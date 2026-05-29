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
    public partial class ManageCustomerDetails : Form
    {
        public ManageCustomerDetails()
        {
            InitializeComponent();
        }

        private void customerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customerBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsSamsLiqourShop);

        }

        private void ManageCustomerDetails_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.dsSamsLiqourShop.Customer);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Extract values from UI controls
                string firstName = txtFirstName.Text.Trim();
                string lastName = txtLastName.Text.Trim();
                string email = txtEmailAddress.Text.Trim();
                
                maskedTextBox1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; //this ensures only the numbers are extracted
                if (!maskedTextBox1.MaskFull)
                {
                    MessageBox.Show("Please enter full ID number"); //ensuring the masked textbox is fully filled out before attempting to extract the value, as it is a required field and must be unique in the database. This prevents empty or incomplete values from being inserted, which would violate database constraints and cause errors.    
                    return;
                }
                string idNumber = maskedTextBox1.Text; //using a masked textbox for the ID number allows us to enforce a specific format (e.g., 13 digits for a South African ID) and ensures that only numbers are used.

                maskedTextBox3.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                if (!maskedTextBox3.MaskFull)
                {
                    MessageBox.Show("Please enter full phone number");
                    return;
                }
                string phone = maskedTextBox3.Text;
              
                // Nullable fields: If text is empty, pass null
                string unitNumber = string.IsNullOrWhiteSpace(txtUnitNumber.Text) ? null : txtUnitNumber.Text.Trim();
                string unitName = string.IsNullOrWhiteSpace(txtUnitName.Text) ? null : txtUnitName.Text.Trim();
                string streetNumber = txtStreetNumber.Text.Trim();
                string streetName = txtStreetName.Text.Trim();
                string suburb = txtSuburb.Text.Trim();

                maskedTextBox2.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                if (!maskedTextBox2.MaskFull)
                {
                    MessageBox.Show("Please enter full postal code");
                    return;
                }
                string postalCode = maskedTextBox2.Text;
     
                string city = txtCity.Text.Trim();

                // ComboBoxes (Make sure items match database types)
                string province = cmbProvince.SelectedItem?.ToString();
                string country = txtCountry.Text.Trim();

                // DateTime Picker
                DateTime registrationDate = dtpRegistrationDateTime.Value;

                // Numeric handling
                int loyaltyPoints = 0;
                int.TryParse(txtLoyaltyPointsBalance.Text, out loyaltyPoints);

                string status = cmbStatus.SelectedItem?.ToString();

                // Nullable Account Fields
                string username = string.IsNullOrWhiteSpace(txtUsername.Text) ? null : txtUsername.Text.Trim();
                string password = string.IsNullOrWhiteSpace(txtPassword.Text) ? null : txtPassword.Text.Trim();


                // 2. Basic validation for non-null database fields
                if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(idNumber))
                {
                    MessageBox.Show("Please fill in all mandatory fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 3. Call the TableAdapter Insert query method
                this.customerTableAdapter.InsertQueryNewCustomer(firstName, lastName, email, idNumber, phone, unitNumber, unitName, streetNumber, streetName, suburb, postalCode, city, province, country, registrationDate.ToString(), loyaltyPoints, status, username, password);
                this.customerTableAdapter.Fill(this.dsSamsLiqourShop.Customer);
                MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (ex.Message.Contains("IX_Customer_2"))
                {
                    MessageBox.Show("Error: The Username or checked unique field must be unique. A record with this value already exists (or a second blank entry is being attempted).", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Database error occurred: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
