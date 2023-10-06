using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;
using LBPRDC.Source.Services;

namespace LBPRDC.Source.Views
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void ClearInputs(Control container)
        {
            foreach (Control c in container.Controls)
            {
                if (c is TextBox textBox)
                {
                    textBox.Text = string.Empty;
                }
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (Utilities.ControlUtils.AreInputsEmpty(pnlLogin))
            {
                MessageBox.Show("Please enter both username and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                bool isAuthenticated = AuthenticationService.ValidateCredentials(username, password);

                if (!isAuthenticated)
                {
                    MessageBox.Show("Invalid username or password.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                UserService.GetUserInfoByUsername(username);
                var currentUser = UserManager.Instance.CurrentUser;

                if (currentUser == null)
                {
                    MessageBox.Show("Failed to get user info. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (currentUser.Status != "Active")
                {
                    MessageBox.Show("Invalid username or password.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                await Task.Run(() => LoggingService.LogActivity(currentUser.UserID, "Sign In Log", "This user signed in to the software."));
                await Task.Run(() => UserService.UpdateLastLoginDate(username));

                //ClearInputs(pnlLogin);
                this.Hide();
                frmMain mainForm = new frmMain();
                mainForm.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnLogin.PerformClick();
            }
        }
    }
}
