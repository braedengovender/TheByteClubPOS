using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheByteClubPOS
{
    public partial class AddNewProductForm : Form
    {
        // Define the available modes
        public enum FormMode
        {
            Add,
            Edit
        }

        // 2. Class-level variables to store the passed-in data
        private FormMode currentMode;
        private int currentProductID;

        private int currentTip = 0;
        private string[] tips =
        {
            "💡 Use the barcode search for faster product lookup.",
            "💡 Review low-stock products daily on your dashboard.",
            "💡 Export reports to Excel for analysis.",
            "💡 Check the dashboard for sales insights.",
            "💡 Inactive products are not eligible for sale.",
        };

        public AddNewProductForm(FormMode mode, int productID = -1)
        {
            InitializeComponent();
            this.currentMode = mode;
            this.currentProductID = productID;
        }

        private void SetupUI()
        {
            if (currentMode == FormMode.Add)
            {
                this.Text = "Add New Product"; // Changes the window title
                                               // (Assuming your save button is named btnSave)

                // lblTitle.Text = "Create a New Record";
                lblProductID.Visible = false; // Hides the product ID label
                product_IDTextBox.Visible = false; // Hides the product ID textbox
            }
            else if (currentMode == FormMode.Edit)
            {
                this.Text = "Edit Product Details"; // Changes the window title

                // Hide components that shouldn't be changed during an edit
                // txtBarcode.Enabled = false; 

                lblProductID.Visible = true;
            }
        }

        private void LoadData()
        {
            // First, load the data into memory
            this.productTableAdapter.Fill(this.dsSamsLiqourShop.Product);

            if (currentMode == FormMode.Add)
            {
                // Prepare a blank canvas for a new record
                this.productBindingSource.AddNew(); // Forces the form to clear and prepare a brand new record
            }
            else if (currentMode == FormMode.Edit)
            {
                // Find the specific row using the Primary Key and tell the form to jump to it
                int rowIndex = this.productBindingSource.Find("Product_ID", currentProductID);

                if (rowIndex > -1)
                {
                    this.productBindingSource.Position = rowIndex;
                }
                else
                {
                    MessageBox.Show("Could not locate the product record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close(); // Close if the record is missing
                }
            }
        }

        private void AddNewProductForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.Discount' table. You can move, or remove it, as needed.
            this.discountTableAdapter.Fill(this.dsSamsLiqourShop.Discount);
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.Supplier' table. You can move, or remove it, as needed.
            this.supplierTableAdapter.Fill(this.dsSamsLiqourShop.Supplier);
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.dsSamsLiqourShop.Category);
            SetupUI();
            LoadData();
            lblTips.Text = tips[0];
        }

        private void timerTips_Tick(object sender, EventArgs e)
        {
            currentTip++;

            if (currentTip >= tips.Length)
                currentTip = 0;

            lblTips.Text = tips[currentTip];
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation: Ask the user for confirmation before canceling
                DialogResult userChoice = MessageBox.Show("Are you sure you want to cancel? Any unsaved product details will be lost.",
                    "Confirm Cancel",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                // 2. If the user clicks 'No', abort the cancellation and leave the form open
                if (userChoice == DialogResult.No)
                {
                    return;
                }

                // 1. Strictly check if the parent exists and is specifically your dashboard class
                if (this.MdiParent != null && this.MdiParent is MainForm)
                {
                    // 2. Explicitly cast the generic MdiParent using direct casting (No 'var', no 'as')
                    MainForm mainForm = (MainForm)this.MdiParent;

                    // 3. Safely call the public method on the parent form
                    mainForm.LoadProductsForm();
                }

                // 4. Finally, close the form to clean up the screen
                this.Close();
            }
            catch (Exception ex)
            {
                // Global Catch: Prevents the app from crashing if the UI routing fails
                MessageBox.Show("An unexpected error occurred while trying to close the window:\n\n" + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
    }
}
