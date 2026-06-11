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

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsSamsLiqourShop1.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.dsSamsLiqourShop1.Product);
            // TODO: This line of code loads data into the 'dsSamsLiqourShop1.Discount' table. You can move, or remove it, as needed.
            this.discountTableAdapter.Fill(this.dsSamsLiqourShop1.Discount);

            LoadImageForCurrentRow();

        }

        private void LoadImageForCurrentRow()
        {
            // 1. Clean up
            if (pictureBox1.Image != null) { pictureBox1.Image.Dispose(); pictureBox1.Image = null; }

            // 2. Safety check
            if (productDataGridView.CurrentRow != null && !productDataGridView.CurrentRow.IsNewRow)
            {
                DataRowView currentRow = (DataRowView)productDataGridView.CurrentRow.DataBoundItem;

                if (currentRow["Product_Image"] != DBNull.Value)
                {
                    byte[] imageBytes = (byte[])currentRow["Product_Image"];
                    try
                    {
                        using (System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBytes))
                        {
                            using (Image img = Image.FromStream(ms))
                            {
                                pictureBox1.Image = new Bitmap(img);
                            }
                        }
                    }
                    catch
                    {
                        // Fallback for OLE headers (as we did before)
                        if (imageBytes.Length > 78)
                        {
                            try
                            {
                                byte[] cleanBytes = new byte[imageBytes.Length - 78];
                                Array.Copy(imageBytes, 78, cleanBytes, 0, cleanBytes.Length);
                                using (System.IO.MemoryStream ms = new System.IO.MemoryStream(cleanBytes))
                                using (Image img = Image.FromStream(ms))
                                    pictureBox1.Image = new Bitmap(img);
                            }
                            catch { }
                        }
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (productDataGridView.CurrentRow == null || productDataGridView.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Please highlight a valid product row.");
                return;
            }

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    byte[] rawBytes = System.IO.File.ReadAllBytes(openFileDialog1.FileName);
                    if (rawBytes.Length == 0) throw new Exception("The selected file is empty.");

                    int selectedProductID = Convert.ToInt32(productDataGridView.CurrentRow.Cells[0].Value);

                    // 1. Save to DB
                    productTableAdapter.UpdateQuery(rawBytes, selectedProductID);

                    // 2. Refresh the DataTable
                    this.productTableAdapter.Fill(this.dsSamsLiqourShop1.Product);

                    // 3. THIS IS THE MISSING STEP: Refresh the PictureBox UI
                    LoadImageForCurrentRow();

                    MessageBox.Show("Success! Image saved.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Upload Failed: " + ex.Message);
                }
            }
        }

        private void productDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            // Simply call the helper method. Do not put the logic here!
            LoadImageForCurrentRow();
        }

        private void productDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Silences formatting exceptions (like DBNull to Image parsing errors)
            e.ThrowException = false;
        }
    }
}
