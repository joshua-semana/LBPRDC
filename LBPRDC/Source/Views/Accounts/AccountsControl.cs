using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;

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
            if (this.Visible == true) PopulateTableWithSearch(txtSearch.Text.Trim().ToLower());
        }

        private async void PopulateTableWithSearch(string searchWord)
        {
            ShowLoadingProgressBar(true);
            var users = await Task.Run(() => UserService.GetAllUsers());

            dgvUsers.Columns.Clear();

            if (users.Count > 0)
            {
                dgvUsers.AutoGenerateColumns = false;

                var filteredUsers = users;

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
                lblRowCounter.Text = ControlUtils.GetTableRowCount(filteredUsers.Count, users.Count);
                dgvUsers.DataSource = filteredUsers;
            }

            ShowLoadingProgressBar(false);
        }

        private void ApplySettingsToTable()
        {
            ControlUtils.AddColumn(dgvUsers, "Role", "Role", "Role");
            ControlUtils.AddColumn(dgvUsers, "Username", "Username", "Username");
            ControlUtils.AddColumn(dgvUsers, "Email", "Email", "Email");
            ControlUtils.AddColumn(dgvUsers, "FirstName", "First Name", "FirstName");
            ControlUtils.AddColumn(dgvUsers, "LastName", "Last Name", "LastName");
            ControlUtils.AddColumn(dgvUsers, "Status", "Status", "Status");
            ControlUtils.AddColumn(dgvUsers, "RegistrationDate", "Registration Date", "RegistrationDate");
            ControlUtils.AddColumn(dgvUsers, "LastLoginDate", "Last Login Date", "LastLoginDate");
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
    }
}
