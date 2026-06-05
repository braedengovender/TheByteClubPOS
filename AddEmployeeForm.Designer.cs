namespace TheByteClubPOS
{
    partial class AddEmployeeForm
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
            System.Windows.Forms.Label employee_FirstNameLabel;
            System.Windows.Forms.Label employee_StatusLabel;
            System.Windows.Forms.Label employee_PasswordLabel;
            System.Windows.Forms.Label employee_UsernameLabel;
            System.Windows.Forms.Label employee_HireDateLabel;
            System.Windows.Forms.Label employee_PhoneNumberLabel;
            System.Windows.Forms.Label employee_EmailAddressLabel;
            System.Windows.Forms.Label employee_RoleLabel;
            System.Windows.Forms.Label employee_IDNumberLabel;
            System.Windows.Forms.Label employee_LastNameLabel;
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.employee_FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.employee_PasswordTextBox = new System.Windows.Forms.TextBox();
            this.employee_UsernameTextBox = new System.Windows.Forms.TextBox();
            this.employee_HireDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.employee_PhoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.employee_IDNumberTextBox = new System.Windows.Forms.TextBox();
            this.employee_LastNameTextBox = new System.Windows.Forms.TextBox();
            this.employee_EmailAddressTextBox = new System.Windows.Forms.TextBox();
            this.employee_StatusComboBox = new System.Windows.Forms.ComboBox();
            this.employee_RoleComboBox = new System.Windows.Forms.ComboBox();
            employee_FirstNameLabel = new System.Windows.Forms.Label();
            employee_StatusLabel = new System.Windows.Forms.Label();
            employee_PasswordLabel = new System.Windows.Forms.Label();
            employee_UsernameLabel = new System.Windows.Forms.Label();
            employee_HireDateLabel = new System.Windows.Forms.Label();
            employee_PhoneNumberLabel = new System.Windows.Forms.Label();
            employee_EmailAddressLabel = new System.Windows.Forms.Label();
            employee_RoleLabel = new System.Windows.Forms.Label();
            employee_IDNumberLabel = new System.Windows.Forms.Label();
            employee_LastNameLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(683, 696);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 53);
            this.btnCancel.TabIndex = 38;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(346, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(183, 29);
            this.lblTitle.TabIndex = 37;
            this.lblTitle.Text = "Add Employee";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(312, 696);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(232, 53);
            this.btnUpdate.TabIndex = 36;
            this.btnUpdate.Text = "SAVE";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.77676F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.22324F));
            this.tableLayoutPanel1.Controls.Add(employee_FirstNameLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.employee_FirstNameTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(employee_StatusLabel, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.employee_PasswordTextBox, 1, 9);
            this.tableLayoutPanel1.Controls.Add(employee_PasswordLabel, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.employee_UsernameTextBox, 1, 8);
            this.tableLayoutPanel1.Controls.Add(employee_UsernameLabel, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.employee_HireDateDateTimePicker, 1, 7);
            this.tableLayoutPanel1.Controls.Add(employee_HireDateLabel, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.employee_PhoneNumberTextBox, 1, 6);
            this.tableLayoutPanel1.Controls.Add(employee_PhoneNumberLabel, 0, 6);
            this.tableLayoutPanel1.Controls.Add(employee_EmailAddressLabel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(employee_RoleLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.employee_IDNumberTextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(employee_IDNumberLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.employee_LastNameTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(employee_LastNameLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.employee_EmailAddressTextBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.employee_StatusComboBox, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.employee_RoleComboBox, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(119, 97);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.017544F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.98245F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(654, 585);
            this.tableLayoutPanel1.TabIndex = 35;
            // 
            // employee_FirstNameLabel
            // 
            employee_FirstNameLabel.AutoSize = true;
            employee_FirstNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            employee_FirstNameLabel.Location = new System.Drawing.Point(4, 4);
            employee_FirstNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            employee_FirstNameLabel.Name = "employee_FirstNameLabel";
            employee_FirstNameLabel.Size = new System.Drawing.Size(137, 29);
            employee_FirstNameLabel.TabIndex = 3;
            employee_FirstNameLabel.Text = "First Name:";
            // 
            // employee_FirstNameTextBox
            // 
            this.employee_FirstNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employee_FirstNameTextBox.Location = new System.Drawing.Point(323, 9);
            this.employee_FirstNameTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.employee_FirstNameTextBox.Name = "employee_FirstNameTextBox";
            this.employee_FirstNameTextBox.Size = new System.Drawing.Size(298, 35);
            this.employee_FirstNameTextBox.TabIndex = 4;
            // 
            // employee_StatusLabel
            // 
            employee_StatusLabel.AutoSize = true;
            employee_StatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            employee_StatusLabel.Location = new System.Drawing.Point(4, 538);
            employee_StatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            employee_StatusLabel.Name = "employee_StatusLabel";
            employee_StatusLabel.Size = new System.Drawing.Size(85, 29);
            employee_StatusLabel.TabIndex = 21;
            employee_StatusLabel.Text = "Status:";
            // 
            // employee_PasswordTextBox
            // 
            this.employee_PasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employee_PasswordTextBox.Location = new System.Drawing.Point(323, 485);
            this.employee_PasswordTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.employee_PasswordTextBox.Name = "employee_PasswordTextBox";
            this.employee_PasswordTextBox.Size = new System.Drawing.Size(298, 35);
            this.employee_PasswordTextBox.TabIndex = 20;
            this.employee_PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // employee_PasswordLabel
            // 
            employee_PasswordLabel.AutoSize = true;
            employee_PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            employee_PasswordLabel.Location = new System.Drawing.Point(4, 480);
            employee_PasswordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            employee_PasswordLabel.Name = "employee_PasswordLabel";
            employee_PasswordLabel.Size = new System.Drawing.Size(126, 29);
            employee_PasswordLabel.TabIndex = 19;
            employee_PasswordLabel.Text = "Password:";
            // 
            // employee_UsernameTextBox
            // 
            this.employee_UsernameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employee_UsernameTextBox.Location = new System.Drawing.Point(323, 429);
            this.employee_UsernameTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.employee_UsernameTextBox.Name = "employee_UsernameTextBox";
            this.employee_UsernameTextBox.Size = new System.Drawing.Size(298, 35);
            this.employee_UsernameTextBox.TabIndex = 18;
            // 
            // employee_UsernameLabel
            // 
            employee_UsernameLabel.AutoSize = true;
            employee_UsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            employee_UsernameLabel.Location = new System.Drawing.Point(4, 424);
            employee_UsernameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            employee_UsernameLabel.Name = "employee_UsernameLabel";
            employee_UsernameLabel.Size = new System.Drawing.Size(130, 29);
            employee_UsernameLabel.TabIndex = 17;
            employee_UsernameLabel.Text = "Username:";
            // 
            // employee_HireDateDateTimePicker
            // 
            this.employee_HireDateDateTimePicker.Enabled = false;
            this.employee_HireDateDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employee_HireDateDateTimePicker.Location = new System.Drawing.Point(323, 372);
            this.employee_HireDateDateTimePicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.employee_HireDateDateTimePicker.Name = "employee_HireDateDateTimePicker";
            this.employee_HireDateDateTimePicker.Size = new System.Drawing.Size(298, 35);
            this.employee_HireDateDateTimePicker.TabIndex = 16;
            // 
            // employee_HireDateLabel
            // 
            employee_HireDateLabel.AutoSize = true;
            employee_HireDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            employee_HireDateLabel.Location = new System.Drawing.Point(4, 367);
            employee_HireDateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            employee_HireDateLabel.Name = "employee_HireDateLabel";
            employee_HireDateLabel.Size = new System.Drawing.Size(120, 29);
            employee_HireDateLabel.TabIndex = 15;
            employee_HireDateLabel.Text = "Hire Date:";
            // 
            // employee_PhoneNumberTextBox
            // 
            this.employee_PhoneNumberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employee_PhoneNumberTextBox.Location = new System.Drawing.Point(323, 316);
            this.employee_PhoneNumberTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.employee_PhoneNumberTextBox.Name = "employee_PhoneNumberTextBox";
            this.employee_PhoneNumberTextBox.Size = new System.Drawing.Size(298, 35);
            this.employee_PhoneNumberTextBox.TabIndex = 14;
            // 
            // employee_PhoneNumberLabel
            // 
            employee_PhoneNumberLabel.AutoSize = true;
            employee_PhoneNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            employee_PhoneNumberLabel.Location = new System.Drawing.Point(4, 311);
            employee_PhoneNumberLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            employee_PhoneNumberLabel.Name = "employee_PhoneNumberLabel";
            employee_PhoneNumberLabel.Size = new System.Drawing.Size(182, 29);
            employee_PhoneNumberLabel.TabIndex = 13;
            employee_PhoneNumberLabel.Text = "Phone Number:";
            // 
            // employee_EmailAddressLabel
            // 
            employee_EmailAddressLabel.AutoSize = true;
            employee_EmailAddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            employee_EmailAddressLabel.Location = new System.Drawing.Point(4, 255);
            employee_EmailAddressLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            employee_EmailAddressLabel.Name = "employee_EmailAddressLabel";
            employee_EmailAddressLabel.Size = new System.Drawing.Size(175, 29);
            employee_EmailAddressLabel.TabIndex = 11;
            employee_EmailAddressLabel.Text = "Email Address:";
            // 
            // employee_RoleLabel
            // 
            employee_RoleLabel.AutoSize = true;
            employee_RoleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            employee_RoleLabel.Location = new System.Drawing.Point(4, 204);
            employee_RoleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            employee_RoleLabel.Name = "employee_RoleLabel";
            employee_RoleLabel.Size = new System.Drawing.Size(70, 29);
            employee_RoleLabel.TabIndex = 9;
            employee_RoleLabel.Text = "Role:";
            // 
            // employee_IDNumberTextBox
            // 
            this.employee_IDNumberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employee_IDNumberTextBox.Location = new System.Drawing.Point(323, 140);
            this.employee_IDNumberTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.employee_IDNumberTextBox.Name = "employee_IDNumberTextBox";
            this.employee_IDNumberTextBox.Size = new System.Drawing.Size(298, 35);
            this.employee_IDNumberTextBox.TabIndex = 8;
            // 
            // employee_IDNumberLabel
            // 
            employee_IDNumberLabel.AutoSize = true;
            employee_IDNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            employee_IDNumberLabel.Location = new System.Drawing.Point(4, 135);
            employee_IDNumberLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            employee_IDNumberLabel.Name = "employee_IDNumberLabel";
            employee_IDNumberLabel.Size = new System.Drawing.Size(135, 29);
            employee_IDNumberLabel.TabIndex = 7;
            employee_IDNumberLabel.Text = "ID Number:";
            // 
            // employee_LastNameTextBox
            // 
            this.employee_LastNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employee_LastNameTextBox.Location = new System.Drawing.Point(323, 74);
            this.employee_LastNameTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.employee_LastNameTextBox.Name = "employee_LastNameTextBox";
            this.employee_LastNameTextBox.Size = new System.Drawing.Size(298, 35);
            this.employee_LastNameTextBox.TabIndex = 6;
            // 
            // employee_LastNameLabel
            // 
            employee_LastNameLabel.AutoSize = true;
            employee_LastNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            employee_LastNameLabel.Location = new System.Drawing.Point(4, 69);
            employee_LastNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            employee_LastNameLabel.Name = "employee_LastNameLabel";
            employee_LastNameLabel.Size = new System.Drawing.Size(134, 29);
            employee_LastNameLabel.TabIndex = 5;
            employee_LastNameLabel.Text = "Last Name:";
            // 
            // employee_EmailAddressTextBox
            // 
            this.employee_EmailAddressTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employee_EmailAddressTextBox.Location = new System.Drawing.Point(323, 260);
            this.employee_EmailAddressTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.employee_EmailAddressTextBox.Name = "employee_EmailAddressTextBox";
            this.employee_EmailAddressTextBox.Size = new System.Drawing.Size(298, 35);
            this.employee_EmailAddressTextBox.TabIndex = 12;
            // 
            // employee_StatusComboBox
            // 
            this.employee_StatusComboBox.FormattingEnabled = true;
            this.employee_StatusComboBox.Location = new System.Drawing.Point(322, 541);
            this.employee_StatusComboBox.Name = "employee_StatusComboBox";
            this.employee_StatusComboBox.Size = new System.Drawing.Size(299, 28);
            this.employee_StatusComboBox.TabIndex = 24;
            // 
            // employee_RoleComboBox
            // 
            this.employee_RoleComboBox.FormattingEnabled = true;
            this.employee_RoleComboBox.Location = new System.Drawing.Point(322, 207);
            this.employee_RoleComboBox.Name = "employee_RoleComboBox";
            this.employee_RoleComboBox.Size = new System.Drawing.Size(299, 28);
            this.employee_RoleComboBox.TabIndex = 23;
            // 
            // AddEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 768);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AddEmployeeForm";
            this.Text = "AddEmployeeForm";
            this.Load += new System.EventHandler(this.AddEmployeeForm_Load);
            this.Click += new System.EventHandler(this.AddEmployeeForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox employee_FirstNameTextBox;
        private System.Windows.Forms.TextBox employee_PasswordTextBox;
        private System.Windows.Forms.TextBox employee_UsernameTextBox;
        private System.Windows.Forms.DateTimePicker employee_HireDateDateTimePicker;
        private System.Windows.Forms.TextBox employee_PhoneNumberTextBox;
        private System.Windows.Forms.TextBox employee_IDNumberTextBox;
        private System.Windows.Forms.TextBox employee_LastNameTextBox;
        private System.Windows.Forms.TextBox employee_EmailAddressTextBox;
        private System.Windows.Forms.ComboBox employee_StatusComboBox;
        private System.Windows.Forms.ComboBox employee_RoleComboBox;
    }
}