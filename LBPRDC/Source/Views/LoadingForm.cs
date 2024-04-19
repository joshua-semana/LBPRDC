using LBPRDC.Source.Config;

namespace LBPRDC.Source.Views
{
    public partial class frmLoading : Form
    {
        private CancellationTokenSource? cancellationTokenSource;

        public Task<string>? StringProcess { get; set; } = null;
        public string? StringResult { get; set; } = null;
        public Task<int>? IntegerProcess { get; set; } = null;
        public int? IntegerResult { get; set; } = null;
        public Task<bool>? BooleanProcess { get; set; } = null;
        public Task<(bool, int)>? BooleanIntProcess { get; set; } = null;
        public (bool, int)? BooleanIntResult { get; set; } = null;
        public Task<Services.Billing>? BillingProcess { get; set; } = null;
        public Services.Billing? BillingResult { get; set; } = null;
        public Task<Services.BillingWithEquipment>? BillingWithEquipmentProcess { get; set; } = null;
        public Services.BillingWithEquipment? BillingWithEquipmentResult { get; set; } = null;
        public Task<Services.EquipmentAccountDetails>? EquipmentDetailsProcess { get; set; } = null;
        public Services.EquipmentAccountDetails? EquipmentDetailsResult { get; set; } = null;
        public Task<List<string>>? StringListProcess { get; set; } = null;
        public List<string>? StringListResult { get; set; } = null;
        public Task<Services.BillingAccount>? BillingAccountProcess { get; set; } = null;
        public Services.BillingAccount? BillingAccountResult { get; set; } = null;
        public Task<List<Services.BillingRecord>>? BillingRecordProcess { get; set; } = null;
        public List<Services.BillingRecord>? BillingRecordResult { get; set; } = null;
        public Task<List<Services.AccountsDetails>>? AccountsTotalValuesProcess { get; set; } = null;
        public List<Services.AccountsDetails>? AccountsTotalValuesResult { get; set; } = null;
        public Task<List<Services.AccountsComboBoxDetails>>? AccountsCollectionProcess { get; set; } = null;
        public List<Services.AccountsComboBoxDetails>? AccountsCollectionResult { get; set; } = null;
        public string? Description { get; set; }
        public Services.Billing? Billing { get; set; }

        // Entity Framework

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
                if (StringProcess != null)
                {
                    StringResult = await Task.Run(() => StringProcess, cancellationTokenSource.Token);
                }
                if (IntegerProcess != null)
                {
                    IntegerResult = await Task.Run(() => IntegerProcess, cancellationTokenSource.Token);
                }
                if (BooleanProcess != null)
                {
                    bool result = await Task.Run(() => BooleanProcess, cancellationTokenSource.Token);
                    if (result) { DialogResult = DialogResult.OK; }
                    else { DialogResult = DialogResult.Abort; }
                    return;
                }
                if (BooleanIntProcess != null)
                {
                    BooleanIntResult = await Task.Run(() => BooleanIntProcess, cancellationTokenSource.Token);
                }
                if (BillingWithEquipmentProcess != null)
                {
                    BillingWithEquipmentResult = await Task.Run(() => BillingWithEquipmentProcess, cancellationTokenSource.Token);
                }
                if (EquipmentDetailsProcess != null)
                {
                    EquipmentDetailsResult = await Task.Run(() => EquipmentDetailsProcess, cancellationTokenSource.Token);
                }
                if (BillingProcess != null)
                {
                    BillingResult = await Task.Run(() => BillingProcess, cancellationTokenSource.Token);
                }
                if (StringListProcess != null)
                {
                    StringListResult = await Task.Run(() => StringListProcess, cancellationTokenSource.Token);
                }
                if (BillingAccountProcess != null)
                {
                    BillingAccountResult = await Task.Run(() => BillingAccountProcess, cancellationTokenSource.Token);
                }
                if (BillingRecordProcess != null)
                {
                    BillingRecordResult = await Task.Run(() => BillingRecordProcess, cancellationTokenSource.Token);
                }
                if (AccountsTotalValuesProcess != null)
                {
                    AccountsTotalValuesResult = await Task.Run(() => AccountsTotalValuesProcess, cancellationTokenSource.Token);
                }
                if (AccountsCollectionProcess != null)
                {
                    AccountsCollectionResult = await Task.Run(() => AccountsCollectionProcess, cancellationTokenSource.Token);
                }
                DialogResult = DialogResult.OK;
            }
            catch (OperationCanceledException)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Abort;
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
