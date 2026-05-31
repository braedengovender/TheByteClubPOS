using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheByteClubPOS
{
    public partial class AccountRecoveryForm : Form
    {
        // Secret Resend API key here
        private readonly string resendApiKey = "re_f847CzLx_EWHwBfQgKrR22NXkpKjbHTzb";

        public AccountRecoveryForm(string initialUsernameOrEmail)
        {
            InitializeComponent();
            txtEmployeeDetails.Text = initialUsernameOrEmail; // Pre-fills with the username/email that was attempted for login
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            btnRecover.Enabled = false; // Disable button temporarily to prevent double-clicks

            string input = txtEmployeeDetails.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Please enter your username or email address before requesting a recovery link.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnRecover.Enabled = true;
                return;
            }

            try
            {
                // FIX: Tell the inner dataset container to temporarily ignore strict constraint validations 
                // because our custom query only brings back the 6 columns needed for recovery layout emails.
                this.dsSamsLiqourShop.EnforceConstraints = false;

                // 2.Clear any lingering rows out of your form's employee data table memory pool
                this.dsSamsLiqourShop.Employee.Clear();

                // Call your verified custom query method passing the search input text
                employeeTableAdapter.FillByResetSearchInput(this.dsSamsLiqourShop.Employee,input);

                // Check if the SQL filter query successfully found a matching row
                if (this.dsSamsLiqourShop.Employee.Rows.Count > 0)
                {
                    // Securely isolate the first index record row matching the identity
                    var matchedEmployee = this.dsSamsLiqourShop.Employee[0];

                    // Extract values dynamically using your precise schema column properties
                    string dbUsername = matchedEmployee.Employee_Username;
                    string dbEmail = matchedEmployee.Employee_EmailAddress;
                    string dbPassword = matchedEmployee.Employee_Password;

                    // Secure fallback strings using standard C# checks instead of Dataset helpers:
                    string dbFirstName = string.IsNullOrEmpty(matchedEmployee.Employee_FirstName) ? "Valued Employee" : matchedEmployee.Employee_FirstName;
                    string dbSurname = string.IsNullOrEmpty(matchedEmployee.Employee_LastName) ? "" : matchedEmployee.Employee_LastName;
                    string dbRole = string.IsNullOrEmpty(matchedEmployee.Employee_Role) ? "Staff" : matchedEmployee.Employee_Role;

                    // ---- PROFESSIONAL HTML ENTERPRISE EMAIL DISPATCH ----
                    StringBuilder htmlBuilder = new StringBuilder();
                    htmlBuilder.Append("<div style='font-family: Arial, sans-serif; max-width: 600px; border: 1px solid #dcdde1; padding: 25px; border-radius: 8px; background-color: #ffffff;'>");
                    htmlBuilder.Append("<h2 style='color: #2f3640; border-bottom: 2px solid #718093; padding-bottom: 12px; margin-top: 0;'>🔑 The Byte Club POS - System Credentials Recovery</h2>");
                    htmlBuilder.Append($"<p style='font-size: 15px; color: #2f3640;'>Dear <strong>{dbFirstName} {dbSurname}</strong> ({dbRole}),</p>");
                    htmlBuilder.Append("<p style='font-size: 14px; color: #353b48; line-height: 1.5;'>An administrator account recovery request was triggered for this profile. Your active security log details are listed below:</p>");

                    // Secure Credential Grid Panel Card
                    htmlBuilder.Append("<div style='background-color: #f5f6fa; border-left: 4px solid #00a8ff; padding: 15px; margin: 20px 0; border-radius: 4px;'>");
                    htmlBuilder.Append("<h4 style='margin: 0 0 10px 0; color: #0097e6; text-transform: uppercase; letter-spacing: 0.5px;'>Account Information Details</h4>");
                    htmlBuilder.Append($"<p style='margin: 6px 0; font-size: 14px;'><strong>System Username:</strong> {dbUsername}</p>");
                    htmlBuilder.Append($"<p style='margin: 6px 0; font-size: 14px;'><strong>Registered Email Address:</strong> {dbEmail}</p>");
                    htmlBuilder.Append($"<p style='margin: 6px 0; font-size: 14px;'><strong>System Password:</strong> <span style='font-family: Consolas, monospace; background-color: #dcdde1; padding: 3px 6px; border-radius: 4px; font-weight: bold; color: #c23616;'>{dbPassword}</span></p>");
                    htmlBuilder.Append("</div>");

                    htmlBuilder.Append("<p style='color: #7f8c8d; font-size: 12px; font-style: italic; border-top: 1px solid #f5f6fa; padding-top: 15px;'>Notice: This is a secure automated system copy routed directly to your official development archive group (theofficialbyteclub@gmail.com) for validation verification tests.</p>");
                    htmlBuilder.Append($"<p style='color: #a4b0be; font-size: 11px; margin-top: 10px;'>Timestamp: {DateTime.Now} | Security Mode: Verified Loopback</p>");
                    htmlBuilder.Append("</div>");

                    // 2. Build the anonymous object matching Resend's API structure
                    // NOTE: Free Resend accounts can only send to their own registered email address
                    var emailPayload = new
                    {
                        from = "The Byte Club Helpdesk <onboarding@resend.dev>", // Leave this as onboarding@resend.dev for free tier
                        to = new[] { "theofficialbyteclub@gmail.com" },
                        subject = $"🔒 Password Recovery Details for {dbUsername}",
                        html = htmlBuilder.ToString()
                    };

                    // 3. Serialize the object into a standardized JSON string payload
                    string jsonString = JsonConvert.SerializeObject(emailPayload);
                    var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    // 4. Configure the web client browser engine container
                    using (HttpClient client = new HttpClient())
                    {
                        // Pass your API key safely inside the standard HTTPS request headers layout
                        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {resendApiKey}");

                        // 5. POST the request over standard Port 443 (Web Traffic)
                        HttpResponseMessage response = await client.PostAsync("https://api.resend.com/emails", httpContent);

                        // 6. Check if the server accepted the message payload
                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show($"If an account exists with '{input}', an email has been sent containing your login password.\n\nPlease check your email inbox shortly.", "Recovery Email Dispatched", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("The system was unable to reach the email distribution service. Please verify your internet connection or contact your manager.", "Service Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    // Identical user message box response to cleanly shield system profiles from visibility guessing
                    MessageBox.Show($"If an account exists with '{input}', an email has been sent containing your login password.\n\nPlease check your email inbox shortly.", "Recovery Email Dispatched", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }  
            }
            catch (Exception ex)
            {
                MessageBox.Show($"A database or network error occurred: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Re-enable strict data validation boundaries for other operations safely
                this.dsSamsLiqourShop.EnforceConstraints = true;
                btnRecover.Enabled = true; // Turn the button back on
                txtEmployeeDetails.Text = "";
            }
        }

        public void ApplyTheme()
        {
            // Check the global tracking variable sitting inside LoginForm
            if (LoginForm.IsDarkMode)
            {
                // 1. Dark Mode Rules
                //this.BackgroundImage = Properties.Resources.DarkBackground;

                // Labels turned completely white
                lblCredentials.ForeColor = Color.White;
                lblDetails.ForeColor = Color.White;
                lblEnterDetails.ForeColor = Color.White;

                // Employee Details Textbox -> Black background, White text
                txtEmployeeDetails.BackColor = Color.Black;
                txtEmployeeDetails.ForeColor = Color.White;

                // Buttons styled sleek black with flat white text
                // Recover Button
                btnRecover.BackColor = Color.Black;
                btnRecover.ForeColor = Color.White;
                btnRecover.FlatStyle = FlatStyle.Flat;
                btnRecover.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 60);

                // Clear Button
                btnClear.BackColor = Color.Black;
                btnClear.ForeColor = Color.White;
                btnClear.FlatStyle = FlatStyle.Flat;
                btnClear.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 60);

                // Back to Login Button
                btnBackToLogin.BackColor = Color.Black;
                btnBackToLogin.ForeColor = Color.White;
                btnBackToLogin.FlatStyle = FlatStyle.Flat;
                btnBackToLogin.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 60);

                // Style the recovery form's theme button for Dark Mode
                btnTheme.BackColor = Color.Black;
                btnTheme.ForeColor = Color.White;
                btnTheme.FlatStyle = FlatStyle.Flat;
                btnTheme.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 60);
                btnTheme.Text = "Change to Light Mode";
            }
            else
            {
                // 2. Light Mode Rules (Resets completely back to standard Windows defaults)
                //this.BackgroundImage = Properties.Resources.LightBackground;

                // Labels reset back to system default text color
                lblCredentials.ForeColor = SystemColors.ControlText;
                lblDetails.ForeColor = SystemColors.ControlText;
                lblEnterDetails.ForeColor = SystemColors.ControlText;

                // Textbox reset
                txtEmployeeDetails.BackColor = Color.White;
                txtEmployeeDetails.ForeColor = SystemColors.ControlText;

                // Reset Buttons back to standard 3D appearance system colors
                btnRecover.BackColor = SystemColors.Control;
                btnRecover.ForeColor = SystemColors.ControlText;
                btnRecover.FlatStyle = FlatStyle.Standard;

                btnClear.BackColor = SystemColors.Control;
                btnClear.ForeColor = SystemColors.ControlText;
                btnClear.FlatStyle = FlatStyle.Standard;

                btnBackToLogin.BackColor = SystemColors.ActiveCaption;
                btnBackToLogin.ForeColor = SystemColors.ControlText;
                btnBackToLogin.FlatStyle = FlatStyle.Standard;

                // Reset the recovery form's theme button for Light Mode
                btnTheme.BackColor = SystemColors.Control;
                btnTheme.ForeColor = SystemColors.ControlText;
                btnTheme.FlatStyle = FlatStyle.Standard;

                btnTheme.Text = "Change to Dark Mode";
            }

            // Automatically set the blinking input cursor to the details box on theme application
            txtEmployeeDetails.Focus();
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEmployeeDetails.Text = "";

            // Keeps the text color white if cleared during dark mode active states
            txtEmployeeDetails.ForeColor = LoginForm.IsDarkMode ? Color.White : SystemColors.ControlText;

            txtEmployeeDetails.Focus();
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            Form loginForm = null;
            foreach (Form openForm in Application.OpenForms)
            {
                // Replace 'FormLogin' with the exact class name of your main login form
                if (openForm is LoginForm)
                {
                    loginForm = openForm;
                    break;
                }
            }

            // 2. If the login form was found hidden in memory, show it again
            if (loginForm != null)
            {
                loginForm.Show();
            }
            else
            {
                // Backup: If it was accidentally destroyed, instantiate a completely new one
                LoginForm freshLogin = new LoginForm();
                freshLogin.Show();
            }

            // 3. Close the current recovery form to clean up memory
            this.Close();
        }

        private void AccountRecoveryForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void txtEmployeeDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // checks if enter was pressed
            {
                e.SuppressKeyPress = true; // prevents the sound
                btnRecover.PerformClick();   // triggers the login button click
            }
        }

        private void AccountRecoveryForm_Load(object sender, EventArgs e)
        {

        }

        private void AccountRecoveryForm_Activated(object sender, EventArgs e)
        {
            ApplyTheme(); // Apply the current theme whenever the form is activated (comes into focus)
        }

        private void btnTheme_Click(object sender, EventArgs e)
        {
            // 1. Flip the global switch sitting inside the LoginForm
            LoginForm.IsDarkMode = !LoginForm.IsDarkMode;

            // 2. Refresh the theme on THIS form instantly
            ApplyTheme();
        }
    }
}
