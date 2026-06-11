namespace TheByteClubPOS
{
    partial class Form1
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
            this.dsSamsLiqourShop1 = new TheByteClubPOS.dsSamsLiqourShop();
            this.discountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.discountTableAdapter = new TheByteClubPOS.dsSamsLiqourShopTableAdapters.DiscountTableAdapter();
            this.tableAdapterManager = new TheByteClubPOS.dsSamsLiqourShopTableAdapters.TableAdapterManager();
            this.paymentMethodTableAdapter1 = new TheByteClubPOS.dsSamsLiqourShopTableAdapters.PaymentMethodTableAdapter();
            this.productTableAdapter = new TheByteClubPOS.dsSamsLiqourShopTableAdapters.ProductTableAdapter();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productDataGridView = new System.Windows.Forms.DataGridView();
            this.productIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productImageDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.productNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productBrandDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productFlavourDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productAlcoholPercentageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productOriginRegionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productIngredientsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productSizeMLDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productBarcodeNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productSellingPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productCostPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productQuantityInStockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productReorderQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dsSamsLiqourShop1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.discountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dsSamsLiqourShop1
            // 
            this.dsSamsLiqourShop1.DataSetName = "dsSamsLiqourShop";
            this.dsSamsLiqourShop1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // discountBindingSource
            // 
            this.discountBindingSource.DataMember = "Discount";
            this.discountBindingSource.DataSource = this.dsSamsLiqourShop1;
            // 
            // discountTableAdapter
            // 
            this.discountTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CategoryTableAdapter = null;
            this.tableAdapterManager.CustomerTableAdapter = null;
            this.tableAdapterManager.DiscountTableAdapter = this.discountTableAdapter;
            this.tableAdapterManager.EmployeeTableAdapter = null;
            this.tableAdapterManager.PaymentMethodTableAdapter = this.paymentMethodTableAdapter1;
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
            // paymentMethodTableAdapter1
            // 
            this.paymentMethodTableAdapter1.ClearBeforeFill = true;
            // 
            // productTableAdapter
            // 
            this.productTableAdapter.ClearBeforeFill = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(11, 166);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(236, 143);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(345, 199);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 83);
            this.button1.TabIndex = 3;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataMember = "Product";
            this.productBindingSource.DataSource = this.dsSamsLiqourShop1;
            // 
            // productDataGridView
            // 
            this.productDataGridView.AutoGenerateColumns = false;
            this.productDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productIDDataGridViewTextBoxColumn,
            this.productImageDataGridViewImageColumn,
            this.productNameDataGridViewTextBoxColumn,
            this.categoryIDDataGridViewTextBoxColumn,
            this.supplierIDDataGridViewTextBoxColumn,
            this.discountIDDataGridViewTextBoxColumn,
            this.productDescriptionDataGridViewTextBoxColumn,
            this.productBrandDataGridViewTextBoxColumn,
            this.productTypeDataGridViewTextBoxColumn,
            this.productFlavourDataGridViewTextBoxColumn,
            this.productAlcoholPercentageDataGridViewTextBoxColumn,
            this.productOriginRegionDataGridViewTextBoxColumn,
            this.productIngredientsDataGridViewTextBoxColumn,
            this.productSizeMLDataGridViewTextBoxColumn,
            this.productBarcodeNumberDataGridViewTextBoxColumn,
            this.productSellingPriceDataGridViewTextBoxColumn,
            this.productCostPriceDataGridViewTextBoxColumn,
            this.productQuantityInStockDataGridViewTextBoxColumn,
            this.productReorderQuantityDataGridViewTextBoxColumn,
            this.productStatusDataGridViewTextBoxColumn});
            this.productDataGridView.DataSource = this.productBindingSource;
            this.productDataGridView.Location = new System.Drawing.Point(11, 11);
            this.productDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.productDataGridView.Name = "productDataGridView";
            this.productDataGridView.RowHeadersWidth = 62;
            this.productDataGridView.RowTemplate.Height = 28;
            this.productDataGridView.Size = new System.Drawing.Size(582, 143);
            this.productDataGridView.TabIndex = 3;
            this.productDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.productDataGridView_DataError);
            this.productDataGridView.SelectionChanged += new System.EventHandler(this.productDataGridView_SelectionChanged);
            // 
            // productIDDataGridViewTextBoxColumn
            // 
            this.productIDDataGridViewTextBoxColumn.DataPropertyName = "Product_ID";
            this.productIDDataGridViewTextBoxColumn.HeaderText = "Product_ID";
            this.productIDDataGridViewTextBoxColumn.Name = "productIDDataGridViewTextBoxColumn";
            this.productIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productImageDataGridViewImageColumn
            // 
            this.productImageDataGridViewImageColumn.DataPropertyName = "Product_Image";
            this.productImageDataGridViewImageColumn.HeaderText = "Product_Image";
            this.productImageDataGridViewImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.productImageDataGridViewImageColumn.Name = "productImageDataGridViewImageColumn";
            // 
            // productNameDataGridViewTextBoxColumn
            // 
            this.productNameDataGridViewTextBoxColumn.DataPropertyName = "Product_Name";
            this.productNameDataGridViewTextBoxColumn.HeaderText = "Product_Name";
            this.productNameDataGridViewTextBoxColumn.Name = "productNameDataGridViewTextBoxColumn";
            // 
            // categoryIDDataGridViewTextBoxColumn
            // 
            this.categoryIDDataGridViewTextBoxColumn.DataPropertyName = "Category_ID";
            this.categoryIDDataGridViewTextBoxColumn.HeaderText = "Category_ID";
            this.categoryIDDataGridViewTextBoxColumn.Name = "categoryIDDataGridViewTextBoxColumn";
            // 
            // supplierIDDataGridViewTextBoxColumn
            // 
            this.supplierIDDataGridViewTextBoxColumn.DataPropertyName = "Supplier_ID";
            this.supplierIDDataGridViewTextBoxColumn.HeaderText = "Supplier_ID";
            this.supplierIDDataGridViewTextBoxColumn.Name = "supplierIDDataGridViewTextBoxColumn";
            // 
            // discountIDDataGridViewTextBoxColumn
            // 
            this.discountIDDataGridViewTextBoxColumn.DataPropertyName = "Discount_ID";
            this.discountIDDataGridViewTextBoxColumn.HeaderText = "Discount_ID";
            this.discountIDDataGridViewTextBoxColumn.Name = "discountIDDataGridViewTextBoxColumn";
            // 
            // productDescriptionDataGridViewTextBoxColumn
            // 
            this.productDescriptionDataGridViewTextBoxColumn.DataPropertyName = "Product_Description";
            this.productDescriptionDataGridViewTextBoxColumn.HeaderText = "Product_Description";
            this.productDescriptionDataGridViewTextBoxColumn.Name = "productDescriptionDataGridViewTextBoxColumn";
            // 
            // productBrandDataGridViewTextBoxColumn
            // 
            this.productBrandDataGridViewTextBoxColumn.DataPropertyName = "Product_Brand";
            this.productBrandDataGridViewTextBoxColumn.HeaderText = "Product_Brand";
            this.productBrandDataGridViewTextBoxColumn.Name = "productBrandDataGridViewTextBoxColumn";
            // 
            // productTypeDataGridViewTextBoxColumn
            // 
            this.productTypeDataGridViewTextBoxColumn.DataPropertyName = "Product_Type";
            this.productTypeDataGridViewTextBoxColumn.HeaderText = "Product_Type";
            this.productTypeDataGridViewTextBoxColumn.Name = "productTypeDataGridViewTextBoxColumn";
            // 
            // productFlavourDataGridViewTextBoxColumn
            // 
            this.productFlavourDataGridViewTextBoxColumn.DataPropertyName = "Product_Flavour";
            this.productFlavourDataGridViewTextBoxColumn.HeaderText = "Product_Flavour";
            this.productFlavourDataGridViewTextBoxColumn.Name = "productFlavourDataGridViewTextBoxColumn";
            // 
            // productAlcoholPercentageDataGridViewTextBoxColumn
            // 
            this.productAlcoholPercentageDataGridViewTextBoxColumn.DataPropertyName = "Product_AlcoholPercentage";
            this.productAlcoholPercentageDataGridViewTextBoxColumn.HeaderText = "Product_AlcoholPercentage";
            this.productAlcoholPercentageDataGridViewTextBoxColumn.Name = "productAlcoholPercentageDataGridViewTextBoxColumn";
            // 
            // productOriginRegionDataGridViewTextBoxColumn
            // 
            this.productOriginRegionDataGridViewTextBoxColumn.DataPropertyName = "Product_OriginRegion";
            this.productOriginRegionDataGridViewTextBoxColumn.HeaderText = "Product_OriginRegion";
            this.productOriginRegionDataGridViewTextBoxColumn.Name = "productOriginRegionDataGridViewTextBoxColumn";
            // 
            // productIngredientsDataGridViewTextBoxColumn
            // 
            this.productIngredientsDataGridViewTextBoxColumn.DataPropertyName = "Product_Ingredients";
            this.productIngredientsDataGridViewTextBoxColumn.HeaderText = "Product_Ingredients";
            this.productIngredientsDataGridViewTextBoxColumn.Name = "productIngredientsDataGridViewTextBoxColumn";
            // 
            // productSizeMLDataGridViewTextBoxColumn
            // 
            this.productSizeMLDataGridViewTextBoxColumn.DataPropertyName = "Product_SizeML";
            this.productSizeMLDataGridViewTextBoxColumn.HeaderText = "Product_SizeML";
            this.productSizeMLDataGridViewTextBoxColumn.Name = "productSizeMLDataGridViewTextBoxColumn";
            // 
            // productBarcodeNumberDataGridViewTextBoxColumn
            // 
            this.productBarcodeNumberDataGridViewTextBoxColumn.DataPropertyName = "Product_BarcodeNumber";
            this.productBarcodeNumberDataGridViewTextBoxColumn.HeaderText = "Product_BarcodeNumber";
            this.productBarcodeNumberDataGridViewTextBoxColumn.Name = "productBarcodeNumberDataGridViewTextBoxColumn";
            // 
            // productSellingPriceDataGridViewTextBoxColumn
            // 
            this.productSellingPriceDataGridViewTextBoxColumn.DataPropertyName = "Product_SellingPrice";
            this.productSellingPriceDataGridViewTextBoxColumn.HeaderText = "Product_SellingPrice";
            this.productSellingPriceDataGridViewTextBoxColumn.Name = "productSellingPriceDataGridViewTextBoxColumn";
            // 
            // productCostPriceDataGridViewTextBoxColumn
            // 
            this.productCostPriceDataGridViewTextBoxColumn.DataPropertyName = "Product_CostPrice";
            this.productCostPriceDataGridViewTextBoxColumn.HeaderText = "Product_CostPrice";
            this.productCostPriceDataGridViewTextBoxColumn.Name = "productCostPriceDataGridViewTextBoxColumn";
            // 
            // productQuantityInStockDataGridViewTextBoxColumn
            // 
            this.productQuantityInStockDataGridViewTextBoxColumn.DataPropertyName = "Product_QuantityInStock";
            this.productQuantityInStockDataGridViewTextBoxColumn.HeaderText = "Product_QuantityInStock";
            this.productQuantityInStockDataGridViewTextBoxColumn.Name = "productQuantityInStockDataGridViewTextBoxColumn";
            // 
            // productReorderQuantityDataGridViewTextBoxColumn
            // 
            this.productReorderQuantityDataGridViewTextBoxColumn.DataPropertyName = "Product_ReorderQuantity";
            this.productReorderQuantityDataGridViewTextBoxColumn.HeaderText = "Product_ReorderQuantity";
            this.productReorderQuantityDataGridViewTextBoxColumn.Name = "productReorderQuantityDataGridViewTextBoxColumn";
            // 
            // productStatusDataGridViewTextBoxColumn
            // 
            this.productStatusDataGridViewTextBoxColumn.DataPropertyName = "Product_Status";
            this.productStatusDataGridViewTextBoxColumn.HeaderText = "Product_Status";
            this.productStatusDataGridViewTextBoxColumn.Name = "productStatusDataGridViewTextBoxColumn";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 366);
            this.Controls.Add(this.productDataGridView);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsSamsLiqourShop1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.discountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private dsSamsLiqourShop dsSamsLiqourShop1;
        private System.Windows.Forms.BindingSource discountBindingSource;
        private dsSamsLiqourShopTableAdapters.DiscountTableAdapter discountTableAdapter;
        private dsSamsLiqourShopTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private dsSamsLiqourShopTableAdapters.ProductTableAdapter productTableAdapter;
        private System.Windows.Forms.BindingSource productBindingSource;
        private dsSamsLiqourShopTableAdapters.PaymentMethodTableAdapter paymentMethodTableAdapter1;
        private System.Windows.Forms.DataGridView productDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn productIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn productImageDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discountIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productBrandDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productFlavourDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productAlcoholPercentageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productOriginRegionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productIngredientsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productSizeMLDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productBarcodeNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productSellingPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productCostPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productQuantityInStockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productReorderQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productStatusDataGridViewTextBoxColumn;
    }
}