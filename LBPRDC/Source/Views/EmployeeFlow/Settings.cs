using LBPRDC.Source.Utilities;

namespace LBPRDC.Source.Views.Employee
{
    public partial class frmSettingsEmployee : Form
    {
        public ucEmployees? ParentControl { get; set; }
        private readonly UserPreference preference;

        public frmSettingsEmployee()
        {
            InitializeComponent();
            preference = UserPreferenceManager.LoadPreference();
            InitializePreferences();
        }

        private void InitializePreferences()
        {
            chkEmployeeID.Checked = preference.ShowEmployeeID;
            chkName.Checked = preference.ShowName;
            chkGender.Checked = preference.ShowGender;
            chkBirthday.Checked = preference.ShowBirthday;
            chkEducation.Checked = preference.ShowEducation;
            chkCivilStatus.Checked = preference.ShowCivilStatus;
            chkEmploymentStatus.Checked = preference.ShowEmploymentStatus;
            chkDepartment.Checked = preference.ShowDepartment;
            chkEmailAddress.Checked = preference.ShowEmailAddress;
            chkContactNumber.Checked = preference.ShowContactNumber;
            chkPosition.Checked = preference.ShowPosition;
            chkSalaryRate.Checked = preference.ShowSalaryRate;
            chkBillingRate.Checked = preference.ShowBillingRate;

            SetSelectedRadioButton(flowRadioGroupForName, preference.SelectedNameFormat.ToString());
            SetSelectedRadioButton(flowRadioGroupForEmail, preference.SelectedEmailFormat.ToString());
            SetSelectedRadioButton(flowRadioGroupForContact, preference.SelectedContactFormat.ToString());
            SetSelectedRadioButton(flowRadioGroupForPosition, preference.SelectedPositionFormat.ToString());

            flowRadioGroupForName.Enabled = preference.ShowName;
            flowRadioGroupForEmail.Enabled = preference.ShowEmailAddress;
            flowRadioGroupForContact.Enabled = preference.ShowContactNumber;
            flowRadioGroupForPosition.Enabled = preference.ShowPosition;
        }

        private void SetSelectedRadioButton(FlowLayoutPanel container, string selectedValue)
        {
            foreach (RadioButton btn in container.Controls)
            {
                if (btn.AccessibleName == selectedValue)
                {
                    btn.Checked = true;
                    break;
                }
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            //if (chkEmployeeID.Checked == false && chkName.Checked == false)
            //{
            //    MessageBox.Show("Please select at least one (1) identifier to proceed.\nIdentifiers:\nEmployee ID\nEmployee Name", "Error Saving Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            preference.ShowEmployeeID = chkEmployeeID.Checked;
            preference.ShowName = chkName.Checked;
            preference.ShowGender = chkGender.Checked;
            preference.ShowBirthday = chkBirthday.Checked;
            preference.ShowEducation = chkEducation.Checked;
            preference.ShowCivilStatus = chkCivilStatus.Checked;
            preference.ShowEmploymentStatus = chkEmploymentStatus.Checked;
            preference.ShowDepartment = chkDepartment.Checked;
            preference.ShowEmailAddress = chkEmailAddress.Checked;
            preference.ShowContactNumber = chkContactNumber.Checked;
            preference.ShowPosition = chkPosition.Checked;
            preference.ShowSalaryRate = chkSalaryRate.Checked;
            preference.ShowBillingRate = chkBillingRate.Checked;
            preference.SelectedNameFormat = Enum.Parse<NameFormat>(GetSelectedRadioButton(flowRadioGroupForName));
            preference.SelectedEmailFormat = Enum.Parse<EmailFormat>(GetSelectedRadioButton(flowRadioGroupForEmail));
            preference.SelectedContactFormat = Enum.Parse<ContactFormat>(GetSelectedRadioButton(flowRadioGroupForContact));
            preference.SelectedPositionFormat = Enum.Parse<PositionFormat>(GetSelectedRadioButton(flowRadioGroupForPosition));

            UserPreferenceManager.SavePreferences(preference);
            MessageBox.Show("Preferences saved.", "User Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ParentControl?.PopulateTable();
            this.Close();
        }

        private string GetSelectedRadioButton(FlowLayoutPanel container)
        {
            foreach (RadioButton btn in container.Controls)
            {
                if (btn.Checked)
                {
                    return btn.AccessibleName;
                }
            }

            return String.Empty;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkName_CheckedChanged(object sender, EventArgs e)
        {
            flowRadioGroupForName.Enabled = chkName.Checked;
        }

        private void chkEmailAddress_CheckedChanged(object sender, EventArgs e)
        {
            flowRadioGroupForEmail.Enabled = chkEmailAddress.Checked;
        }

        private void chkContactNumber_CheckedChanged(object sender, EventArgs e)
        {
            flowRadioGroupForContact.Enabled = chkContactNumber.Checked;
        }

        private void chkPosition_CheckedChanged(object sender, EventArgs e)
        {
            flowRadioGroupForPosition.Enabled = chkPosition.Checked;
        }

        private void chkFilterDepartment_CheckedChanged(object sender, EventArgs e)
        {
            cmbFilterDepartment.Enabled = chkFilterDepartment.Checked;
        }

        private void chkFilterPosition_CheckedChanged(object sender, EventArgs e)
        {
            cmbFilterPosition.Enabled = chkFilterPosition.Checked;
        }

        private void chkFilterCivilStatus_CheckedChanged(object sender, EventArgs e)
        {
            cmbFilterCivilStatus.Enabled = chkFilterCivilStatus.Checked;
        }

        private void chkFilterGender_CheckedChanged(object sender, EventArgs e)
        {
            cmbFilterGender.Enabled = chkFilterGender.Checked;
        }

        private void chkFilterEmploymentStatus_CheckedChanged(object sender, EventArgs e)
        {
            cmbFilterEmploymentStatus.Enabled = chkFilterEmploymentStatus.Checked;
        }
    }
}
