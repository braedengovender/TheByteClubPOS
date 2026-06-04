using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static TheByteClubPOS.dsSamsLiqourShop;

namespace TheByteClubPOS
{
    public partial class POSForm : Form
    {
        int clearButtonClickCount = 0;

        int currentEmployeeID;
        int? currentCustomerID = null;
        public int selectedPaymentMethodID = 0;
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
            // Keep currentEmployeeID intact since the same staff member is still logged in!

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
            lblSubtotalAmount.Text = getTotal().ToString("C2");
            lblTotalAmount.Text = getTotal().ToString("C2");
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

        private void productBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsSamsLiqourShop);

        }

        private void POSForm_Load(object sender, EventArgs e)
        {
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


        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            
            productTableAdapter.FillByProductSearch(dsSamsLiqourShop.Product, txtSearch.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
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
                    row["SaleLine_Subtotal"] = newQty * price;

                    itemExistsInCart = true;
                    break; // Stop looking, we found it
                }
            }

            // 3. If it's a brand new item choice, append a clean new line row entry
            if (!itemExistsInCart)
            {
                int initialQuantity = 1;
                decimal initialSubtotal = initialQuantity * price;
                this.dsSamsLiqourShop.Cart.Rows.Add(productID, productName, price, null, null, null, initialQuantity, initialSubtotal);
            }

            lblSubtotalAmount.Text = getTotal().ToString("C2");
            lblTotalAmount.Text = getTotal().ToString("C2");
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

        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            

            // Check if there is actually a row selected in the grid
            if (cartDataGridView.CurrentRow != null)
            {
                this.dsSamsLiqourShop.Cart.Rows[cartDataGridView.CurrentRow.Index].Delete();

                lblSubtotalAmount.Text = getTotal().ToString("C2");
                lblTotalAmount.Text = getTotal().ToString("C2");
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
                txtSearch.ForeColor = Color.Black;
                txtSearch.Font = new Font(txtSearch.Font, FontStyle.Regular);
            }


        }

        private bool isDarkMode = false;

        private void ApplyDarkMode()
        {
            this.BackgroundImage = Properties.Resources.DarkMode_Background;
            this.BackColor = Color.FromArgb(32, 32, 32); // Dark Charcoal
            this.ForeColor = Color.White;
            btnToggleTheme.Text = "Switch to Light Mode";
            btnToggleTheme.BackColor = Color.FromArgb(50, 50, 50);
            btnToggleTheme.ForeColor = Color.White;
            
            comboBox1.BackColor = Color.FromArgb(40, 40, 40);
            comboBox1.ForeColor = Color.White;

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

        private void ApplyLightMode()
        {
            this.BackgroundImage = Properties.Resources.Background;
            this.BackColor = SystemColors.Control;
            this.ForeColor = SystemColors.ControlText;
            btnToggleTheme.Text = "Switch to Dark Mode";
            btnToggleTheme.BackColor = SystemColors.ControlLight;
            btnToggleTheme.ForeColor = SystemColors.ControlText;

            comboBox1.BackColor = Color.White;
            comboBox1.ForeColor = Color.Black;

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

        // Paste this inside your form class, before the final closing brace
        private void UpdateControlThemes(Control.ControlCollection controls, Color backColor, Color foreColor)
        {
            foreach (Control c in controls)
            {
                // Leave the main toggle button alone to retain its custom styling
                if (c == btnToggleTheme) continue;

                c.BackColor = backColor;
                c.ForeColor = foreColor;

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
                        MessageBox.Show(
                            "This customer account is inactive. Loyalty points will not be added to purchases.",
                            "Inactive Customer",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                    else
                    {
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
                txtAmountTendered.Enabled = true;
                txtAmountTendered.BackColor = Color.White; // Highlighting it as active
                txtAmountTendered.Focus();                 // Automatically place the cursor inside
            }
            else
            {
                txtAmountTendered.Enabled = false;
                txtAmountTendered.Text = "";
                txtAmountTendered.BackColor = Color.LightGray; // Grayed out style visual cue

                // For non-cash transactions, Amount Tendered is automatically the exact total
                //lblChangeAmount.Text = "R 0.00";
            }


        }
        private void saveSaleLines(int saleID)
        {
            // Loop through every product row sitting in your temporary memory cart
            foreach (DataRow cartRow in this.dsSamsLiqourShop.Cart.Rows)
            {
                // 1. Extract the column data from the current cart row
                // (Make sure these string names match your Cart DataTable columns exactly!)
                int productID = Convert.ToInt32(cartRow["Product_ID"]);
                int qty = Convert.ToInt32(cartRow["SaleLine_Quantity"]);
                decimal originalPrice = Convert.ToDecimal(cartRow["SaleLine_OriginalUnitPrice"]);

                // If your cart doesn't calculate discounts yet, we can default them logically:
                int? discountID = null; // null means no discount applied
                decimal priceAfterDiscount = originalPrice;
                decimal subtotal = qty * priceAfterDiscount;

                // 2. Fire your newly created wizard query with all 7 required arguments
                this.saleLineTableAdapter.InsertQuerySaleLine(saleID, productID, discountID, qty, originalPrice, priceAfterDiscount, subtotal);
            }
        }
        private void btnCompleteSale_Click(object sender, EventArgs e)
        {
            // 1. Guard check: make sure there's actually something in the cart
            if (this.dsSamsLiqourShop.Cart.Rows.Count == 0)
            {
                MessageBox.Show("The cart is empty. Cannot complete a sale.", "Cart Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (currentCustomerID == null && !string.IsNullOrWhiteSpace(maskedTextBox1.Text.Replace("-", "").Trim()))
            {
                // Programmatically trigger the lookup button click!
                btnLookup_Click(null, null);

                // Note: If your lookup code clears fields or alerts the cashier on failure, 
                // you might want to double check if currentCustomerID is STILL null here.
            }

            int loyaltyPointsEarned = (int)Math.Floor(getTotal() / 10); // Example: 1 point for every R10 spent

            try
            {
                int saleID = (int)saleTableAdapter.InsertQueryNewSale(currentCustomerID, currentEmployeeID, 1, null, DateTime.Now, getTotal(), null, getTotal(), loyaltyPointsEarned, "Completed");
                MessageBox.Show("Sale completed successfully! ID: " + saleID + " Loyalty points earned: " + loyaltyPointsEarned, "Transaction Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                saveSaleLines(saleID);
                updateStockQuantityInDatabase();

                if (currentCustomerID != null)
              
                {
                    customerTableAdapter.UpdateQueryCustLoyaltyPoints(Convert.ToInt32(currentCustomerID), loyaltyPointsEarned);
                }

                DialogResult result = MessageBox.Show("Print receipt...", "Sale Completion", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("Receipt printed successfully.", "Sale Completion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                clearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to log transaction: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }

        private void cartDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
