// DashboardForm.Designer.cs
// Minimal designer stub — all controls are built in DashboardForm.cs.
// Replace your existing DashboardForm.Designer.cs with this file.

namespace TheByteClubPOS
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));

            this.SuspendLayout();

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(245, 247, 250);
            this.ClientSize          = new System.Drawing.Size(1280, 780);
            this.Name                = "DashboardForm";
            this.Text                = "Dashboard";

            // Preserve the original form icon stored in the .resx
            try
            {
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            }
            catch { /* no icon resource — harmless */ }

            this.ResumeLayout(false);
        }

        #endregion
    }
}
