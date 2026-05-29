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
    public partial class MainForm : Form
    {
        public int employeeID { get; set; }
        string employeeFullName;
        
        public MainForm(int employeeID)
        {
            InitializeComponent();
            this.employeeID = employeeID;
            employeeFullName = Convert.ToString(employeeTableAdapter.GetEmployeeFullName1(employeeID));
            toolStripTextBox1.Text = "Logged in as: " + employeeFullName;
        }

        private void OpenChildForm(Form childForm)
        {
            // Close existing child forms
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }

            // Open new child form
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.FormBorderStyle = FormBorderStyle.None;

            childForm.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
            else
            {
                return;
            }

            // Close the current  form to clean up memory
            this.Close();

        }

        private void employeeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsSamsLiqourShop);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.dsSamsLiqourShop.Employee);

        }

        private void manageAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageCashierDetailsForm manageCashierDetailsForm = new ManageCashierDetailsForm();
            OpenChildForm(manageCashierDetailsForm);
        }

        private void processSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            POSForm posForm = new POSForm();
            OpenChildForm(posForm);
        }

        private void manageSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageSales manageSales = new ManageSales();
            OpenChildForm(manageSales);
        }

        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageCustomerDetails manageCustomerDetails = new ManageCustomerDetails();
            OpenChildForm(manageCustomerDetails);
        }
    }
}
