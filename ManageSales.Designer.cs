namespace TheByteClubPOS
{
    partial class ManageSales
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageSales));
            this.lblManageSales = new System.Windows.Forms.Label();
            this.lblTransactionDetails = new System.Windows.Forms.Label();
            this.dsSamsLiqourShop = new TheByteClubPOS.dsSamsLiqourShop();
            this.salesSummaryInnerJoinDTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.salesSummaryInnerJoinDTTableAdapter = new TheByteClubPOS.dsSamsLiqourShopTableAdapters.SalesSummaryInnerJoinDTTableAdapter();
            this.tableAdapterManager = new TheByteClubPOS.dsSamsLiqourShopTableAdapters.TableAdapterManager();
            this.salesSummaryInnerJoinDTDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saleLinesSummaryInnerJoinDTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saleLinesSummaryInnerJoinDTTableAdapter = new TheByteClubPOS.dsSamsLiqourShopTableAdapters.SaleLinesSummaryInnerJoinDTTableAdapter();
            this.saleLinesSummaryInnerJoinDTDataGridView = new System.Windows.Forms.DataGridView();
            this.Product_Image = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnFilterDate = new System.Windows.Forms.Button();
            this.btnPDFExport = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.dsSamsLiqourShop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesSummaryInnerJoinDTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesSummaryInnerJoinDTDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleLinesSummaryInnerJoinDTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleLinesSummaryInnerJoinDTDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // lblManageSales
            // 
            this.lblManageSales.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblManageSales.AutoSize = true;
            this.lblManageSales.BackColor = System.Drawing.Color.Transparent;
            this.lblManageSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManageSales.Location = new System.Drawing.Point(27, 49);
            this.lblManageSales.Name = "lblManageSales";
            this.lblManageSales.Size = new System.Drawing.Size(210, 33);
            this.lblManageSales.TabIndex = 5;
            this.lblManageSales.Text = "Sales History:";
            // 
            // lblTransactionDetails
            // 
            this.lblTransactionDetails.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTransactionDetails.AutoSize = true;
            this.lblTransactionDetails.BackColor = System.Drawing.Color.Transparent;
            this.lblTransactionDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionDetails.Location = new System.Drawing.Point(27, 402);
            this.lblTransactionDetails.Name = "lblTransactionDetails";
            this.lblTransactionDetails.Size = new System.Drawing.Size(473, 31);
            this.lblTransactionDetails.TabIndex = 6;
            this.lblTransactionDetails.Text = "Transaction Details (Sale ID : 000):";
            // 
            // dsSamsLiqourShop
            // 
            this.dsSamsLiqourShop.DataSetName = "dsSamsLiqourShop";
            this.dsSamsLiqourShop.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // salesSummaryInnerJoinDTBindingSource
            // 
            this.salesSummaryInnerJoinDTBindingSource.DataMember = "SalesSummaryInnerJoinDT";
            this.salesSummaryInnerJoinDTBindingSource.DataSource = this.dsSamsLiqourShop;
            // 
            // salesSummaryInnerJoinDTTableAdapter
            // 
            this.salesSummaryInnerJoinDTTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CategoryTableAdapter = null;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.CustomerTableAdapter = null;
            this.tableAdapterManager.DiscountTableAdapter = null;
            this.tableAdapterManager.EmployeeTableAdapter = null;
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
            // salesSummaryInnerJoinDTDataGridView
            // 
            this.salesSummaryInnerJoinDTDataGridView.AllowUserToAddRows = false;
            this.salesSummaryInnerJoinDTDataGridView.AllowUserToDeleteRows = false;
            this.salesSummaryInnerJoinDTDataGridView.AutoGenerateColumns = false;
            this.salesSummaryInnerJoinDTDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.salesSummaryInnerJoinDTDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.salesSummaryInnerJoinDTDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn8});
            this.salesSummaryInnerJoinDTDataGridView.DataSource = this.salesSummaryInnerJoinDTBindingSource;
            this.salesSummaryInnerJoinDTDataGridView.Location = new System.Drawing.Point(33, 184);
            this.salesSummaryInnerJoinDTDataGridView.Name = "salesSummaryInnerJoinDTDataGridView";
            this.salesSummaryInnerJoinDTDataGridView.ReadOnly = true;
            this.salesSummaryInnerJoinDTDataGridView.Size = new System.Drawing.Size(1077, 241);
            this.salesSummaryInnerJoinDTDataGridView.TabIndex = 7;
            this.salesSummaryInnerJoinDTDataGridView.SelectionChanged += new System.EventHandler(this.salesSummaryInnerJoinDTDataGridView_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Sale_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Invoice Number";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Sale_DateTime";
            this.dataGridViewTextBoxColumn10.FillWeight = 120F;
            this.dataGridViewTextBoxColumn10.HeaderText = "Date & Time";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Customer_Details";
            this.dataGridViewTextBoxColumn3.FillWeight = 120F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Customer Account";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Employee_Name";
            this.dataGridViewTextBoxColumn5.FillWeight = 120F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Served By";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "SaleType_Name";
            this.dataGridViewTextBoxColumn7.FillWeight = 60F;
            this.dataGridViewTextBoxColumn7.HeaderText = "Payment Method";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Sale_Discount_Name";
            this.dataGridViewTextBoxColumn9.FillWeight = 160F;
            this.dataGridViewTextBoxColumn9.HeaderText = "Applied Promo";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Sale_Subtotal";
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn11.FillWeight = 80F;
            this.dataGridViewTextBoxColumn11.HeaderText = "Subtotal";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Sale_DiscountAmount";
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.dataGridViewTextBoxColumn12.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn12.FillWeight = 80F;
            this.dataGridViewTextBoxColumn12.HeaderText = "Discount";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Sale_TotalAmount";
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn13.FillWeight = 80F;
            this.dataGridViewTextBoxColumn13.HeaderText = "Total Paid";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Sale_LoyaltyPointsEarned";
            this.dataGridViewTextBoxColumn14.FillWeight = 80F;
            this.dataGridViewTextBoxColumn14.HeaderText = "Points Earned";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "Sale_Status";
            this.dataGridViewTextBoxColumn15.FillWeight = 90F;
            this.dataGridViewTextBoxColumn15.HeaderText = "Status";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Customer_ID";
            this.dataGridViewTextBoxColumn2.HeaderText = "Customer_ID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Employee_ID";
            this.dataGridViewTextBoxColumn4.HeaderText = "Employee_ID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "SaleType_ID";
            this.dataGridViewTextBoxColumn6.HeaderText = "SaleType_ID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Discount_ID";
            this.dataGridViewTextBoxColumn8.HeaderText = "Discount_ID";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // saleLinesSummaryInnerJoinDTBindingSource
            // 
            this.saleLinesSummaryInnerJoinDTBindingSource.DataMember = "SaleLinesSummaryInnerJoinDT";
            this.saleLinesSummaryInnerJoinDTBindingSource.DataSource = this.dsSamsLiqourShop;
            // 
            // saleLinesSummaryInnerJoinDTTableAdapter
            // 
            this.saleLinesSummaryInnerJoinDTTableAdapter.ClearBeforeFill = true;
            // 
            // saleLinesSummaryInnerJoinDTDataGridView
            // 
            this.saleLinesSummaryInnerJoinDTDataGridView.AllowUserToAddRows = false;
            this.saleLinesSummaryInnerJoinDTDataGridView.AllowUserToDeleteRows = false;
            this.saleLinesSummaryInnerJoinDTDataGridView.AutoGenerateColumns = false;
            this.saleLinesSummaryInnerJoinDTDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.saleLinesSummaryInnerJoinDTDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.saleLinesSummaryInnerJoinDTDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Product_Image,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn20,
            this.dataGridViewTextBoxColumn21,
            this.dataGridViewTextBoxColumn22,
            this.dataGridViewTextBoxColumn23,
            this.dataGridViewTextBoxColumn24,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn19});
            this.saleLinesSummaryInnerJoinDTDataGridView.DataSource = this.saleLinesSummaryInnerJoinDTBindingSource;
            this.saleLinesSummaryInnerJoinDTDataGridView.Location = new System.Drawing.Point(33, 491);
            this.saleLinesSummaryInnerJoinDTDataGridView.Name = "saleLinesSummaryInnerJoinDTDataGridView";
            this.saleLinesSummaryInnerJoinDTDataGridView.ReadOnly = true;
            this.saleLinesSummaryInnerJoinDTDataGridView.Size = new System.Drawing.Size(1077, 154);
            this.saleLinesSummaryInnerJoinDTDataGridView.TabIndex = 8;
            // 
            // Product_Image
            // 
            this.Product_Image.DataPropertyName = "Product_Image";
            this.Product_Image.FillWeight = 40F;
            this.Product_Image.HeaderText = "Product";
            this.Product_Image.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Product_Image.Name = "Product_Image";
            this.Product_Image.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "Product_Name";
            this.dataGridViewTextBoxColumn18.FillWeight = 200F;
            this.dataGridViewTextBoxColumn18.HeaderText = "Item Description";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "Product_Discount_Name";
            this.dataGridViewTextBoxColumn20.HeaderText = "Item Deal";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "SaleLine_Quantity";
            this.dataGridViewTextBoxColumn21.FillWeight = 50F;
            this.dataGridViewTextBoxColumn21.HeaderText = "Quantity";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.DataPropertyName = "SaleLine_OriginalUnitPrice";
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.dataGridViewTextBoxColumn22.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn22.HeaderText = "Base Price";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.DataPropertyName = "SaleLine_UnitPriceAfterDiscount";
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.dataGridViewTextBoxColumn23.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn23.HeaderText = "Final Unit Price";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.DataPropertyName = "SaleLine_Subtotal";
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = null;
            this.dataGridViewTextBoxColumn24.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn24.HeaderText = "Line Total";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "Sale_ID";
            this.dataGridViewTextBoxColumn16.HeaderText = "Sale_ID";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.Visible = false;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "Product_ID";
            this.dataGridViewTextBoxColumn17.HeaderText = "Product_ID";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Visible = false;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "Discount_ID";
            this.dataGridViewTextBoxColumn19.HeaderText = "Discount_ID";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            this.dataGridViewTextBoxColumn19.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "View Sales History && Transaction Details";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(455, 66);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(470, 35);
            this.txtSearch.TabIndex = 10;
            this.txtSearch.Text = "Search by Customer, Employee or Promo...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = global::TheByteClubPOS.Properties.Resources.ClearIcon;
            this.btnClear.Location = new System.Drawing.Point(934, 64);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(79, 38);
            this.btnClear.TabIndex = 11;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::TheByteClubPOS.Properties.Resources.RefreshIcon;
            this.btnRefresh.Location = new System.Drawing.Point(1022, 64);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(39, 38);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Image = global::TheByteClubPOS.Properties.Resources.HelpIcon;
            this.btnHelp.Location = new System.Drawing.Point(1071, 64);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(39, 37);
            this.btnHelp.TabIndex = 33;
            this.btnHelp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Location = new System.Drawing.Point(690, 119);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(235, 21);
            this.dtpStartDate.TabIndex = 34;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Location = new System.Drawing.Point(690, 146);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(235, 21);
            this.dtpEndDate.TabIndex = 35;
            this.dtpEndDate.ValueChanged += new System.EventHandler(this.dtpEndDate_ValueChanged);
            // 
            // btnFilterDate
            // 
            this.btnFilterDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilterDate.Image = global::TheByteClubPOS.Properties.Resources.FilterIcon;
            this.btnFilterDate.Location = new System.Drawing.Point(934, 119);
            this.btnFilterDate.Name = "btnFilterDate";
            this.btnFilterDate.Size = new System.Drawing.Size(176, 48);
            this.btnFilterDate.TabIndex = 36;
            this.btnFilterDate.Text = "Clear Date Filter";
            this.btnFilterDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFilterDate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFilterDate.UseVisualStyleBackColor = true;
            this.btnFilterDate.Click += new System.EventHandler(this.btnFilterDate_Click);
            // 
            // btnPDFExport
            // 
            this.btnPDFExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPDFExport.Image = global::TheByteClubPOS.Properties.Resources.PDFIcon;
            this.btnPDFExport.Location = new System.Drawing.Point(455, 119);
            this.btnPDFExport.Name = "btnPDFExport";
            this.btnPDFExport.Size = new System.Drawing.Size(229, 48);
            this.btnPDFExport.TabIndex = 37;
            this.btnPDFExport.Text = "Export to PDF";
            this.btnPDFExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPDFExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPDFExport.UseVisualStyleBackColor = true;
            this.btnPDFExport.Visible = false;
            this.btnPDFExport.Click += new System.EventHandler(this.btnPDFExport_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage_1);
            // 
            // ManageSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TheByteClubPOS.Properties.Resources.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1134, 715);
            this.Controls.Add(this.btnPDFExport);
            this.Controls.Add(this.btnFilterDate);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saleLinesSummaryInnerJoinDTDataGridView);
            this.Controls.Add(this.salesSummaryInnerJoinDTDataGridView);
            this.Controls.Add(this.lblTransactionDetails);
            this.Controls.Add(this.lblManageSales);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManageSales";
            this.Text = "Sales";
            this.Load += new System.EventHandler(this.ManageSales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsSamsLiqourShop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesSummaryInnerJoinDTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesSummaryInnerJoinDTDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleLinesSummaryInnerJoinDTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleLinesSummaryInnerJoinDTDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblManageSales;
        private System.Windows.Forms.Label lblTransactionDetails;
        private dsSamsLiqourShop dsSamsLiqourShop;
        private System.Windows.Forms.BindingSource salesSummaryInnerJoinDTBindingSource;
        private dsSamsLiqourShopTableAdapters.SalesSummaryInnerJoinDTTableAdapter salesSummaryInnerJoinDTTableAdapter;
        private dsSamsLiqourShopTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView salesSummaryInnerJoinDTDataGridView;
        private System.Windows.Forms.BindingSource saleLinesSummaryInnerJoinDTBindingSource;
        private dsSamsLiqourShopTableAdapters.SaleLinesSummaryInnerJoinDTTableAdapter saleLinesSummaryInnerJoinDTTableAdapter;
        private System.Windows.Forms.DataGridView saleLinesSummaryInnerJoinDTDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewImageColumn Product_Image;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnFilterDate;
        private System.Windows.Forms.Button btnPDFExport;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}