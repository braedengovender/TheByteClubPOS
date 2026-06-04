using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

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
            dv.Sort = "Customer_RegistrationDateTime DESC";
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCity.Checked)
            {
                // Prompt user for city filter
                string city = Microsoft.VisualBasic.Interaction.InputBox(
                    "Enter city to filter by:",
                    "City Filter",
                    ""
                );

                if (!string.IsNullOrWhiteSpace(city))
                {
                    dv.RowFilter = $"Customer_City LIKE '%{city.Replace("'", "''")}%'";
                }
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCountry.Checked)
            {
                // Prompt user for country filter
                string country = Microsoft.VisualBasic.Interaction.InputBox(
                    "Enter country to filter by:",
                    "Country Filter",
                    ""
                );

                if (!string.IsNullOrWhiteSpace(country))
                {
                    dv.RowFilter = $"Customer_Country LIKE '%{country.Replace("'", "''")}%'";
                }
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            dv.RowFilter = "Customer_Status = 'Inactive'";
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dv.RowFilter = ""; // Clear Filter

            rbCity.Checked = false;
            rbCountry.Checked = false; //Unchecl Radio Buttons
            rbInactive.Checked = false;

            customerDataGridView.DataSource = dv; // Refresh DataGridView

        }

        private void BtnSort_Click(object sender, EventArgs e)
        {
            dv.Sort = ""; // Clear Sort

            rbFirstName.Checked = false;
            rbSurname.Checked = false; //Uncheck Radio Buttons
            rbDateCreated.Checked = false;

            customerDataGridView.DataSource = dv; // Refresh DataGridView
        }
    }
}
