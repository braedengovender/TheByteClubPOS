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
    public partial class ManageEmployeeDetailsForm : Form
    {
        public ManageEmployeeDetailsForm()
        {
            InitializeComponent();
        }

        private void ManageEmployeeDetailsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.dsSamsLiqourShop.Employee);

        }




        private void ApplySorting()
        {
            try
            {
                string column = "";

                if (rdoName.Checked)
                    column = "Employee_FirstName";

                else if (rdoSurname.Checked)
                    column = "Employee_LastName";

                else if (rdoUsername.Checked)
                    column = "Employee_Username";

                else if (rdoID.Checked)
                    column = "Employee_ID";

                if (column == "")
                {
                    employeeBindingSource.Sort = "";

                    return;
                }

                string direction =
                    rdoDesc.Checked
                    ? "DESC"
                    : "ASC";

                employeeBindingSource.Sort =
                    $"{column} {direction}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ApplyRoleFilter()
        {
            try
            {
                if (rdoManager.Checked)
                {
                    employeeBindingSource.Filter =
                        "Employee_Role = 'Manager'";
                }
                else if (rdoCashier.Checked)
                {
                    employeeBindingSource.Filter =
                        "Employee_Role = 'Cashier'";
                }
                else if (rdoAdmin.Checked)
                {
                    employeeBindingSource.Filter =
                        "Employee_Role = 'Admin'";
                }
                else if (rdoAll.Checked)
                {
                    employeeBindingSource.RemoveFilter();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (employeeBindingSource.Current == null)
            {
                MessageBox.Show(
                    "Please select an employee first.");

                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to remove this employee?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                MessageBox.Show(
                    "Delete cancelled.");

                return;
            }

            try
            {
                employeeBindingSource.RemoveCurrent();

                employeeBindingSource.EndEdit();

                employeeTableAdapter.Update(
                    dsSamsLiqourShop.Employee);

                MessageBox.Show(
                    "Employee removed successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error removing employee.\n\n" +
                    ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            employeeBindingSource.RemoveFilter();

            employeeBindingSource.Sort = "";

            txtSearch.Clear();

            rdoManager.Checked = false;
            rdoCashier.Checked = false;
            rdoAdmin.Checked = false;

            rdoName.Checked = false;
            rdoSurname.Checked = false;
            rdoUsername.Checked = false;
            rdoID.Checked = false;

            rdoAsc.Checked = false;
            rdoDesc.Checked = false;

            employeeBindingSource.ResetBindings(false);

            MessageBox.Show(
                "Filters reset.");
        }

        private void rdoManager_CheckedChanged(object sender, EventArgs e)
        {
            ApplyRoleFilter();
        }

        private void rdoCashier_CheckedChanged(object sender, EventArgs e)
        {
            ApplyRoleFilter();
        }

        private void rdoAdmin_CheckedChanged(object sender, EventArgs e)
        {
            ApplyRoleFilter();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(
           txtSearch.Text))
            {
                employeeBindingSource.RemoveFilter();

                return;
            }

            employeeBindingSource.Filter =
                $"Employee_FirstName LIKE '%{txtSearch.Text}%'" +
                $" OR Employee_LastName LIKE '%{txtSearch.Text}%'" +
                $" OR Employee_Username LIKE '%{txtSearch.Text}%'";
        }

        private void rdoName_CheckedChanged(object sender, EventArgs e)
        {
            ApplySorting();
        }

        private void rdoSurname_CheckedChanged(object sender, EventArgs e)
        {
            ApplySorting();
        }

        private void rdoUsername_CheckedChanged(object sender, EventArgs e)
        {
            ApplySorting();
        }

        private void rdoID_CheckedChanged(object sender, EventArgs e)
        {
            ApplySorting();
        }

        private void rdoAsc_CheckedChanged(object sender, EventArgs e)
        {
            ApplySorting();
        }

        private void rdoDesc_CheckedChanged(object sender, EventArgs e)
        {
            ApplySorting();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Make sure an employee is selected
            if (employeeBindingSource.Current == null)
            {
                MessageBox.Show(
                    "Please select an employee first.");

                return;
            }

            // Get selected row
            DataRowView selectedRow =
                (DataRowView)employeeBindingSource.Current;

            int employeeID =
                Convert.ToInt32(
                    selectedRow["Employee_ID"]);

            // Open Edit Form
           UpdateEmployeesForm updateemployees =
                new UpdateEmployeesForm(employeeID); 
          


            updateemployees.ShowDialog();

            // Refresh grid after editing
            employeeTableAdapter.Fill(
                dsSamsLiqourShop.Employee);
        }

        private void rdoAll_CheckedChanged(object sender, EventArgs e)
        {
            ApplyRoleFilter();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        { // Open Add Employee Form
            UpdateEmployeesForm addemployee = new UpdateEmployeesForm(2);
            addemployee.tabControl1.SelectedIndex = 1; // Select the Add Employee tab

            addemployee.ShowDialog();

            // Refresh employee list when form closes
            employeeTableAdapter.Fill(dsSamsLiqourShop.Employee);
        }

        private void rdoAsc_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    }
}

