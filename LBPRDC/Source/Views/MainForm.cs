using LBPRDC.Source.Services;

namespace LBPRDC.Source.Views
{
    public partial class frmMain : Form
    {
        private List<Button> pageSwitchButtons = new List<Button>();
        private string currentPage = "Home";

        UserControl employeesMainControl = new ucEmployees();

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
            //accountsControl.Hide();
            //logsControl.Hide();

            lblPageName.Text = pageName;

            switch (pageName)
            {
                case "Home":
                    //homeControl.Dock = DockStyle.Fill;
                    //pnlMainContent.Controls.Add(homeControl);
                    //homeControl.Show();
                    break;
                case "Employees":
                    employeesMainControl.Dock = DockStyle.Fill;
                    pnlContent.Controls.Add(employeesMainControl);
                    employeesMainControl.Show();
                    break;

                case "Accounts":
                    //accountsControl.Dock = DockStyle.Fill;
                    //pnlMainContent.Controls.Add(accountsControl);
                    //accountsControl.Show();
                    break;

                case "Logs":
                    //logsControl.Dock = DockStyle.Fill;
                    //pnlMainContent.Controls.Add(logsControl);
                    //logsControl.Show();
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
                frmLogin loginForm = new frmLogin();
                loginForm.ShowDialog();
                this.Close();
            }
        }
    }
}
