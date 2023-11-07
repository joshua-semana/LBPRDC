
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
                txtUsername,
                txtPassword,
                txtConfirmPassword
            };
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ControlUtils.AreRequiredFieldsFilled(requiredFields))
            {
                var userCount = UserService.GetAllUsers().Count(f => f.Username == txtUsername.Text);
                if (userCount > 0)
                {
                    MessageBox.Show("The username you entered already exists in the database. Please enter a different username.", "Username Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                AddNewUserAccount();
            }
        }

        private async void AddNewUserAccount()
        {
            UserService.User newUser = new()
            {
                Username = txtUsername.Text,
                Password = txtConfirmPassword.Text,
                Email = txtEmailAddress.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text
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
            var result = MessageBox.Show("Are you sure you want to cancel this operation?", "Cancel Operation Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
