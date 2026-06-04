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
        DataView dv;
      
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
            dv = dsSamsLiqourShop.Customer.DefaultView;
            customerDataGridView.DataSource = dv;
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.dsSamsLiqourShop.Customer);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            customerTableAdapter.FillByCustomerFirstName(dsSamsLiqourShop.Customer, textBox1.Text);
        }

        private void customerDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (customerDataGridView.Rows[e.RowIndex].Cells[17].Value != null)
            {
                string status = customerDataGridView.Rows[e.RowIndex].Cells[17].Value.ToString();

                if (status == "Inactive")
                {
                    customerDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                    customerDataGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
                else
                {
                    customerDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    customerDataGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dv.Sort = "Customer_FirstName ASC";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dv.Sort = "Customer_LastName ASC";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            dv.Sort = "Customer_Datecreated DESC";
        }
    }
}
