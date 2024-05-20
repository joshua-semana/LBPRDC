using LBPRDC.Source.Config;
using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;

namespace LBPRDC.Source.Views.Billing
{
    public partial class AddAccountForm : Form
    {
        public BillingControl ParentControl { get; set; } = new();
        public string BillingName { get; set; } = string.Empty;

        private readonly List<Control> RequiredFields;

        public AddAccountForm()
        {
            InitializeComponent();

            RequiredFields = new()
            {
                txtAccountNumber,
                txtClassification,
                txtBillingValue
            };
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (ControlUtils.AreRequiredFieldsFilled(RequiredFields))
            {
                AddCustomAccount();
            }
        }

        //private void AddCustomBillingRecord()
        //{
        //    List<BillingRecord> records = new();

        //    var existingGuidList = new HashSet<Guid>(BillingRecordService.GetGuids());

        //    Guid newGuid;
        //    do
        //    {
        //        newGuid = Guid.NewGuid();
        //    } while (existingGuidList.Contains(newGuid));

        //    string classification = txtClassification.Text.ToString().ToUpper().Trim();
        //    string accountNumber = txtAccountNumber.Text.ToString().ToUpper().Trim();
        //    decimal grossAmount = Convert.ToDecimal(txtBillingValue.Text);

        //    records.Add(new()
        //    {
        //        Guid = newGuid,
        //        EmployeeID = null, // TODO: Make sure the view all billings in employee does not error out because of this.
        //        FullName = classification,
        //        EntryType = null,
        //        Position = null,
        //        Department = classification,
        //        TimeDetailJSON = null,
        //        SalaryRate = 0,
        //        BillingRate = 0,
        //        BillingName = BillingName,
        //        RegularAccountNumber = accountNumber,
        //        OvertimeAccountNumber = null,
        //        RegularBillingValue = grossAmount,
        //        OvertimeBillingValue = 0,
        //        RegularAdjustmentRemarks
        //    });
        //}

        private void AddCustomAccount()
        {
            List<BillingAccount> newAccounts = new();

            decimal grossAmount = Convert.ToDecimal(txtBillingValue.Text);

            newAccounts.Add(new()
            {
                BillingName = BillingName,
                AccountNumber = txtAccountNumber.Text.ToString().ToUpper().Trim(),
                EntryType = StringConstants.Type.CUSTOM,
                OfficialReceiptNumber = "",
                Classification = txtClassification.Text.ToString().ToUpper().Trim(),
                BilledValue = grossAmount,
                NetBilling = Convert.ToDecimal((double)grossAmount / 1.12 * 0.07),
                CollectedValue = 0,
                CollectionDate = null,
                Balance = grossAmount,
                Purpose = "",
                Timestamp = DateTime.Now,
                Remarks = ""
            });

            frmLoading form = new()
            {
                BooleanProcess = Task.Run(() => BillingAccountService.Add(newAccounts, BillingName))
            };

            DialogResult result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                MessageBox.Show("You have successfully added this new custom account entry.", "Add Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ParentControl.btnView.PerformClick();
                Close();
            }
            else if (result == DialogResult.Abort)
            {
                MessageBox.Show("There is a problem adding a custom account entry, please try again.", MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
