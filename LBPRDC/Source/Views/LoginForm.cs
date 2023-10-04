using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LBPRDC.Source.Views
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter both username and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool AuthenticateAccount()
        {
            //TODO: Check username and password from database
            if (txtUsername.Text != "admin" && txtPassword.Text != "admin")
            {
                MessageBox.Show("Invalid username or password.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                if (AuthenticateAccount())
                {
                    //TODO: Display the main form
                    //this.Hide();
                    //MainForm mainForm = new MainForm();
                    //mainForm.ShowDialog(); // Use ShowDialog to make the main form modal
                    //this.Close();
                    MessageBox.Show("Login successfully.", "Authentication Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
