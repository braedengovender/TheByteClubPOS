namespace TheByteClubPOS
{
    partial class AddNewProductForm
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
            System.Windows.Forms.Label product_IDLabel;
            System.Windows.Forms.Label category_IDLabel;
            System.Windows.Forms.Label supplier_IDLabel;
            System.Windows.Forms.Label discount_IDLabel;
            System.Windows.Forms.Label product_NameLabel;
            System.Windows.Forms.Label product_DescriptionLabel;
            System.Windows.Forms.Label product_BrandLabel;
            System.Windows.Forms.Label product_TypeLabel;
            System.Windows.Forms.Label product_FlavourLabel;
            System.Windows.Forms.Label product_AlcoholPercentageLabel;
            System.Windows.Forms.Label product_OriginRegionLabel;
            System.Windows.Forms.Label product_IngredientsLabel;
            System.Windows.Forms.Label product_SizeMLLabel;
            System.Windows.Forms.Label product_BarcodeNumberLabel;
            System.Windows.Forms.Label product_SellingPriceLabel;
            System.Windows.Forms.Label product_CostPriceLabel;
            System.Windows.Forms.Label product_QuantityInStockLabel;
            System.Windows.Forms.Label product_ReorderQuantityLabel;
            System.Windows.Forms.Label product_StatusLabel;
            this.dsSamsLiqourShop = new TheByteClubPOS.dsSamsLiqourShop();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productTableAdapter = new TheByteClubPOS.dsSamsLiqourShopTableAdapters.ProductTableAdapter();
            this.tableAdapterManager = new TheByteClubPOS.dsSamsLiqourShopTableAdapters.TableAdapterManager();
            this.product_IDTextBox = new System.Windows.Forms.TextBox();
            this.product_NameTextBox = new System.Windows.Forms.TextBox();
            this.product_DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.product_BrandTextBox = new System.Windows.Forms.TextBox();
            this.product_TypeTextBox = new System.Windows.Forms.TextBox();
            this.product_FlavourTextBox = new System.Windows.Forms.TextBox();
            this.product_IngredientsTextBox = new System.Windows.Forms.TextBox();
            this.product_SizeMLTextBox = new System.Windows.Forms.TextBox();
            this.product_BarcodeNumberTextBox = new System.Windows.Forms.TextBox();
            this.lblInventory = new System.Windows.Forms.Label();
            this.lblDetails = new System.Windows.Forms.Label();
            this.lblClassificaction = new System.Windows.Forms.Label();
            this.lblPricing = new System.Windows.Forms.Label();
            this.lblBasicInformation = new System.Windows.Forms.Label();
            this.lblImage = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveProduct = new System.Windows.Forms.Button();
            this.lblProductDescription = new System.Windows.Forms.Label();
            this.lblAddNewProducts = new System.Windows.Forms.Label();
            this.btnClearImage = new System.Windows.Forms.Button();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.lblTips = new System.Windows.Forms.Label();
            this.timerTips = new System.Windows.Forms.Timer(this.components);
            this.lblProductID = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.categoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoryTableAdapter = new TheByteClubPOS.dsSamsLiqourShopTableAdapters.CategoryTableAdapter();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.supplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.supplierTableAdapter = new TheByteClubPOS.dsSamsLiqourShopTableAdapters.SupplierTableAdapter();
            this.cmbDiscount = new System.Windows.Forms.ComboBox();
            this.discountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.discountTableAdapter = new TheByteClubPOS.dsSamsLiqourShopTableAdapters.DiscountTableAdapter();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.numericUpDownQuantityInStock = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownReorderQuantity = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownAlcoholPercentage = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSellingPrice = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCostPrice = new System.Windows.Forms.NumericUpDown();
            this.lblProductHelp = new System.Windows.Forms.Label();
            this.cmbOrigin = new System.Windows.Forms.ComboBox();
            product_IDLabel = new System.Windows.Forms.Label();
            category_IDLabel = new System.Windows.Forms.Label();
            supplier_IDLabel = new System.Windows.Forms.Label();
            discount_IDLabel = new System.Windows.Forms.Label();
            product_NameLabel = new System.Windows.Forms.Label();
            product_DescriptionLabel = new System.Windows.Forms.Label();
            product_BrandLabel = new System.Windows.Forms.Label();
            product_TypeLabel = new System.Windows.Forms.Label();
            product_FlavourLabel = new System.Windows.Forms.Label();
            product_AlcoholPercentageLabel = new System.Windows.Forms.Label();
            product_OriginRegionLabel = new System.Windows.Forms.Label();
            product_IngredientsLabel = new System.Windows.Forms.Label();
            product_SizeMLLabel = new System.Windows.Forms.Label();
            product_BarcodeNumberLabel = new System.Windows.Forms.Label();
            product_SellingPriceLabel = new System.Windows.Forms.Label();
            product_CostPriceLabel = new System.Windows.Forms.Label();
            product_QuantityInStockLabel = new System.Windows.Forms.Label();
            product_ReorderQuantityLabel = new System.Windows.Forms.Label();
            product_StatusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dsSamsLiqourShop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.discountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantityInStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownReorderQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlcoholPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSellingPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCostPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // product_IDLabel
            // 
            product_IDLabel.AutoSize = true;
            product_IDLabel.BackColor = System.Drawing.Color.Transparent;
            product_IDLabel.Location = new System.Drawing.Point(532, 203);
            product_IDLabel.Name = "product_IDLabel";
            product_IDLabel.Size = new System.Drawing.Size(21, 13);
            product_IDLabel.TabIndex = 1;
            product_IDLabel.Text = "ID:";
            product_IDLabel.Visible = false;
            // 
            // category_IDLabel
            // 
            category_IDLabel.AutoSize = true;
            category_IDLabel.BackColor = System.Drawing.Color.Transparent;
            category_IDLabel.Location = new System.Drawing.Point(53, 425);
            category_IDLabel.Name = "category_IDLabel";
            category_IDLabel.Size = new System.Drawing.Size(59, 13);
            category_IDLabel.TabIndex = 3;
            category_IDLabel.Text = "Category: *";
            // 
            // supplier_IDLabel
            // 
            supplier_IDLabel.AutoSize = true;
            supplier_IDLabel.BackColor = System.Drawing.Color.Transparent;
            supplier_IDLabel.Location = new System.Drawing.Point(53, 471);
            supplier_IDLabel.Name = "supplier_IDLabel";
            supplier_IDLabel.Size = new System.Drawing.Size(55, 13);
            supplier_IDLabel.TabIndex = 5;
            supplier_IDLabel.Text = "Supplier: *";
            // 
            // discount_IDLabel
            // 
            discount_IDLabel.AutoSize = true;
            discount_IDLabel.BackColor = System.Drawing.Color.Transparent;
            discount_IDLabel.Location = new System.Drawing.Point(53, 519);
            discount_IDLabel.Name = "discount_IDLabel";
            discount_IDLabel.Size = new System.Drawing.Size(52, 13);
            discount_IDLabel.TabIndex = 7;
            discount_IDLabel.Text = "Discount:";
            // 
            // product_NameLabel
            // 
            product_NameLabel.AutoSize = true;
            product_NameLabel.BackColor = System.Drawing.Color.Transparent;
            product_NameLabel.Location = new System.Drawing.Point(55, 181);
            product_NameLabel.Name = "product_NameLabel";
            product_NameLabel.Size = new System.Drawing.Size(45, 13);
            product_NameLabel.TabIndex = 9;
            product_NameLabel.Text = "Name: *";
            // 
            // product_DescriptionLabel
            // 
            product_DescriptionLabel.AutoSize = true;
            product_DescriptionLabel.BackColor = System.Drawing.Color.Transparent;
            product_DescriptionLabel.Location = new System.Drawing.Point(356, 181);
            product_DescriptionLabel.Name = "product_DescriptionLabel";
            product_DescriptionLabel.Size = new System.Drawing.Size(63, 13);
            product_DescriptionLabel.TabIndex = 11;
            product_DescriptionLabel.Text = "Description:";
            // 
            // product_BrandLabel
            // 
            product_BrandLabel.AutoSize = true;
            product_BrandLabel.BackColor = System.Drawing.Color.Transparent;
            product_BrandLabel.Location = new System.Drawing.Point(55, 245);
            product_BrandLabel.Name = "product_BrandLabel";
            product_BrandLabel.Size = new System.Drawing.Size(38, 13);
            product_BrandLabel.TabIndex = 13;
            product_BrandLabel.Text = "Brand:";
            // 
            // product_TypeLabel
            // 
            product_TypeLabel.AutoSize = true;
            product_TypeLabel.BackColor = System.Drawing.Color.Transparent;
            product_TypeLabel.Location = new System.Drawing.Point(255, 245);
            product_TypeLabel.Name = "product_TypeLabel";
            product_TypeLabel.Size = new System.Drawing.Size(34, 13);
            product_TypeLabel.TabIndex = 15;
            product_TypeLabel.Text = "Type:";
            // 
            // product_FlavourLabel
            // 
            product_FlavourLabel.AutoSize = true;
            product_FlavourLabel.BackColor = System.Drawing.Color.Transparent;
            product_FlavourLabel.Location = new System.Drawing.Point(461, 245);
            product_FlavourLabel.Name = "product_FlavourLabel";
            product_FlavourLabel.Size = new System.Drawing.Size(45, 13);
            product_FlavourLabel.TabIndex = 17;
            product_FlavourLabel.Text = "Flavour:";
            // 
            // product_AlcoholPercentageLabel
            // 
            product_AlcoholPercentageLabel.AutoSize = true;
            product_AlcoholPercentageLabel.BackColor = System.Drawing.Color.Transparent;
            product_AlcoholPercentageLabel.Location = new System.Drawing.Point(55, 313);
            product_AlcoholPercentageLabel.Name = "product_AlcoholPercentageLabel";
            product_AlcoholPercentageLabel.Size = new System.Drawing.Size(120, 13);
            product_AlcoholPercentageLabel.TabIndex = 19;
            product_AlcoholPercentageLabel.Text = "Alcohol Percentage (%):";
            // 
            // product_OriginRegionLabel
            // 
            product_OriginRegionLabel.AutoSize = true;
            product_OriginRegionLabel.BackColor = System.Drawing.Color.Transparent;
            product_OriginRegionLabel.Location = new System.Drawing.Point(256, 313);
            product_OriginRegionLabel.Name = "product_OriginRegionLabel";
            product_OriginRegionLabel.Size = new System.Drawing.Size(79, 13);
            product_OriginRegionLabel.TabIndex = 21;
            product_OriginRegionLabel.Text = "Origin/ Region:";
            // 
            // product_IngredientsLabel
            // 
            product_IngredientsLabel.AutoSize = true;
            product_IngredientsLabel.BackColor = System.Drawing.Color.Transparent;
            product_IngredientsLabel.Location = new System.Drawing.Point(461, 313);
            product_IngredientsLabel.Name = "product_IngredientsLabel";
            product_IngredientsLabel.Size = new System.Drawing.Size(62, 13);
            product_IngredientsLabel.TabIndex = 23;
            product_IngredientsLabel.Text = "Ingredients:";
            // 
            // product_SizeMLLabel
            // 
            product_SizeMLLabel.AutoSize = true;
            product_SizeMLLabel.BackColor = System.Drawing.Color.Transparent;
            product_SizeMLLabel.Location = new System.Drawing.Point(308, 440);
            product_SizeMLLabel.Name = "product_SizeMLLabel";
            product_SizeMLLabel.Size = new System.Drawing.Size(56, 13);
            product_SizeMLLabel.TabIndex = 25;
            product_SizeMLLabel.Text = "Size (ml): *";
            // 
            // product_BarcodeNumberLabel
            // 
            product_BarcodeNumberLabel.AutoSize = true;
            product_BarcodeNumberLabel.BackColor = System.Drawing.Color.Transparent;
            product_BarcodeNumberLabel.Location = new System.Drawing.Point(432, 440);
            product_BarcodeNumberLabel.Name = "product_BarcodeNumberLabel";
            product_BarcodeNumberLabel.Size = new System.Drawing.Size(97, 13);
            product_BarcodeNumberLabel.TabIndex = 27;
            product_BarcodeNumberLabel.Text = "Barcode Number: *";
            // 
            // product_SellingPriceLabel
            // 
            product_SellingPriceLabel.AutoSize = true;
            product_SellingPriceLabel.BackColor = System.Drawing.Color.Transparent;
            product_SellingPriceLabel.Location = new System.Drawing.Point(608, 440);
            product_SellingPriceLabel.Name = "product_SellingPriceLabel";
            product_SellingPriceLabel.Size = new System.Drawing.Size(92, 13);
            product_SellingPriceLabel.TabIndex = 29;
            product_SellingPriceLabel.Text = "Selling Price (R): *";
            // 
            // product_CostPriceLabel
            // 
            product_CostPriceLabel.AutoSize = true;
            product_CostPriceLabel.BackColor = System.Drawing.Color.Transparent;
            product_CostPriceLabel.Location = new System.Drawing.Point(608, 516);
            product_CostPriceLabel.Name = "product_CostPriceLabel";
            product_CostPriceLabel.Size = new System.Drawing.Size(75, 13);
            product_CostPriceLabel.TabIndex = 31;
            product_CostPriceLabel.Text = "Cost Price (R):";
            // 
            // product_QuantityInStockLabel
            // 
            product_QuantityInStockLabel.AutoSize = true;
            product_QuantityInStockLabel.BackColor = System.Drawing.Color.Transparent;
            product_QuantityInStockLabel.Location = new System.Drawing.Point(947, 438);
            product_QuantityInStockLabel.Name = "product_QuantityInStockLabel";
            product_QuantityInStockLabel.Size = new System.Drawing.Size(99, 13);
            product_QuantityInStockLabel.TabIndex = 33;
            product_QuantityInStockLabel.Text = "Quantity In Stock: *";
            // 
            // product_ReorderQuantityLabel
            // 
            product_ReorderQuantityLabel.AutoSize = true;
            product_ReorderQuantityLabel.BackColor = System.Drawing.Color.Transparent;
            product_ReorderQuantityLabel.Location = new System.Drawing.Point(947, 516);
            product_ReorderQuantityLabel.Name = "product_ReorderQuantityLabel";
            product_ReorderQuantityLabel.Size = new System.Drawing.Size(97, 13);
            product_ReorderQuantityLabel.TabIndex = 35;
            product_ReorderQuantityLabel.Text = "Reorder Quantity: *";
            // 
            // product_StatusLabel
            // 
            product_StatusLabel.AutoSize = true;
            product_StatusLabel.BackColor = System.Drawing.Color.Transparent;
            product_StatusLabel.Location = new System.Drawing.Point(308, 515);
            product_StatusLabel.Name = "product_StatusLabel";
            product_StatusLabel.Size = new System.Drawing.Size(40, 13);
            product_StatusLabel.TabIndex = 37;
            product_StatusLabel.Text = "Status:";
            // 
            // dsSamsLiqourShop
            // 
            this.dsSamsLiqourShop.DataSetName = "dsSamsLiqourShop";
            this.dsSamsLiqourShop.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataMember = "Product";
            this.productBindingSource.DataSource = this.dsSamsLiqourShop;
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
            // product_IDTextBox
            // 
            this.product_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Product_ID", true));
            this.product_IDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_IDTextBox.Location = new System.Drawing.Point(599, 150);
            this.product_IDTextBox.Name = "product_IDTextBox";
            this.product_IDTextBox.ReadOnly = true;
            this.product_IDTextBox.Size = new System.Drawing.Size(52, 27);
            this.product_IDTextBox.TabIndex = 2;
            // 
            // product_NameTextBox
            // 
            this.product_NameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Product_Name", true));
            this.product_NameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_NameTextBox.Location = new System.Drawing.Point(58, 200);
            this.product_NameTextBox.Name = "product_NameTextBox";
            this.product_NameTextBox.Size = new System.Drawing.Size(282, 27);
            this.product_NameTextBox.TabIndex = 10;
            // 
            // product_DescriptionTextBox
            // 
            this.product_DescriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Product_Description", true));
            this.product_DescriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_DescriptionTextBox.Location = new System.Drawing.Point(359, 200);
            this.product_DescriptionTextBox.Name = "product_DescriptionTextBox";
            this.product_DescriptionTextBox.Size = new System.Drawing.Size(292, 27);
            this.product_DescriptionTextBox.TabIndex = 12;
            // 
            // product_BrandTextBox
            // 
            this.product_BrandTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Product_Brand", true));
            this.product_BrandTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_BrandTextBox.Location = new System.Drawing.Point(58, 265);
            this.product_BrandTextBox.Name = "product_BrandTextBox";
            this.product_BrandTextBox.Size = new System.Drawing.Size(185, 27);
            this.product_BrandTextBox.TabIndex = 14;
            // 
            // product_TypeTextBox
            // 
            this.product_TypeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Product_Type", true));
            this.product_TypeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_TypeTextBox.Location = new System.Drawing.Point(259, 265);
            this.product_TypeTextBox.Name = "product_TypeTextBox";
            this.product_TypeTextBox.Size = new System.Drawing.Size(185, 27);
            this.product_TypeTextBox.TabIndex = 16;
            // 
            // product_FlavourTextBox
            // 
            this.product_FlavourTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Product_Flavour", true));
            this.product_FlavourTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_FlavourTextBox.Location = new System.Drawing.Point(464, 265);
            this.product_FlavourTextBox.Name = "product_FlavourTextBox";
            this.product_FlavourTextBox.Size = new System.Drawing.Size(185, 27);
            this.product_FlavourTextBox.TabIndex = 18;
            // 
            // product_IngredientsTextBox
            // 
            this.product_IngredientsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Product_Ingredients", true));
            this.product_IngredientsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_IngredientsTextBox.Location = new System.Drawing.Point(464, 334);
            this.product_IngredientsTextBox.Name = "product_IngredientsTextBox";
            this.product_IngredientsTextBox.Size = new System.Drawing.Size(185, 27);
            this.product_IngredientsTextBox.TabIndex = 24;
            // 
            // product_SizeMLTextBox
            // 
            this.product_SizeMLTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Product_SizeML", true));
            this.product_SizeMLTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_SizeMLTextBox.Location = new System.Drawing.Point(311, 459);
            this.product_SizeMLTextBox.Name = "product_SizeMLTextBox";
            this.product_SizeMLTextBox.Size = new System.Drawing.Size(108, 27);
            this.product_SizeMLTextBox.TabIndex = 26;
            // 
            // product_BarcodeNumberTextBox
            // 
            this.product_BarcodeNumberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Product_BarcodeNumber", true));
            this.product_BarcodeNumberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_BarcodeNumberTextBox.Location = new System.Drawing.Point(435, 459);
            this.product_BarcodeNumberTextBox.Name = "product_BarcodeNumberTextBox";
            this.product_BarcodeNumberTextBox.Size = new System.Drawing.Size(141, 27);
            this.product_BarcodeNumberTextBox.TabIndex = 28;
            // 
            // lblInventory
            // 
            this.lblInventory.AutoSize = true;
            this.lblInventory.BackColor = System.Drawing.Color.Transparent;
            this.lblInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInventory.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblInventory.Location = new System.Drawing.Point(947, 407);
            this.lblInventory.Name = "lblInventory";
            this.lblInventory.Size = new System.Drawing.Size(70, 16);
            this.lblInventory.TabIndex = 39;
            this.lblInventory.Text = "Inventory";
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.BackColor = System.Drawing.Color.Transparent;
            this.lblDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetails.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblDetails.Location = new System.Drawing.Point(308, 407);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(56, 16);
            this.lblDetails.TabIndex = 40;
            this.lblDetails.Text = "Details";
            // 
            // lblClassificaction
            // 
            this.lblClassificaction.AutoSize = true;
            this.lblClassificaction.BackColor = System.Drawing.Color.Transparent;
            this.lblClassificaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassificaction.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblClassificaction.Location = new System.Drawing.Point(53, 407);
            this.lblClassificaction.Name = "lblClassificaction";
            this.lblClassificaction.Size = new System.Drawing.Size(100, 16);
            this.lblClassificaction.TabIndex = 41;
            this.lblClassificaction.Text = "Classification";
            // 
            // lblPricing
            // 
            this.lblPricing.AutoSize = true;
            this.lblPricing.BackColor = System.Drawing.Color.Transparent;
            this.lblPricing.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPricing.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblPricing.Location = new System.Drawing.Point(608, 407);
            this.lblPricing.Name = "lblPricing";
            this.lblPricing.Size = new System.Drawing.Size(55, 16);
            this.lblPricing.TabIndex = 42;
            this.lblPricing.Text = "Pricing";
            // 
            // lblBasicInformation
            // 
            this.lblBasicInformation.AutoSize = true;
            this.lblBasicInformation.BackColor = System.Drawing.Color.Transparent;
            this.lblBasicInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBasicInformation.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblBasicInformation.Location = new System.Drawing.Point(53, 151);
            this.lblBasicInformation.Name = "lblBasicInformation";
            this.lblBasicInformation.Size = new System.Drawing.Size(126, 16);
            this.lblBasicInformation.TabIndex = 43;
            this.lblBasicInformation.Text = "Basic Information";
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.BackColor = System.Drawing.Color.Transparent;
            this.lblImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImage.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblImage.Location = new System.Drawing.Point(691, 151);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(50, 16);
            this.lblImage.TabIndex = 44;
            this.lblImage.Text = "Image";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::TheByteClubPOS.Properties.Resources.CloseIcon;
            this.btnCancel.Location = new System.Drawing.Point(847, 83);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 38);
            this.btnCancel.TabIndex = 45;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveProduct
            // 
            this.btnSaveProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveProduct.Image = global::TheByteClubPOS.Properties.Resources.SaveIcon;
            this.btnSaveProduct.Location = new System.Drawing.Point(956, 83);
            this.btnSaveProduct.Name = "btnSaveProduct";
            this.btnSaveProduct.Size = new System.Drawing.Size(139, 38);
            this.btnSaveProduct.TabIndex = 46;
            this.btnSaveProduct.Text = "Save Product";
            this.btnSaveProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveProduct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveProduct.UseVisualStyleBackColor = true;
            this.btnSaveProduct.Click += new System.EventHandler(this.btnSaveProduct_Click);
            // 
            // lblProductDescription
            // 
            this.lblProductDescription.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblProductDescription.AutoSize = true;
            this.lblProductDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblProductDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductDescription.Location = new System.Drawing.Point(37, 144);
            this.lblProductDescription.Name = "lblProductDescription";
            this.lblProductDescription.Size = new System.Drawing.Size(290, 24);
            this.lblProductDescription.TabIndex = 47;
            this.lblProductDescription.Text = "Enter/ Edit the details of a product";
            // 
            // lblAddNewProducts
            // 
            this.lblAddNewProducts.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblAddNewProducts.AutoSize = true;
            this.lblAddNewProducts.BackColor = System.Drawing.Color.Transparent;
            this.lblAddNewProducts.Font = new System.Drawing.Font("Segoe UI", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddNewProducts.Location = new System.Drawing.Point(34, 100);
            this.lblAddNewProducts.Name = "lblAddNewProducts";
            this.lblAddNewProducts.Size = new System.Drawing.Size(260, 37);
            this.lblAddNewProducts.TabIndex = 48;
            this.lblAddNewProducts.Text = "Add/ Edit Products";
            // 
            // btnClearImage
            // 
            this.btnClearImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearImage.Image = global::TheByteClubPOS.Properties.Resources.TrashIcon;
            this.btnClearImage.Location = new System.Drawing.Point(953, 321);
            this.btnClearImage.Name = "btnClearImage";
            this.btnClearImage.Size = new System.Drawing.Size(139, 38);
            this.btnClearImage.TabIndex = 49;
            this.btnClearImage.Text = "Clear Image";
            this.btnClearImage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClearImage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClearImage.UseVisualStyleBackColor = true;
            // 
            // pbImage
            // 
            this.pbImage.BackgroundImage = global::TheByteClubPOS.Properties.Resources.SaveImage;
            this.pbImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbImage.Location = new System.Drawing.Point(694, 174);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(239, 185);
            this.pbImage.TabIndex = 50;
            this.pbImage.TabStop = false;
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveImage.Image = global::TheByteClubPOS.Properties.Resources.SaveIcon;
            this.btnSaveImage.Location = new System.Drawing.Point(953, 174);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(139, 141);
            this.btnSaveImage.TabIndex = 51;
            this.btnSaveImage.Text = "Change Image";
            this.btnSaveImage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveImage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveImage.UseVisualStyleBackColor = true;
            // 
            // lblTips
            // 
            this.lblTips.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTips.AutoSize = true;
            this.lblTips.BackColor = System.Drawing.Color.Transparent;
            this.lblTips.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTips.Location = new System.Drawing.Point(366, 103);
            this.lblTips.Name = "lblTips";
            this.lblTips.Size = new System.Drawing.Size(38, 20);
            this.lblTips.TabIndex = 52;
            this.lblTips.Text = "Tips";
            // 
            // timerTips
            // 
            this.timerTips.Enabled = true;
            this.timerTips.Interval = 5000;
            this.timerTips.Tick += new System.EventHandler(this.timerTips_Tick);
            // 
            // lblProductID
            // 
            this.lblProductID.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblProductID.AutoSize = true;
            this.lblProductID.BackColor = System.Drawing.Color.Transparent;
            this.lblProductID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductID.Location = new System.Drawing.Point(532, 200);
            this.lblProductID.Name = "lblProductID";
            this.lblProductID.Size = new System.Drawing.Size(23, 17);
            this.lblProductID.TabIndex = 53;
            this.lblProductID.Text = "ID:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.productBindingSource, "Category_ID", true));
            this.cmbCategory.DataSource = this.categoryBindingSource;
            this.cmbCategory.DisplayMember = "Category_Name";
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(56, 442);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(217, 28);
            this.cmbCategory.TabIndex = 54;
            this.cmbCategory.ValueMember = "Category_ID";
            // 
            // categoryBindingSource
            // 
            this.categoryBindingSource.DataMember = "Category";
            this.categoryBindingSource.DataSource = this.dsSamsLiqourShop;
            // 
            // categoryTableAdapter
            // 
            this.categoryTableAdapter.ClearBeforeFill = true;
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.productBindingSource, "Supplier_ID", true));
            this.cmbSupplier.DataSource = this.supplierBindingSource;
            this.cmbSupplier.DisplayMember = "Supplier_Name";
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(56, 488);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(217, 28);
            this.cmbSupplier.TabIndex = 55;
            this.cmbSupplier.ValueMember = "Supplier_ID";
            // 
            // supplierBindingSource
            // 
            this.supplierBindingSource.DataMember = "Supplier";
            this.supplierBindingSource.DataSource = this.dsSamsLiqourShop;
            // 
            // supplierTableAdapter
            // 
            this.supplierTableAdapter.ClearBeforeFill = true;
            // 
            // cmbDiscount
            // 
            this.cmbDiscount.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.productBindingSource, "Discount_ID", true));
            this.cmbDiscount.DataSource = this.discountBindingSource;
            this.cmbDiscount.DisplayMember = "Discount_Name";
            this.cmbDiscount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDiscount.FormattingEnabled = true;
            this.cmbDiscount.Location = new System.Drawing.Point(56, 535);
            this.cmbDiscount.Name = "cmbDiscount";
            this.cmbDiscount.Size = new System.Drawing.Size(217, 28);
            this.cmbDiscount.TabIndex = 56;
            this.cmbDiscount.ValueMember = "Discount_ID";
            // 
            // discountBindingSource
            // 
            this.discountBindingSource.DataMember = "Discount";
            this.discountBindingSource.DataSource = this.dsSamsLiqourShop;
            // 
            // discountTableAdapter
            // 
            this.discountTableAdapter.ClearBeforeFill = true;
            // 
            // cmbStatus
            // 
            this.cmbStatus.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.productBindingSource, "Product_Status", true));
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.cmbStatus.Location = new System.Drawing.Point(311, 535);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(195, 28);
            this.cmbStatus.TabIndex = 57;
            // 
            // numericUpDownQuantityInStock
            // 
            this.numericUpDownQuantityInStock.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.productBindingSource, "Product_QuantityInStock", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDownQuantityInStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownQuantityInStock.Location = new System.Drawing.Point(950, 462);
            this.numericUpDownQuantityInStock.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownQuantityInStock.Name = "numericUpDownQuantityInStock";
            this.numericUpDownQuantityInStock.Size = new System.Drawing.Size(142, 27);
            this.numericUpDownQuantityInStock.TabIndex = 58;
            // 
            // numericUpDownReorderQuantity
            // 
            this.numericUpDownReorderQuantity.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.productBindingSource, "Product_ReorderQuantity", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDownReorderQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownReorderQuantity.Location = new System.Drawing.Point(950, 536);
            this.numericUpDownReorderQuantity.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownReorderQuantity.Name = "numericUpDownReorderQuantity";
            this.numericUpDownReorderQuantity.Size = new System.Drawing.Size(142, 27);
            this.numericUpDownReorderQuantity.TabIndex = 59;
            // 
            // numericUpDownAlcoholPercentage
            // 
            this.numericUpDownAlcoholPercentage.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.productBindingSource, "Product_AlcoholPercentage", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDownAlcoholPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownAlcoholPercentage.Location = new System.Drawing.Point(58, 334);
            this.numericUpDownAlcoholPercentage.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownAlcoholPercentage.Name = "numericUpDownAlcoholPercentage";
            this.numericUpDownAlcoholPercentage.Size = new System.Drawing.Size(187, 27);
            this.numericUpDownAlcoholPercentage.TabIndex = 60;
            // 
            // numericUpDownSellingPrice
            // 
            this.numericUpDownSellingPrice.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.productBindingSource, "Product_SellingPrice", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "C2"));
            this.numericUpDownSellingPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownSellingPrice.Location = new System.Drawing.Point(611, 462);
            this.numericUpDownSellingPrice.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownSellingPrice.Name = "numericUpDownSellingPrice";
            this.numericUpDownSellingPrice.Size = new System.Drawing.Size(212, 27);
            this.numericUpDownSellingPrice.TabIndex = 61;
            // 
            // numericUpDownCostPrice
            // 
            this.numericUpDownCostPrice.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.productBindingSource, "Product_CostPrice", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "C2"));
            this.numericUpDownCostPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownCostPrice.Location = new System.Drawing.Point(611, 535);
            this.numericUpDownCostPrice.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownCostPrice.Name = "numericUpDownCostPrice";
            this.numericUpDownCostPrice.Size = new System.Drawing.Size(212, 27);
            this.numericUpDownCostPrice.TabIndex = 62;
            // 
            // lblProductHelp
            // 
            this.lblProductHelp.AutoSize = true;
            this.lblProductHelp.BackColor = System.Drawing.Color.Transparent;
            this.lblProductHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductHelp.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblProductHelp.Location = new System.Drawing.Point(367, 82);
            this.lblProductHelp.Name = "lblProductHelp";
            this.lblProductHelp.Size = new System.Drawing.Size(97, 16);
            this.lblProductHelp.TabIndex = 63;
            this.lblProductHelp.Text = "Product Help";
            // 
            // cmbOrigin
            // 
            this.cmbOrigin.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.productBindingSource, "Product_Status", true));
            this.cmbOrigin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrigin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOrigin.FormattingEnabled = true;
            this.cmbOrigin.Location = new System.Drawing.Point(258, 334);
            this.cmbOrigin.Name = "cmbOrigin";
            this.cmbOrigin.Size = new System.Drawing.Size(186, 28);
            this.cmbOrigin.TabIndex = 64;
            // 
            // AddNewProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TheByteClubPOS.Properties.Resources.AddNewProductFormBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1130, 662);
            this.ControlBox = false;
            this.Controls.Add(this.cmbOrigin);
            this.Controls.Add(this.lblProductHelp);
            this.Controls.Add(this.numericUpDownCostPrice);
            this.Controls.Add(this.numericUpDownSellingPrice);
            this.Controls.Add(this.numericUpDownAlcoholPercentage);
            this.Controls.Add(this.numericUpDownReorderQuantity);
            this.Controls.Add(this.numericUpDownQuantityInStock);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.cmbDiscount);
            this.Controls.Add(this.cmbSupplier);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblProductID);
            this.Controls.Add(this.lblTips);
            this.Controls.Add(this.btnSaveImage);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.btnClearImage);
            this.Controls.Add(this.lblProductDescription);
            this.Controls.Add(this.lblAddNewProducts);
            this.Controls.Add(this.btnSaveProduct);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.lblBasicInformation);
            this.Controls.Add(this.lblPricing);
            this.Controls.Add(this.lblClassificaction);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.lblInventory);
            this.Controls.Add(product_IDLabel);
            this.Controls.Add(this.product_IDTextBox);
            this.Controls.Add(category_IDLabel);
            this.Controls.Add(supplier_IDLabel);
            this.Controls.Add(discount_IDLabel);
            this.Controls.Add(product_NameLabel);
            this.Controls.Add(this.product_NameTextBox);
            this.Controls.Add(product_DescriptionLabel);
            this.Controls.Add(this.product_DescriptionTextBox);
            this.Controls.Add(product_BrandLabel);
            this.Controls.Add(this.product_BrandTextBox);
            this.Controls.Add(product_TypeLabel);
            this.Controls.Add(this.product_TypeTextBox);
            this.Controls.Add(product_FlavourLabel);
            this.Controls.Add(this.product_FlavourTextBox);
            this.Controls.Add(product_AlcoholPercentageLabel);
            this.Controls.Add(product_OriginRegionLabel);
            this.Controls.Add(product_IngredientsLabel);
            this.Controls.Add(this.product_IngredientsTextBox);
            this.Controls.Add(product_SizeMLLabel);
            this.Controls.Add(this.product_SizeMLTextBox);
            this.Controls.Add(product_BarcodeNumberLabel);
            this.Controls.Add(this.product_BarcodeNumberTextBox);
            this.Controls.Add(product_SellingPriceLabel);
            this.Controls.Add(product_CostPriceLabel);
            this.Controls.Add(product_QuantityInStockLabel);
            this.Controls.Add(product_ReorderQuantityLabel);
            this.Controls.Add(product_StatusLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddNewProductForm";
            this.ShowIcon = false;
            this.Text = "Add New Product";
            this.Load += new System.EventHandler(this.AddNewProductForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsSamsLiqourShop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.discountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantityInStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownReorderQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlcoholPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSellingPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCostPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private dsSamsLiqourShop dsSamsLiqourShop;
        private System.Windows.Forms.BindingSource productBindingSource;
        private dsSamsLiqourShopTableAdapters.ProductTableAdapter productTableAdapter;
        private dsSamsLiqourShopTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox product_IDTextBox;
        private System.Windows.Forms.TextBox product_NameTextBox;
        private System.Windows.Forms.TextBox product_DescriptionTextBox;
        private System.Windows.Forms.TextBox product_BrandTextBox;
        private System.Windows.Forms.TextBox product_TypeTextBox;
        private System.Windows.Forms.TextBox product_FlavourTextBox;
        private System.Windows.Forms.TextBox product_IngredientsTextBox;
        private System.Windows.Forms.TextBox product_SizeMLTextBox;
        private System.Windows.Forms.TextBox product_BarcodeNumberTextBox;
        private System.Windows.Forms.Label lblInventory;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.Label lblClassificaction;
        private System.Windows.Forms.Label lblPricing;
        private System.Windows.Forms.Label lblBasicInformation;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveProduct;
        private System.Windows.Forms.Label lblProductDescription;
        private System.Windows.Forms.Label lblAddNewProducts;
        private System.Windows.Forms.Button btnClearImage;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.Label lblTips;
        private System.Windows.Forms.Timer timerTips;
        private System.Windows.Forms.Label lblProductID;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.BindingSource categoryBindingSource;
        private dsSamsLiqourShopTableAdapters.CategoryTableAdapter categoryTableAdapter;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.BindingSource supplierBindingSource;
        private dsSamsLiqourShopTableAdapters.SupplierTableAdapter supplierTableAdapter;
        private System.Windows.Forms.ComboBox cmbDiscount;
        private System.Windows.Forms.BindingSource discountBindingSource;
        private dsSamsLiqourShopTableAdapters.DiscountTableAdapter discountTableAdapter;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantityInStock;
        private System.Windows.Forms.NumericUpDown numericUpDownReorderQuantity;
        private System.Windows.Forms.NumericUpDown numericUpDownAlcoholPercentage;
        private System.Windows.Forms.NumericUpDown numericUpDownSellingPrice;
        private System.Windows.Forms.NumericUpDown numericUpDownCostPrice;
        private System.Windows.Forms.Label lblProductHelp;
        private System.Windows.Forms.ComboBox cmbOrigin;
    }
}