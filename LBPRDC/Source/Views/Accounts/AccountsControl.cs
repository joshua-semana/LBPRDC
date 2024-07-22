using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;
using LBPRDC.Source.Views.Categories;

namespace LBPRDC.Source.Views.Accounts
{
    public partial class AccountsControl : UserControl
    {
        UserControl loadingControl = new ucLoading() { Dock = DockStyle.Fill };

        public AccountsControl()
        {
            InitializeComponent();
            this.Controls.Add(loadingControl);
            loadingControl.BringToFront();
        }

        public void ResetTableSearch()
        {
            txtSearch.Text = string.Empty;
            PopulateTableWithSearch("");
        }

        private void AccountsControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                ResetTableSearch();
            }
        }

        private async void PopulateTableWithSearch(string searchWord)
        {
            ShowLoadingProgressBar(true);
            var users = await Task.Run(() => UserService.GetUsers());

            dgvUsers.Columns.Clear();

            if (users.Count > 0)
            {
                dgvUsers.AutoGenerateColumns = false;

                var filteredUsers = users.Where(w => w.ID != UserService.CurrentUser?.ID).ToList();

                if (!string.IsNullOrEmpty(searchWord))
                {
                    filteredUsers = filteredUsers
                        .Where(user =>
                            user.Username.ToLower().Contains(searchWord) ||
                            user.FirstName.ToLower().Contains(searchWord) ||
                            user.LastName.ToLower().Contains(searchWord))
                        .ToList();
                }

                ApplySettingsToTable();
                lblRowCounter.Text = ControlUtils.GetTableRowCount(filteredUsers.Count, users.Count, "user");
                dgvUsers.DataSource = filteredUsers;
            }

            ShowLoadingProgressBar(false);
        }

        private void ApplySettingsToTable()
        {
            ControlUtils.AddColumn(dgvUsers, "ID", "ID", "ID", true, true);
            ControlUtils.AddColumn(dgvUsers, "Role", "Role", "Role", true, true);
            ControlUtils.AddColumn(dgvUsers, "Username", "Username", "Username", true, true);
            ControlUtils.AddColumn(dgvUsers, "Email", "Email", "Email", true, true);
            ControlUtils.AddColumn(dgvUsers, "FirstName", "First Name", "FirstName", true, true);
            ControlUtils.AddColumn(dgvUsers, "LastName", "Last Name", "LastName", true, true);
            ControlUtils.AddColumn(dgvUsers, "RegistrationDate", "Registration Date", "RegistrationDate", true, true);
            ControlUtils.AddColumn(dgvUsers, "LastLoginDate", "Last Login Date", "LastLoginDate", true, true);
            ControlUtils.AddColumn(dgvUsers, "Status", "Status", "Status", true, true);
        }

        private void ShowLoadingProgressBar(bool state)
        {
            loadingControl.Visible = state;
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PopulateTableWithSearch(txtSearch.Text.Trim().ToLower());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewUser addNewUser = new();
            addNewUser.ParentControl = this;
            addNewUser.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.Rows.Count > 0)
            {
                EditUserForAdminForm editUserForAdminForm = new()
                {
                    UserID = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells[0].Value),
                    ParentControl = this
                };
                editUserForAdminForm.ShowDialog();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (dgvUsers.Rows.Count > 0)
            {
                var result = MessageBox.Show("Are you sure you want to reset the password of this user?", "Reser Password Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    ResetUserPasswordAsync();
                }
            }
        }

        private async void ResetUserPasswordAsync()
        {
            string newPassword = Generator.GeneratePassword(12);

            Models.User user = new()
            {
                ID = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells[0].Value),
                PasswordHash = newPassword
            };

            bool isReset = await UserService.ResetPassword(user);

            if (isReset)
            {
                ViewGeneratedPassword viewGeneratedPassword = new()
                {
                    Password = newPassword
                };
                viewGeneratedPassword.ShowDialog();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PopulateTableWithSearch(txtSearch.Text.Trim().ToLower());
        }

        private void btnPermissions_Click(object sender, EventArgs e)
        {
            PermissionsForm form = new()
            {
                ParentAccountsControl = this,
            };
            form.ShowDialog();
        }
    }
}
