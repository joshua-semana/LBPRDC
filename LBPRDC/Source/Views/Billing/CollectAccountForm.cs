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
        public decimal AmountCollected { get; set; }
        public int OfficialReceiptNumber { get; set; }
        public DateTime CollectionDate { get; set; }
        public string? Remarks { get; set; }

        public List<Control> RequiredFields;

        public CollectAccountForm()
        {
            InitializeComponent();

            RequiredFields = new()
            {
                txtAmountCollected,
                txtReceiptNumber
            };
        }

        private void CollectAccountForm_Load(object sender, EventArgs e)
        {
            Text = AccountNumber;

            txtBillingValue.Text = BillingValue.ToString();
            txtAmountCollected.Text = AmountCollected.ToString();
            txtReceiptNumber.Text = OfficialReceiptNumber.ToString();
            dtpCollectionDate.Value = CollectionDate;
            txtRemarks.Text = Remarks;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (ControlUtils.AreRequiredFieldsFilled(RequiredFields))
            {
                if (Convert.ToInt32(txtReceiptNumber.Text) < 0)
                {
                    MessageBox.Show("Invalid entry for Receipt Number.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                UpdateAccountCollectionInformation();
            }
        }

        private void UpdateAccountCollectionInformation()
        {
            BillingAccount accountInformation = new()
            {
                BillingName = BillingName,
                AccountNumber = AccountNumber,
                CollectedValue = Convert.ToDecimal(txtAmountCollected.Text),
                CollectionDate = dtpCollectionDate.Value,
                OfficialReceiptNumber = Convert.ToInt32(txtReceiptNumber.Text),
                Remarks = txtRemarks.Text
            };

            frmLoading form = new()
            {
                BooleanProcess = Task.Run(() => BillingService.UpdateBillingAccountInformation(accountInformation)),
                Description = "Updating information, please wait..."
            };

            var result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                MessageBox.Show("You have successfully updated the information of this billing's statement of account.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ParentControl?.FetchAccountAndPopulate();
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

        private void ValidateInputIfNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '.' || (e.KeyChar == '.' && (sender as TextBox)?.Text.Contains('.') == true)) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
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
