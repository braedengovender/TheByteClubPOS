namespace TheByteClubPOS
{
    partial class LoginForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.btnTestLoginCashier = new System.Windows.Forms.Button();
            this.btnTestLoginManager = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblLogin = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnTheme = new System.Windows.Forms.Button();
            this.dsSamsLiqourShop = new TheByteClubPOS.dsSamsLiqourShop();
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.employeeTableAdapter = new TheByteClubPOS.dsSamsLiqourShopTableAdapters.EmployeeTableAdapter();
            this.tableAdapterManager = new TheByteClubPOS.dsSamsLiqourShopTableAdapters.TableAdapterManager();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsSamsLiqourShop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTestLoginCashier
            // 
            this.btnTestLoginCashier.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestLoginCashier.Location = new System.Drawing.Point(1546, 665);
            this.btnTestLoginCashier.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTestLoginCashier.Name = "btnTestLoginCashier";
            this.btnTestLoginCashier.Size = new System.Drawing.Size(282, 62);
            this.btnTestLoginCashier.TabIndex = 5;
            this.btnTestLoginCashier.Text = "Login as Cashier";
            this.btnTestLoginCashier.UseVisualStyleBackColor = true;
            this.btnTestLoginCashier.Click += new System.EventHandler(this.btnTestLogin_Click);
            // 
            // btnTestLoginManager
            // 
            this.btnTestLoginManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestLoginManager.Location = new System.Drawing.Point(1546, 758);
            this.btnTestLoginManager.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTestLoginManager.Name = "btnTestLoginManager";
            this.btnTestLoginManager.Size = new System.Drawing.Size(282, 62);
            this.btnTestLoginManager.TabIndex = 6;
            this.btnTestLoginManager.Text = "Login as Manager";
            this.btnTestLoginManager.UseVisualStyleBackColor = true;
            this.btnTestLoginManager.Click += new System.EventHandler(this.button3_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 870F));
            this.tableLayoutPanel1.Controls.Add(this.lblLogin, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.linkLabel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(584, 385);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 122F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 134F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(870, 531);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // lblLogin
            // 
            this.lblLogin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblLogin.AutoSize = true;
            this.lblLogin.BackColor = System.Drawing.Color.Transparent;
            this.lblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.Location = new System.Drawing.Point(203, 0);
            this.lblLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(464, 48);
            this.lblLogin.TabIndex = 6;
            this.lblLogin.Text = "Login To Your Account";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(280, 372);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(309, 25);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Forgot your password? Click here!";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.26829F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.7317F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblUsername, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblPassword, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 135);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.43956F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.56044F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(862, 135);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.txtUsername, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(256, 5);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(602, 71);
            this.tableLayoutPanel5.TabIndex = 8;
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.ForeColor = System.Drawing.Color.DarkGray;
            this.txtUsername.Location = new System.Drawing.Point(4, 5);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(589, 35);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtUsername_MouseClick);
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 91.37931F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.620689F));
            this.tableLayoutPanel3.Controls.Add(this.txtPassword, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.pictureBox1, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(256, 86);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(602, 44);
            this.tableLayoutPanel3.TabIndex = 8;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.DarkGray;
            this.txtPassword.Location = new System.Drawing.Point(4, 5);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(536, 35);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPassword_MouseClick);
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TheByteClubPOS.Properties.Resources.ShowEye;
            this.pictureBox1.Location = new System.Drawing.Point(554, 5);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(4, 0);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(166, 66);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Username/ Email:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(4, 81);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(151, 33);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password:";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.39161F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.60839F));
            this.tableLayoutPanel4.Controls.Add(this.btnLogin, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnClear, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(4, 402);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(862, 124);
            this.tableLayoutPanel4.TabIndex = 8;
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogin.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(94, 57);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(405, 62);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(507, 57);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(228, 62);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnTheme
            // 
            this.btnTheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTheme.Location = new System.Drawing.Point(1546, 572);
            this.btnTheme.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTheme.Name = "btnTheme";
            this.btnTheme.Size = new System.Drawing.Size(282, 62);
            this.btnTheme.TabIndex = 8;
            this.btnTheme.Text = "Change to Dark Mode";
            this.btnTheme.UseVisualStyleBackColor = true;
            this.btnTheme.Click += new System.EventHandler(this.btnTheme_Click);
            // 
            // dsSamsLiqourShop
            // 
            this.dsSamsLiqourShop.DataSetName = "dsSamsLiqourShop";
            this.dsSamsLiqourShop.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // employeeBindingSource
            // 
            this.employeeBindingSource.DataMember = "Employee";
            this.employeeBindingSource.DataSource = this.dsSamsLiqourShop;
            // 
            // employeeTableAdapter
            // 
            this.employeeTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CategoryTableAdapter = null;
            this.tableAdapterManager.CustomerTableAdapter = null;
            this.tableAdapterManager.DiscountTableAdapter = null;
            this.tableAdapterManager.EmployeeTableAdapter = this.employeeTableAdapter;
            this.tableAdapterManager.PaymentMethodTableAdapter = null;
            this.tableAdapterManager.PaymentTableAdapter = null;
            this.tableAdapterManager.ProductTableAdapter = null;
            this.tableAdapterManager.PurchaseOrderLineTableAdapter = null;
            this.tableAdapterManager.PurchaseOrderTableAdapter = null;
            this.tableAdapterManager.SaleLineTableAdapter = null;
            this.tableAdapterManager.SaleTableAdapter = null;
            this.tableAdapterManager.SaleTypeTableAdapter = null;
            this.tableAdapterManager.SupplierTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = TheByteClubPOS.dsSamsLiqourShopTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1546, 845);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(282, 62);
            this.button1.TabIndex = 9;
            this.button1.Text = "Login as Admin";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TheByteClubPOS.Properties.Resources.Untitled_design__1_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnTheme);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnTestLoginManager);
            this.Controls.Add(this.btnTestLoginCashier);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sam\'s Liquor Shop - Point of Sale System";
            this.Activated += new System.EventHandler(this.LoginForm_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginForm_FormClosed);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.Shown += new System.EventHandler(this.LoginForm_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsSamsLiqourShop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private dsSamsLiqourShop dsSamsLiqourShop;
        private System.Windows.Forms.BindingSource employeeBindingSource;
        private dsSamsLiqourShopTableAdapters.EmployeeTableAdapter employeeTableAdapter;
        private dsSamsLiqourShopTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Button btnTestLoginCashier;
        private System.Windows.Forms.Button btnTestLoginManager;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnTheme;
        private System.Windows.Forms.Button button1;
    }
}