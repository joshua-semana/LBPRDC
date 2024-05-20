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
            chkEmploymentStatus.Checked = preference.ShowEmploymentStatus;
            chkClassification.Checked = preference.ShowClassification;
            chkDepartment.Checked = preference.ShowDepartment;
            chkLocation.Checked = preference.ShowLocation;
            chkEmailAddress.Checked = preference.ShowEmailAddress;
            chkContactNumber.Checked = preference.ShowContactNumber;
            chkPosition.Checked = preference.ShowPosition;
            chkWageType.Checked = preference.ShowWageType;
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
            preference.ShowEmployeeID = chkEmployeeID.Checked;
            preference.ShowName = chkName.Checked;
            preference.ShowGender = chkGender.Checked;
            preference.ShowEmploymentStatus = chkEmploymentStatus.Checked;
            preference.ShowClassification = chkClassification.Checked;
            preference.ShowDepartment = chkDepartment.Checked;
            preference.ShowLocation = chkLocation.Checked;
            preference.ShowEmailAddress = chkEmailAddress.Checked;
            preference.ShowContactNumber = chkContactNumber.Checked;
            preference.ShowPosition = chkPosition.Checked;
            preference.ShowWageType = chkWageType.Checked;
            preference.ShowSalaryRate = chkSalaryRate.Checked;
            preference.ShowBillingRate = chkBillingRate.Checked;
            preference.SelectedNameFormat = Enum.Parse<NameFormat>(GetSelectedRadioButton(flowRadioGroupForName));
            preference.SelectedEmailFormat = Enum.Parse<EmailFormat>(GetSelectedRadioButton(flowRadioGroupForEmail));
            preference.SelectedContactFormat = Enum.Parse<ContactFormat>(GetSelectedRadioButton(flowRadioGroupForContact));
            preference.SelectedPositionFormat = Enum.Parse<PositionFormat>(GetSelectedRadioButton(flowRadioGroupForPosition));

            UserPreferenceManager.SavePreferences(preference);
            ParentControl?.ResetTableSearchFilter();
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
    }
}
