using LBPRDC.Source.Services;
namespace LBPRDC.Source.Views.Billing
{
    public partial class ReleaseBillingForm : Form
    {
        public BillingControl? ParentControl { get; set; }
        public string? BillingName { get; set; }

        public ReleaseBillingForm()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var output = MessageBox.Show("Are you sure you want to release and lock this billing for any type of modification?", "Release Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (output == DialogResult.Yes)
            {
                frmLoading form = new()
                {
                    BooleanProcess = Task.Run(() => BillingService.ReleaseBilling(BillingName, dtpReleaseDate.Value)),
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
                    MessageBox.Show("There is a problem releasing this billing, please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
