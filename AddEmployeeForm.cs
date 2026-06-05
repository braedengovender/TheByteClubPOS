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
    public partial class AddEmployeeForm : Form
    {
        public AddEmployeeForm()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // First Name
            if (!Regex.IsMatch(
                employee_FirstNameTextBox.Text.Trim(),
                @"^[A-Za-z ]+$"))
            {
                MessageBox.Show(
                    "First Name can only contain letters.");

                return;
            }

            // Last Name
            if (!Regex.IsMatch(
                employee_LastNameTextBox.Text.Trim(),
                @"^[A-Za-z ]+$"))
            {
                MessageBox.Show(
                    "Last Name can only contain letters.");

                return;
            }

            // South African ID Number
            if (!Regex.IsMatch(
                employee_IDNumberTextBox.Text.Trim(),
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
                        employee_EmailAddressTextBox.Text.Trim());
            }
            catch
            {
                MessageBox.Show(
                    "Please enter a valid Email Address.");

                return;
            }

            // Phone Number
            if (!Regex.IsMatch(
                employee_PhoneNumberTextBox.Text.Trim(),
                @"^\d{10,12}$"))
            {
                MessageBox.Show(
                    "Phone Number is invalid.");

                return;
            }

            // Username
            if (employee_UsernameTextBox.Text.Trim().Length < 4)
            {
                MessageBox.Show(
                    "Username must be at least 4 characters.");

                return;
            }

            // Password
            if (employee_PasswordTextBox.Text.Length < 8)
            {
                MessageBox.Show(
                    "Password must be at least 8 characters.");

                return;
            }

            // Role
            if (employee_RoleComboBox.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a Role.");

                return;
            }

            // Status
            if (employee_StatusComboBox.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a Status.");

                return;
            }

            EmployeeTableAdapter employeeTA =
                new EmployeeTableAdapter();

            // Duplicate Username Check
            if ((int)employeeTA.UsernameExists(
                employee_UsernameTextBox.Text.Trim()) > 0)
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
                    employee_FirstNameTextBox.Text.Trim(),
                    employee_LastNameTextBox.Text.Trim(),
                    employee_IDNumberTextBox.Text.Trim(),
                    employee_RoleComboBox.Text,
                    employee_EmailAddressTextBox.Text.Trim(),
                    employee_PhoneNumberTextBox.Text.Trim(),
                    employee_HireDateDateTimePicker.Value
                        .ToString("yyyy-MM-dd"),

                    employee_UsernameTextBox.Text.Trim(),
                    employee_PasswordTextBox.Text,
                    employee_StatusComboBox.Text
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

        private void AddEmployeeForm_Load(object sender, EventArgs e)
        {
            employee_RoleComboBox.Items.Clear();

            employee_RoleComboBox.Items.Add("Admin");
            employee_RoleComboBox.Items.Add("Cashier");
            employee_RoleComboBox.Items.Add("Manager");

            employee_StatusComboBox.Items.Clear();

            employee_StatusComboBox.Items.Add("Active");
            employee_StatusComboBox.Items.Add("Inactive");

            employee_HireDateDateTimePicker.Value =
                DateTime.Today;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ManageEmployeeDetailsForm manageEmployeeDetailsForm =
                new ManageEmployeeDetailsForm();
            this.Hide();
            manageEmployeeDetailsForm.ShowDialog();
        }
    }
}