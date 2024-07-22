using LBPRDC.Source.Config;
using LBPRDC.Source.Models;
using LBPRDC.Source.Services;

namespace LBPRDC.Source.Views
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void SetTextBoxState(bool enabled)
        {
            txtUsername.Enabled = enabled;
            txtPassword.Enabled = enabled;
        }

        private void SetSignInButtonState(string buttonText, bool enabled)
        {
            btnSignIn.Text = buttonText;
            btnSignIn.Enabled = enabled;
        }

        private async void btnSignIn_Click(object sender, EventArgs e)
        {
            if (Utilities.ControlUtils.AreInputsEmpty(pnlLogin))
            {
                MessageBox.Show("Please enter both username and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                SetSignInButtonState("Signing in...", false);
                SetTextBoxState(false);

                bool isAuthenticated = await UserService.Authenticate(username, password);

                if (!isAuthenticated)
                {
                    MessageBox.Show("Invalid username or password. Please try again.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var users = await UserService.GetUsers(Username: username);

                if (!users.Any())
                {
                    MessageBox.Show(MessagesConstants.Error.MISSING_USER, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                UserService.SetCurrentUser(users.First());
                var currentUser = UserService.CurrentUser;

                if (currentUser == null)
                {
                    MessageBox.Show("Failed to get user info. Please try again.", MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (currentUser.Status != StringConstants.Status.ACTIVE)
                {
                    MessageBox.Show("Your account is set to inactive. Please contact your administrator.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                await LoggingService.AddLog(new()
                {
                    UserID = currentUser.ID,
                    Type = "Sign In",
                    Details = "User Signed In"
                });

                await UserService.UpdateLastLoginDate(currentUser.ID);

                PayFrequencyForm form = new();
                form.ShowDialog();

                if (form.DialogResult == DialogResult.Cancel) { return; }

                if (PayFrequencyService.CurrentPayFrequencyID == 0)
                {
                    MessageBox.Show("Unable to set the Pay Frequency. Please call an administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                await FetchUserPermissions(currentUser);

                this.Hide();
                frmMain mainForm = new();
                mainForm.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            finally
            {
                SetSignInButtonState("Sign In", true);
                SetTextBoxState(true);
            }
        }

        private static async Task FetchUserPermissions(User currentUser)
        {
            var roleType = await UserRoleService.GetType(currentUser.UserRoleID);

            if (roleType.IsAdmin)
            {
                AccessPermissionService.SetAllPermissionsByBool(AccessPermissionService.CurrentUserPermissions, true);
                return;
            }

            var userPermissions = await RolePermissionService.GetAllPermission(currentUser.UserRoleID);

            if (userPermissions.Any())
            {
                AccessPermissionService.SetPermissions(AccessPermissionService.CurrentUserPermissions, userPermissions);
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnSignIn.PerformClick();
            }
        }

        private void btnConfiguration_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Changing these settings incorrectly can disrupt the functionality of the application. " +
                "Only modify these settings if you are sure about the changes you are making and have the necessary knowledge. " +
                "Incorrect settings may require technical support to restore proper functionality. \n\nDo you still want to proceed?",
                "Settings Modification Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                frmServerSetup serverSetupForm = new();
                serverSetupForm.ShowDialog();
            }
        }
    }
}
