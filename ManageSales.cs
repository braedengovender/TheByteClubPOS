using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheByteClubPOS
{
    public partial class ManageSales : Form
    {
        public ManageSales()
        {
            InitializeComponent();
        }

        private void LoadMasterSalesData()
        {
            try
            {
                // TODO: This line of code loads data into the 'dsSamsLiqourShop.SalesSummaryInnerJoinDT' table. You can move, or remove it, as needed.
                this.salesSummaryInnerJoinDTTableAdapter.FillWithDetails(this.dsSamsLiqourShop.SalesSummaryInnerJoinDT);

                // Sorts the grid directly using the UI column and the system sort direction enum
                salesSummaryInnerJoinDTDataGridView.Sort(salesSummaryInnerJoinDTDataGridView.Columns["dataGridViewTextBoxColumn10"], ListSortDirection.Descending);

                salesSummaryInnerJoinDTDataGridView.ClearSelection();

                // Clear out label text if no record is active on initial load
                lblTransactionDetails.Text = "Transaction Details (Select a sale above)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sales history summary: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilters()
        {
            // 1. Validate dates so the range is always logical
            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                // Automatically sync the end date to the start date 
                // to prevent the filter from breaking.
                dtpEndDate.Value = dtpStartDate.Value;
            }

            // Use explicit formatting to prevent regional setting errors
            string startStr = dtpStartDate.Value.Date.ToString("yyyy-MM-dd 00:00:00");
            string endStr = dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss");

            string dateFilter = $"Sale_DateTime >= '{startStr}' AND Sale_DateTime <= '{endStr}'";

            string searchFilter = "";
            if (txtSearch.Text != "Search by Customer, Employee or Promo..." && !string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                string safeSearch = txtSearch.Text.Replace("'", "''").Trim();
                searchFilter = $"(Customer_Details LIKE '%{safeSearch}%' OR Employee_Name LIKE '%{safeSearch}%' OR Sale_Status LIKE '%{safeSearch}%' OR SaleType_Name LIKE '%{safeSearch}%' OR Sale_Discount_Name LIKE '%{safeSearch}%')";
            }

            // Combine them safely
            if (!string.IsNullOrEmpty(searchFilter))
                salesSummaryInnerJoinDTBindingSource.Filter = $"{dateFilter} AND {searchFilter}";
            else
                salesSummaryInnerJoinDTBindingSource.Filter = dateFilter;
        }

        private void ManageSales_Load(object sender, EventArgs e)
        {
            LoadMasterSalesData();
            
        }

        private void salesSummaryInnerJoinDTDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            // Ensure a row is selected and it isn't an empty spacer row
            if (salesSummaryInnerJoinDTDataGridView.CurrentRow != null && !salesSummaryInnerJoinDTDataGridView.CurrentRow.IsNewRow && salesSummaryInnerJoinDTDataGridView.CurrentRow.Index >= 0)
            {
                try
                {
                    // 3. Extract the row primary key using DataRowView mapping to avoid index mismatch bugs
                    DataRowView currentRow = (DataRowView)salesSummaryInnerJoinDTDataGridView.CurrentRow.DataBoundItem;
                    int selectedSaleID = Convert.ToInt32(currentRow["Sale_ID"]);

                    lblTransactionDetails.Text = $"Transaction Details (Invoice Number: {selectedSaleID})";

                    // 4. Pass the selected ID to filter the line items table breakdown automatically
                    this.saleLinesSummaryInnerJoinDTTableAdapter.FillBySaleID(this.dsSamsLiqourShop.SaleLinesSummaryInnerJoinDT, selectedSaleID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading matching transaction details: {ex.Message}", "Data Sync Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show( "Are you sure you want to refresh? This will clear your active search and filters.", "Confirm Refresh", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                txtSearch.Clear(); // Wipe the search input window to reset display bounds
                txtSearch.Text = "Search by Customer, Employee or Promo...";
                txtSearch.ForeColor = Color.Gray;

                // Reset date pickers to today
                dtpStartDate.Value = DateTime.Now;
                dtpEndDate.Value = DateTime.Now;

                salesSummaryInnerJoinDTBindingSource.Filter = ""; // Clears both text and date filters
                LoadMasterSalesData();
                MessageBox.Show("Data successfully refreshed!", "Refresh Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Ignore filtering if the textbox currently contains the placeholder text
            /*if (txtSearch.Text == "Search by Customer, Employee or Promo..." && txtSearch.ForeColor == Color.Gray)
            {
                return;
            }

            try
            {
                // This targets the BindingSource generated by your dataset table component
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    // If search bar is blank, remove filters entirely
                    salesSummaryInnerJoinDTBindingSource.Filter = "";
                }
                else
                {
                    // Safely escapes characters and filters both Customer and Employee column data simultaneously
                    string safeSearchTerm = txtSearch.Text.Replace("'", "''").Trim();
                    salesSummaryInnerJoinDTBindingSource.Filter = string.Format(
                        "Customer_Details LIKE '%{0}%' OR " +
                        "Employee_Name LIKE '%{0}%' OR " +
                        "Sale_Status LIKE '%{0}%' OR " +
                        "SaleType_Name LIKE '%{0}%' OR " +
                        "Sale_Discount_Name LIKE '%{0}%' OR " +
                        "Convert(Sale_DateTime, 'System.String') LIKE '%{0}%' OR " +
                        "Convert(Sale_TotalAmount, 'System.String') LIKE '%{0}%'",
                        safeSearchTerm
                    );
                }
            }
            catch (Exception ex)
            {
                // Soft warning log to prevent crashing if temporary syntax string clipping occurs during rapid input
                System.Diagnostics.Debug.WriteLine("Search string processing mismatch: " + ex.Message);
            }*/
            ApplyFilters();
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search by Customer, Employee or Promo..." && txtSearch.ForeColor == Color.Gray)
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black; // Change text back to crisp typing color
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Search by Customer, Employee or Promo...";
                txtSearch.ForeColor = Color.Gray;
                salesSummaryInnerJoinDTBindingSource.Filter = ""; // Clear active filters
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string helpMessage = "Sales History Help:\n\n" +
                         "1. View Sales: The table lists all completed transactions.\n" +
                         "2. Search: Use the search bar to find sales by Date or Receipt Number.\n" +
                         "3. Print: Select a row and click 'Print Invoice' to generate a copy.\n" +
                         "4. Filter: Use the date range pickers to narrow down historical data.\n\n" +
                         "If you need further assistance, please contact the IT Administrator.";

            MessageBox.Show(helpMessage, "Help - Manage Sales History", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnFilterDate_Click(object sender, EventArgs e)
        {
            /*try
            {
                // Get the dates from the pickers
                DateTime startDate = dtpStartDate.Value.Date;
                DateTime endDate = dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1); // Includes the full end day

                // Construct a filter string based on the Sale_DateTime column
                // We use the '#' delimiter which is standard for DataView filters with dates
                string dateFilter = $"Sale_DateTime >= '{startDate}' AND Sale_DateTime <= '{endDate}'";

                // Apply the filter to the BindingSource
                salesSummaryInnerJoinDTBindingSource.Filter = dateFilter;

                salesSummaryInnerJoinDTDataGridView.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering by date: " + ex.Message);
            }*/

            // 1. Reset pickers to a default "wide" range (e.g., beginning of time to now)
            // You can also use DateTime.MinValue if you want to include every sale ever
            dtpStartDate.Value = new DateTime(2000, 1, 1);
            dtpEndDate.Value = DateTime.Now;

            // 2. Do NOT clear the search box or reload the data from the database.
            // By calling ApplyFilters(), the system will automatically rebuild 
            // the filter string using the new (wide) date range AND your existing text search.
            ApplyFilters();
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnPDFExport_Click(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            
        }
    }
}
