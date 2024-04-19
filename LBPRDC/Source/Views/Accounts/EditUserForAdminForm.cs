using LBPRDC.Source.Config;
using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;

namespace LBPRDC.Source.Views.Accounts
{
    public partial class EditUserForAdminForm : Form
    {

        public int UserID { get; set; }
        public AccountsControl? ParentControl { get; set; }
        private readonly List<Control> requiredFields;

        public EditUserForAdminForm()
        {
            InitializeComponent();

            requiredFields = new List<Control>
            {
                cmbRole,
                cmbStatus
            };
        }

        private void EditUserForAdminForm_Load(object sender, EventArgs e)
        {
            InitializeUserInformation(UserID);
        }

        private void InitializeUserInformation(int userID)
        {
            var user = UserService.GetAllUsers().First(f => f.UserID == userID);
            txtUserID.Text = userID.ToString();
            txtUsername.Text = user.Username;
            cmbRole.SelectedItem = user.Role;
            cmbStatus.SelectedItem = user.Status;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ControlUtils.AreRequiredFieldsFilled(requiredFields))
            {
                UpdateUserInformation();
            }
        }

        private async void UpdateUserInformation()
        {
            UserService.User userUpdate = new()
            {
                UserID = Convert.ToInt32(txtUserID.Text),
                Username = txtUsername.Text,
                Role = cmbRole.Text,
                Status = cmbStatus.Text
            };

            bool isUpdated = await UserService.UpdateUserStatusRole(userUpdate);
            if (isUpdated)
            {
                MessageBox.Show("You have successfully updated the information of this user.", "User Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ParentControl?.ResetTableSearch();
                this.Close();
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
    }
}
