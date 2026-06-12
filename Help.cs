using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheByteClubPOS.Resources
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
        }

        private void Help_Load(object sender, EventArgs e)
        {

            lstUserGuide.Items.Add("Logging In");
            lstUserGuide.Items.Add("Registering a New Customer");
            lstUserGuide.Items.Add("Updating Customer Details");
            lstUserGuide.Items.Add("Processing a Sale");
            lstUserGuide.Items.Add("Redeeming Loyalty Points");
            lstUserGuide.Items.Add("Adding a New Employee");        
            lstUserGuide.Items.Add("Updating Employee Details");    
            lstUserGuide.Items.Add("Adding a New Product");         
            lstUserGuide.Items.Add("Updating Product Details");

            lstUserGuide.SelectedIndex = 0;

            lstTroubleshooting.Items.Add("Cannot Log In");
            lstTroubleshooting.Items.Add("Customer Cannot Be Found");
            lstTroubleshooting.Items.Add("Unable to Complete Sale");
            lstTroubleshooting.Items.Add("Customer Details Not Updating");
            lstTroubleshooting.Items.Add("Loyalty Points Not Added");
            lstTroubleshooting.Items.Add("Database Connection Error");

            lstTroubleshooting.SelectedIndex = 0;

            DisplayAbout();
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

        private void DisplayGuide(string title, string content)
        {
            rtbUserGuide.Clear();

            // Title
            rtbUserGuide.SelectionColor = Color.DarkGreen;
            rtbUserGuide.SelectionFont =
                new Font("Segoe UI", 14, FontStyle.Bold);

            rtbUserGuide.AppendText(title + "\n\n");

            // Content
            rtbUserGuide.SelectionColor = Color.Black;
            rtbUserGuide.SelectionFont =
                new Font("Segoe UI", 10, FontStyle.Regular);

            rtbUserGuide.AppendText(content);
        }

        private void DisplayHelpContent(string title, string content)
        {
            rtbTroubleshooting.Clear();

            rtbTroubleshooting.SelectionColor = Color.DarkRed;
            rtbTroubleshooting.SelectionFont =
                new Font("Segoe UI", 14, FontStyle.Bold);

            rtbTroubleshooting.AppendText(title + "\n\n");

            rtbTroubleshooting.SelectionColor = Color.Black;
            rtbTroubleshooting.SelectionFont =
                new Font("Segoe UI", 10, FontStyle.Regular);

            rtbTroubleshooting.AppendText(content);
        }

        private void lstUserGuide_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (lstUserGuide.SelectedIndex)
            {
                case 0:
                    DisplayGuide(
                        "LOGGING IN",
                        "1. Launch the SAMS Liquor Store POS application.\n\n" +
                        "2. Enter your username.\n\n" +
                        "3. Enter your password.\n\n" +
                        "4. Click the Login button.\n\n" +
                        "5. The Main Menu will be displayed.\n\n" +
                        "NOTE:\nContact an administrator if login fails."
                    );
                    break;

                case 1:
                    DisplayGuide(
                        "REGISTERING A NEW CUSTOMER",
                        "1. Open Manage Customer.\n\n" +
                        "2. Enter the customer's details.\n\n" +
                        "3. Click Add Customer.\n\n" +
                        "4. Click Save.\n\n" +
                        "5. The customer record will be stored successfully.\n\n" +
                        "NOTE:\nAll required fields must be completed."
                    );
                    break;

                case 2:
                    DisplayGuide(
                        "UPDATING CUSTOMER DETAILS",
                        "1. Search for the customer.\n\n" +
                        "2. Edit the required information.\n\n" +
                        "3. Click Update.\n\n" +
                        "4. Changes will be saved to the database."
                    );
                    break;

                case 3:
                    DisplayGuide(
                        "PROCESSING A SALE",
                        "1. Open Process Sale.\n\n" +
                        "2. Add products to the cart.\n\n" +
                        "3. Verify quantities and prices.\n\n" +
                        "4. Search for a customer.\n\n" +
                        "5. Select a payment method.\n\n" +
                        "6. Use loyalty points as discount as per customer request.\n\n" +
                        "7. Click Complete Sale.\n\n" +
                        "8. The transaction will be processed successfully."
                    );
                    break;

                case 4:
                    DisplayGuide(
                        "REDEEMING LOYALTY POINTS",
                        "1. Search for the customer.\n\n" +
                        "2. Verify available loyalty points.\n\n" +
                        "3. Add products to the cart.\n\n" +
                        "4. Enter loyalty points amount.\n\n" +
                        "5. Complete the transaction."
                    );
                    break;

                case 5:
                    DisplayGuide(
                        "ADDING A NEW EMPLOYEE",
                        "1. Open Manage Staff.\n\n" +
                        "2. Enter the employee's details.\n\n" +
                        "3. Assign the employee's role.\n\n" +
                        "4. Enter a username and password.\n\n" +
                        "5. Click Add Employee.\n\n" +
                        "6. Click Save.\n\n" +
                        "7. The employee record will be stored successfully.\n\n" +
                        "NOTE:\nAll required fields must be completed."
                    );
                    break;

                case 6:
                    DisplayGuide(
                        "UPDATING EMPLOYEE DETAILS",
                        "1. Open Manage Staff.\n\n" +
                        "2. Select the employee record.\n\n" +
                        "3. Edit the required information.\n\n" +
                        "4. Click Update.\n\n" +
                        "5. Changes will be saved to the database."
                    );
                    break;

                case 7:
                    DisplayGuide(
                        "ADDING A NEW PRODUCT",
                        "1. Open Manage Products.\n\n" +
                        "2. Slect Add Product tab.\n\n" +
                        "3. Enter the product information.\n\n" +
                        "4. Click Add Product.\n\n" +
                        "5. Click Save.\n\n" +
                        "6. The product will be added successfully.\n\n" +
                        "NOTE:\nEnsure all required product information is entered correctly."
                    );
                    break;

                case 8:
                    DisplayGuide(
                        "UPDATING PRODUCT DETAILS",
                        "1. Open Manage Products.\n\n" +
                        "2. Select update product tab.\n\n" +
                        "3. Select the product record.\n\n" +
                        "4. Modify the required information.\n\n" +
                        "5. Click Update.\n\n" +
                        "6. Changes will be saved successfully.\n\n" +
                        "NOTE:\nChanges to pricing and product information take effect immediately."
                    );
                    break;
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void lstTroubleshooting_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (lstTroubleshooting.SelectedIndex)
            {
                case 0:
                    DisplayHelpContent(
                        "CANNOT LOG IN",
                        "POSSIBLE CAUSES:\n\n" +
                        "• Incorrect username.\n" +
                        "• Incorrect password.\n" +
                        "• User account is inactive.\n\n" +

                        "SOLUTION:\n\n" +
                        "1. Verify your username and password.\n" +
                        "2. Ensure Caps Lock is not enabled.\n" +
                        "3. Contact an administrator if the issue persists."
                    );
                    break;

                case 1:
                    DisplayHelpContent(
                        "CUSTOMER CANNOT BE FOUND",
                        "POSSIBLE CAUSES:\n\n" +
                        "• Incorrect Customer ID entered.\n" +
                        "• Customer record does not exist.\n\n" +

                        "SOLUTION:\n\n" +
                        "1. Verify the Customer ID.\n" +
                        "2. Search using the customer's name.\n" +
                        "3. Register the customer if necessary."
                    );
                    break;

                case 2:
                    DisplayHelpContent(
                        "UNABLE TO COMPLETE SALE",
                        "POSSIBLE CAUSES:\n\n" +
                        "• No products have been added to the cart.\n" +
                        "• Insufficient stock.\n" +
                        "• Required customer information is missing.\n\n" +

                        "SOLUTION:\n\n" +
                        "1. Add products to the cart.\n" +
                        "2. Check stock availability.\n" +
                        "3. Complete all required information.\n" +
                        "4. Attempt the transaction again."
                    );
                    break;

                case 3:
                    DisplayHelpContent(
                        "CUSTOMER DETAILS NOT UPDATING",
                        "POSSIBLE CAUSES:\n\n" +
                        "• Customer record not selected.\n" +
                        "• Required fields are empty.\n" +
                        "• Invalid data entered.\n\n" +

                        "SOLUTION:\n\n" +
                        "1. Search and select the customer.\n" +
                        "2. Complete all mandatory fields.\n" +
                        "3. Verify the information entered.\n" +
                        "4. Click Update again."
                    );
                    break;

                case 4:
                    DisplayHelpContent(
                        "LOYALTY POINTS NOT ADDED",
                        "POSSIBLE CAUSES:\n\n" +
                        "• Sale not completed successfully.\n" +
                        "• Customer not linked to the sale.\n\n" +

                        "SOLUTION:\n\n" +
                        "1. Complete the sale successfully.\n" +
                        "2. Ensure the customer is selected.\n" +
                        "3. Verify the updated points balance."
                    );
                    break;



                case 5:
                    DisplayHelpContent(
                        "DATABASE CONNECTION ERROR",
                        "POSSIBLE CAUSES:\n\n" +
                        "• Database server is unavailable.\n" +
                        "• Connection string is incorrect.\n" +
                        "• Network connectivity issues.\n" +
                        "• Database service is not running.\n\n" +

                        "SOLUTION:\n\n" +
                        "1. Verify the database server is running.\n" +
                        "2. Check the network connection.\n" +
                        "3. Ensure the connection string is correct.\n" +
                        "4. Restart the application.\n" +
                        "5. Contact the system administrator if the issue persists."
                    );
                    break;
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void DisplayAbout()
        {
            rtbAbout.Clear();

            // Main Heading
            rtbAbout.SelectionColor = Color.DarkBlue;
            rtbAbout.SelectionFont =
                new Font("Segoe UI", 16, FontStyle.Bold);

            rtbAbout.AppendText("SAMS LIQUOR STORE POS SYSTEM\n\n");

            rtbAbout.AppendText("Institution\n\n");

            // Section Content
            rtbAbout.SelectionColor = Color.DarkGreen;
            rtbAbout.SelectionFont =
                new Font("Segoe UI", 12, FontStyle.Bold);

            rtbAbout.AppendText("University of KwaZulu-Natal\n\n");


            // Normal text
            rtbAbout.SelectionColor = Color.Black;
            rtbAbout.SelectionFont =
                new Font("Segoe UI", 10, FontStyle.Regular);

            rtbAbout.AppendText(
                "Version: 1.0\n\n" +
                "Developed By The Byte Club:\n" +
                "• Divani Pillay\n" +
                "• Braeden Govender\n" +
                "• Kiyan Krishna\n" +
                "• Rashiven Govender\n" +
                "• Keenan Nainaar\n\n");

            // Section heading
            rtbAbout.SelectionColor = Color.DarkGreen;
            rtbAbout.SelectionFont =
                new Font("Segoe UI", 12, FontStyle.Bold);

            rtbAbout.AppendText("System Overview\n\n");

            // Section content
            rtbAbout.SelectionColor = Color.Black;
            rtbAbout.SelectionFont =
                new Font("Segoe UI", 10);

            rtbAbout.AppendText(
                "The SAMS Liquor Store POS System is designed to manage " +
                "customer information, sales transactions, inventory and " +
                "loyalty points efficiently.\n\n");

            // Another section
            rtbAbout.SelectionColor = Color.DarkGreen;
            rtbAbout.SelectionFont =
                new Font("Segoe UI", 12, FontStyle.Bold);

            rtbAbout.AppendText("Key Features\n\n");

            rtbAbout.SelectionColor = Color.Black;
            rtbAbout.SelectionFont =
                new Font("Segoe UI", 10);

            rtbAbout.AppendText(
                "• Customer Registration and Management\n" +
                "• Sales Processing\n" +
                "• Employee Management\n" +
                "• Loyalty Points Tracking\n" +
                "• Reporting and Analytics\n" +
                "• Help and Support Features\n\n");

            rtbAbout.SelectionColor = Color.DarkGreen;
            rtbAbout.SelectionFont =
                new Font("Segoe UI", 12, FontStyle.Bold);

            rtbAbout.AppendText("Technology Used\n\n");

            rtbAbout.SelectionColor = Color.Black;

            rtbAbout.AppendText(
                "• C# Windows Forms\n" +
                "• SQL Server Database\n\n");

            rtbAbout.SelectionColor = Color.Gray;

            rtbAbout.AppendText(
                "© 2026 SAMS Liquor Store.");
        }
    }
}
