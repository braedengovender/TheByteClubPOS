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
            this.category_IDTextBox = new System.Windows.Forms.TextBox();
            this.supplier_IDTextBox = new System.Windows.Forms.TextBox();
            this.discount_IDTextBox = new System.Windows.Forms.TextBox();
            this.product_NameTextBox = new System.Windows.Forms.TextBox();
            this.product_DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.product_BrandTextBox = new System.Windows.Forms.TextBox();
            this.product_TypeTextBox = new System.Windows.Forms.TextBox();
            this.product_FlavourTextBox = new System.Windows.Forms.TextBox();
            this.product_AlcoholPercentageTextBox = new System.Windows.Forms.TextBox();
            this.product_OriginRegionTextBox = new System.Windows.Forms.TextBox();
            this.product_IngredientsTextBox = new System.Windows.Forms.TextBox();
            this.product_SizeMLTextBox = new System.Windows.Forms.TextBox();
            this.product_BarcodeNumberTextBox = new System.Windows.Forms.TextBox();
            this.product_SellingPriceTextBox = new System.Windows.Forms.TextBox();
            this.product_CostPriceTextBox = new System.Windows.Forms.TextBox();
            this.product_QuantityInStockTextBox = new System.Windows.Forms.TextBox();
            this.product_ReorderQuantityTextBox = new System.Windows.Forms.TextBox();
            this.product_StatusTextBox = new System.Windows.Forms.TextBox();
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
            this.SuspendLayout();
            // 
            // product_IDLabel
            // 
            product_IDLabel.AutoSize = true;
            product_IDLabel.BackColor = System.Drawing.Color.Transparent;
            product_IDLabel.Location = new System.Drawing.Point(326, 142);
            product_IDLabel.Name = "product_IDLabel";
            product_IDLabel.Size = new System.Drawing.Size(61, 13);
            product_IDLabel.TabIndex = 1;
            product_IDLabel.Text = "Product ID:";
            // 
            // category_IDLabel
            // 
            category_IDLabel.AutoSize = true;
            category_IDLabel.BackColor = System.Drawing.Color.Transparent;
            category_IDLabel.Location = new System.Drawing.Point(25, 452);
            category_IDLabel.Name = "category_IDLabel";
            category_IDLabel.Size = new System.Drawing.Size(59, 13);
            category_IDLabel.TabIndex = 3;
            category_IDLabel.Text = "Category: *";
            // 
            // supplier_IDLabel
            // 
            supplier_IDLabel.AutoSize = true;
            supplier_IDLabel.BackColor = System.Drawing.Color.Transparent;
            supplier_IDLabel.Location = new System.Drawing.Point(25, 513);
            supplier_IDLabel.Name = "supplier_IDLabel";
            supplier_IDLabel.Size = new System.Drawing.Size(55, 13);
            supplier_IDLabel.TabIndex = 5;
            supplier_IDLabel.Text = "Supplier: *";
            // 
            // discount_IDLabel
            // 
            discount_IDLabel.AutoSize = true;
            discount_IDLabel.BackColor = System.Drawing.Color.Transparent;
            discount_IDLabel.Location = new System.Drawing.Point(25, 575);
            discount_IDLabel.Name = "discount_IDLabel";
            discount_IDLabel.Size = new System.Drawing.Size(59, 13);
            discount_IDLabel.TabIndex = 7;
            discount_IDLabel.Text = "Discount: *";
            // 
            // product_NameLabel
            // 
            product_NameLabel.AutoSize = true;
            product_NameLabel.BackColor = System.Drawing.Color.Transparent;
            product_NameLabel.Location = new System.Drawing.Point(25, 177);
            product_NameLabel.Name = "product_NameLabel";
            product_NameLabel.Size = new System.Drawing.Size(45, 13);
            product_NameLabel.TabIndex = 9;
            product_NameLabel.Text = "Name: *";
            // 
            // product_DescriptionLabel
            // 
            product_DescriptionLabel.AutoSize = true;
            product_DescriptionLabel.BackColor = System.Drawing.Color.Transparent;
            product_DescriptionLabel.Location = new System.Drawing.Point(326, 177);
            product_DescriptionLabel.Name = "product_DescriptionLabel";
            product_DescriptionLabel.Size = new System.Drawing.Size(63, 13);
            product_DescriptionLabel.TabIndex = 11;
            product_DescriptionLabel.Text = "Description:";
            // 
            // product_BrandLabel
            // 
            product_BrandLabel.AutoSize = true;
            product_BrandLabel.BackColor = System.Drawing.Color.Transparent;
            product_BrandLabel.Location = new System.Drawing.Point(25, 246);
            product_BrandLabel.Name = "product_BrandLabel";
            product_BrandLabel.Size = new System.Drawing.Size(38, 13);
            product_BrandLabel.TabIndex = 13;
            product_BrandLabel.Text = "Brand:";
            // 
            // product_TypeLabel
            // 
            product_TypeLabel.AutoSize = true;
            product_TypeLabel.BackColor = System.Drawing.Color.Transparent;
            product_TypeLabel.Location = new System.Drawing.Point(240, 246);
            product_TypeLabel.Name = "product_TypeLabel";
            product_TypeLabel.Size = new System.Drawing.Size(34, 13);
            product_TypeLabel.TabIndex = 15;
            product_TypeLabel.Text = "Type:";
            // 
            // product_FlavourLabel
            // 
            product_FlavourLabel.AutoSize = true;
            product_FlavourLabel.BackColor = System.Drawing.Color.Transparent;
            product_FlavourLabel.Location = new System.Drawing.Point(457, 246);
            product_FlavourLabel.Name = "product_FlavourLabel";
            product_FlavourLabel.Size = new System.Drawing.Size(45, 13);
            product_FlavourLabel.TabIndex = 17;
            product_FlavourLabel.Text = "Flavour:";
            // 
            // product_AlcoholPercentageLabel
            // 
            product_AlcoholPercentageLabel.AutoSize = true;
            product_AlcoholPercentageLabel.BackColor = System.Drawing.Color.Transparent;
            product_AlcoholPercentageLabel.Location = new System.Drawing.Point(25, 314);
            product_AlcoholPercentageLabel.Name = "product_AlcoholPercentageLabel";
            product_AlcoholPercentageLabel.Size = new System.Drawing.Size(120, 13);
            product_AlcoholPercentageLabel.TabIndex = 19;
            product_AlcoholPercentageLabel.Text = "Alcohol Percentage (%):";
            // 
            // product_OriginRegionLabel
            // 
            product_OriginRegionLabel.AutoSize = true;
            product_OriginRegionLabel.BackColor = System.Drawing.Color.Transparent;
            product_OriginRegionLabel.Location = new System.Drawing.Point(241, 314);
            product_OriginRegionLabel.Name = "product_OriginRegionLabel";
            product_OriginRegionLabel.Size = new System.Drawing.Size(79, 13);
            product_OriginRegionLabel.TabIndex = 21;
            product_OriginRegionLabel.Text = "Origin/ Region:";
            // 
            // product_IngredientsLabel
            // 
            product_IngredientsLabel.AutoSize = true;
            product_IngredientsLabel.BackColor = System.Drawing.Color.Transparent;
            product_IngredientsLabel.Location = new System.Drawing.Point(457, 314);
            product_IngredientsLabel.Name = "product_IngredientsLabel";
            product_IngredientsLabel.Size = new System.Drawing.Size(62, 13);
            product_IngredientsLabel.TabIndex = 23;
            product_IngredientsLabel.Text = "Ingredients:";
            // 
            // product_SizeMLLabel
            // 
            product_SizeMLLabel.AutoSize = true;
            product_SizeMLLabel.BackColor = System.Drawing.Color.Transparent;
            product_SizeMLLabel.Location = new System.Drawing.Point(288, 452);
            product_SizeMLLabel.Name = "product_SizeMLLabel";
            product_SizeMLLabel.Size = new System.Drawing.Size(56, 13);
            product_SizeMLLabel.TabIndex = 25;
            product_SizeMLLabel.Text = "Size (ml): *";
            // 
            // product_BarcodeNumberLabel
            // 
            product_BarcodeNumberLabel.AutoSize = true;
            product_BarcodeNumberLabel.BackColor = System.Drawing.Color.Transparent;
            product_BarcodeNumberLabel.Location = new System.Drawing.Point(412, 452);
            product_BarcodeNumberLabel.Name = "product_BarcodeNumberLabel";
            product_BarcodeNumberLabel.Size = new System.Drawing.Size(97, 13);
            product_BarcodeNumberLabel.TabIndex = 27;
            product_BarcodeNumberLabel.Text = "Barcode Number: *";
            // 
            // product_SellingPriceLabel
            // 
            product_SellingPriceLabel.AutoSize = true;
            product_SellingPriceLabel.BackColor = System.Drawing.Color.Transparent;
            product_SellingPriceLabel.Location = new System.Drawing.Point(595, 452);
            product_SellingPriceLabel.Name = "product_SellingPriceLabel";
            product_SellingPriceLabel.Size = new System.Drawing.Size(92, 13);
            product_SellingPriceLabel.TabIndex = 29;
            product_SellingPriceLabel.Text = "Selling Price (R): *";
            // 
            // product_CostPriceLabel
            // 
            product_CostPriceLabel.AutoSize = true;
            product_CostPriceLabel.BackColor = System.Drawing.Color.Transparent;
            product_CostPriceLabel.Location = new System.Drawing.Point(758, 452);
            product_CostPriceLabel.Name = "product_CostPriceLabel";
            product_CostPriceLabel.Size = new System.Drawing.Size(75, 13);
            product_CostPriceLabel.TabIndex = 31;
            product_CostPriceLabel.Text = "Cost Price (R):";
            // 
            // product_QuantityInStockLabel
            // 
            product_QuantityInStockLabel.AutoSize = true;
            product_QuantityInStockLabel.BackColor = System.Drawing.Color.Transparent;
            product_QuantityInStockLabel.Location = new System.Drawing.Point(946, 450);
            product_QuantityInStockLabel.Name = "product_QuantityInStockLabel";
            product_QuantityInStockLabel.Size = new System.Drawing.Size(99, 13);
            product_QuantityInStockLabel.TabIndex = 33;
            product_QuantityInStockLabel.Text = "Quantity In Stock: *";
            // 
            // product_ReorderQuantityLabel
            // 
            product_ReorderQuantityLabel.AutoSize = true;
            product_ReorderQuantityLabel.BackColor = System.Drawing.Color.Transparent;
            product_ReorderQuantityLabel.Location = new System.Drawing.Point(946, 528);
            product_ReorderQuantityLabel.Name = "product_ReorderQuantityLabel";
            product_ReorderQuantityLabel.Size = new System.Drawing.Size(97, 13);
            product_ReorderQuantityLabel.TabIndex = 35;
            product_ReorderQuantityLabel.Text = "Reorder Quantity: *";
            // 
            // product_StatusLabel
            // 
            product_StatusLabel.AutoSize = true;
            product_StatusLabel.BackColor = System.Drawing.Color.Transparent;
            product_StatusLabel.Location = new System.Drawing.Point(288, 527);
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
            this.product_IDTextBox.Location = new System.Drawing.Point(393, 134);
            this.product_IDTextBox.Name = "product_IDTextBox";
            this.product_IDTextBox.Size = new System.Drawing.Size(52, 27);
            this.product_IDTextBox.TabIndex = 2;
            // 
            // category_IDTextBox
            // 
            this.category_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Category_ID", true));
            this.category_IDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_IDTextBox.Location = new System.Drawing.Point(97, 440);
            this.category_IDTextBox.Name = "category_IDTextBox";
            this.category_IDTextBox.Size = new System.Drawing.Size(48, 27);
            this.category_IDTextBox.TabIndex = 4;
            // 
            // supplier_IDTextBox
            // 
            this.supplier_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Supplier_ID", true));
            this.supplier_IDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplier_IDTextBox.Location = new System.Drawing.Point(97, 501);
            this.supplier_IDTextBox.Name = "supplier_IDTextBox";
            this.supplier_IDTextBox.Size = new System.Drawing.Size(48, 27);
            this.supplier_IDTextBox.TabIndex = 6;
            // 
            // discount_IDTextBox
            // 
            this.discount_IDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Discount_ID", true));
            this.discount_IDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discount_IDTextBox.Location = new System.Drawing.Point(97, 563);
            this.discount_IDTextBox.Name = "discount_IDTextBox";
            this.discount_IDTextBox.Size = new System.Drawing.Size(48, 27);
            this.discount_IDTextBox.TabIndex = 8;
            // 
            // product_NameTextBox
            // 
            this.product_NameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Product_Name", true));
            this.product_NameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_NameTextBox.Location = new System.Drawing.Point(28, 196);
            this.product_NameTextBox.Name = "product_NameTextBox";
            this.product_NameTextBox.Size = new System.Drawing.Size(282, 27);
            this.product_NameTextBox.TabIndex = 10;
            // 
            // product_DescriptionTextBox
            // 
            this.product_DescriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Product_Description", true));
            this.product_DescriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_DescriptionTextBox.Location = new System.Drawing.Point(329, 196);
            this.product_DescriptionTextBox.Name = "product_DescriptionTextBox";
            this.product_DescriptionTextBox.Size = new System.Drawing.Size(331, 27);
            this.product_DescriptionTextBox.TabIndex = 12;
            // 
            // product_BrandTextBox
            // 
            this.product_BrandTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Product_Brand", true));
            this.product_BrandTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_BrandTextBox.Location = new System.Drawing.Point(28, 266);
            this.product_BrandTextBox.Name = "product_BrandTextBox";
            this.product_BrandTextBox.Size = new System.Drawing.Size(198, 27);
            this.product_BrandTextBox.TabIndex = 14;
            // 
            // product_TypeTextBox
            // 
            this.product_TypeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Product_Type", true));
            this.product_TypeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_TypeTextBox.Location = new System.Drawing.Point(244, 266);
            this.product_TypeTextBox.Name = "product_TypeTextBox";
            this.product_TypeTextBox.Size = new System.Drawing.Size(198, 27);
            this.product_TypeTextBox.TabIndex = 16;
            // 
            // product_FlavourTextBox
            // 
            this.product_FlavourTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Product_Flavour", true));
            this.product_FlavourTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_FlavourTextBox.Location = new System.Drawing.Point(460, 266);
            this.product_FlavourTextBox.Name = "product_FlavourTextBox";
            this.product_FlavourTextBox.Size = new System.Drawing.Size(198, 27);
            this.product_FlavourTextBox.TabIndex = 18;
            // 
            // product_AlcoholPercentageTextBox
            // 
            this.product_AlcoholPercentageTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Product_AlcoholPercentage", true));
            this.product_AlcoholPercentageTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_AlcoholPercentageTextBox.Location = new System.Drawing.Point(28, 335);
            this.product_AlcoholPercentageTextBox.Name = "product_AlcoholPercentageTextBox";
            this.product_AlcoholPercentageTextBox.Size = new System.Drawing.Size(198, 27);
            this.product_AlcoholPercentageTextBox.TabIndex = 20;
            // 
            // product_OriginRegionTextBox
            // 
            this.product_OriginRegionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Product_OriginRegion", true));
            this.product_OriginRegionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_OriginRegionTextBox.Location = new System.Drawing.Point(243, 335);
            this.product_OriginRegionTextBox.Name = "product_OriginRegionTextBox";
            this.product_OriginRegionTextBox.Size = new System.Drawing.Size(198, 27);
            this.product_OriginRegionTextBox.TabIndex = 22;
            // 
            // product_IngredientsTextBox
            // 
            this.product_IngredientsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Product_Ingredients", true));
            this.product_IngredientsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_IngredientsTextBox.Location = new System.Drawing.Point(460, 335);
            this.product_IngredientsTextBox.Name = "product_IngredientsTextBox";
            this.product_IngredientsTextBox.Size = new System.Drawing.Size(198, 27);
            this.product_IngredientsTextBox.TabIndex = 24;
            // 
            // product_SizeMLTextBox
            // 
            this.product_SizeMLTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Product_SizeML", true));
            this.product_SizeMLTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_SizeMLTextBox.Location = new System.Drawing.Point(291, 471);
            this.product_SizeMLTextBox.Name = "product_SizeMLTextBox";
            this.product_SizeMLTextBox.Size = new System.Drawing.Size(108, 27);
            this.product_SizeMLTextBox.TabIndex = 26;
            // 
            // product_BarcodeNumberTextBox
            // 
            this.product_BarcodeNumberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Product_BarcodeNumber", true));
            this.product_BarcodeNumberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_BarcodeNumberTextBox.Location = new System.Drawing.Point(415, 471);
            this.product_BarcodeNumberTextBox.Name = "product_BarcodeNumberTextBox";
            this.product_BarcodeNumberTextBox.Size = new System.Drawing.Size(141, 27);
            this.product_BarcodeNumberTextBox.TabIndex = 28;
            // 
            // product_SellingPriceTextBox
            // 
            this.product_SellingPriceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Product_SellingPrice", true));
            this.product_SellingPriceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_SellingPriceTextBox.Location = new System.Drawing.Point(291, 547);
            this.product_SellingPriceTextBox.Name = "product_SellingPriceTextBox";
            this.product_SellingPriceTextBox.Size = new System.Drawing.Size(198, 27);
            this.product_SellingPriceTextBox.TabIndex = 30;
            // 
            // product_CostPriceTextBox
            // 
            this.product_CostPriceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Product_CostPrice", true));
            this.product_CostPriceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_CostPriceTextBox.Location = new System.Drawing.Point(598, 471);
            this.product_CostPriceTextBox.Name = "product_CostPriceTextBox";
            this.product_CostPriceTextBox.Size = new System.Drawing.Size(142, 27);
            this.product_CostPriceTextBox.TabIndex = 32;
            // 
            // product_QuantityInStockTextBox
            // 
            this.product_QuantityInStockTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Product_QuantityInStock", true));
            this.product_QuantityInStockTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_QuantityInStockTextBox.Location = new System.Drawing.Point(761, 471);
            this.product_QuantityInStockTextBox.Name = "product_QuantityInStockTextBox";
            this.product_QuantityInStockTextBox.Size = new System.Drawing.Size(152, 27);
            this.product_QuantityInStockTextBox.TabIndex = 34;
            // 
            // product_ReorderQuantityTextBox
            // 
            this.product_ReorderQuantityTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Product_ReorderQuantity", true));
            this.product_ReorderQuantityTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_ReorderQuantityTextBox.Location = new System.Drawing.Point(949, 471);
            this.product_ReorderQuantityTextBox.Name = "product_ReorderQuantityTextBox";
            this.product_ReorderQuantityTextBox.Size = new System.Drawing.Size(142, 27);
            this.product_ReorderQuantityTextBox.TabIndex = 36;
            // 
            // product_StatusTextBox
            // 
            this.product_StatusTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Product_Status", true));
            this.product_StatusTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_StatusTextBox.Location = new System.Drawing.Point(949, 547);
            this.product_StatusTextBox.Name = "product_StatusTextBox";
            this.product_StatusTextBox.Size = new System.Drawing.Size(142, 27);
            this.product_StatusTextBox.TabIndex = 38;
            // 
            // lblInventory
            // 
            this.lblInventory.AutoSize = true;
            this.lblInventory.BackColor = System.Drawing.Color.Transparent;
            this.lblInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInventory.Location = new System.Drawing.Point(946, 419);
            this.lblInventory.Name = "lblInventory";
            this.lblInventory.Size = new System.Drawing.Size(61, 16);
            this.lblInventory.TabIndex = 39;
            this.lblInventory.Text = "Inventory";
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.BackColor = System.Drawing.Color.Transparent;
            this.lblDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetails.Location = new System.Drawing.Point(288, 419);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(49, 16);
            this.lblDetails.TabIndex = 40;
            this.lblDetails.Text = "Details";
            // 
            // lblClassificaction
            // 
            this.lblClassificaction.AutoSize = true;
            this.lblClassificaction.BackColor = System.Drawing.Color.Transparent;
            this.lblClassificaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassificaction.Location = new System.Drawing.Point(25, 419);
            this.lblClassificaction.Name = "lblClassificaction";
            this.lblClassificaction.Size = new System.Drawing.Size(86, 16);
            this.lblClassificaction.TabIndex = 41;
            this.lblClassificaction.Text = "Classification";
            // 
            // lblPricing
            // 
            this.lblPricing.AutoSize = true;
            this.lblPricing.BackColor = System.Drawing.Color.Transparent;
            this.lblPricing.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPricing.Location = new System.Drawing.Point(595, 419);
            this.lblPricing.Name = "lblPricing";
            this.lblPricing.Size = new System.Drawing.Size(48, 16);
            this.lblPricing.TabIndex = 42;
            this.lblPricing.Text = "Pricing";
            // 
            // lblBasicInformation
            // 
            this.lblBasicInformation.AutoSize = true;
            this.lblBasicInformation.BackColor = System.Drawing.Color.Transparent;
            this.lblBasicInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBasicInformation.Location = new System.Drawing.Point(25, 147);
            this.lblBasicInformation.Name = "lblBasicInformation";
            this.lblBasicInformation.Size = new System.Drawing.Size(109, 16);
            this.lblBasicInformation.TabIndex = 43;
            this.lblBasicInformation.Text = "Basic Information";
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.BackColor = System.Drawing.Color.Transparent;
            this.lblImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImage.Location = new System.Drawing.Point(687, 147);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(45, 16);
            this.lblImage.TabIndex = 44;
            this.lblImage.Text = "Image";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::TheByteClubPOS.Properties.Resources.CloseIcon;
            this.btnCancel.Location = new System.Drawing.Point(843, 37);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 38);
            this.btnCancel.TabIndex = 45;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSaveProduct
            // 
            this.btnSaveProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveProduct.Image = global::TheByteClubPOS.Properties.Resources.SaveIcon;
            this.btnSaveProduct.Location = new System.Drawing.Point(952, 37);
            this.btnSaveProduct.Name = "btnSaveProduct";
            this.btnSaveProduct.Size = new System.Drawing.Size(139, 38);
            this.btnSaveProduct.TabIndex = 46;
            this.btnSaveProduct.Text = "Save Product";
            this.btnSaveProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveProduct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveProduct.UseVisualStyleBackColor = true;
            // 
            // lblProductDescription
            // 
            this.lblProductDescription.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblProductDescription.AutoSize = true;
            this.lblProductDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblProductDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductDescription.Location = new System.Drawing.Point(15, 81);
            this.lblProductDescription.Name = "lblProductDescription";
            this.lblProductDescription.Size = new System.Drawing.Size(305, 24);
            this.lblProductDescription.TabIndex = 47;
            this.lblProductDescription.Text = "Enter the details of the new product";
            // 
            // lblAddNewProducts
            // 
            this.lblAddNewProducts.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblAddNewProducts.AutoSize = true;
            this.lblAddNewProducts.BackColor = System.Drawing.Color.Transparent;
            this.lblAddNewProducts.Font = new System.Drawing.Font("Segoe UI", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddNewProducts.Location = new System.Drawing.Point(12, 37);
            this.lblAddNewProducts.Name = "lblAddNewProducts";
            this.lblAddNewProducts.Size = new System.Drawing.Size(273, 40);
            this.lblAddNewProducts.TabIndex = 48;
            this.lblAddNewProducts.Text = "Add New Products";
            // 
            // btnClearImage
            // 
            this.btnClearImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearImage.Image = global::TheByteClubPOS.Properties.Resources.TrashIcon;
            this.btnClearImage.Location = new System.Drawing.Point(949, 324);
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
            this.pbImage.Location = new System.Drawing.Point(690, 177);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(239, 185);
            this.pbImage.TabIndex = 50;
            this.pbImage.TabStop = false;
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveImage.Image = global::TheByteClubPOS.Properties.Resources.SaveIcon;
            this.btnSaveImage.Location = new System.Drawing.Point(949, 177);
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
            this.lblTips.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTips.Location = new System.Drawing.Point(372, 50);
            this.lblTips.Name = "lblTips";
            this.lblTips.Size = new System.Drawing.Size(46, 24);
            this.lblTips.TabIndex = 52;
            this.lblTips.Text = "Tips";
            // 
            // timerTips
            // 
            this.timerTips.Enabled = true;
            this.timerTips.Interval = 5000;
            this.timerTips.Tick += new System.EventHandler(this.timerTips_Tick);
            // 
            // AddNewProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TheByteClubPOS.Properties.Resources.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1134, 666);
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
            this.Controls.Add(this.category_IDTextBox);
            this.Controls.Add(supplier_IDLabel);
            this.Controls.Add(this.supplier_IDTextBox);
            this.Controls.Add(discount_IDLabel);
            this.Controls.Add(this.discount_IDTextBox);
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
            this.Controls.Add(this.product_AlcoholPercentageTextBox);
            this.Controls.Add(product_OriginRegionLabel);
            this.Controls.Add(this.product_OriginRegionTextBox);
            this.Controls.Add(product_IngredientsLabel);
            this.Controls.Add(this.product_IngredientsTextBox);
            this.Controls.Add(product_SizeMLLabel);
            this.Controls.Add(this.product_SizeMLTextBox);
            this.Controls.Add(product_BarcodeNumberLabel);
            this.Controls.Add(this.product_BarcodeNumberTextBox);
            this.Controls.Add(product_SellingPriceLabel);
            this.Controls.Add(this.product_SellingPriceTextBox);
            this.Controls.Add(product_CostPriceLabel);
            this.Controls.Add(this.product_CostPriceTextBox);
            this.Controls.Add(product_QuantityInStockLabel);
            this.Controls.Add(this.product_QuantityInStockTextBox);
            this.Controls.Add(product_ReorderQuantityLabel);
            this.Controls.Add(this.product_ReorderQuantityTextBox);
            this.Controls.Add(product_StatusLabel);
            this.Controls.Add(this.product_StatusTextBox);
            this.Name = "AddNewProductForm";
            this.Text = "Add New Product";
            this.Load += new System.EventHandler(this.AddNewProductForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsSamsLiqourShop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private dsSamsLiqourShop dsSamsLiqourShop;
        private System.Windows.Forms.BindingSource productBindingSource;
        private dsSamsLiqourShopTableAdapters.ProductTableAdapter productTableAdapter;
        private dsSamsLiqourShopTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox product_IDTextBox;
        private System.Windows.Forms.TextBox category_IDTextBox;
        private System.Windows.Forms.TextBox supplier_IDTextBox;
        private System.Windows.Forms.TextBox discount_IDTextBox;
        private System.Windows.Forms.TextBox product_NameTextBox;
        private System.Windows.Forms.TextBox product_DescriptionTextBox;
        private System.Windows.Forms.TextBox product_BrandTextBox;
        private System.Windows.Forms.TextBox product_TypeTextBox;
        private System.Windows.Forms.TextBox product_FlavourTextBox;
        private System.Windows.Forms.TextBox product_AlcoholPercentageTextBox;
        private System.Windows.Forms.TextBox product_OriginRegionTextBox;
        private System.Windows.Forms.TextBox product_IngredientsTextBox;
        private System.Windows.Forms.TextBox product_SizeMLTextBox;
        private System.Windows.Forms.TextBox product_BarcodeNumberTextBox;
        private System.Windows.Forms.TextBox product_SellingPriceTextBox;
        private System.Windows.Forms.TextBox product_CostPriceTextBox;
        private System.Windows.Forms.TextBox product_QuantityInStockTextBox;
        private System.Windows.Forms.TextBox product_ReorderQuantityTextBox;
        private System.Windows.Forms.TextBox product_StatusTextBox;
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
    }
}