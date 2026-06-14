using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheByteClubPOS
{
    public partial class AddNewProductForm : Form
    {
        // Define the available modes
        public enum FormMode
        {
            Add,
            Edit
        }

        private readonly System.Collections.Generic.Dictionary<System.Windows.Forms.TextBox, string> _placeholders = new System.Collections.Generic.Dictionary<System.Windows.Forms.TextBox, string>();

        // 2. Class-level variables to store the passed-in data
        private FormMode currentMode;
        private int currentProductID;

        private int currentTip = 0;
        private string[] tips =
        {
            "💡 Use the barcode search for faster product lookup.",
            "💡 Review low-stock products daily on your dashboard.",
            "💡 Export reports to Excel for analysis.",
            "💡 Check the dashboard for sales insights.",
            "💡 Inactive products are not eligible for sale.",
        };

        public AddNewProductForm(FormMode mode, int productID = -1)
        {
            InitializeComponent();
            this.currentMode = mode;
            this.currentProductID = productID;
        }

        private void DisplayProductImage(int productID)
        {
            try
            {
                // 1. Explicitly type the result as a nullable byte array
                byte[] imageBytes = (byte[])this.productTableAdapter.GetImageByID(productID);

                // 2. Validation: Check if the returned byte array is null or has no data
                if (imageBytes == null || imageBytes.Length == 0)
                {
                    pbImage.Image = Properties.Resources.NoImageAvailable;
                    return;
                }

                // 3. Convert byte array to Image using a MemoryStream
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBytes))
                {
                    pbImage.Image = System.Drawing.Image.FromStream(ms);
                    pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                }
            }
            catch (System.Exception ex)
            {
                // 4. Validation: Log/Report errors explicitly
                MessageBox.Show("Could not load product image. The data might be corrupted.\n\nDetails: " + ex.Message,
                                "Image Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                pbImage.Image = Properties.Resources.NoImageAvailable;
            }
        }

        private void LoadCountries()
        {
            cmbOrigin.Items.Clear();

            // Get all cultures from Windows
            foreach (System.Globalization.CultureInfo culture in System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.SpecificCultures))
            {
                System.Globalization.RegionInfo region = new System.Globalization.RegionInfo(culture.Name);
                if (!cmbOrigin.Items.Contains(region.EnglishName))
                {
                    cmbOrigin.Items.Add(region.EnglishName);
                }
            }

            // Sort alphabetically
            cmbOrigin.Sorted = true;
            // Set the default to South Africa
            cmbOrigin.SelectedItem = "South Africa";
        }

        private void SetupPlaceholders()
        {
            // Define the boxes and their specific messages
            _placeholders.Add(product_NameTextBox, "Enter product name");
            _placeholders.Add(product_DescriptionTextBox, "Enter description (optional)");
            _placeholders.Add(product_BrandTextBox, "Enter brand (optional)");
            _placeholders.Add(product_TypeTextBox, "Enter type (optional)");
            _placeholders.Add(product_FlavourTextBox, "Enter flavour (optional)");
            _placeholders.Add(product_IngredientsTextBox, "Enter ingredients (optional)");
            _placeholders.Add(product_SizeMLTextBox, "e.g. 750");
            _placeholders.Add(product_BarcodeNumberTextBox, "Enter barcode");

            foreach (var entry in _placeholders)
            {
                entry.Key.ForeColor = System.Drawing.Color.Gray;
                entry.Key.Text = entry.Value;

                // Subscribe to events
                entry.Key.Enter += InputBox_Enter;
                entry.Key.Leave += InputBox_Leave;
            }
        }

        private void InputBox_Enter(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox box = (System.Windows.Forms.TextBox)sender;
            if (box.Text == _placeholders[box])
            {
                box.Text = "";
                box.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void InputBox_Leave(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox box = (System.Windows.Forms.TextBox)sender;
            if (string.IsNullOrWhiteSpace(box.Text))
            {
                box.Text = _placeholders[box];
                box.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void SetupUI()
        {
            if (currentMode == FormMode.Add)
            {
                this.Text = "Add New Product"; // Changes the window title
                                               // (Assuming your save button is named btnSave)

                // lblTitle.Text = "Create a New Record";
                lblProductID.Visible = false; // Hides the product ID label
                product_IDTextBox.Visible = false; // Hides the product ID textbox
            }
            else if (currentMode == FormMode.Edit)
            {
                this.Text = "Edit Product Details"; // Changes the window title

                // Hide components that shouldn't be changed during an edit
                // txtBarcode.Enabled = false; 

                lblProductID.Visible = true;
            }
        }

        private void LoadData()
        {
            // First, load the data into memory
            this.productTableAdapter.Fill(this.dsSamsLiqourShop.Product);

            LoadCountries();

            if (currentMode == FormMode.Add)
            {
                // Prepare a blank canvas for a new record
                this.productBindingSource.AddNew(); // Forces the form to clear and prepare a brand new record

                cmbOrigin.SelectedItem = "South Africa";
                numericUpDownAlcoholPercentage.Value = 0;
                numericUpDownSellingPrice.Value = 0;
                numericUpDownCostPrice.Value = 0;
                numericUpDownQuantityInStock.Value = 0;
                numericUpDownReorderQuantity.Value = 0;

                SetupPlaceholders();
            }
            else if (currentMode == FormMode.Edit)
            {
                // Find the specific row using the Primary Key and tell the form to jump to it
                int rowIndex = this.productBindingSource.Find("Product_ID", currentProductID);

                if (rowIndex > -1)
                {
                    this.productBindingSource.Position = rowIndex;
                    DisplayProductImage(currentProductID);
                }
                else
                {
                    MessageBox.Show("Could not locate the product record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close(); // Close if the record is missing
                }
            }
        }

        private void AddNewProductForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.Discount' table. You can move, or remove it, as needed.
            this.discountTableAdapter.Fill(this.dsSamsLiqourShop.Discount);
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.Supplier' table. You can move, or remove it, as needed.
            this.supplierTableAdapter.Fill(this.dsSamsLiqourShop.Supplier);
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.dsSamsLiqourShop.Category);
            SetupUI();
            LoadData();
            lblTips.Text = tips[0];
        }

        private void timerTips_Tick(object sender, EventArgs e)
        {
            currentTip++;

            if (currentTip >= tips.Length)
                currentTip = 0;

            lblTips.Text = tips[currentTip];
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation: Ask the user for confirmation before canceling
                DialogResult userChoice = MessageBox.Show("Are you sure you want to cancel? Any unsaved product details will be lost.",
                    "Confirm Cancel",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                // 2. If the user clicks 'No', abort the cancellation and leave the form open
                if (userChoice == DialogResult.No)
                {
                    return;
                }

                // 1. Strictly check if the parent exists and is specifically your dashboard class
                if (this.MdiParent != null && this.MdiParent is MainForm)
                {
                    // 2. Explicitly cast the generic MdiParent using direct casting (No 'var', no 'as')
                    MainForm mainForm = (MainForm)this.MdiParent;

                    // 3. Safely call the public method on the parent form
                    mainForm.LoadProductsForm();
                }

                // 4. Finally, close the form to clean up the screen
                this.Close();
            }
            catch (Exception ex)
            {
                // Global Catch: Prevents the app from crashing if the UI routing fails
                MessageBox.Show("An unexpected error occurred while trying to close the window:\n\n" + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private string GetCleanText(System.Windows.Forms.TextBox box)
        {
            // If the text matches the placeholder, return an empty string
            if (_placeholders.ContainsKey(box) && box.Text == _placeholders[box])
            {
                return string.Empty;
            }
            return box.Text;
        }

        private bool ValidateProductData()
        {
            // --- 1) Basic required UI selections ---
            if (cmbCategory.SelectedValue == null)
            {
                MessageBox.Show("Please select a Category.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategory.Focus();
                return false;
            }

            if (cmbSupplier.SelectedValue == null)
            {
                MessageBox.Show("Please select a Supplier.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSupplier.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbStatus.Text) || cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a valid Status.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbStatus.Focus();
                return false;
            }

            // --- 2) Text fields validation (using helper to clean placeholders) ---
            if (string.IsNullOrWhiteSpace(GetCleanText(product_NameTextBox)))
            {
                MessageBox.Show("Product Name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                product_NameTextBox.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(GetCleanText(product_BarcodeNumberTextBox)))
            {
                MessageBox.Show("Barcode is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                product_BarcodeNumberTextBox.Focus();
                return false;
            }

            // --- 3) Numeric fields & Business Logic ---
            // Size (ML) - Using TryParse as a fallback
            string sizeText = GetCleanText(product_SizeMLTextBox);
            if (!string.IsNullOrWhiteSpace(sizeText))
            {
                if (!int.TryParse(sizeText, out int sizeVal) || sizeVal <= 0)
                {
                    MessageBox.Show("Size (ML) must be a positive whole number greater than 0.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    product_SizeMLTextBox.Focus();
                    return false;
                }
            }

            // Selling Price
            if (numericUpDownSellingPrice.Value < 0)
            {
                MessageBox.Show("Enter a valid non-negative Selling Price.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericUpDownSellingPrice.Focus();
                return false;
            }

            // Cost Price
            if (numericUpDownCostPrice.Value < 0)
            {
                MessageBox.Show("Enter a valid non-negative Cost Price.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericUpDownCostPrice.Focus();
                return false;
            }

            // Business Logic: Selling vs Cost
            if (numericUpDownSellingPrice.Value < numericUpDownCostPrice.Value)
            {
                DialogResult resp = MessageBox.Show("Selling price is lower than cost price. Continue?", "Price Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resp != DialogResult.Yes) return false;
            }

            // --- 4) Final Placeholder Cleanup ---
            // If the user left any optional field as its placeholder, clear it for the DB
            foreach (var entry in _placeholders)
            {
                if (entry.Key.Text == entry.Value)
                {
                    entry.Key.Text = string.Empty;
                }
            }

            return true;
        }

        private void btnSaveProduct_Click(object sender, EventArgs e)
        {
            // In your Save button:
            string nameToSave = GetCleanText(product_NameTextBox);
            // Use 'nameToSave' when assigning to your BindingSource or SQL command

            // Run validation first
            if (!ValidateProductData()) return;

            try
            {

                // 2. Perform Save based on mode
                if (currentMode == FormMode.Add)
                {
                    // End the edit to commit UI values to the BindingSource
                    this.productBindingSource.EndEdit();

                    // Save the new row
                    this.productTableAdapter.Update(this.dsSamsLiqourShop.Product);
                    MessageBox.Show("New product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (currentMode == FormMode.Edit)
                {
                    // Commit UI changes to the BindingSource
                    this.productBindingSource.EndEdit();

                    // Update the specific row in the database
                    this.productTableAdapter.Update(this.dsSamsLiqourShop.Product);
                    MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // 3. Close the form and return to the main dashboard
                this.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("An error occurred while saving: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UploadProductImage()
        {
            using (System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        // 1. Convert file to byte array
                        byte[] rawBytes = System.IO.File.ReadAllBytes(openFileDialog.FileName);
                        if (rawBytes.Length == 0) throw new System.Exception("The selected file is empty.");

                        // 2. Perform direct DB Update using the PK
                        // This assumes your TableAdapter has an UpdateQuery(byte[] image, int id)
                        this.productTableAdapter.UpdateQuery(rawBytes, this.currentProductID);

                        // 3. Refresh the local data to reflect the change
                        this.productTableAdapter.Fill(this.dsSamsLiqourShop.Product);

                        // 4. Refresh the PictureBox UI
                        DisplayProductImage(this.currentProductID);

                        MessageBox.Show("Success! Image updated.", "System Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Upload Failed: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void pbImage_Click(object sender, EventArgs e)
        {
            UploadProductImage();
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            UploadProductImage();
        }

        private void btnClearImage_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Confirm with user to avoid accidental deletions
                DialogResult result = MessageBox.Show("Are you sure you want to remove the product image?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    this.productTableAdapter.UpdateQueryClearProductImage(this.currentProductID);

                    // 3. Refresh the UI
                    this.productTableAdapter.Fill(this.dsSamsLiqourShop.Product);
                    pbImage.Image = Properties.Resources.NoImageAvailable;

                    MessageBox.Show("Image removed successfully.");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Could not remove image: " + ex.Message);
            }
        }
    }
}
