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
    public partial class ManageCashierDetailsForm : Form
    {
        public ManageCashierDetailsForm()
        {
            InitializeComponent();
        }


        private void ManageCashierDetailsForm_Load(object sender, EventArgs e)
        {
            MainForm parent = (MainForm)this.MdiParent;

            // TODO: This line of code loads data into the 'dsSamsLiqourShop.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.FillByEmployeeDetails(this.dsSamsLiqourShop.Employee, parent.employeeID);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();

                employeeBindingSource.EndEdit();

                employeeTableAdapter.Update(dsSamsLiqourShop.Employee);

                MessageBox.Show("Details updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (employee_PasswordTextBox.UseSystemPasswordChar)
            {
                employee_PasswordTextBox.UseSystemPasswordChar = false;
                btnShow.Text = "Hide";
            }
            else
            {
                employee_PasswordTextBox.UseSystemPasswordChar = true;
                btnShow.Text = "Show";
            }
        }
    }
}
