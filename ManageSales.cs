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
    public partial class ManageSales : Form
    {
        public ManageSales()
        {
            InitializeComponent();
        }

        private void saleBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.saleBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsSamsLiqourShop);

        }

        private void ManageSales_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.SaleLine' table. You can move, or remove it, as needed.
            this.saleLineTableAdapter.Fill(this.dsSamsLiqourShop.SaleLine);
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.Sale' table. You can move, or remove it, as needed.
            this.saleTableAdapter.Fill(this.dsSamsLiqourShop.Sale);

        }

        private void saleBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.saleBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsSamsLiqourShop);

        }
    }
}
