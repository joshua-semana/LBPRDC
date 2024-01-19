namespace LBPRDC.Source.Views
{
    public partial class frmLoading : Form
    {
        private CancellationTokenSource? cancellationTokenSource;

        public Task<bool>? BooleanProcess { get; set; } = null;
        public Task<Services.Billing>? BillingProcess { get; set; } = null;
        public Services.Billing? BillingResult { get; set; } = null;
        public Task<List<string>>? StringListProcess { get; set; } = null;
        public List<string>? StringListResult { get; set; } = null;
        public Task<Services.BillingAccount>? BillingAccountProcess { get; set; } = null;
        public Services.BillingAccount? BillingAccountResult { get; set; } = null;
        public Task<List<Services.BillingRecord>>? BillingRecordProcess { get; set; } = null;
        public List<Services.BillingRecord>? BillingRecordResult { get; set; } = null;
        public Task<List<Services.AccountsDetails>>? AccountsTotalValuesProcess { get; set; } = null;
        public List<Services.AccountsDetails>? AccountsTotalValuesResult { get; set; } = null;
        public string? Description { get; set; }
        public Services.Billing? Billing { get; set; }

        public frmLoading()
        {
            InitializeComponent();
        }

        private async void frmLoading_Load(object sender, EventArgs e)
        {
            lblDescription.Text = Description;

            try
            {
                cancellationTokenSource = new CancellationTokenSource();
                if (BooleanProcess != null)
                {
                    bool result = await Task.Run(() => BooleanProcess, cancellationTokenSource.Token);
                    if (result) { DialogResult = DialogResult.OK; }
                    else { DialogResult = DialogResult.Abort; }
                    return;
                }
                if (BillingProcess != null)
                {
                    var result = await Task.Run(() => BillingProcess, cancellationTokenSource.Token);
                    BillingResult = result;
                }
                if (StringListProcess != null)
                {
                    var result = await Task.Run(() => StringListProcess, cancellationTokenSource.Token);
                    StringListResult = result;
                }
                if (BillingAccountProcess != null)
                {
                    var result = await Task.Run(() => BillingAccountProcess, cancellationTokenSource.Token);
                    BillingAccountResult = result;
                }
                if (BillingRecordProcess != null)
                {
                    var result = await Task.Run(() => BillingRecordProcess, cancellationTokenSource.Token);
                    BillingRecordResult = result;
                }
                if (AccountsTotalValuesProcess != null)
                {
                    var result = await Task.Run(() => AccountsTotalValuesProcess, cancellationTokenSource.Token);
                    AccountsTotalValuesResult = result;
                }
                DialogResult = DialogResult.OK;
            }
            catch (OperationCanceledException)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cancellationTokenSource?.Dispose();
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancellationTokenSource?.Cancel();
        }
    }
}
