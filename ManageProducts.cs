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
        public ManageProducts()
        {
            InitializeComponent();
        }

        private void ManageProducts_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.Discount' table. You can move, or remove it, as needed.
            this.discountTableAdapter.Fill(this.dsSamsLiqourShop.Discount);
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.Supplier' table. You can move, or remove it, as needed.
            this.supplierTableAdapter.Fill(this.dsSamsLiqourShop.Supplier);
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.dsSamsLiqourShop.Category);
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.dsSamsLiqourShop.Product);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

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
    }
}
