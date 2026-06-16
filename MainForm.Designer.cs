namespace TheByteClubPOS
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.manageSalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processSaleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.manageSalesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.managePaymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managePaymentMethodsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageSaleTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageProductsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.manageProducToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processInventoryOrderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.manageInventoryOrdersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.manageSuppliersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageCustomersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageEmployeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageEmployeesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.manageDiscountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageDiscountsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.darkModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageMyProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTime = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDate = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.troubleshootingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelRole = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTerminal = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSpacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelConnection = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnProcessSale = new System.Windows.Forms.Button();
            this.btnManageSales = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnSuppliers = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dsSamsLiqourShop = new TheByteClubPOS.dsSamsLiqourShop();
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.employeeTableAdapter = new TheByteClubPOS.dsSamsLiqourShopTableAdapters.EmployeeTableAdapter();
            this.tableAdapterManager = new TheByteClubPOS.dsSamsLiqourShopTableAdapters.TableAdapterManager();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSamsLiqourShop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageSalesToolStripMenuItem,
            this.inventoryToolStripMenuItem,
            this.manageCustomerToolStripMenuItem,
            this.manageEmployeesToolStripMenuItem,
            this.manageDiscountsToolStripMenuItem,
            this.darkModeToolStripMenuItem,
            this.manageAccountToolStripMenuItem,
            this.toolStripMenuItemTime,
            this.toolStripMenuItemDate,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1354, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // manageSalesToolStripMenuItem
            // 
            this.manageSalesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.processSaleToolStripMenuItem1,
            this.manageSalesToolStripMenuItem1,
            this.managePaymentsToolStripMenuItem,
            this.managePaymentMethodsToolStripMenuItem,
            this.manageSaleTypesToolStripMenuItem});
            this.manageSalesToolStripMenuItem.Image = global::TheByteClubPOS.Properties.Resources.SalesIcon;
            this.manageSalesToolStripMenuItem.Name = "manageSalesToolStripMenuItem";
            this.manageSalesToolStripMenuItem.Size = new System.Drawing.Size(69, 28);
            this.manageSalesToolStripMenuItem.Text = "Sales";
            this.manageSalesToolStripMenuItem.Click += new System.EventHandler(this.manageSalesToolStripMenuItem_Click);
            // 
            // processSaleToolStripMenuItem1
            // 
            this.processSaleToolStripMenuItem1.Name = "processSaleToolStripMenuItem1";
            this.processSaleToolStripMenuItem1.Size = new System.Drawing.Size(217, 22);
            this.processSaleToolStripMenuItem1.Text = "Process Sale";
            this.processSaleToolStripMenuItem1.Click += new System.EventHandler(this.processSaleToolStripMenuItem1_Click);
            // 
            // manageSalesToolStripMenuItem1
            // 
            this.manageSalesToolStripMenuItem1.Name = "manageSalesToolStripMenuItem1";
            this.manageSalesToolStripMenuItem1.Size = new System.Drawing.Size(217, 22);
            this.manageSalesToolStripMenuItem1.Text = "View Sales";
            this.manageSalesToolStripMenuItem1.Click += new System.EventHandler(this.manageSalesToolStripMenuItem1_Click);
            // 
            // managePaymentsToolStripMenuItem
            // 
            this.managePaymentsToolStripMenuItem.Name = "managePaymentsToolStripMenuItem";
            this.managePaymentsToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.managePaymentsToolStripMenuItem.Text = "View Payments";
            this.managePaymentsToolStripMenuItem.Visible = false;
            // 
            // managePaymentMethodsToolStripMenuItem
            // 
            this.managePaymentMethodsToolStripMenuItem.Name = "managePaymentMethodsToolStripMenuItem";
            this.managePaymentMethodsToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.managePaymentMethodsToolStripMenuItem.Text = "Manage Payment Methods";
            this.managePaymentMethodsToolStripMenuItem.Visible = false;
            // 
            // manageSaleTypesToolStripMenuItem
            // 
            this.manageSaleTypesToolStripMenuItem.Name = "manageSaleTypesToolStripMenuItem";
            this.manageSaleTypesToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.manageSaleTypesToolStripMenuItem.Text = "Manage Sale Types";
            this.manageSaleTypesToolStripMenuItem.Visible = false;
            // 
            // inventoryToolStripMenuItem
            // 
            this.inventoryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageProductsToolStripMenuItem1,
            this.manageProducToolStripMenuItem,
            this.processInventoryOrderToolStripMenuItem1,
            this.manageInventoryOrdersToolStripMenuItem1,
            this.manageSuppliersToolStripMenuItem});
            this.inventoryToolStripMenuItem.Image = global::TheByteClubPOS.Properties.Resources.InventoryIcon;
            this.inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
            this.inventoryToolStripMenuItem.Size = new System.Drawing.Size(93, 28);
            this.inventoryToolStripMenuItem.Text = "Inventory";
            // 
            // manageProductsToolStripMenuItem1
            // 
            this.manageProductsToolStripMenuItem1.Name = "manageProductsToolStripMenuItem1";
            this.manageProductsToolStripMenuItem1.Size = new System.Drawing.Size(221, 22);
            this.manageProductsToolStripMenuItem1.Text = "Manage Products";
            this.manageProductsToolStripMenuItem1.Click += new System.EventHandler(this.manageProductsToolStripMenuItem1_Click);
            // 
            // manageProducToolStripMenuItem
            // 
            this.manageProducToolStripMenuItem.Name = "manageProducToolStripMenuItem";
            this.manageProducToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.manageProducToolStripMenuItem.Text = "Manage Product Categories";
            this.manageProducToolStripMenuItem.Visible = false;
            this.manageProducToolStripMenuItem.Click += new System.EventHandler(this.manageProducToolStripMenuItem_Click);
            // 
            // processInventoryOrderToolStripMenuItem1
            // 
            this.processInventoryOrderToolStripMenuItem1.Name = "processInventoryOrderToolStripMenuItem1";
            this.processInventoryOrderToolStripMenuItem1.Size = new System.Drawing.Size(221, 22);
            this.processInventoryOrderToolStripMenuItem1.Text = "Process Inventory Order";
            this.processInventoryOrderToolStripMenuItem1.Visible = false;
            this.processInventoryOrderToolStripMenuItem1.Click += new System.EventHandler(this.processInventoryOrderToolStripMenuItem1_Click);
            // 
            // manageInventoryOrdersToolStripMenuItem1
            // 
            this.manageInventoryOrdersToolStripMenuItem1.Name = "manageInventoryOrdersToolStripMenuItem1";
            this.manageInventoryOrdersToolStripMenuItem1.Size = new System.Drawing.Size(221, 22);
            this.manageInventoryOrdersToolStripMenuItem1.Text = "Manage Inventory Orders";
            this.manageInventoryOrdersToolStripMenuItem1.Visible = false;
            this.manageInventoryOrdersToolStripMenuItem1.Click += new System.EventHandler(this.manageInventoryOrdersToolStripMenuItem1_Click);
            // 
            // manageSuppliersToolStripMenuItem
            // 
            this.manageSuppliersToolStripMenuItem.Name = "manageSuppliersToolStripMenuItem";
            this.manageSuppliersToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.manageSuppliersToolStripMenuItem.Text = "Manage Suppliers";
            this.manageSuppliersToolStripMenuItem.Visible = false;
            this.manageSuppliersToolStripMenuItem.Click += new System.EventHandler(this.manageSuppliersToolStripMenuItem_Click);
            // 
            // manageCustomerToolStripMenuItem
            // 
            this.manageCustomerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageCustomersToolStripMenuItem});
            this.manageCustomerToolStripMenuItem.Image = global::TheByteClubPOS.Properties.Resources.CustomersIcon;
            this.manageCustomerToolStripMenuItem.Name = "manageCustomerToolStripMenuItem";
            this.manageCustomerToolStripMenuItem.Size = new System.Drawing.Size(100, 28);
            this.manageCustomerToolStripMenuItem.Text = "Customers";
            // 
            // manageCustomersToolStripMenuItem
            // 
            this.manageCustomersToolStripMenuItem.Name = "manageCustomersToolStripMenuItem";
            this.manageCustomersToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.manageCustomersToolStripMenuItem.Text = "Manage Customers";
            this.manageCustomersToolStripMenuItem.Click += new System.EventHandler(this.manageCustomersToolStripMenuItem_Click);
            // 
            // manageEmployeesToolStripMenuItem
            // 
            this.manageEmployeesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageEmployeesToolStripMenuItem1});
            this.manageEmployeesToolStripMenuItem.Image = global::TheByteClubPOS.Properties.Resources.EmployeesIcon;
            this.manageEmployeesToolStripMenuItem.Name = "manageEmployeesToolStripMenuItem";
            this.manageEmployeesToolStripMenuItem.Size = new System.Drawing.Size(67, 28);
            this.manageEmployeesToolStripMenuItem.Text = "Staff";
            // 
            // manageEmployeesToolStripMenuItem1
            // 
            this.manageEmployeesToolStripMenuItem1.Name = "manageEmployeesToolStripMenuItem1";
            this.manageEmployeesToolStripMenuItem1.Size = new System.Drawing.Size(177, 22);
            this.manageEmployeesToolStripMenuItem1.Text = "Manage Employees";
            this.manageEmployeesToolStripMenuItem1.Click += new System.EventHandler(this.manageEmployeesToolStripMenuItem1_Click);
            // 
            // manageDiscountsToolStripMenuItem
            // 
            this.manageDiscountsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageDiscountsToolStripMenuItem1});
            this.manageDiscountsToolStripMenuItem.Image = global::TheByteClubPOS.Properties.Resources.DiscountIcon;
            this.manageDiscountsToolStripMenuItem.Name = "manageDiscountsToolStripMenuItem";
            this.manageDiscountsToolStripMenuItem.Size = new System.Drawing.Size(95, 28);
            this.manageDiscountsToolStripMenuItem.Text = "Discounts";
            this.manageDiscountsToolStripMenuItem.Visible = false;
            // 
            // manageDiscountsToolStripMenuItem1
            // 
            this.manageDiscountsToolStripMenuItem1.Name = "manageDiscountsToolStripMenuItem1";
            this.manageDiscountsToolStripMenuItem1.Size = new System.Drawing.Size(172, 22);
            this.manageDiscountsToolStripMenuItem1.Text = "Manage Discounts";
            // 
            // darkModeToolStripMenuItem
            // 
            this.darkModeToolStripMenuItem.Image = global::TheByteClubPOS.Properties.Resources.DarkModeIcon;
            this.darkModeToolStripMenuItem.Name = "darkModeToolStripMenuItem";
            this.darkModeToolStripMenuItem.Size = new System.Drawing.Size(101, 28);
            this.darkModeToolStripMenuItem.Text = "Dark Mode";
            this.darkModeToolStripMenuItem.Click += new System.EventHandler(this.darkModeToolStripMenuItem_Click);
            // 
            // manageAccountToolStripMenuItem
            // 
            this.manageAccountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageMyProfileToolStripMenuItem,
            this.logoutToolStripMenuItem1});
            this.manageAccountToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("manageAccountToolStripMenuItem.Image")));
            this.manageAccountToolStripMenuItem.Name = "manageAccountToolStripMenuItem";
            this.manageAccountToolStripMenuItem.Size = new System.Drawing.Size(108, 28);
            this.manageAccountToolStripMenuItem.Text = "My Account";
            this.manageAccountToolStripMenuItem.Click += new System.EventHandler(this.manageAccountToolStripMenuItem_Click);
            // 
            // manageMyProfileToolStripMenuItem
            // 
            this.manageMyProfileToolStripMenuItem.Name = "manageMyProfileToolStripMenuItem";
            this.manageMyProfileToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.manageMyProfileToolStripMenuItem.Text = "Manage My Profile";
            this.manageMyProfileToolStripMenuItem.Click += new System.EventHandler(this.manageMyProfileToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem1
            // 
            this.logoutToolStripMenuItem1.Name = "logoutToolStripMenuItem1";
            this.logoutToolStripMenuItem1.Size = new System.Drawing.Size(174, 22);
            this.logoutToolStripMenuItem1.Text = "Logout";
            this.logoutToolStripMenuItem1.Click += new System.EventHandler(this.logoutToolStripMenuItem1_Click);
            // 
            // toolStripMenuItemTime
            // 
            this.toolStripMenuItemTime.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItemTime.Image = global::TheByteClubPOS.Properties.Resources.ClockIcon;
            this.toolStripMenuItemTime.Name = "toolStripMenuItemTime";
            this.toolStripMenuItemTime.Size = new System.Drawing.Size(85, 28);
            this.toolStripMenuItemTime.Text = "14:30:00";
            // 
            // toolStripMenuItemDate
            // 
            this.toolStripMenuItemDate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItemDate.Image = global::TheByteClubPOS.Properties.Resources.CalendarIcon;
            this.toolStripMenuItemDate.Name = "toolStripMenuItemDate";
            this.toolStripMenuItemDate.Size = new System.Drawing.Size(108, 28);
            this.toolStripMenuItemDate.Text = "31 May 2026";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem,
            this.userGuideToolStripMenuItem,
            this.troubleshootingToolStripMenuItem});
            this.helpToolStripMenuItem.Image = global::TheByteClubPOS.Properties.Resources.HelpIcon;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(109, 28);
            this.helpToolStripMenuItem.Text = "System Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(158, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // userGuideToolStripMenuItem
            // 
            this.userGuideToolStripMenuItem.Name = "userGuideToolStripMenuItem";
            this.userGuideToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.userGuideToolStripMenuItem.Text = "User Guide";
            this.userGuideToolStripMenuItem.Click += new System.EventHandler(this.userGuideToolStripMenuItem_Click);
            // 
            // troubleshootingToolStripMenuItem
            // 
            this.troubleshootingToolStripMenuItem.Name = "troubleshootingToolStripMenuItem";
            this.troubleshootingToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.troubleshootingToolStripMenuItem.Text = "Troubleshooting";
            this.troubleshootingToolStripMenuItem.Click += new System.EventHandler(this.troubleshootingToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelUser,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabelRole,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabelTerminal,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabelSpacer,
            this.toolStripStatusLabelVersion,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabelConnection});
            this.statusStrip1.Location = new System.Drawing.Point(0, 657);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1354, 29);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelUser
            // 
            this.toolStripStatusLabelUser.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabelUser.Image")));
            this.toolStripStatusLabelUser.Name = "toolStripStatusLabelUser";
            this.toolStripStatusLabelUser.Size = new System.Drawing.Size(104, 24);
            this.toolStripStatusLabelUser.Text = "Logged in as: ";
            this.toolStripStatusLabelUser.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(10, 24);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // toolStripStatusLabelRole
            // 
            this.toolStripStatusLabelRole.Image = global::TheByteClubPOS.Properties.Resources.BadgeIcon;
            this.toolStripStatusLabelRole.Name = "toolStripStatusLabelRole";
            this.toolStripStatusLabelRole.Size = new System.Drawing.Size(60, 24);
            this.toolStripStatusLabelRole.Text = "Role: ";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(10, 24);
            this.toolStripStatusLabel3.Text = "|";
            // 
            // toolStripStatusLabelTerminal
            // 
            this.toolStripStatusLabelTerminal.Image = global::TheByteClubPOS.Properties.Resources.ComputerIcon;
            this.toolStripStatusLabelTerminal.Name = "toolStripStatusLabelTerminal";
            this.toolStripStatusLabelTerminal.Size = new System.Drawing.Size(122, 24);
            this.toolStripStatusLabelTerminal.Text = "Terminal: POS-01";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(10, 24);
            this.toolStripStatusLabel4.Text = "|";
            // 
            // toolStripStatusLabelSpacer
            // 
            this.toolStripStatusLabelSpacer.Name = "toolStripStatusLabelSpacer";
            this.toolStripStatusLabelSpacer.Size = new System.Drawing.Size(755, 24);
            this.toolStripStatusLabelSpacer.Spring = true;
            // 
            // toolStripStatusLabelVersion
            // 
            this.toolStripStatusLabelVersion.Image = global::TheByteClubPOS.Properties.Resources.InfoIcon;
            this.toolStripStatusLabelVersion.Name = "toolStripStatusLabelVersion";
            this.toolStripStatusLabelVersion.Size = new System.Drawing.Size(131, 24);
            this.toolStripStatusLabelVersion.Text = "System Version: 1.2";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(10, 24);
            this.toolStripStatusLabel5.Text = "|";
            // 
            // toolStripStatusLabelConnection
            // 
            this.toolStripStatusLabelConnection.Image = global::TheByteClubPOS.Properties.Resources.GreenCircleIcon;
            this.toolStripStatusLabelConnection.Name = "toolStripStatusLabelConnection";
            this.toolStripStatusLabelConnection.Size = new System.Drawing.Size(127, 24);
            this.toolStripStatusLabelConnection.Text = "Status: Connected";
            // 
            // tmrClock
            // 
            this.tmrClock.Enabled = true;
            this.tmrClock.Interval = 1000;
            this.tmrClock.Tick += new System.EventHandler(this.tmrClock_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 627);
            this.panel1.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.flowLayoutPanel1.Controls.Add(this.btnDashboard);
            this.flowLayoutPanel1.Controls.Add(this.btnProcessSale);
            this.flowLayoutPanel1.Controls.Add(this.btnManageSales);
            this.flowLayoutPanel1.Controls.Add(this.btnProducts);
            this.flowLayoutPanel1.Controls.Add(this.btnCustomers);
            this.flowLayoutPanel1.Controls.Add(this.btnSuppliers);
            this.flowLayoutPanel1.Controls.Add(this.btnLogout);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 130);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(220, 497);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // btnDashboard
            // 
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Image = global::TheByteClubPOS.Properties.Resources.HomeIcon;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(13, 13);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(200, 45);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnProcessSale
            // 
            this.btnProcessSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcessSale.Image = global::TheByteClubPOS.Properties.Resources.CartIcon;
            this.btnProcessSale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcessSale.Location = new System.Drawing.Point(13, 64);
            this.btnProcessSale.Name = "btnProcessSale";
            this.btnProcessSale.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnProcessSale.Size = new System.Drawing.Size(200, 45);
            this.btnProcessSale.TabIndex = 1;
            this.btnProcessSale.Text = "Process Sale";
            this.btnProcessSale.UseVisualStyleBackColor = true;
            this.btnProcessSale.Click += new System.EventHandler(this.btnProcessSale_Click);
            // 
            // btnManageSales
            // 
            this.btnManageSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageSales.Image = ((System.Drawing.Image)(resources.GetObject("btnManageSales.Image")));
            this.btnManageSales.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageSales.Location = new System.Drawing.Point(13, 115);
            this.btnManageSales.Name = "btnManageSales";
            this.btnManageSales.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnManageSales.Size = new System.Drawing.Size(200, 45);
            this.btnManageSales.TabIndex = 2;
            this.btnManageSales.Text = "View Sales";
            this.btnManageSales.UseVisualStyleBackColor = true;
            this.btnManageSales.Click += new System.EventHandler(this.btnManageSales_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProducts.Image = ((System.Drawing.Image)(resources.GetObject("btnProducts.Image")));
            this.btnProducts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProducts.Location = new System.Drawing.Point(13, 166);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnProducts.Size = new System.Drawing.Size(200, 45);
            this.btnProducts.TabIndex = 3;
            this.btnProducts.Text = "View Products";
            this.btnProducts.UseVisualStyleBackColor = true;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // btnCustomers
            // 
            this.btnCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomers.Image = global::TheByteClubPOS.Properties.Resources.CustomerIcon;
            this.btnCustomers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomers.Location = new System.Drawing.Point(13, 217);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnCustomers.Size = new System.Drawing.Size(200, 45);
            this.btnCustomers.TabIndex = 4;
            this.btnCustomers.Text = "View Customers";
            this.btnCustomers.UseVisualStyleBackColor = true;
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // btnSuppliers
            // 
            this.btnSuppliers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuppliers.Image = global::TheByteClubPOS.Properties.Resources.TruckIcon;
            this.btnSuppliers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuppliers.Location = new System.Drawing.Point(13, 268);
            this.btnSuppliers.Name = "btnSuppliers";
            this.btnSuppliers.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnSuppliers.Size = new System.Drawing.Size(200, 45);
            this.btnSuppliers.TabIndex = 5;
            this.btnSuppliers.Text = "Suppliers";
            this.btnSuppliers.UseVisualStyleBackColor = true;
            this.btnSuppliers.Visible = false;
            this.btnSuppliers.Click += new System.EventHandler(this.btnSuppliers_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Image = global::TheByteClubPOS.Properties.Resources.LogoutIcon;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(13, 319);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(200, 45);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 369);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(201, 45);
            this.button2.TabIndex = 8;
            this.button2.Text = "New View Products";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::TheByteClubPOS.Properties.Resources.MainFormPanel1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TheByteClubPOS.Properties.Resources.POINT_OF_SALES;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1354, 686);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sam\'s Liquor Shop - Point of Sale System";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSamsLiqourShop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private dsSamsLiqourShop dsSamsLiqourShop;
        private System.Windows.Forms.BindingSource employeeBindingSource;
        private dsSamsLiqourShopTableAdapters.EmployeeTableAdapter employeeTableAdapter;
        private dsSamsLiqourShopTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ToolStripMenuItem manageAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageSalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageEmployeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managePaymentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managePaymentMethodsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageSaleTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageDiscountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageSalesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem processSaleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem manageDiscountsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem manageCustomersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageProductsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem manageProducToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processInventoryOrderToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem manageInventoryOrdersToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem manageSuppliersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageEmployeesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem manageMyProfileToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelUser;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRole;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTerminal;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelVersion;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelConnection;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSpacer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDate;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTime;
        private System.Windows.Forms.Timer tmrClock;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnManageSales;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button btnSuppliers;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ToolStripMenuItem darkModeToolStripMenuItem;
        public System.Windows.Forms.Button btnProcessSale;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userGuideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem troubleshootingToolStripMenuItem;
        public System.Windows.Forms.Button btnProducts;
        public System.Windows.Forms.Button button2;
    }
}