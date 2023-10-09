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

        UserControl employeesControl = new ucEmployees();

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
            lblGreetUser.Text = "Hello, " + UserManager.Instance.CurrentUser?.FirstName;
        }

        private void InitializeFeatureBasedOnUserRole()
        {
            string? userRole = UserManager.Instance.CurrentUser?.Role;

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
            employeesControl.Hide();
            //accountsControl.Hide();
            //logsControl.Hide();

            switch (pageName)
            {
                case "Home":
                    //homeControl.Dock = DockStyle.Fill;
                    //pnlMainContent.Controls.Add(homeControl);
                    //homeControl.Show();
                    break;
                case "Employees":
                    employeesControl.Dock = DockStyle.Fill;
                    pnlContent.Controls.Add(employeesControl);
                    employeesControl.Show();
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
                UserManager.Instance.ClearCurrentUser();
                this.Hide();
                frmLogin loginForm = new frmLogin();
                loginForm.ShowDialog();
                this.Close();
            }
        }

        private void picLogo_Click(object sender, EventArgs e)
        {
            List<Employee> employees = EmployeeService.GetAllEmployees();

            var filteredAndTransformedData = employees.Select(emp => new
            {
                emp.EmployeeID,
                FullName = $"{emp.FirstName} {emp.MiddleName} {emp.LastName} {emp.Suffix}".Trim(),
                emp.DepartmentName,
                emp.EmailAddress,
                emp.ContactNumber,
                emp.MarriageStatus,
                emp.DateOfUpdateOfMarriageStatus,
                emp.DateHired,
                emp.EmploymentStatus,
                emp.DateOfEmploymentStatusChange
            }).ToList();

            //dataGridView1.DataSource = filteredAndTransformedData;
            //Panel test = new Panel();
            //test.Dock = DockStyle.Fill;
            //test.BackColor = Color.Yellow;
            //pnlMainContainer.Controls.Add(test);
        }
    }
}
