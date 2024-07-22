using LBPRDC.Source.Config;
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
                txtMiddleName,
                txtLastName,
                txtEmailAddress,
                txtPositionTitle
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
            if (UserID == 0)
            {
                MessageBox.Show(MessagesConstants.Error.MISSING_USER, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            InitializeUserInformation(UserID);
        }

        private async void InitializeUserInformation(int userId)
        {
            var users = await UserService.GetUsers(userId);
            if (users.Any())
            {
                var user = users.First();
                lblHiddenUserID.Text = user.ID.ToString();
                txtFirstName.Text = user.FirstName;
                txtLastName.Text = user.LastName;
                txtEmailAddress.Text = user.Email;
                txtMiddleName.Text = user.MiddleName;
                txtPositionTitle.Text = user.PositionTitle;

                originalTextBoxValues.Add(txtFirstName, user.FirstName);
                originalTextBoxValues.Add(txtLastName, user.LastName);
                originalTextBoxValues.Add(txtEmailAddress, user.Email);
                originalTextBoxValues.Add(txtMiddleName, user.MiddleName);
                originalTextBoxValues.Add(txtPositionTitle, user.PositionTitle);
            }
            else
            {
                MessageBox.Show(MessagesConstants.Error.RETRIEVE_DATA, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

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
            Models.User userUpdate = new()
            {
                ID = userId,
                FirstName = txtFirstName.Text,
                MiddleName = txtMiddleName.Text,
                LastName = txtLastName.Text,
                Email = txtEmailAddress.Text,
                PositionTitle = txtPositionTitle.Text,
            };

            var isUpdated = await UserService.UpdateCurrentUserBasicInformation(userUpdate);
            if (isUpdated)
            {
                MessageBox.Show("You have successfully updated your account information. Reminders, some changes may require you to re-login or restart the app for them to take effect", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdateBasicInformation.Enabled = false;
            }
            else
            {
                MessageBox.Show(MessagesConstants.Error.ACTION, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task UpdateUserPassword(int userId)
        {
            var users = await UserService.GetUsers(userId);

            if (!users.Any())
            {
                MessageBox.Show(MessagesConstants.Error.RETRIEVE_DATA, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var user = users.First();

            if (! await UserService.Authenticate(user.Username, txtOldPassword.Text))
            {
                MessageBox.Show("Your current password do not match to your entered old password.", MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.", MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Models.User userUpdate = new()
            {
                ID = userId,
                PasswordHash = txtConfirmPassword.Text
            };

            var isUpdated = await UserService.UpdateCurrentUserPassword(userUpdate);
            if (isUpdated)
            {
                MessageBox.Show("You have successfully updated your account's password.", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                grpPasswordData.Enabled = false;
                chkChangePassword.Checked = false;
            }
            else
            {
                MessageBox.Show(MessagesConstants.Error.ACTION, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
