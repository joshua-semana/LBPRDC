﻿using System;
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

        private void SetSignInButtonState(string buttonText, bool enabled)
        {
            btnSignIn.Text = buttonText;
            btnSignIn.Enabled = enabled;
        }

        private async void btnSignIn_Click(object sender, EventArgs e)
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

                SetSignInButtonState("Signing in...", false);

                bool isAuthenticated = AuthenticationService.ValidateCredentials(username, password);

                if (!isAuthenticated)
                {
                    MessageBox.Show("Invalid username or password.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                UserService.GetUserByUsername(username);
                var currentUser = UserService.CurrentUser;

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

                LoggingService.Log newLog = new()
                {
                    UserID = currentUser.UserID,
                    Type = "Sign In Log",
                    Details = "This user signed in to the software."
                };

                await Task.Run(() => LoggingService.LogActivity(newLog));
                await Task.Run(() => UserService.UpdateLastLoginDate(username));

                this.Hide();
                frmMain mainForm = new frmMain();
                mainForm.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            finally
            {
                SetSignInButtonState("Sign In", true);
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
                btnSignIn.PerformClick();
            }
        }

        private void btnConfiguration_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Changing these settings incorrectly can disrupt the functionality of the application. " +
                "Only modify these settings if you are sure about the changes you are making and have the necessary knowledge. " +
                "Incorrect settings may require technical support to restore proper functionality. \n\nDo you still want to proceed?",
                "Settings Modification Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                frmServerSetup serverSetupForm = new frmServerSetup();
                serverSetupForm.ShowDialog();
            }
        }
    }
}
