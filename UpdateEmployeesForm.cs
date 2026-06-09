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

namespace TheByteClubPOS
{
    public partial class UpdateEmployeesForm : Form
    {
        private int employeeID;
        public UpdateEmployeesForm(int selectedEmployeeID)
        {
            InitializeComponent();
            employeeID = selectedEmployeeID;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
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
            lblID.Text = row.Employee_ID.ToString();
            lblName.Text = row.Employee_FirstName + " " + row.Employee_LastName;
            lblStatus.Text = row.Employee_Status;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ManageEmployeeDetailsForm manageEmployeeDetailsForm =
               new ManageEmployeeDetailsForm();
            this.Hide();
            manageEmployeeDetailsForm.ShowDialog();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            // First Name
            if (!Regex.IsMatch(
                AddFirstname.Text.Trim(),
                @"^[A-Za-z ]+$"))
            {
                MessageBox.Show(
                    "First Name can only contain letters.");

                return;
            }

            // Last Name
            if (!Regex.IsMatch(
                AddLastName.Text.Trim(),
                @"^[A-Za-z ]+$"))
            {
                MessageBox.Show(
                    "Last Name can only contain letters.");

                return;
            }

            // South African ID Number
            if (!Regex.IsMatch(
                AddID.Text.Trim(),
                @"^\d{13}$"))
            {
                MessageBox.Show(
                    "ID Number must contain exactly 13 digits.");

                return;
            }

            // Email Validation
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

            // Phone Number
            if (!Regex.IsMatch(
                AddPhoneNumber.Text.Trim(),
                @"^\d{10,12}$"))
            {
                MessageBox.Show(
                    "Phone Number is invalid.");

                return;
            }

            // Username
            if (AddUsername.Text.Trim().Length < 4)
            {
                MessageBox.Show(
                    "Username must be at least 4 characters.");

                return;
            }

            // Password
            if (AddPassword.Text.Length < 8)
            {
                MessageBox.Show(
                    "Password must be at least 8 characters.");

                return;
            }

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
            ManageEmployeeDetailsForm manageEmployeeDetailsForm =
                new ManageEmployeeDetailsForm();
            this.Hide();
            manageEmployeeDetailsForm.ShowDialog();
        }
    }
}
