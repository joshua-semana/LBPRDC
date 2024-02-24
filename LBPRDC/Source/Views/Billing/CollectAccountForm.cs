using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;

namespace LBPRDC.Source.Views.Billing
{
    public partial class CollectAccountForm : Form
    {
        public BillingControl? ParentControl { get; set; }
        public string? BillingName { get; set; }
        public string? AccountNumber { get; set; }
        public decimal BillingValue { get; set; }
        //public decimal AmountCollected { get; set; }
        public string? OfficialReceiptNumber { get; set; }
        public DateTime CollectionDate { get; set; }

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
            BillingAccount accountInformation = new()
            {
                BillingName = BillingName,
                AccountNumber = AccountNumber,
                CollectionDate = dtpCollectionDate.Value,
                OfficialReceiptNumber = txtReceiptNumber.Text,
                Purpose = "Still Collecting",
            };

            BillingRecord recordInformation = new();
            string transactionType = string.Empty;


            if (!AccountNumber.Contains("OT"))
            {
                transactionType = "Regular";
                recordInformation = new()
                {
                    BillingName = BillingName,
                    RegularAccountNumber = AccountNumber,
                    RegularCollectedDate = dtpCollectionDate.Value,
                };
            }
            else
            {
                transactionType = "Overtime";
                recordInformation = new()
                {
                    BillingName = BillingName,
                    OvertimeAccountNumber = AccountNumber,
                    OvertimeCollectedDate = dtpCollectionDate.Value,
                };
            }

            frmLoading form = new()
            {
                BooleanProcess = Task.Run(() => BillingAccountService.UpdateInformation(accountInformation)),
                Description = "Updating information, please wait..."
            };

            var result = form.ShowDialog();

            if (result == DialogResult.OK && await Task.Run(() => BillingRecordService.UpdateCollectionDates(recordInformation, transactionType)))
            {
                MessageBox.Show("You have successfully updated the information of this billing's statement of account.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ParentControl?.FetchAccountDetailsAndPopulate();
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
