using LBPRDC.Source.Config;
using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;

namespace LBPRDC.Source.Views.Billing
{
    public partial class CollectAccountForm : Form
    {
        public BillingControl? ParentControl { get; set; }
        public int BillingID { get; set; }
        public string AccountNumber { get; set; } = "";
        public decimal BillingValue { get; set; }
        public string? OfficialReceiptNumber { get; set; }
        public DateTime CollectionDate { get; set; }
        public string EntryType { get; set; } = "";

        public List<Control> RequiredFields;

        public CollectAccountForm()
        {
            InitializeComponent();

            RequiredFields = new()
            {
                txtReceiptNumber
            };
        }

        private void CollectAccountForm_Load(object sender, EventArgs e)
        {
            if (BillingID == 0 || string.IsNullOrEmpty(AccountNumber) || string.IsNullOrEmpty(EntryType))
            {
                MessageBox.Show(MessagesConstants.Error.MISSING_BILLING, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            Text = AccountNumber;

            txtBillingValue.Text = BillingValue.ToString();
            txtReceiptNumber.Text = OfficialReceiptNumber?.ToString();
            dtpCollectionDate.Value = CollectionDate;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (ControlUtils.AreRequiredFieldsFilled(RequiredFields))
            {
                if (string.IsNullOrEmpty(txtReceiptNumber.Text))
                {
                    MessageBox.Show("Invalid entry for Receipt Number.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                UpdateAccountCollectionInformation();
            }
        }

        private async void UpdateAccountCollectionInformation()
        {
            Models.Billing.Account accountInformation = new()
            {
                BillingID = BillingID,
                AccountNumber = AccountNumber,
                CollectionDate = dtpCollectionDate.Value,
                OfficialReceiptNumber = txtReceiptNumber.Text,
                Purpose = StringConstants.Status.COLLECTING,
            };

            Models.Billing.Record recordInformation = new();
            string transactionType = string.Empty;


            if (!AccountNumber.Contains("OT"))
            {
                transactionType = StringConstants.Type.REGULAR;
                recordInformation = new()
                {
                    BillingID = BillingID,
                    RegularAccountNumber = AccountNumber,
                    RegularCollectedDate = dtpCollectionDate.Value,
                };
            }
            else
            {
                transactionType = StringConstants.Type.OVERTIME;
                recordInformation = new()
                {
                    BillingID = BillingID,
                    OvertimeAccountNumber = AccountNumber,
                    OvertimeCollectedDate = dtpCollectionDate.Value,
                };
            }

            frmLoading form = new()
            {
                BooleanProcess = Task.Run(() => BillingAccountService.UpdateInformationAsync(accountInformation)),
                Description = "Updating information, please wait..."
            };

            var result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (EntryType == StringConstants.Type.REGULAR)
                {
                    await BillingRecordService.UpdateCollectionDatesAsync(recordInformation, transactionType);
                }

                MessageBox.Show("You have successfully updated the information of this billing's statement of account.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ParentControl?.PopulateSelectedAccountInformation();
                Close();
            }
            else if (result == DialogResult.Abort)
            {
                MessageBox.Show("There is a problem updating the information of this billing's statement of account, please try again.", "Update Not Successful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ValidateInputIfNumber1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}
