using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TheByteClubPOS
{
    public partial class LoadingForm : Form
    {

        // Dedicated counter to track how many times the timer has ticked
        int tickCount = 0;

        public LoadingForm()
        {
            InitializeComponent();

            progressBarLoading.Value = 0;
            // Starting status text immediately when it opens
            lblStatus.Text = "Initialising system...";
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {

            tmrProgressBar.Start();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblCopyright_Click(object sender, EventArgs e)
        {

        }

        private void progressBarLoading_Click(object sender, EventArgs e)
        {

        }

        private void tmrProgressBar_Tick(object sender, EventArgs e)
        {
            tickCount++; // Move to the next phase

            switch (tickCount)
            {
                case 1:
                    // Starts at 0%
                    lblStatus.Text = "Connecting to database...";
                    progressBarLoading.Increment(33); // Fills to 33%
                    break;

                case 2:
                    // Starts at 33%
                    lblStatus.Text = "Loading point of sale system...";
                    progressBarLoading.Increment(33); // Fills to 66%
                    break;

                case 3:
                    // Starts at 66%
                    lblStatus.Text = "Preparing user interface...";
                    progressBarLoading.Increment(33); // Fills to 99%
                    break;

                case 4:
                    // Starts at 99%
                    lblStatus.Text = "Starting The Byte Club POS...";
                    progressBarLoading.Increment(1); // Snaps to 100% right here!
                    progressBarLoading.Value = 100;

                    // Force the UI to show the 100% complete bar and text instantly
                    this.Refresh();

                    // Let them see it perfectly full for a brief, natural moment
                    System.Threading.Thread.Sleep(600);

                    // Clean up and switch forms
                    tmrProgressBar.Stop();
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                    this.Hide();
                    break;
            }
        }
    }
}
