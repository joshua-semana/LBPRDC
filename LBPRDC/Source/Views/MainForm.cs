using LBPRDC.Source.Services;
using LBPRDC.Source.Views.Logs;
using LBPRDC.Source.Views.Accounts;
using LBPRDC.Source.Views.Profile;
using LBPRDC.Source.Views.Categories;


namespace LBPRDC.Source.Views
{
    public partial class frmMain : Form
    {
        private List<Button> pageSwitchButtons = new();
        private string currentPage = "Home";

        UserControl employeesMainControl = new ucEmployees() { Dock = DockStyle.Fill };
        UserControl logsControl = new LogsControl() { Dock = DockStyle.Fill };
        UserControl accountsControl = new AccountsControl() { Dock = DockStyle.Fill };
        UserControl categoriesControl = new CategoriesControl() { Dock = DockStyle.Fill};

        public frmMain()
        {
            InitializeComponent();
            InitializePageSwitchButtons(flowSideNavTop);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            UpdatePageSwitchButtonsStyle();
            InitializeFeatureBasedOnUserRole();
            lblDateToday.Text = DateTime.Now.ToString("MMM. dd, yyyy (ddd)");
            lblGreetUser.Text = "Hello, " + UserService.CurrentUser?.FirstName;
            lblPageName.Text = currentPage;
        }

        private void InitializeFeatureBasedOnUserRole()
        {
            string? userRole = UserService.CurrentUser?.Role;

            if (userRole != "Admin")
            {
                btnAccounts.Visible = false;
                btnLogs.Visible = false;
            }
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
                if ((string)button.Tag == currentPage)
                {
                    button.BackColor = Utilities.ColorConstants.PageSwitchButton;
                }
                else
                {
                    button.BackColor = Utilities.ColorConstants.Default;
                }
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
            employeesMainControl.Hide();
            accountsControl.Hide();
            logsControl.Hide();
            categoriesControl.Hide();

            lblPageName.Text = pageName;

            switch (pageName)
            {
                case "Home":
                    //homeControl.Dock = DockStyle.Fill;
                    //pnlContent.Controls.Add(homeControl);
                    //homeControl.Show();
                    break;
                case "Employees":
                    pnlContent.Controls.Add(employeesMainControl);
                    employeesMainControl.Show();
                    break;

                case "Accounts":
                    pnlContent.Controls.Add(accountsControl);
                    accountsControl.Show();
                    break;

                case "Logs":
                    pnlContent.Controls.Add(logsControl);
                    logsControl.Show();
                    break;

                case "Categories":
                    pnlContent.Controls.Add(categoriesControl);
                    categoriesControl.Show();
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
                    UserID = UserService.CurrentUser.UserID
                };
                viewAndEditProfileForm.ShowDialog();
            }
        }
    }
}
