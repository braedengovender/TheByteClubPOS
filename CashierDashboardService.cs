using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TheByteClubPOS.dsSamsLiqourShopTableAdapters;
using static TheByteClubPOS.dsSamsLiqourShop;

namespace TheByteClubPOS
{
    // ─────────────────────────────────────────────────────────────────
    // DTOs  (shared with manager dashboard where types already exist,
    //        new ones defined here for cashier-specific data)
    // ─────────────────────────────────────────────────────────────────

    /// <summary>Summary strip for the cashier dashboard.</summary>
    public class CashierSummaryDto
    {
        public int     LowStockCount    { get; set; }
        public int     TotalCustomers   { get; set; }
        // Cashier-specific
        public int     MyTxCount        { get; set; }   // transactions this month by this cashier
        public decimal MyTxTotal        { get; set; }   // total revenue processed by this cashier
    }

    /// <summary>One row in the cashier's own transactions table.</summary>
    public class CashierTransactionDto
    {
        public string   InvoiceNumber { get; set; }
        public DateTime SaleDateTime  { get; set; }
        public string   CustomerName  { get; set; }
        public decimal  TotalAmount   { get; set; }
    }

    /// <summary>Complete payload for CashierDashboardForm.</summary>
    public class CashierDashboardData
    {
        public CashierSummaryDto           Summary         { get; set; }
        public BestCustomerDto             BestCustomer    { get; set; }
        public List<LowStockItemDto>       LowStockItems   { get; set; }
        public List<CashierTransactionDto> MyTransactions  { get; set; }
        public DateTime                    LastUpdated     { get; set; }
    }

    // ─────────────────────────────────────────────────────────────────
    // SERVICE
    // ─────────────────────────────────────────────────────────────────

    public class CashierDashboardService
    {
        private static string ConnStr =>
            Properties.Settings.Default.GroupWst15ConnectionString;

        public CashierDashboardData LoadAll(int cashierEmployeeID)
        {
            var saleAdapter     = new SaleTableAdapter();
            var productAdapter  = new ProductTableAdapter();
            var customerAdapter = new CustomerTableAdapter();

            SaleDataTable    sales    = saleAdapter.GetData();
            ProductDataTable products = productAdapter.GetData();
            CustomerDataTable customers = customerAdapter.GetData();

            var now        = DateTime.Now;
            var monthStart = new DateTime(now.Year, now.Month, 1);

            // All non-cancelled sales this month
            var monthSales = sales.Cast<SaleRow>()
                .Where(s => s.Sale_DateTime >= monthStart &&
                            !string.Equals(s.Sale_Status, "Cancelled",
                                StringComparison.OrdinalIgnoreCase))
                .ToList();

            // ── Cashier's own sales this month ────────────────────────
            // Employee_ID on SaleRow — check nullability via IsNull helper
            var mySales = monthSales
                .Where(s => !s.IsNull("Employee_ID") &&
                             Convert.ToInt32(s["Employee_ID"]) == cashierEmployeeID)
                .ToList();

            // ── Summary ───────────────────────────────────────────────
            int lowStockCount = products.Cast<ProductRow>()
                .Count(p => p.Product_QuantityInStock <= p.Product_ReorderQuantity);

            var summary = new CashierSummaryDto
            {
                LowStockCount  = lowStockCount,
                TotalCustomers = customers.Count,
                MyTxCount      = mySales.Count,
                MyTxTotal      = mySales.Sum(s => s.Sale_TotalAmount)
            };

            // ── Best Customer (store-wide this month) ─────────────────
            var customerDict = customers.Cast<CustomerRow>()
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
            if (bestSpend != null &&
                customerDict.TryGetValue(bestSpend.CustomerId, out var custRow))
            {
                bestCustomer = new BestCustomerDto
                {
                    CustomerName     = (custRow.Customer_FirstName + " " +
                                        custRow.Customer_LastName).Trim(),
                    TotalSpent       = bestSpend.TotalSpent,
                    TransactionCount = bestSpend.TxCount
                };
            }

            // ── Low Stock Items ───────────────────────────────────────
            var lowStockItems = products.Cast<ProductRow>()
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

            // ── Cashier's transactions (raw SQL for LEFT JOIN on Customer) ─
            var myTx = GetCashierTransactions(cashierEmployeeID, 10);

            return new CashierDashboardData
            {
                Summary        = summary,
                BestCustomer   = bestCustomer,
                LowStockItems  = lowStockItems,
                MyTransactions = myTx,
                LastUpdated    = DateTime.Now
            };
        }

        private List<CashierTransactionDto> GetCashierTransactions(int employeeID, int take)
        {
            var result = new List<CashierTransactionDto>();

            const string sql = @"
SELECT TOP (@take)
    s.Sale_ID,
    s.Sale_DateTime,
    s.Sale_TotalAmount,
    ISNULL(c.Customer_FirstName + ' ' + c.Customer_LastName,
           'Walk-in Customer') AS CustomerName
FROM   dbo.Sale s
LEFT  JOIN dbo.Customer c ON s.Customer_ID = c.Customer_ID
WHERE  s.Employee_ID = @empID
  AND  s.Sale_Status <> 'Cancelled'
ORDER  BY s.Sale_DateTime DESC";

            using (var conn = new SqlConnection(ConnStr))
            using (var cmd  = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@take",  take);
                cmd.Parameters.AddWithValue("@empID", employeeID);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        result.Add(new CashierTransactionDto
                        {
                            InvoiceNumber = "INV-" +
                                Convert.ToInt32(rdr["Sale_ID"]).ToString("D6"),
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
