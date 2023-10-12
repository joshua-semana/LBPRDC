using LBPRDC.Source.Services;
using OfficeOpenXml.Drawing.Slicer.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LBPRDC.Source.Views
{
    public partial class frmEmployeeDataEntry : Form
    {
        private List<Control> requiredFields;

        public frmEmployeeDataEntry()
        {
            InitializeComponent();

            requiredFields = new List<Control>
            {
                txtFirstName,
                txtLastName,
                cmbCivilStatus,
                txtEmployeeID,
                cmbPosition,
                cmbEmploymentStatus
            };
        }

        private void frmEmployeeDataEntry_Load(object sender, EventArgs e)
        {
            InitializePositionComboBoxItems();
            InitializeCivilStatusComboBoxItems();
            InitializeEmploymentStatusComboBoxItems();
            InitializeSuffixComboBoxItems();
            InitializeGenderComboBoxItems();
        }

        private void InitializePositionComboBoxItems()
        {
            cmbPosition.DataSource = Services.PositionService.GetPositionItems();
            cmbPosition.DisplayMember = "DisplayText";
            cmbPosition.ValueMember = "ID";
        }

        private void InitializeCivilStatusComboBoxItems()
        {
            cmbCivilStatus.DataSource = Services.CivilStatusService.GetCivilStatusItems();
            cmbCivilStatus.DisplayMember = "Status";
            cmbCivilStatus.ValueMember = "ID";
        }

        private void InitializeEmploymentStatusComboBoxItems()
        {
            cmbEmploymentStatus.DataSource = Services.EmploymentStatusService.GetEmploymentStatusItems();
            cmbEmploymentStatus.DisplayMember = "Status";
            cmbEmploymentStatus.ValueMember = "ID";
        }

        private void InitializeSuffixComboBoxItems()
        {
            cmbSuffix.DataSource = Services.SuffixService.GetSuffixItems();
            cmbSuffix.DisplayMember = "Name";
            cmbSuffix.ValueMember = "ID";
        }

        private void InitializeGenderComboBoxItems()
        {
            cmbGender.SelectedIndex = 0;
        }

        private bool AreRequiredFieldsFilled()
        {
            List<string> emptyField = new List<string>();

            foreach (Control control in requiredFields)
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
                string emptyFields = string.Join(", ", emptyField);
                MessageBox.Show($"The following fields are required: {emptyFields}", "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(AreRequiredFieldsFilled())
            {
                if(Services.EmployeeService.IDExists(txtEmployeeID.Text))
                {
                    MessageBox.Show("The Employee ID you entered already exists in the database. Please enter a different ID.", "Employee ID Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                NewEmployee newEmployee = new()
                {
                    
                };
            }
        }

        private void txtContactNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to cancel this operation?", "Cancel Adding of Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
