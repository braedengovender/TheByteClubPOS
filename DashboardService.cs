using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

// Bring the typed TableAdapter namespace in scope
using TheByteClubPOS.dsSamsLiqourShopTableAdapters;
using static TheByteClubPOS.dsSamsLiqourShop;

namespace TheByteClubPOS
{
    // ─────────────────────────────────────────────────────────────────
    // DATA TRANSFER OBJECTS (DTOs)
    // ─────────────────────────────────────────────────────────────────

    public class DashboardSummaryDto
    {
        public decimal MonthSalesTotal       { get; set; }
        public int     MonthTransactionCount { get; set; }
        public int     LowStockCount         { get; set; }
        public int     TotalCustomers        { get; set; }
        public int     TotalEmployees        { get; set; }
    }

    public class CategorySalesDto
    {
        public string  CategoryName { get; set; }
        public decimal TotalSales   { get; set; }
    }

    public class ProductSalesRankDto
    {
        public int    Rank        { get; set; }
        public string ProductName { get; set; }
        public int    UnitsSold   { get; set; }
    }

    public class RecentTransactionDto
    {
        public string   InvoiceNumber { get; set; }
        public DateTime SaleDateTime  { get; set; }
        public string   CustomerName  { get; set; }
        public decimal  TotalAmount   { get; set; }
    }

    public class LowStockItemDto
    {
        public string ProductName  { get; set; }
        public int    CurrentStock { get; set; }
        public int    ReorderLevel { get; set; }
    }

    public class BestCustomerDto
    {
        public string  CustomerName     { get; set; }
        public decimal TotalSpent       { get; set; }
        public int     TransactionCount { get; set; }
    }

    public class DashboardData
    {
        public DashboardSummaryDto        Summary            { get; set; }
        public List<CategorySalesDto>     CategorySales      { get; set; }
        public List<ProductSalesRankDto>  TopSelling         { get; set; }
        public List<ProductSalesRankDto>  LeastSelling       { get; set; }
        public List<RecentTransactionDto> RecentTransactions { get; set; }
        public List<LowStockItemDto>      LowStockItems      { get; set; }
        public BestCustomerDto            BestCustomer       { get; set; }
        public DateTime                   LastUpdated        { get; set; }
    }

    // ─────────────────────────────────────────────────────────────────
    // SERVICE
    // ─────────────────────────────────────────────────────────────────

    public class DashboardService
    {
        private static string ConnStr =>
            Properties.Settings.Default.GroupWst15ConnectionString;

        // ── Public entry point ────────────────────────────────────────

        public DashboardData LoadAll()
        {
            // Fill typed DataTables via the existing adapters
            var saleAdapter     = new SaleTableAdapter();
            var saleLineAdapter = new SaleLineTableAdapter();
            var productAdapter  = new ProductTableAdapter();
            var categoryAdapter = new CategoryTableAdapter();
            var customerAdapter = new CustomerTableAdapter();
            var employeeAdapter = new EmployeeTableAdapter();

            SaleDataTable     sales      = saleAdapter.GetData();
            SaleLineDataTable saleLines  = saleLineAdapter.GetData();
            ProductDataTable  products   = productAdapter.GetData();
            CategoryDataTable categories = categoryAdapter.GetData();
            CustomerDataTable customers  = customerAdapter.GetData();
            EmployeeDataTable employees  = employeeAdapter.GetData();

            // ── Current-month filter ──────────────────────────────────
            // Sale_DateTime is NOT NULL in the schema – access it directly.
            // Sale_Status  is NOT NULL in the schema – access it directly.
            var monthStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            var monthSales = sales
                .Cast<SaleRow>()
                .Where(s => s.Sale_DateTime >= monthStart &&
                            !string.Equals(s.Sale_Status, "Cancelled",
                                           StringComparison.OrdinalIgnoreCase))
                .ToList();

            // ── Summary cards ─────────────────────────────────────────
            // Sale_TotalAmount is NOT NULL – safe to read directly.
            decimal monthTotal = monthSales.Sum(s => s.Sale_TotalAmount);

            // Product_QuantityInStock and Product_ReorderQuantity are NOT NULL.
            int lowStockCount = products
                .Cast<ProductRow>()
                .Count(p => p.Product_QuantityInStock <= p.Product_ReorderQuantity);

            var summary = new DashboardSummaryDto
            {
                MonthSalesTotal       = monthTotal,
                MonthTransactionCount = monthSales.Count,
                LowStockCount         = lowStockCount,
                TotalCustomers        = customers.Count,
                TotalEmployees        = employees.Count
            };

            // ── Sales by Category ─────────────────────────────────────
            var monthSaleIds = new HashSet<int>(monthSales.Select(s => s.Sale_ID));

            // Build lookup dictionaries to avoid O(n²) scanning
            var productDict  = products  .Cast<ProductRow>()
                                          .ToDictionary(p => p.Product_ID);
            var categoryDict = categories.Cast<CategoryRow>()
                                          .ToDictionary(c => c.Category_ID);

            var categoryRevenue = saleLines
                .Cast<SaleLineRow>()
                .Where(sl => monthSaleIds.Contains(sl.Sale_ID) &&
                             productDict.ContainsKey(sl.Product_ID) &&
                             categoryDict.ContainsKey(productDict[sl.Product_ID].Category_ID))
                .GroupBy(sl => categoryDict[productDict[sl.Product_ID].Category_ID].Category_Name)
                .Select(g => new CategorySalesDto
                {
                    CategoryName = g.Key,
                    // SaleLine_Subtotal is NOT NULL in the schema.
                    TotalSales   = g.Sum(sl => sl.SaleLine_Subtotal)
                })
                .OrderByDescending(x => x.TotalSales)
                .ToList();

            // ── Top / Least Selling ───────────────────────────────────
            // SaleLine_Quantity is NOT NULL in the schema.
            var unitsByProduct = saleLines
                .Cast<SaleLineRow>()
                .Where(sl => monthSaleIds.Contains(sl.Sale_ID) &&
                             productDict.ContainsKey(sl.Product_ID))
                .GroupBy(sl => productDict[sl.Product_ID].Product_Name)
                .Select(g => new ProductSalesRankDto
                {
                    ProductName = g.Key,
                    UnitsSold   = g.Sum(sl => sl.SaleLine_Quantity)
                })
                .ToList();

            var top5 = unitsByProduct
                .OrderByDescending(x => x.UnitsSold)
                .Take(5)
                .Select((x, i) => { x.Rank = i + 1; return x; })
                .ToList();

            var least5 = unitsByProduct
                .OrderBy(x => x.UnitsSold)
                .Take(5)
                .Select((x, i) => { x.Rank = i + 1; return x; })
                .ToList();

            // ── Recent Transactions (LEFT JOIN so walk-ins are included) ──
            var recentTx = GetRecentTransactions(5);

            // ── Low Stock Items ───────────────────────────────────────
            var lowStockItems = products
                .Cast<ProductRow>()
                .Where(p => p.Product_QuantityInStock <= p.Product_ReorderQuantity)
                .OrderBy(p => p.Product_QuantityInStock)
                .Take(5)
                .Select(p => new LowStockItemDto
                {
                    ProductName  = p.Product_Name,
                    CurrentStock = p.Product_QuantityInStock,
                    ReorderLevel = p.Product_ReorderQuantity
                })
                .ToList();

            // ── Best Customer ─────────────────────────────────────────
            // Customer_ID IS nullable on SaleRow – use IsCustomer_IDNull()
            // (the only genuine IsXxx_Null() method on SaleRow).
            var customerDict = customers
                .Cast<CustomerRow>()
                .ToDictionary(c => c.Customer_ID);

            var bestSpend = monthSales
                .Where(s => !s.IsCustomer_IDNull() &&
                             customerDict.ContainsKey(s.Customer_ID))
                .GroupBy(s => s.Customer_ID)
                .Select(g => new
                {
                    CustomerId = g.Key,
                    TotalSpent = g.Sum(s => s.Sale_TotalAmount),
                    TxCount    = g.Count()
                })
                .OrderByDescending(x => x.TotalSpent)
                .FirstOrDefault();

            BestCustomerDto bestCustomer = null;
            if (bestSpend != null && customerDict.TryGetValue(bestSpend.CustomerId, out var custRow))
            {
                bestCustomer = new BestCustomerDto
                {
                    CustomerName     = (custRow.Customer_FirstName + " " +
                                        custRow.Customer_LastName).Trim(),
                    TotalSpent       = bestSpend.TotalSpent,
                    TransactionCount = bestSpend.TxCount
                };
            }

            return new DashboardData
            {
                Summary            = summary,
                CategorySales      = categoryRevenue,
                TopSelling         = top5,
                LeastSelling       = least5,
                RecentTransactions = recentTx,
                LowStockItems      = lowStockItems,
                BestCustomer       = bestCustomer,
                LastUpdated        = DateTime.Now
            };
        }

        // ── Recent transactions: raw SQL with LEFT JOIN ───────────────

        private List<RecentTransactionDto> GetRecentTransactions(int take)
        {
            var result = new List<RecentTransactionDto>();

            const string sql = @"
SELECT TOP (@take)
    s.Sale_ID,
    s.Sale_DateTime,
    s.Sale_TotalAmount,
    ISNULL(c.Customer_FirstName + ' ' + c.Customer_LastName,
           'Walk-in Customer') AS CustomerName
FROM   dbo.Sale s
LEFT  JOIN dbo.Customer c ON s.Customer_ID = c.Customer_ID
WHERE  s.Sale_Status <> 'Cancelled'
ORDER  BY s.Sale_DateTime DESC";

            using (var conn = new SqlConnection(ConnStr))
            using (var cmd  = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@take", take);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        result.Add(new RecentTransactionDto
                        {
                            InvoiceNumber = "INV-" + Convert.ToInt32(rdr["Sale_ID"]).ToString("D6"),
                            SaleDateTime  = Convert.ToDateTime(rdr["Sale_DateTime"]),
                            CustomerName  = rdr["CustomerName"].ToString(),
                            TotalAmount   = Convert.ToDecimal(rdr["Sale_TotalAmount"])
                        });
                    }
                }
            }

            return result;
        }
    }
}
