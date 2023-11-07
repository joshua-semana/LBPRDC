namespace LBPRDC.Source.Views.Accounts
{
    public partial class ViewGeneratedPassword : Form
    {
        public string? Password { get; set; }
        public AccountsControl? ParentControl { get; set; }

        public ViewGeneratedPassword()
        {
            InitializeComponent();
        }

        private void ViewGeneratedPassword_Load(object sender, EventArgs e)
        {
            InitializeUserNewPassword();
        }

        private void InitializeUserNewPassword()
        {
            txtPassword.Text = Password;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to close this form? Be sure to save the user's new password.", "Close Form Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnCopyPassword_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtPassword.Text);
            lblNotifCopied.Visible = true;
        }
    }
}
