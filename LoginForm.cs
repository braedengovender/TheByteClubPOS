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
using static TheByteClubPOS.dsSamsLiqourShop;

namespace TheByteClubPOS
{
    public partial class LoginForm : Form
    {
        public static int LoggedInEmployeeID;
        //int btnClearClickCount = 0;
        //int btnClearClickCount2 = 0;
        public static bool IsDarkMode = false;

        private string[] quotes =
{
            "\"Customer loyalty is earned, not bought.\"",

            "\"Inventory is money sitting on shelves.\"",

            "\"Profit is made when buying, not selling.\"",

            "\"A satisfied customer is the best business strategy.\"",

            "\"Great businesses are built on great service.\"",

            "\"Every sale begins with trust.\"",

            "\"Success is the sum of small efforts repeated daily.\"",

            "\"Quality means doing it right when no one is looking.\"",

            "\"The goal is not to sell once, but to create a customer for life.\"",

            "\"Small improvements every day lead to remarkable results.\""
        };
        private int currentQuoteIndex = 0;
        private Random random = new Random();

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
                this.BackgroundImage = Properties.Resources.DarkModeLogin;

                lblLogin.ForeColor = Color.White;
                lblUsername.ForeColor = Color.White;
                lblPassword.ForeColor = Color.White;
                linkLabel1.LinkColor = Color.White;
                lblQuote.ForeColor = Color.White;

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

                btnTheme.Image = Properties.Resources.DarkModeIconInverted;
            }
            else
            {
                // Light Mode Rules
                // Swap 'LightBackground' with your original image name, or set to null if it used a default color
                this.BackgroundImage = Properties.Resources.Untitled_design__1_;

                lblLogin.ForeColor = SystemColors.ControlText;
                lblUsername.ForeColor = SystemColors.ControlText;
                lblPassword.ForeColor = SystemColors.ControlText;
                linkLabel1.LinkColor = SystemColors.HotTrack; // Default blue link color for light mode
                lblQuote.ForeColor = SystemColors.ControlText;

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

                btnTheme.Image = Properties.Resources.DarkModeIcon;
            }

            // Forces the blinking cursor into the username textbox instantly when the theme flips
            txtUsername.Focus();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            lblQuote.Text = quotes[0];
            tmrQuote.Start();
            // 1. Set the initial placeholder text for Username
            txtUsername.Text = "Enter Username";
            txtUsername.ForeColor = Color.Gray;

            // 2. Set the initial placeholder text for Password
            // We set PasswordChar to '\0' so the placeholder text "Enter Password" is readable
            txtPassword.PasswordChar = '\0';
            txtPassword.Text = "Enter Password";
            txtPassword.ForeColor = Color.Gray;

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
                    // Store logged in employee ID for use throughout the system
                    LoggedInEmployeeID = employeeID;

                    MainForm mainForm = new MainForm(employeeID, IsDarkMode);
                    mainForm.Show();
                    this.Close();
                }
                else
                {
                    string statusCheck = employeeTableAdapter.GetStatusByUsername(username);
                    if (statusCheck == "Inactive")
                    {
                        MessageBox.Show("Access Denied. Your account is currently inactive. Please contact a manager.",
                                        "Account Inactive", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        // Login failed
                        MessageBox.Show("Access Denied. Invalid username or password.", "Login Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while attempting to log in:\n\n" + ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTestLogin_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "dlamini@liquorstore.co.za";
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
                //toolTip1.SetToolTip(txtPassword, string.Empty);
            }
            else
            {
                // txtPassword.ForeColor = Color.Red;
                //toolTip1.SetToolTip(txtPassword, errors);
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
            /*if (btnClearClickCount == 0)
            {
                txtUsername.Text = "";
                btnClearClickCount++;
                txtUsername.ForeColor = Color.Black;
                txtUsername.Font = new Font(txtUsername.Font, FontStyle.Regular);
            }*/
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            /*if (btnClearClickCount == 0)
            {
                txtUsername.Text = "";
                btnClearClickCount++;
                txtUsername.ForeColor = Color.Black;
                txtUsername.Font = new Font(txtUsername.Font, FontStyle.Regular);
            }*/
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            txtUsername.Text = "naledi.khumalo@liquorstore.co.za";
            txtPassword.Text = "NalediAdmin2023#";
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            // If the text is your placeholder, clear it when they click in
            if (txtUsername.Text == "Enter Username")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = IsDarkMode ? Color.White : Color.Black;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            // If they clicked away and left it empty, put the placeholder back
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.Text = "Enter Username";
                txtUsername.ForeColor = Color.Gray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Enter Password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = IsDarkMode ? Color.White : Color.Black;
                txtPassword.PasswordChar = '●'; // Re-enable masking for the real password
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.PasswordChar = '\0'; // Disable masking so the placeholder "Enter Password" is visible
                txtPassword.Text = "Enter Password";
                txtPassword.ForeColor = Color.Gray;
            }
        }

        private void tmrQuote_Tick(object sender, EventArgs e)
        {
            currentQuoteIndex =
            random.Next(quotes.Length);

            lblQuote.Text =
                quotes[currentQuoteIndex];

            tmrQuote.Start();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
