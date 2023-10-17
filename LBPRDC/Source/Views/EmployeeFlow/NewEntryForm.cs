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
    public partial class frmNewEntryEmployee : Form
    {
        public ucEmployees? ParentControl { get; set; }
        private readonly List<Control> requiredFields;

        public frmNewEntryEmployee()
        {
            InitializeComponent();

            requiredFields = new List<Control>
            {
                txtFirstName,
                txtLastName,
                cmbGender,
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
            cmbPosition.DataSource = PositionService.GetPositionItems();
            cmbPosition.DisplayMember = "DisplayText";
            cmbPosition.ValueMember = "ID";
        }

        private void InitializeCivilStatusComboBoxItems()
        {
            cmbCivilStatus.DataSource = CivilStatusService.GetCivilStatusItems();
            cmbCivilStatus.DisplayMember = "Status";
            cmbCivilStatus.ValueMember = "ID";
        }

        private void InitializeEmploymentStatusComboBoxItems()
        {
            cmbEmploymentStatus.DataSource = EmploymentStatusService.GetEmploymentStatusItems();
            cmbEmploymentStatus.DisplayMember = "Status";
            cmbEmploymentStatus.ValueMember = "ID";
        }

        private void InitializeSuffixComboBoxItems()
        {
            cmbSuffix.DataSource = SuffixService.GetSuffixItems();
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
                string emptyFields = string.Join("\n", emptyField);
                MessageBox.Show($"The following fields are required:\n{emptyFields}", "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            if (AreRequiredFieldsFilled())
            {
                if (EmployeeService.IDExists(txtEmployeeID.Text))
                {
                    MessageBox.Show("The Employee ID you entered already exists in the database. Please enter a different ID.", "Employee ID Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtContactNumber1.Text != "" && txtContactNumber1.Text.Length < 11)
                {
                    MessageBox.Show("Contact number should be 11 digits.", "Contact Number Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtContactNumber2.Text != "" && txtContactNumber2.Text.Length < 11)
                {
                    MessageBox.Show("Contact number should be 11 digits.", "Contact Number Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                NewEmployee newEmployee = new()
                {
                    EmployeeID = txtEmployeeID.Text.ToUpper(),
                    LastName = txtLastName.Text.ToUpper(),
                    FirstName = txtFirstName.Text.ToUpper(),
                    MiddleName = txtMiddleName.Text.ToUpper(),
                    SuffixID = cmbSuffix.SelectedIndex + 1,
                    Gender = cmbGender.Text,
                    Birthday = dtpBirthday.Value,
                    Education = txtEducation.Text,
                    Department = txtDepartment.Text,
                    EmailAddress1 = txtEmailAddress1.Text,
                    EmailAddress2 = txtEmailAddress2.Text,
                    ContactNumber1 = txtContactNumber1.Text,
                    ContactNumber2 = txtContactNumber2.Text,
                    CivilStatusID = cmbCivilStatus.SelectedIndex,
                    PositionID = cmbPosition.SelectedIndex,
                    EmploymentStatusID = cmbEmploymentStatus.SelectedIndex,

                    StartDate = dtpStartDate.Value,
                    PositionTitle = txtPositionTitle.Text,
                    Remarks = txtRemarks.Text,
                    isPreviousEmployee = true,
                    PreviousFrom = dtpFromDate.Value,
                    PreviousTo = dtpToDate.Value,
                    PreviousPosition = txtPreviousPosition.Text,
                    OtherInformation = txtOtherInformation.Text
                };

                bool isAdded = await EmployeeService.AddNewEmployee(newEmployee);

                if (isAdded)
                {
                    MessageBox.Show("You have successfully added a new employee.", "New Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ParentControl?.PopulateTable();
                    this.Close();
                }
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

        private void chkPreviousEmployee_CheckedChanged(object sender, EventArgs e)
        {
            grpPreviousWork.Enabled = chkPreviousEmployee.Checked;
            if (chkPreviousEmployee.Checked)
            {
                requiredFields.Add(txtPreviousPosition);
            }
            else if(requiredFields.Contains(txtPreviousPosition))
            {
                requiredFields.Remove(txtPreviousPosition);
            }
        }
    }
}
