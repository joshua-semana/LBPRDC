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

        private void AccountsControl_VisibleChanged(object sender, EventArgs e)
        {
            PopulateTableWithSearch(txtSearch.Text);
        }

        private async void PopulateTableWithSearch(string searchWord)
        {
            ShowLoadingProgressBar();
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
                UpdateTableRowCount(filteredUsers.Count, users.Count);
                dgvUsers.DataSource = filteredUsers;
            }

            HideLoadingProgressBar();
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

        private void ShowLoadingProgressBar()
        {
            loadingControl.Visible = true;
        }

        private void HideLoadingProgressBar()
        {
            loadingControl.Visible = false;
        }

        private void UpdateTableRowCount(int currentCount, int originalCount)
        {
            lblRowCounter.Text = $"Currently displaying {currentCount} out of {originalCount} log(s).";
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PopulateTableWithSearch(txtSearch.Text);
            }
        }
    }
}
