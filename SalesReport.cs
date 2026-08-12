using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace TheByteClubPOS
{
    /// <summary>
    /// Sales Report using the CRYSTAL PUSH MODEL.
    ///
    /// The .rpt is designed against SalesReportSchema.xsd -- it holds no
    /// connection details at all. This class fetches the rows itself and hands
    /// the DataTable to the report via SetDataSource().
    ///
    /// Advantages over letting Crystal connect for itself:
    ///   * No database credentials stored inside the .rpt file
    ///   * No "Database Logon Failed" prompt at runtime
    ///   * You can design the report with no database access (use sample data)
    ///   * The same .rpt drops into the ASP.NET Web Forms project unchanged
    /// </summary>
    public partial class SalesReport : Form
    {
        private ReportDocument reportDocument;

        /// <summary>
        /// Set to true to render from SalesReportSampleData.xml instead of the
        /// database. Useful while you have no DB access, and for demoing the
        /// report if the server is unreachable. Flip to false once connected.
        /// </summary>
        private const bool UseSampleData = false;

        public SalesReport()
        {
            InitializeComponent();
        }

        private void SalesReport_Load(object sender, EventArgs e)
        {
            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEnd.Value = DateTime.Now;
            GenerateReport();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            GenerateReport();
        }

        // ─────────────────────────────────────────────────────────────────
        private void GenerateReport()
        {
            if (dtpStart.Value.Date > dtpEnd.Value.Date)
            {
                MessageBox.Show("The start date cannot be after the end date.",
                                "Invalid Date Range",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;

                DataTable data = UseSampleData
                    ? LoadSampleData()
                    : LoadSalesData(dtpStart.Value.Date, dtpEnd.Value.Date);

                if (data.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "No sales were found for the selected period.",
                        "No Data",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    crystalReportViewer1.ReportSource = null;
                    return;
                }

                reportDocument?.Close();
                reportDocument?.Dispose();
                reportDocument = new ReportDocument();

                reportDocument.Load(Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory, "rptSalesReport.rpt"));

                // THE KEY LINE -- pushes the rows into the report
                reportDocument.SetDataSource(data);

                // Header text. These are report parameters, NOT command parameters,
                // so they only affect what is printed -- they do not filter anything.
                reportDocument.SetParameterValue("StartDate", dtpStart.Value.Date);
                reportDocument.SetParameterValue("EndDate", dtpEnd.Value.Date);

                crystalReportViewer1.ReportSource = reportDocument;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not generate the report:\n\n" + ex.Message,
                                "Report Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // ─────────────────────────────────────────────────────────────────
        /// <summary>
        /// Runs Query 1 from SalesReport_Queries.sql against GroupWst15.
        /// Read-only -- creates nothing on the server.
        /// </summary>
        private DataTable LoadSalesData(DateTime startDate, DateTime endDate)
        {
            const string sql = @"
SELECT
    s.Sale_ID, sl.Product_ID, p.Category_ID, s.Employee_ID, s.Customer_ID,
    s.Sale_DateTime,
    CAST(s.Sale_DateTime AS DATE)                    AS Sale_Date,
    DATEPART(YEAR,    s.Sale_DateTime)               AS Sale_Year,
    DATEPART(MONTH,   s.Sale_DateTime)               AS Sale_MonthNumber,
    DATENAME(MONTH,   s.Sale_DateTime)               AS Sale_MonthName,
    DATEPART(QUARTER, s.Sale_DateTime)               AS Sale_Quarter,
    DATENAME(WEEKDAY, s.Sale_DateTime)               AS Sale_DayName,
    DATEPART(HOUR,    s.Sale_DateTime)               AS Sale_Hour,
    p.Product_Name, p.Product_Brand, p.Product_SizeML,
    c.Category_Name, sup.Supplier_Name, st.SaleType_Name,
    e.Employee_FirstName + ' ' + e.Employee_LastName AS Employee_Name,
    e.Employee_Role,
    ISNULL(cust.Customer_FirstName + ' ' + cust.Customer_LastName,
           'Walk-in Customer')                       AS Customer_Name,
    pm.PaymentMethod_Name,
    s.Sale_Status,
    sl.SaleLine_Quantity                             AS Quantity,
    sl.SaleLine_OriginalUnitPrice                    AS UnitPrice_Original,
    sl.SaleLine_UnitPriceAfterDiscount               AS UnitPrice_AfterDiscount,
    sl.SaleLine_Subtotal                             AS LineRevenue,
    CAST((sl.SaleLine_OriginalUnitPrice - sl.SaleLine_UnitPriceAfterDiscount)
         * sl.SaleLine_Quantity AS DECIMAL(18,2))    AS LineDiscountAmount,
    CAST(p.Product_CostPrice * sl.SaleLine_Quantity AS DECIMAL(18,2))
                                                     AS LineCost,
    CAST(sl.SaleLine_Subtotal - (p.Product_CostPrice * sl.SaleLine_Quantity)
         AS DECIMAL(18,2))                           AS LineGrossProfit,
    s.Sale_Subtotal, s.Sale_DiscountAmount, s.Sale_TotalAmount
FROM        dbo.SaleLine       AS sl
INNER JOIN  dbo.Sale           AS s    ON s.Sale_ID           = sl.Sale_ID
INNER JOIN  dbo.Product        AS p    ON p.Product_ID        = sl.Product_ID
INNER JOIN  dbo.Category       AS c    ON c.Category_ID       = p.Category_ID
LEFT  JOIN  dbo.Supplier       AS sup  ON sup.Supplier_ID     = p.Supplier_ID
LEFT  JOIN  dbo.SaleType       AS st   ON st.SaleType_ID      = s.SaleType_ID
LEFT  JOIN  dbo.Employee       AS e    ON e.Employee_ID       = s.Employee_ID
LEFT  JOIN  dbo.Customer       AS cust ON cust.Customer_ID    = s.Customer_ID
LEFT  JOIN  dbo.Payment        AS pay  ON pay.Sale_ID         = s.Sale_ID
LEFT  JOIN  dbo.PaymentMethod  AS pm   ON pm.PaymentMethod_ID = pay.PaymentMethod_ID
WHERE       s.Sale_Status <> 'Cancelled'
  AND       s.Sale_DateTime >= @StartDate
  AND       s.Sale_DateTime <  DATEADD(DAY, 1, CAST(@EndDate AS DATE))
ORDER BY    s.Sale_DateTime, s.Sale_ID;";

            string connStr = ConfigurationManager.ConnectionStrings[
                "TheByteClubPOS.Properties.Settings.GroupWst15ConnectionString"]
                .ConnectionString;

            // The DataTable name MUST match the table name in the .xsd,
            // otherwise SetDataSource cannot bind the fields.
            var table = new DataTable("SalesFact");

            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.CommandTimeout = 60;

                using (var adapter = new SqlDataAdapter(cmd))
                    adapter.Fill(table);
            }

            return table;
        }

        // ─────────────────────────────────────────────────────────────────
        /// <summary>
        /// Reads SalesReportData.xml so the report renders with no database
        /// connection. That file carries its schema inline, so ReadXml picks up
        /// the correct column types on its own -- no separate .xsd needed.
        /// Set the file to Copy to Output Directory.
        /// </summary>
        private DataTable LoadSampleData()
        {
            var ds = new DataSet();
            ds.ReadXml(Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "SalesReportData.xml"),
                XmlReadMode.ReadSchema);

            return ds.Tables["SalesFact"];
        }

        private void SalesReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            reportDocument?.Close();
            reportDocument?.Dispose();
        }

    }
}
