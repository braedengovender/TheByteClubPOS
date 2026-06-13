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
    public partial class ViewProducts : Form
    {
        public ViewProducts()
        {
            InitializeComponent();
        }

        private void productBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();

        }

        private void ViewProducts_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.ProductInnerJoinDT' table. You can move, or remove it, as needed.
            this.productInnerJoinDTTableAdapter.FillWithDetails(this.dsSamsLiqourShop.ProductInnerJoinDT);

        }

        private void productInnerJoinDTDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Safety check: Only apply formatting if columns have actually loaded
            if (productInnerJoinDTDataGridView.Columns.Count > 0)
            {

                productInnerJoinDTDataGridView.Columns["Discount_Name"].DefaultCellStyle.NullValue = "None";
                productInnerJoinDTDataGridView.Columns["Product_Description"].DefaultCellStyle.NullValue = "";
                productInnerJoinDTDataGridView.Columns["Product_Brand"].DefaultCellStyle.NullValue = "Generic";
                productInnerJoinDTDataGridView.Columns["Product_Type"].DefaultCellStyle.NullValue = "Unspecified";
                productInnerJoinDTDataGridView.Columns["Product_Flavour"].DefaultCellStyle.NullValue = "-";
                productInnerJoinDTDataGridView.Columns["Product_AlcoholPercentage"].DefaultCellStyle.NullValue = "0.0%";
                productInnerJoinDTDataGridView.Columns["Product_OriginRegion"].DefaultCellStyle.NullValue = "-";
                productInnerJoinDTDataGridView.Columns["Product_Ingredients"].DefaultCellStyle.NullValue = "";
            }
        }
    }
}
