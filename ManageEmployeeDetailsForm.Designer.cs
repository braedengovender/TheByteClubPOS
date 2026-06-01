namespace TheByteClubPOS
{
    partial class ManageEmployeeDetailsForm
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
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.employeeHireDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeUsernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeePasswordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsSamsLiqourShopBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsSamsLiqourShop = new TheByteClubPOS.dsSamsLiqourShop();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.employeeTableAdapter = new TheByteClubPOS.dsSamsLiqourShopTableAdapters.EmployeeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSamsLiqourShopBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSamsLiqourShop)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.AutoGenerateColumns = false;
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.employeeHireDateDataGridViewTextBoxColumn,
            this.employeeUsernameDataGridViewTextBoxColumn,
            this.employeePasswordDataGridViewTextBoxColumn,
            this.employeeStatusDataGridViewTextBoxColumn});
            this.dgvEmployees.DataSource = this.employeeBindingSource;
            this.dgvEmployees.Location = new System.Drawing.Point(8, 44);
            this.dgvEmployees.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.RowHeadersWidth = 62;
            this.dgvEmployees.RowTemplate.Height = 28;
            this.dgvEmployees.Size = new System.Drawing.Size(1097, 194);
            this.dgvEmployees.TabIndex = 0;
            // 
            // employeeHireDateDataGridViewTextBoxColumn
            // 
            this.employeeHireDateDataGridViewTextBoxColumn.DataPropertyName = "Employee_HireDate";
            this.employeeHireDateDataGridViewTextBoxColumn.HeaderText = "Employee_HireDate";
            this.employeeHireDateDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.employeeHireDateDataGridViewTextBoxColumn.Name = "employeeHireDateDataGridViewTextBoxColumn";
            this.employeeHireDateDataGridViewTextBoxColumn.Width = 150;
            // 
            // employeeUsernameDataGridViewTextBoxColumn
            // 
            this.employeeUsernameDataGridViewTextBoxColumn.DataPropertyName = "Employee_Username";
            this.employeeUsernameDataGridViewTextBoxColumn.HeaderText = "Employee_Username";
            this.employeeUsernameDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.employeeUsernameDataGridViewTextBoxColumn.Name = "employeeUsernameDataGridViewTextBoxColumn";
            this.employeeUsernameDataGridViewTextBoxColumn.Width = 150;
            // 
            // employeePasswordDataGridViewTextBoxColumn
            // 
            this.employeePasswordDataGridViewTextBoxColumn.DataPropertyName = "Employee_Password";
            this.employeePasswordDataGridViewTextBoxColumn.HeaderText = "Employee_Password";
            this.employeePasswordDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.employeePasswordDataGridViewTextBoxColumn.Name = "employeePasswordDataGridViewTextBoxColumn";
            this.employeePasswordDataGridViewTextBoxColumn.Width = 150;
            // 
            // employeeStatusDataGridViewTextBoxColumn
            // 
            this.employeeStatusDataGridViewTextBoxColumn.DataPropertyName = "Employee_Status";
            this.employeeStatusDataGridViewTextBoxColumn.HeaderText = "Employee_Status";
            this.employeeStatusDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.employeeStatusDataGridViewTextBoxColumn.Name = "employeeStatusDataGridViewTextBoxColumn";
            this.employeeStatusDataGridViewTextBoxColumn.Width = 150;
            // 
            // employeeBindingSource
            // 
            this.employeeBindingSource.DataMember = "Employee";
            this.employeeBindingSource.DataSource = this.dsSamsLiqourShopBindingSource;
            // 
            // dsSamsLiqourShopBindingSource
            // 
            this.dsSamsLiqourShopBindingSource.DataSource = this.dsSamsLiqourShop;
            this.dsSamsLiqourShopBindingSource.Position = 0;
            // 
            // dsSamsLiqourShop
            // 
            this.dsSamsLiqourShop.DataSetName = "dsSamsLiqourShop";
            this.dsSamsLiqourShop.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(77, 268);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 44);
            this.button1.TabIndex = 1;
            this.button1.Text = "Edit Details";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(77, 337);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 44);
            this.button2.TabIndex = 2;
            this.button2.Text = "Add Employee";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(77, 398);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(107, 44);
            this.button3.TabIndex = 3;
            this.button3.Text = "Remove Employee";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(701, 398);
            this.button4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(107, 44);
            this.button4.TabIndex = 4;
            this.button4.Text = "Reset Filter";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton6);
            this.groupBox2.Controls.Add(this.radioButton5);
            this.groupBox2.Controls.Add(this.radioButton4);
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Location = new System.Drawing.Point(466, 268);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(183, 174);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sort by:";
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(23, 147);
            this.radioButton6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(36, 17);
            this.radioButton6.TabIndex = 4;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "ID";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(23, 110);
            this.radioButton5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(73, 17);
            this.radioButton5.TabIndex = 3;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Username";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(23, 68);
            this.radioButton4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(67, 17);
            this.radioButton4.TabIndex = 2;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Surname";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(23, 29);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(53, 17);
            this.radioButton3.TabIndex = 1;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Name";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton8);
            this.groupBox3.Controls.Add(this.radioButton7);
            this.groupBox3.Location = new System.Drawing.Point(669, 268);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(171, 119);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Order by:";
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(25, 75);
            this.radioButton8.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(82, 17);
            this.radioButton8.TabIndex = 2;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "Descending";
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(25, 29);
            this.radioButton7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(75, 17);
            this.radioButton7.TabIndex = 1;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "Ascending";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(243, 278);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Search:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(290, 276);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(154, 20);
            this.textBox1.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(246, 326);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(197, 116);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter by:";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(31, 77);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(60, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Cashier";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(31, 32);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(67, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Manager";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 21);
            this.label2.TabIndex = 11;
            this.label2.Text = "Employee Details:";
            // 
            // employeeTableAdapter
            // 
            this.employeeTableAdapter.ClearBeforeFill = true;
            // 
            // ManageEmployeeDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 666);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvEmployees);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ManageEmployeeDetailsForm";
            this.Text = "ManageEmployeeDetailsForm";
            this.Load += new System.EventHandler(this.ManageEmployeeDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSamsLiqourShopBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSamsLiqourShop)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource dsSamsLiqourShopBindingSource;
        private dsSamsLiqourShop dsSamsLiqourShop;
        private System.Windows.Forms.BindingSource employeeBindingSource;
        private dsSamsLiqourShopTableAdapters.EmployeeTableAdapter employeeTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeFirstNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeLastNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeIDNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeRoleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeEmailAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeePhoneNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeHireDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeUsernameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeePasswordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeStatusDataGridViewTextBoxColumn;
    }
}