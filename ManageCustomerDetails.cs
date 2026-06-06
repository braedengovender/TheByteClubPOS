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
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtEmailAddress_TextChanged(object sender, EventArgs e)
        {
            string email = txtEmailAddress.Text.Trim();

            bool hasAt = email.Contains("@");
            bool hasDot = email.Contains(".");
            bool hasSpace = email.Contains(" ");

            if (hasAt && hasDot && !hasSpace)
            {
                toolTip1.SetToolTip(txtEmailAddress, "Valid email format");
            }
            else
            {
                toolTip1.SetToolTip(txtEmailAddress, "Invalid email (needs @, ., and no spaces)");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (customerDataGridView.SelectedRows.Count > 0)
            {
                int customerID = Convert.ToInt32(customerDataGridView.SelectedRows[0].Cells[0].Value);

                customerTableAdapter.UpdateQueryStatus(customerID, customerID);
                customerTableAdapter.Fill(this.dsSamsLiqourShop.Customer);

                MessageBox.Show("Customer deactivated successfully.");
            }
            else
            {
                MessageBox.Show("Please select a customer first.");
            }
        }

        private void customerDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (customerDataGridView.Rows[e.RowIndex].Cells[17].Value != null)
            {
                string status = customerDataGridView.Rows[e.RowIndex].Cells[17].Value.ToString();

                if (status == "Inactive")
                {
                    customerDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                    customerDataGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
                else
                {
                    customerDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    customerDataGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
            }

        private void button1_Click_1(object sender, EventArgs e)
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

                string status = txtStatus.Text.Trim();

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

        private void tabPage2_Click(object sender, EventArgs e)
        {
            customerTableAdapter.Fill(this.dsSamsLiqourShop.Customer);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            customerTableAdapter.FillByCustomerName(dsSamsLiqourShop.Customer, textBox2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = customer_RegistrationDateTimeDateTimePicker.Value;

         customerTableAdapter.UpdateQueryCustomerDetails(
    customer_FirstNameTextBox1.Text,
    customer_LastNameTextBox1.Text,
    customer_EmailAddressTextBox.Text,
    customer_IDNumberTextBox1.Text,
    customer_PhoneNumberTextBox.Text,
    customer_UnitNumberTextBox.Text,
    customer_UnitNameTextBox.Text,
    customer_StreetNumberTextBox.Text,
    customer_StreetNameTextBox.Text,
    customer_SuburbTextBox.Text,
    customer_PostalCodeTextBox.Text,
    customer_CityTextBox.Text,
    customer_ProvinceTextBox.Text,
    customer_CountryTextBox.Text,
    selectedDate.ToString(),
    Convert.ToInt32(customer_LoyaltyPointsBalanceTextBox.Text),
    customer_StatusTextBox1.Text,
    customer_UsernameTextBox.Text,
    customer_PasswordTextBox.Text,
    Convert.ToInt32(customer_IDTextBox.Text)
);
            customerTableAdapter.Fill(this.dsSamsLiqourShop.Customer);
            MessageBox.Show("Customer details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void customer_FirstNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void customer_LastNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void customer_EmailAddressLabel_Click(object sender, EventArgs e)
        {

        }

        private void customer_IDNumberLabel_Click(object sender, EventArgs e)
        {

        }

        private void customer_PhoneNumberLabel_Click(object sender, EventArgs e)
        {

        }

        private void customer_UnitNumberLabel_Click(object sender, EventArgs e)
        {

        }

        private void customer_UnitNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void customer_StreetNumberLabel_Click(object sender, EventArgs e)
        {

        }

        private void customer_StreetNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void customer_SuburbLabel_Click(object sender, EventArgs e)
        {

        }

        private void customer_PostalCodeLabel_Click(object sender, EventArgs e)
        {

        }

        private void customer_CityLabel_Click(object sender, EventArgs e)
        {

        }

        private void customer_ProvinceLabel_Click(object sender, EventArgs e)
        {

        }

        private void customer_CountryLabel_Click(object sender, EventArgs e)
        {

        }

        private void customer_RegistrationDateTimeLabel_Click(object sender, EventArgs e)
        {

        }

        private void customer_LoyaltyPointsBalanceLabel_Click(object sender, EventArgs e)
        {

        }

        private void customer_StatusLabel_Click(object sender, EventArgs e)
        {

        }

        private void customer_UsernameLabel_Click(object sender, EventArgs e)
        {

        }

        private void customer_PasswordLabel_Click(object sender, EventArgs e)
        {

        }

        private void customer_FirstNameLabel1_Click(object sender, EventArgs e)
        {

        }

        private void customer_LastNameLabel1_Click(object sender, EventArgs e)
        {

        }

        private void customer_IDNumberLabel1_Click(object sender, EventArgs e)
        {

        }

        private void customer_StatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void customer_IDLabel1_Click(object sender, EventArgs e)
        {

        }

        private void customer_FirstNameLabel2_Click(object sender, EventArgs e)
        {

        }

        private void customer_LastNameLabel2_Click(object sender, EventArgs e)
        {

        }

        private void customer_EmailAddressLabel1_Click(object sender, EventArgs e)
        {

        }

        private void customer_IDNumberLabel2_Click(object sender, EventArgs e)
        {

        }

        private void customer_PhoneNumberLabel1_Click(object sender, EventArgs e)
        {

        }

        private void customer_UnitNumberLabel1_Click(object sender, EventArgs e)
        {

        }

        private void customer_UnitNameLabel1_Click(object sender, EventArgs e)
        {

        }

        private void customer_StreetNumberLabel1_Click(object sender, EventArgs e)
        {

        }

        private void customer_StreetNameLabel1_Click(object sender, EventArgs e)
        {

        }

        private void customer_SuburbLabel1_Click(object sender, EventArgs e)
        {

        }

        private void customer_PostalCodeLabel1_Click(object sender, EventArgs e)
        {

        }

        private void customer_CityLabel1_Click(object sender, EventArgs e)
        {

        }

        private void customer_ProvinceLabel1_Click(object sender, EventArgs e)
        {

        }

        private void customer_CountryLabel1_Click(object sender, EventArgs e)
        {

        }

        private void customer_RegistrationDateTimeLabel1_Click(object sender, EventArgs e)
        {

        }

        private void customer_LoyaltyPointsBalanceLabel1_Click(object sender, EventArgs e)
        {

        }

        private void customer_StatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void customer_UsernameLabel1_Click(object sender, EventArgs e)
        {

        }

        private void customer_PasswordLabel1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void customer_IDLabel_Click(object sender, EventArgs e)
        {

        }

        private void txtStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected_1(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void dtpRegistrationDateTime_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbProvince_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLoyaltyPointsBalance_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCountry_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSuburb_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStreetName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStreetNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUnitName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUnitNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmailAddress_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void customer_StatusTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void customerBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void customer_IDNumberTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void customer_LastNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void customer_FirstNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void customerDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void customer_IDTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void customer_FirstNameTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void customer_LastNameTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void customer_EmailAddressTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void customer_IDNumberTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void customer_PhoneNumberTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void customer_UnitNumberTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void customer_UnitNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void customer_StreetNumberTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void customer_StreetNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void customer_SuburbTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void customer_PostalCodeTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void customer_CityTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void customer_ProvinceTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void customer_CountryTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void customer_RegistrationDateTimeDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void customer_LoyaltyPointsBalanceTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void customer_StatusTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void customer_UsernameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void customer_PasswordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}