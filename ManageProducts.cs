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
    }
}
