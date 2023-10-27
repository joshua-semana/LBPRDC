using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;
using System.Data;

namespace LBPRDC.Source.Views.EmployeeFlow
{
    public partial class EditEmployeeForm : Form
    {
        public string? EmployeeId { get; set; }
        public ucEmployees? ParentControl { get; set; }

        private readonly List<Control> requiredFields;

        private bool employeeHasRecord;

        public EditEmployeeForm()
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

        private void EditEmployeeForm_Load(object sender, EventArgs e)
        {
            if (EmployeeId != null)
            {
                InitializeEmployeeInformation(EmployeeId);
            }
        }

        private void InitializePositionComboBoxItems(int value)
        {
            cmbPosition.DataSource = PositionService.GetAllItemsForComboBox();
            cmbPosition.DisplayMember = "Name";
            cmbPosition.ValueMember = "ID";
            cmbPosition.SelectedValue = value;
        }

        private void InitializeCivilStatusComboBoxItems(int value)
        {
            cmbCivilStatus.DataSource = CivilStatusService.GetAllItemsForComboBox();
            cmbCivilStatus.DisplayMember = "Name";
            cmbCivilStatus.ValueMember = "ID";
            cmbCivilStatus.SelectedValue = value;
        }

        private void InitializeEmploymentStatusComboBoxItems(int value)
        {
            cmbEmploymentStatus.DataSource = EmploymentStatusService.GetAllItemsForComboBox();
            cmbEmploymentStatus.DisplayMember = "Name";
            cmbEmploymentStatus.ValueMember = "ID";
            cmbEmploymentStatus.SelectedValue = value;
        }

        private void InitializeSuffixComboBoxItems(int value)
        {
            cmbSuffix.DataSource = SuffixService.GetAllItemsForComboBox();
            cmbSuffix.DisplayMember = "Name";
            cmbSuffix.ValueMember = "ID";
            cmbSuffix.SelectedValue = value;
        }

        private void InitializeDepartmentComboBoxItems(int value)
        {
            cmbDepartment.DataSource = DepartmentService.GetAllItemsForComboBox();
            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "ID";
            cmbDepartment.SelectedValue = value;
        }

        private void InitializeLocationComboBoxItems(int deparment, int value)
        {
            int DepartmentID = Convert.ToInt32(deparment);
            cmbLocation.DataSource = LocationService.GetAllItemsForComboBox(DepartmentID);
            cmbLocation.DisplayMember = "Name";
            cmbLocation.ValueMember = "ID";
            cmbLocation.SelectedValue = value;
        }

        private void InitializeGenderComboBoxItems(string value)
        {
            cmbGender.SelectedItem = value;
        }

        private void InitializeEmployeeInformation(string ID)
        {
            List<EmployeeService.Employee> employees = EmployeeService.GetAllEmployees();
            List<PositionService.History> positions = PositionService.GetAllHistory();
            PreviousEmployeeService.PreviousEmployee employeeRecord = PreviousEmployeeService.GetRecordByEmployeeID(ID);

            var employee = employees.First(e => e.EmployeeID == ID);
            var currentPosition = positions.First(p => p.EmployeeID == ID && p.Status == "Active");

            txtFirstName.Text = employee.FirstName;
            txtMiddleName.Text = employee.MiddleName;
            txtLastName.Text = employee.LastName;
            txtEducation.Text = employee.Education;
            dtpBirthday.Value = employee.Birthday.Value;
            txtEmailAddress1.Text = employee.EmailAddress1;
            txtEmailAddress2.Text = employee.EmailAddress2;
            txtContactNumber1.Text = employee.ContactNumber1;
            txtContactNumber2.Text = employee.ContactNumber2;
            txtEmployeeID.Text = employee.EmployeeID;
            dtpStartDate.Value = currentPosition.Timestamp.Value;
            txtPositionTitle.Text = Utilities.StringFormat.ToSentenceCase(currentPosition.PositionTitle);
            txtRemarks.Text = employee.Remarks;
            InitializeGenderComboBoxItems(employee.Gender);
            InitializePositionComboBoxItems(employee.PositionID);
            InitializeCivilStatusComboBoxItems(employee.CivilStatusID);
            InitializeEmploymentStatusComboBoxItems(employee.EmploymentStatusID);
            InitializeSuffixComboBoxItems(employee.SuffixID);
            InitializeDepartmentComboBoxItems(employee.DepartmentID);
            InitializeLocationComboBoxItems(employee.DepartmentID, employee.LocationID);

            employeeHasRecord = employeeRecord.HasRecord;

            if (employeeRecord.HasRecord)
            {
                chkPreviousEmployee.Checked = true;
                grpPreviousWork.Enabled = true;
                txtPreviousPosition.Text = employeeRecord.Position;
                dtpFromDate.Value = employeeRecord.StartDate.Value;
                dtpToDate.Value = employeeRecord.EndDate.Value;
                txtOtherInformation.Text = employeeRecord.Information;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to cancel this operation?", "Cancel Operation Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ControlUtils.AreRequiredFieldsFilled(requiredFields))
            {
                if (employeeHasRecord && !chkPreviousEmployee.Checked)
                {
                    var result = MessageBox.Show("It has been detected that you've unchecked the checkbox for stating that this person is a previous employee of LBRDC. Are you sure you want to proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No) return;
                }

                var result1 = MessageBox.Show("Are you sure you want to update this employee's information?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result1 == DialogResult.No) return;

                UpdateEmployeeInformation();
            }
        }

        private async void UpdateEmployeeInformation()
        {
            EmployeeService.EmployeeHistory data = new()
            {
                EmployeeID = txtEmployeeID.Text,
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

                EffectiveDate = dtpStartDate.Value,
                PositionTitle = txtPositionTitle.Text.ToUpper().Trim(),
                isPreviousEmployee = chkPreviousEmployee.Checked,
                PreviousFrom = dtpFromDate.Value,
                PreviousTo = dtpToDate.Value,
                PreviousPosition = txtPreviousPosition.Text,
                OtherInformation = txtOtherInformation.Text
            };

            bool isUpdated = await EmployeeService.UpdateEmployee(data);

            if (isUpdated)
            {
                MessageBox.Show("You have successfully updated this employee's information.", "Update Employee Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ParentControl?.ApplyFilterAndSearchThenPopulate();
                this.Close();
            }
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetLocationComboBoxItems();
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
    }
}
