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

            string username = txtUsername.Text;
            string password = txtPassword.Text;

            try
            {
                bool isAuthenticated = AuthenticationService.ValidateCredentials(username, password);

                if (isAuthenticated)
                {
                    UserService.GetUserInfoByUsername(username);

                    if (UserManager.Instance.CurrentUser != null)
                    {
                        if (UserManager.Instance.CurrentUser?.Status == "Active")
                        {
                            bool updateSuccessful = await Task.Run(() => UserService.UpdateLastLoginDate(username));

                            if (!updateSuccessful)
                            {
                                MessageBox.Show("Failed to update 'LastLoginDate'.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                            ClearInputs(pnlLogin);
                            this.Hide();
                            frmMain mainForm = new frmMain();
                            mainForm.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to get user info. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
