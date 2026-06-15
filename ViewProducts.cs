using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices; // Required for releasing COM objects
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel; // Alias to make things easier

namespace TheByteClubPOS
{
    public partial class ViewProducts : Form
    {
        // Class-level flag to prevent the dropdowns from fighting each other
        bool isResetting = false;

        public void SetAdminButtonsVisibility(bool isVisible)
        {
            btnAddNewProduct.Visible = isVisible;
            btnEditProduct.Visible = isVisible;
            btnDeactivateProduct.Visible = isVisible;
        }

        public ViewProducts()
        {
            InitializeComponent();
        }

        private void ViewProducts_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.dsSamsLiqourShop.Product);
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.Supplier' table. You can move, or remove it, as needed.
            this.supplierTableAdapter.Fill(this.dsSamsLiqourShop.Supplier);
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.dsSamsLiqourShop.Category);
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.ProductInnerJoinDT' table. You can move, or remove it, as needed.
            this.productInnerJoinDTTableAdapter.FillWithDetails(this.dsSamsLiqourShop.ProductInnerJoinDT);

            // Tell the system we are performing an initial setup reset
            isResetting = true;
            // Force both dropdowns to display absolutely nothing on startup
            cmbCategoryFilter.SelectedIndex = -1;
            cmbSupplierFilter.SelectedIndex = -1;
            // Reset the flag so user clicks can now be processed normally
            isResetting = false;

        }

        private void productInnerJoinDTDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Initialize counter variables explicitly
            int totalProducts = 0;
            decimal totalValue = 0;

            // Loop through every row currently visible in the grid
            for (int i = 0; i < productInnerJoinDTDataGridView.Rows.Count; i++)
            {
                DataGridViewRow row = productInnerJoinDTDataGridView.Rows[i];

                // Skip the blank template row at the very bottom of the grid if it exists
                if (row.IsNewRow)
                {
                    continue;
                }

                // 1. Calculate Total Products
                totalProducts++;

                // 2. Calculate Total Value (Stock Quantity * Cost Price)
                // (Verify that 'Stock Quantity' and 'Cost Price' match your database column names)
                if (row.Cells["dataGridViewTextBoxColumn17"].Value != null && row.Cells["dataGridViewTextBoxColumn16"].Value != null)
                {
                    int stockQty = Convert.ToInt32(row.Cells["dataGridViewTextBoxColumn17"].Value);
                    decimal costPrice = Convert.ToDecimal(row.Cells["dataGridViewTextBoxColumn16"].Value);

                    totalValue += (stockQty * costPrice);
                }

                // 3. Highlight Low Stock Rows (Stock Quantity <= Reorder Quantity)
                // (Verify that 'Stock Quantity' and 'Reorder Quantity' match your database column names)
                if (row.Cells["dataGridViewTextBoxColumn17"].Value != null && row.Cells["dataGridViewTextBoxColumn18"].Value != null)
                {
                    int stockQty = Convert.ToInt32(row.Cells["dataGridViewTextBoxColumn17"].Value);
                    int reorderQty = Convert.ToInt32(row.Cells["dataGridViewTextBoxColumn18"].Value);

                    if (stockQty <= reorderQty)
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose; // Soft warning red/pink color
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.White; // Reset back to white if stock is safe
                    }
                }
            }

            // 4. Assign the final calculations directly to your UI Labels
            lblTotalProducts.Text = "Total Products: " + totalProducts.ToString();
            lblTotalValue.Text = "Total Value: R " + totalValue.ToString("N2"); // Formats as currency (e.g., R 1,250.00)
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            // 1. Validation Check: Ensure there is data to actually export
            if (productInnerJoinDTDataGridView.Rows.Count == 0)
            {
                MessageBox.Show("There are no product records available to export.",
                                "Export Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Configure Save File Dialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Save Full Product Inventory Export";
            saveFileDialog.FileName = "SamsLiquorShop_Product_Report_" + DateTime.Now.ToString("yyyy-MM-dd");

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Change cursor to wait indicator while compiling spreadsheet
                Cursor.Current = Cursors.WaitCursor;

                // Initialize strongly-typed Excel COM Objects
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbooks workbooks = excelApp.Workbooks;
                Excel.Workbook workbook = workbooks.Add(Type.Missing);
                Excel._Worksheet worksheet = (Excel._Worksheet)workbook.ActiveSheet;

                try
                {
                    // 3. Export Column Headers (Export ALL except Product_Image)
                    int excelColIndex = 1;
                    for (int i = 0; i < productInnerJoinDTDataGridView.Columns.Count; i++)
                    {
                        DataGridViewColumn column = productInnerJoinDTDataGridView.Columns[i];

                        // Check by exact backend name to filter out binary/image data
                        if (column.Name != "Product_Image")
                        {
                            worksheet.Cells[1, excelColIndex] = column.HeaderText;
                            excelColIndex++;
                        }
                    }

                    // 4. Export Rows and Cells (Pulls values from hidden and visible cells alike)
                    for (int i = 0; i < productInnerJoinDTDataGridView.Rows.Count; i++)
                    {
                        excelColIndex = 1; // Reset target Excel column for each new row record

                        for (int j = 0; j < productInnerJoinDTDataGridView.Columns.Count; j++)
                        {
                            DataGridViewColumn column = productInnerJoinDTDataGridView.Columns[j];

                            if (column.Name != "Product_Image")
                            {
                                DataGridViewCell cell = productInnerJoinDTDataGridView.Rows[i].Cells[j];

                                // Check for DBNull or C# null to prevent runtime formatting crashes
                                if (cell.Value != null && cell.Value != DBNull.Value)
                                {
                                    worksheet.Cells[i + 2, excelColIndex] = cell.Value.ToString();
                                }
                                else
                                {
                                    worksheet.Cells[i + 2, excelColIndex] = ""; // Clean fallback for null values
                                }

                                excelColIndex++;
                            }
                        }
                    }

                    // 5. Layout Polish: Adjust column widths dynamically to prevent layout clipping
                    worksheet.Columns.AutoFit();

                    // 6. Save Workbook
                    workbook.SaveAs(saveFileDialog.FileName);

                    MessageBox.Show("Complete product inventory successfully exported to Excel!",
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred during the Excel compilation:\n" + ex.Message,
                                    "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // 7. Resource Cleanup: Clean memory references out of OS background processes
                    workbook.Close(false);
                    excelApp.Quit();

                    Marshal.ReleaseComObject(worksheet);
                    Marshal.ReleaseComObject(workbook);
                    Marshal.ReleaseComObject(workbooks);
                    Marshal.ReleaseComObject(excelApp);

                    // Reset cursor indicator
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                txtProductSearch.Clear();
                txtProductSearch.Text = "Search by name, brand or barcode...";
                txtProductSearch.ForeColor = System.Drawing.Color.DarkGray;

                // 2. Re-execute the Fill method to pull live records from the database
                // (Verify that 'productInnerJoinDTTableAdapter' matches your exact backend utility name)
                this.productInnerJoinDTTableAdapter.FillWithDetails(this.dsSamsLiqourShop.ProductInnerJoinDT);

                // Clear any active filters
                this.productInnerJoinDTBindingSource.Filter = "";
                cmbCategoryFilter.SelectedIndex = -1;
                cmbSupplierFilter.SelectedIndex = -1;

                // 3. User feedback confirmation
                MessageBox.Show("Product database successfully refreshed.",
                                "Refresh Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Safety wrap: Catches database connection drops or timeouts smoothly
                MessageBox.Show("An error occurred while synchronizing with SQL Server:\n" + ex.Message,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If the system is currently wiping the other dropdown, ignore this event pass
            if (isResetting) return;

            // If the user manually cleared the choice or it's blank, clear the grid filter
            if (cmbCategoryFilter.SelectedIndex == -1 || cmbCategoryFilter.SelectedValue == null)
            {
                this.productInnerJoinDTBindingSource.Filter = "";
                return;
            }

            string selectedCategory = cmbCategoryFilter.SelectedValue.ToString();

            if (!selectedCategory.Contains("System.Data.DataRowView"))
            {
                // 1. Raise the flag to tell the Supplier dropdown to stand down
                isResetting = true;
                cmbSupplierFilter.SelectedIndex = -1;
                isResetting = false; // Lower the flag

                // 2. Apply the fresh category filter
                this.productInnerJoinDTBindingSource.Filter = "Category_Name = '" + selectedCategory.Replace("'", "''") + "'";
            }
        }

        private void cmbSupplierFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If the system is currently wiping the other dropdown, ignore this event pass
            if (isResetting) return;

            // If the user manually cleared the choice or it's blank, clear the grid filter
            if (cmbSupplierFilter.SelectedIndex == -1 || cmbSupplierFilter.SelectedValue == null)
            {
                this.productInnerJoinDTBindingSource.Filter = "";
                return;
            }

            string selectedSupplier = cmbSupplierFilter.SelectedValue.ToString();

            if (!selectedSupplier.Contains("System.Data.DataRowView"))
            {
                // 1. Raise the flag to tell the Category dropdown to stand down
                isResetting = true;
                cmbCategoryFilter.SelectedIndex = -1;
                isResetting = false; // Lower the flag

                // 2. Apply the fresh supplier filter
                this.productInnerJoinDTBindingSource.Filter = "Supplier_Name = '" + selectedSupplier.Replace("'", "''") + "'";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtProductSearch.Text = "Search by name, brand or barcode...";
            txtProductSearch.ForeColor = System.Drawing.Color.DarkGray; // Fade it out to look like a placeholder again

            // Remove the filter string from the binding source completely
            this.productInnerJoinDTBindingSource.Filter = "";

            // Reset the ComboBox visual state so no specific category is highlighted
            cmbCategoryFilter.SelectedIndex = -1;
            cmbSupplierFilter.SelectedIndex = -1;
        }

        private void txtProductSearch_Enter(object sender, EventArgs e)
        {
            // If the box currently contains the placeholder, wipe it clean for user typing
            if (txtProductSearch.Text == "Search by name, brand or barcode...")
            {
                txtProductSearch.Text = "";
                txtProductSearch.ForeColor = System.Drawing.Color.Black; // Change text color back to normal typing color
            }
        }

        private void txtProductSearch_Leave(object sender, EventArgs e)
        {
            // If the user didn't type anything or just typed spaces, restore the placeholder
            if (string.IsNullOrWhiteSpace(txtProductSearch.Text))
            {
                txtProductSearch.Text = "Search by name, brand or barcode...";
                txtProductSearch.ForeColor = System.Drawing.Color.DarkGray; // Fade it out to look like a placeholder again
            }
        }

        private void txtProductSearch_TextChanged(object sender, EventArgs e)
        {
            // Only filter the database if the user is actually typing a real search query
            if (txtProductSearch.Text != "Search by name, brand or barcode..." && !string.IsNullOrWhiteSpace(txtProductSearch.Text))
            {
                this.productInnerJoinDTBindingSource.Filter = "Product_Name LIKE '%" + txtProductSearch.Text.Replace("'", "''") + "%'";
            }
            else if (txtProductSearch.Text == "Search by name, brand or barcode..." || string.IsNullOrWhiteSpace(txtProductSearch.Text))
            {
                // If the placeholder is showing or it's completely empty, show all items
                this.productInnerJoinDTBindingSource.Filter = "";
            }
        }

        private void btnDeactivateProduct_Click(object sender, EventArgs e)
        {
            // 1. Guard Clause: Ensure a record is selected
            if (productInnerJoinDTDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Please select a product from the list to update.",
                                "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Determine target action based on current button UI state
            string actionType = btnDeactivateProduct.Text == "Reactivate Product" ? "activate" : "deactivate";

            // 2. Security Confirmation Check
            DialogResult confirmation = MessageBox.Show("Are you sure you want to " + actionType + " this product?",
                                                        "Confirm Status Change", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmation == DialogResult.Yes)
            {
                try
                {
                    // 3. Extract the Primary Key (Double-check that 'dataGridViewTextBoxColumn1' is indeed your ID column!)
                    int selectedProductID = Convert.ToInt32(productInnerJoinDTDataGridView.CurrentRow.Cells["dataGridViewTextBoxColumn1"].Value);

                    // 4. Branch logic execution based on current button mode
                    if (btnDeactivateProduct.Text == "Reactivate Product")
                    {
                        this.productTableAdapter.UpdateQueryReactivateProduct(selectedProductID);
                    }
                    else
                    {
                        this.productTableAdapter.UpdateQueryDeactivateProduct(selectedProductID);
                    }

                    // 5. Re-fill the layout grid to show live visual adjustments instantly
                    this.productInnerJoinDTTableAdapter.FillWithDetails(this.dsSamsLiqourShop.ProductInnerJoinDT);

                    MessageBox.Show("Product status successfully updated.",
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while updating the product record:\n" + ex.Message,
                                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void productInnerJoinDTDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            // Ensure a valid row is highlighted and it's not the empty new row template
            if (productInnerJoinDTDataGridView.CurrentRow != null && !productInnerJoinDTDataGridView.CurrentRow.IsNewRow)
            {
                // Target your grid's Status column design name (Verify if it is named 'dataGridViewTextBoxColumnStatus' or similar)
                if (productInnerJoinDTDataGridView.CurrentRow.Cells["dataGridViewTextBoxColumn19"].Value != null)
                {
                    string currentStatus = productInnerJoinDTDataGridView.CurrentRow.Cells["dataGridViewTextBoxColumn19"].Value.ToString();

                    // Dynamic text switching based on row selection status
                    if (currentStatus == "Inactive")
                    {
                        btnDeactivateProduct.Text = "Reactivate Product";
                    }
                    else
                    {
                        btnDeactivateProduct.Text = "Deactivate Product";
                    }
                }
            }
        }

        private void btnAddNewProduct_Click(object sender, EventArgs e)
        {
            try
            {
                // Open Add New Product Form
                AddNewProductForm addNewProductForm = new AddNewProductForm(AddNewProductForm.FormMode.Add);

                addNewProductForm.MdiParent = this.ParentForm;

                addNewProductForm.FormClosed += (senderForm, eventArgs) =>
                {

                    try
                    {
                        // Refresh both the base table and the inner join grid view to show the newly added product
                        // This code runs only when the window closes
                        this.productTableAdapter.Fill(this.dsSamsLiqourShop.Product); // Refresh the Product table
                        this.productInnerJoinDTTableAdapter.FillWithDetails(this.dsSamsLiqourShop.ProductInnerJoinDT);
                    }
                    catch (Exception fillEx)
                    {
                        // Warn the user if the save worked but the dashboard visual refresh failed
                        MessageBox.Show("The product window closed, but the dashboard failed to refresh automatically.\n\n" + fillEx.Message,
                                        "Dashboard Refresh Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };

                // Display the form to the user
                addNewProductForm.Show();
            }
            catch (Exception ex)
            {
                // Global Catch: Prevents the app from crashing if the form fails to initialize (e.g., memory or DB load error)
                MessageBox.Show("An unexpected system error occurred while trying to open the Add Product window:\n\n" + ex.Message, "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation: Ensures a valid, existing row is highlighted
                if (productInnerJoinDTDataGridView.CurrentRow == null || productInnerJoinDTDataGridView.CurrentRow.IsNewRow)
                {
                    MessageBox.Show("Please select a specific product from the inventory list to edit.", "No Product Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Stop execution here
                }

                // Direct Validation: Ensure the cell isn't completely missing before reading it
                if (productInnerJoinDTDataGridView.CurrentRow.Cells["dataGridViewTextBoxColumn1"].Value == null)
                {
                    MessageBox.Show("The system cannot read the ID for this product because the cell is empty.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Explicit Typing: Grab the value directly as a string
                string idString = productInnerJoinDTDataGridView.CurrentRow.Cells["dataGridViewTextBoxColumn1"].Value.ToString();

                // Explicit Parsing: Attempt to convert that string into an integer safely
                int selectedID;
                if (!int.TryParse(idString, out selectedID))
                {
                    MessageBox.Show("The product ID is corrupted or not a valid number. Please check your database.", "Data Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Initialize/ Open Add New Product Form - Pass 'Edit' mode AND the specific Product ID
                AddNewProductForm addNewProductForm = new AddNewProductForm(AddNewProductForm.FormMode.Edit, selectedID);
                addNewProductForm.MdiParent = this.ParentForm;

                // This code runs only when the window closes
                addNewProductForm.FormClosed += (senderForm, eventArgs) =>
                {
                    try
                    {
                        // Refresh both the base table and the inner join grid view
                        this.productTableAdapter.Fill(this.dsSamsLiqourShop.Product); // Refresh the Product table
                        this.productInnerJoinDTTableAdapter.FillWithDetails(this.dsSamsLiqourShop.ProductInnerJoinDT); // Refresh your main grid after they close the form to show updates
                    }
                    catch (Exception fillEx)
                    {
                        MessageBox.Show("The product was updated, but the grid failed to refresh automatically.\n\n" + fillEx.Message, "Refresh Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                };

                // Display the form to the user
                addNewProductForm.Show();
            }
            catch (Exception ex)
            {
                // Captures any completely unexpected UI or memory crashes
                MessageBox.Show("An unexpected system error occurred while trying to open the editor:\n\n" + ex.Message, "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                
        }

        private void btnPDFExport_Click(object sender, EventArgs e)
        {
            if (productInnerJoinDTDataGridView.Rows.Count == 0)
            {
                MessageBox.Show("No data available to export.", "Export Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "PDF Documents (*.pdf)|*.pdf", FileName = "Inventory_Report_" + DateTime.Now.ToString("yyyyMMdd") };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    PdfWriter writer = new PdfWriter(saveFileDialog.FileName);
                    PdfDocument pdf = new PdfDocument(writer);
                    Document document = new Document(pdf, iText.Kernel.Geom.PageSize.A4.Rotate());
                    document.SetMargins(20, 20, 20, 20);

                    // Create Bold Font for the Title
                    PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

                    document.Add(new Paragraph("Product Inventory Report")
                        .SetFontSize(16)
                        .SetFont(boldFont));

                    // Identify columns to export (excluding image)
                    List<DataGridViewColumn> visibleCols = productInnerJoinDTDataGridView.Columns
                        .Cast<DataGridViewColumn>().Where(c => c.Name != "Product_Image").ToList();

                    // Set table to use all available width
                    Table table = new Table(visibleCols.Count).UseAllAvailableWidth();
                    table.SetFixedLayout();

                    // Add Headers
                    foreach (var col in visibleCols)
                    {
                        table.AddHeaderCell(new Cell().Add(new Paragraph(col.HeaderText)
                            .SetFontSize(8)
                            .SetFont(boldFont)) // Using the boldFont object
                            .SetBackgroundColor(ColorConstants.LIGHT_GRAY) // Using ColorConstants
                            .SetTextAlignment(TextAlignment.CENTER));
                    }

                    // Add Rows
                    foreach (DataGridViewRow row in productInnerJoinDTDataGridView.Rows)
                    {
                        if (row.IsNewRow) continue;
                        foreach (var col in visibleCols)
                        {
                            string cellValue = row.Cells[col.Index].Value?.ToString() ?? "";
                            table.AddCell(new Cell().Add(new Paragraph(cellValue)
                                .SetFontSize(7)) // Smaller font to prevent cutoff
                                .SetTextAlignment(TextAlignment.CENTER));
                        }
                    }

                    document.Add(table);
                    document.Close();

                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Export successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string helpMessage = "Product Management Help:                                                          \n\n" +
                 "• Search: Type in the search box to find items by name or barcode.              \n" +
                 "• Filters: Use the Category or Supplier dropdowns to narrow your list.         \n" +
                 "• Low Stock: Items highlighted in red are at or below reorder levels.          \n" +
                 "• Actions: Select a row to 'Deactivate' or 'Reactivate' a product.              \n" +
                 "• Export: Use the Excel or PDF buttons to save your current view as a report.  ";

            MessageBox.Show(helpMessage, "How to use Product Inventory", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
