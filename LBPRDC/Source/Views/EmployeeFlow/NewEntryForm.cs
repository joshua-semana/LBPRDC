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
using System.Xml.Serialization;

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
                cmbEmploymentStatus,
                cmbDepartment
            };
        }

        private void frmEmployeeDataEntry_Load(object sender, EventArgs e)
        {
            InitializePositionComboBoxItems();
            InitializeCivilStatusComboBoxItems();
            InitializeEmploymentStatusComboBoxItems();
            InitializeSuffixComboBoxItems();
            InitializeGenderComboBoxItems();
            InitializeDepartmentComboBoxItems();
        }

        private void InitializePositionComboBoxItems()
        {
            cmbPosition.DataSource = PositionService.GetAllItemsForComboBox();
            cmbPosition.DisplayMember = "Name";
            cmbPosition.ValueMember = "ID";
        }

        private void InitializeCivilStatusComboBoxItems()
        {
            cmbCivilStatus.DataSource = CivilStatusService.GetAllItemsForComboBox();
            cmbCivilStatus.DisplayMember = "Name";
            cmbCivilStatus.ValueMember = "ID";
        }

        private void InitializeEmploymentStatusComboBoxItems()
        {
            cmbEmploymentStatus.DataSource = EmploymentStatusService.GetAllItemsForComboBox();
            cmbEmploymentStatus.DisplayMember = "Name";
            cmbEmploymentStatus.ValueMember = "ID";
        }

        private void InitializeSuffixComboBoxItems()
        {
            cmbSuffix.DataSource = SuffixService.GetAllItemsForComboBox();
            cmbSuffix.DisplayMember = "Name";
            cmbSuffix.ValueMember = "ID";
        }

        private void InitializeDepartmentComboBoxItems()
        {
            cmbDepartment.DataSource = DepartmentService.GetAllItemsForComboBox();
            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "ID";
        }

        private void GetLocationComboBoxItems()
        {
            if (cmbDepartment.SelectedIndex != 0)
            {
                cmbLocation.Enabled = true;
                int DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue);
                cmbLocation.DataSource = LocationService.GetAllItemsForComboBox(DepartmentID);
                cmbLocation.DisplayMember = "Name";
                cmbLocation.ValueMember = "ID";
            }
            else
            {
                cmbLocation.DataSource = null;
                cmbLocation.Enabled = false;
            }
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

                EmployeeService.NewEmployee newEmployee = new()
                {
                    EmployeeID = txtEmployeeID.Text.ToUpper(),
                    LastName = txtLastName.Text.ToUpper(),
                    FirstName = txtFirstName.Text.ToUpper(),
                    MiddleName = txtMiddleName.Text.ToUpper(),
                    SuffixID = Convert.ToInt32(cmbSuffix.SelectedValue),
                    Gender = cmbGender.Text,
                    Birthday = dtpBirthday.Value,
                    Education = txtEducation.Text,
                    DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue),
                    LocationID = Convert.ToInt32(cmbLocation.SelectedValue),
                    EmailAddress1 = txtEmailAddress1.Text,
                    EmailAddress2 = txtEmailAddress2.Text,
                    ContactNumber1 = txtContactNumber1.Text,
                    ContactNumber2 = txtContactNumber2.Text,
                    CivilStatusID = Convert.ToInt32(cmbCivilStatus.SelectedValue),
                    PositionID = Convert.ToInt32(cmbPosition.SelectedValue),
                    EmploymentStatusID = Convert.ToInt32(cmbEmploymentStatus.SelectedValue),
                    Remarks = txtRemarks.Text,

                    StartDate = dtpStartDate.Value,
                    PositionTitle = txtPositionTitle.Text,
                    isPreviousEmployee = chkPreviousEmployee.Checked,
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
            else if (requiredFields.Contains(txtPreviousPosition))
            {
                requiredFields.Remove(txtPreviousPosition);
            }
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetLocationComboBoxItems();
        }
    }
}
