using LBPRDC.Source.Services;
using LBPRDC.Source.Views.Logs;
using LBPRDC.Source.Views.Accounts;
using LBPRDC.Source.Views.Profile;
using LBPRDC.Source.Views.Categories;
using LBPRDC.Source.Views.Billing;
using LBPRDC.Source.Config;

namespace LBPRDC.Source.Views
{
    public partial class frmMain : Form
    {
        private List<Button> pageSwitchButtons = new();
        private string currentPage = "Home";

        readonly UserControl EmployeeControl = new ucEmployees() { Dock = DockStyle.Fill };
        readonly UserControl LogsControl = new LogsControl() { Dock = DockStyle.Fill };
        readonly UserControl AccountsControl = new AccountsControl() { Dock = DockStyle.Fill };
        readonly UserControl CategoriesControl = new CategoriesControl() { Dock = DockStyle.Fill };
        readonly UserControl BillingControl = new BillingControl() { Dock = DockStyle.Fill };

        public frmMain()
        {
            InitializeComponent();
            InitializePageSwitchButtons(flowSideNavTop);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            SetControlAccessVisibility();
            UpdatePageSwitchButtonsStyle();
            PopulateGreetingText();
            lblDateToday.Text = DateTime.Now.ToString("MMM. dd, yyyy (ddd)");
            lblPageName.Text = currentPage;
        }

        private void SetControlAccessVisibility()
        {
            btnBilling.Visible = AccessPermissionService.CurrentUserPermissions.CanAccessBillingTab;
            btnEmployees.Visible = AccessPermissionService.CurrentUserPermissions.CanAccessEmployeesTab;
            btnCategories.Visible = AccessPermissionService.CurrentUserPermissions.CanAccessCategoriesTab;
            btnLogs.Visible = AccessPermissionService.CurrentUserPermissions.CanAccessLogsTab;
            btnAccounts.Visible = AccessPermissionService.CurrentUserPermissions.CanAccessAccountsTab;
        }

        private void PopulateGreetingText()
        {
            string randomGreeting = StringConstants.Greetings[new Random().Next(StringConstants.Greetings.Length)];
            lblGreetUser.Text = $"{randomGreeting} {UserService.CurrentUser?.FirstName} 👋🏻";
        }

        private void InitializePageSwitchButtons(Control container)
        {
            foreach (Control control in container.Controls)
            {
                if (control is Button button)
                {
                    pageSwitchButtons.Add(button);
                    button.Click += btnPageSwitch_Click;
                }
            }
        }

        private void UpdatePageSwitchButtonsStyle()
        {
            foreach (Button button in pageSwitchButtons)
            {
                button.BackColor = ((string)button.Tag == currentPage) ?
                    Utilities.ColorConstants.PageSwitchButton :
                    Utilities.ColorConstants.Default;
            }
        }

        private void btnPageSwitch_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            currentPage = (string)clickedButton.Tag;

            UpdatePageSwitchButtonsStyle();
            DisplayPage(currentPage);
        }

        private void DisplayPage(string pageName)
        {
            //homeControl.Hide();
            BillingControl.Hide();
            EmployeeControl.Hide();
            AccountsControl.Hide();
            LogsControl.Hide();
            CategoriesControl.Hide();

            lblPageName.Text = pageName;

            switch (pageName)
            {
                case "Home":
                    //pnlContent.Controls.Add(homeControl);
                    //homeControl.Show();
                    break;

                case "Billing":
                    pnlContent.Controls.Add(BillingControl);
                    BillingControl.Show();
                    break;

                case "Employees":
                    pnlContent.Controls.Add(EmployeeControl);
                    EmployeeControl.Show();
                    break;

                case "Accounts":
                    pnlContent.Controls.Add(AccountsControl);
                    AccountsControl.Show();
                    break;

                case "Logs":
                    pnlContent.Controls.Add(LogsControl);
                    LogsControl.Show();
                    break;

                case "Categories":
                    pnlContent.Controls.Add(CategoriesControl);
                    CategoriesControl.Show();
                    break;
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (!Utilities.ExitConfirmationUtil.ConfirmExit())
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to sign out?", "Sign Out Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                UserService.ClearCurrentUser();
                AccessPermissionService.SetAllPermissionsByBool(AccessPermissionService.CurrentUserPermissions, false);
                this.Hide();
                frmLogin loginForm = new();
                loginForm.ShowDialog();
                this.Close();
            }
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            if (UserService.CurrentUser != null)
            {
                ViewAndEditProfileForm viewAndEditProfileForm = new()
                {
                    UserID = UserService.CurrentUser.ID
                };
                viewAndEditProfileForm.ShowDialog();
            }
        }
    }
}
