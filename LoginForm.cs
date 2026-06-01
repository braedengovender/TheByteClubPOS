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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace TheByteClubPOS
{
    public partial class LoginForm : Form
    {
        int btnClearClickCount = 0;
        int btnClearClickCount2 = 0;
        public static bool IsDarkMode = false;
        public LoginForm()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '●';
            pictureBox1.Image = Properties.Resources.ShowEye;


          /* txtPassword.UseSystemPasswordChar = false;
            txtPassword.PasswordChar = '\0'; // Removes masking

            txtPassword.Text = "Enter Password";
            txtPassword.ForeColor = Color.Gray;*/
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

        public void ApplyTheme()
        {
            if (IsDarkMode)
            {
                // Dark Mode Rules
                // Swap 'DarkBackground' with the exact name of your resource image file
                this.BackgroundImage = Properties.Resources.DarkMode_Background;

                lblLogin.ForeColor = Color.White;
                lblUsername.ForeColor = Color.White;
                lblPassword.ForeColor = Color.White;
                linkLabel1.LinkColor = Color.White;

                // Textboxes become solid black with white text
                txtUsername.BackColor = Color.Black;
                txtUsername.ForeColor = Color.White;
                txtPassword.BackColor = Color.Black;
                txtPassword.ForeColor = Color.White;

                // Login Button (button1) -> Black background, White text
                btnLogin.BackColor = Color.Black;
                btnLogin.ForeColor = Color.White;
                btnLogin.FlatStyle = FlatStyle.Flat; // Gives it a clean, modern flat edge border
                btnLogin.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 60); // Subtle gray border line

                // Clear Button (button2) -> Black background, White text
                btnClear.BackColor = Color.Black;
                btnClear.ForeColor = Color.White;
                btnClear.FlatStyle = FlatStyle.Flat;
                btnClear.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 60);

                // Theme Toggle Button (btnTheme) -> Black background, White text, Flat look
                btnTheme.BackColor = Color.Black;
                btnTheme.ForeColor = Color.White;
                btnTheme.FlatStyle = FlatStyle.Flat;
                btnTheme.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 60);

                btnTheme.Text = "Change to Light Mode";
            }
            else
            {
                // Light Mode Rules
                // Swap 'LightBackground' with your original image name, or set to null if it used a default color
                this.BackgroundImage = Properties.Resources.Background;

                lblLogin.ForeColor = SystemColors.ControlText;
                lblUsername.ForeColor = SystemColors.ControlText;
                lblPassword.ForeColor = SystemColors.ControlText;
                linkLabel1.LinkColor = SystemColors.HotTrack; // Default blue link color for light mode

                txtUsername.BackColor = Color.White;
                txtUsername.ForeColor = SystemColors.ControlText;
                txtPassword.BackColor = Color.White;
                txtPassword.ForeColor = SystemColors.ControlText;

                // Reset Login Button back to default styling system colors
                btnLogin.BackColor = SystemColors.ActiveCaption;
                btnLogin.ForeColor = SystemColors.ControlText;
                btnLogin.FlatStyle = FlatStyle.Standard; // Resets back to the normal 3D button style

                // Reset Clear Button back to default styling system colors
                btnClear.BackColor = SystemColors.Control;
                btnClear.ForeColor = SystemColors.ControlText;
                btnClear.FlatStyle = FlatStyle.Standard;

                // Reset Theme Toggle Button back to normal light mode appearance
                btnTheme.BackColor = SystemColors.Control;
                btnTheme.ForeColor = SystemColors.ControlText;
                btnTheme.FlatStyle = FlatStyle.Standard;

                btnTheme.Text = "Change to Dark Mode";
            }

            // Forces the blinking cursor into the username textbox instantly when the theme flips
            txtUsername.Focus();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            bool loaded = false;
            while(!loaded)
            {
                try
                {
                    // TODO: This line of code loads data into the 'dsSamsLiqourShop.Employee' table. You can move, or remove it, as needed.
                    this.employeeTableAdapter.Fill(this.dsSamsLiqourShop.Employee);
                    loaded = true;
                    txtUsername.Focus();
                }
                catch (Exception ex)
                {
                    DialogResult result = MessageBox.Show("A network error occurred during login: " + Environment.NewLine + Environment.NewLine + "Technical Message: " + ex.Message + Environment.NewLine + Environment.NewLine + "Action Required: Please check internet and VPN connection OR contact administrator for assistance.", "Connectivity Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (result == DialogResult.Cancel)
                    {
                        MessageBox.Show("The application will now close. Please try again later.", "Closing Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Exit();
                        return;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Login Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            string passwordErrors = ValidatePasswordDetailed(password);
            if (!string.IsNullOrEmpty(passwordErrors))
            {
                MessageBox.Show("Password must include: Uppercase, Lowercase, Digit & Special Character.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.ForeColor = Color.Red;
                return;
            }

            try
            {
                int count = (int)employeeTableAdapter.FillByEmployeeLogin(username, password);
                if (count > 0)
                {
                    // Login successful
                    int employeeID = (int)employeeTableAdapter.GetEmployeeID(username, password);

                    MainForm mainForm = new MainForm(employeeID);
                    mainForm.Show();
                    this.Close();
                }
                else
                {
                    // Login failed
                    MessageBox.Show("Access Denied. Invalid username or password.", "Login Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while attempting to log in:\n\n" + ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            // Reset cleanly back to theme-specific colors instead of forcing a hardcoded light-mode default
            txtPassword.ForeColor = IsDarkMode ? Color.White : SystemColors.ControlText;

            txtPassword.PasswordChar = '●';
            toolTip1.SetToolTip(txtPassword, string.Empty);
            pictureBox1.Image = Properties.Resources.ShowEye;

            txtUsername.Focus();
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
                // If the password is valid, change it to White in Dark Mode, or system default in Light Mode
                txtPassword.ForeColor = IsDarkMode ? Color.White : SystemColors.ControlText;
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

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // checks if enter was pressed
            {
                e.SuppressKeyPress = true; // prevents the sound
                btnLogin.PerformClick();   // triggers the login button click
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void btnTheme_Click(object sender, EventArgs e)
        {
            // 1. Flip the switch
            IsDarkMode = !IsDarkMode;

            // 2. Apply the theme to THIS form
            ApplyTheme();
        }

        private void LoginForm_Activated(object sender, EventArgs e)
        {
            ApplyTheme();
        }

        private void txtUsername_MouseClick(object sender, MouseEventArgs e)
        {
            if (btnClearClickCount == 0)
            {
                txtUsername.Text = "";
                btnClearClickCount++;
                txtUsername.ForeColor = Color.Black;
                txtUsername.Font = new Font(txtUsername.Font, FontStyle.Regular);
            }
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (btnClearClickCount == 0)
            {
                txtUsername.Text = "";
                btnClearClickCount++;
                txtUsername.ForeColor = Color.Black;
                txtUsername.Font = new Font(txtUsername.Font, FontStyle.Regular);
            }
        }
    }
}
