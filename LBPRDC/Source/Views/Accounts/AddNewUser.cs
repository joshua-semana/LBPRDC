using LBPRDC.Source.Config;
using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;

namespace LBPRDC.Source.Views.Accounts
{
    public partial class AddNewUser : Form
    {
        public AccountsControl? ParentControl { get; set; }
        private readonly List<Control> requiredFields;

        public AddNewUser()
        {
            InitializeComponent();

            requiredFields = new List<Control>
            {
                txtFirstName,
                txtLastName,
                txtEmailAddress,
                txtPositionTitle,
                txtUsername,
                txtPassword,
                txtConfirmPassword,
                cmbUserRole
            };
        }

        private void AddNewUser_Load(object sender, EventArgs e)
        {
            FetchUserRolesCollection();
        }

        private async void FetchUserRolesCollection()
        {
            cmbUserRole.DataSource = await UserRoleService.GetItemsForComboBox();
            cmbUserRole.DisplayMember = nameof(Models.UserRole.Name);
            cmbUserRole.ValueMember = nameof(Models.UserRole.ID);
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (ControlUtils.AreRequiredFieldsFilled(requiredFields))
            {
                var users = await UserService.GetUsers();
                var userCount = users.Count(f => f.Username == txtUsername.Text);

                if (userCount > 0)
                {
                    MessageBox.Show("The username you entered already exists in the database. Please enter a different username.", "Username Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Passwords do not match.", MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                AddNewUserAccount();
            }
        }

        private async void AddNewUserAccount()
        {
            Models.User newUser = new()
            {
                Username = txtUsername.Text,
                PasswordHash = txtConfirmPassword.Text,
                Email = txtEmailAddress.Text,
                FirstName = txtFirstName.Text,
                MiddleName = txtMiddleName.Text,
                LastName = txtLastName.Text,
                PositionTitle = txtPositionTitle.Text,
                UserRoleID = Convert.ToInt32(cmbUserRole.SelectedValue),
                Status = StringConstants.Status.ACTIVE,
                RegistrationDate = DateTime.Now,
                LastLoginDate = DateTime.Now,
            };

            bool isAdded = await UserService.Add(newUser);
            if (isAdded)
            {
                MessageBox.Show("You have successfully added a new user.", "New User Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
