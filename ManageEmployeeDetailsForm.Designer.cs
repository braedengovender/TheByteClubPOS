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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageEmployeeDetailsForm));
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsSamsLiqourShopBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsSamsLiqourShop = new TheByteClubPOS.dsSamsLiqourShop();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.rdoAdmin = new System.Windows.Forms.RadioButton();
            this.rdoCashier = new System.Windows.Forms.RadioButton();
            this.rdoManager = new System.Windows.Forms.RadioButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.grpOrderby = new System.Windows.Forms.GroupBox();
            this.rdoDesc = new System.Windows.Forms.RadioButton();
            this.rdoAsc = new System.Windows.Forms.RadioButton();
            this.grpSort = new System.Windows.Forms.GroupBox();
            this.rdoID = new System.Windows.Forms.RadioButton();
            this.rdoUsername = new System.Windows.Forms.RadioButton();
            this.rdoSurname = new System.Windows.Forms.RadioButton();
            this.rdoName = new System.Windows.Forms.RadioButton();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.Employee_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employee_FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employee_LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employee_IDNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employee_Role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employee_EmailAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employee_PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employee_HireDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employee_Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employee_Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employee_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeFirstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeLastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeIDNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeRoleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeEmailAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeePhoneNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeHireDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeUsernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeePasswordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeTableAdapter = new TheByteClubPOS.dsSamsLiqourShopTableAdapters.EmployeeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSamsLiqourShopBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSamsLiqourShop)).BeginInit();
            this.grpFilter.SuspendLayout();
            this.grpOrderby.SuspendLayout();
            this.grpSort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.SuspendLayout();
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
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Modern No. 20", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(21, 45);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(168, 21);
            this.lblTitle.TabIndex = 24;
            this.lblTitle.Text = "Employee Details:";
            // 
            // grpFilter
            // 
            this.grpFilter.BackColor = System.Drawing.Color.Transparent;
            this.grpFilter.Controls.Add(this.rdoAll);
            this.grpFilter.Controls.Add(this.rdoAdmin);
            this.grpFilter.Controls.Add(this.rdoCashier);
            this.grpFilter.Controls.Add(this.rdoManager);
            this.grpFilter.Location = new System.Drawing.Point(363, 482);
            this.grpFilter.Margin = new System.Windows.Forms.Padding(2);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Padding = new System.Windows.Forms.Padding(2);
            this.grpFilter.Size = new System.Drawing.Size(197, 129);
            this.grpFilter.TabIndex = 23;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Filter by:";
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Location = new System.Drawing.Point(31, 17);
            this.rdoAll.Margin = new System.Windows.Forms.Padding(2);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(36, 17);
            this.rdoAll.TabIndex = 3;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "All";
            this.rdoAll.UseVisualStyleBackColor = true;
            this.rdoAll.CheckedChanged += new System.EventHandler(this.rdoAll_CheckedChanged);
            this.rdoAll.Click += new System.EventHandler(this.rdoAll_CheckedChanged);
            // 
            // rdoAdmin
            // 
            this.rdoAdmin.AutoSize = true;
            this.rdoAdmin.Location = new System.Drawing.Point(31, 102);
            this.rdoAdmin.Margin = new System.Windows.Forms.Padding(2);
            this.rdoAdmin.Name = "rdoAdmin";
            this.rdoAdmin.Size = new System.Drawing.Size(54, 17);
            this.rdoAdmin.TabIndex = 2;
            this.rdoAdmin.TabStop = true;
            this.rdoAdmin.Text = "Admin";
            this.rdoAdmin.UseVisualStyleBackColor = true;
            this.rdoAdmin.Click += new System.EventHandler(this.rdoAdmin_CheckedChanged);
            // 
            // rdoCashier
            // 
            this.rdoCashier.AutoSize = true;
            this.rdoCashier.Location = new System.Drawing.Point(31, 72);
            this.rdoCashier.Margin = new System.Windows.Forms.Padding(2);
            this.rdoCashier.Name = "rdoCashier";
            this.rdoCashier.Size = new System.Drawing.Size(60, 17);
            this.rdoCashier.TabIndex = 1;
            this.rdoCashier.TabStop = true;
            this.rdoCashier.Text = "Cashier";
            this.rdoCashier.UseVisualStyleBackColor = true;
            this.rdoCashier.Click += new System.EventHandler(this.rdoCashier_CheckedChanged);
            // 
            // rdoManager
            // 
            this.rdoManager.AutoSize = true;
            this.rdoManager.Location = new System.Drawing.Point(31, 44);
            this.rdoManager.Margin = new System.Windows.Forms.Padding(2);
            this.rdoManager.Name = "rdoManager";
            this.rdoManager.Size = new System.Drawing.Size(67, 17);
            this.rdoManager.TabIndex = 0;
            this.rdoManager.TabStop = true;
            this.rdoManager.Text = "Manager";
            this.rdoManager.UseVisualStyleBackColor = true;
            this.rdoManager.CheckedChanged += new System.EventHandler(this.rdoManager_CheckedChanged);
            this.rdoManager.Click += new System.EventHandler(this.rdoManager_CheckedChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(407, 445);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(154, 20);
            this.txtSearch.TabIndex = 22;
            this.txtSearch.Click += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.BackColor = System.Drawing.Color.Transparent;
            this.lblSearch.Location = new System.Drawing.Point(360, 447);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(44, 13);
            this.lblSearch.TabIndex = 21;
            this.lblSearch.Text = "Search:";
            // 
            // grpOrderby
            // 
            this.grpOrderby.BackColor = System.Drawing.Color.Transparent;
            this.grpOrderby.Controls.Add(this.rdoDesc);
            this.grpOrderby.Controls.Add(this.rdoAsc);
            this.grpOrderby.Location = new System.Drawing.Point(786, 437);
            this.grpOrderby.Margin = new System.Windows.Forms.Padding(2);
            this.grpOrderby.Name = "grpOrderby";
            this.grpOrderby.Padding = new System.Windows.Forms.Padding(2);
            this.grpOrderby.Size = new System.Drawing.Size(171, 119);
            this.grpOrderby.TabIndex = 20;
            this.grpOrderby.TabStop = false;
            this.grpOrderby.Text = "Order by:";
            // 
            // rdoDesc
            // 
            this.rdoDesc.AutoSize = true;
            this.rdoDesc.Location = new System.Drawing.Point(25, 75);
            this.rdoDesc.Margin = new System.Windows.Forms.Padding(2);
            this.rdoDesc.Name = "rdoDesc";
            this.rdoDesc.Size = new System.Drawing.Size(82, 17);
            this.rdoDesc.TabIndex = 2;
            this.rdoDesc.TabStop = true;
            this.rdoDesc.Text = "Descending";
            this.rdoDesc.UseVisualStyleBackColor = true;
            this.rdoDesc.Click += new System.EventHandler(this.rdoDesc_CheckedChanged);
            // 
            // rdoAsc
            // 
            this.rdoAsc.AutoSize = true;
            this.rdoAsc.Location = new System.Drawing.Point(25, 29);
            this.rdoAsc.Margin = new System.Windows.Forms.Padding(2);
            this.rdoAsc.Name = "rdoAsc";
            this.rdoAsc.Size = new System.Drawing.Size(75, 17);
            this.rdoAsc.TabIndex = 1;
            this.rdoAsc.TabStop = true;
            this.rdoAsc.Text = "Ascending";
            this.rdoAsc.UseVisualStyleBackColor = true;
            this.rdoAsc.Click += new System.EventHandler(this.rdoAsc_CheckedChanged);
            // 
            // grpSort
            // 
            this.grpSort.BackColor = System.Drawing.Color.Transparent;
            this.grpSort.Controls.Add(this.rdoID);
            this.grpSort.Controls.Add(this.rdoUsername);
            this.grpSort.Controls.Add(this.rdoSurname);
            this.grpSort.Controls.Add(this.rdoName);
            this.grpSort.Location = new System.Drawing.Point(583, 437);
            this.grpSort.Margin = new System.Windows.Forms.Padding(2);
            this.grpSort.Name = "grpSort";
            this.grpSort.Padding = new System.Windows.Forms.Padding(2);
            this.grpSort.Size = new System.Drawing.Size(183, 174);
            this.grpSort.TabIndex = 19;
            this.grpSort.TabStop = false;
            this.grpSort.Text = "Sort by:";
            // 
            // rdoID
            // 
            this.rdoID.AutoSize = true;
            this.rdoID.Location = new System.Drawing.Point(23, 147);
            this.rdoID.Margin = new System.Windows.Forms.Padding(2);
            this.rdoID.Name = "rdoID";
            this.rdoID.Size = new System.Drawing.Size(36, 17);
            this.rdoID.TabIndex = 4;
            this.rdoID.TabStop = true;
            this.rdoID.Text = "ID";
            this.rdoID.UseVisualStyleBackColor = true;
            this.rdoID.Click += new System.EventHandler(this.rdoID_CheckedChanged);
            // 
            // rdoUsername
            // 
            this.rdoUsername.AutoSize = true;
            this.rdoUsername.Location = new System.Drawing.Point(23, 110);
            this.rdoUsername.Margin = new System.Windows.Forms.Padding(2);
            this.rdoUsername.Name = "rdoUsername";
            this.rdoUsername.Size = new System.Drawing.Size(73, 17);
            this.rdoUsername.TabIndex = 3;
            this.rdoUsername.TabStop = true;
            this.rdoUsername.Text = "Username";
            this.rdoUsername.UseVisualStyleBackColor = true;
            this.rdoUsername.Click += new System.EventHandler(this.rdoUsername_CheckedChanged);
            // 
            // rdoSurname
            // 
            this.rdoSurname.AutoSize = true;
            this.rdoSurname.Location = new System.Drawing.Point(23, 68);
            this.rdoSurname.Margin = new System.Windows.Forms.Padding(2);
            this.rdoSurname.Name = "rdoSurname";
            this.rdoSurname.Size = new System.Drawing.Size(67, 17);
            this.rdoSurname.TabIndex = 2;
            this.rdoSurname.TabStop = true;
            this.rdoSurname.Text = "Surname";
            this.rdoSurname.UseVisualStyleBackColor = true;
            this.rdoSurname.Click += new System.EventHandler(this.rdoSurname_CheckedChanged);
            // 
            // rdoName
            // 
            this.rdoName.AutoSize = true;
            this.rdoName.Location = new System.Drawing.Point(23, 29);
            this.rdoName.Margin = new System.Windows.Forms.Padding(2);
            this.rdoName.Name = "rdoName";
            this.rdoName.Size = new System.Drawing.Size(53, 17);
            this.rdoName.TabIndex = 1;
            this.rdoName.TabStop = true;
            this.rdoName.Text = "Name";
            this.rdoName.UseVisualStyleBackColor = true;
            this.rdoName.Click += new System.EventHandler(this.rdoName_CheckedChanged);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(818, 566);
            this.btnReset.Margin = new System.Windows.Forms.Padding(2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(107, 44);
            this.btnReset.TabIndex = 18;
            this.btnReset.Text = "Reset Filter";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(194, 566);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(107, 44);
            this.btnRemove.TabIndex = 17;
            this.btnRemove.Text = "Remove Employee";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(194, 498);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(107, 44);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Add Employee";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(194, 437);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(107, 44);
            this.btnEdit.TabIndex = 15;
            this.btnEdit.Text = "Edit Details";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.AutoGenerateColumns = false;
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Employee_ID,
            this.Employee_FirstName,
            this.Employee_LastName,
            this.Employee_IDNumber,
            this.Employee_Role,
            this.Employee_EmailAddress,
            this.Employee_PhoneNumber,
            this.Employee_HireDate,
            this.Employee_Username,
            this.Employee_Password,
            this.Employee_Status,
            this.employeeIDDataGridViewTextBoxColumn,
            this.employeeFirstNameDataGridViewTextBoxColumn,
            this.employeeLastNameDataGridViewTextBoxColumn,
            this.employeeIDNumberDataGridViewTextBoxColumn,
            this.employeeRoleDataGridViewTextBoxColumn,
            this.employeeEmailAddressDataGridViewTextBoxColumn,
            this.employeePhoneNumberDataGridViewTextBoxColumn,
            this.employeeHireDateDataGridViewTextBoxColumn,
            this.employeeUsernameDataGridViewTextBoxColumn,
            this.employeePasswordDataGridViewTextBoxColumn,
            this.employeeStatusDataGridViewTextBoxColumn});
            this.dgvEmployees.DataSource = this.employeeBindingSource;
            this.dgvEmployees.Location = new System.Drawing.Point(8, 77);
            this.dgvEmployees.Margin = new System.Windows.Forms.Padding(2);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.RowHeadersWidth = 62;
            this.dgvEmployees.RowTemplate.Height = 28;
            this.dgvEmployees.Size = new System.Drawing.Size(1114, 319);
            this.dgvEmployees.TabIndex = 14;
            // 
            // Employee_ID
            // 
            this.Employee_ID.DataPropertyName = "Employee_ID";
            this.Employee_ID.HeaderText = "ID";
            this.Employee_ID.MinimumWidth = 8;
            this.Employee_ID.Name = "Employee_ID";
            this.Employee_ID.ReadOnly = true;
            this.Employee_ID.Width = 80;
            // 
            // Employee_FirstName
            // 
            this.Employee_FirstName.DataPropertyName = "Employee_FirstName";
            this.Employee_FirstName.HeaderText = "FirstName";
            this.Employee_FirstName.MinimumWidth = 8;
            this.Employee_FirstName.Name = "Employee_FirstName";
            this.Employee_FirstName.Width = 110;
            // 
            // Employee_LastName
            // 
            this.Employee_LastName.DataPropertyName = "Employee_LastName";
            this.Employee_LastName.HeaderText = "LastName";
            this.Employee_LastName.MinimumWidth = 8;
            this.Employee_LastName.Name = "Employee_LastName";
            this.Employee_LastName.Width = 110;
            // 
            // Employee_IDNumber
            // 
            this.Employee_IDNumber.DataPropertyName = "Employee_IDNumber";
            this.Employee_IDNumber.HeaderText = "IDNumber";
            this.Employee_IDNumber.MinimumWidth = 8;
            this.Employee_IDNumber.Name = "Employee_IDNumber";
            this.Employee_IDNumber.Width = 110;
            // 
            // Employee_Role
            // 
            this.Employee_Role.DataPropertyName = "Employee_Role";
            this.Employee_Role.HeaderText = "Role";
            this.Employee_Role.MinimumWidth = 8;
            this.Employee_Role.Name = "Employee_Role";
            this.Employee_Role.Width = 90;
            // 
            // Employee_EmailAddress
            // 
            this.Employee_EmailAddress.DataPropertyName = "Employee_EmailAddress";
            this.Employee_EmailAddress.HeaderText = "EmailAddress";
            this.Employee_EmailAddress.MinimumWidth = 8;
            this.Employee_EmailAddress.Name = "Employee_EmailAddress";
            this.Employee_EmailAddress.Width = 120;
            // 
            // Employee_PhoneNumber
            // 
            this.Employee_PhoneNumber.DataPropertyName = "Employee_PhoneNumber";
            this.Employee_PhoneNumber.HeaderText = "PhoneNumber";
            this.Employee_PhoneNumber.MinimumWidth = 8;
            this.Employee_PhoneNumber.Name = "Employee_PhoneNumber";
            this.Employee_PhoneNumber.Width = 120;
            // 
            // Employee_HireDate
            // 
            this.Employee_HireDate.DataPropertyName = "Employee_HireDate";
            this.Employee_HireDate.HeaderText = "HireDate";
            this.Employee_HireDate.MinimumWidth = 8;
            this.Employee_HireDate.Name = "Employee_HireDate";
            this.Employee_HireDate.Width = 110;
            // 
            // Employee_Username
            // 
            this.Employee_Username.DataPropertyName = "Employee_Username";
            this.Employee_Username.HeaderText = "Username";
            this.Employee_Username.MinimumWidth = 8;
            this.Employee_Username.Name = "Employee_Username";
            this.Employee_Username.Width = 110;
            // 
            // Employee_Password
            // 
            this.Employee_Password.DataPropertyName = "Employee_Password";
            this.Employee_Password.HeaderText = "Password";
            this.Employee_Password.MinimumWidth = 8;
            this.Employee_Password.Name = "Employee_Password";
            this.Employee_Password.Width = 110;
            // 
            // Employee_Status
            // 
            this.Employee_Status.DataPropertyName = "Employee_Status";
            this.Employee_Status.HeaderText = "Status";
            this.Employee_Status.MinimumWidth = 8;
            this.Employee_Status.Name = "Employee_Status";
            this.Employee_Status.Width = 80;
            // 
            // employeeIDDataGridViewTextBoxColumn
            // 
            this.employeeIDDataGridViewTextBoxColumn.DataPropertyName = "Employee_ID";
            this.employeeIDDataGridViewTextBoxColumn.HeaderText = "Employee_ID";
            this.employeeIDDataGridViewTextBoxColumn.Name = "employeeIDDataGridViewTextBoxColumn";
            this.employeeIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeeFirstNameDataGridViewTextBoxColumn
            // 
            this.employeeFirstNameDataGridViewTextBoxColumn.DataPropertyName = "Employee_FirstName";
            this.employeeFirstNameDataGridViewTextBoxColumn.HeaderText = "Employee_FirstName";
            this.employeeFirstNameDataGridViewTextBoxColumn.Name = "employeeFirstNameDataGridViewTextBoxColumn";
            // 
            // employeeLastNameDataGridViewTextBoxColumn
            // 
            this.employeeLastNameDataGridViewTextBoxColumn.DataPropertyName = "Employee_LastName";
            this.employeeLastNameDataGridViewTextBoxColumn.HeaderText = "Employee_LastName";
            this.employeeLastNameDataGridViewTextBoxColumn.Name = "employeeLastNameDataGridViewTextBoxColumn";
            // 
            // employeeIDNumberDataGridViewTextBoxColumn
            // 
            this.employeeIDNumberDataGridViewTextBoxColumn.DataPropertyName = "Employee_IDNumber";
            this.employeeIDNumberDataGridViewTextBoxColumn.HeaderText = "Employee_IDNumber";
            this.employeeIDNumberDataGridViewTextBoxColumn.Name = "employeeIDNumberDataGridViewTextBoxColumn";
            // 
            // employeeRoleDataGridViewTextBoxColumn
            // 
            this.employeeRoleDataGridViewTextBoxColumn.DataPropertyName = "Employee_Role";
            this.employeeRoleDataGridViewTextBoxColumn.HeaderText = "Employee_Role";
            this.employeeRoleDataGridViewTextBoxColumn.Name = "employeeRoleDataGridViewTextBoxColumn";
            // 
            // employeeEmailAddressDataGridViewTextBoxColumn
            // 
            this.employeeEmailAddressDataGridViewTextBoxColumn.DataPropertyName = "Employee_EmailAddress";
            this.employeeEmailAddressDataGridViewTextBoxColumn.HeaderText = "Employee_EmailAddress";
            this.employeeEmailAddressDataGridViewTextBoxColumn.Name = "employeeEmailAddressDataGridViewTextBoxColumn";
            // 
            // employeePhoneNumberDataGridViewTextBoxColumn
            // 
            this.employeePhoneNumberDataGridViewTextBoxColumn.DataPropertyName = "Employee_PhoneNumber";
            this.employeePhoneNumberDataGridViewTextBoxColumn.HeaderText = "Employee_PhoneNumber";
            this.employeePhoneNumberDataGridViewTextBoxColumn.Name = "employeePhoneNumberDataGridViewTextBoxColumn";
            // 
            // employeeHireDateDataGridViewTextBoxColumn
            // 
            this.employeeHireDateDataGridViewTextBoxColumn.DataPropertyName = "Employee_HireDate";
            this.employeeHireDateDataGridViewTextBoxColumn.HeaderText = "Employee_HireDate";
            this.employeeHireDateDataGridViewTextBoxColumn.Name = "employeeHireDateDataGridViewTextBoxColumn";
            // 
            // employeeUsernameDataGridViewTextBoxColumn
            // 
            this.employeeUsernameDataGridViewTextBoxColumn.DataPropertyName = "Employee_Username";
            this.employeeUsernameDataGridViewTextBoxColumn.HeaderText = "Employee_Username";
            this.employeeUsernameDataGridViewTextBoxColumn.Name = "employeeUsernameDataGridViewTextBoxColumn";
            // 
            // employeePasswordDataGridViewTextBoxColumn
            // 
            this.employeePasswordDataGridViewTextBoxColumn.DataPropertyName = "Employee_Password";
            this.employeePasswordDataGridViewTextBoxColumn.HeaderText = "Employee_Password";
            this.employeePasswordDataGridViewTextBoxColumn.Name = "employeePasswordDataGridViewTextBoxColumn";
            // 
            // employeeStatusDataGridViewTextBoxColumn
            // 
            this.employeeStatusDataGridViewTextBoxColumn.DataPropertyName = "Employee_Status";
            this.employeeStatusDataGridViewTextBoxColumn.HeaderText = "Employee_Status";
            this.employeeStatusDataGridViewTextBoxColumn.Name = "employeeStatusDataGridViewTextBoxColumn";
            // 
            // employeeTableAdapter
            // 
            this.employeeTableAdapter.ClearBeforeFill = true;
            // 
            // ManageEmployeeDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TheByteClubPOS.Properties.Resources.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1134, 666);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.grpOrderby);
            this.Controls.Add(this.grpSort);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.dgvEmployees);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ManageEmployeeDetailsForm";
            this.Text = "ManageEmployeeDetailsForm";
            this.Load += new System.EventHandler(this.ManageEmployeeDetailsForm_Load);
            this.Click += new System.EventHandler(this.ManageEmployeeDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSamsLiqourShopBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSamsLiqourShop)).EndInit();
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.grpOrderby.ResumeLayout(false);
            this.grpOrderby.PerformLayout();
            this.grpSort.ResumeLayout(false);
            this.grpSort.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.RadioButton rdoAdmin;
        private System.Windows.Forms.RadioButton rdoCashier;
        private System.Windows.Forms.RadioButton rdoManager;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.GroupBox grpOrderby;
        private System.Windows.Forms.RadioButton rdoDesc;
        private System.Windows.Forms.RadioButton rdoAsc;
        private System.Windows.Forms.GroupBox grpSort;
        private System.Windows.Forms.RadioButton rdoID;
        private System.Windows.Forms.RadioButton rdoUsername;
        private System.Windows.Forms.RadioButton rdoSurname;
        private System.Windows.Forms.RadioButton rdoName;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employee_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employee_FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employee_LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employee_IDNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employee_Role;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employee_EmailAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employee_PhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employee_HireDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employee_Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employee_Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employee_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeHireDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeUsernameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeePasswordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeStatusDataGridViewTextBoxColumn;
    }
}