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
            List<EmployeeService.Employee> employee = EmployeeService.GetAllEmployees();
            List<PositionService.History> positionHistory = PositionService.GetAllHistory();
            PreviousEmployeeService.PreviousEmployee employeeRecord = PreviousEmployeeService.GetRecordByEmployeeID(ID);

            employee = employee.Where(w => w.EmployeeID == ID).ToList();
            txtFirstName.Text = employee.First().FirstName;
            txtMiddleName.Text = employee.First().MiddleName;
            txtLastName.Text = employee.First().LastName;
            txtEducation.Text = employee.First().Education;
            dtpBirthday.Value = employee.First().Birthday.Value;
            txtEmailAddress1.Text = employee.First().EmailAddress1;
            txtEmailAddress2.Text = employee.First().EmailAddress2;
            txtContactNumber1.Text = employee.First().ContactNumber1;
            txtContactNumber2.Text = employee.First().ContactNumber2;
            txtEmployeeID.Text = employee.First().EmployeeID;
            dtpStartDate.Value = positionHistory.Where(w => w.EmployeeID == ID && w.Status == "Active").First().Timestamp.Value;
            txtPositionTitle.Text = Utilities.StringFormat.ToSentenceCase(positionHistory.Where(w => w.EmployeeID == ID && w.Status == "Active").First().PositionTitle);
            txtRemarks.Text = employee.First().Remarks;
            InitializeGenderComboBoxItems(employee.First().Gender);
            InitializePositionComboBoxItems(employee.First().PositionID);
            InitializeCivilStatusComboBoxItems(employee.First().CivilStatusID);
            InitializeEmploymentStatusComboBoxItems(employee.First().EmploymentStatusID);
            InitializeSuffixComboBoxItems(employee.First().SuffixID);
            InitializeDepartmentComboBoxItems(employee.First().DepartmentID);
            InitializeLocationComboBoxItems(employee.First().DepartmentID, employee.First().LocationID);

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
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to cancel this operation?", "Cancel Adding of Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                ParentControl?.PopulateTable();
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
