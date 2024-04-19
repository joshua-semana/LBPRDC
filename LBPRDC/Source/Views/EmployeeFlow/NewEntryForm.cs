using LBPRDC.Source.Config;
using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;

namespace LBPRDC.Source.Views
{
    public partial class frmNewEntryEmployee : Form
    {
        public ucEmployees? ParentControl { get; set; }
        public int ClientID { get; set; }
        public string ClientName { get; set; } = "";

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
                cmbWageType,
                cmbPosition,
                cmbEmploymentStatus,
                cmbDepartment
            };
        }

        private void frmEmployeeDataEntry_Load(object sender, EventArgs e)
        {
            if (ClientID == 0)
            {
                MessageBox.Show(MessagesConstants.ERROR_RETRIEVE_CLIENT, MessagesConstants.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            this.Text = $"New Employee for Client: {ClientName}";

            InitializePositionComboBoxItems();
            InitializeCivilStatusComboBoxItems();
            InitializeEmploymentStatusComboBoxItems();
            InitializeSuffixComboBoxItems();
            InitializeGenderComboBoxItems();
            InitializeDepartmentComboBoxItems();
            InitializeWageTypeComboBoxItems();
        }

        private async void InitializePositionComboBoxItems()
        {
            cmbPosition.DataSource = await PositionService.GetAllItemsForComboBoxByClientID(ClientID);
            cmbPosition.DisplayMember = "Name";
            cmbPosition.ValueMember = "ID";
        }

        private async void InitializeCivilStatusComboBoxItems()
        {
            cmbCivilStatus.DataSource = await CivilStatusService.GetAllItemsForComboBox();
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

        private async void InitializeDepartmentComboBoxItems()
        {
            cmbDepartment.DataSource = await DepartmentService.GetAllItemsForComboBoxByClientID(ClientID);
            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "ID";
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

        private void InitializeGenderComboBoxItems()
        {
            cmbGender.SelectedIndex = 0;
        }

        private async void InitializeWageTypeComboBoxItems()
        {
            cmbWageType.DataSource = await WageService.GetAllItemsForComboBox();
            cmbWageType.DisplayMember = "Name";
            cmbWageType.ValueMember = "ID";
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (ControlUtils.AreRequiredFieldsFilled(requiredFields))
            {
                if (EmployeeService.IDExists(ClientID, txtEmployeeID.Text.Trim()))
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

                AddNewEmployee();
            }
        }

        private async void AddNewEmployee()
        {
            EmployeeService.EmployeeHistory newEmployee = new()
            {
                EmployeeID = txtEmployeeID.Text.ToUpper().Trim(),
                ClientID = ClientID,
                LastName = txtLastName.Text.ToUpper().Trim(),
                FirstName = txtFirstName.Text.ToUpper().Trim(),
                MiddleName = txtMiddleName.Text.ToUpper().Trim(),
                SuffixID = Convert.ToInt32(cmbSuffix.SelectedValue),
                Gender = cmbGender.Text,
                Birthday = dtpBirthday.Value,
                Education = txtEducation.Text,
                DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue),
                LocationID = Convert.ToInt32(cmbLocation.SelectedValue),
                EmailAddress1 = txtEmailAddress1.Text.Trim(),
                EmailAddress2 = txtEmailAddress2.Text.Trim(),
                ContactNumber1 = txtContactNumber1.Text,
                ContactNumber2 = txtContactNumber2.Text,
                CivilStatusID = Convert.ToInt32(cmbCivilStatus.SelectedValue),
                PositionID = Convert.ToInt32(cmbPosition.SelectedValue),
                EmploymentStatusID = Convert.ToInt32(cmbEmploymentStatus.SelectedValue),
                Remarks = txtRemarks.Text.Trim(),
                WageID = Convert.ToInt32(cmbWageType.SelectedValue),

                StartDate = dtpStartDate.Value,
                PositionTitle = txtPositionTitle.Text.ToUpper().Trim(),
                isPreviousEmployee = chkPreviousEmployee.Checked,
                PreviousFrom = dtpFromDate.Value,
                PreviousTo = dtpToDate.Value,
                PreviousPosition = txtPreviousPosition.Text.ToUpper().Trim(),
                OtherInformation = txtOtherInformation.Text.Trim()
            };

            bool isAdded = await EmployeeService.AddNewEmployee(newEmployee);

            if (isAdded)
            {
                MessageBox.Show("You have successfully added a new employee.", "New Employee Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ParentControl?.ResetTableSearchFilter();
                this.Close();
            }
            else
            {
                MessageBox.Show(MessagesConstants.ERROR_ACTION, MessagesConstants.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            var result = MessageBox.Show(MessagesConstants.Cancel.QUESTION, MessagesConstants.Cancel.TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
