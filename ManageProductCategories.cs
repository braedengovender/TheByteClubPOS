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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TheByteClubPOS
{
    public partial class ManageProductCategories : Form
    {
        public ManageProductCategories()
        {
            InitializeComponent();
        }

        private void ManageProductCategories_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsSamsLiqourShop.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.dsSamsLiqourShop.Category);
            this.dataGridView3.CellClick += dataGridView3_CellClick;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Add new category to database
            try
            {
                string name = txtCategoryName.Text.Trim();
                string description = txtCatDescription.Text.Trim();

                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Please enter a category name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCategoryName.Focus();
                    return;
                }

                // Attempt to get a discount id from the combo box. If not available or not parseable, pass null.
                int? discountId = null;
                if (cmbDiscount.SelectedValue != null && cmbDiscount.SelectedValue != DBNull.Value)
                {
                    if (int.TryParse(cmbDiscount.SelectedValue.ToString(), out int parsed))
                        discountId = parsed;
                }

                // Insert the category. The typed TableAdapter Insert accepts (string, string, Nullable<int>).
                categoryTableAdapter.Insert(
                    name,
                    string.IsNullOrEmpty(description) ? null : description,
                    discountId);

                // Refresh local dataset so DataGridViews update
                this.categoryTableAdapter.Fill(this.dsSamsLiqourShop.Category);

                // Clear inputs and notify user
                txtCategoryName.Clear();
                txtCatDescription.Clear();
                MessageBox.Show("Category added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Show error so you can debug DB/connectivity issues
                MessageBox.Show("Failed to add category: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCDel_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input
                if (!int.TryParse(txtDel.Text.Trim(), out int categoryId))
                {
                    MessageBox.Show("Please enter a valid numeric Category ID.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDel.Focus();
                    return;
                }

                // Find the row in the typed dataset
                var categoryRow = this.dsSamsLiqourShop.Category.FindByCategory_ID(categoryId);
                if (categoryRow == null)
                {
                    MessageBox.Show($"No category found with ID {categoryId}.", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Ask for confirmation
                var confirm = MessageBox.Show($"Delete category '{categoryRow.Category_Name}' (ID {categoryId})?\nThis action cannot be undone.", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm != DialogResult.Yes) return;

                // Mark row for deletion and push change to DB
                categoryRow.Delete();
                int affected = this.categoryTableAdapter.Update(this.dsSamsLiqourShop.Category);

                // Refresh dataset to reflect current DB state
                this.categoryTableAdapter.Fill(this.dsSamsLiqourShop.Category);

                if (affected > 0)
                {
                    txtDel.Clear();
                    MessageBox.Show("Category deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Delete completed but no rows were affected. Verify the database and try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete category: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return; // header clicked

                var row = this.dataGridView3.Rows[e.RowIndex];
                var drv = row.DataBoundItem as DataRowView;
                if (drv == null) return;

                // Fill the "Display / Update" controls
                // textBox6 = Enter CategoryID, textBox4 = Category Name, textBox5 = Description, comboBox2 = Discount
                object idObj = drv["Category_ID"];
                object nameObj = drv["Category_Name"];
                object descObj = drv["Category_Description"];
                object discountObj = drv["Discount_ID"];

                textBox6.Text = idObj != DBNull.Value ? idObj.ToString() : string.Empty;
                textBox4.Text = nameObj != DBNull.Value ? nameObj.ToString() : string.Empty;
                textBox5.Text = descObj != DBNull.Value ? descObj.ToString() : string.Empty;

                // Set comboBox2 selected value if it contains discount items
                if (discountObj != DBNull.Value && discountObj != null)
                {
                    int parsed;
                    if (int.TryParse(discountObj.ToString(), out parsed))
                    {
                        try
                        {
                            comboBox2.SelectedValue = parsed;
                        }
                        catch
                        {
                            // If comboBox2 isn't populated with discount items yet, just leave it unselected.
                            comboBox2.SelectedIndex = -1;
                        }
                    }
                    else
                    {
                        comboBox2.SelectedIndex = -1;
                    }
                }
                else
                {
                    comboBox2.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to populate update fields: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate Category ID
                if (!int.TryParse(textBox6.Text.Trim(), out int categoryId))
                {
                    MessageBox.Show("Please select a category (click a row) or enter a valid Category ID.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox6.Focus();
                    return;
                }

                var categoryRow = this.dsSamsLiqourShop.Category.FindByCategory_ID(categoryId);
                if (categoryRow == null)
                {
                    MessageBox.Show($"No category found with ID {categoryId}.", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Validate name
                string newName = textBox4.Text.Trim();
                if (string.IsNullOrWhiteSpace(newName))
                {
                    MessageBox.Show("Category name cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox4.Focus();
                    return;
                }

                // Apply changes to the DataRow
                categoryRow.Category_Name = newName;

                if (string.IsNullOrWhiteSpace(textBox5.Text))
                {
                    categoryRow.SetCategory_DescriptionNull();
                }
                else
                {
                    categoryRow.Category_Description = textBox5.Text.Trim();
                }

                // Discount (optional)
                if (comboBox2.SelectedValue != null && comboBox2.SelectedValue != DBNull.Value)
                {
                    if (int.TryParse(comboBox2.SelectedValue.ToString(), out int discountId))
                        categoryRow.Discount_ID = discountId;
                    else
                        categoryRow.SetDiscount_IDNull();
                }
                else
                {
                    categoryRow.SetDiscount_IDNull();
                }

                // Persist update
                int affected = this.categoryTableAdapter.Update(this.dsSamsLiqourShop.Category);

                // Refresh dataset so UI reflects DB
                this.categoryTableAdapter.Fill(this.dsSamsLiqourShop.Category);

                if (affected > 0)
                {
                    MessageBox.Show("Category updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Update completed but no rows were affected. Verify the database and try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update category: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            categoryTableAdapter.FillByName(dsSamsLiqourShop.Category, textBox7.Text.Trim());
        }
    }
}
