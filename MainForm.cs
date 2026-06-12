using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheByteClubPOS.Resources;
using static TheByteClubPOS.dsSamsLiqourShop;

namespace TheByteClubPOS
{
    public partial class MainForm : Form
    {
        // Create a public property so child forms can look up here to see if dark mode is on
        public bool IsDarkMode { get; private set; }
        public int employeeID { get; set; }
        public string employeeFullName;
        public string employeeRole;

        private void ApplyRolePermissions()
        {
            // Convert to lowercase to prevent typos/case mismatch bugs
            switch (employeeRole.ToLower())
            {
                case "cashier":
                    // Hide management/admin buttons
                    btnManageSales.Visible = false;
                    btnSuppliers.Visible = false;

                    // Hide main menu items (Strip Menu components)
                    manageSalesToolStripMenuItem.Visible = false;
                    // inventoryToolStripMenuItem.Visible = false;
                    manageEmployeesToolStripMenuItem.Visible = false;
                    manageDiscountsToolStripMenuItem.Visible = false;

                    manageProducToolStripMenuItem.Visible = false;
                    processInventoryOrderToolStripMenuItem1.Visible = false;
                    break;
                case "manager":
                    btnProcessSale.Visible = false; // Managers don't process sales, so hide the button
                    processSaleToolStripMenuItem1.Visible = false; // Hide the menu item for processing sales
                    break;
                case "admin":
                    break;
                default:
                    MessageBox.Show("Unknown role detected.", "Security Warning");
                    break;
            }
        }

        public MainForm(int employeeID, bool IsDarkMode)
        {
            InitializeComponent();
            this.employeeID = employeeID;

            this.IsDarkMode = IsDarkMode; // Sync dark mode state with the login form

            var employeeTable = employeeTableAdapter.GetDataByEmployeeID(employeeID);

            if (employeeTable.Rows.Count > 0)
            {
                var employeeRow = employeeTable[0];

                this.employeeFullName = employeeRow.Employee_FirstName + " " + employeeRow.Employee_LastName;
                this.employeeRole = employeeRow.Employee_Role;

                toolStripStatusLabelUser.Text = $"Logged in as: {employeeFullName}";
                toolStripStatusLabelRole.Text = $"Role: {employeeRole}";

                ApplyRolePermissions();
            }

            toolStripStatusLabelTerminal.Text = "Terminal: POS-01";
            toolStripStatusLabelVersion.Text = "Version: 1.2";
            toolStripStatusLabelConnection.Text = "Status: Connected";

            
        }

        private void ApplyDarkMode()
        {

        }

        private void ApplyLightMode()
        {

        }

        private void OpenChildForm(Form childForm)
        {
            // Close existing child forms
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }

            // Open new child form
            childForm.MdiParent = this;

            childForm.ControlBox = false; // Removes the minimize, maximize, and close buttons
            childForm.WindowState = FormWindowState.Maximized;
            childForm.FormBorderStyle = FormBorderStyle.None;

            childForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.dsSamsLiqourShop.Employee);

            toolStripMenuItemDate.Text = DateTime.Now.ToString("dddd, dd MMM yyyy");
            toolStripMenuItemTime.Text = DateTime.Now.ToString("HH:mm:ss");
            tmrClock.Start();

            // ====== APPLY THEME ON LOAD ======
            if (this.IsDarkMode)
            {
                
                ApplyDarkMode();
                darkModeToolStripMenuItem.Text = "Light Mode"; // Set text to the opposite action
                darkModeToolStripMenuItem.Image = Properties.Resources.LightModeIcon; // Set to the light icon
            }
            else
            {
                ApplyLightMode();
                darkModeToolStripMenuItem.Text = "Dark Mode"; // Set text to the opposite action
                darkModeToolStripMenuItem.Image = Properties.Resources.DarkModeIcon; // Set to the dark icon
            }

            btnDashboard.PerformClick();

        }

        private void manageAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        private void manageSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageCustomerDetails manageCustomerDetails = new ManageCustomerDetails();
            OpenChildForm(manageCustomerDetails);
        }

        private void processSaleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            POSForm posForm = new POSForm();
            OpenChildForm(posForm);

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
            else
            {
                return;
            }

            // Close the current  form to clean up memory
            this.Close();
        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            toolStripMenuItemDate.Text = DateTime.Now.ToString("dddd, dd MMM yyyy");
            toolStripMenuItemTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            if (employeeRole.Equals("Cashier", StringComparison.OrdinalIgnoreCase))
            {
                OpenChildForm(new CashierDashboardForm(employeeID, employeeFullName));
            }
            else
            {
                OpenChildForm(new DashboardForm(employeeID, employeeFullName, employeeRole));
            }
        }

        private void btnProcessSale_Click(object sender, EventArgs e)
        {
            processSaleToolStripMenuItem1.PerformClick();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            logoutToolStripMenuItem1.PerformClick();
        }

        private void manageProductsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ManageProducts manageProducts = new ManageProducts();
            OpenChildForm(manageProducts);
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            ManageProducts manageProducts = new ManageProducts();
            manageProducts.showOnlyViewProducts();
            OpenChildForm(manageProducts);
        }

        private void manageProducToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageProductCategories manageProductCategories = new ManageProductCategories();
            OpenChildForm(manageProductCategories);
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            ViewCustomer customer = new ViewCustomer();
            OpenChildForm(customer);
        }

        private void manageCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ManageCustomerDetails manageCustomerDetails = new ManageCustomerDetails();
            OpenChildForm(manageCustomerDetails);
        }

        private void deactivateCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void manageEmployeesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ManageEmployeeDetailsForm employeeDetailsForm = new ManageEmployeeDetailsForm();


            OpenChildForm(employeeDetailsForm);
        }

        private void btnManageSales_Click(object sender, EventArgs e)
        {
            ManageSales manageSalesForm = new ManageSales();
            OpenChildForm(manageSalesForm);
        }

        private void manageSalesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ManageSales manageSales = new ManageSales();
            OpenChildForm(manageSales);
        }

        private void darkModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Flip our global state variable
            IsDarkMode = !IsDarkMode;

            if (IsDarkMode)
                ApplyDarkMode();
            else
                ApplyLightMode();

            // Update the parent form's UI text/icons
            darkModeToolStripMenuItem.Text = IsDarkMode ? "Light Mode" : "Dark Mode";
            darkModeToolStripMenuItem.Image = IsDarkMode ? Properties.Resources.LightModeIcon : Properties.Resources.DarkModeIcon;

            // IF a child form is currently active, update it immediately!
            if (this.ActiveMdiChild != null)
            {
                if (IsDarkMode)
                {
                    // Explicitly execute custom theme methods if open screen is POSForm
                    if (this.ActiveMdiChild is POSForm posForm)
                    {
                        posForm.ApplyDarkMode();
                    }
                }
                else
                {

                    if (this.ActiveMdiChild is POSForm posForm)
                    {
                        posForm.ApplyLightMode();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1() ;
            form.Show();
        }

        private void changesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manageInventoryOrdersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //HelpForm helpForm = new HelpForm();
            //OpenChildForm(helpForm);
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {

        }

        private void manageMyProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateEmployeesForm update = new UpdateEmployeesForm(employeeID);
            update.IsManageProfile = true;
            OpenChildForm(update);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm();
            helpForm.SetTabVisibility(HelpForm.HelpMode.About);
            OpenChildForm(helpForm);
        }

        private void userGuideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm();
            helpForm.SetTabVisibility(HelpForm.HelpMode.UserGuide);
            OpenChildForm(helpForm);
        }

        private void troubleshootingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm();
            helpForm.SetTabVisibility(HelpForm.HelpMode.Troubleshooting);
            OpenChildForm(helpForm);
        }

        private void manageSuppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void processInventoryOrderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ManageInventory manageinventory = new ManageInventory();
            OpenChildForm(manageinventory);
        }
    }
}
