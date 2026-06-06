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
    public partial class SalesReport : Form
    {
        private dsSamsLiqourShop dsSamsLiqourShop;
        private dsSamsLiqourShopTableAdapters.CategoryTableAdapter categoryTableAdapter;
        private dsSamsLiqourShopTableAdapters.ProductTableAdapter productTableAdapter;
        private dsSamsLiqourShopTableAdapters.SaleTableAdapter saleTableAdapter;
        private dsSamsLiqourShopTableAdapters.SaleLineTableAdapter saleLineTableAdapter;

        public SalesReport()
        {
            InitializeComponent();
            dsSamsLiqourShop = new dsSamsLiqourShop();

            // Initialize the table adapters
            categoryTableAdapter = new dsSamsLiqourShopTableAdapters.CategoryTableAdapter();
            productTableAdapter = new dsSamsLiqourShopTableAdapters.ProductTableAdapter();
            saleTableAdapter = new dsSamsLiqourShopTableAdapters.SaleTableAdapter();
            saleLineTableAdapter = new dsSamsLiqourShopTableAdapters.SaleLineTableAdapter();
        }

        private void SalesReport_Load(object sender, EventArgs e)
        {
            LoadAllData();
        }

        private void LoadAllData()
        {
            try
            {
                // Load all necessary tables from the database
                saleTableAdapter.Fill(dsSamsLiqourShop.Sale);
                saleLineTableAdapter.Fill(dsSamsLiqourShop.SaleLine);
                productTableAdapter.Fill(dsSamsLiqourShop.Product);
                categoryTableAdapter.Fill(dsSamsLiqourShop.Category);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        // Button 1: Total Revenue
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                decimal totalRevenue = 0;

                foreach (DataRow saleRow in dsSamsLiqourShop.Sale.Rows)
                {
                    if (saleRow.RowState != DataRowState.Deleted)
                    {
                        int saleID = Convert.ToInt32(saleRow["Sale_ID"]);
                        
                        // Sum all sale line subtotals for this sale
                        var saleLinesForSale = dsSamsLiqourShop.SaleLine.AsEnumerable()
                            .Where(row => Convert.ToInt32(row["Sale_ID"]) == saleID && row.RowState != DataRowState.Deleted);

                        foreach (var saleLine in saleLinesForSale)
                        {
                            totalRevenue += Convert.ToDecimal(saleLine["SaleLine_Subtotal"]);
                        }
                    }
                }

                richTextBox1.Clear();
                richTextBox1.AppendText("TOTAL REVENUE REPORT\n");
                richTextBox1.AppendText("====================\n\n");
                richTextBox1.AppendText($"Total Revenue: R{totalRevenue:N2}\n");
            }
            catch (Exception ex)
            {
                richTextBox1.Clear();
                richTextBox1.AppendText("Error: " + ex.Message);
            }
        }

        // Button 2: Total Sales Per Category
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Clear();
                richTextBox1.AppendText("TOTAL SALES PER CATEGORY\n");
                richTextBox1.AppendText("========================\n\n");

                var categorySales = new Dictionary<string, decimal>();

                foreach (DataRow saleLineRow in dsSamsLiqourShop.SaleLine.Rows)
                {
                    if (saleLineRow.RowState != DataRowState.Deleted)
                    {
                        int productID = Convert.ToInt32(saleLineRow["Product_ID"]);
                        decimal subtotal = Convert.ToDecimal(saleLineRow["SaleLine_Subtotal"]);

                        var product = dsSamsLiqourShop.Product.AsEnumerable()
                            .FirstOrDefault(p => Convert.ToInt32(p["Product_ID"]) == productID && p.RowState != DataRowState.Deleted);

                        if (product != null)
                        {
                            int categoryID = Convert.ToInt32(product["Category_ID"]);
                            var category = dsSamsLiqourShop.Category.AsEnumerable()
                                .FirstOrDefault(c => Convert.ToInt32(c["Category_ID"]) == categoryID && c.RowState != DataRowState.Deleted);

                            if (category != null)
                            {
                                string categoryName = category["Category_Name"].ToString();
                                if (!categorySales.ContainsKey(categoryName))
                                {
                                    categorySales[categoryName] = 0;
                                }
                                categorySales[categoryName] += subtotal;
                            }
                        }
                    }
                }

                if (categorySales.Count == 0)
                {
                    richTextBox1.AppendText("No sales data available.\n");
                }
                else
                {
                    foreach (var category in categorySales.OrderByDescending(x => x.Value))
                    {
                        richTextBox1.AppendText($"{category.Key}: R{category.Value:N2}\n");
                    }
                }
            }
            catch (Exception ex)
            {
                richTextBox1.Clear();
                richTextBox1.AppendText("Error: " + ex.Message);
            }
        }

        // Button 3: Products That Are Low on Stock
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Clear();
                richTextBox1.AppendText("LOW STOCK PRODUCTS\n");
                richTextBox1.AppendText("==================\n\n");

                const int lowStockThreshold = 10; // Products with 10 or fewer units
                bool hasLowStockProducts = false;

                foreach (DataRow productRow in dsSamsLiqourShop.Product.Rows)
                {
                    if (productRow.RowState != DataRowState.Deleted)
                    {
                        int quantity = Convert.ToInt32(productRow["Product_Quantity"]);
                        if (quantity <= lowStockThreshold)
                        {
                            hasLowStockProducts = true;
                            string productName = productRow["Product_Name"].ToString();
                            richTextBox1.AppendText($"• {productName}: {quantity} units\n");
                        }
                    }
                }

                if (!hasLowStockProducts)
                {
                    richTextBox1.AppendText("All products have adequate stock levels.\n");
                }
            }
            catch (Exception ex)
            {
                richTextBox1.Clear();
                richTextBox1.AppendText("Error: " + ex.Message);
            }
        }

        // Button 4: Products That Are Below Average Stock Levels
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Clear();
                richTextBox1.AppendText("BELOW AVERAGE STOCK PRODUCTS\n");
                richTextBox1.AppendText("============================\n\n");

                // Calculate average stock level
                double averageStock = 0;
                int productCount = 0;

                foreach (DataRow productRow in dsSamsLiqourShop.Product.Rows)
                {
                    if (productRow.RowState != DataRowState.Deleted)
                    {
                        averageStock += Convert.ToInt32(productRow["Product_Quantity"]);
                        productCount++;
                    }
                }

                if (productCount > 0)
                {
                    averageStock /= productCount;

                    richTextBox1.AppendText($"Average Stock Level: {averageStock:F2} units\n\n");

                    bool hasBelowAverage = false;

                    foreach (DataRow productRow in dsSamsLiqourShop.Product.Rows)
                    {
                        if (productRow.RowState != DataRowState.Deleted)
                        {
                            int quantity = Convert.ToInt32(productRow["Product_Quantity"]);
                            if (quantity < averageStock)
                            {
                                hasBelowAverage = true;
                                string productName = productRow["Product_Name"].ToString();
                                richTextBox1.AppendText($"• {productName}: {quantity} units\n");
                            }
                        }
                    }

                    if (!hasBelowAverage)
                    {
                        richTextBox1.AppendText("No products below average stock level.\n");
                    }
                }
                else
                {
                    richTextBox1.AppendText("No product data available.\n");
                }
            }
            catch (Exception ex)
            {
                richTextBox1.Clear();
                richTextBox1.AppendText("Error: " + ex.Message);
            }
        }

        // Button 5: Best Selling Product
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Clear();
                richTextBox1.AppendText("BEST SELLING PRODUCT\n");
                richTextBox1.AppendText("====================\n\n");

                var productSales = new Dictionary<int, int>(); // ProductID, Quantity Sold
                var productInfo = new Dictionary<int, string>(); // ProductID, ProductName

                foreach (DataRow saleLineRow in dsSamsLiqourShop.SaleLine.Rows)
                {
                    if (saleLineRow.RowState != DataRowState.Deleted)
                    {
                        int productID = Convert.ToInt32(saleLineRow["Product_ID"]);
                        int quantity = Convert.ToInt32(saleLineRow["SaleLine_Quantity"]);

                        if (!productSales.ContainsKey(productID))
                        {
                            productSales[productID] = 0;

                            var product = dsSamsLiqourShop.Product.AsEnumerable()
                                .FirstOrDefault(p => Convert.ToInt32(p["Product_ID"]) == productID && p.RowState != DataRowState.Deleted);

                            if (product != null)
                            {
                                productInfo[productID] = product["Product_Name"].ToString();
                            }
                        }

                        productSales[productID] += quantity;
                    }
                }

                if (productSales.Count == 0)
                {
                    richTextBox1.AppendText("No sales data available.\n");
                }
                else
                {
                    var bestSeller = productSales.OrderByDescending(x => x.Value).First();
                    string productName = productInfo.ContainsKey(bestSeller.Key) 
                        ? productInfo[bestSeller.Key] 
                        : "Unknown";

                    richTextBox1.AppendText($"Product: {productName}\n");
                    richTextBox1.AppendText($"Total Units Sold: {bestSeller.Value}\n");
                }
            }
            catch (Exception ex)
            {
                richTextBox1.Clear();
                richTextBox1.AppendText("Error: " + ex.Message);
            }
        }

        // Button 6: Products That Have Never Been Sold
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Clear();
                richTextBox1.AppendText("NEVER SOLD PRODUCTS\n");
                richTextBox1.AppendText("===================\n\n");

                var soldProductIDs = new HashSet<int>();

                foreach (DataRow saleLineRow in dsSamsLiqourShop.SaleLine.Rows)
                {
                    if (saleLineRow.RowState != DataRowState.Deleted)
                    {
                        int productID = Convert.ToInt32(saleLineRow["Product_ID"]);
                        soldProductIDs.Add(productID);
                    }
                }

                bool hasNeverSold = false;

                foreach (DataRow productRow in dsSamsLiqourShop.Product.Rows)
                {
                    if (productRow.RowState != DataRowState.Deleted)
                    {
                        int productID = Convert.ToInt32(productRow["Product_ID"]);

                        if (!soldProductIDs.Contains(productID))
                        {
                            hasNeverSold = true;
                            string productName = productRow["Product_Name"].ToString();
                            richTextBox1.AppendText($"• {productName}\n");
                        }
                    }
                }

                if (!hasNeverSold)
                {
                    richTextBox1.AppendText("All products have been sold.\n");
                }
            }
            catch (Exception ex)
            {
                richTextBox1.Clear();
                richTextBox1.AppendText("Error: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
