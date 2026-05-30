using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TheByteClubPOS
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '●';
            pictureBox1.Image = Properties.Resources.ShowEye;
        }
        private string ValidatePasswordDetailed(string password)
        {
            bool hasUpper = false, hasLower = false, hasDigit = false, hasPunctuation = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpper = true;
                else if (char.IsLower(c)) hasLower = true;
                else if (char.IsDigit(c)) hasDigit = true;
                else if (char.IsPunctuation(c) || char.IsSymbol(c)) hasPunctuation = true;
            }

            string errors = "";
            if (!hasUpper) errors += "Missing uppercase letter\n";
            if (!hasLower) errors += "Missing lowercase letter\n";
            if (!hasDigit) errors += "Missing digit\n";
            if (!hasPunctuation) errors += "Missing special character\n";

            return errors;
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
            catch (Exception )
            {
                MessageBox.Show("An error occurred while loading data! Connect to Global Protect. ", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Login Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int count = (int)employeeTableAdapter.FillByEmployeeLogin(txtUsername.Text, txtPassword.Text);
            if (count > 0)
            {
                // Login successful
                int employeeID = (int)employeeTableAdapter.GetEmployeeID(txtUsername.Text, txtPassword.Text);
              
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

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            string employeePassword = txtPassword.Text;
            string errors = ValidatePasswordDetailed(employeePassword);

            if (string.IsNullOrEmpty(errors))
            {
                txtPassword.ForeColor = SystemColors.WindowText;
                toolTip1.SetToolTip(txtPassword, string.Empty);
            }
            else
            {
                txtPassword.ForeColor = Color.Red;
                toolTip1.SetToolTip(txtPassword, errors);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '●')
            {
                txtPassword.PasswordChar = '\0';
                pictureBox1.Image = Properties.Resources.HideEye;
            }
            else
            {
                txtPassword.PasswordChar = '●';
                pictureBox1.Image = Properties.Resources.ShowEye;
            }
        }
    }
}
