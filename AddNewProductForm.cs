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
                //pbImage.SizeMode = PictureBoxSizeMode.Zoom;
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

                cmbCategory.SelectedIndex = -1;
                cmbSupplier.SelectedIndex = -1;
                cmbDiscount.SelectedIndex = -1;

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

            if (numericUpDownAlcoholPercentage.Value < 0 || numericUpDownAlcoholPercentage.Value > 100)
            {
                MessageBox.Show(
                    "Alcohol percentage must be between 0 and 100.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                numericUpDownAlcoholPercentage.Focus();
                return false;
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
                // ─── SAFE TEXT EXTRACTION + NULL CLEANUP ─────────────────────────────
                string name = GetCleanText(product_NameTextBox);
                string desc = GetCleanText(product_DescriptionTextBox);
                string brand = GetCleanText(product_BrandTextBox);
                string type = GetCleanText(product_TypeTextBox);
                string flavour = GetCleanText(product_FlavourTextBox);
                string ingredients = GetCleanText(product_IngredientsTextBox);
                string barcode = GetCleanText(product_BarcodeNumberTextBox);

                // convert empty strings to NULL (SQL-friendly)
                if (string.IsNullOrWhiteSpace(name)) name = null;
                if (string.IsNullOrWhiteSpace(desc)) desc = null;
                if (string.IsNullOrWhiteSpace(brand)) brand = null;
                if (string.IsNullOrWhiteSpace(type)) type = null;
                if (string.IsNullOrWhiteSpace(flavour)) flavour = null;
                if (string.IsNullOrWhiteSpace(ingredients)) ingredients = null;
                if (string.IsNullOrWhiteSpace(barcode)) barcode = null;

                // ─── SAFE NUMBER PARSING (NO CRASHES) ─────────────────
                int sizeML = 0;
                int.TryParse(GetCleanText(product_SizeMLTextBox), out sizeML);

                decimal sellingPrice = 0;
                decimal.TryParse(numericUpDownSellingPrice.Value.ToString(), out sellingPrice);

                decimal costPrice = 0;
                decimal.TryParse(numericUpDownCostPrice.Value.ToString(), out costPrice);

                decimal alcohol = numericUpDownAlcoholPercentage.Value;

                int qty = (int)numericUpDownQuantityInStock.Value;
                int reorder = (int)numericUpDownReorderQuantity.Value;

                // ─── SAFE COMBOBOX HANDLING ───────────────────────────
                int categoryID = 0;
                int supplierID = 0;

                try
                {
                    if (cmbCategory.SelectedValue != null)
                        categoryID = Convert.ToInt32(cmbCategory.SelectedValue is DataRowView row ? row[0] : cmbCategory.SelectedValue);
                }
                catch
                {
                    MessageBox.Show("Invalid Category selected.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    if (cmbSupplier.SelectedValue != null)
                        supplierID = Convert.ToInt32(cmbSupplier.SelectedValue is DataRowView r ? r[0] : cmbSupplier.SelectedValue);
                }
                catch
                {
                    MessageBox.Show("Invalid Supplier selected.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string origin = cmbOrigin.Text ?? "";
                string status = cmbStatus.Text ?? "";

                int? discountID = cmbDiscount.SelectedValue != null
                ? Convert.ToInt32(cmbDiscount.SelectedValue)
                : (int?)null;

                // ─── IMAGE SAFETY (IMPORTANT) ─────────────────────────

                byte[] imageBytes = _pendingImageBytes;

                if (_currentMode == FormMode.Edit && imageBytes == null)
                {
                    // KEEP EXISTING IMAGE (do NOT overwrite with null)
                    object img = this.productTableAdapter.GetImageByID(_currentProductID);
                    imageBytes = img == DBNull.Value ? null : (byte[])img;
                }

                // ─── FINAL SAVE ───────────────────────────────────────
                if (_currentMode == FormMode.Add)
                {
                    productTableAdapter.InsertProductQuery(
                    categoryID,
                    supplierID,
                    discountID,
                    name,
                    desc,
                    brand,
                    type,
                    flavour,
                    alcohol,
                    origin,
                    ingredients,
                    sizeML,
                    barcode,
                    sellingPrice,
                    costPrice,
                    qty,
                    reorder,
                    status,
                    imageBytes
                );

                    MessageBox.Show("Product added successfully!");
                }
                else
                {
                    productTableAdapter.UpdateEntireProductQuery(
                        categoryID,
                    supplierID,
                    discountID,
                    name,
                    desc,
                    brand,
                    type,
                    flavour,
                    alcohol,
                    origin,
                    ingredients,
                    sizeML,
                    barcode,
                    sellingPrice,
                    costPrice,
                    qty,
                    reorder,
                    status,
                    imageBytes,
                    _currentProductID
                    );

                    MessageBox.Show("Product updated successfully!");
                }

                if (this.MdiParent is MainForm mainForm)
                    mainForm.LoadProductsForm();

                _pendingImageBytes = null;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Save failed, but system is safe.\n\n" + ex.Message,
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        // ─── Image Upload ─────────────────────────────────────────────────────────

        private void UploadProductImage()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    byte[] rawBytes;

                    try
                    {
                        rawBytes = System.IO.File.ReadAllBytes(openFileDialog.FileName);
                    }
                    catch
                    {
                        MessageBox.Show("Could not read image file.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (rawBytes == null || rawBytes.Length == 0)
                    {
                        MessageBox.Show("Invalid image file selected.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // SAME LOGIC FOR ADD + EDIT (SAFE)
                    _pendingImageBytes = rawBytes;
                    LoadImageIntoBox(rawBytes);

                    MessageBox.Show(
                        "Image selected. It will be saved when you click Save.",
                        "Image Ready",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not read image:\n\n" + ex.Message,
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

                _pendingImageBytes = null;

                _activeImageStream?.Dispose();
                _activeImageStream = null;

                pbImage.Image?.Dispose();
                pbImage.Image = Properties.Resources.NoImageAvailable;

                // ONLY delete from DB in EDIT mode
                if (_currentMode == FormMode.Edit)
                {
                    productTableAdapter.UpdateQueryClearProductImage(_currentProductID);
                    this.productTableAdapter.Fill(this.dsSamsLiqourShop.Product);
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