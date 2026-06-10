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
        // place right after: this.discountTableAdapter.Fill(this.dsSamsLiqourShop.Discount);
        //comboBox3.SelectedValue = null;
        // Remove this invalid line from the class-level scope:
        // comboBox3.SelectedValue = null;

        // The following line is invalid at class scope and causes CS1519 and IDE1007 errors:
        // comboBox3.SelectedValue = null;

        // Instead, set SelectedValue (or SelectedIndex) in the constructor or Form Load event, after InitializeComponent() and after comboBox3 is initialized.
        // For example, in the constructor or ManageProducts_Load:

        public ManageProducts()
        {
            InitializeComponent();
            // Set SelectedIndex to -1 after controls are initialized
            if (comboBox3 != null)
                comboBox3.SelectedIndex = -1;
        }

        // Or, in ManageProducts_Load (after filling the Discount table):
        private void ManageProducts_Load(object sender, EventArgs e)
        {
            this.discountTableAdapter.Fill(this.dsSamsLiqourShop.Discount);
            // ... other initialization ...
            if (comboBox3 != null)
                comboBox3.SelectedIndex = -1;
            // ... rest of method ...
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
            /* try
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
             }*/

            try
            {
                // --- 1) Basic required selections ---
                if (comboBox1.SelectedValue == null)
                {
                    MessageBox.Show("Please select a Category.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox1.Focus();
                    return;
                }

                if (comboBox2.SelectedValue == null)
                {
                    MessageBox.Show("Please select a Supplier.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox2.Focus();
                    return;
                }

                // --- 2) Map required IDs ---
                int categoryId = Convert.ToInt32(comboBox1.SelectedValue);
                int supplierId = Convert.ToInt32(comboBox2.SelectedValue);

                // --- 3) Optional discount ---
                int? discountId = null;
                if (comboBox3.SelectedValue != null && int.TryParse(comboBox3.SelectedValue.ToString(), out int dVal))
                    discountId = dVal;

                // --- 4) Text fields validation ---
                string productName = textBox1.Text.Trim();
                if (string.IsNullOrEmpty(productName))
                {
                    MessageBox.Show("Product Name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                    return;
                }

                string productDescription = textBox2.Text.Trim();
                string productBrand = textBox3.Text.Trim();
                string productType = textBox4.Text.Trim();
                string productFlavour = textBox5.Text.Trim();
                string productOrigin = textBox7.Text.Trim();
                string productIngredients = textBox8.Text.Trim();
                string barcode = textBox10.Text.Trim();
                string status = textBox15.Text.Trim();
                string image = textBox16.Text.Trim();

                // --- 5) Numeric fields validation (safe parsing, non-negative checks) ---
                decimal? alcoholPercentage = null;
                if (!string.IsNullOrWhiteSpace(textBox6.Text))
                {
                    if (!decimal.TryParse(textBox6.Text.Trim(), out decimal alc) || alc < 0)
                    {
                        MessageBox.Show("Enter a valid non-negative Alcohol Percentage.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox6.Focus();
                        return;
                    }
                    alcoholPercentage = alc;
                }

                int sizeML = 0;
                if (!string.IsNullOrWhiteSpace(textBox9.Text))
                {
                    if (!int.TryParse(textBox9.Text.Trim(), out sizeML) || sizeML < 0)
                    {
                        MessageBox.Show("Enter a valid non-negative Size (ml).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox9.Focus();
                        return;
                    }
                }

                if (!decimal.TryParse(textBox11.Text.Trim(), out decimal sellingPrice) || sellingPrice < 0)
                {
                    MessageBox.Show("Enter a valid non-negative Selling Price.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox11.Focus();
                    return;
                }

                if (!decimal.TryParse(textBox12.Text.Trim(), out decimal costPrice) || costPrice < 0)
                {
                    MessageBox.Show("Enter a valid non-negative Cost Price.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox12.Focus();
                    return;
                }

                // optional business check: selling should typically be >= cost (warning only)
                if (sellingPrice < costPrice)
                {
                    var resp = MessageBox.Show("Selling price is lower than cost price. Continue?", "Price warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resp != DialogResult.Yes) return;
                }

                int quantityInStock = 0;
                if (!string.IsNullOrWhiteSpace(textBox13.Text))
                {
                    if (!int.TryParse(textBox13.Text.Trim(), out quantityInStock) || quantityInStock < 0)
                    {
                        MessageBox.Show("Enter a valid non-negative Quantity In Stock.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox13.Focus();
                        return;
                    }
                }

                int reorderQuantity = 0;
                if (!string.IsNullOrWhiteSpace(textBox14.Text))
                {
                    if (!int.TryParse(textBox14.Text.Trim(), out reorderQuantity) || reorderQuantity < 0)
                    {
                        MessageBox.Show("Enter a valid non-negative Reorder Quantity.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox14.Focus();
                        return;
                    }
                }

                // --- 6) Insert row (typed TableAdapter Insert used) ---
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

                // Refresh dataset so we can read database values (including the DB-assigned Product_ID and stored reorder quantity)
                this.productTableAdapter.Fill(this.dsSamsLiqourShop.Product);

                MessageBox.Show("Product added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // --- 7) Locate the inserted product in the refreshed table and use database value Product_ReorderQuantity ---
                try
                {
                    // Attempt to find the newly inserted row.
                    // Prefer matching barcode when provided (most reliable).
                    dsSamsLiqourShop.ProductRow added = null;

                    if (!string.IsNullOrWhiteSpace(barcode))
                    {
                        added = this.dsSamsLiqourShop.Product
                            .FirstOrDefault(p => !string.IsNullOrWhiteSpace(p.Product_BarcodeNumber) &&
                                                 p.Product_BarcodeNumber.Equals(barcode, StringComparison.OrdinalIgnoreCase) &&
                                                 string.Equals(p.Product_Name, productName, StringComparison.OrdinalIgnoreCase));
                    }

                    if (added == null)
                    {
                        // Fallback: match by name and selling price, pick the most recent Product_ID
                        added = this.dsSamsLiqourShop.Product
                            .Where(p => string.Equals(p.Product_Name, productName, StringComparison.OrdinalIgnoreCase) &&
                                        p.Product_SellingPrice == sellingPrice)
                            .OrderByDescending(p => p.Product_ID)
                            .FirstOrDefault();
                    }

                    if (added != null)
                    {
                        int dbQis = added.Product_QuantityInStock;
                        int dbReorder = added.Product_ReorderQuantity;

                        // Only alert if reorder level is meaningful (> 0) and stock is at/below reorder.
                        if (dbReorder > 0 && dbQis <= dbReorder)
                        {
                            MessageBox.Show(
                                $"Reorder alert: Product '{added.Product_Name}' (ID {added.Product_ID}) has stock {dbQis} which is at or below its reorder level ({dbReorder}).",
                                "Reorder Alert",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        // If we couldn't locate the inserted row that's unexpected but harmless.
                        // Optionally: log or ignore.
                    }
                }
                catch
                {
                    // Non-fatal: do not interrupt the user flow if post-insert check fails.
                }

                // --- 8) Refresh UI binding (already filled above, but ensure any bound controls update) ---
                this.productTableAdapter.Fill(this.dsSamsLiqourShop.Product);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the product:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDeleteP_Click(object sender, EventArgs e)
        {
            /* try
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
                 productRow.Delete(); //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
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
             }*/

            try
            {
                // Validate input
                string input = txtDel?.Text;
                if (string.IsNullOrWhiteSpace(input))
                {
                    MessageBox.Show("Please enter a Product ID to deactivate.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(input.Trim(), out int productId) || productId <= 0)
                {
                    MessageBox.Show("Please enter a valid numeric Product ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ensure the Product table is loaded for lookup
                this.productTableAdapter.Fill(this.dsSamsLiqourShop.Product);

                var productRow = this.dsSamsLiqourShop.Product.FindByProduct_ID(productId);
                if (productRow == null)
                {
                    MessageBox.Show($"Product with ID {productId} was not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Safe check for current status without relying on generated IsXxxNull
                string currentStatus = productRow.IsNull("Product_Status") ? "" : Convert.ToString(productRow["Product_Status"]);
                if (string.Equals(currentStatus, "Inactive", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show($"Product ID {productId} is already inactive.", "No Action", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var confirm = MessageBox.Show(
                    $"Set product '{productRow.Product_Name}' (ID: {productId}) status to Inactive?",
                    "Confirm Deactivate",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes) return;

                // Update only the status with a direct parameterized SQL command to avoid touching binary/image columns
                var conn = this.productTableAdapter.Connection;
                bool openedHere = false;
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                    openedHere = true;
                }

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Product SET Product_Status = @status WHERE Product_ID = @id";
                    var pStatus = cmd.CreateParameter();
                    pStatus.ParameterName = "@status";
                    pStatus.Value = "Inactive";
                    pStatus.DbType = DbType.String;
                    cmd.Parameters.Add(pStatus);

                    var pId = cmd.CreateParameter();
                    pId.ParameterName = "@id";
                    pId.Value = productId;
                    pId.DbType = DbType.Int32;
                    cmd.Parameters.Add(pId);

                    int affected = cmd.ExecuteNonQuery();
                    if (affected > 0)
                        MessageBox.Show("Product status updated to Inactive.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("No rows were updated. Verify the Product ID and try again.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (openedHere) conn.Close();

                // Refresh local dataset/UI
                this.productTableAdapter.Fill(this.dsSamsLiqourShop.Product);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating product status:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                 // Ensure the lookup selections are present
                 if (cmbCategory.SelectedValue == null)
                 {
                     MessageBox.Show("Please select a Category.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     cmbCategory.Focus();
                     return;
                 }

                 if (cmbSupplier.SelectedValue == null)
                 {
                     MessageBox.Show("Please select a Supplier.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     cmbSupplier.Focus();
                     return;
                 }

                 // Basic text validation
                 string name = txtName.Text?.Trim() ?? "";
                 if (string.IsNullOrEmpty(name))
                 {
                     MessageBox.Show("Product Name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     txtName.Focus();
                     return;
                 }

                 // Validate numeric fields before applying to the DataRow
                 decimal? alcoholPercentage = null;
                 if (!string.IsNullOrWhiteSpace(txtPercentage.Text))
                 {
                     if (!decimal.TryParse(txtPercentage.Text.Trim(), out decimal alc) || alc < 0)
                     {
                         MessageBox.Show("Enter a valid non-negative Alcohol Percentage.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                         txtPercentage.Focus();
                         return;
                     }
                     alcoholPercentage = alc;
                 }

                 int sizeML = 0;
                 if (!string.IsNullOrWhiteSpace(txtSize.Text))
                 {
                     if (!int.TryParse(txtSize.Text.Trim(), out sizeML) || sizeML < 0)
                     {
                         MessageBox.Show("Enter a valid non-negative Size (ml).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                         txtSize.Focus();
                         return;
                     }
                 }

                 int quantityInStock = 0;
                 if (!string.IsNullOrWhiteSpace(txtQIS.Text))
                 {
                     if (!int.TryParse(txtQIS.Text.Trim(), out quantityInStock) || quantityInStock < 0)
                     {
                         MessageBox.Show("Enter a valid non-negative Quantity In Stock.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                         txtQIS.Focus();
                         return;
                     }
                 }

                 int reorderQuantity = 0;
                 if (!string.IsNullOrWhiteSpace(txtROQ.Text))
                 {
                     if (!int.TryParse(txtROQ.Text.Trim(), out reorderQuantity) || reorderQuantity < 0)
                     {
                         MessageBox.Show("Enter a valid non-negative Reorder Quantity.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                         txtROQ.Focus();
                         return;
                     }
                 }

                 if (!decimal.TryParse(txtSellPrice.Text, out decimal sellPrice) || sellPrice < 0)
                 {
                     MessageBox.Show("Enter a valid non-negative Selling Price.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     txtSellPrice.Focus();
                     return;
                 }

                 if (!decimal.TryParse(txtCostPrice.Text, out decimal costPrice) || costPrice < 0)
                 {
                     MessageBox.Show("Enter a valid non-negative Cost Price.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     txtCostPrice.Focus();
                     return;
                 }

                 // Optional business check: selling should typically be >= cost (warning only)
                 if (sellPrice < costPrice)
                 {
                     var resp = MessageBox.Show("Selling price is lower than cost price. Continue?", "Price warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                     if (resp != DialogResult.Yes) return;
                 }

                 // Reload dataset to get the latest state and locate the typed row
                 this.productTableAdapter.Fill(this.dsSamsLiqourShop.Product);
                 var productRow = this.dsSamsLiqourShop.Product.FindByProduct_ID(currentEditingProductId);

                 if (productRow == null)
                 {
                     MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     return;
                 }

                 // Keep the id for post-update lookup
                 int editedProductId = productRow.Product_ID;

                 // Apply changes to the typed DataRow
                 productRow.Category_ID = Convert.ToInt32(cmbCategory.SelectedValue);
                 productRow.Supplier_ID = Convert.ToInt32(cmbSupplier.SelectedValue);

                 if (cmbDiscount.SelectedValue != null && int.TryParse(cmbDiscount.SelectedValue.ToString(), out int discVal))
                     productRow.Discount_ID = discVal;
                 else
                     productRow.SetDiscount_IDNull();

                 productRow.Product_Name = name;
                 productRow.Product_Description = txtDescription.Text?.Trim() ?? "";
                 productRow.Product_Brand = txtBrand.Text?.Trim() ?? "";
                 productRow.Product_Type = txtType.Text?.Trim() ?? "";
                 productRow.Product_Flavour = txtFlavour.Text?.Trim() ?? "";
                 productRow.Product_OriginRegion = txtOrigin.Text?.Trim() ?? "";
                 productRow.Product_Ingredients = txtIngredients.Text?.Trim() ?? "";
                 productRow.Product_BarcodeNumber = txtBarcode.Text?.Trim() ?? "";
                 productRow.Product_Status = txtStatus.Text?.Trim() ?? "";
                 // image ignored as text in UI

                 if (alcoholPercentage.HasValue)
                     productRow.Product_AlcoholPercentage = alcoholPercentage.Value;
                 else
                     productRow.SetProduct_AlcoholPercentageNull();

                 productRow.Product_SizeML = sizeML;
                 productRow.Product_QuantityInStock = quantityInStock;
                 productRow.Product_ReorderQuantity = reorderQuantity;

                 productRow.Product_SellingPrice = sellPrice;
                 productRow.Product_CostPrice = costPrice;

                 // Persist changes
                 this.productTableAdapter.Update(this.dsSamsLiqourShop.Product);

                 MessageBox.Show("Product updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                 // Refresh dataset so we read database-enforced values
                 this.productTableAdapter.Fill(this.dsSamsLiqourShop.Product);

                 // Post-update: read database values and show reorder alert when necessary
                 try
                 {
                     var updated = this.dsSamsLiqourShop.Product.FindByProduct_ID(editedProductId);
                     if (updated != null)
                     {
                         // Use DataRow's IsNull / indexer to avoid relying on generated typed IsXxxNull() methods
                         int dbQis = updated.IsNull("Product_QuantityInStock")
                             ? 0
                             : Convert.ToInt32(updated["Product_QuantityInStock"]);

                         int dbReorder = updated.IsNull("Product_ReorderQuantity")
                             ? 0
                             : Convert.ToInt32(updated["Product_ReorderQuantity"]);

                         string prodName = updated.IsNull("Product_Name") ? "" : Convert.ToString(updated["Product_Name"]);
                         int prodId = updated.IsNull("Product_ID") ? editedProductId : Convert.ToInt32(updated["Product_ID"]);

                         if (dbReorder > 0 && dbQis <= dbReorder)
                         {
                             MessageBox.Show(
                                 $"Reorder alert: Product '{prodName}' (ID {prodId}) has stock {dbQis} which is at or below its reorder level ({dbReorder}).",
                                 "Reorder Alert",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Warning);
                         }
                     }
                 }
                 catch
                 {
                     // Non-fatal: ignore any failure in the post-check
                 }

                 // Reset editing state
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void discountBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void supplierBindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void supplierBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void categoryBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void productBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void txtDel_TextChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void productBindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void txtImage_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtROQ_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQIS_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCostPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSellPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSize_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIngredients_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtOrigin_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPercentage_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFlavour_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtType_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBrand_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void discountBindingSource2_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void discountBindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void supplierBindingSource3_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void supplierBindingSource2_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void categoryBindingSource2_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void categoryBindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void productBindingSource2_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void rbDescending_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbAscending_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void rbStock_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbPrice_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbName_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void rbTobacco_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbSnacks_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbAccessories_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbNonAlcoholic_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbRTD_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbSpirits_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbWhiskies_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbWines_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void productBindingSource3_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
