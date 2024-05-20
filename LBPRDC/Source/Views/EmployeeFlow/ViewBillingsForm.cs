using LBPRDC.Source.Config;
using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;

namespace LBPRDC.Source.Views.EmployeeFlow
{
    public partial class ViewBillingsForm : Form
    {
        public string EmployeeID { get; set; } = "";
        public int ClientID { get; set; }

        private string TimeType = string.Empty;

        public ViewBillingsForm()
        {
            InitializeComponent();
        }

        private void ViewBillingsForm_Load(object sender, EventArgs e)
        {
            if (EmployeeID == "" && ClientID == 0)
            {
                MessageBox.Show(MessagesConstants.Error.RETRIEVE_DATA, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            cmbTimeType.SelectedIndex = 0;
        }

        private async void GetBillings()
        {
            var billingRecords = await BillingRecordService.GetAllBillingRecordInfoByIDs(ClientID, EmployeeID);
            dgvBillings.Columns.Clear();
            dgvBillings.AutoGenerateColumns = false;
            ApplySettingsToTable();
            dgvBillings.DataSource = billingRecords;
        }

        private void ApplySettingsToTable()
        {
            ControlUtils.AddColumn(dgvBillings, "Description", "Status", "Description", true, true); // Verified or Unverified
            ControlUtils.AddColumn(dgvBillings, "BillingName", "Billing Name", "BillingName", true, true);
            ControlUtils.AddColumn(dgvBillings, $"{TimeType}AccountNumber", "SOA", $"{TimeType}AccountNumber", true, true);
            //ControlUtils.AddColumn(dgvBillings, "EntryType", "Type", "EntryType", true, true);
            ControlUtils.AddColumn(dgvBillings, "Position", "Position", "Position", true, true);
            ControlUtils.AddColumn(dgvBillings, "SalaryRate", "Salary Rate", "SalaryRate", true, true);
            ControlUtils.AddColumn(dgvBillings, "BillingRate", "Billing Rate", "BillingRate", true, true);
            ControlUtils.AddColumn(dgvBillings, "UserRemarks", "Remarks", "UserRemarks", true, true);
            ControlUtils.AddColumn(dgvBillings, $"{TimeType}BillingValue", "Gross Billing", $"{TimeType}BillingValue", true, true);
            ControlUtils.AddColumn(dgvBillings, $"{TimeType}CollectedValue", "Collected Value", $"{TimeType}CollectedValue", true, true);
            ControlUtils.AddColumn(dgvBillings, $"{TimeType}CollectedDate", "Collected Date", $"{TimeType}CollectedDate", true, true);
            ControlUtils.AddColumn(dgvBillings, $"{TimeType}AdjustmentRemarks", "Adjustments", $"{TimeType}AdjustmentRemarks", true, true);
        }

        private void cmbTimeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            TimeType = cmbTimeType.Text;
            GetBillings();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
