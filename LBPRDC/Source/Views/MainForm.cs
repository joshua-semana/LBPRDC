using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using LBPRDC.Source.Services;

namespace LBPRDC.Source.Views
{
    public partial class frmMain : Form
    {
        private List<Button> pageSwitchButtons = new List<Button>();
        private string currentPage = "Home";

        public frmMain()
        {
            InitializeComponent();
            InitializePageSwitchButtons(flowHeader);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            UpdatePageSwitchButtonsStyle();
            InitializeFeatureBasedOnUserRole();
            lblDateToday.Text = DateTime.Now.ToString("MMM. dd, yyyy (ddd)");
            lblGreetUser.Text = "Hello, " + UserManager.Instance.CurrentUser?.FirstName;
        }

        private void InitializeFeatureBasedOnUserRole()
        {
            string? userRole = UserManager.Instance.CurrentUser?.Role;

            if (userRole != "Admin")
            {
                btnAccounts.Visible = false;
                menuItemLogs.Visible = false;
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
                if (button.Text == currentPage)
                {
                    button.BackColor = Utilities.ColorConstants.PageSwitchButton;
                    button.Font = new Font(button.Font, FontStyle.Bold);
                }
                else
                {
                    button.BackColor = Utilities.ColorConstants.PanelHeader;
                    button.Font = new Font(button.Font, FontStyle.Regular);
                }
            }
        }

        private void btnPageSwitch_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            currentPage = clickedButton.Text;

            UpdatePageSwitchButtonsStyle();

            if (clickedButton.Text == "Home") { }
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

        private void menuItemSignOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to sign out?", "Sign Out Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                UserManager.Instance.ClearCurrentUser();
                this.Hide();
                frmLogin loginForm = new frmLogin();
                loginForm.ShowDialog();
                this.Close();
            }
        }
    }
}
