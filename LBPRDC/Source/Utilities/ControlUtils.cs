using LBPRDC.Source.Views.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBPRDC.Source.Utilities
{
    internal class ControlUtils
    {
        public static bool AreInputsEmpty(Control container)
        {
            foreach (Control control in container.Controls)
            {
                if (control is TextBox textBox)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        return true;
                    }
                }
                // You can add more conditions for other types of controls (e.g., ComboBox, etc.) if needed
            }
            return false;
        }

        public static void ToggleInputState(Control container)
        {
            foreach(Control control in container.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Enabled = !textBox.Enabled;
                }
            }
        }

        public static void ClearInputs(Control container)
        {
            foreach (Control control in container.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Text = "";
                }
            }
        }

        public static bool AreRequiredFieldsFilled(List<Control> fields)
        {
            List<string> emptyField = new();

            foreach (Control control in fields)
            {
                if (control is TextBox)
                {
                    if (string.IsNullOrWhiteSpace(control.Text))
                    {
                        emptyField.Add(control.AccessibleName);
                    }
                }
                else if (control is ComboBox comboBox)
                {
                    if (comboBox.SelectedIndex == 0)
                    {
                        emptyField.Add(control.AccessibleName);
                    }
                }
            }

            if (emptyField.Count > 0)
            {
                string emptyFields = string.Join("\n", emptyField);
                MessageBox.Show($"The following fields are required:\n{emptyFields}", "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        public static void ResetFilters(Control container)
        {
            foreach (Control control in container.Controls)
            {
                if (control is DynamicCheckedListBoxControl dynamicCheckbox)
                {
                    dynamicCheckbox.ClearCheckedItems();
                }
            }
        }

        public static void AddColumn(DataGridView dgvTable, string name, string header, string property)
        {
            dgvTable.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                DataPropertyName = property
            });
        }

        public static string GetTableRowCount(int currentCount, int originalCount, string name)
        {
            return $"Currently displaying {currentCount} out of {originalCount} {name}(s).";
        }
    }
}
