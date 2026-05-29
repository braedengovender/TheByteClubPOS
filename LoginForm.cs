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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void employeeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsSamsLiqourShop);

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'dsSamsLiqourShop.Employee' table. You can move, or remove it, as needed.
                this.employeeTableAdapter.Fill(this.dsSamsLiqourShop.Employee);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading employee data: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = (int)employeeTableAdapter.FillByEmployeeLogin(txtUsername.Text, txtPassword.Text);
            if (count > 0)
            {
                // Login successful
                int employeeID = (int)employeeTableAdapter.GetEmployeeID(txtUsername.Text, txtPassword.Text);
                MessageBox.Show("Login successful!");
                MainForm mainForm = new MainForm(employeeID);
                mainForm.Show();
                this.Close();
            }
            else
            {
                // Login failed
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void btnTestLogin_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "zinhle.d";
            txtPassword.Text = "Zinhle!Cash22";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "sipho.n";
            txtPassword.Text = "SiphoMgr@7";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AccountRecoveryForm accountRecoveryForm = new AccountRecoveryForm(txtUsername.Text);
            accountRecoveryForm.Show();
            this.Hide();
        }
    }
}
