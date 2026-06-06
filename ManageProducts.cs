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
    public partial class ManageProducts : Form
    {
        private int currentEditingProductId = -1;

        public ManageProducts()
        {
            InitializeComponent();
        }

        private void ManageProducts_Load(object sender, EventArgs e)
        {
            // Load lookup tables and products
            this.discountTableAdapter.Fill(this.dsSamsLiqourShop.Discount);
            this.supplierTableAdapter.Fill(this.dsSamsLiqourShop.Supplier);
            this.categoryTableAdapter.Fill(this.dsSamsLiqourShop.Category);
            this.productTableAdapter.Fill(this.dsSamsLiqourShop.Product);

            // Wire all radio buttons and search box to the same filter method
            rbBeer.CheckedChanged += ViewFilter_Changed;
            rbWines.CheckedChanged += ViewFilter_Changed;
            rbWhiskies.CheckedChanged += ViewFilter_Changed;
            rbSpirits.CheckedChanged += ViewFilter_Changed;
            rbRTD.CheckedChanged += ViewFilter_Changed;
            rbNonAlcoholic.CheckedChanged += ViewFilter_Changed;
            rbAccessories.CheckedChanged += ViewFilter_Changed;
            rbSnacks.CheckedChanged += ViewFilter_Changed;
            rbTobacco.CheckedChanged += ViewFilter_Changed;

            rbName.CheckedChanged += ViewFilter_Changed;
            rbPrice.CheckedChanged += ViewFilter_Changed;
            rbStock.CheckedChanged += ViewFilter_Changed;

            rbAscending.CheckedChanged += ViewFilter_Changed;
            rbDescending.CheckedChanged += ViewFilter_Changed;

            // Search box
            this.textBox17.TextChanged += (s, ev) => ApplyViewFilters();

            if (this.dataGridView3 != null)
            {
                this.dataGridView3.CellClick -= dataGridView3_CellClick; // avoid duplicate subscription
                this.dataGridView3.CellClick += dataGridView3_CellClick;
                this.dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.dataGridView3.MultiSelect = false;
            }

            if (this.button2 != null)
            {
                this.button2.Enabled = false; // disabled until a row is selected and loaded
            }
            // Initial population
            ApplyViewFilters();
        }

        // Shared handler for radio checked changes
        private void ViewFilter_Changed(object sender, EventArgs e)
        {
            // Only apply when a radio's Checked state changed
            ApplyViewFilters();
        }

        // Apply filters and sorting to dataGridView4
        private void ApplyViewFilters()
        {
            try
            {
                // Ensure the dataset is current
                this.productTableAdapter.Fill(this.dsSamsLiqourShop.Product);

                // Work on a copy so we can safely filter/sort
                DataTable dt = this.dsSamsLiqourShop.Product.Copy();
                DataView dv = dt.DefaultView;

                var filters = new List<string>();

                // 1) Text search
                string search = (textBox17?.Text ?? "").Trim();
                if (!string.IsNullOrEmpty(search))
                {
                    string esc = search.Replace("'", "''");
                    filters.Add($"(Product_Name LIKE '%{esc}%' OR Product_Description LIKE '%{esc}%' OR Product_Brand LIKE '%{esc}%' OR Product_BarcodeNumber LIKE '%{esc}%')");
                }

                // 2) Category filter from radio buttons
                int? categoryId = GetSelectedCategoryIdFromRadio();
                if (categoryId.HasValue)
                {
                    filters.Add($"Category_ID = {categoryId.Value}");
                }

                dv.RowFilter = (filters.Count == 0) ? "" : string.Join(" AND ", filters);

                // 3) Sort column
                string sortCol = "Product_Name";
                if (rbPrice.Checked) sortCol = "Product_SellingPrice";
                else if (rbStock.Checked) sortCol = "Product_QuantityInStock";

                // 4) Order direction
                string direction = rbDescending.Checked ? "DESC" : "ASC";

                dv.Sort = $"{sortCol} {direction}";

                // Bind
                this.dataGridView4.DataSource = dv;
                // Adjust column widths for readability
                this.dataGridView4.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to apply view filter/sort: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Determine Category_ID based on which filter radio is checked.
        // Uses substring match against category names in dataset (case-insensitive).
        // Returns null when no category filter selected (show all).
        private int? GetSelectedCategoryIdFromRadio()
        {
            // No selection -> null
            bool anyCategoryChecked = rbBeer.Checked || rbWines.Checked || rbWhiskies.Checked ||
                                      rbSpirits.Checked || rbRTD.Checked || rbNonAlcoholic.Checked ||
                                      rbAccessories.Checked || rbSnacks.Checked || rbTobacco.Checked;
            if (!anyCategoryChecked) return null;

            string keyword = null;
            if (rbBeer.Checked) keyword = "beer";
            else if (rbWines.Checked) keyword = "wine";
            else if (rbWhiskies.Checked) keyword = "whisk";
            else if (rbSpirits.Checked) keyword = "spirit";
            else if (rbRTD.Checked) keyword = "ready"; // 'Ready to drink'
            else if (rbNonAlcoholic.Checked) keyword = "non"; // 'Non-Alcoholic'
            else if (rbAccessories.Checked) keyword = "access";
            else if (rbSnacks.Checked) keyword = "snack";
            else if (rbTobacco.Checked) keyword = "tobacco";

            if (string.IsNullOrEmpty(keyword)) return null;

            // lookup category table for a matching name
            foreach (DataRow r in this.dsSamsLiqourShop.Category.Rows)
            {
                if (r.IsNull("Category_Name")) continue;
                string catName = Convert.ToString(r["Category_Name"]);
                if (catName.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return Convert.ToInt32(r["Category_ID"]);
                }
            }

            // fallback: no matching category found — show none
            return null;
        }

        // Existing add / update / delete / update-tab code remains unchanged below...
        private void label1_Click(object sender, EventArgs e) { }

        private void label2_Click(object sender, EventArgs e) { }

        private void label4_Click(object sender, EventArgs e) { }

        private void tabPage1_Click(object sender, EventArgs e) { }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate required selections
                if (comboBox1.SelectedValue == null)
                {
                    MessageBox.Show("Please select a Category.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBox2.SelectedValue == null)
                {
                    MessageBox.Show("Please select a Supplier.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Required mapped values
                int categoryId = Convert.ToInt32(comboBox1.SelectedValue);
                int supplierId = Convert.ToInt32(comboBox2.SelectedValue);

                // Discount is optional (nullable)
                int? discountId = null;
                if (comboBox3.SelectedValue != null && int.TryParse(comboBox3.SelectedValue.ToString(), out int dVal))
                    discountId = dVal;

                // Text fields
                string productName = textBox1.Text.Trim();
                if (string.IsNullOrEmpty(productName))
                {
                    MessageBox.Show("Product Name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string productDescription = textBox2.Text.Trim();
                string productBrand = textBox3.Text.Trim();
                string productType = textBox4.Text.Trim();
                string productFlavour = textBox5.Text.Trim();

                // Numeric / nullable numeric fields
                decimal? alcoholPercentage = null;
                if (decimal.TryParse(textBox6.Text.Trim(), out decimal alc))
                    alcoholPercentage = alc;

                string productOrigin = textBox7.Text.Trim();
                string productIngredients = textBox8.Text.Trim();

                int sizeML = 0;
                int.TryParse(textBox9.Text.Trim(), out sizeML);

                string barcode = textBox10.Text.Trim();

                if (!decimal.TryParse(textBox11.Text.Trim(), out decimal sellingPrice))
                {
                    MessageBox.Show("Enter a valid Selling Price.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(textBox12.Text.Trim(), out decimal costPrice))
                {
                    MessageBox.Show("Enter a valid Cost Price.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int quantityInStock = 0;
                int.TryParse(textBox13.Text.Trim(), out quantityInStock);

                int reorderQuantity = 0;
                int.TryParse(textBox14.Text.Trim(), out reorderQuantity);

                string status = textBox15.Text.Trim();
                string image = textBox16.Text.Trim();

                // Call the typed TableAdapter Insert (matches dsSamsLiqourShop.ProductTableAdapter.Insert signature)
                this.productTableAdapter.Insert(
                    categoryId,
                    supplierId,
                    discountId,
                    productName,
                    productDescription,
                    productBrand,
                    productType,
                    productFlavour,
                    alcoholPercentage,
                    productOrigin,
                    productIngredients,
                    sizeML,
                    barcode,
                    sellingPrice,
                    costPrice,
                    quantityInStock,
                    reorderQuantity,
                    status,
                    image
                );

                MessageBox.Show("Product added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh products shown in the grid
                this.productTableAdapter.Fill(this.dsSamsLiqourShop.Product);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the product:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
    }

        private void btnDeleteP_Click(object sender, EventArgs e)
        {
            try
            {
                // Prompt user for Product ID (allows you to keep the designer unchanged).
                string input = txtDel.Text;
                if (string.IsNullOrWhiteSpace(input)) return;

                if (!int.TryParse(input.Trim(), out int productId))
                {
                    MessageBox.Show("Please enter a valid numeric Product ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ensure the Product table is loaded
                this.productTableAdapter.Fill(this.dsSamsLiqourShop.Product);

                // Find the product row in the strongly-typed DataTable
                var productRow = this.dsSamsLiqourShop.Product.FindByProduct_ID(productId);
                if (productRow == null)
                {
                    MessageBox.Show($"Product with ID {productId} was not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Confirm deletion with the user
                var confirm = MessageBox.Show($"Are you sure you want to delete product '{productRow.Product_Name}' (ID: {productId})?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                // Mark the row for deletion and push the change to the database via the TableAdapter update
                productRow.Delete();
                int rowsAffected = this.productTableAdapter.Update(this.dsSamsLiqourShop.Product);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Product deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No rows were deleted. Verify permissions and try again.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Refresh grid
                this.productTableAdapter.Fill(this.dsSamsLiqourShop.Product);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the product:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // When a row in the Update tab grid is clicked, populate controls for editing
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                var row = this.dataGridView3.Rows[e.RowIndex];
                var idCell = row.Cells["productIDDataGridViewTextBoxColumn2"].Value;
                if (idCell == null || idCell == DBNull.Value)
                {
                    MessageBox.Show("Selected row does not contain a valid Product ID.", "Invalid row", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int productId = Convert.ToInt32(idCell);
                LoadProductIntoUpdateControls(productId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load selected product:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProductIntoUpdateControls(int productId)
        {
            /* try
             {
                 // Ensure the Product table is loaded and get the typed row
                 this.productTableAdapter.Fill(this.dsSamsLiqourShop.Product);
                 var productRow = this.dsSamsLiqourShop.Product.FindByProduct_ID(productId);

                 if (productRow == null)
                 {
                     MessageBox.Show($"Product with ID {productId} not found in dataset.", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     return;
                 }

                 currentEditingProductId = productId;

                 // Helper readers that avoid relying on generated IsXxxNull() methods
                 Func<string, string> readString = col => (productRow[col] == DBNull.Value) ? "" : Convert.ToString(productRow[col]);
                 Func<string, object> readValueOrNull = col => (productRow[col] == DBNull.Value) ? null : productRow[col];

                 // Populate combo boxes (they are bound by ValueMember to ID)
                 var catVal = readValueOrNull("Category_ID");
                 var supVal = readValueOrNull("Supplier_ID");
                 var discVal = readValueOrNull("Discount_ID");

                 cmbCategory.SelectedValue = (catVal == null) ? (object)null : Convert.ToInt32(catVal);
                 cmbSupplier.SelectedValue = (supVal == null) ? (object)null : Convert.ToInt32(supVal);
                 if (discVal == null) cmbDiscount.SelectedIndex = -1;
                 else cmbDiscount.SelectedValue = Convert.ToInt32(discVal);

                 // Populate textboxes using column names from the dataset
                 txtName.Text = readString("Product_Name");
                 txtDescription.Text = readString("Product_Description");
                 txtBrand.Text = readString("Product_Brand");
                 txtType.Text = readString("Product_Type");
                 txtFlavour.Text = readString("Product_Flavour");
                 txtOrigin.Text = readString("Product_OriginRegion");
                 txtIngredients.Text = readString("Product_Ingredients");
                 txtBarcode.Text = readString("Product_BarcodeNumber");
                 txtStatus.Text = readString("Product_Status");
                 txtImage.Text = readString("Product_Image");

                 // Numeric fields displayed as text (empty when null)
                 txtPercentage.Text = readString("Product_AlcoholPercentage");
                 txtSize.Text = readString("Product_SizeML");
                 txtSellPrice.Text = readString("Product_SellingPrice");
                 txtCostPrice.Text = readString("Product_CostPrice");
                 txtQIS.Text = readString("Product_QuantityInStock");
                 txtROQ.Text = readString("Product_ReorderQuantity");
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Failed to load product into update controls:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }*/
            try
            {
                // Ensure the Product table is loaded and get the typed row
                this.productTableAdapter.Fill(this.dsSamsLiqourShop.Product);
                var productRow = this.dsSamsLiqourShop.Product.FindByProduct_ID(productId);

                if (productRow == null)
                {
                    MessageBox.Show($"Product with ID {productId} not found in dataset.", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                currentEditingProductId = productId;

                // Enable the Update button now that a product is loaded for editing
                if (this.button2 != null) this.button2.Enabled = true;

                // Helper readers that avoid relying on generated IsXxxNull() methods
                Func<string, string> readString = col => (productRow[col] == DBNull.Value) ? "" : Convert.ToString(productRow[col]);
                Func<string, object> readValueOrNull = col => (productRow[col] == DBNull.Value) ? null : productRow[col];

                // Populate combo boxes (they are bound by ValueMember to ID)
                var catVal = readValueOrNull("Category_ID");
                var supVal = readValueOrNull("Supplier_ID");
                var discVal = readValueOrNull("Discount_ID");

                cmbCategory.SelectedValue = (catVal == null) ? (object)null : Convert.ToInt32(catVal);
                cmbSupplier.SelectedValue = (supVal == null) ? (object)null : Convert.ToInt32(supVal);
                if (discVal == null) cmbDiscount.SelectedIndex = -1;
                else cmbDiscount.SelectedValue = Convert.ToInt32(discVal);

                // Populate textboxes using column names from the dataset
                txtName.Text = readString("Product_Name");
                txtDescription.Text = readString("Product_Description");
                txtBrand.Text = readString("Product_Brand");
                txtType.Text = readString("Product_Type");
                txtFlavour.Text = readString("Product_Flavour");
                txtOrigin.Text = readString("Product_OriginRegion");
                txtIngredients.Text = readString("Product_Ingredients");
                txtBarcode.Text = readString("Product_BarcodeNumber");
                txtStatus.Text = readString("Product_Status");
                // txtImage.Text = readString("Product_Image"); image is not a text LOL

                // Numeric fields displayed as text (empty when null)
                txtPercentage.Text = readString("Product_AlcoholPercentage");
                txtSize.Text = readString("Product_SizeML");
                txtSellPrice.Text = readString("Product_SellingPrice");
                txtCostPrice.Text = readString("Product_CostPrice");
                txtQIS.Text = readString("Product_QuantityInStock");
                txtROQ.Text = readString("Product_ReorderQuantity");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load product into update controls:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Update button: persist edits back to the dataset and database
        private void button2_Click(object sender, EventArgs e){

            /* try
             {
                 if (currentEditingProductId == -1)
                 {
                     MessageBox.Show("Please select a product first.",
                         "No Product Selected",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Warning);
                     return;
                 }

                 // Reload products
                 this.productTableAdapter.Fill(this.dsSamsLiqourShop.Product);

                 var productRow =
                     this.dsSamsLiqourShop.Product.FindByProduct_ID(currentEditingProductId);

                 if (productRow == null)
                 {
                     MessageBox.Show("Product not found.",
                         "Error",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error);
                     return;
                 }

                 // ComboBoxes
                 productRow.Category_ID = Convert.ToInt32(cmbCategory.SelectedValue);
                 productRow.Supplier_ID = Convert.ToInt32(cmbSupplier.SelectedValue);

                 if (cmbDiscount.SelectedValue != null)
                     productRow.Discount_ID = Convert.ToInt32(cmbDiscount.SelectedValue);
                 else
                     productRow.SetDiscount_IDNull();

                 // Text Fields
                 productRow.Product_Name = txtName.Text.Trim();
                 productRow.Product_Description = txtDescription.Text.Trim();
                 productRow.Product_Brand = txtBrand.Text.Trim();
                 productRow.Product_Type = txtType.Text.Trim();
                 productRow.Product_Flavour = txtFlavour.Text.Trim();
                 productRow.Product_OriginRegion = txtOrigin.Text.Trim();
                 productRow.Product_Ingredients = txtIngredients.Text.Trim();
                 productRow.Product_BarcodeNumber = txtBarcode.Text.Trim();
                 productRow.Product_Status = txtStatus.Text.Trim();
                 productRow.Product_Image = txtImage.Text.Trim();

                 // Decimal
                 if (decimal.TryParse(txtPercentage.Text, out decimal alc))
                     productRow.Product_AlcoholPercentage = alc;
                 else
                     productRow.SetProduct_AlcoholPercentageNull();

                 // Int
                 if (int.TryParse(txtSize.Text, out int size))
                     productRow.Product_SizeML = size;

                 if (int.TryParse(txtQIS.Text, out int stock))
                     productRow.Product_QuantityInStock = stock;

                 if (int.TryParse(txtROQ.Text, out int reorder))
                     productRow.Product_ReorderQuantity = reorder;

                 // Prices
                 if (!decimal.TryParse(txtSellPrice.Text, out decimal sellPrice))
                 {
                     MessageBox.Show("Invalid Selling Price.");
                     return;
                 }

                 if (!decimal.TryParse(txtCostPrice.Text, out decimal costPrice))
                 {
                     MessageBox.Show("Invalid Cost Price.");
                     return;
                 }

                 productRow.Product_SellingPrice = sellPrice;
                 productRow.Product_CostPrice = costPrice;

                 // Save changes
                 this.productTableAdapter.Update(this.dsSamsLiqourShop.Product);

                 MessageBox.Show("Product updated successfully.",
                     "Success",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Information);

                 // Refresh grid
                 this.productTableAdapter.Fill(this.dsSamsLiqourShop.Product);
             }
             catch (Exception ex)
             {
                 MessageBox.Show(
                     "Error updating product:\n" + ex.Message,
                     "Error",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
             }*/
            try
            {
                if (currentEditingProductId == -1)
                {
                    MessageBox.Show("Please select a product first.",
                        "No Product Selected",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // Reload products
                this.productTableAdapter.Fill(this.dsSamsLiqourShop.Product);

                var productRow =
                    this.dsSamsLiqourShop.Product.FindByProduct_ID(currentEditingProductId);

                if (productRow == null)
                {
                    MessageBox.Show("Product not found.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                // ComboBoxes
                productRow.Category_ID = Convert.ToInt32(cmbCategory.SelectedValue);
                productRow.Supplier_ID = Convert.ToInt32(cmbSupplier.SelectedValue);

                if (cmbDiscount.SelectedValue != null)
                    productRow.Discount_ID = Convert.ToInt32(cmbDiscount.SelectedValue);
                else
                    productRow.SetDiscount_IDNull();

                // Text Fields
                productRow.Product_Name = txtName.Text.Trim();
                productRow.Product_Description = txtDescription.Text.Trim();
                productRow.Product_Brand = txtBrand.Text.Trim();
                productRow.Product_Type = txtType.Text.Trim();
                productRow.Product_Flavour = txtFlavour.Text.Trim();
                productRow.Product_OriginRegion = txtOrigin.Text.Trim();
                productRow.Product_Ingredients = txtIngredients.Text.Trim();
                productRow.Product_BarcodeNumber = txtBarcode.Text.Trim();
                productRow.Product_Status = txtStatus.Text.Trim();
                // productRow.Product_Image = txtImage.Text.Trim(); image is not a text LOL

                // Decimal
                if (decimal.TryParse(txtPercentage.Text, out decimal alc))
                    productRow.Product_AlcoholPercentage = alc;
                else
                    productRow.SetProduct_AlcoholPercentageNull();

                // Int
                if (int.TryParse(txtSize.Text, out int size))
                    productRow.Product_SizeML = size;

                if (int.TryParse(txtQIS.Text, out int stock))
                    productRow.Product_QuantityInStock = stock;

                if (int.TryParse(txtROQ.Text, out int reorder))
                    productRow.Product_ReorderQuantity = reorder;

                // Prices
                if (!decimal.TryParse(txtSellPrice.Text, out decimal sellPrice))
                {
                    MessageBox.Show("Invalid Selling Price.");
                    return;
                }

                if (!decimal.TryParse(txtCostPrice.Text, out decimal costPrice))
                {
                    MessageBox.Show("Invalid Cost Price.");
                    return;
                }

                productRow.Product_SellingPrice = sellPrice;
                productRow.Product_CostPrice = costPrice;

                // Save changes
                this.productTableAdapter.Update(this.dsSamsLiqourShop.Product);

                MessageBox.Show("Product updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Refresh grid
                this.productTableAdapter.Fill(this.dsSamsLiqourShop.Product);

                // Reset editing state to require the user to re-select a row for the next update
                currentEditingProductId = -1;
                if (this.button2 != null) this.button2.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error updating product:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
          /*  try
            {
                // Ensure a row is selected
                if (dataGridView3.CurrentRow == null)
                {
                    MessageBox.Show("Please select a product row first.", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Read product ID from the selected grid row
                object idCell = dataGridView3.CurrentRow.Cells["productIDDataGridViewTextBoxColumn2"].Value;
                if (idCell == null || idCell == DBNull.Value)
                {
                    MessageBox.Show("Selected row does not contain a valid Product ID.", "Invalid row", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int productId = Convert.ToInt32(idCell);

                // Ensure the Product table is loaded and find the typed row by Product_ID.
                this.productTableAdapter.Fill(this.dsSamsLiqourShop.Product);
                var productRow = this.dsSamsLiqourShop.Product.FindByProduct_ID(productId);

                if (productRow == null)
                {
                    MessageBox.Show($"Product with ID {productId} not found in dataset.", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Track currently edited product id
                currentEditingProductId = productId;

                // Helper to safely read columns without relying on typed IsXxxNull() methods
                Func<string, string> readString = col => (productRow[col] == DBNull.Value) ? "" : Convert.ToString(productRow[col]);
                Func<string, object> readValueOrNull = col => (productRow[col] == DBNull.Value) ? null : productRow[col];

                // Populate combo boxes (they are bound by ValueMember to ID)
                var catVal = readValueOrNull("Category_ID");
                var supVal = readValueOrNull("Supplier_ID");
                var discVal = readValueOrNull("Discount_ID");

                cmbCategory.SelectedValue = (catVal == null) ? (object)null : Convert.ToInt32(catVal);
                cmbSupplier.SelectedValue = (supVal == null) ? (object)null : Convert.ToInt32(supVal);
                if (discVal == null)
                    cmbDiscount.SelectedIndex = -1;
                else
                    cmbDiscount.SelectedValue = Convert.ToInt32(discVal);

                // Populate textboxes using column names from the dataset
                txtName.Text = readString("Product_Name");
                txtDescription.Text = readString("Product_Description");
                txtBrand.Text = readString("Product_Brand");
                txtType.Text = readString("Product_Type");
                txtFlavour.Text = readString("Product_Flavour");
                txtOrigin.Text = readString("Product_OriginRegion");
                txtIngredients.Text = readString("Product_Ingredients");
                txtBarcode.Text = readString("Product_BarcodeNumber");
                txtStatus.Text = readString("Product_Status");
                txtImage.Text = readString("Product_Image");

                // Numeric fields displayed as text (empty when null)
                txtPercentage.Text = readString("Product_AlcoholPercentage");
                txtSize.Text = readString("Product_SizeML");
                txtSellPrice.Text = readString("Product_SellingPrice");
                txtCostPrice.Text = readString("Product_CostPrice");
                txtQIS.Text = readString("Product_QuantityInStock");
                txtROQ.Text = readString("Product_ReorderQuantity");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load selected product into the update controls:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/
          
            if (dataGridView3.CurrentRow == null)
            {
                MessageBox.Show("Please select a product.");
                return;
            }

            int productId = Convert.ToInt32(
                dataGridView3.CurrentRow.Cells["productIDDataGridViewTextBoxColumn2"].Value);

            LoadProductIntoUpdateControls(productId);
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            productTableAdapter.FillByProName(dsSamsLiqourShop.Product, textBox17.Text.Trim());
        }

        private void l(object sender, EventArgs e)
        {

        }

        private void rbBeer_CheckedChanged(object sender, EventArgs e)
        {
            // handled by shared handler assigned in Load
        }
    }
}
