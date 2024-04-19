using LBPRDC.Source.Config;
using LBPRDC.Source.Services;
namespace LBPRDC.Source.Views.Billing
{
    public partial class ReleaseBillingForm : Form
    {
        public BillingControl? ParentControl { get; set; }
        public string? BillingName { get; set; }
        public int BillingID { get; set; }
        public int ClientID { get; set; }

        public ReleaseBillingForm()
        {
            InitializeComponent();
        }

        private void ReleaseBillingForm_Load(object sender, EventArgs e)
        {
            if (BillingID == 0 || ClientID == 0)
            {
                MessageBox.Show(MessagesConstants.Error.MISSING_CLIENT_BILLING, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var output = MessageBox.Show("Are you sure you want to release and lock this billing for any type of modification?", "Release Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (output == DialogResult.Yes)
            {
                frmLoading form = new()
                {
                    BooleanProcess = Task.Run(() => BillingService.ReleaseBilling(BillingID, ClientID, dtpReleaseDate.Value)),
                    Description = "Releasing this billing, please wait..."
                };

                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    MessageBox.Show("You have successfully released this billing.", "Billing Release Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ParentControl?.ApplySearchThenPopulate();
                    Close();
                }
                else if (result == DialogResult.Abort)
                {
                    MessageBox.Show("There is a problem releasing this billing, please try again.", MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
