using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;

namespace LBPRDC.Source.Views.Profile
{
    public partial class ViewAndEditProfileForm : Form
    {
        public int UserID { get; set; }

        private readonly Dictionary<TextBox, string> originalTextBoxValues = new();
        private List<Control> requiredTextboxes;
        private List<Control> requiredPasswords;


        public ViewAndEditProfileForm()
        {
            InitializeComponent();

            requiredTextboxes = new()
            {
                txtFirstName,
                txtLastName,
                txtEmailAddress
            };

            requiredPasswords = new()
            {
                txtOldPassword,
                txtNewPassword,
                txtConfirmPassword
            };
        }

        private void ViewAndEditProfileForm_Load(object sender, EventArgs e)
        {
            InitializeUserInformation(UserID);
        }

        private void InitializeUserInformation(int userId)
        {
            var user = UserService.GetAllUsers().First(f => f.UserID == userId);
            lblHiddenUserID.Text = user.UserID.ToString();
            txtFirstName.Text = user.FirstName;
            txtLastName.Text = user.LastName;
            txtEmailAddress.Text = user.Email;

            originalTextBoxValues.Add(txtFirstName, user.FirstName);
            originalTextBoxValues.Add(txtLastName, user.LastName);
            originalTextBoxValues.Add(txtEmailAddress, user.Email);

            foreach (var kv in originalTextBoxValues)
            {
                kv.Key.TextChanged += Control_Changed;
            }
        }

        private void Control_Changed(object sender, EventArgs e)
        {
            bool anyTextBoxChanged = originalTextBoxValues.Any(kv =>
            {
                if (kv.Key is TextBox textBox)
                {
                    return textBox.Text != kv.Value;
                }
                return false;
            });

            if (anyTextBoxChanged)
            {
                btnUpdateBasicInformation.Enabled = true;
            }
            else
            {
                btnUpdateBasicInformation.Enabled = false;
            }
        }

        private void chkChangePassword_CheckedChanged(object sender, EventArgs e)
        {
            grpPasswordData.Enabled = chkChangePassword.Checked;
            ControlUtils.ClearInputs(grpPasswordData);
        }

        private async void btnUpdateBasicInformation_Click(object sender, EventArgs e)
        {
            if (ControlUtils.AreRequiredFieldsFilled(requiredTextboxes))
            {
                await UpdateUserInformationAsync(Convert.ToInt32(lblHiddenUserID.Text));
            }
        }

        private async void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            if (ControlUtils.AreRequiredFieldsFilled(requiredPasswords))
            {
                await UpdateUserPassword(Convert.ToInt32(lblHiddenUserID.Text));
            }
        }

        private async Task UpdateUserInformationAsync(int userId)
        {
            UserService.User userUpdate = new()
            {
                UserID = userId,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmailAddress.Text
            };

            var isUpdated = await UserService.UpdateUserBasicInformation(userUpdate);
            if (isUpdated)
            {
                MessageBox.Show("You have successfully updated your account information. Reminders, some changes may require you to re-login or restart the app for them to take effect", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdateBasicInformation.Enabled = false;
            }
        }

        private async Task UpdateUserPassword(int userId)
        {
            var user = UserService.GetAllUsers().First(f => f.UserID == userId);

            if (!AuthenticationService.ValidateCredentials(user.Username, txtOldPassword.Text))
            {
                MessageBox.Show("Your current password do not match to your entered old password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UserService.User userUpdate = new()
            {
                UserID = userId,
                Password = txtConfirmPassword.Text
            };

            var isUpdated = await UserService.UpdatePassword(userUpdate);
            if (isUpdated)
            {
                MessageBox.Show("You have successfully updated your account's password.", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                grpPasswordData.Enabled = false;
                chkChangePassword.Checked = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
