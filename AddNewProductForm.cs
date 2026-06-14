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
    public partial class AddNewProductForm : Form
    {
        private int currentTip = 0;
        private string[] tips =
        {
            "💡 Use the barcode search for faster product lookup.",
            "💡 Review low-stock products daily on your dashboard.",
            "💡 Export reports to Excel for analysis.",
            "💡 Check the dashboard for sales insights.",
            "💡 Inactive products are not eligible for sale.",
        };

        public AddNewProductForm()
        {
            InitializeComponent();
        }

        private void productBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsSamsLiqourShop);

        }

        private void AddNewProductForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.dsSamsLiqourShop.Product);
            lblTips.Text = tips[0];
        }

        private void timerTips_Tick(object sender, EventArgs e)
        {
            currentTip++;

            if (currentTip >= tips.Length)
                currentTip = 0;

            lblTips.Text = tips[currentTip];
        }
    }
}
