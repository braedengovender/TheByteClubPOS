using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TheByteClubPOS.dsSamsLiqourShop;

namespace TheByteClubPOS
{
    public partial class MainForm : Form
    {
        public int employeeID { get; set; }
        string employeeFullName;
        string employeeRole;

        public MainForm(int employeeID)
        {
            InitializeComponent();
            this.employeeID = employeeID;

            var employeeTable = employeeTableAdapter.GetDataByEmployeeID(employeeID);

            if (employeeTable.Rows.Count > 0)
            {
                var employeeRow = employeeTable[0];

                this.employeeFullName = employeeRow.Employee_FirstName + " " + employeeRow.Employee_LastName;
                this.employeeRole = employeeRow.Employee_Role;

                toolStripStatusLabelUser.Text = $"Logged in as: {employeeFullName}";
                toolStripStatusLabelRole.Text = $"Role: {employeeRole}";


            }

            toolStripStatusLabelTerminal.Text = "Terminal: POS-01";
            toolStripStatusLabelVersion.Text = "Version: 1.2";
            toolStripStatusLabelConnection.Text = "Sttaus: Connected";
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.dsSamsLiqourShop.Employee);

            toolStripMenuItemDate.Text = DateTime.Now.ToString("dddd, dd MMM yyyy");
            toolStripMenuItemTime.Text = DateTime.Now.ToString("HH:mm:ss");
            tmrClock.Start();

        }

        private void manageAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageCashierDetailsForm manageCashierDetailsForm = new ManageCashierDetailsForm();
            OpenChildForm(manageCashierDetailsForm);
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

        private void processSaleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            POSForm posForm = new POSForm();
            OpenChildForm(posForm);
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
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

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            toolStripMenuItemDate.Text = DateTime.Now.ToString("dddd, dd MMM yyyy");
            toolStripMenuItemTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
