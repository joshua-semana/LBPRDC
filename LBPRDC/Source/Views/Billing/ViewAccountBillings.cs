using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;

namespace LBPRDC.Source.Views.Billing
{
    public partial class ViewAccountBillings : Form
    {
        public BillingControl? ParentControl { get; set; }
        public List<BillingRecord> BillingRecords { get; set; } = new();
        public List<AccountsDetails>? AccountsTotalValues { get; set; } = new();
        public string AccountNumber { get; set; } = "";
        public string BillingName { get; set; } = "";

        public ViewAccountBillings()
        {
            InitializeComponent();
        }

        private void ViewAccountBillings_Load(object sender, EventArgs e)
        {
            Text = BillingName;
            lblAccountNumber.Text = $"SOA No.: {AccountNumber}";

            if (BillingRecords.Count > 0)
            {
                PopulateBillingTable(BillingRecords);
                PopulateAccountNumberValues(AccountsTotalValues);
            }
            else
            {
                MessageBox.Show("There is a problem retrieving the record(s) of this account number, please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Close();
            }
        }

        private void PopulateAccountNumberValues(List<AccountsDetails> accountsTotal)
        {
            if (accountsTotal.Any())
            {
                var totalGross = accountsTotal.First(f => f.AccountNumber == AccountNumber).GrossBilling;
                var totalNet = (double) totalGross - ((double) totalGross / 1.12 * 0.07);
                lblTotalGrossValue.Text = $"Total Gross Billing: {totalGross:N2}";
                lblTotalNetValue.Text = $"Total Net Billing: {totalNet:N2}";
            }
            else
            {
                lblTotalGrossValue.Text = "Total Gross Billing: (Can't retrieve information)";
                lblTotalNetValue.Text = "Total Net Billing: (Can't retrieve information)";
            }
        }

        private void PopulateBillingTable(List<BillingRecord> records)
        {
            dgvBillings.Columns.Clear();
            dgvBillings.AutoGenerateColumns = false;
            ApplySettingsToTable();
            dgvBillings.DataSource = records;

            dgvBillings.CellContentClick += DgvBillings_CellContentClick;
        }

        private void ApplySettingsToTable()
        {
            ControlUtils.AddColumn(dgvBillings, "EntryType", "Type", "EntryType");
            ControlUtils.AddColumn(dgvBillings, "EmployeeID", "ID", "EmployeeID");
            ControlUtils.AddColumn(dgvBillings, "FullName", "Name", "FullName");
            ControlUtils.AddColumn(dgvBillings, "Position", "Position", "Position");
            ControlUtils.AddColumn(dgvBillings, "UserRemarks", "Your Remarks", "UserRemarks");
            ControlUtils.AddColumn(dgvBillings, "Description", "Status", "Description");
            if (!AccountNumber.Contains("OT"))
            {
                ControlUtils.AddColumn(dgvBillings, "RegularBillingValue", "Gross Billing", "RegularBillingValue");
                ControlUtils.AddColumn(dgvBillings, "RegularAdjustmentRemarks", "Adjustments", "RegularAdjustmentRemarks");
            }
            else
            {
                ControlUtils.AddColumn(dgvBillings, "OvertimeBillingValue", "Gross Billing", "OvertimeBillingValue");
                ControlUtils.AddColumn(dgvBillings, "OvertimeAdjustmentRemarks", "Adjustments", "OvertimeAdjustmentRemarks");
            }

            DataGridViewButtonColumn colAction = new()
            {
                HeaderText = "Action",
                Text = "Collect",
                UseColumnTextForButtonValue = true
            };
            dgvBillings.Columns.Add(colAction);
        }

        private void DgvBillings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvBillings.Columns.Count - 1)
            {
                MessageBox.Show("Button clicked for row " + e.RowIndex.ToString());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
