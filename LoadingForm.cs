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
    public partial class LoadingForm : Form
    {
        int progress = 0;
        public LoadingForm()
        {
            InitializeComponent();
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            
        }

        private void tmrLoadingForm_Tick(object sender, EventArgs e)
        {
            progress++;

            progressBarLoading.Value = progress;

            if (progress == 10)
                lblStatus.Text = "Initialising system...";

            if (progress == 25)
                lblStatus.Text = "Connecting to database...";

            if (progress == 45)
                lblStatus.Text = "Loading inventory system...";

            if (progress == 65)
                lblStatus.Text = "Preparing user interface...";

            if (progress == 85)
                lblStatus.Text = "Starting The Byte Club POS...";

            if (progress >= 100)
            {
                tmrLoadingForm.Stop();

                LoginForm login = new LoginForm();
                login.Show();

                this.Hide();
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblCopyright_Click(object sender, EventArgs e)
        {

        }
    }
}
