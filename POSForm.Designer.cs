namespace TheByteClubPOS
{
    partial class POSForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POSForm));
            this.productDataGridView = new System.Windows.Forms.DataGridView();
            this.productIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productImageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productBrandDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productQuantityInStockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productSellingPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsSamsLiqourShop = new TheByteClubPOS.dsSamsLiqourShop();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblCart = new System.Windows.Forms.Label();
            this.lblItemCount = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblSubtotalAmount = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.paymentMethodBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblAmountTendered = new System.Windows.Forms.Label();
            this.txtAmountTendered = new System.Windows.Forms.TextBox();
            this.btnClearCart = new System.Windows.Forms.Button();
            this.btnCompleteSale = new System.Windows.Forms.Button();
            this.lblLoyaltyProgram = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.cartDataGridView = new System.Windows.Forms.DataGridView();
            this.productIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saleLineOriginalUnitPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saleLineUnitPriceAfterDiscountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saleLineQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saleLineSubtotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cartBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnLookup = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.productTableAdapter = new TheByteClubPOS.dsSamsLiqourShopTableAdapters.ProductTableAdapter();
            this.tableAdapterManager = new TheByteClubPOS.dsSamsLiqourShopTableAdapters.TableAdapterManager();
            this.lblCount = new System.Windows.Forms.Label();
            this.paymentMethodTableAdapter = new TheByteClubPOS.dsSamsLiqourShopTableAdapters.PaymentMethodTableAdapter();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customerTableAdapter = new TheByteClubPOS.dsSamsLiqourShopTableAdapters.CustomerTableAdapter();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblCustName = new System.Windows.Forms.Label();
            this.lblLoyaltyPoints = new System.Windows.Forms.Label();
            this.lblPointsAmount = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.saleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saleTableAdapter = new TheByteClubPOS.dsSamsLiqourShopTableAdapters.SaleTableAdapter();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblVatAmount = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblDiscountAmount = new System.Windows.Forms.Label();
            this.lblVat = new System.Windows.Forms.Label();
            this.saleLineBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saleLineTableAdapter = new TheByteClubPOS.dsSamsLiqourShopTableAdapters.SaleLineTableAdapter();
            this.btnToggleTheme = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.productDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSamsLiqourShop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentMethodBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cartDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cartBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saleLineBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // productDataGridView
            // 
            this.productDataGridView.AllowUserToAddRows = false;
            this.productDataGridView.AllowUserToDeleteRows = false;
            this.productDataGridView.AllowUserToResizeColumns = false;
            this.productDataGridView.AllowUserToResizeRows = false;
            this.productDataGridView.AutoGenerateColumns = false;
            this.productDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productIDDataGridViewTextBoxColumn1,
            this.productImageDataGridViewTextBoxColumn,
            this.productNameDataGridViewTextBoxColumn1,
            this.productBrandDataGridViewTextBoxColumn,
            this.productTypeDataGridViewTextBoxColumn,
            this.productQuantityInStockDataGridViewTextBoxColumn,
            this.productSellingPriceDataGridViewTextBoxColumn});
            this.productDataGridView.DataSource = this.productBindingSource;
            this.productDataGridView.EnableHeadersVisualStyles = false;
            this.productDataGridView.Location = new System.Drawing.Point(28, 146);
            this.productDataGridView.Name = "productDataGridView";
            this.productDataGridView.ReadOnly = true;
            this.productDataGridView.RowHeadersVisible = false;
            this.productDataGridView.Size = new System.Drawing.Size(502, 375);
            this.productDataGridView.TabIndex = 1;
            this.productDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.productDataGridView_CellContentClick);
            this.productDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.productDataGridView_CellDoubleClick);
            // 
            // productIDDataGridViewTextBoxColumn1
            // 
            this.productIDDataGridViewTextBoxColumn1.DataPropertyName = "Product_ID";
            this.productIDDataGridViewTextBoxColumn1.HeaderText = "Product_ID";
            this.productIDDataGridViewTextBoxColumn1.Name = "productIDDataGridViewTextBoxColumn1";
            this.productIDDataGridViewTextBoxColumn1.ReadOnly = true;
            this.productIDDataGridViewTextBoxColumn1.Visible = false;
            // 
            // productImageDataGridViewTextBoxColumn
            // 
            this.productImageDataGridViewTextBoxColumn.DataPropertyName = "Product_Image";
            this.productImageDataGridViewTextBoxColumn.HeaderText = "Product_Image";
            this.productImageDataGridViewTextBoxColumn.Name = "productImageDataGridViewTextBoxColumn";
            this.productImageDataGridViewTextBoxColumn.ReadOnly = true;
            this.productImageDataGridViewTextBoxColumn.Visible = false;
            // 
            // productNameDataGridViewTextBoxColumn1
            // 
            this.productNameDataGridViewTextBoxColumn1.DataPropertyName = "Product_Name";
            this.productNameDataGridViewTextBoxColumn1.HeaderText = "Product";
            this.productNameDataGridViewTextBoxColumn1.Name = "productNameDataGridViewTextBoxColumn1";
            this.productNameDataGridViewTextBoxColumn1.ReadOnly = true;
            this.productNameDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.productNameDataGridViewTextBoxColumn1.Width = 242;
            // 
            // productBrandDataGridViewTextBoxColumn
            // 
            this.productBrandDataGridViewTextBoxColumn.DataPropertyName = "Product_Brand";
            this.productBrandDataGridViewTextBoxColumn.HeaderText = "Product_Brand";
            this.productBrandDataGridViewTextBoxColumn.Name = "productBrandDataGridViewTextBoxColumn";
            this.productBrandDataGridViewTextBoxColumn.ReadOnly = true;
            this.productBrandDataGridViewTextBoxColumn.Visible = false;
            // 
            // productTypeDataGridViewTextBoxColumn
            // 
            this.productTypeDataGridViewTextBoxColumn.DataPropertyName = "Product_Type";
            this.productTypeDataGridViewTextBoxColumn.HeaderText = "Product_Type";
            this.productTypeDataGridViewTextBoxColumn.Name = "productTypeDataGridViewTextBoxColumn";
            this.productTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.productTypeDataGridViewTextBoxColumn.Visible = false;
            // 
            // productQuantityInStockDataGridViewTextBoxColumn
            // 
            this.productQuantityInStockDataGridViewTextBoxColumn.DataPropertyName = "Product_QuantityInStock";
            this.productQuantityInStockDataGridViewTextBoxColumn.HeaderText = "Quantity in Stock";
            this.productQuantityInStockDataGridViewTextBoxColumn.Name = "productQuantityInStockDataGridViewTextBoxColumn";
            this.productQuantityInStockDataGridViewTextBoxColumn.ReadOnly = true;
            this.productQuantityInStockDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.productQuantityInStockDataGridViewTextBoxColumn.Width = 120;
            // 
            // productSellingPriceDataGridViewTextBoxColumn
            // 
            this.productSellingPriceDataGridViewTextBoxColumn.DataPropertyName = "Product_SellingPrice";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.productSellingPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.productSellingPriceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.productSellingPriceDataGridViewTextBoxColumn.Name = "productSellingPriceDataGridViewTextBoxColumn";
            this.productSellingPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.productSellingPriceDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.productSellingPriceDataGridViewTextBoxColumn.Width = 120;
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataMember = "Product";
            this.productBindingSource.DataSource = this.dsSamsLiqourShop;
            // 
            // dsSamsLiqourShop
            // 
            this.dsSamsLiqourShop.DataSetName = "dsSamsLiqourShop";
            this.dsSamsLiqourShop.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.DimGray;
            this.txtSearch.Location = new System.Drawing.Point(28, 91);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(332, 26);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.Text = "Search";
            this.txtSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSearch_MouseClick);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSearch.AutoSize = true;
            this.lblSearch.BackColor = System.Drawing.Color.Transparent;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(24, 44);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(518, 24);
            this.lblSearch.TabIndex = 4;
            this.lblSearch.Text = "Product Search (by Name, Type, Brand or Barcode Number)";
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(378, 84);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(152, 33);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblCart
            // 
            this.lblCart.AutoSize = true;
            this.lblCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCart.Location = new System.Drawing.Point(3, 0);
            this.lblCart.Name = "lblCart";
            this.lblCart.Size = new System.Drawing.Size(43, 24);
            this.lblCart.TabIndex = 8;
            this.lblCart.Text = "Cart";
            // 
            // lblItemCount
            // 
            this.lblItemCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblItemCount.AutoSize = true;
            this.lblItemCount.BackColor = System.Drawing.Color.Transparent;
            this.lblItemCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemCount.Location = new System.Drawing.Point(554, 91);
            this.lblItemCount.Name = "lblItemCount";
            this.lblItemCount.Size = new System.Drawing.Size(105, 24);
            this.lblItemCount.TabIndex = 9;
            this.lblItemCount.Text = "Item Count:";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(3, 5);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(87, 24);
            this.lblSubtotal.TabIndex = 10;
            this.lblSubtotal.Text = "Subtotal: ";
            // 
            // lblSubtotalAmount
            // 
            this.lblSubtotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubtotalAmount.AutoSize = true;
            this.lblSubtotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotalAmount.Location = new System.Drawing.Point(467, 5);
            this.lblSubtotalAmount.Name = "lblSubtotalAmount";
            this.lblSubtotalAmount.Size = new System.Drawing.Size(88, 24);
            this.lblSubtotalAmount.TabIndex = 11;
            this.lblSubtotalAmount.Text = "R0000.00";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(467, 95);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(88, 24);
            this.lblTotalAmount.TabIndex = 13;
            this.lblTotalAmount.Text = "R0000.00";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(3, 95);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(56, 24);
            this.lblTotal.TabIndex = 12;
            this.lblTotal.Text = "Total:";
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.BackColor = System.Drawing.Color.Transparent;
            this.lblPaymentMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentMethod.Location = new System.Drawing.Point(549, 532);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(157, 24);
            this.lblPaymentMethod.TabIndex = 14;
            this.lblPaymentMethod.Text = "Payment Method:";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.paymentMethodBindingSource;
            this.comboBox1.DisplayMember = "PaymentMethod_Name";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(911, 529);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(197, 28);
            this.comboBox1.TabIndex = 15;
            this.comboBox1.ValueMember = "PaymentMethod_ID";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // paymentMethodBindingSource
            // 
            this.paymentMethodBindingSource.DataMember = "PaymentMethod";
            this.paymentMethodBindingSource.DataSource = this.dsSamsLiqourShop;
            // 
            // lblAmountTendered
            // 
            this.lblAmountTendered.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAmountTendered.AutoSize = true;
            this.lblAmountTendered.BackColor = System.Drawing.Color.Transparent;
            this.lblAmountTendered.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountTendered.Location = new System.Drawing.Point(549, 566);
            this.lblAmountTendered.Name = "lblAmountTendered";
            this.lblAmountTendered.Size = new System.Drawing.Size(170, 24);
            this.lblAmountTendered.TabIndex = 16;
            this.lblAmountTendered.Text = "Amount Tendered:";
            // 
            // txtAmountTendered
            // 
            this.txtAmountTendered.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAmountTendered.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountTendered.Location = new System.Drawing.Point(810, 566);
            this.txtAmountTendered.Name = "txtAmountTendered";
            this.txtAmountTendered.Size = new System.Drawing.Size(301, 26);
            this.txtAmountTendered.TabIndex = 17;
            // 
            // btnClearCart
            // 
            this.btnClearCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearCart.Location = new System.Drawing.Point(959, 86);
            this.btnClearCart.Name = "btnClearCart";
            this.btnClearCart.Size = new System.Drawing.Size(152, 40);
            this.btnClearCart.TabIndex = 18;
            this.btnClearCart.Text = "Clear Cart";
            this.btnClearCart.UseVisualStyleBackColor = true;
            this.btnClearCart.Click += new System.EventHandler(this.btnClearCart_Click);
            // 
            // btnCompleteSale
            // 
            this.btnCompleteSale.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCompleteSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompleteSale.Location = new System.Drawing.Point(553, 610);
            this.btnCompleteSale.Name = "btnCompleteSale";
            this.btnCompleteSale.Size = new System.Drawing.Size(558, 40);
            this.btnCompleteSale.TabIndex = 19;
            this.btnCompleteSale.Text = "Complete Sale";
            this.btnCompleteSale.UseVisualStyleBackColor = false;
            this.btnCompleteSale.Click += new System.EventHandler(this.btnCompleteSale_Click);
            // 
            // lblLoyaltyProgram
            // 
            this.lblLoyaltyProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLoyaltyProgram.AutoSize = true;
            this.lblLoyaltyProgram.BackColor = System.Drawing.Color.Transparent;
            this.lblLoyaltyProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoyaltyProgram.Location = new System.Drawing.Point(549, 497);
            this.lblLoyaltyProgram.Name = "lblLoyaltyProgram";
            this.lblLoyaltyProgram.Size = new System.Drawing.Size(149, 24);
            this.lblLoyaltyProgram.TabIndex = 20;
            this.lblLoyaltyProgram.Text = "Loyalty Program:";
            this.lblLoyaltyProgram.Click += new System.EventHandler(this.lblLoyaltyProgram_Click);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBox1.Location = new System.Drawing.Point(912, 495);
            this.maskedTextBox1.Mask = "(999) 000-0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(119, 26);
            this.maskedTextBox1.TabIndex = 21;
            this.maskedTextBox1.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox1_MaskInputRejected);
            // 
            // cartDataGridView
            // 
            this.cartDataGridView.AllowUserToAddRows = false;
            this.cartDataGridView.AllowUserToDeleteRows = false;
            this.cartDataGridView.AutoGenerateColumns = false;
            this.cartDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cartDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productIDDataGridViewTextBoxColumn,
            this.productNameDataGridViewTextBoxColumn,
            this.saleLineOriginalUnitPriceDataGridViewTextBoxColumn,
            this.discountIDDataGridViewTextBoxColumn,
            this.discountNameDataGridViewTextBoxColumn,
            this.saleLineUnitPriceAfterDiscountDataGridViewTextBoxColumn,
            this.saleLineQuantityDataGridViewTextBoxColumn,
            this.saleLineSubtotalDataGridViewTextBoxColumn});
            this.cartDataGridView.DataSource = this.cartBindingSource;
            this.cartDataGridView.EnableHeadersVisualStyles = false;
            this.cartDataGridView.Location = new System.Drawing.Point(553, 146);
            this.cartDataGridView.Name = "cartDataGridView";
            this.cartDataGridView.ReadOnly = true;
            this.cartDataGridView.RowHeadersVisible = false;
            this.cartDataGridView.Size = new System.Drawing.Size(558, 201);
            this.cartDataGridView.TabIndex = 21;
            this.cartDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cartDataGridView_CellContentClick);
            // 
            // productIDDataGridViewTextBoxColumn
            // 
            this.productIDDataGridViewTextBoxColumn.DataPropertyName = "Product_ID";
            this.productIDDataGridViewTextBoxColumn.HeaderText = "Product_ID";
            this.productIDDataGridViewTextBoxColumn.Name = "productIDDataGridViewTextBoxColumn";
            this.productIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.productIDDataGridViewTextBoxColumn.Visible = false;
            this.productIDDataGridViewTextBoxColumn.Width = 86;
            // 
            // productNameDataGridViewTextBoxColumn
            // 
            this.productNameDataGridViewTextBoxColumn.DataPropertyName = "Product_Name";
            this.productNameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.productNameDataGridViewTextBoxColumn.Name = "productNameDataGridViewTextBoxColumn";
            this.productNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.productNameDataGridViewTextBoxColumn.Width = 180;
            // 
            // saleLineOriginalUnitPriceDataGridViewTextBoxColumn
            // 
            this.saleLineOriginalUnitPriceDataGridViewTextBoxColumn.DataPropertyName = "SaleLine_OriginalUnitPrice";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.saleLineOriginalUnitPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.saleLineOriginalUnitPriceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.saleLineOriginalUnitPriceDataGridViewTextBoxColumn.Name = "saleLineOriginalUnitPriceDataGridViewTextBoxColumn";
            this.saleLineOriginalUnitPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.saleLineOriginalUnitPriceDataGridViewTextBoxColumn.Width = 56;
            // 
            // discountIDDataGridViewTextBoxColumn
            // 
            this.discountIDDataGridViewTextBoxColumn.DataPropertyName = "Discount_ID";
            this.discountIDDataGridViewTextBoxColumn.HeaderText = "Discount_ID";
            this.discountIDDataGridViewTextBoxColumn.Name = "discountIDDataGridViewTextBoxColumn";
            this.discountIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.discountIDDataGridViewTextBoxColumn.Visible = false;
            this.discountIDDataGridViewTextBoxColumn.Width = 91;
            // 
            // discountNameDataGridViewTextBoxColumn
            // 
            this.discountNameDataGridViewTextBoxColumn.DataPropertyName = "Discount_Name";
            this.discountNameDataGridViewTextBoxColumn.HeaderText = "Discount";
            this.discountNameDataGridViewTextBoxColumn.Name = "discountNameDataGridViewTextBoxColumn";
            this.discountNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.discountNameDataGridViewTextBoxColumn.Width = 74;
            // 
            // saleLineUnitPriceAfterDiscountDataGridViewTextBoxColumn
            // 
            this.saleLineUnitPriceAfterDiscountDataGridViewTextBoxColumn.DataPropertyName = "SaleLine_UnitPriceAfterDiscount";
            this.saleLineUnitPriceAfterDiscountDataGridViewTextBoxColumn.HeaderText = "Discount Price";
            this.saleLineUnitPriceAfterDiscountDataGridViewTextBoxColumn.Name = "saleLineUnitPriceAfterDiscountDataGridViewTextBoxColumn";
            this.saleLineUnitPriceAfterDiscountDataGridViewTextBoxColumn.ReadOnly = true;
            this.saleLineUnitPriceAfterDiscountDataGridViewTextBoxColumn.Width = 101;
            // 
            // saleLineQuantityDataGridViewTextBoxColumn
            // 
            this.saleLineQuantityDataGridViewTextBoxColumn.DataPropertyName = "SaleLine_Quantity";
            this.saleLineQuantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this.saleLineQuantityDataGridViewTextBoxColumn.Name = "saleLineQuantityDataGridViewTextBoxColumn";
            this.saleLineQuantityDataGridViewTextBoxColumn.ReadOnly = true;
            this.saleLineQuantityDataGridViewTextBoxColumn.Width = 71;
            // 
            // saleLineSubtotalDataGridViewTextBoxColumn
            // 
            this.saleLineSubtotalDataGridViewTextBoxColumn.DataPropertyName = "SaleLine_Subtotal";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.saleLineSubtotalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.saleLineSubtotalDataGridViewTextBoxColumn.HeaderText = "Subtotal";
            this.saleLineSubtotalDataGridViewTextBoxColumn.Name = "saleLineSubtotalDataGridViewTextBoxColumn";
            this.saleLineSubtotalDataGridViewTextBoxColumn.ReadOnly = true;
            this.saleLineSubtotalDataGridViewTextBoxColumn.Width = 71;
            // 
            // cartBindingSource
            // 
            this.cartBindingSource.DataMember = "Cart";
            this.cartBindingSource.DataSource = this.dsSamsLiqourShop;
            // 
            // btnLookup
            // 
            this.btnLookup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLookup.Location = new System.Drawing.Point(1037, 493);
            this.btnLookup.Name = "btnLookup";
            this.btnLookup.Size = new System.Drawing.Size(71, 28);
            this.btnLookup.TabIndex = 22;
            this.btnLookup.Text = "Lookup";
            this.btnLookup.UseVisualStyleBackColor = true;
            this.btnLookup.Click += new System.EventHandler(this.btnLookup_Click);
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveItem.Location = new System.Drawing.Point(801, 86);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(152, 40);
            this.btnRemoveItem.TabIndex = 23;
            this.btnRemoveItem.Text = "Remove Item";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // productTableAdapter
            // 
            this.productTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CategoryTableAdapter = null;
            this.tableAdapterManager.CustomerTableAdapter = null;
            this.tableAdapterManager.DiscountTableAdapter = null;
            this.tableAdapterManager.EmployeeTableAdapter = null;
            this.tableAdapterManager.PaymentMethodTableAdapter = null;
            this.tableAdapterManager.PaymentTableAdapter = null;
            this.tableAdapterManager.ProductTableAdapter = this.productTableAdapter;
            this.tableAdapterManager.PurchaseOrderLineTableAdapter = null;
            this.tableAdapterManager.PurchaseOrderTableAdapter = null;
            this.tableAdapterManager.SaleLineTableAdapter = null;
            this.tableAdapterManager.SaleTableAdapter = null;
            this.tableAdapterManager.SaleTypeTableAdapter = null;
            this.tableAdapterManager.SupplierTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = TheByteClubPOS.dsSamsLiqourShopTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCount.AutoSize = true;
            this.lblCount.BackColor = System.Drawing.Color.Transparent;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(665, 91);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(20, 24);
            this.lblCount.TabIndex = 24;
            this.lblCount.Text = "0";
            // 
            // paymentMethodTableAdapter
            // 
            this.paymentMethodTableAdapter.ClearBeforeFill = true;
            // 
            // customerBindingSource
            // 
            this.customerBindingSource.DataMember = "Customer";
            this.customerBindingSource.DataSource = this.dsSamsLiqourShop;
            // 
            // customerTableAdapter
            // 
            this.customerTableAdapter.ClearBeforeFill = true;
            // 
            // lblCustomer
            // 
            this.lblCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.BackColor = System.Drawing.Color.Transparent;
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(24, 546);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(218, 24);
            this.lblCustomer.TabIndex = 26;
            this.lblCustomer.Text = "Customer Loyalty Details:";
            // 
            // lblCustName
            // 
            this.lblCustName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCustName.AutoSize = true;
            this.lblCustName.BackColor = System.Drawing.Color.Transparent;
            this.lblCustName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustName.Location = new System.Drawing.Point(24, 583);
            this.lblCustName.Name = "lblCustName";
            this.lblCustName.Size = new System.Drawing.Size(66, 24);
            this.lblCustName.TabIndex = 27;
            this.lblCustName.Text = "Name:";
            // 
            // lblLoyaltyPoints
            // 
            this.lblLoyaltyPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLoyaltyPoints.AutoSize = true;
            this.lblLoyaltyPoints.BackColor = System.Drawing.Color.Transparent;
            this.lblLoyaltyPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoyaltyPoints.Location = new System.Drawing.Point(24, 619);
            this.lblLoyaltyPoints.Name = "lblLoyaltyPoints";
            this.lblLoyaltyPoints.Size = new System.Drawing.Size(128, 24);
            this.lblLoyaltyPoints.TabIndex = 28;
            this.lblLoyaltyPoints.Text = "Loyalty Points:";
            // 
            // lblPointsAmount
            // 
            this.lblPointsAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPointsAmount.AutoSize = true;
            this.lblPointsAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblPointsAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPointsAmount.Location = new System.Drawing.Point(158, 619);
            this.lblPointsAmount.Name = "lblPointsAmount";
            this.lblPointsAmount.Size = new System.Drawing.Size(20, 24);
            this.lblPointsAmount.TabIndex = 30;
            this.lblPointsAmount.Text = "0";
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(96, 583);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(158, 24);
            this.lblName.TabIndex = 29;
            this.lblName.Text = "Walk-in Customer";
            // 
            // saleBindingSource
            // 
            this.saleBindingSource.DataMember = "Sale";
            this.saleBindingSource.DataSource = this.dsSamsLiqourShop;
            // 
            // saleTableAdapter
            // 
            this.saleTableAdapter.ClearBeforeFill = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblCart, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(553, 44);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(558, 32);
            this.tableLayoutPanel1.TabIndex = 31;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lblVatAmount, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblDiscount, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblSubtotal, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblSubtotalAmount, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblTotal, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblTotalAmount, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblDiscountAmount, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblVat, 0, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(553, 354);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.875F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.125F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(558, 119);
            this.tableLayoutPanel2.TabIndex = 32;
            // 
            // lblVatAmount
            // 
            this.lblVatAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVatAmount.AutoSize = true;
            this.lblVatAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVatAmount.Location = new System.Drawing.Point(467, 66);
            this.lblVatAmount.Name = "lblVatAmount";
            this.lblVatAmount.Size = new System.Drawing.Size(88, 24);
            this.lblVatAmount.TabIndex = 17;
            this.lblVatAmount.Text = "R0000.00";
            // 
            // lblDiscount
            // 
            this.lblDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.Location = new System.Drawing.Point(3, 37);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(88, 24);
            this.lblDiscount.TabIndex = 14;
            this.lblDiscount.Text = "Discount:";
            // 
            // lblDiscountAmount
            // 
            this.lblDiscountAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiscountAmount.AutoSize = true;
            this.lblDiscountAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountAmount.Location = new System.Drawing.Point(467, 37);
            this.lblDiscountAmount.Name = "lblDiscountAmount";
            this.lblDiscountAmount.Size = new System.Drawing.Size(88, 24);
            this.lblDiscountAmount.TabIndex = 15;
            this.lblDiscountAmount.Text = "R0000.00";
            // 
            // lblVat
            // 
            this.lblVat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVat.AutoSize = true;
            this.lblVat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVat.Location = new System.Drawing.Point(3, 66);
            this.lblVat.Name = "lblVat";
            this.lblVat.Size = new System.Drawing.Size(105, 24);
            this.lblVat.TabIndex = 16;
            this.lblVat.Text = "VAT (15%):";
            // 
            // saleLineBindingSource
            // 
            this.saleLineBindingSource.DataMember = "SaleLine";
            this.saleLineBindingSource.DataSource = this.dsSamsLiqourShop;
            // 
            // saleLineTableAdapter
            // 
            this.saleLineTableAdapter.ClearBeforeFill = true;
            // 
            // btnToggleTheme
            // 
            this.btnToggleTheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToggleTheme.Location = new System.Drawing.Point(347, 606);
            this.btnToggleTheme.Name = "btnToggleTheme";
            this.btnToggleTheme.Size = new System.Drawing.Size(183, 44);
            this.btnToggleTheme.TabIndex = 25;
            this.btnToggleTheme.Text = "Change to Dark Mode";
            this.btnToggleTheme.UseVisualStyleBackColor = true;
            this.btnToggleTheme.Visible = false;
            this.btnToggleTheme.Click += new System.EventHandler(this.btnToggleTheme_Click);
            // 
            // POSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TheByteClubPOS.Properties.Resources.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1134, 666);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblPointsAmount);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblLoyaltyPoints);
            this.Controls.Add(this.lblCustName);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.btnToggleTheme);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnRemoveItem);
            this.Controls.Add(this.btnLookup);
            this.Controls.Add(this.cartDataGridView);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.lblLoyaltyProgram);
            this.Controls.Add(this.btnCompleteSale);
            this.Controls.Add(this.btnClearCart);
            this.Controls.Add(this.txtAmountTendered);
            this.Controls.Add(this.lblAmountTendered);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblPaymentMethod);
            this.Controls.Add(this.lblItemCount);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.productDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "POSForm";
            this.Text = "POSForm";
            this.Load += new System.EventHandler(this.POSForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSamsLiqourShop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentMethodBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cartDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cartBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saleLineBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private dsSamsLiqourShop dsSamsLiqourShop;
        private System.Windows.Forms.BindingSource productBindingSource;
        private dsSamsLiqourShopTableAdapters.ProductTableAdapter productTableAdapter;
        private dsSamsLiqourShopTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView productDataGridView;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblCart;
        private System.Windows.Forms.Label lblItemCount;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblSubtotalAmount;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblAmountTendered;
        private System.Windows.Forms.TextBox txtAmountTendered;
        private System.Windows.Forms.Button btnClearCart;
        private System.Windows.Forms.Button btnCompleteSale;
        private System.Windows.Forms.Label lblLoyaltyProgram;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.BindingSource cartBindingSource;
        private System.Windows.Forms.DataGridView cartDataGridView;
        private System.Windows.Forms.Button btnLookup;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.BindingSource paymentMethodBindingSource;
        private dsSamsLiqourShopTableAdapters.PaymentMethodTableAdapter paymentMethodTableAdapter;
        private System.Windows.Forms.BindingSource customerBindingSource;
        private dsSamsLiqourShopTableAdapters.CustomerTableAdapter customerTableAdapter;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblCustName;
        private System.Windows.Forms.Label lblLoyaltyPoints;
        private System.Windows.Forms.Label lblPointsAmount;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.BindingSource saleBindingSource;
        private dsSamsLiqourShopTableAdapters.SaleTableAdapter saleTableAdapter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn productIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saleLineOriginalUnitPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discountIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discountNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saleLineUnitPriceAfterDiscountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saleLineQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saleLineSubtotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource saleLineBindingSource;
        private dsSamsLiqourShopTableAdapters.SaleLineTableAdapter saleLineTableAdapter;
        private System.Windows.Forms.Button btnToggleTheme;
        private System.Windows.Forms.Label lblVatAmount;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblDiscountAmount;
        private System.Windows.Forms.Label lblVat;
        private System.Windows.Forms.DataGridViewTextBoxColumn productIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn productImageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn productBrandDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productQuantityInStockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productSellingPriceDataGridViewTextBoxColumn;
    }
}