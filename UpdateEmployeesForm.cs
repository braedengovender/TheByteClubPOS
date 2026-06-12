using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheByteClubPOS.dsSamsLiqourShopTableAdapters;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TheByteClubPOS
{
    public partial class UpdateEmployeesForm : Form
    {
        private int employeeID;
        public static bool IsDarkMode = false;
        public bool IsManageProfile = false;
        private string ValidatePasswordDetailed(string password)
        {
            bool hasUpper = false, hasLower = false, hasDigit = false, hasPunctuation = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpper = true;
                else if (char.IsLower(c)) hasLower = true;
                else if (char.IsDigit(c)) hasDigit = true;
                else if (char.IsPunctuation(c) || char.IsSymbol(c)) hasPunctuation = true;
            }

            string errors = "";
            if (!hasUpper) errors += "Missing uppercase letter\n";
            if (!hasLower) errors += "Missing lowercase letter\n";
            if (!hasDigit) errors += "Missing digit\n";
            if (!hasPunctuation) errors += "Missing special character\n";

            return errors;
        }

        public void SetTabVisibility(bool isAddMode)
        {
            // First, clear everything so we don't end up with duplicate tabs
            tabControl1.TabPages.Clear();

            if (isAddMode)
            {
                // Add only the tab we want
                tabControl1.TabPages.Add(tabPage2);
            }
            else
            {
                // Add only the tab we want
                tabControl1.TabPages.Add(tabPage1);
            }
        }

        public UpdateEmployeesForm(int selectedEmployeeID)
        {
            InitializeComponent();
            employeeID = selectedEmployeeID;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(employee_FirstNameTextBox.Text)) { MessageBox.Show("Enter a Firstname."); }
            if (string.IsNullOrWhiteSpace(employee_LastNameTextBox.Text)) { MessageBox.Show("Enter a Lastname."); }
            if (string.IsNullOrWhiteSpace(employee_IDNumberTextBox.Text)) { MessageBox.Show("Enter an ID."); }
            if (string.IsNullOrWhiteSpace(employee_EmailAddressTextBox.Text)) { MessageBox.Show("Enter an Email."); }
            if (string.IsNullOrWhiteSpace(employee_PhoneNumberTextBox.Text)) { MessageBox.Show("Enter a Phone Number."); }
            if (string.IsNullOrWhiteSpace(employee_UsernameTextBox.Text)) { MessageBox.Show("Enter a Username."); }
            if (string.IsNullOrWhiteSpace(employee_PasswordTextBox.Text)) { MessageBox.Show("Enter a Password."); }
            if (employee_RoleComboBox.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Select a Role.");

                return;
            }

            if (employee_StatusComboBox.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Select a Status.");

                return;
            }

            EmployeeTableAdapter employeeTA =
                new EmployeeTableAdapter();

            employeeTA.UpdateEmployee(
                employee_FirstNameTextBox.Text.Trim(),
                employee_LastNameTextBox.Text.Trim(),
                employee_IDNumberTextBox.Text.Trim(),
                employee_RoleComboBox.Text,
                employee_EmailAddressTextBox.Text.Trim(),
                employee_PhoneNumberTextBox.Text.Trim(),
                employee_HireDateDateTimePicker.Value.ToString("yyyy-MM-dd"),
                employee_UsernameTextBox.Text.Trim(),
                employee_PasswordTextBox.Text,
                employee_StatusComboBox.Text,
                employeeID
            );

            MessageBox.Show(
                "Employee updated successfully.");

            this.Close();
        }

        private void UpdateEmployeesForm_Load(object sender, EventArgs e)
        {
            employee_RoleComboBox.Items.Clear();
            employee_RoleComboBox.Items.Clear();
            employee_RoleComboBox.Items.Add("Admin");
            employee_RoleComboBox.Items.Add("Cashier");
            employee_RoleComboBox.Items.Add("Manager");

            employee_StatusComboBox.Items.Clear();
            employee_StatusComboBox.Items.Clear();
            employee_StatusComboBox.Items.Add("Active");
            employee_StatusComboBox.Items.Add("Inactive");

            //Add
            cbRole.Items.Clear();

            cbRole.Items.Add("Admin");
            cbRole.Items.Add("Cashier");
            cbRole.Items.Add("Manager");

            cbStatus.Items.Clear();

            cbStatus.Items.Add("Active");
            cbStatus.Items.Add("Inactive");

            AddHire.Value =
                DateTime.Today;

            EmployeeTableAdapter employeeTA =
                new EmployeeTableAdapter();

            var employee =
                employeeTA.GetDataByEmployeeID(
                    employeeID);

            if (employee.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Employee not found.");

                this.Close();

                return;
            }

            var row = employee[0];

            employee_IDTextBox.Text =
                row.Employee_ID.ToString();

            employee_FirstNameTextBox.Text =
                row.Employee_FirstName;

            employee_LastNameTextBox.Text =
                row.Employee_LastName;

            employee_IDNumberTextBox.Text =
                row.Employee_IDNumber;

            employee_RoleComboBox.Text =
                row.Employee_Role;

            employee_EmailAddressTextBox.Text =
                row.Employee_EmailAddress;

            employee_PhoneNumberTextBox.Text =
                row.Employee_PhoneNumber;

            employee_HireDateDateTimePicker.Value =
                row.Employee_HireDate;

            employee_UsernameTextBox.Text =
                row.Employee_Username;

            employee_PasswordTextBox.Text =
                row.Employee_Password;

            employee_StatusComboBox.Text =
                row.Employee_Status;
            lblID.Text = "Employee ID : " + row.Employee_ID.ToString();
            lblName.Text = row.Employee_FirstName + " " + row.Employee_LastName;
            lblStatus.Text = row.Employee_Status;

            if (lblStatus.Text == "Active")
            {
                lblStatus.BackColor = Color.LightGreen;
                lblStatus.ForeColor = Color.DarkGreen;
            }
            else
            {
                lblStatus.BackColor = Color.LightCoral;
                lblStatus.ForeColor = Color.DarkRed;
            }
            if (IsManageProfile)
            {
                lblHeading.Text = "Edit My Details";

                employee_IDTextBox.ReadOnly = true;

                employee_IDTextBox.Text =
                    LoginForm.LoggedInEmployeeID.ToString();

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            /*ManageEmployeeDetailsForm manageEmployeeDetailsForm = new ManageEmployeeDetailsForm();
            this.Hide();
            manageEmployeeDetailsForm.ShowDialog();*/
            this.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(AddFirstname.Text)) {MessageBox.Show("Enter a Firstname.");}
            if (string.IsNullOrWhiteSpace(AddLastName.Text)) { MessageBox.Show("Enter a Lastname."); }
            if (string.IsNullOrWhiteSpace(AddID.Text)) { MessageBox.Show("Enter an ID."); }
            if (string.IsNullOrWhiteSpace(AddEmail.Text)) { MessageBox.Show("Enter an Email."); }
            if (string.IsNullOrWhiteSpace(AddPhoneNumber.Text)) { MessageBox.Show("Enter a Phone Number."); }
            if (string.IsNullOrWhiteSpace(AddUsername.Text)) { MessageBox.Show("Enter a Username."); }
            if (string.IsNullOrWhiteSpace(AddPassword.Text)) { MessageBox.Show("Enter a Password."); }
            // Role
            if (cbRole.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a Role.");

                return;
            }

            // Status
            if (cbStatus.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a Status.");

                return;
            }

            EmployeeTableAdapter employeeTA =
                new EmployeeTableAdapter();

            // Duplicate Username Check
            if ((int)employeeTA.UsernameExists(
                AddUsername.Text.Trim()) > 0)
            {
                MessageBox.Show(
                    "Username already exists.");

                return;
            }

            // Duplicate ID Number Check

            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to add this employee?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }

            try
            {
                employeeTA.InsertEmployee(
                    AddFirstname.Text.Trim(),
                    AddLastName.Text.Trim(),
                    AddID.Text.Trim(),
                    cbRole.Text,
                    AddEmail.Text.Trim(),
                    AddPhoneNumber.Text.Trim(),
                    AddHire.Value
                        .ToString("yyyy-MM-dd"),

                    AddUsername.Text.Trim(),
                    AddPassword.Text,
                    cbStatus.Text
                );

                MessageBox.Show(
                    "Employee added successfully.");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error adding employee:\n\n" +
                    ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*ManageEmployeeDetailsForm manageEmployeeDetailsForm = new ManageEmployeeDetailsForm();
            this.Hide();
            manageEmployeeDetailsForm.ShowDialog();*/
            this.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (employee_PasswordTextBox.UseSystemPasswordChar)
            {
                employee_PasswordTextBox.UseSystemPasswordChar = false;
                pictureBox7.Image = Properties.Resources.HideEye;
            }
            else
            {
                employee_PasswordTextBox.UseSystemPasswordChar = true;
                pictureBox7.Image = Properties.Resources.ShowEye;
            }
        }

        private void employee_FirstNameTextBox_Leave(object sender, EventArgs e)
        {
            
        }

        private void employee_LastNameTextBox_Leave(object sender, EventArgs e)
        {
            
        }

        private void AddFirstname_Leave(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(
        AddFirstname.Text.Trim(),
        @"^[A-Za-z ]+$"))
            {
                MessageBox.Show(
                    "First Name can only contain letters.");

                AddFirstname.Focus();
                return;
            }
        }

        private void AddLastName_Leave(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(
               AddLastName.Text.Trim(),
               @"^[A-Za-z ]+$"))
            {
                MessageBox.Show(
                    "Last Name can only contain letters.");
                AddLastName.Focus();
                return;
            }

        }

        private void AddID_Leave(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(
                AddID.Text.Trim(),
                @"^\d{13}$"))
            {
                MessageBox.Show(
                    "ID Number must contain exactly 13 digits.");

                return;
            }
        }

        private void AddEmail_Leave(object sender, EventArgs e)
        {
            try
            {
                var email =
                    new System.Net.Mail.MailAddress(
                        AddEmail.Text.Trim());
            }
            catch
            {
                MessageBox.Show(
                    "Please enter a valid Email Address.");

                return;
            }
        }

        private void AddPhoneNumber_Leave(object sender, EventArgs e)
        {
            // Phone Number
            if (!Regex.IsMatch(
                AddPhoneNumber.Text.Trim(),
                @"^\d{10,12}$"))
            {
                MessageBox.Show(
                    "Phone Number is invalid.");

                return;
            }
        }

        private void AddUsername_Leave(object sender, EventArgs e)
        {
            // Username
            if (AddUsername.Text.Trim().Length < 4)
            {
                MessageBox.Show(
                    "Username must be at least 4 characters.");

                return;
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (AddPassword.UseSystemPasswordChar)
            {
                AddPassword.UseSystemPasswordChar = false;
                pictureBox8.Image = Properties.Resources.HideEye;
            }
            else
            {
                AddPassword.UseSystemPasswordChar = true;
                pictureBox8.Image = Properties.Resources.ShowEye;
            }
        }

        private void employee_PasswordTextBox_Leave(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(
    employee_PasswordTextBox.Text,
    @"^(?=.*\d)(?=.*[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?]).{8,}$"))
            {
                MessageBox.Show(
                    "Password must contain:\n" +
                    "- At least 8 characters\n" +
                    "- At least 1 digit\n" +
                    "- At least 1 special character",
                    "Invalid Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
        }

        private void AddPassword_Leave(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(
    AddPassword.Text,
    @"^(?=.*\d)(?=.*[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?]).{8,}$"))
            {
                MessageBox.Show(
                    "Password must contain:\n" +
                    "- At least 8 characters\n" +
                    "- At least 1 digit\n" +
                    "- At least 1 special character",
                    "Invalid Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
        }

        private void customer_FirstNameLabel2_Click(object sender, EventArgs e)
        {

        }

        private void AddPassword_TextChanged(object sender, EventArgs e)
        {
            string employeePassword = AddPassword.Text;
            string errors = ValidatePasswordDetailed(employeePassword);
            if (string.IsNullOrEmpty(errors))
            {
                // If the password is valid, change it to White in Dark Mode, or system default in Light Mode
                AddPassword.ForeColor = IsDarkMode ? Color.White : SystemColors.ControlText;
                toolTip1.SetToolTip(AddPassword, string.Empty);
            }
            else
            {
                AddPassword.ForeColor = Color.Red;
                toolTip1.SetToolTip(AddPassword, errors);
            }
        }

        private void employee_PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            string employeePassword = employee_PasswordTextBox.Text;
            string errors = ValidatePasswordDetailed(employeePassword);
            if (string.IsNullOrEmpty(errors))
            {
                // If the password is valid, change it to White in Dark Mode, or system default in Light Mode
                employee_PasswordTextBox.ForeColor = IsDarkMode ? Color.White : SystemColors.ControlText;
                toolTip1.SetToolTip(employee_PasswordTextBox, string.Empty);
            }
            else
            {
                employee_PasswordTextBox.ForeColor = Color.Red;
                toolTip1.SetToolTip(employee_PasswordTextBox, errors);
            }
        }
    }
}
