using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TheByteClubPOS
{
    public partial class ManageCustomerDetails : Form
    {
        public ManageCustomerDetails()
        {
            InitializeComponent();

        }

        private void ManageCustomerDetails_Load(object sender, EventArgs e)
        {
            customerTableAdapter.Fill(this.dsSamsLiqourShop.Customer);
            UpdateCustomerCard(); //call the method to update the customer card display when the form loads
        }

        private void UpdateCustomerCard() //method for the updateCustomer tab to display ID , name and loyalty points in panel
        {
            label8.Text = "Customer ID : " + customer_IDTextBox.Text;

            label9.Text = customer_FirstNameTextBox1.Text +
                          " " +
                          customer_LastNameTextBox1.Text;

            label10.Text = customer_StatusTextBox1.Text;

            if (label10.Text == "Active")
            {
                label10.BackColor = Color.LightGreen;
                label10.ForeColor = Color.DarkGreen;
            }
            else
            {
                label10.BackColor = Color.LightCoral;
                label10.ForeColor = Color.DarkRed;
            }
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            /*  try
              {
                  // 1. Extract values from UI controls
                  string firstName = txtFirstName.Text.Trim();
                  string lastName = txtLastName.Text.Trim();

                  string email = txtEmailAddress.Text.Trim();





                  // Nullable fields: If text is empty, pass null
                  string unitNumber = string.IsNullOrWhiteSpace(txtUnitNumber.Text) ? null : txtUnitNumber.Text.Trim();
                  string unitName = string.IsNullOrWhiteSpace(txtUnitName.Text) ? null : txtUnitName.Text.Trim();
                  string streetNumber = txtStreetNumber.Text.Trim();
                  string streetName = txtStreetName.Text.Trim();
                  string suburb = txtSuburb.Text.Trim();



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

                  string idNumber = maskedTextBox1.Text;
                  // 2. Basic validation for non-null database fields
                  if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(idNumber))
                  {
                      MessageBox.Show("Please fill in all mandatory fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                      return;
                  }

                  string phone = maskedTextBox3.Text;
                  string postalCode = maskedTextBox2.Text;
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
              }*/
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            customerTableAdapter.Fill(this.dsSamsLiqourShop.Customer);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            customerTableAdapter.FillByCustomerName(dsSamsLiqourShop.Customer, textBox2.Text);
            UpdateCustomerCard();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to update this customer's details?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
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

            else
            {
                MessageBox.Show("Customer update cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            return Regex.IsMatch(email, pattern);
        }

        private void txtEmailAddress_Leave(object sender, EventArgs e)
        {
            if (!IsValidEmail(txtEmailAddress.Text.Trim()))
            {
                MessageBox.Show(
                    "Please enter a valid email address.",
                    "Invalid Email",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtEmailAddress.BackColor = Color.MistyRose;
                txtEmailAddress.Focus();
            }
            else
            {
                txtEmailAddress.BackColor = Color.White;
            }
        }
        private void maskedTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            maskedTextBox1.SelectionStart = 0;
        }

        private void txtFirstName_Leave(object sender, EventArgs e)
        {
            if (!txtFirstName.Text.All(c => char.IsLetter(c) || c == ' '))
            {
                MessageBox.Show("First Name may only contain letters.");
                txtFirstName.Focus();
            }
        }

        private void txtLastName_Leave(object sender, EventArgs e)
        {
            if (!txtLastName.Text.All(c => char.IsLetter(c) || c == ' '))
            {
                MessageBox.Show("Last Name may only contain letters.");
                txtLastName.Focus();
            }
        }

        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            maskedTextBox1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; //this ensures only the numbers are extracted
            if (!maskedTextBox1.MaskFull)
            {
                MessageBox.Show("Please enter full ID number"); //ensuring the masked textbox is fully filled out before attempting to extract the value, as it is a required field and must be unique in the database. This prevents empty or incomplete values from being inserted, which would violate database constraints and cause errors.    
                return;
            }
            string idNumber = maskedTextBox1.Text; //using a masked textbox for the ID number allows us to enforce a specific format (e.g., 13 digits for a South African ID) and ensures that only numbers are used.
        }

        private void maskedTextBox3_Leave(object sender, EventArgs e)
        {
            maskedTextBox3.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            if (!maskedTextBox3.MaskFull)
            {
                MessageBox.Show("Please enter full phone number");
                return;
            }
            string phone = maskedTextBox3.Text;
        }

        private void maskedTextBox2_Leave(object sender, EventArgs e)
        {
            maskedTextBox2.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            if (!maskedTextBox2.MaskFull)
            {
                MessageBox.Show("Please enter full postal code");
                return;
            }
            string postalCode = maskedTextBox2.Text;
        }

        private void customer_PhoneNumberTextBox_Leave(object sender, EventArgs e)
        {
            if (customer_PhoneNumberTextBox.Text.Length != 10 || !customer_PhoneNumberTextBox.Text.All(char.IsDigit))
            {
                MessageBox.Show("Phone number must contain exactly 10 digits.",
                                "Invalid Phone Number",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                customer_PhoneNumberTextBox.Focus();
            }

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                // Configure MaskedTextBox settings to exclude format characters when fetching data
                maskedTextBox1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                maskedTextBox2.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                maskedTextBox3.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                // 1. Extract values from UI controls (Trim trailing white spaces)
                string firstName = txtFirstName.Text.Trim();
                string lastName = txtLastName.Text.Trim();
                string email = txtEmailAddress.Text.Trim();
                string idNumber = maskedTextBox1.Text.Trim();
                string postalCode = maskedTextBox2.Text.Trim();
                string phone = maskedTextBox3.Text.Trim();

                // Nullable fields: If text is empty, pass null
                string unitNumber = string.IsNullOrWhiteSpace(txtUnitNumber.Text) ? null : txtUnitNumber.Text.Trim();
                string unitName = string.IsNullOrWhiteSpace(txtUnitName.Text) ? null : txtUnitName.Text.Trim();

                string streetNumber = txtStreetNumber.Text.Trim();
                string streetName = txtStreetName.Text.Trim();
                string suburb = txtSuburb.Text.Trim();
                string city = txtCity.Text.Trim();
                string country = txtCountry.Text.Trim();

                // ComboBoxes (Make sure items match database types)
                string province = cmbProvince.SelectedItem?.ToString();

                // DateTime Picker
                DateTime registrationDate = dtpRegistrationDateTime.Value;

                // Numeric handling
                int loyaltyPoints = 0;
                int.TryParse(txtLoyaltyPointsBalance.Text, out loyaltyPoints);

                string status = txtStatus.Text.Trim();

                // Basic validation for non-null database fields
                if (string.IsNullOrEmpty(firstName) ||
                    string.IsNullOrEmpty(lastName) ||
                    string.IsNullOrEmpty(email) ||
                    string.IsNullOrEmpty(idNumber) ||
                    string.IsNullOrEmpty(phone) ||
                    string.IsNullOrEmpty(postalCode) ||
                    string.IsNullOrEmpty(streetNumber) ||
                    string.IsNullOrEmpty(streetName) ||
                    string.IsNullOrEmpty(suburb) ||
                    string.IsNullOrEmpty(city) ||
                    string.IsNullOrEmpty(province) ||
                    string.IsNullOrEmpty(country) ||
                    string.IsNullOrEmpty(status))
                {
                    MessageBox.Show("Please fill in all mandatory fields.\n\nOnly Unit Number, Unit Name, Username, and Password can be left blank.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string formattedRegDate = registrationDate.ToString("yyyy-MM-dd HH:mm:ss");

                // 3. Call the TableAdapter Insert query method
                this.customerTableAdapter.InsertQueryNewCustomer(firstName, lastName, email, idNumber, phone, unitNumber, unitName, streetNumber, streetName, suburb, postalCode, city, province, country, formattedRegDate, loyaltyPoints, status, null, null);
                this.customerTableAdapter.Fill(this.dsSamsLiqourShop.Customer);
                MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                // Error numbers 2627 and 2601 are SQL Server's universal codes for Unique Constraint / Duplicate Key violations
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    // Default message if we can't narrow it down completely
                    string specificField = "field (ID Number, Phone, Email, or Username)";
                    string errorMessage = ex.Message; // Keep original casing since SQL constraint names are often capitalized

                    // Better pattern matching that looks for your database column names or parts of them
                    if (errorMessage.IndexOf("idnumber", StringComparison.OrdinalIgnoreCase) >= 0 ||
                        errorMessage.IndexOf("id_number", StringComparison.OrdinalIgnoreCase) >= 0 ||
                        errorMessage.IndexOf("id", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        specificField = "ID Number";
                    }
                    else if (errorMessage.IndexOf("phone", StringComparison.OrdinalIgnoreCase) >= 0 ||
                             errorMessage.IndexOf("mobile", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        specificField = "Phone Number";
                    }
                    else if (errorMessage.IndexOf("email", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        specificField = "Email Address";
                    }
                    else if (errorMessage.IndexOf("username", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        specificField = "Username";
                    }

                    MessageBox.Show(
                        $"Database Error: Duplicate Entry Detected!\n\n" +
                        $"The {specificField} you entered is already registered to an existing customer.\n\n" +
                        $"Please verify the input details or check if this customer has already been captured.",
                        "Duplicate Record Blocked",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                // Handle String Truncation (Entering data longer than the database column capacity)
                else if (ex.Number == 8152 || ex.Message.Contains("truncated"))
                {
                    MessageBox.Show(
                        "Database Error: Data Too Long!\n\n" +
                        "One of the fields you filled out contains too many characters for the database schema layout.\n\n" +
                        "Please make sure fields like Postal Code, Street Number, or Status are brief and match database size limits.",
                        "Data Length Errorx",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(
                        $"A database driver error occurred:\n\n" +
                        $"Message: {ex.Message}\n" +
                        $"Error Code: {ex.Number}\n" +
                        $"Procedure: {ex.Procedure}",
                        "SQL Server Engine Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Handle unexpected application flaws (e.g., UI cast or object mapping failure)
                MessageBox.Show(
                    $"An unexpected application tier error occurred:\n\n" +
                    $"Type: {ex.GetType().Name}\n" +
                    $"Message: {ex.Message}",
                    "Application Framework Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void rbCity_CheckedChanged(object sender, EventArgs e)
        {

            DataView dv = dsSamsLiqourShop.Customer.DefaultView;
            dv.RowFilter = "customer_City = 'Durban'";
            customerDataGridView.DataSource = dv;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            DataView dv = dsSamsLiqourShop.Customer.DefaultView;
            dv.RowFilter = "customer_City = 'Johannesburg'";
            customerDataGridView.DataSource = dv;
        }

        private void rbCountry_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCity.Checked)
            {
                // Prompt user for city filter
                string city = Microsoft.VisualBasic.Interaction.InputBox(
                    "Enter city to filter by:",
                    "City Filter",
                    ""
                );

                if (!string.IsNullOrWhiteSpace(city))
                {
                    DataView dv = dsSamsLiqourShop.Customer.DefaultView;
                    dv.RowFilter = $"Customer_City LIKE '%{city.Replace("'", "''")}%'";
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            DataView dv = dsSamsLiqourShop.Customer.DefaultView;
            dv.RowFilter = "customer_City = 'Cape Town'";
            customerDataGridView.DataSource = dv;
        }

        private void rbInactive_CheckedChanged(object sender, EventArgs e)
        {
            DataView dv = dsSamsLiqourShop.Customer.DefaultView;
            dv.RowFilter = "Customer_Status = 'Inactive'";
        }

        private void rbFirstName_CheckedChanged(object sender, EventArgs e)
        {
            DataView dv = dsSamsLiqourShop.Customer.DefaultView;
            dv.Sort = "Customer_FirstName ASC";
        }

        private void rbSurname_CheckedChanged(object sender, EventArgs e)
        {
            DataView dv = dsSamsLiqourShop.Customer.DefaultView;
            dv.Sort = "Customer_LastName ASC";
        }

        private void rbDateCreated_CheckedChanged(object sender, EventArgs e)
        {
            DataView dv = dsSamsLiqourShop.Customer.DefaultView;
            dv.Sort = "Customer_RegistrationDateTime DESC";
        }

        private void customerDataGridView_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            customerTableAdapter.FillByCustomerFirstName(dsSamsLiqourShop.Customer, textBox1.Text);
        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            DataView dv = dsSamsLiqourShop.Customer.DefaultView;
            dv.RowFilter = ""; // Clear Filter

            rbCity.Checked = false;
            rbCountry.Checked = false; //Unchecl Radio Buttons
            rbInactive.Checked = false;

            customerDataGridView.DataSource = dv; // Refresh DataGridView

        }

        private void BtnSort_Click(object sender, EventArgs e)
        {
            DataView dv = dsSamsLiqourShop.Customer.DefaultView;
            dv.Sort = ""; // Clear Sort

            rbFirstName.Checked = false;
            rbSurname.Checked = false; //Uncheck Radio Buttons
            rbDateCreated.Checked = false;

            customerDataGridView.DataSource = dv; // Refresh DataGridView
        }
    }
}