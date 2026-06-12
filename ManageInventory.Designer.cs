namespace TheByteClubPOS
{
    partial class ManageInventory
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
            this.btnClear = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.productIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productFlavourDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productAlcoholPercentageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productSizeMLDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productSellingPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productCostPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productQuantityInStockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productReorderQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsSamsLiqourShop = new TheByteClubPOS.dsSamsLiqourShop();
            this.dgvOrderItems = new System.Windows.Forms.DataGridView();
            this.colProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLineTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSupplierID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnClearItems = new System.Windows.Forms.Button();
            this.btnComplete = new System.Windows.Forms.Button();
            this.lblOrders = new System.Windows.Forms.Label();
            this.dgvPurchaseOrder = new System.Windows.Forms.DataGridView();
            this.purchaseOrderIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchaseOrderDateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchaseOrderExpectedDeliveryDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchaseOrderTotalAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchaseOrderStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchaseOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productTableAdapter = new TheByteClubPOS.dsSamsLiqourShopTableAdapters.ProductTableAdapter();
            this.purchaseOrderTableAdapter = new TheByteClubPOS.dsSamsLiqourShopTableAdapters.PurchaseOrderTableAdapter();
            this.purchaseOrderLineTableAdapter1 = new TheByteClubPOS.dsSamsLiqourShopTableAdapters.PurchaseOrderLineTableAdapter();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblItemCount = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblVat = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnLow = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSamsLiqourShop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseOrderBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(257, 66);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(93, 33);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSearch.AutoSize = true;
            this.lblSearch.BackColor = System.Drawing.Color.Transparent;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(21, 201);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(518, 24);
            this.lblSearch.TabIndex = 8;
            this.lblSearch.Text = "Product Search (by Name, Type, Brand or Barcode Number)";
            // 
            // dgvProducts
            // 
            this.dgvProducts.AutoGenerateColumns = false;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productIDDataGridViewTextBoxColumn,
            this.productNameDataGridViewTextBoxColumn,
            this.productDescriptionDataGridViewTextBoxColumn,
            this.productFlavourDataGridViewTextBoxColumn,
            this.productAlcoholPercentageDataGridViewTextBoxColumn,
            this.productSizeMLDataGridViewTextBoxColumn,
            this.productSellingPriceDataGridViewTextBoxColumn,
            this.productCostPriceDataGridViewTextBoxColumn,
            this.productQuantityInStockDataGridViewTextBoxColumn,
            this.productReorderQuantityDataGridViewTextBoxColumn,
            this.productStatusDataGridViewTextBoxColumn});
            this.dgvProducts.DataSource = this.productBindingSource;
            this.dgvProducts.Location = new System.Drawing.Point(25, 107);
            this.dgvProducts.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.RowHeadersWidth = 62;
            this.dgvProducts.RowTemplate.Height = 28;
            this.dgvProducts.Size = new System.Drawing.Size(527, 447);
            this.dgvProducts.TabIndex = 11;
            this.dgvProducts.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellContentDoubleClick);
            // 
            // productIDDataGridViewTextBoxColumn
            // 
            this.productIDDataGridViewTextBoxColumn.DataPropertyName = "Product_ID";
            this.productIDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.productIDDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.productIDDataGridViewTextBoxColumn.Name = "productIDDataGridViewTextBoxColumn";
            this.productIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.productIDDataGridViewTextBoxColumn.Width = 80;
            // 
            // productNameDataGridViewTextBoxColumn
            // 
            this.productNameDataGridViewTextBoxColumn.DataPropertyName = "Product_Name";
            this.productNameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.productNameDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.productNameDataGridViewTextBoxColumn.Name = "productNameDataGridViewTextBoxColumn";
            this.productNameDataGridViewTextBoxColumn.Width = 110;
            // 
            // productDescriptionDataGridViewTextBoxColumn
            // 
            this.productDescriptionDataGridViewTextBoxColumn.DataPropertyName = "Product_Description";
            this.productDescriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.productDescriptionDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.productDescriptionDataGridViewTextBoxColumn.Name = "productDescriptionDataGridViewTextBoxColumn";
            this.productDescriptionDataGridViewTextBoxColumn.Width = 120;
            // 
            // productFlavourDataGridViewTextBoxColumn
            // 
            this.productFlavourDataGridViewTextBoxColumn.DataPropertyName = "Product_Flavour";
            this.productFlavourDataGridViewTextBoxColumn.HeaderText = "Flavour";
            this.productFlavourDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.productFlavourDataGridViewTextBoxColumn.Name = "productFlavourDataGridViewTextBoxColumn";
            this.productFlavourDataGridViewTextBoxColumn.Width = 110;
            // 
            // productAlcoholPercentageDataGridViewTextBoxColumn
            // 
            this.productAlcoholPercentageDataGridViewTextBoxColumn.DataPropertyName = "Product_AlcoholPercentage";
            this.productAlcoholPercentageDataGridViewTextBoxColumn.HeaderText = "AlcoholPercentage";
            this.productAlcoholPercentageDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.productAlcoholPercentageDataGridViewTextBoxColumn.Name = "productAlcoholPercentageDataGridViewTextBoxColumn";
            this.productAlcoholPercentageDataGridViewTextBoxColumn.Width = 80;
            // 
            // productSizeMLDataGridViewTextBoxColumn
            // 
            this.productSizeMLDataGridViewTextBoxColumn.DataPropertyName = "Product_SizeML";
            this.productSizeMLDataGridViewTextBoxColumn.HeaderText = "SizeML";
            this.productSizeMLDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.productSizeMLDataGridViewTextBoxColumn.Name = "productSizeMLDataGridViewTextBoxColumn";
            this.productSizeMLDataGridViewTextBoxColumn.Width = 80;
            // 
            // productSellingPriceDataGridViewTextBoxColumn
            // 
            this.productSellingPriceDataGridViewTextBoxColumn.DataPropertyName = "Product_SellingPrice";
            this.productSellingPriceDataGridViewTextBoxColumn.HeaderText = "SellingPrice";
            this.productSellingPriceDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.productSellingPriceDataGridViewTextBoxColumn.Name = "productSellingPriceDataGridViewTextBoxColumn";
            this.productSellingPriceDataGridViewTextBoxColumn.Width = 150;
            // 
            // productCostPriceDataGridViewTextBoxColumn
            // 
            this.productCostPriceDataGridViewTextBoxColumn.DataPropertyName = "Product_CostPrice";
            this.productCostPriceDataGridViewTextBoxColumn.HeaderText = "CostPrice";
            this.productCostPriceDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.productCostPriceDataGridViewTextBoxColumn.Name = "productCostPriceDataGridViewTextBoxColumn";
            this.productCostPriceDataGridViewTextBoxColumn.Width = 150;
            // 
            // productQuantityInStockDataGridViewTextBoxColumn
            // 
            this.productQuantityInStockDataGridViewTextBoxColumn.DataPropertyName = "Product_QuantityInStock";
            this.productQuantityInStockDataGridViewTextBoxColumn.HeaderText = "QuantityInStock";
            this.productQuantityInStockDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.productQuantityInStockDataGridViewTextBoxColumn.Name = "productQuantityInStockDataGridViewTextBoxColumn";
            this.productQuantityInStockDataGridViewTextBoxColumn.Width = 80;
            // 
            // productReorderQuantityDataGridViewTextBoxColumn
            // 
            this.productReorderQuantityDataGridViewTextBoxColumn.DataPropertyName = "Product_ReorderQuantity";
            this.productReorderQuantityDataGridViewTextBoxColumn.HeaderText = "ReorderQuantity";
            this.productReorderQuantityDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.productReorderQuantityDataGridViewTextBoxColumn.Name = "productReorderQuantityDataGridViewTextBoxColumn";
            this.productReorderQuantityDataGridViewTextBoxColumn.Width = 110;
            // 
            // productStatusDataGridViewTextBoxColumn
            // 
            this.productStatusDataGridViewTextBoxColumn.DataPropertyName = "Product_Status";
            this.productStatusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.productStatusDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.productStatusDataGridViewTextBoxColumn.Name = "productStatusDataGridViewTextBoxColumn";
            this.productStatusDataGridViewTextBoxColumn.Width = 150;
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
            // dgvOrderItems
            // 
            this.dgvOrderItems.AllowUserToAddRows = false;
            this.dgvOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductID,
            this.colProductName,
            this.colQuantity,
            this.colUnitPrice,
            this.colLineTotal,
            this.colSupplierID});
            this.dgvOrderItems.Location = new System.Drawing.Point(573, 318);
            this.dgvOrderItems.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvOrderItems.Name = "dgvOrderItems";
            this.dgvOrderItems.RowHeadersWidth = 62;
            this.dgvOrderItems.RowTemplate.Height = 28;
            this.dgvOrderItems.Size = new System.Drawing.Size(520, 184);
            this.dgvOrderItems.TabIndex = 12;
            // 
            // colProductID
            // 
            this.colProductID.HeaderText = "ProductID";
            this.colProductID.MinimumWidth = 8;
            this.colProductID.Name = "colProductID";
            this.colProductID.Width = 150;
            // 
            // colProductName
            // 
            this.colProductName.HeaderText = "Name";
            this.colProductName.MinimumWidth = 8;
            this.colProductName.Name = "colProductName";
            this.colProductName.Width = 150;
            // 
            // colQuantity
            // 
            this.colQuantity.HeaderText = "Quantity";
            this.colQuantity.MinimumWidth = 8;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Width = 150;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.HeaderText = "UnitPrice";
            this.colUnitPrice.MinimumWidth = 8;
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.Width = 80;
            // 
            // colLineTotal
            // 
            this.colLineTotal.HeaderText = "LineTotal";
            this.colLineTotal.MinimumWidth = 8;
            this.colLineTotal.Name = "colLineTotal";
            this.colLineTotal.Width = 80;
            // 
            // colSupplierID
            // 
            this.colSupplierID.HeaderText = "SupplierID";
            this.colSupplierID.MinimumWidth = 8;
            this.colSupplierID.Name = "colSupplierID";
            this.colSupplierID.Width = 150;
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveItem.Location = new System.Drawing.Point(941, 526);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(152, 40);
            this.btnRemoveItem.TabIndex = 27;
            this.btnRemoveItem.Text = "Remove Item";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // btnClearItems
            // 
            this.btnClearItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearItems.Location = new System.Drawing.Point(941, 588);
            this.btnClearItems.Name = "btnClearItems";
            this.btnClearItems.Size = new System.Drawing.Size(152, 40);
            this.btnClearItems.TabIndex = 26;
            this.btnClearItems.Text = "Clear Items";
            this.btnClearItems.UseVisualStyleBackColor = true;
            this.btnClearItems.Click += new System.EventHandler(this.btnClearItems_Click);
            // 
            // btnComplete
            // 
            this.btnComplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComplete.Location = new System.Drawing.Point(25, 586);
            this.btnComplete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(527, 57);
            this.btnComplete.TabIndex = 29;
            this.btnComplete.Text = "Complete order";
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // lblOrders
            // 
            this.lblOrders.AutoSize = true;
            this.lblOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrders.Location = new System.Drawing.Point(569, 72);
            this.lblOrders.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOrders.Name = "lblOrders";
            this.lblOrders.Size = new System.Drawing.Size(138, 24);
            this.lblOrders.TabIndex = 30;
            this.lblOrders.Text = "Recent Orders:";
            // 
            // dgvPurchaseOrder
            // 
            this.dgvPurchaseOrder.AutoGenerateColumns = false;
            this.dgvPurchaseOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchaseOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.purchaseOrderIDDataGridViewTextBoxColumn,
            this.supplierIDDataGridViewTextBoxColumn,
            this.employeeIDDataGridViewTextBoxColumn,
            this.purchaseOrderDateTimeDataGridViewTextBoxColumn,
            this.purchaseOrderExpectedDeliveryDateDataGridViewTextBoxColumn,
            this.purchaseOrderTotalAmountDataGridViewTextBoxColumn,
            this.purchaseOrderStatusDataGridViewTextBoxColumn});
            this.dgvPurchaseOrder.DataSource = this.purchaseOrderBindingSource;
            this.dgvPurchaseOrder.Location = new System.Drawing.Point(573, 109);
            this.dgvPurchaseOrder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvPurchaseOrder.Name = "dgvPurchaseOrder";
            this.dgvPurchaseOrder.RowHeadersWidth = 62;
            this.dgvPurchaseOrder.RowTemplate.Height = 28;
            this.dgvPurchaseOrder.Size = new System.Drawing.Size(520, 182);
            this.dgvPurchaseOrder.TabIndex = 31;
            // 
            // purchaseOrderIDDataGridViewTextBoxColumn
            // 
            this.purchaseOrderIDDataGridViewTextBoxColumn.DataPropertyName = "PurchaseOrder_ID";
            this.purchaseOrderIDDataGridViewTextBoxColumn.HeaderText = "PurchaseOrder_ID";
            this.purchaseOrderIDDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.purchaseOrderIDDataGridViewTextBoxColumn.Name = "purchaseOrderIDDataGridViewTextBoxColumn";
            this.purchaseOrderIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.purchaseOrderIDDataGridViewTextBoxColumn.Width = 150;
            // 
            // supplierIDDataGridViewTextBoxColumn
            // 
            this.supplierIDDataGridViewTextBoxColumn.DataPropertyName = "Supplier_ID";
            this.supplierIDDataGridViewTextBoxColumn.HeaderText = "Supplier_ID";
            this.supplierIDDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.supplierIDDataGridViewTextBoxColumn.Name = "supplierIDDataGridViewTextBoxColumn";
            this.supplierIDDataGridViewTextBoxColumn.Width = 150;
            // 
            // employeeIDDataGridViewTextBoxColumn
            // 
            this.employeeIDDataGridViewTextBoxColumn.DataPropertyName = "Employee_ID";
            this.employeeIDDataGridViewTextBoxColumn.HeaderText = "Employee_ID";
            this.employeeIDDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.employeeIDDataGridViewTextBoxColumn.Name = "employeeIDDataGridViewTextBoxColumn";
            this.employeeIDDataGridViewTextBoxColumn.Width = 120;
            // 
            // purchaseOrderDateTimeDataGridViewTextBoxColumn
            // 
            this.purchaseOrderDateTimeDataGridViewTextBoxColumn.DataPropertyName = "PurchaseOrder_DateTime";
            this.purchaseOrderDateTimeDataGridViewTextBoxColumn.HeaderText = "DateTime";
            this.purchaseOrderDateTimeDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.purchaseOrderDateTimeDataGridViewTextBoxColumn.Name = "purchaseOrderDateTimeDataGridViewTextBoxColumn";
            this.purchaseOrderDateTimeDataGridViewTextBoxColumn.Width = 90;
            // 
            // purchaseOrderExpectedDeliveryDateDataGridViewTextBoxColumn
            // 
            this.purchaseOrderExpectedDeliveryDateDataGridViewTextBoxColumn.DataPropertyName = "PurchaseOrder_ExpectedDeliveryDate";
            this.purchaseOrderExpectedDeliveryDateDataGridViewTextBoxColumn.HeaderText = "ExpectedDeliveryDate";
            this.purchaseOrderExpectedDeliveryDateDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.purchaseOrderExpectedDeliveryDateDataGridViewTextBoxColumn.Name = "purchaseOrderExpectedDeliveryDateDataGridViewTextBoxColumn";
            this.purchaseOrderExpectedDeliveryDateDataGridViewTextBoxColumn.Width = 160;
            // 
            // purchaseOrderTotalAmountDataGridViewTextBoxColumn
            // 
            this.purchaseOrderTotalAmountDataGridViewTextBoxColumn.DataPropertyName = "PurchaseOrder_TotalAmount";
            this.purchaseOrderTotalAmountDataGridViewTextBoxColumn.HeaderText = "Total";
            this.purchaseOrderTotalAmountDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.purchaseOrderTotalAmountDataGridViewTextBoxColumn.Name = "purchaseOrderTotalAmountDataGridViewTextBoxColumn";
            this.purchaseOrderTotalAmountDataGridViewTextBoxColumn.Width = 70;
            // 
            // purchaseOrderStatusDataGridViewTextBoxColumn
            // 
            this.purchaseOrderStatusDataGridViewTextBoxColumn.DataPropertyName = "PurchaseOrder_Status";
            this.purchaseOrderStatusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.purchaseOrderStatusDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.purchaseOrderStatusDataGridViewTextBoxColumn.Name = "purchaseOrderStatusDataGridViewTextBoxColumn";
            this.purchaseOrderStatusDataGridViewTextBoxColumn.Width = 90;
            // 
            // purchaseOrderBindingSource
            // 
            this.purchaseOrderBindingSource.DataMember = "PurchaseOrder";
            this.purchaseOrderBindingSource.DataSource = this.dsSamsLiqourShop;
            // 
            // productTableAdapter
            // 
            this.productTableAdapter.ClearBeforeFill = true;
            // 
            // purchaseOrderTableAdapter
            // 
            this.purchaseOrderTableAdapter.ClearBeforeFill = true;
            // 
            // purchaseOrderLineTableAdapter1
            // 
            this.purchaseOrderLineTableAdapter1.ClearBeforeFill = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(25, 74);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(226, 20);
            this.txtSearch.TabIndex = 32;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(571, 526);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "Items";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(571, 554);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 34;
            this.label2.Text = "Subtotal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(571, 588);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 35;
            this.label3.Text = "VAT (15%)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(571, 621);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 36;
            this.label4.Text = "Total";
            // 
            // lblItemCount
            // 
            this.lblItemCount.AutoSize = true;
            this.lblItemCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemCount.Location = new System.Drawing.Point(807, 526);
            this.lblItemCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblItemCount.Name = "lblItemCount";
            this.lblItemCount.Size = new System.Drawing.Size(31, 20);
            this.lblItemCount.TabIndex = 37;
            this.lblItemCount.Text = "0.0";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(807, 554);
            this.lblSubtotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(31, 20);
            this.lblSubtotal.TabIndex = 38;
            this.lblSubtotal.Text = "0.0";
            // 
            // lblVat
            // 
            this.lblVat.AutoSize = true;
            this.lblVat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVat.Location = new System.Drawing.Point(807, 588);
            this.lblVat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVat.Name = "lblVat";
            this.lblVat.Size = new System.Drawing.Size(31, 20);
            this.lblVat.TabIndex = 39;
            this.lblVat.Text = "0.0";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(807, 621);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(31, 20);
            this.lblTotal.TabIndex = 40;
            this.lblTotal.Text = "0.0";
            // 
            // btnLow
            // 
            this.btnLow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLow.Location = new System.Drawing.Point(353, 65);
            this.btnLow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLow.Name = "btnLow";
            this.btnLow.Size = new System.Drawing.Size(112, 34);
            this.btnLow.TabIndex = 41;
            this.btnLow.Text = "Low Stock";
            this.btnLow.UseVisualStyleBackColor = true;
            this.btnLow.Click += new System.EventHandler(this.btnLow_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(469, 66);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 34);
            this.button1.TabIndex = 42;
            this.button1.Text = "All";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ManageInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TheByteClubPOS.Properties.Resources.Background;
            this.ClientSize = new System.Drawing.Size(1134, 666);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLow);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblVat);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.lblItemCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvPurchaseOrder);
            this.Controls.Add(this.lblOrders);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.btnRemoveItem);
            this.Controls.Add(this.btnClearItems);
            this.Controls.Add(this.dgvOrderItems);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblSearch);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ManageInventory";
            this.Text = "ManageInventory";
            this.Load += new System.EventHandler(this.ManageInventory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSamsLiqourShop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseOrderBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridView dgvOrderItems;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Button btnClearItems;
        private System.Windows.Forms.Button btnComplete;
        private dsSamsLiqourShop dsSamsLiqourShop;
        private System.Windows.Forms.BindingSource productBindingSource;
        private dsSamsLiqourShopTableAdapters.ProductTableAdapter productTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn productIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productFlavourDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productAlcoholPercentageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productSizeMLDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productSellingPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productCostPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productQuantityInStockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productReorderQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lblOrders;
        private System.Windows.Forms.DataGridView dgvPurchaseOrder;
        private System.Windows.Forms.BindingSource purchaseOrderBindingSource;
        private dsSamsLiqourShopTableAdapters.PurchaseOrderTableAdapter purchaseOrderTableAdapter;
        private dsSamsLiqourShopTableAdapters.PurchaseOrderLineTableAdapter purchaseOrderLineTableAdapter1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblItemCount;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblVat;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnLow;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLineTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSupplierID;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseOrderIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseOrderDateTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseOrderExpectedDeliveryDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseOrderTotalAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseOrderStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
    }
}