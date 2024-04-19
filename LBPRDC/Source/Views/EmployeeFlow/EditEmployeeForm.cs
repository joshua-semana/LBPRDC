using LBPRDC.Source.Config;
using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;

namespace LBPRDC.Source.Views.EmployeeFlow
{
    public partial class EditEmployeeForm : Form
    {
        public int EmployeeID { get; set; }
        public int ClientID { get; set; }
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
            if (EmployeeID != 0 && ClientID != 0)
            {
                InitializeEmployeeInformation(EmployeeID);
            }
            else
            {
                MessageBox.Show(MessagesConstants.Error.RETRIEVE_DATA, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private async void InitializePositionComboBoxItems(int ID, string Name)
        {
            var items = await PositionService.GetAllItemsForComboBoxByClientID(ClientID);
            cmbPosition.DisplayMember = "Name";
            cmbPosition.ValueMember = "ID";
            bool itemExists = items.Any(a => a.ID == ID);
            if (!itemExists)
            {
                items.Add(new Models.Position { ID = ID, Name = Name });
            }
            cmbPosition.DataSource = items;
            cmbPosition.SelectedValue = ID;
        }

        private async void InitializeCivilStatusComboBoxItems(int ID, string Name)
        {
            var items = await CivilStatusService.GetAllItemsForComboBox();
            cmbCivilStatus.DisplayMember = "Name";
            cmbCivilStatus.ValueMember = "ID";
            bool itemExists = items.Any(a => a.ID == ID);
            if (!itemExists)
            {
                items.Add(new Models.CivilStatus { ID = ID, Name = Name });
            }
            cmbCivilStatus.DataSource = items;
            cmbCivilStatus.SelectedValue = ID;
        }

        private void InitializeEmploymentStatusComboBoxItems(int ID, string Name)
        {
            var items = EmploymentStatusService.GetAllItemsForComboBox();
            cmbEmploymentStatus.DisplayMember = "Name";
            cmbEmploymentStatus.ValueMember = "ID";
            bool itemExists = items.Any(a => a.ID == ID);
            if (!itemExists)
            {
                items.Add(new EmploymentStatusService.EmploymentStatus { ID = ID, Name = Name });
            }
            cmbEmploymentStatus.DataSource = items;
            cmbEmploymentStatus.SelectedValue = ID;
        }

        private void InitializeSuffixComboBoxItems(int ID, string Name)
        {
            var items = SuffixService.GetAllItemsForComboBox();
            cmbSuffix.DisplayMember = "Name";
            cmbSuffix.ValueMember = "ID";
            bool itemExists = items.Any(a => a.ID == ID);
            if (!itemExists)
            {
                items.Add(new SuffixService.Suffix { ID = ID, Name = Name });
            }
            cmbSuffix.DataSource = items;
            cmbSuffix.SelectedValue = ID;
        }

        private async void InitializeDepartmentComboBoxItems(int ID, string Name)
        {
            var items = await DepartmentService.GetAllItemsForComboBoxByClientID(ClientID);
            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "ID";
            bool itemExists = items.Any(a => a.ID == ID);
            if (!itemExists)
            {
                items.Add(new Models.Department { ID = ID, Name = Name });
            }
            cmbDepartment.DataSource = items;
            cmbDepartment.SelectedValue = ID;
        }

        private async void InitializeLocationComboBoxItems(int DepartmentID, int ID, string Name)
        {
            var items = await LocationService.GetAllItemsForComboBoxByID(Convert.ToInt32(DepartmentID));
            cmbLocation.DisplayMember = "Name";
            cmbLocation.ValueMember = "ID";
            bool itemExists = items.Any(a => a.ID == ID);
            if (!itemExists)
            {
                items.Add(new Models.Location { ID = ID, Name = Name });
            }
            cmbLocation.DataSource = items;
            cmbLocation.SelectedValue = ID;
        }

        private void InitializeGenderComboBoxItems(string ID)
        {
            cmbGender.SelectedItem = ID;
        }

        private async void InitializeWageTypeComboBoxItems(int ID, string Name)
        {
            var items = await WageService.GetAllItemsForComboBox();
            cmbWageType.DisplayMember = "Name";
            cmbWageType.ValueMember = "ID";
            bool itemExists = items.Any(a => a.ID == ID);
            if (!itemExists)
            {
                items.Add(new Models.Wage { ID = ID, Name = Name });
            }
            cmbWageType.DataSource = items;
            cmbWageType.SelectedValue = ID;
        }

        private async void InitializeEmployeeInformation(int EmployeeID)
        {
            var employeeList = await EmployeeService.GetAllEmployeeInfoByClientID(ClientID, EmployeeID);

            if (employeeList == null && !employeeList.Any())
            {
                MessageBox.Show(MessagesConstants.Error.MISSING_EMPLOYEE, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            var employee = employeeList.First();
            var positionHistory = await PositionService.GetEmployeeHistory(EmployeeID);
            var employmentStatusHistory = await EmploymentStatusService.GetEmployeeHistory(EmployeeID);
            var employeePreviousRecord = await PreviousEmployeeService.GetEmployeeHistory(EmployeeID);

            txtFirstName.Text = employee.FirstName;
            txtMiddleName.Text = employee.MiddleName;
            txtLastName.Text = employee.LastName;
            txtEducation.Text = employee.Education;
            dtpBirthday.Value = employee.Birthday;
            txtEmailAddress1.Text = employee.EmailAddress1;
            txtEmailAddress2.Text = employee.EmailAddress2;
            txtContactNumber1.Text = employee.ContactNumber1;
            txtContactNumber2.Text = employee.ContactNumber2;
            txtEmployeeID.Text = employee.EmployeeID;
            dtpPositionEffectiveDate.Value = positionHistory != null ? positionHistory.Timestamp : DateTime.MinValue;
            dtpStatusEffectiveDate.Value = employmentStatusHistory != null ? employmentStatusHistory.Timestamp : DateTime.MinValue;
            txtPositionTitle.Text = positionHistory != null ? Utilities.StringFormat.ToSentenceCase(positionHistory.PositionTitle) : "Error Getting Data";
            txtRemarks.Text = employee.Remarks;
            InitializeGenderComboBoxItems(employee.Gender);
            InitializePositionComboBoxItems(employee.PositionID, employee.PositionName);
            InitializeCivilStatusComboBoxItems(employee.CivilStatusID, employee.CivilStatusName);
            InitializeEmploymentStatusComboBoxItems(employee.EmploymentStatusID, employee.EmploymentStatusName);
            InitializeSuffixComboBoxItems(employee.SuffixID, employee.SuffixName);
            InitializeDepartmentComboBoxItems(employee.DepartmentID, employee.DepartmentName);
            InitializeLocationComboBoxItems(employee.DepartmentID, employee.LocationID, employee.LocationName);
            InitializeWageTypeComboBoxItems(employee.WageID, employee.WageName);

            if (employeePreviousRecord.HasRecord)
            {
                employeeHasRecord = employeePreviousRecord.HasRecord;
                chkPreviousEmployee.Checked = true;
                grpPreviousWork.Enabled = true;
                txtPreviousPosition.Text = employeePreviousRecord.Position;
                dtpFromDate.Value = employeePreviousRecord.StartDate;
                dtpToDate.Value = employeePreviousRecord.EndDate;
                txtOtherInformation.Text = employeePreviousRecord.Information;
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
            var result = MessageBox.Show(MessagesConstants.Cancel.QUESTION, MessagesConstants.Cancel.TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                ID = EmployeeID,
                EmployeeID = txtEmployeeID.Text,
                LastName = txtLastName.Text.ToUpper(),
                FirstName = txtFirstName.Text.ToUpper(),
                MiddleName = txtMiddleName.Text.ToUpper(),
                SuffixID = Convert.ToInt32(cmbSuffix.SelectedValue),
                Gender = cmbGender.Text,
                Birthday = dtpBirthday.Value,
                Education = txtEducation.Text,
                DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue),
                Department = cmbDepartment.Text,
                LocationID = Convert.ToInt32(cmbLocation.SelectedValue),
                Location = cmbLocation.Text,
                EmailAddress1 = txtEmailAddress1.Text,
                EmailAddress2 = txtEmailAddress2.Text,
                ContactNumber1 = txtContactNumber1.Text,
                ContactNumber2 = txtContactNumber2.Text,
                CivilStatusID = Convert.ToInt32(cmbCivilStatus.SelectedValue),
                PositionID = Convert.ToInt32(cmbPosition.SelectedValue),
                EmploymentStatusID = Convert.ToInt32(cmbEmploymentStatus.SelectedValue),
                Remarks = txtRemarks.Text,
                WageID = Convert.ToInt32(cmbWageType.SelectedValue),

                PositionEffectiveDate = dtpPositionEffectiveDate.Value,
                StatusEffectiveDate = dtpStatusEffectiveDate.Value,
                PositionTitle = txtPositionTitle.Text.ToUpper().Trim(),
                isPreviousEmployee = chkPreviousEmployee.Checked,
                PreviousFrom = dtpFromDate.Value,
                PreviousTo = dtpToDate.Value,
                PreviousPosition = txtPreviousPosition.Text,
                OtherInformation = txtOtherInformation.Text,
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

        private async void GetLocationComboBoxItems()
        {
            if (cmbDepartment.SelectedIndex != 0)
            {
                cmbLocation.Enabled = true;
                int DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue);
                cmbLocation.DataSource = await LocationService.GetAllItemsForComboBoxByID(DepartmentID);
                cmbLocation.DisplayMember = "Name";
                cmbLocation.ValueMember = "ID";
            }
            else
            {
                cmbLocation.DataSource = null;
                cmbLocation.Enabled = false;
            }
        }

        private void ValidateInputIfNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}
