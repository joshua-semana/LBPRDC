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
            if (UserID == 0)
            {
                MessageBox.Show(MessagesConstants.Error.MISSING_USER, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            InitializeUserInformation(UserID);
            FetchUserRoleCollection();
        }

        private async void FetchUserRoleCollection()
        {
            cmbRole.DataSource = await UserRoleService.GetItemsForComboBox();
            cmbRole.DisplayMember = nameof(Models.UserRole.Name);
            cmbRole.ValueMember = nameof(Models.UserRole.ID);
        }

        private async void InitializeUserInformation(int userID)
        {
            var users = await UserService.GetUsers(userID);
            if (users.Any())
            {
                var user = users.First();
                txtUserID.Text = userID.ToString();
                txtUsername.Text = user.Username;
                cmbRole.SelectedValue = user.UserRoleID;
                cmbStatus.SelectedItem = user.Status;
            }
            else
            {
                MessageBox.Show(MessagesConstants.Error.RETRIEVE_DATA, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
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
            Models.User userUpdate = new()
            {
                ID = Convert.ToInt32(txtUserID.Text),
                Username = txtUsername.Text,
                UserRoleID = Convert.ToInt32(cmbRole.SelectedValue),
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
