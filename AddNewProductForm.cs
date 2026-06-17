using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace TheByteClubPOS
{
    public partial class AddNewProductForm : Form
    {
        public enum FormMode
        {
            Add,
            Edit
        }

        private readonly Dictionary<TextBox, string> _placeholders = new Dictionary<TextBox, string>();
        private FormMode _currentMode;
        private int _currentProductID;
        private byte[] _pendingImageBytes = null;
        private System.IO.MemoryStream _activeImageStream = null;

        private int _currentTip = 0;
        private readonly string[] _tips =
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
            _currentMode = mode;
            _currentProductID = productID;
        }

        // ─── Image Helpers ────────────────────────────────────────────────────────

        /// <summary>
        /// Loads a byte array into the PictureBox, keeping the MemoryStream alive
        /// so GDI+ can read from it lazily during rendering.
        /// </summary>
        private void LoadImageIntoBox(byte[] imageBytes)
        {
            try
            {
                // Dispose the previous stream before creating a new one
                _activeImageStream?.Dispose();
                _activeImageStream = new System.IO.MemoryStream(imageBytes);

                pbImage.Image?.Dispose();
                pbImage.Image = Image.FromStream(_activeImageStream);
                pbImage.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch
            {
                pbImage.Image = Properties.Resources.NoImageAvailable;
            }
        }

        /// <summary>
        /// Loads the stored image for a product from the database into the PictureBox.
        /// Falls back to the placeholder image on any failure.
        /// </summary>
        private void DisplayProductImage(int productID)
        {
            try
            {
                byte[] imageBytes = (byte[])this.productTableAdapter.GetImageByID(productID);

                if (imageBytes == null || imageBytes.Length == 0)
                {
                    pbImage.Image = Properties.Resources.NoImageAvailable;
                    return;
                }

                LoadImageIntoBox(imageBytes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load product image. The data might be corrupted.\n\nDetails: " + ex.Message,
                    "Image Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                pbImage.Image = Properties.Resources.NoImageAvailable;
            }
        }

        /// <summary>
        /// Attempts to write imageBytes (or null) to the database for the given product ID.
        /// Returns true on success, false on failure. Never throws.
        /// </summary>
        private bool TrySaveImage(byte[] imageBytes, int productID)
        {
            try
            {
                this.productTableAdapter.UpdateQuery(imageBytes, productID);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // ─── UI Setup ─────────────────────────────────────────────────────────────

        private void LoadCountries()
        {
            cmbOrigin.Items.Clear();

            foreach (System.Globalization.CultureInfo culture in
                System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.SpecificCultures))
            {
                System.Globalization.RegionInfo region = new System.Globalization.RegionInfo(culture.Name);
                if (!cmbOrigin.Items.Contains(region.EnglishName))
                    cmbOrigin.Items.Add(region.EnglishName);
            }

            cmbOrigin.Sorted = true;
            cmbOrigin.SelectedItem = "South Africa";
        }

        private void SetupPlaceholders()
        {
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
                entry.Key.ForeColor = Color.Gray;
                entry.Key.Text = entry.Value;
                entry.Key.Enter += InputBox_Enter;
                entry.Key.Leave += InputBox_Leave;
            }
        }

        private void InputBox_Enter(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            if (box.Text == _placeholders[box])
            {
                box.Text = string.Empty;
                box.ForeColor = Color.Black;
            }
        }

        private void InputBox_Leave(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(box.Text))
            {
                box.Text = _placeholders[box];
                box.ForeColor = Color.Gray;
            }
        }

        private void SetupUI()
        {
            if (_currentMode == FormMode.Add)
            {
                this.Text = "Add New Product";
                lblProductID.Visible = false;
                product_IDTextBox.Visible = false;
                pbImage.Image = Properties.Resources.NoImageAvailable;
            }
            else
            {
                this.Text = "Edit Product Details";
                lblProductID.Visible = true;
                product_IDTextBox.Visible = true;
            }
        }

        private void LoadData()
        {
            this.productTableAdapter.Fill(this.dsSamsLiqourShop.Product);
            LoadCountries();

            if (_currentMode == FormMode.Add)
            {
                this.productBindingSource.AddNew();

                cmbOrigin.SelectedItem = "South Africa";
                numericUpDownAlcoholPercentage.Value = 0;
                numericUpDownSellingPrice.Value = 0;
                numericUpDownCostPrice.Value = 0;
                numericUpDownQuantityInStock.Value = 0;
                numericUpDownReorderQuantity.Value = 0;

                SetupPlaceholders();
            }
            else
            {
                int rowIndex = this.productBindingSource.Find("Product_ID", _currentProductID);

                if (rowIndex > -1)
                {
                    this.productBindingSource.Position = rowIndex;
                    DisplayProductImage(_currentProductID);
                }
                else
                {
                    MessageBox.Show("Could not locate the product record.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }

        // ─── Form Events ──────────────────────────────────────────────────────────

        private void AddNewProductForm_Load(object sender, EventArgs e)
        {
            this.discountTableAdapter.Fill(this.dsSamsLiqourShop.Discount);
            this.supplierTableAdapter.Fill(this.dsSamsLiqourShop.Supplier);
            this.categoryTableAdapter.Fill(this.dsSamsLiqourShop.Category);
            SetupUI();
            LoadData();
            lblTips.Text = _tips[0];
        }

        private void timerTips_Tick(object sender, EventArgs e)
        {
            _currentTip = (_currentTip + 1) % _tips.Length;
            lblTips.Text = _tips[_currentTip];
        }

        // ─── Validation ───────────────────────────────────────────────────────────

        private string GetCleanText(TextBox box)
        {
            if (_placeholders.ContainsKey(box) && box.Text == _placeholders[box])
                return string.Empty;

            return box.Text;
        }

        private bool ValidateProductData()
        {
            if (cmbCategory.SelectedValue == null)
            {
                MessageBox.Show("Please select a Category.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategory.Focus();
                return false;
            }

            if (cmbSupplier.SelectedValue == null)
            {
                MessageBox.Show("Please select a Supplier.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSupplier.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbStatus.Text) || cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a valid Status.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbStatus.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(GetCleanText(product_NameTextBox)))
            {
                MessageBox.Show("Product Name is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                product_NameTextBox.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(GetCleanText(product_BarcodeNumberTextBox)))
            {
                MessageBox.Show("Barcode is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                product_BarcodeNumberTextBox.Focus();
                return false;
            }

            string sizeText = GetCleanText(product_SizeMLTextBox);
            if (!string.IsNullOrWhiteSpace(sizeText))
            {
                if (!int.TryParse(sizeText, out int sizeVal) || sizeVal <= 0)
                {
                    MessageBox.Show("Size (ML) must be a positive whole number greater than 0.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    product_SizeMLTextBox.Focus();
                    return false;
                }
            }

            if (numericUpDownSellingPrice.Value < 0)
            {
                MessageBox.Show("Enter a valid non-negative Selling Price.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericUpDownSellingPrice.Focus();
                return false;
            }

            if (numericUpDownCostPrice.Value < 0)
            {
                MessageBox.Show("Enter a valid non-negative Cost Price.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericUpDownCostPrice.Focus();
                return false;
            }

            if (numericUpDownSellingPrice.Value < numericUpDownCostPrice.Value)
            {
                DialogResult resp = MessageBox.Show(
                    "Selling price is lower than cost price. Continue?",
                    "Price Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resp != DialogResult.Yes) return false;
            }

            // Strip placeholder text before committing to the binding source
            foreach (var entry in _placeholders)
            {
                if (entry.Key.Text == entry.Value)
                    entry.Key.Text = string.Empty;
            }

            return true;
        }

        // ─── Save ─────────────────────────────────────────────────────────────────

        private void btnSaveProduct_Click(object sender, EventArgs e)
        {
            if (!ValidateProductData()) return;

            try
            {
                this.productBindingSource.EndEdit();
                this.productTableAdapter.Update(this.dsSamsLiqourShop.Product);

                if (_currentMode == FormMode.Add)
                {
                    DataRowView currentRowView = (DataRowView)this.productBindingSource.Current;
                    int newProductID = Convert.ToInt32(currentRowView["Product_ID"]);

                    if (_pendingImageBytes != null)
                    {
                        bool imageUploaded = TrySaveImage(_pendingImageBytes, newProductID);

                        if (!imageUploaded)
                        {
                            // Image failed — set null to keep the column clean, never block the save
                            TrySaveImage(null, newProductID);

                            MessageBox.Show(
                                "Product saved successfully, but the image could not be uploaded and has been cleared.\n" +
                                "You can add the image later by editing the product.",
                                "Saved Without Image", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("New product added successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("New product added successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Product updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (this.MdiParent is MainForm mainForm)
                    mainForm.LoadProductsForm();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving:\n\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── Image Upload ─────────────────────────────────────────────────────────

        private void UploadProductImage()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() != DialogResult.OK) return;

                try
                {
                    byte[] rawBytes = System.IO.File.ReadAllBytes(openFileDialog.FileName);

                    if (rawBytes.Length == 0)
                        throw new Exception("The selected file is empty.");

                    if (_currentMode == FormMode.Add)
                    {
                        _pendingImageBytes = rawBytes;
                        LoadImageIntoBox(rawBytes);

                        MessageBox.Show(
                            "Image staged. It will be saved when you click 'Save Product'.",
                            "Image Staged", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        bool success = TrySaveImage(rawBytes, _currentProductID);

                        if (!success)
                        {
                            // Upload failed — clear column so it is not left corrupted
                            TrySaveImage(null, _currentProductID);

                            MessageBox.Show(
                                "The image could not be uploaded and has been cleared.\n" +
                                "Please try a different image file.",
                                "Image Upload Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        // Always refresh display from DB so UI reflects what is actually stored
                        this.productTableAdapter.Fill(this.dsSamsLiqourShop.Product);
                        DisplayProductImage(_currentProductID);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not read the selected file:\n\n" + ex.Message,
                        "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ─── Control Events ───────────────────────────────────────────────────────

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult userChoice = MessageBox.Show(
                    "Are you sure you want to cancel? Any unsaved product details will be lost.",
                    "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (userChoice == DialogResult.No) return;

                this.productBindingSource.CancelEdit();

                if (this.MdiParent is MainForm mainForm)
                    mainForm.LoadProductsForm();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error occurred while trying to close the window:\n\n" + ex.Message,
                    "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbImage_Click(object sender, EventArgs e) => UploadProductImage();
        private void btnSaveImage_Click(object sender, EventArgs e) => UploadProductImage();

        private void btnClearImage_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to remove the product image?",
                    "Confirm Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result != DialogResult.Yes) return;

                if (_currentMode == FormMode.Add)
                {
                    _pendingImageBytes = null;

                    _activeImageStream?.Dispose();
                    _activeImageStream = null;

                    pbImage.Image?.Dispose();
                    pbImage.Image = Properties.Resources.NoImageAvailable;
                }
                else
                {
                    this.productTableAdapter.UpdateQueryClearProductImage(_currentProductID);
                    this.productTableAdapter.Fill(this.dsSamsLiqourShop.Product);

                    _activeImageStream?.Dispose();
                    _activeImageStream = null;

                    pbImage.Image?.Dispose();
                    pbImage.Image = Properties.Resources.NoImageAvailable;
                }

                MessageBox.Show("Image removed successfully.", "Done",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not remove image:\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── Dispose ──────────────────────────────────────────────────────────────

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _activeImageStream?.Dispose();
            base.OnFormClosed(e);
        }
    }
}