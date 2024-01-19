using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;

namespace LBPRDC.Source.Views.Accounts
{
    public partial class EditUserForm : Form
    {
        public int UserID { get; set; }
        public AccountsControl? ParentControl { get; set; }
        private readonly List<Control> requiredFields;

        public EditUserForm()
        {
            InitializeComponent();

            requiredFields = new List<Control>
            {
                txtFirstName,
                txtLastName,
                txtEmailAddress,
                cmbRole,
                cmbStatus
            };
        }

        private void EditUserForm_Load(object sender, EventArgs e)
        {
            InitializeUserInformation(UserID);
        }

        private void InitializeUserInformation(int userID)
        {
            var user = UserService.GetAllUsers().First(f => f.UserID == userID);
            txtFirstName.Text = user.FirstName;
            txtLastName.Text = user.LastName;
            txtEmailAddress.Text = user.Email;
            txtUsername.Text = user.Username;
            cmbRole.SelectedItem = user.Role;
            cmbStatus.SelectedItem = user.Status;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ControlUtils.AreRequiredFieldsFilled(requiredFields))
            {
                if (chkChangePassword.Checked && txtPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                EditUserInformation();
            }
        }

        private void EditUserInformation()
        {
            // TODO
        }

        private void chkChangePassword_CheckedChanged(object sender, EventArgs e)
        {
            grpPasswordData.Enabled = chkChangePassword.Checked;
            if (chkChangePassword.Checked)
            {
                requiredFields.Add(txtOldPassword);
                requiredFields.Add(txtNewPassword);
                requiredFields.Add(txtConfirmPassword);
            }
            else
            {
                requiredFields.Remove(txtOldPassword);
                requiredFields.Remove(txtNewPassword);
                requiredFields.Remove(txtConfirmPassword);
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
    }
}
