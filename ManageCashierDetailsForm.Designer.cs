namespace TheByteClubPOS
{
    partial class ManageCashierDetailsForm
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
            System.Windows.Forms.Label employee_IDLabel;
            System.Windows.Forms.Label employee_FirstNameLabel;
            System.Windows.Forms.Label employee_LastNameLabel;
            System.Windows.Forms.Label employee_IDNumberLabel;
            System.Windows.Forms.Label employee_RoleLabel;
            System.Windows.Forms.Label employee_EmailAddressLabel;
            System.Windows.Forms.Label employee_PhoneNumberLabel;
            System.Windows.Forms.Label employee_HireDateLabel;
            System.Windows.Forms.Label employee_UsernameLabel;
            System.Windows.Forms.Label employee_PasswordLabel;
            System.Windows.Forms.Label employee_StatusLabel;
            this.dsSamsLiqourShop = new TheByteClubPOS.dsSamsLiqourShop();
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.employeeTableAdapter = new TheByteClubPOS.dsSamsLiqourShopTableAdapters.EmployeeTableAdapter();
            this.tableAdapterManager = new TheByteClubPOS.dsSamsLiqourShopTableAdapters.TableAdapterManager();
            this.employee_IDTextBox = new System.Windows.Forms.TextBox();
            this.employee_FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.employee_LastNameTextBox = new System.Windows.Forms.TextBox();
            this.employee_IDNumberTextBox = new System.Windows.Forms.TextBox();
            this.employee_RoleTextBox = new System.Windows.Forms.TextBox();
            this.employee_EmailAddressTextBox = new System.Windows.Forms.TextBox();
            this.employee_PhoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.employee_HireDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.employee_UsernameTextBox = new System.Windows.Forms.TextBox();
            this.employee_PasswordTextBox = new System.Windows.Forms.TextBox();
            this.employee_StatusTextBox = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblSystemName = new System.Windows.Forms.Label();
            this.btnShow = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            employee_IDLabel = new System.Windows.Forms.Label();
            employee_FirstNameLabel = new System.Windows.Forms.Label();
            employee_LastNameLabel = new System.Windows.Forms.Label();
            employee_IDNumberLabel = new System.Windows.Forms.Label();
            employee_RoleLabel = new System.Windows.Forms.Label();
            employee_EmailAddressLabel = new System.Windows.Forms.Label();
            employee_PhoneNumberLabel = new System.Windows.Forms.Label();
            employee_HireDateLabel = new System.Windows.Forms.Label();
            employee_UsernameLabel = new System.Windows.Forms.Label();
            employee_PasswordLabel = new System.Windows.Forms.Label();
            employee_StatusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dsSamsLiqourShop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // employee_IDLabel
            // 
            employee_IDLabel.AutoSize = true;
            employee_IDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            employee_IDLabel.Location = new System.Drawing.Point(3, 0);
            employee_IDLabel.Name = "employee_IDLabel";
            employee_IDLabel.Size = new System.Drawing.Size(104, 20);
            employee_IDLabel.TabIndex = 1;
            employee_IDLabel.Text = "Employee ID:";
            // 
            // employee_FirstNameLabel
            // 
            employee_FirstNameLabel.AutoSize = true;
            employee_FirstNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            employee_FirstNameLabel.Location = new System.Drawing.Point(3, 41);
            employee_FirstNameLabel.Name = "employee_FirstNameLabel";
            employee_FirstNameLabel.Size = new System.Drawing.Size(90, 20);
            employee_FirstNameLabel.TabIndex = 3;
            employee_FirstNameLabel.Text = "First Name:";
            // 
            // employee_LastNameLabel
            // 
            employee_LastNameLabel.AutoSize = true;
            employee_LastNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            employee_LastNameLabel.Location = new System.Drawing.Point(3, 76);
            employee_LastNameLabel.Name = "employee_LastNameLabel";
            employee_LastNameLabel.Size = new System.Drawing.Size(90, 20);
            employee_LastNameLabel.TabIndex = 5;
            employee_LastNameLabel.Text = "Last Name:";
            // 
            // employee_IDNumberLabel
            // 
            employee_IDNumberLabel.AutoSize = true;
            employee_IDNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            employee_IDNumberLabel.Location = new System.Drawing.Point(3, 112);
            employee_IDNumberLabel.Name = "employee_IDNumberLabel";
            employee_IDNumberLabel.Size = new System.Drawing.Size(90, 20);
            employee_IDNumberLabel.TabIndex = 7;
            employee_IDNumberLabel.Text = "ID Number:";
            // 
            // employee_RoleLabel
            // 
            employee_RoleLabel.AutoSize = true;
            employee_RoleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            employee_RoleLabel.Location = new System.Drawing.Point(3, 146);
            employee_RoleLabel.Name = "employee_RoleLabel";
            employee_RoleLabel.Size = new System.Drawing.Size(46, 20);
            employee_RoleLabel.TabIndex = 9;
            employee_RoleLabel.Text = "Role:";
            // 
            // employee_EmailAddressLabel
            // 
            employee_EmailAddressLabel.AutoSize = true;
            employee_EmailAddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            employee_EmailAddressLabel.Location = new System.Drawing.Point(3, 180);
            employee_EmailAddressLabel.Name = "employee_EmailAddressLabel";
            employee_EmailAddressLabel.Size = new System.Drawing.Size(115, 20);
            employee_EmailAddressLabel.TabIndex = 11;
            employee_EmailAddressLabel.Text = "Email Address:";
            // 
            // employee_PhoneNumberLabel
            // 
            employee_PhoneNumberLabel.AutoSize = true;
            employee_PhoneNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            employee_PhoneNumberLabel.Location = new System.Drawing.Point(3, 213);
            employee_PhoneNumberLabel.Name = "employee_PhoneNumberLabel";
            employee_PhoneNumberLabel.Size = new System.Drawing.Size(119, 20);
            employee_PhoneNumberLabel.TabIndex = 13;
            employee_PhoneNumberLabel.Text = "Phone Number:";
            // 
            // employee_HireDateLabel
            // 
            employee_HireDateLabel.AutoSize = true;
            employee_HireDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            employee_HireDateLabel.Location = new System.Drawing.Point(3, 247);
            employee_HireDateLabel.Name = "employee_HireDateLabel";
            employee_HireDateLabel.Size = new System.Drawing.Size(81, 20);
            employee_HireDateLabel.TabIndex = 15;
            employee_HireDateLabel.Text = "Hire Date:";
            // 
            // employee_UsernameLabel
            // 
            employee_UsernameLabel.AutoSize = true;
            employee_UsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            employee_UsernameLabel.Location = new System.Drawing.Point(3, 281);
            employee_UsernameLabel.Name = "employee_UsernameLabel";
            employee_UsernameLabel.Size = new System.Drawing.Size(87, 20);
            employee_UsernameLabel.TabIndex = 17;
            employee_UsernameLabel.Text = "Username:";
            // 
            // employee_PasswordLabel
            // 
            employee_PasswordLabel.AutoSize = true;
            employee_PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            employee_PasswordLabel.Location = new System.Drawing.Point(3, 315);
            employee_PasswordLabel.Name = "employee_PasswordLabel";
            employee_PasswordLabel.Size = new System.Drawing.Size(82, 20);
            employee_PasswordLabel.TabIndex = 19;
            employee_PasswordLabel.Text = "Password:";
            // 
            // employee_StatusLabel
            // 
            employee_StatusLabel.AutoSize = true;
            employee_StatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            employee_StatusLabel.Location = new System.Drawing.Point(3, 349);
            employee_StatusLabel.Name = "employee_StatusLabel";
            employee_StatusLabel.Size = new System.Drawing.Size(60, 20);
            employee_StatusLabel.TabIndex = 21;
            employee_StatusLabel.Text = "Status:";
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
            // employee_IDTextBox
            // 
            this.employee_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource, "Employee_ID", true));
            this.employee_IDTextBox.Enabled = false;
            this.employee_IDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employee_IDTextBox.Location = new System.Drawing.Point(221, 3);
            this.employee_IDTextBox.Name = "employee_IDTextBox";
            this.employee_IDTextBox.Size = new System.Drawing.Size(200, 26);
            this.employee_IDTextBox.TabIndex = 2;
            // 
            // employee_FirstNameTextBox
            // 
            this.employee_FirstNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource, "Employee_FirstName", true));
            this.employee_FirstNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employee_FirstNameTextBox.Location = new System.Drawing.Point(221, 44);
            this.employee_FirstNameTextBox.Name = "employee_FirstNameTextBox";
            this.employee_FirstNameTextBox.Size = new System.Drawing.Size(200, 26);
            this.employee_FirstNameTextBox.TabIndex = 4;
            // 
            // employee_LastNameTextBox
            // 
            this.employee_LastNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource, "Employee_LastName", true));
            this.employee_LastNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employee_LastNameTextBox.Location = new System.Drawing.Point(221, 79);
            this.employee_LastNameTextBox.Name = "employee_LastNameTextBox";
            this.employee_LastNameTextBox.Size = new System.Drawing.Size(200, 26);
            this.employee_LastNameTextBox.TabIndex = 6;
            // 
            // employee_IDNumberTextBox
            // 
            this.employee_IDNumberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource, "Employee_IDNumber", true));
            this.employee_IDNumberTextBox.Enabled = false;
            this.employee_IDNumberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employee_IDNumberTextBox.Location = new System.Drawing.Point(221, 115);
            this.employee_IDNumberTextBox.Name = "employee_IDNumberTextBox";
            this.employee_IDNumberTextBox.Size = new System.Drawing.Size(200, 26);
            this.employee_IDNumberTextBox.TabIndex = 8;
            // 
            // employee_RoleTextBox
            // 
            this.employee_RoleTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource, "Employee_Role", true));
            this.employee_RoleTextBox.Enabled = false;
            this.employee_RoleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employee_RoleTextBox.Location = new System.Drawing.Point(221, 149);
            this.employee_RoleTextBox.Name = "employee_RoleTextBox";
            this.employee_RoleTextBox.Size = new System.Drawing.Size(200, 26);
            this.employee_RoleTextBox.TabIndex = 10;
            // 
            // employee_EmailAddressTextBox
            // 
            this.employee_EmailAddressTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource, "Employee_EmailAddress", true));
            this.employee_EmailAddressTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employee_EmailAddressTextBox.Location = new System.Drawing.Point(221, 183);
            this.employee_EmailAddressTextBox.Name = "employee_EmailAddressTextBox";
            this.employee_EmailAddressTextBox.Size = new System.Drawing.Size(200, 26);
            this.employee_EmailAddressTextBox.TabIndex = 12;
            // 
            // employee_PhoneNumberTextBox
            // 
            this.employee_PhoneNumberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource, "Employee_PhoneNumber", true));
            this.employee_PhoneNumberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employee_PhoneNumberTextBox.Location = new System.Drawing.Point(221, 216);
            this.employee_PhoneNumberTextBox.Name = "employee_PhoneNumberTextBox";
            this.employee_PhoneNumberTextBox.Size = new System.Drawing.Size(200, 26);
            this.employee_PhoneNumberTextBox.TabIndex = 14;
            // 
            // employee_HireDateDateTimePicker
            // 
            this.employee_HireDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.employeeBindingSource, "Employee_HireDate", true));
            this.employee_HireDateDateTimePicker.Enabled = false;
            this.employee_HireDateDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employee_HireDateDateTimePicker.Location = new System.Drawing.Point(221, 250);
            this.employee_HireDateDateTimePicker.Name = "employee_HireDateDateTimePicker";
            this.employee_HireDateDateTimePicker.Size = new System.Drawing.Size(200, 26);
            this.employee_HireDateDateTimePicker.TabIndex = 16;
            // 
            // employee_UsernameTextBox
            // 
            this.employee_UsernameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource, "Employee_Username", true));
            this.employee_UsernameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employee_UsernameTextBox.Location = new System.Drawing.Point(221, 284);
            this.employee_UsernameTextBox.Name = "employee_UsernameTextBox";
            this.employee_UsernameTextBox.Size = new System.Drawing.Size(200, 26);
            this.employee_UsernameTextBox.TabIndex = 18;
            // 
            // employee_PasswordTextBox
            // 
            this.employee_PasswordTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource, "Employee_Password", true));
            this.employee_PasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employee_PasswordTextBox.Location = new System.Drawing.Point(221, 318);
            this.employee_PasswordTextBox.Name = "employee_PasswordTextBox";
            this.employee_PasswordTextBox.Size = new System.Drawing.Size(200, 26);
            this.employee_PasswordTextBox.TabIndex = 20;
            this.employee_PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // employee_StatusTextBox
            // 
            this.employee_StatusTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource, "Employee_Status", true));
            this.employee_StatusTextBox.Enabled = false;
            this.employee_StatusTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employee_StatusTextBox.Location = new System.Drawing.Point(221, 352);
            this.employee_StatusTextBox.Name = "employee_StatusTextBox";
            this.employee_StatusTextBox.Size = new System.Drawing.Size(200, 26);
            this.employee_StatusTextBox.TabIndex = 22;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(549, 577);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(270, 40);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblSystemName
            // 
            this.lblSystemName.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblSystemName.AutoSize = true;
            this.lblSystemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemName.Location = new System.Drawing.Point(543, 99);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(281, 33);
            this.lblSystemName.TabIndex = 24;
            this.lblSystemName.Text = "Manage My Details";
            // 
            // btnShow
            // 
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(923, 462);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(152, 40);
            this.btnShow.TabIndex = 25;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(employee_IDLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.employee_IDTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(employee_FirstNameLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.employee_FirstNameTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(employee_StatusLabel, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.employee_PasswordTextBox, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.employee_StatusTextBox, 1, 10);
            this.tableLayoutPanel1.Controls.Add(employee_PasswordLabel, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.employee_UsernameTextBox, 1, 8);
            this.tableLayoutPanel1.Controls.Add(employee_UsernameLabel, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.employee_HireDateDateTimePicker, 1, 7);
            this.tableLayoutPanel1.Controls.Add(employee_HireDateLabel, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.employee_PhoneNumberTextBox, 1, 6);
            this.tableLayoutPanel1.Controls.Add(employee_PhoneNumberLabel, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.employee_EmailAddressTextBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(employee_EmailAddressLabel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.employee_RoleTextBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(employee_RoleLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.employee_IDNumberTextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(employee_IDNumberLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.employee_LastNameTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(employee_LastNameLabel, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(466, 167);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.62319F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.37681F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(436, 384);
            this.tableLayoutPanel1.TabIndex = 26;
            // 
            // ManageCashierDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 686);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.lblSystemName);
            this.Controls.Add(this.btnSave);
            this.Name = "ManageCashierDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ManageCashierDetailsForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ManageCashierDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsSamsLiqourShop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private dsSamsLiqourShop dsSamsLiqourShop;
        private System.Windows.Forms.BindingSource employeeBindingSource;
        private dsSamsLiqourShopTableAdapters.EmployeeTableAdapter employeeTableAdapter;
        private dsSamsLiqourShopTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox employee_IDTextBox;
        private System.Windows.Forms.TextBox employee_FirstNameTextBox;
        private System.Windows.Forms.TextBox employee_LastNameTextBox;
        private System.Windows.Forms.TextBox employee_IDNumberTextBox;
        private System.Windows.Forms.TextBox employee_RoleTextBox;
        private System.Windows.Forms.TextBox employee_EmailAddressTextBox;
        private System.Windows.Forms.TextBox employee_PhoneNumberTextBox;
        private System.Windows.Forms.DateTimePicker employee_HireDateDateTimePicker;
        private System.Windows.Forms.TextBox employee_UsernameTextBox;
        private System.Windows.Forms.TextBox employee_PasswordTextBox;
        private System.Windows.Forms.TextBox employee_StatusTextBox;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblSystemName;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}