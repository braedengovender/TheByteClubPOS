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
    public partial class DeactivateCustomer : Form
    {
        public DeactivateCustomer()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (customerDataGridView.SelectedRows.Count > 0)
            {
                int customerID = Convert.ToInt32(customerDataGridView.SelectedRows[0].Cells[0].Value);

                customerTableAdapter.UpdateQueryStatus(customerID, customerID);
                customerTableAdapter.Fill(this.dsSamsLiqourShop.Customer);

                MessageBox.Show("Customer deactivated successfully.");
            }
            else
            {
                MessageBox.Show("Please select a customer first.");
            }
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
    }
}
