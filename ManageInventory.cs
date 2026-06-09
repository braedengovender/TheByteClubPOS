using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheByteClubPOS.dsSamsLiqourShopTableAdapters;

namespace TheByteClubPOS
{
    public partial class ManageInventory : Form
    {
        public ManageInventory()
        {
            InitializeComponent();
        }

        private void lblTotalAmount_Click(object sender, EventArgs e)
        {

        }

        private void ManageInventory_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.PurchaseOrder' table. You can move, or remove it, as needed.
            this.purchaseOrderTableAdapter.Fill(this.dsSamsLiqourShop.PurchaseOrder);
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.dsSamsLiqourShop.Product);
            productTableAdapter.FillLowStockProducts(
            dsSamsLiqourShop.Product);

            purchaseOrderTableAdapter.FillPendingOrders(
            dsSamsLiqourShop.PurchaseOrder);

            CalculateTotals();

        }
        private void CalculateTotals()
        {
            decimal subtotal = 0;

            foreach (DataGridViewRow row
                in dgvOrderItems.Rows)
            {
                if (row.Cells["colLineTotal"].Value != null)
                {
                    subtotal += Convert.ToDecimal(
                        row.Cells["colLineTotal"].Value);
                }
            }

            decimal vat = subtotal * 0.15m;

            decimal total = subtotal + vat;

            lblItemCount.Text =
                dgvOrderItems.Rows.Count.ToString();

            lblSubtotalAmount.Text =
                "R" + subtotal.ToString("0.00");

            lblVatAmount.Text =
                "R" + vat.ToString("0.00");

            lblTotalAmount.Text =
                "R" + total.ToString("0.00");
        }
        private void dgvProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show(
                    "Please select a product.");

                return;
            }

            string quantityInput =
                Microsoft.VisualBasic.Interaction.InputBox(
                    "Enter quantity to order:",
                    "Quantity",
                    "1");

            int quantity;

            if (!int.TryParse(quantityInput, out quantity))
            {
                MessageBox.Show(
                    "Quantity must be numeric.");

                return;
            }

            if (quantity <= 0)
            {
                MessageBox.Show(
                    "Quantity must be greater than zero.");

                return;
            }

            int productID =
                Convert.ToInt32(
                    dgvProducts.CurrentRow.Cells["Product_ID"].Value);

            string productName =
                dgvProducts.CurrentRow.Cells["Product_Name"]
                .Value.ToString();

            decimal unitPrice =
                Convert.ToDecimal(
                    dgvProducts.CurrentRow.Cells["Product_CostPrice"]
                    .Value);

            int supplierID =
                Convert.ToInt32(
                    dgvProducts.CurrentRow.Cells["Supplier_ID"]
                    .Value);

            decimal lineTotal =
                quantity * unitPrice;

            // Prevent duplicate products
            foreach (DataGridViewRow row in dgvOrderItems.Rows)
            {
                if (row.Cells[0].Value != null &&
                    row.Cells[0].Value.ToString()
                    == productID.ToString())
                {
                    MessageBox.Show(
                        "Product already added.");

                    return;
                }
            }

            dgvOrderItems.Rows.Add(
                productID,
                productName,
                quantity,
                unitPrice,
                lineTotal,
                supplierID);

            CalculateTotals();
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvOrderItems.CurrentRow == null)
            {
                MessageBox.Show(
                    "Please select an item.");

                return;
            }

            dgvOrderItems.Rows.Remove(
                dgvOrderItems.CurrentRow);

            CalculateTotals();
        }

        private void btnClearItems_Click(object sender, EventArgs e)
        {
            DialogResult result =
       MessageBox.Show(
           "Clear entire order?",
           "Confirm",
           MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                dgvOrderItems.Rows.Clear();

                CalculateTotals();
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (dgvOrderItems.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Please add products first.");

                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Send order to supplier?",
                    "Confirm Order",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }

            try
            {
                decimal subtotal = 0;

                foreach (DataGridViewRow row
                    in dgvOrderItems.Rows)
                {
                    if (row.Cells["colLineTotal"].Value != null)
                    {
                        subtotal += Convert.ToDecimal(
                            row.Cells["colLineTotal"].Value);
                    }
                }

                int supplierID =
                    Convert.ToInt32(
                        dgvOrderItems.Rows[0]
                        .Cells["colSupplierID"]
                        .Value);

                int employeeID =
                    LoginForm.LoggedInEmployeeID;

                DateTime orderDate =
                    DateTime.Now;

                DateTime expectedDate =
                    DateTime.Now.AddDays(7);

                // Create purchase order

                purchaseOrderTableAdapter.InsertPurchaseOrder(
                    supplierID,
                    employeeID,
                    orderDate.ToString("yyyy-MM-dd HH:mm:ss"),
                    expectedDate.ToString("yyyy-MM-dd HH:mm:ss"),
                    subtotal,
                    "Sent");

                // Get generated order ID

                int purchaseOrderID =
                    Convert.ToInt32(
                        purchaseOrderTableAdapter
                        .GetLatestPurchaseOrderID());

                // Add all order lines

                foreach (DataGridViewRow row
                    in dgvOrderItems.Rows)
                {
                    if (row.Cells[0].Value == null)
                    {
                        continue;
                    }

                    int productID =
                        Convert.ToInt32(
                            row.Cells["colProductID"]
                            .Value);

                    int quantity =
                        Convert.ToInt32(
                            row.Cells["colQuantity"]
                            .Value);

                    decimal unitPrice =
                        Convert.ToDecimal(
                            row.Cells["colUnitPrice"]
                            .Value);

                    purchaseOrderLineTableAdapter1
                        .InsertPurchaseOrderLine(
                            purchaseOrderID,
                            productID,
                            quantity,
                            unitPrice);
                }

                MessageBox.Show(
                    "Stock Order Sent To Supplier Successfully.");

                dgvOrderItems.Rows.Clear();

                CalculateTotals();

                purchaseOrderTableAdapter.FillPendingOrders(
                    dsSamsLiqourShop.PurchaseOrder);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                productTableAdapter.FillLowStockProducts(
                   dsSamsLiqourShop.Product);

                return;
            }

            // Search products

            productTableAdapter.FillByProductSearch(
                dsSamsLiqourShop.Product,
                txtSearch.Text.Trim());
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }
    }
}
