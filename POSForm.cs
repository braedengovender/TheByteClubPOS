using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static TheByteClubPOS.dsSamsLiqourShop;
using Microsoft.VisualBasic; // Required for Interaction.InputBox
using System.Drawing.Printing;
using Newtonsoft.Json;
using System.Net.Http;


namespace TheByteClubPOS
{
    public partial class POSForm : Form
    {
        private bool isDarkMode = false;
        int clearButtonClickCount = 0;
        int currentEmployeeID;
        int? currentCustomerID = null;
        private bool allowLoyaltyPoints = true; // Global toggle logic for points system
        public int selectedPaymentMethodID = 0;
        int saleID;
        int newCustLoyaltyPointsBalance;

        
        public System.Windows.Forms.Button btnChangeTheme
        { 
            get {  return btnToggleTheme; }
        }

        private bool IsCashPaymentValid()
        {
            // If the payment method isn't Cash, skip validation entirely
            if (!comboBox1.Text.Trim().Equals("Cash", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            // 1. Guard Check: Empty textbox
            if (string.IsNullOrWhiteSpace(txtAmountTendered.Text))
            {
                MessageBox.Show("Please enter the amount of cash tendered by the customer.", "Tendered Amount Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmountTendered.Focus();
                return false;
            }

            // 2. Guard Check: Invalid format
            decimal amountTendered;
            if (!decimal.TryParse(txtAmountTendered.Text.Trim(), out amountTendered))
            {
                MessageBox.Show("Invalid amount entered! Please type a valid cash number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmountTendered.Focus();
                return false;
            }

            // 3. Guard Check: Negative values
            if (amountTendered < 0m)
            {
                MessageBox.Show("Tendered amount cannot be negative.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmountTendered.Focus();
                return false;
            }

            // 4. Guard Check: Short Payment
            decimal totalPayable = getTotal();
            if (amountTendered < totalPayable)
            {
                decimal shortAmount = totalPayable - amountTendered;
                MessageBox.Show($"Insufficient funds! \nThe customer gave R{amountTendered.ToString("F2")},\nbut the total is R{totalPayable.ToString("F2")}.\nThey still owe: R{shortAmount.ToString("F2")}", "Short Payment", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtAmountTendered.Focus();
                return false;
            }

            return true; // The numbers are good to go!
        }
        private bool IsCustomerOfAge(string preLoadedID = "")
        {
            string idNumber = preLoadedID;

            // If no ID was passed from the database, prompt the cashier manually
            if (string.IsNullOrWhiteSpace(idNumber))
            {
                // Prompt the cashier to type in the customer's 13-digit SA ID number
                idNumber = Interaction.InputBox("Please enter the customer's 13-digit South African ID number for age verification:", "Age Verification", "");
            }

            // Clean up any accidental spaces typed by the cashier
            idNumber = idNumber.Trim();

            // 2. Validate basic length requirements
            if (idNumber.Length != 13)
            {
                MessageBox.Show("Invalid ID number! It must be exactly 13 digits long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                // 3. Extract birth date components from the first 6 digits (YYMMDD)
                int yearPart = Convert.ToInt32(idNumber.Substring(0, 2));
                int month = Convert.ToInt32(idNumber.Substring(2, 2));
                int day = Convert.ToInt32(idNumber.Substring(4, 2));

                // 4. Determine the correct century for the birth year
                // If year digits are less than or equal to current year (e.g., 26), it's 20xx. Otherwise, 19xx.
                int currentYearTwoDigits = DateTime.Today.Year % 100; // e.g., 26
                int fullBirthYear = (yearPart <= currentYearTwoDigits) ? (2000 + yearPart) : (1900 + yearPart);

                // 5. Build the birth date object safely
                DateTime birthDate = new DateTime(fullBirthYear, month, day);

                // 6. Calculate age relative to today
                int age = DateTime.Today.Year - birthDate.Year;

                // Adjust age downward if the customer hasn't had their birthday yet this year
                if (DateTime.Today < birthDate.AddYears(age))
                {
                    age--;
                }

                // 7. Check if they meet the legal liquor consumption threshold
                if (age >= 18)
                {
                    return true; // Verification passed
                }
                else
                {
                    MessageBox.Show($"Customer is UNDERAGE! The customer is only {age} years old.", "Sale Blocked", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }
            catch
            {
                // Catches conversion errors if someone types letters instead of numbers, or invalid dates like month 15
                MessageBox.Show("Could not process ID number. Ensure it contains a valid date sequence.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public int getItemCount()
        {
            int count = 0;
            foreach (DataRow row in this.dsSamsLiqourShop.Cart.Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    count += Convert.ToInt32(row["SaleLine_Quantity"]);
                }
            }
            return count;
        }

        private decimal getSubtotal()
        {
            decimal subtotal = 0;
            foreach (DataRow row in this.dsSamsLiqourShop.Cart.Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    subtotal += Convert.ToDecimal(row["SaleLine_OriginalUnitPrice"]) * Convert.ToDecimal(row["SaleLine_Quantity"]);
                }
            }
            return subtotal;
        }

        private decimal getDiscountAmount()
        {
            decimal discountAmount = 0;
            foreach (DataRow row in this.dsSamsLiqourShop.Cart.Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    decimal originalPrice = row["SaleLine_OriginalUnitPrice"] == DBNull.Value ? 0 : Convert.ToDecimal(row["SaleLine_OriginalUnitPrice"]);

                    decimal discountedPrice = row["SaleLine_UnitPriceAfterDiscount"] == DBNull.Value ? originalPrice : Convert.ToDecimal(row["SaleLine_UnitPriceAfterDiscount"]);

                    // Extract the quantity of items purchased
                    int quantity = row["SaleLine_Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(row["SaleLine_Quantity"]);

                    discountAmount += (originalPrice - discountedPrice) * quantity; ;
                }
            }
            return discountAmount;
        }

        private decimal getTotal()
        {
            decimal total = 0;
            foreach (DataRow row in this.dsSamsLiqourShop.Cart.Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    total += Convert.ToDecimal(row["SaleLine_Subtotal"]);
                }
            }
            return total;
        }

        private decimal getVat()
        {
            decimal vat = getTotal() * (15m / 115m);
            return vat;
        }
        private void updateStockQuantityInDatabase()
        {
            foreach (DataRow row in this.dsSamsLiqourShop.Cart.Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    int productID = Convert.ToInt32(row["Product_ID"]);
                    int quantityPurchased = Convert.ToInt32(row["SaleLine_Quantity"]);
                    // Call your TableAdapter's custom method to update the quantity
                    productTableAdapter.UpdateQueryProductQuantity(productID, -quantityPurchased);
                }
            }
        }
        private void clearForm()
        {
            // 1. Clear the data cart table (This empties your DataGridView instantly)
            this.dsSamsLiqourShop.Cart.Clear();

            // 2. Wipe your global tracking variables back to safe defaults
            currentCustomerID = null;
            clearButtonClickCount = 0; // Fixes search box placeholder toggle behavior
            saleID = 0;
            newCustLoyaltyPointsBalance = 0;

            allowLoyaltyPoints = true;

            // 3. Reset Loyalty UI items back to a Walk-In guest state
            maskedTextBox1.Text = "";
            lblName.Text = "Walk-in Customer";
            lblPointsAmount.Text = "0";

            // 4. Reset Payment Details & Fields
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0; // Automatically triggers its event to toggle fields
            }
            txtAmountTendered.Text = "";

            // 5. Recalculate and refresh the total labels to show zero values
            lblSubtotalAmount.Text = getSubtotal().ToString("C2");
            lblDiscountAmount.Text = getDiscountAmount().ToString("C2");
            lblTotalAmount.Text = getTotal().ToString("C2");
            lblVatAmount.Text = getVat().ToString("C2");
            lblCount.Text = getItemCount().ToString();

            // REFRESH THE PRODUCT DATAGRID HERE
            this.productTableAdapter.Fill(this.dsSamsLiqourShop.Product);

            // 6. Set focus back to your primary input for speed (like product scanning or lookup)
            maskedTextBox1.Focus();
        }
        public POSForm()
        {
            InitializeComponent();
        }

        private void POSForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.Discount' table. You can move, or remove it, as needed.
            this.discountTableAdapter.Fill(this.dsSamsLiqourShop.Discount);
            // Filter out the automatic item-level discount rows so the cashier cannot manually pick them
            discountBindingSource.Filter = "Discount_Name <> 'Johnnie Walker 20% off' AND Discount_Name <> 'Wine Wednesday 10% off'";
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.SaleType' table. You can move, or remove it, as needed.
            this.saleTypeTableAdapter.Fill(this.dsSamsLiqourShop.SaleType);
            this.saleTypeBindingSource.Filter = "SaleType_ID <> 2";
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.SaleLine' table. You can move, or remove it, as needed.
            this.saleLineTableAdapter.Fill(this.dsSamsLiqourShop.SaleLine);
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.Sale' table. You can move, or remove it, as needed.
            this.saleTableAdapter.Fill(this.dsSamsLiqourShop.Sale);
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.dsSamsLiqourShop.Customer);
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.PaymentMethod' table. You can move, or remove it, as needed.
            this.paymentMethodTableAdapter.Fill(this.dsSamsLiqourShop.PaymentMethod);
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.PaymentMethod' table. You can move, or remove it, as needed.
            this.paymentMethodTableAdapter.Fill(this.dsSamsLiqourShop.PaymentMethod);
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.dsSamsLiqourShop.Product);
            productBindingSource.Filter = "Product_Status = 'Active'";

            // 2. GRAB THE REAL EMPLOYEE ID FROM THE PARENT FORM
            if (this.MdiParent != null)
            {
                // Replace 'MainMenuForm' with the exact name of your main parent form class!
                MainForm parent = (MainForm)this.MdiParent;

                // This copies the parent form's login variable straight into your child form's variable
                this.currentEmployeeID = parent.employeeID;
            }

            // Default your combo box selection
            if (comboBox1.Items.Count > 0) comboBox1.SelectedIndex = 0;

            // Automatically match theme state when initialized
            if (this.MdiParent is MainForm mainForm && mainForm.IsDarkMode)
            {
                ApplyDarkMode();
            }
            else
            {
                ApplyLightMode();
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            productTableAdapter.FillByProductSearch(dsSamsLiqourShop.Product, txtSearch.Text);
            productBindingSource.Filter = "Product_Status = 'Active'";
        }

        private void lblLoyaltyProgram_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void productDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            // Ensure the user clicked a valid row data index, not the header row (-1)
            if (e.RowIndex < 0) return;

            int productID = Convert.ToInt32(this.productDataGridView.CurrentRow.Cells[0].Value);
            string productName = this.productDataGridView.CurrentRow.Cells[2].Value.ToString();
            decimal price = Convert.ToDecimal(this.productDataGridView.CurrentRow.Cells[6].Value);
            decimal productAlcoholPercentage = (this.productDataGridView.CurrentRow.Cells["Product_AlcoholPercentage"].Value == DBNull.Value) ? 0m : Convert.ToDecimal(this.productDataGridView.CurrentRow.Cells["Product_AlcoholPercentage"].Value);
            
            // Default our calculation variable to the original price
            decimal unitPriceAfterDiscount = price;
            int? appliedDiscountID = null;
            string foundDiscountName = "";
            bool isDiscountApplied = false;

            // Extract Discount Info using your exact column specifications
            /*int discountID = 0;
            if (this.productDataGridView.CurrentRow.Cells["Discount_ID"].Value != DBNull.Value)
            {
                discountID = Convert.ToInt32(this.productDataGridView.CurrentRow.Cells["Discount_ID"].Value);
            }*/

            //string productType = (this.productDataGridView.CurrentRow.Cells["Product_Type"].Value == DBNull.Value) ? "" : this.productDataGridView.CurrentRow.Cells["Product_Type"].Value.ToString();

            // DYNAMIC DATABASE PROMOTION LOOKUP 
            // Check if this product actually has a Discount_ID assigned to it
            if (this.productDataGridView.CurrentRow.Cells["Discount_ID"].Value != DBNull.Value)
            {
                int productDiscountID = Convert.ToInt32(this.productDataGridView.CurrentRow.Cells["Discount_ID"].Value);

                // Find the matching promotion row inside your local Discount table dataset
                DataRow[] matchingDiscounts = this.dsSamsLiqourShop.Discount.Select($"Discount_ID = {productDiscountID}");

                if (matchingDiscounts.Length > 0)
                {
                    DataRow discountRow = matchingDiscounts[0];

                    // Extract validation properties from the database row
                    int status = Convert.ToInt32(discountRow["Discount_Status"]);
                    DateTime startDate = Convert.ToDateTime(discountRow["Discount_StartDate"]);
                    DateTime endDate = Convert.ToDateTime(discountRow["Discount_EndDate"]);
                    DateTime today = DateTime.Now;
                    string promoName = discountRow["Discount_Name"].ToString();

                    // EXPLICIT GUARD: Wine Wednesday promos only run on Wednesdays
                    bool isWineWednesdayValid = true;
                    if (promoName.ToLower().Contains("wednesday") && today.DayOfWeek != DayOfWeek.Wednesday)
                    {
                        isWineWednesdayValid = false;
                    }

                    // RULE CHECK: Only calculate if status is active (1) AND today falls between the start and end dates
                    if (status == 1 && today >= startDate && today <= endDate && isWineWednesdayValid)
                    {
                        string discountType = discountRow["Discount_Type"].ToString();
                        decimal discountValue = Convert.ToDecimal(discountRow["Discount_Value"]);

                        // Evaluate calculation strategy dynamically based on database values
                        if (discountType.Equals("Percentage", StringComparison.OrdinalIgnoreCase))
                        {
                            unitPriceAfterDiscount = price * (1m - (discountValue / 100m));
                        }
                        else if (discountType.Equals("Fixed", StringComparison.OrdinalIgnoreCase))
                        {
                            // Ensure a fixed discount doesn't accidentally drop the unit price below zero
                            unitPriceAfterDiscount = Math.Max(0m, price - discountValue);
                        }

                        appliedDiscountID = productDiscountID;
                        foundDiscountName = promoName;
                        isDiscountApplied = true;
                    }
                }
            }

            bool itemExistsInCart = false;

            // 2. Scan your Strongly-Typed Cart Rows to see if the product is already added
            foreach (DataRow row in this.dsSamsLiqourShop.Cart.Rows)
            {
                // Skip rows marked for deletion
                if (row.RowState == DataRowState.Deleted) continue;

                if (Convert.ToInt32(row["Product_ID"]) == productID)
                {
                    // Item found! Grab current quantity, bump it up by 1
                    int currentQty = Convert.ToInt32(row["SaleLine_Quantity"]);
                    int newQty = currentQty + 1;

                    row["SaleLine_Quantity"] = newQty;
                    row["SaleLine_UnitPriceAfterDiscount"] = unitPriceAfterDiscount;
                    row["SaleLine_Subtotal"] = newQty * unitPriceAfterDiscount;

                    // Apply types or handle database NULL explicitly without object variables
                    if (isDiscountApplied)
                    {
                        row["Discount_Name"] = foundDiscountName;
                        row["Discount_ID"] = (object)appliedDiscountID ?? DBNull.Value;
                    }
                    else
                    {
                        row["Discount_Name"] = DBNull.Value;
                        row["Discount_ID"] = DBNull.Value;
                    }

                    itemExistsInCart = true;
                    break; // Stop looking, we found it
                }
            }

            // 3. If it's a brand new item choice, append a clean new line row entry
            if (!itemExistsInCart)
            {
                int initialQuantity = 1;
                decimal initialSubtotal = initialQuantity * unitPriceAfterDiscount;
                DataRow newCartRow = this.dsSamsLiqourShop.Cart.Rows.Add(productID, productName, price, isDiscountApplied ? (object)appliedDiscountID : DBNull.Value, isDiscountApplied ? (object)foundDiscountName : DBNull.Value, unitPriceAfterDiscount, initialQuantity, initialSubtotal, productAlcoholPercentage);
            }

            lblSubtotalAmount.Text = getSubtotal().ToString("C2");
            lblDiscountAmount.Text = getDiscountAmount().ToString("C2");
            lblTotalAmount.Text = getTotal().ToString("C2");
            lblVatAmount.Text = getVat().ToString("C2");
            lblCount.Text = getItemCount().ToString();
        }

        private void productDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            this.dsSamsLiqourShop.Cart.Rows.Clear();
            
            lblSubtotalAmount.Text = "R0000.00";
            lblTotalAmount.Text = "R0000.00";
            lblCount.Text = "0";
            lblVatAmount.Text = "R0000.00";
            lblDiscountAmount.Text = "R0000.00";
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            // Check if there is actually a row selected in the grid
            if (cartDataGridView.CurrentRow != null)
            {
                int rowIndex = cartDataGridView.CurrentRow.Index;
                // Access the specific cell value directly
                int currentQty = Convert.ToInt32(this.dsSamsLiqourShop.Cart.Rows[rowIndex]["SaleLine_Quantity"]);

                if (currentQty > 1)
                {
                    // Just decrease the quantity directly in the table
                    int newQty = currentQty - 1;
                    this.dsSamsLiqourShop.Cart.Rows[rowIndex]["SaleLine_Quantity"] = newQty;

                    decimal unitPriceAfterDiscount = Convert.ToDecimal(this.dsSamsLiqourShop.Cart.Rows[rowIndex]["SaleLine_UnitPriceAfterDiscount"]);
                    this.dsSamsLiqourShop.Cart.Rows[rowIndex]["SaleLine_Subtotal"] = unitPriceAfterDiscount * newQty;
                }
                else
                {
                    // Quantity is 1, so remove the row
                    this.dsSamsLiqourShop.Cart.Rows[rowIndex].Delete();
                }

                cartDataGridView.Refresh();
                cartBindingSource.ResetBindings(false);

                lblSubtotalAmount.Text = getSubtotal().ToString("C2");
                lblDiscountAmount.Text = getDiscountAmount().ToString("C2");
                lblTotalAmount.Text = getTotal().ToString("C2");
                lblVatAmount.Text = getVat().ToString("C2");
                lblCount.Text = getItemCount().ToString();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            if (clearButtonClickCount == 0)
            {
                txtSearch.Text = "";
                clearButtonClickCount++;
                txtSearch.ForeColor = isDarkMode ? Color.White : Color.Black;
                txtSearch.Font = new Font(txtSearch.Font, FontStyle.Regular);
            }
        }

        public void ApplyDarkMode()
        {
            isDarkMode = true;

            this.BackgroundImage = Properties.Resources.Dark_Background;
            this.BackColor = Color.FromArgb(32, 32, 32); // Dark Charcoal
            this.ForeColor = Color.White;
            btnToggleTheme.Text = "Switch to Light Mode";
            btnToggleTheme.BackColor = Color.FromArgb(50, 50, 50);
            btnToggleTheme.ForeColor = Color.White;
            
            comboBox1.BackColor = Color.FromArgb(40, 40, 40);
            comboBox1.ForeColor = Color.White;

            txtSearch.BackColor = Color.FromArgb(45, 45, 45); // Sleek input dark gray
            txtSearch.ForeColor = Color.White;                // Force text to White

            productDataGridView.BackgroundColor = Color.FromArgb(45, 45, 48);
            productDataGridView.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            productDataGridView.DefaultCellStyle.ForeColor = Color.White;
            productDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            productDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            cartDataGridView.BackgroundColor = Color.FromArgb(45, 45, 48);
            cartDataGridView.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            cartDataGridView.DefaultCellStyle.ForeColor = Color.White;
            cartDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            cartDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            productDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(32, 32, 32);
            productDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            productDataGridView.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(32, 32, 32);
            productDataGridView.RowHeadersDefaultCellStyle.ForeColor = Color.White;

            cartDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(32, 32, 32);
            cartDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            cartDataGridView.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(32, 32, 32);
            cartDataGridView.RowHeadersDefaultCellStyle.ForeColor = Color.White;

            // Loop through all controls to apply the theme
            UpdateControlThemes(this.Controls, Color.FromArgb(32, 32, 32), Color.White);
        }

        public void ApplyLightMode()
        {
            isDarkMode = false;
            this.BackgroundImage = Properties.Resources.Background;
            this.BackColor = SystemColors.Control;
            this.ForeColor = SystemColors.ControlText;
            btnToggleTheme.Text = "Switch to Dark Mode";
            btnToggleTheme.BackColor = SystemColors.ControlLight;
            btnToggleTheme.ForeColor = SystemColors.ControlText;

            comboBox1.BackColor = Color.White;
            comboBox1.ForeColor = Color.Black;

            txtSearch.BackColor = Color.White;
            txtSearch.ForeColor = Color.Black; // Reset text to Black

            productDataGridView.BackgroundColor = Color.White;
            productDataGridView.DefaultCellStyle.BackColor = Color.White;
            productDataGridView.DefaultCellStyle.ForeColor = Color.Black;
            productDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            productDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            cartDataGridView.BackgroundColor = Color.White;
            cartDataGridView.DefaultCellStyle.BackColor = Color.White;
            cartDataGridView.DefaultCellStyle.ForeColor = Color.Black;
            cartDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            cartDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            productDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            productDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            productDataGridView.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;
            productDataGridView.RowHeadersDefaultCellStyle.ForeColor = Color.Black;

            cartDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            cartDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            cartDataGridView.RowHeadersDefaultCellStyle.BackColor = Color.LightGray;
            cartDataGridView.RowHeadersDefaultCellStyle.ForeColor = Color.Black;

            UpdateControlThemes(this.Controls, SystemColors.Control, SystemColors.ControlText);
        }

        private void UpdateControlThemes(Control.ControlCollection controls, Color backColor, Color foreColor)
        {
            foreach (Control c in controls)
            {
                // Leave the main toggle button alone to retain its custom styling
                if (c == btnToggleTheme) continue;

                c.ForeColor = foreColor;

                // Identify controls that should always blend into the background seamlessly
                if (c is Label || c is CheckBox || c is RadioButton || c is PictureBox || c is Panel || c is TableLayoutPanel || c is FlowLayoutPanel)
                {
                    c.BackColor = Color.Transparent;
                }
                else
                {
                    // Structural layouts, panels, and input boxes keep the actual solid theme background
                    c.BackColor = backColor;
                }

                // If the control contains nested elements (like a Panel or GroupBox), loop through them too
                if (c.HasChildren)
                {
                    UpdateControlThemes(c.Controls, backColor, foreColor);
                }
            }
        }
       
        private void btnToggleTheme_Click(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;

            if (isDarkMode)
                ApplyDarkMode();
            else
                ApplyLightMode();
        }

        private void btnLookup_Click(object sender, EventArgs e)
        {
            
            maskedTextBox1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            string idOrPhoneNumber = maskedTextBox1.Text.Trim();
            lblName.Text = "Searching...";
            lblPointsAmount.Text = "0";
            currentCustomerID = null;

            maskedTextBox1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

            try
            {
                customerTableAdapter.FillByIDOrPhoneNumber(this.dsSamsLiqourShop.Customer, idOrPhoneNumber);

                if (this.dsSamsLiqourShop.Customer.Rows.Count > 0)
                {
                    DataRow customerRow = this.dsSamsLiqourShop.Customer.Rows[0];
                    string customerStatus = customerRow["Customer_Status"].ToString();
                    currentCustomerID = Convert.ToInt32(customerRow["Customer_ID"]);
                    lblName.Text = customerRow["Customer_FirstName"].ToString() + " " + customerRow["Customer_LastName"].ToString();
                    lblPointsAmount.Text = customerRow["Customer_LoyaltyPointsBalance"].ToString();


                    if (customerStatus == "Inactive")
                    {
                        allowLoyaltyPoints = false; // LOCK OUT point accumulation
                        MessageBox.Show(
                            "This customer account is inactive. Loyalty points will not be added to purchases.",
                            "Inactive Customer",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                    else
                    {
                        allowLoyaltyPoints = true; // UNLOCK point accumulation safely
                        // SUCCESS POPUP: Gives clear confirmation to the cashier
                        MessageBox.Show($"Customer profile found successfully!\n\nName: {lblName.Text}", "Profile Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                       
                }
                else
                {
                    lblName.Text = "Walk-in Customer";
                    lblPointsAmount.Text = "0";
                    currentCustomerID = null; // Revert to walk-in status
                    MessageBox.Show("No customer found with that ID or phone number.", "Lookup Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to communicate with database." + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 1. Guard Clause: Make sure an actual item is selected
            if (comboBox1.SelectedItem == null) return;

            selectedPaymentMethodID = Convert.ToInt32(comboBox1.SelectedValue);
            

            // 4. Activate amount tendered IF the option is "Cash" (case-insensitive check)
            if (comboBox1.Text.Trim().Equals("Cash", StringComparison.OrdinalIgnoreCase))
            {
                txtAmountTendered.Visible = true;
                lblAmountTendered.Visible = true;
                txtAmountTendered.Enabled = true;
                txtAmountTendered.BackColor = Color.White; // Highlighting it as active
                txtAmountTendered.Focus();                 // Automatically place the cursor inside
                lblAmountTendered.Text = "Amount Tendered:";
            }
            else if (comboBox1.Text.Trim().Equals("Card", StringComparison.OrdinalIgnoreCase))
            {
                txtAmountTendered.Enabled = false;
                txtAmountTendered.Visible = false;
                lblAmountTendered.Visible = false;

            }
            else if (comboBox1.Text.Trim().Equals("Loyalty Points", StringComparison.OrdinalIgnoreCase))
            {
                txtAmountTendered.Visible = true;
                lblAmountTendered.Visible = true;
                txtAmountTendered.Enabled = true;
                txtAmountTendered.BackColor = Color.White; // Highlighting it as active
                txtAmountTendered.Focus();
                lblAmountTendered.Text = "Loyalty Points to Use:";
            }
            else if (comboBox1.Text.Trim().Equals("Voucher", StringComparison.OrdinalIgnoreCase))
            {
                txtAmountTendered.Visible = true;
                lblAmountTendered.Visible = true;
                txtAmountTendered.Enabled = true;
                txtAmountTendered.BackColor = Color.White; // Highlighting it as active
                txtAmountTendered.Focus();
                lblAmountTendered.Text = "Voucher Number:";
            }
            else
            {
                txtAmountTendered.Enabled = false;
                txtAmountTendered.Text = "";
                //txtAmountTendered.BackColor = Color.LightGray; // Grayed out style visual cue

                // For non-cash transactions, Amount Tendered is automatically the exact total
                //lblChangeAmount.Text = "R 0.00";
            }

        }

        private void saveSaleLines(int saleID)
        {
            // Loop through every product row sitting in your temporary memory cart
            foreach (DataRow cartRow in this.dsSamsLiqourShop.Cart.Rows)
            {
                // Skip rows marked for deletion
                if (cartRow.RowState == DataRowState.Deleted) continue;

                // 1. Extract the column data from the current cart row
                // (Make sure these string names match your Cart DataTable columns exactly!)
                int productID = Convert.ToInt32(cartRow["Product_ID"]);
                int qty = Convert.ToInt32(cartRow["SaleLine_Quantity"]);
                decimal originalPrice = Convert.ToDecimal(cartRow["SaleLine_OriginalUnitPrice"]);
                decimal priceAfterDiscount = Convert.ToDecimal(cartRow["SaleLine_UnitPriceAfterDiscount"]);
                decimal subtotal = Convert.ToDecimal(cartRow["SaleLine_Subtotal"]);

                int? discountID = null;

                if (cartRow["Discount_ID"] != DBNull.Value)
                {
                    discountID = Convert.ToInt32(cartRow["Discount_ID"]);
                }

                // 2. Fire your newly created wizard query with all 7 required arguments
                this.saleLineTableAdapter.InsertQuerySaleLine(saleID, productID, discountID, qty, originalPrice, priceAfterDiscount, subtotal);
            }
        }

        private async Task<bool> SendReceiptEmailAsync(string customerEmail, string customerName, string invoiceId, decimal subtotal, decimal discount, decimal vatAmount, decimal totalAmount, decimal amountTendered, decimal changeDue, string loyaltyInfo, string paymentMethod, int totalItemsCount, string employeeName, string saleType)
        {
            string resendApiKey = "re_f847CzLx_EWHwBfQgKrR22NXkpKjbHTzb";

            try
            {
                // 1. ---- PROFESSIONAL HTML ENTERPRISE RECEIPT DESIGN ----
                StringBuilder htmlBuilder = new StringBuilder();
                htmlBuilder.Append("<div style='font-family: Arial, sans-serif; max-width: 500px; margin: 0 auto; border: 1px solid #dcdde1; padding: 30px; border-radius: 8px; background-color: #ffffff; color: #2f3640;'>");

                // --- STORE HEADER ---
                htmlBuilder.Append("<div style='text-align: center; margin-bottom: 25px; border-bottom: 2px solid #00a8ff; padding-bottom: 15px;'>");
                htmlBuilder.Append("<h2 style='margin: 0; color: #0097e6; font-size: 24px;'>Sam's Liquor Shop</h2>");
                htmlBuilder.Append("<p style='margin: 4px 0; font-size: 13px; color: #718093;'>21 Coronation Road, Mithangar</p>");
                htmlBuilder.Append("<p style='margin: 4px 0; font-size: 13px; color: #718093;'>Tongaat, 4399</p>");
                htmlBuilder.Append("</div>");

                // --- INVOICE & CUSTOMER INFO ---
                htmlBuilder.Append("<div style='margin-bottom: 20px; font-size: 13px;'>");
                htmlBuilder.Append($"<p style='margin: 4px 0;'><strong>Invoice:</strong> <span style='color: #0097e6;'>INV-{invoiceId}</span></p>");
                htmlBuilder.Append($"<p style='margin: 4px 0;'><strong>Date:</strong> {DateTime.Now:dd MMM yyyy HH:mm}</p>");
                htmlBuilder.Append($"<p style='margin: 4px 0;'><strong>Customer:</strong> {customerName}</p>");
                htmlBuilder.Append($"<p style='margin: 4px 0;'><strong>Sale Type:</strong> {saleType}</p>");
                htmlBuilder.Append($"<p style='margin: 4px 0;'><strong>Served by:</strong> {employeeName}</p>");
                htmlBuilder.Append($"<p style='margin: 4px 0;'><strong>Loyalty Balance:</strong> {loyaltyInfo}</p>");
                htmlBuilder.Append("</div>");

                // --- LINE ITEMS ---
                htmlBuilder.Append("<table style='width: 100%; border-collapse: collapse; font-size: 13px; margin-bottom: 15px;'>");
                htmlBuilder.Append("<tr style='background-color: #0097e6; color: #ffffff; border-radius: 4px;'><th style='text-align: left; padding: 8px;'>Description</th><th style='text-align: center; padding: 8px;'>Qty</th><th style='text-align: right; padding: 8px;'>Total</th></tr>");

                foreach (System.Data.DataRow row in this.dsSamsLiqourShop.Cart.Rows)
                {
                    string productName = row["Product_Name"] != DBNull.Value ? row["Product_Name"].ToString() : "Item";
                    int qty = row["SaleLine_Quantity"] != DBNull.Value ? Convert.ToInt32(row["SaleLine_Quantity"]) : 1;

                    // Prices
                    decimal totalPaidForLine = row["SaleLine_UnitPriceAfterDiscount"] != DBNull.Value ? Convert.ToDecimal(row["SaleLine_UnitPriceAfterDiscount"]) : 0.00m;
                    decimal originalUnitPrice = row["SaleLine_OriginalUnitPrice"] != DBNull.Value ? Convert.ToDecimal(row["SaleLine_OriginalUnitPrice"]) : 0.00m;

                    // Calc unit price and discount
                    decimal unitPriceAfter = qty > 0 ? (totalPaidForLine / qty) : totalPaidForLine;
                    decimal discountPerUnit = originalUnitPrice - unitPriceAfter;

                    htmlBuilder.Append($"<tr style='border-bottom: 1px solid #f5f6fa;'>");
                    htmlBuilder.Append($"<td style='padding: 8px;'>{productName}<br/>");
                    htmlBuilder.Append($"<span style='font-size: 11px; color: #7f8c8d;'>@ R {unitPriceAfter:F2} each</span>");

                    // Only show discount if there is a saving
                    if (discountPerUnit > 0.01m)
                    {
                        htmlBuilder.Append($" <span style='font-size: 11px; color: #44bd32;'>(-R {discountPerUnit:F2} off)</span>");
                    }
                    htmlBuilder.Append($"</td>");

                    htmlBuilder.Append($"<td style='text-align: center; padding: 8px;'>{qty}</td>");
                    htmlBuilder.Append($"<td style='text-align: right; padding: 8px;'>R {totalPaidForLine:F2}</td>");
                    htmlBuilder.Append($"</tr>");
                }
                htmlBuilder.Append("</table>");

                // --- FINANCIAL TOTALS ---
                htmlBuilder.Append("<div style='font-size: 13px; padding-top: 10px;'>");
                htmlBuilder.Append($"<div style='display: flex; justify-content: space-between; margin: 4px 0;'><span>Total Items:</span> <span>{totalItemsCount}</span></div>");
                htmlBuilder.Append($"<div style='display: flex; justify-content: space-between; margin: 4px 0;'><span>Subtotal:</span> <span>R {subtotal:F2}</span></div>");

                if (discount > 0)
                {
                    htmlBuilder.Append($"<div style='display: flex; justify-content: space-between; margin: 4px 0; color: #44bd32;'><span>Discount Applied:</span> <span>- R {discount:F2}</span></div>");
                }

                htmlBuilder.Append($"<div style='display: flex; justify-content: space-between; margin: 4px 0; color: #7f8c8d; font-size: 11px;'><span>Includes 15% VAT:</span> <span>R {vatAmount:F2}</span></div>");
                htmlBuilder.Append("</div>");

                // --- PAYMENT BLOCK ---
                htmlBuilder.Append("<div style='background-color: #f5f6fa; border-left: 4px solid #00a8ff; padding: 15px; border-radius: 4px; font-size: 14px; margin-top: 15px;'>");
                htmlBuilder.Append($"<div style='margin: 4px 0; display: flex; justify-content: space-between;'><strong>TOTAL PAID:</strong> <strong style='font-size: 16px; color: #0097e6;'>R {totalAmount:F2}</strong></div>");
                htmlBuilder.Append($"<div style='margin: 8px 0 4px 0; display: flex; justify-content: space-between; font-size: 13px;'><span>Payment Method:</span> <strong>{paymentMethod}</strong></div>");

                if (paymentMethod.Equals("Cash", StringComparison.OrdinalIgnoreCase))
                {
                    htmlBuilder.Append($"<div style='margin: 4px 0; display: flex; justify-content: space-between; font-size: 13px;'><span>Tendered:</span> <span>R {amountTendered:F2}</span></div>");
                    htmlBuilder.Append($"<div style='margin: 4px 0; display: flex; justify-content: space-between; font-size: 13px;'><span>Change:</span> <span>R {changeDue:F2}</span></div>");
                }
                htmlBuilder.Append("</div>");

                htmlBuilder.Append("<p style='color: #7f8c8d; font-size: 11px; margin-top: 25px; font-style: italic; text-align: center;'>Thank you for shopping at Sam's Liquor Shop.<br/>Powered by The Byte Club POS.</p>");
                htmlBuilder.Append("</div>");

                // 2. ---- CONSTRUCT RESEND JSON PAYLOAD ----
                var emailPayload = new
                {
                    from = "The Byte Club Helpdesk <onboarding@resend.dev>",
                    to = "theofficialbyteclub@gmail.com",
                    subject = $"🧾 E-Receipt: INV-{invoiceId} from Sam's Liquor Shop",
                    html = htmlBuilder.ToString()
                };

                string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(emailPayload);
                var httpContent = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");

                // 3. ---- POST ROUTE ----
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {resendApiKey}");

                    HttpResponseMessage response = await client.PostAsync("https://api.resend.com/emails", httpContent);

                    return response.IsSuccessStatusCode;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Email System Error: {ex.Message}", "Email Engine Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private async void btnCompleteSale_Click(object sender, EventArgs e)
        {
            
            // 1. Guard check: make sure there's actually something in the cart
            if (this.dsSamsLiqourShop.Cart.Rows.Count == 0)
            {
                MessageBox.Show("The cart is empty. Cannot complete a sale.", "Cart Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cash & Tendered validation check
            if (IsCashPaymentValid() == false)
            {
                return; // Stops the sale if cash calculations fail or money is short
            }

            // Check if the masked textbox actually contains characters (excluding mask prompt/literals)
            maskedTextBox1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            bool hasInput = !string.IsNullOrWhiteSpace(maskedTextBox1.Text.Replace("-", "").Trim());
            maskedTextBox1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

            if (currentCustomerID == null)
            {
                if (hasInput)
                {
                    // If they typed something but forgot to click lookup, run it automatically
                    btnLookup_Click(null, null);
                }
                else
                {
                    // If the box is completely empty, prompt them with your custom confirmation box
                    DialogResult loyaltyCheck = MessageBox.Show("Are you sure that this customer does not have a loyalty account?", "Loyalty Account Verification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (loyaltyCheck == DialogResult.No)
                    {
                        return; // Stops the sale entirely so they can input the number!
                    }
                    else
                    {
                        // Clear instructions mapping to standard MessageBox buttons
                        string prompt = "Does the Customer want to create a loyalty account?\n\n" +
                                        "• Click YES to open the 'Add New Customer' screen.\n" +
                                        "• Click NO to proceed as a Walk-in Customer.\n" +
                                        "• Click CANCEL to go back and type in their ID.";

                        DialogResult loyaltyCheckMessageBox = MessageBox.Show(prompt, "Customer Verification", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                        if (loyaltyCheckMessageBox == DialogResult.Cancel)
                        {
                            return; // Stops the sale entirely
                        }
                        else if (loyaltyCheckMessageBox == DialogResult.Yes)
                        {
                            // Access the MDI Parent and trigger its button click programmatically
                            if (this.MdiParent is MainForm mainForm)
                            {
                                mainForm.OpenAddCustomerFormOnly();
                            }

                            // Stop the current checkout process so they can fill out the registration
                            return;
                        }

                        // If they click NO, the code naturally ignores the 'if' statements 
                        // and continues down to process the sale as a Walk-in!
                    }
                }
            }

            // Automatic Profile Lookup Guard
            // If the cashier forgot to hit "Lookup" but typed a number into the masked box anyway, pull it now
            /*if (currentCustomerID == null && !string.IsNullOrWhiteSpace(maskedTextBox1.Text.Replace("-", "").Trim()))
            {
                // Programmatically trigger the lookup button click!
                btnLookup_Click(null, null);
            }*/

            string customerIDFromDB = "";

            // If a registered customer profile is successfully active in memory
            if (currentCustomerID != null && this.dsSamsLiqourShop.Customer.Rows.Count > 0)
            {
                DataRow customerRow = this.dsSamsLiqourShop.Customer.Rows[0];

                if (customerRow["Customer_IDNumber"] != DBNull.Value)
                {
                    customerIDFromDB = customerRow["Customer_IDNumber"].ToString();
                }
            }

            // Scan the cart to see if any item contains alcohol
            bool cartContainsAlcohol = false;

            foreach (DataRow row in this.dsSamsLiqourShop.Cart.Rows)
            {
                // Safely parse the alcohol percentage field, handling potential nulls
                decimal alcoholPercent = row["Product_AlcoholPercentage"] == DBNull.Value ? 0m : Convert.ToDecimal(row["Product_AlcoholPercentage"]);

                if (alcoholPercent > 0m)
                {
                    cartContainsAlcohol = true;
                    break; // We found at least one alcoholic item, no need to check the rest!
                }
            }

            // Run Age Verification ONLY if an alcoholic item is present 
            if (cartContainsAlcohol)
            {
                // Run Age Verification
                // Pass the ID string. If it's empty (walk-in), it opens the input box. If it has the DB ID, it runs silently!
                if (IsCustomerOfAge(customerIDFromDB) == false)
                {
                    return; // Stops the sale immediately if underage or invalid ID
                }
            }

            btnCompleteSale.Enabled = false;

            try
            {
                int loyaltyPointsEarned = 0;

                if (currentCustomerID != null && allowLoyaltyPoints)
                {
                    loyaltyPointsEarned = (int)Math.Floor(getTotal() / 10); // Example: 1 point for every R10 spent

                    customerTableAdapter.UpdateQueryCustLoyaltyPoints(loyaltyPointsEarned, Convert.ToInt32(currentCustomerID));
                    newCustLoyaltyPointsBalance = (int)customerTableAdapter.getCustomerLoyaltyPointsBalance(Convert.ToInt32(currentCustomerID));
                }
                else
                {
                    // If the customer is a Walk-in OR their account is Inactive, they explicitly get 0 points
                    loyaltyPointsEarned = 0;
                }

                int chosenSaleTypeID = Convert.ToInt32(comboBox2.SelectedValue);
                string saleTypeText = comboBox2.Text.Trim();
                string paymentMethodUsed = comboBox1.Text.Trim();
                saleID = (int)saleTableAdapter.InsertQueryNewSale(currentCustomerID, currentEmployeeID, chosenSaleTypeID, null, DateTime.Now, getSubtotal(), getDiscountAmount(), getTotal(), loyaltyPointsEarned, "Completed");
                
                saveSaleLines(saleID);
                updateStockQuantityInDatabase();

                decimal amountTendered = 0m;
                decimal changeDue = 0m;

                string changeDetails = "";
                // Sale is completely successful, now show change due to customer
                if (paymentMethodUsed.Equals("Cash", StringComparison.OrdinalIgnoreCase))
                {
                    amountTendered = Convert.ToDecimal(txtAmountTendered.Text.Trim());
                    decimal totalPayable = getTotal();
                    changeDue = amountTendered - totalPayable;

                    if (changeDue > 0m)
                    {
                        changeDetails = $"Total: R {totalPayable.ToString("F2")}\n" + $"Tendered: R {amountTendered.ToString("F2")}\n" + $"Change Due: R {changeDue.ToString("F2")}\n\n";
                    }
                    else
                    {
                        changeDetails = "Exact change provided. No change due.\n\n";
                    }

                    //MessageBox.Show("Sale completed successfully! ID: " + saleID + " Loyalty points earned: " + loyaltyPointsEarned, "Transaction Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    amountTendered = getTotal();
                    // Fallback success message for Card/Other payment types
                    //MessageBox.Show("Sale completed successfully! ID: " + saleID + " Loyalty points earned: " + loyaltyPointsEarned, "Transaction Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                string msgPrompt = "";

                if (currentCustomerID != null && allowLoyaltyPoints)
                {
                    // Profile Customer: Include Loyalty Points details
                    msgPrompt = $"{changeDetails}" + $"Sale completed successfully!\n" + $"Invoice ID: {saleID}\n" + $"Loyalty Points Earned: {loyaltyPointsEarned}\n\n" + $"Would you like to print the receipt?";
                }
                else
                {
                    // Walk-in Customer: Completely remove any mention of loyalty points
                    msgPrompt = $"{changeDetails}" + $"Sale completed successfully!\n" + $"Invoice ID: {saleID}\n\n";
                }

                // Append the new explicit choices
                msgPrompt += "\nHow would you like your receipt?\n" +
                             "👉 Click YES to Print a Physical Receipt (and send Email)\n" +
                             "👉 Click NO for an E-Receipt (Email Only)";
                DialogResult result = MessageBox.Show(msgPrompt, "Transaction Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                string custName = "Walk-in Customer";
                string loyaltyDisplay = "N/A";

                decimal vatAmount = Math.Round(getTotal() * 15m / 115m, 2); // 15% VAT calc

                int totalItemsCount = 0;
                foreach (DataRow row in this.dsSamsLiqourShop.Cart.Rows)
                {
                    totalItemsCount += row["SaleLine_Quantity"] != DBNull.Value ? Convert.ToInt32(row["SaleLine_Quantity"]) : 1;
                }

                if (currentCustomerID != null && this.dsSamsLiqourShop.Customer.Rows.Count > 0)
                {
                    DataRow custRow = this.dsSamsLiqourShop.Customer.Rows[0];
                    string firstName = custRow["Customer_FirstName"]?.ToString() ?? "";
                    string lastName = custRow["Customer_LastName"]?.ToString() ?? "";
                    custName = string.IsNullOrWhiteSpace(firstName + lastName) ? "Valued Customer" : $"{firstName} {lastName}".Trim();
                    loyaltyDisplay = $"{newCustLoyaltyPointsBalance} pts (Earned +{loyaltyPointsEarned} today)";
                }

                string employeeDisplayName = "Unknown Cashier"; // Default fallback

                // Access the parent form and grab the existing public variable
                if (this.MdiParent is MainForm mainForm)
                {
                    employeeDisplayName = mainForm.employeeFullName;
                }

                bool emailSent = await SendReceiptEmailAsync(
                    "theofficialbyteclub@gmail.com",
                    custName,
                    saleID.ToString(),
                    getSubtotal(),
                    getDiscountAmount(),
                    vatAmount,
                    getTotal(),
                    amountTendered,
                    changeDue,
                    loyaltyDisplay,
                    paymentMethodUsed,
                    totalItemsCount,
                    employeeDisplayName,
                    saleTypeText
                );
                if (emailSent)
                {
                    MessageBox.Show("E-Receipt dispatched directly to the Customers Email!", "Email Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (result == DialogResult.Yes)
                {
                    GenerateReceipt();
                    //MessageBox.Show("Receipt printed successfully.", "Sale Completion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    clearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to log transaction: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Regardless of success or failure, reset the form for the next customer
                btnCompleteSale.Enabled = true;
            }
        }

        private void GenerateReceipt()
        {
            PrintDocument printDoc = new PrintDocument();

            // Attach the layout drawing event handler
            printDoc.PrintPage += new PrintPageEventHandler(PrintReceiptPage);

            ReceiptForm receiptForm = new ReceiptForm(printDoc);
            receiptForm.MdiParent = this.MdiParent;
            receiptForm.WindowState = FormWindowState.Maximized;

            receiptForm.FormClosed += (sender, e) =>
            {
                // Check if our form is running inside the MDI layout frame
                if (this.MdiParent != null && this.MdiParent is MainForm mainForm)
                {
                    mainForm.btnProcessSale.PerformClick();

                }
                else
                {
                    // Fallback safety rule in case it's run standalone
                    clearForm();
                }
            };
            receiptForm.Show();

        }

        private void PrintReceiptPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphic = e.Graphics;

            // Set up text font stylings
            Font fontNormal = new Font("Courier New", 10, FontStyle.Regular);
            Font fontBold = new Font("Courier New", 10, FontStyle.Bold);
            Font fontHeader = new Font("Courier New", 14, FontStyle.Bold);

            float leading = 16; // Space between rows
            float startX = 10;  // Left border margin
            float startY = 10;  // Top border margin
            float offset = 0;   // Rolling vertical offset marker

            // 1. BUSINESS METADATA HEADER
            graphic.DrawString("SAM'S LIQUOR SHOP", fontHeader, Brushes.Black, startX, startY + offset);
            offset += leading + 4;
            graphic.DrawString("21 Coronation Road, Mithangar, Tongaat, 4399", fontNormal, Brushes.Black, startX, startY + offset);
            offset += leading;
            graphic.DrawString("Contact Number: +27 82 405 5932", fontNormal, Brushes.Black, startX, startY + offset);
            offset += leading * 2;

            // 2. TRANSACTION METADATA
            string invoiceNum = "INV-" + Convert.ToString(saleID);
            graphic.DrawString($"INVOICE: {invoiceNum}", fontBold, Brushes.Black, startX, startY + offset);
            offset += leading;
            graphic.DrawString($"DATE: {DateTime.Now.ToString("G")}", fontNormal, Brushes.Black, startX, startY + offset);
            offset += leading;
            graphic.DrawString($"SALE TYPE: {comboBox2.Text.Trim()}", fontNormal, Brushes.Black, startX, startY + offset);
            offset += leading * 2;

            // 3. CART COLUMN GRID HEADER
            graphic.DrawString("----------------------------------------------------------------------", fontNormal, Brushes.Black, startX, startY + offset);
            offset += leading;

            // WIDER COLUMNS: Item column extended to 280px to prevent wrapping
            graphic.DrawString("Item", fontBold, Brushes.Black, startX, startY + offset);
            graphic.DrawString("Qty", fontBold, Brushes.Black, startX + 280, startY + offset);
            graphic.DrawString("Price", fontBold, Brushes.Black, startX + 330, startY + offset);
            graphic.DrawString("Disc", fontBold, Brushes.Black, startX + 390, startY + offset);
            graphic.DrawString("Total", fontBold, Brushes.Black, startX + 460, startY + offset);
            offset += leading;
            graphic.DrawString("----------------------------------------------------------------------", fontNormal, Brushes.Black, startX, startY + offset);
            offset += leading;

            // 4. ITERATE ITEMS IN THE CART
            int totalItemCount = 0;
            decimal totalDiscountGiven = 0m;

            foreach (DataRow row in this.dsSamsLiqourShop.Cart.Rows)
            {
                string name = row["Product_Name"].ToString();
                int qty = Convert.ToInt32(row["SaleLine_Quantity"]);
                decimal originalPrice = Convert.ToDecimal(row["SaleLine_OriginalUnitPrice"]);
                decimal discountPrice = row["SaleLine_UnitPriceAfterDiscount"] == DBNull.Value ? originalPrice : Convert.ToDecimal(row["SaleLine_UnitPriceAfterDiscount"]);
                decimal lineTotal = (qty * discountPrice);

                decimal unitDiscountAmount = originalPrice - discountPrice;
                decimal totalLineSavings = unitDiscountAmount * qty;

                totalItemCount += qty;
                totalDiscountGiven += totalLineSavings;

                // Truncate long product names (increased to 35 chars for wider column)
                if (name.Length > 35) name = name.Substring(0, 32) + "...";

                graphic.DrawString(name, fontNormal, Brushes.Black, startX, startY + offset);
                graphic.DrawString(qty.ToString(), fontNormal, Brushes.Black, startX + 280, startY + offset);
                graphic.DrawString(originalPrice.ToString("F2"), fontNormal, Brushes.Black, startX + 330, startY + offset);
                graphic.DrawString(unitDiscountAmount.ToString("F2"), fontNormal, Brushes.Black, startX + 390, startY + offset);
                graphic.DrawString(lineTotal.ToString("F2"), fontNormal, Brushes.Black, startX + 460, startY + offset);
                offset += leading;

                if (totalLineSavings > 0m)
                {
                    graphic.DrawString($"  * Promo Savings: -R {totalLineSavings.ToString("F2")}", fontNormal, Brushes.Gray, startX, startY + offset);
                    offset += leading;
                }
            }

            graphic.DrawString("----------------------------------------------------------------------", fontNormal, Brushes.Black, startX, startY + offset);
            offset += leading;

            // ====== SECTION 5: BALANCES ======
            decimal subtotalAmount = getSubtotal();
            decimal vatAmount = getVat();
            decimal totalFinalAmount = getTotal();

            string paymentMethod = comboBox1.Text.Trim();
            string rawInput = txtAmountTendered.Text.Trim();

            // Safe numeric parsing for payment
            decimal.TryParse(rawInput, out decimal numericTendered);
            decimal changeDue = (paymentMethod.Equals("Cash", StringComparison.OrdinalIgnoreCase)) ? (numericTendered - totalFinalAmount) : 0;
            if (changeDue < 0) changeDue = 0;

            // Draw financial aggregations with indentations
            graphic.DrawString($"Total Items Count: {totalItemCount}", fontNormal, Brushes.Black, startX, startY + offset);
            offset += leading;
            graphic.DrawString($"Subtotal Amount:    R {subtotalAmount.ToString("F2")}", fontNormal, Brushes.Black, startX, startY + offset);
            offset += leading;

            if (totalDiscountGiven > 0m)
            {
                graphic.DrawString($"Total Discount:    -R {totalDiscountGiven.ToString("F2")}", fontNormal, Brushes.Black, startX, startY + offset);
                offset += leading;
            }

            // Indented VAT
            graphic.DrawString($"  VAT (15%):        R {vatAmount.ToString("F2")}", fontNormal, Brushes.Black, startX, startY + offset);
            offset += leading;
            graphic.DrawString($"Total Final Price:  R {totalFinalAmount.ToString("F2")}", fontBold, Brushes.Black, startX, startY + offset);
            offset += leading;
            graphic.DrawString($"Payment Method:     {paymentMethod}", fontNormal, Brushes.Black, startX, startY + offset);
            offset += leading;

            if (paymentMethod.Equals("Loyalty Points", StringComparison.OrdinalIgnoreCase))
            {
                graphic.DrawString($"Points Redeemed:    {rawInput} pts", fontNormal, Brushes.Black, startX, startY + offset);
                offset += leading;
            }
            else if (paymentMethod.Equals("Voucher", StringComparison.OrdinalIgnoreCase))
            {
                graphic.DrawString($"Voucher Ref Num:    {rawInput}", fontNormal, Brushes.Black, startX, startY + offset);
                offset += leading;
            }
            else if (paymentMethod.Equals("Cash", StringComparison.OrdinalIgnoreCase))
            {
                graphic.DrawString($"Cash Tendered:      R {numericTendered.ToString("F2")}", fontNormal, Brushes.Black, startX, startY + offset);
                offset += leading;
                graphic.DrawString($"Change Amount:      R {changeDue.ToString("F2")}", fontBold, Brushes.Black, startX, startY + offset);
                offset += leading;
            }

            offset += leading * 2;

            // 6. TAILORED DYNAMIC FOOTER
            if (currentCustomerID != null && this.dsSamsLiqourShop.Customer.Rows.Count > 0)
            {
                graphic.DrawString($"Hi {lblName.Text},", fontBold, Brushes.Black, startX, startY + offset);
                offset += leading;
                graphic.DrawString("Thank you for shopping at Sam's Liquor Shop!", fontNormal, Brushes.Black, startX, startY + offset);
                offset += leading;
                graphic.DrawString($"Your new loyalty points balance is: {newCustLoyaltyPointsBalance}", fontBold, Brushes.Black, startX, startY + offset);
                offset += leading * 1.5f;
            }

            graphic.DrawString("Please keep this receipt as proof of purchase.", fontNormal, Brushes.Black, startX, startY + offset);
            offset += leading * 1.5f;

            string employeeName = "Cashier";
            Form parentForm = this.MdiParent ?? this.Owner;
            if (parentForm is MainForm mainForm)
            {
                employeeName = mainForm.employeeFullName;
            }
            graphic.DrawString($"You were helped by: {employeeName}", fontNormal, Brushes.Black, startX, startY + offset);
        }

        private void cartDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
