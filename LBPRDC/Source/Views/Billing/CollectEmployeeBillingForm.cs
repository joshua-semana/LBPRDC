using LBPRDC.Source.Config;
using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;

namespace LBPRDC.Source.Views.Billing
{
    public partial class CollectEmployeeBillingForm : Form
    {
        public ViewAccountBillings? ParentControl { get; set; }
        public int BillingID { get; set; }
        public string BillingName { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public Guid EmployeeGuid { get; set; }
        public string? EmployeeName { get; set; } = string.Empty;
        public decimal AccountGrossBillingValue { get; set; }
        public decimal GrossBillingValue { get; set; }
        public decimal CollectedValue { get; set; }

        private readonly List<Control> RequiredFields;

        public CollectEmployeeBillingForm()
        {
            InitializeComponent();

            RequiredFields = new()
            {
                txtCollectedAmount
            };
        }

        private void CollectEmployeeBillingForm_Load(object sender, EventArgs e)
        {
            Text = $"{AccountNumber} | {EmployeeName}";
            txtGrossBillingValue.Text = $"{GrossBillingValue:N2}";
            txtCollectedAmount.Text = (CollectedValue > 0) ? CollectedValue.ToString() : "";
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (ControlUtils.AreRequiredFieldsFilled(RequiredFields))
            {
                decimal collectedAmount = Convert.ToDecimal(txtCollectedAmount.Text);
                UpdateCollectedValueOfEmployee(EmployeeGuid, collectedAmount);
            }
        }

        private async void UpdateCollectedValueOfEmployee(Guid employeeGuid, decimal collectedAmount)
        {
            BillingRecord collectionDetails = new();
            string transactionType = string.Empty;

            if (!AccountNumber.Contains("OT"))
            {
                transactionType = "Regular";
                collectionDetails = new()
                {
                    Guid = employeeGuid,
                    BillingName = BillingName,
                    RegularAccountNumber = AccountNumber,
                    RegularCollectedValue = collectedAmount
                };
            }
            else
            {
                transactionType = "Overtime";
                collectionDetails = new()
                {
                    Guid = employeeGuid,
                    BillingName = BillingName,
                    OvertimeAccountNumber = AccountNumber,
                    OvertimeCollectedValue = collectedAmount
                };
            }

            if (collectionDetails == null && string.IsNullOrEmpty(transactionType))
            {
                MessageBox.Show("Unable to update billing collection information. Objects are empty.", MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmLoading form = new()
            {
                //BooleanProcess = Task.Run(() => BillingRecordService.UpdateCollectionInformation(collectionDetails, transactionType))
            };

            DialogResult output = form.ShowDialog();

            if (output == DialogResult.OK && await UpdateAccountCollectedAndBalanceValue())
            {
                ParentControl?.FetchData();
                Close();
            }
            else if (output == DialogResult.Abort)
            {
                MessageBox.Show("There is a problem updating the employee collected billing information; please try again.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<bool> UpdateAccountCollectedAndBalanceValue()
        {
            decimal currentValue = await Task.Run(() => BillingAccountService.GetCollectedValue(AccountNumber, BillingName));
            decimal newCollectedValue = (currentValue - Convert.ToDecimal(CollectedValue)) + Convert.ToDecimal(txtCollectedAmount.Text);
            decimal newBalanceValue = AccountGrossBillingValue - newCollectedValue;

            bool hasCollectedValueUpdated = await Task.Run(() => BillingAccountService.UpdateCollectedValue(AccountNumber, BillingID, newCollectedValue));
            bool hasBalanceValueUpdated = await Task.Run(() => BillingAccountService.UpdateBalance(AccountNumber, BillingID, newBalanceValue));
            return hasCollectedValueUpdated && hasBalanceValueUpdated;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MoneyInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '.' || (e.KeyChar == '.' && (sender as TextBox)?.Text.Contains('.') == true)) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

    }
}
