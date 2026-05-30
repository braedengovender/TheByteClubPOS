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
        // 1. Paste your secret Resend API key here
        private readonly string resendApiKey = "re_f847CzLx_EWHwBfQgKrR22NXkpKjbHTzb";
        public AccountRecoveryForm(string initialUsernameOrEmail)
        {
            InitializeComponent();
            txtEmployeeDetails.Text = initialUsernameOrEmail; // Pre-fill with the username/email that was attempted for login
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            btnRecover.Enabled = false; // Disable button temporarily to prevent double-clicks

            try
            {
                // 2. Build the anonymous object matching Resend's API structure
                // NOTE: Free Resend accounts can only send to their own registered email address
                var emailPayload = new
                {
                    from = "Byte Club <onboarding@resend.dev>", // Leave this as onboarding@resend.dev for free tier
                    to = new[] { "theofficialbyteclub@gmail.com" },
                    subject = "Byte Club API Integration Test",
                    text = $"Success! Sent securely via Web HTTP API at: {DateTime.Now} while connected to VPN."
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
                        MessageBox.Show("HTTP API pipeline transmission complete! Check your inbox.",
                                        "Test Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string errorResponse = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"API rejected request!\n\nStatus Code: {response.StatusCode}\nDetails: {errorResponse}",
                                        "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Web Request Failed!\n\nDetails: {ex.Message}", "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnRecover.Enabled = true; // Turn the button back on
                txtEmployeeDetails.Text = "";
            }
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEmployeeDetails.Text="";
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
    }
}
