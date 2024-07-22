using LBPRDC.Source.Config;
using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;

namespace LBPRDC.Source.Views.EmployeeFlow
{
    public partial class EditEmployeeForm : Form
    {
        public int ClientID { get; set; }
        public int EmployeeID { get; set; }
        public ucEmployees? ParentControl { get; set; }

        private readonly List<Control> requiredFields;

        private bool isFormerEmployee = false;

        public EditEmployeeForm()
        {
            InitializeComponent();

            requiredFields = new List<Control>
            {
                txtFirstName,
                txtLastName,
                cmbGender,
                txtEmployeeID,
                cmbPosition,
                cmbEmploymentStatus,
                cmbDepartment
            };
        }

        private void EditEmployeeForm_Load(object sender, EventArgs e)
        {
            if (EmployeeID == 0 || ClientID == 0)
            {
                MessageBox.Show(MessagesConstants.Error.RETRIEVE_DATA, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            PopulateEmployeeInformation(EmployeeID);
        }

        private void InitializeGenderComboBoxItems(string name)
        {
            cmbGender.SelectedItem = name;
        }

        private async void InitializeSuffixComboBoxItems(int ID, string Name)
        {
            var items = await SuffixService.GetAllItemsForComboBox();
            cmbSuffix.DisplayMember = "Name";
            cmbSuffix.ValueMember = "ID";
            bool itemExists = items.Any(a => a.ID == ID);
            if (!itemExists)
            {
                items.Add(new Models.Suffix { ID = ID, Name = Name });
            }
            cmbSuffix.DataSource = items;
            cmbSuffix.SelectedValue = ID;
        }

        private async void InitializeEmploymentStatusComboBoxItems(int ID, string Name)
        {
            var items = await EmploymentStatusService.GetAllItemsForComboBox();
            cmbEmploymentStatus.DisplayMember = "Name";
            cmbEmploymentStatus.ValueMember = "ID";
            bool itemExists = items.Any(a => a.ID == ID);
            if (!itemExists)
            {
                items.Add(new Models.EmploymentStatus { ID = ID, Name = Name });
            }
            cmbEmploymentStatus.DataSource = items;
            cmbEmploymentStatus.SelectedValue = ID;
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

        private async void InitializeClassificationComboBoxItems(int ID, string Name)
        {
            var items = await ClassificationService.GetAllItemsForComboBoxByClientID(ClientID);
            cmbClassification.DisplayMember = "Name";
            cmbClassification.ValueMember = "ID";
            bool itemExists = items.Any(a => a.ID == ID);
            if (!itemExists)
            {
                items.Add(new Models.Classification { ID = ID, Name = Name });
            }
            cmbClassification.DataSource = items;
            cmbClassification.SelectedValue = ID;
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

        private async void InitializeDepartmentComboBoxItems(int ID, string Name)
        {
            var items = await DepartmentService.GetAllItemsForComboBox(ClientID);
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

        private async void PopulateEmployeeInformation(int EmployeeID)
        {
            var employees = await EmployeeService.GetEmployees(ClientID, EmployeeID);
            var positionHistories = await PositionService.GetAllEmployeeHistory(EmployeeID);
            var employmentStatusHistory = await EmploymentStatusService.GetEmployeeHistory(EmployeeID);

            if (!employees.Any() || !positionHistories.Any() || employmentStatusHistory == null)
            {
                MessageBox.Show(MessagesConstants.Error.MISSING_EMPLOYEE, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            var e = employees.First();

            txtFirstName.Text = e.FirstName;
            txtMiddleName.Text = e.MiddleName;
            txtLastName.Text = e.LastName;
            txtEmailAddress1.Text = e.EmailAddress1;
            txtEmailAddress2.Text = e.EmailAddress2;
            txtContactNumber1.Text = e.ContactNumber1;
            txtContactNumber2.Text = e.ContactNumber2;
            txtEmployeeID.Text = e.EmployeeID;
            txtRemarks.Text = e.Remarks;

            InitializeSuffixComboBoxItems(e.SuffixID, e.SuffixName);
            InitializeGenderComboBoxItems(e.Gender);
            InitializeEmploymentStatusComboBoxItems(e.EmploymentStatusID, e.EmploymentStatusName);
            InitializeClassificationComboBoxItems(e.ClassificationID, e.ClassificationName);
            InitializeWageTypeComboBoxItems(e.WageID, e.WageName);
            InitializePositionComboBoxItems(e.PositionID, e.PositionName);
            InitializeDepartmentComboBoxItems(e.DepartmentID, e.DepartmentName);
            InitializeLocationComboBoxItems(e.DepartmentID, e.LocationID, e.LocationName);
            
            var currentPosition = positionHistories.Where(w => w.Status == StringConstants.Status.ACTIVE).FirstOrDefault();
            dtpPositionEffectiveDate.Value = currentPosition != null ? currentPosition.Timestamp : dtpPositionEffectiveDate.MinDate;
            txtPositionTitle.Text = currentPosition != null ? Utilities.StringFormat.ToSentenceCase(currentPosition.PositionTitle) : "Error Getting Data";

            dtpStatusEffectiveDate.Value = employmentStatusHistory != null ? employmentStatusHistory.Timestamp : dtpStatusEffectiveDate.MinDate;

            var employeePreviousRecordList = await PreviousEmployeeService.GetEmployeeFormerHistory(EmployeeID);
            isFormerEmployee = employeePreviousRecordList.Any();

            if (isFormerEmployee)
            {
                var entity = employeePreviousRecordList.First();
                chkPreviousEmployee.Checked = true;
                grpPreviousWork.Enabled = true;
                txtPreviousPosition.Text = entity.Position;
                dtpFromDate.Value = entity.StartDate;
                dtpToDate.Value = entity.EndDate;
                txtOtherInformation.Text = entity.Information;
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
                if (isFormerEmployee && !chkPreviousEmployee.Checked)
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
            var isUpdated = await EmployeeService.UpdateEmployee(new()
            {
                ID = EmployeeID,
                EmployeeID = txtEmployeeID.Text,
                FirstName = txtFirstName.Text.ToUpper().Trim(),
                MiddleName = txtMiddleName.Text.ToUpper().Trim(),
                LastName = txtLastName.Text.ToUpper().Trim(),
                Gender = cmbGender.Text,

                EmailAddress1 = txtEmailAddress1.Text,
                EmailAddress2 = txtEmailAddress2.Text,
                ContactNumber1 = txtContactNumber1.Text,
                ContactNumber2 = txtContactNumber2.Text,
                Remarks = txtRemarks.Text,

                SuffixID = Convert.ToInt32(cmbSuffix.SelectedValue),
                EmploymentStatusID = Convert.ToInt32(cmbEmploymentStatus.SelectedValue),

                ClientID = ClientID,
                ClassificationID = Convert.ToInt32(cmbClassification.SelectedValue),
                WageID = Convert.ToInt32(cmbWageType.SelectedValue),
                PositionID = Convert.ToInt32(cmbPosition.SelectedValue),
                DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue),
                LocationID = Convert.ToInt32(cmbLocation.SelectedValue),
            },
            new()
            {
                PositionEffectiveDate = dtpPositionEffectiveDate.Value,
                StatusEffectiveDate = dtpStatusEffectiveDate.Value,

                IsFormerEmployee = chkPreviousEmployee.Checked,
                FormerPositionTitle = txtPreviousPosition.Text.ToUpper().Trim(),
                FormerStartDate = dtpFromDate.Value,
                FormerEndDate = dtpToDate.Value,
                MoreFormerInformation = txtOtherInformation.Text.Trim(),
                CurrentPositionTitle = txtPositionTitle.Text.ToUpper().Trim(),

                WageName = cmbWageType.Text.ToUpper(),
                DepartmentName = cmbDepartment.Text.Trim(),
                LocationName = cmbLocation.Text.Trim()
            });

            if (isUpdated)
            {
                MessageBox.Show("You have successfully updated this employee's information.", "Update Employee Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ParentControl?.ApplyFilterAndSearchThenPopulate();
                this.Close();
            }
            else
            {
                MessageBox.Show(MessagesConstants.ERROR_ACTION, MessagesConstants.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
