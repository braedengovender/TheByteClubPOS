using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            employee_RoleComboBox.Items.Add("Admin");
            employee_RoleComboBox.Items.Add("Cashier");
            employee_RoleComboBox.Items.Add("Manager");

            employee_StatusComboBox.Items.Clear();
            employee_StatusComboBox.Items.Add("Active");
            employee_StatusComboBox.Items.Add("Inactive");

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
