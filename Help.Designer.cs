namespace TheByteClubPOS.Resources
{
    partial class HelpForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbUserGuide = new System.Windows.Forms.RichTextBox();
            this.lstUserGuide = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rtbTroubleshooting = new System.Windows.Forms.RichTextBox();
            this.lstTroubleshooting = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.rtbAbout = new System.Windows.Forms.RichTextBox();
            this.dsSamsLiqourShop1 = new TheByteClubPOS.dsSamsLiqourShop();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsSamsLiqourShop1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1134, 666);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImage = global::TheByteClubPOS.Properties.Resources.HelpBackground;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.rtbUserGuide);
            this.tabPage1.Controls.Add(this.lstUserGuide);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1126, 640);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "User Guide";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(98, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(365, 30);
            this.label2.TabIndex = 4;
            this.label2.Text = "What do you need help with today?";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TheByteClubPOS.Properties.Resources.HelpFormIcon;
            this.pictureBox1.Location = new System.Drawing.Point(25, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(66, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(98, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Please select a guide below";
            // 
            // rtbUserGuide
            // 
            this.rtbUserGuide.BackColor = System.Drawing.Color.White;
            this.rtbUserGuide.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbUserGuide.Location = new System.Drawing.Point(569, 93);
            this.rtbUserGuide.Name = "rtbUserGuide";
            this.rtbUserGuide.ReadOnly = true;
            this.rtbUserGuide.Size = new System.Drawing.Size(464, 437);
            this.rtbUserGuide.TabIndex = 1;
            this.rtbUserGuide.Text = "";
            // 
            // lstUserGuide
            // 
            this.lstUserGuide.BackColor = System.Drawing.Color.White;
            this.lstUserGuide.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstUserGuide.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstUserGuide.FormattingEnabled = true;
            this.lstUserGuide.ItemHeight = 30;
            this.lstUserGuide.Location = new System.Drawing.Point(52, 183);
            this.lstUserGuide.Name = "lstUserGuide";
            this.lstUserGuide.Size = new System.Drawing.Size(335, 300);
            this.lstUserGuide.TabIndex = 0;
            this.lstUserGuide.SelectedIndexChanged += new System.EventHandler(this.lstUserGuide_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackgroundImage = global::TheByteClubPOS.Properties.Resources.HelpBackground;
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.rtbTroubleshooting);
            this.tabPage2.Controls.Add(this.lstTroubleshooting);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1126, 640);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Troubleshooting";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(100, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 30);
            this.label3.TabIndex = 7;
            this.label3.Text = "Is there an issue?";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TheByteClubPOS.Properties.Resources.HelpFormIcon;
            this.pictureBox2.Location = new System.Drawing.Point(25, 28);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(66, 61);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(100, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(354, 30);
            this.label4.TabIndex = 5;
            this.label4.Text = "Please select a problem area below";
            // 
            // rtbTroubleshooting
            // 
            this.rtbTroubleshooting.BackColor = System.Drawing.Color.White;
            this.rtbTroubleshooting.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbTroubleshooting.Location = new System.Drawing.Point(576, 88);
            this.rtbTroubleshooting.Name = "rtbTroubleshooting";
            this.rtbTroubleshooting.ReadOnly = true;
            this.rtbTroubleshooting.Size = new System.Drawing.Size(436, 437);
            this.rtbTroubleshooting.TabIndex = 3;
            this.rtbTroubleshooting.Text = "";
            // 
            // lstTroubleshooting
            // 
            this.lstTroubleshooting.BackColor = System.Drawing.Color.White;
            this.lstTroubleshooting.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstTroubleshooting.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTroubleshooting.FormattingEnabled = true;
            this.lstTroubleshooting.ItemHeight = 30;
            this.lstTroubleshooting.Location = new System.Drawing.Point(55, 182);
            this.lstTroubleshooting.Name = "lstTroubleshooting";
            this.lstTroubleshooting.Size = new System.Drawing.Size(323, 330);
            this.lstTroubleshooting.TabIndex = 2;
            this.lstTroubleshooting.SelectedIndexChanged += new System.EventHandler(this.lstTroubleshooting_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.BackgroundImage = global::TheByteClubPOS.Properties.Resources.Background;
            this.tabPage3.Controls.Add(this.rtbAbout);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1126, 640);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "About";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // rtbAbout
            // 
            this.rtbAbout.Location = new System.Drawing.Point(8, 6);
            this.rtbAbout.Name = "rtbAbout";
            this.rtbAbout.Size = new System.Drawing.Size(1110, 628);
            this.rtbAbout.TabIndex = 0;
            this.rtbAbout.Text = "";
            // 
            // dsSamsLiqourShop1
            // 
            this.dsSamsLiqourShop1.DataSetName = "dsSamsLiqourShop";
            this.dsSamsLiqourShop1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 666);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HelpForm";
            this.Text = "Help";
            this.Load += new System.EventHandler(this.Help_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsSamsLiqourShop1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox rtbUserGuide;
        private System.Windows.Forms.ListBox lstUserGuide;
        private System.Windows.Forms.Label label1;
        private dsSamsLiqourShop dsSamsLiqourShop1;
        private System.Windows.Forms.RichTextBox rtbTroubleshooting;
        private System.Windows.Forms.ListBox lstTroubleshooting;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox rtbAbout;
    }
}