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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void discountBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.discountBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsSamsLiqourShop1);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsSamsLiqourShop1.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.dsSamsLiqourShop1.Product);
            // TODO: This line of code loads data into the 'dsSamsLiqourShop1.Discount' table. You can move, or remove it, as needed.
            this.discountTableAdapter.Fill(this.dsSamsLiqourShop1.Discount);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (productDataGridView.CurrentRow == null || productDataGridView.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Please highlight a valid product row in the grid first.");
                return;
            }

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    int selectedProductID = Convert.ToInt32(productDataGridView.CurrentRow.Cells[0].Value);

                    byte[] imageBytes = System.IO.File.ReadAllBytes(openFileDialog1.FileName);

                    productTableAdapter.UpdateQuery(imageBytes, selectedProductID);

                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBytes))
                    {
                        pictureBox1.Image = new Bitmap(ms);
                    }
                    MessageBox.Show("Success! Image bound to Product ID: " + selectedProductID);

                    this.productTableAdapter.Fill(this.dsSamsLiqourShop1.Product);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something went wrong: " + ex.Message);
                }
            }
        }

        private void productDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (productDataGridView.CurrentRow != null && !productDataGridView.CurrentRow.IsNewRow)
            {
                DataRowView currentRow = (DataRowView)productDataGridView.CurrentRow.DataBoundItem;

                if (currentRow["Product_Image"] != DBNull.Value)
                {
                    byte[] imageBytes = (byte[])currentRow["Product_Image"];
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBytes))
                    {
                        pictureBox1.Image = new Bitmap(ms);
                    }
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
        }

        private void productDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Silences formatting exceptions (like DBNull to Image parsing errors)
            e.ThrowException = false;
        }
    }
}
