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
    public partial class ViewCustomer : Form
    {
        public ViewCustomer()
        {
            InitializeComponent();
        }

        private void customerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customerBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsSamsLiqourShop);

        }

        private void ViewCustomer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.dsSamsLiqourShop.Customer);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            customerTableAdapter.FillByCustomerFirstName(dsSamsLiqourShop.Customer, textBox1.Text);
        }
    }
}
