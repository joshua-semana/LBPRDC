using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;

namespace LBPRDC.Source.Views.EmployeeFlow
{
    public partial class ViewBillingsForm : Form
    {
        public string EmployeeID { get; set; } = string.Empty;

        private string TimeType = string.Empty;

        public ViewBillingsForm()
        {
            InitializeComponent();
        }

        private void ViewBillingsForm_Load(object sender, EventArgs e)
        {
            cmbTimeType.SelectedIndex = 0;

            GetBillings();
        }

        private void GetBillings()
        {
            frmLoading form = new()
            {
                BillingRecordProcess = Task.Run(() => BillingRecordService.GetAllBillingsByEmployeeID(EmployeeID))
            };

            DialogResult result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                PopulateTable(form.BillingRecordResult);
            }
            else if (result == DialogResult.Abort)
            {
                MessageBox.Show("Unable to retrieve billing information; please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void PopulateTable(List<BillingRecord> records)
        {
            dgvBillings.Columns.Clear();
            dgvBillings.AutoGenerateColumns = false;
            ApplySettingsToTable();
            dgvBillings.DataSource = records;
        }

        private void ApplySettingsToTable()
        {
            ControlUtils.AddColumn(dgvBillings, "Description", "Status 1", "Description", true, true); // Verified or Unverified
            ControlUtils.AddColumn(dgvBillings, "BillingName", "Billing Name", "BillingName", true, true);
            ControlUtils.AddColumn(dgvBillings, $"{TimeType}AccountNumber", "SOA", $"{TimeType}AccountNumber", true, true);
            ControlUtils.AddColumn(dgvBillings, "EntryType", "Type", "EntryType", true, true);
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
