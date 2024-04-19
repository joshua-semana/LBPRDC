using LBPRDC.Source.Config;
using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;
using static LBPRDC.Source.Services.EmployeeService;

namespace LBPRDC.Source.Views.Billing
{
    public partial class SummaryView : Form
    {
        public EmployeeTimekeepReviewForm? ParentControl { get; set; }
        public string BillingName = "";

        public List<Entry> Employees { get; set; } = new();
        public List<Entry> UnverifiedEmployees { get; private set; } = new();
        public List<Entry> BookmarkedEmployees { get; private set; } = new();
        public List<Entry> SILEmployees { get; private set; } = new();

        public SummaryView()
        {
            InitializeComponent();
        }

        private void SummaryViewForm_Load(object sender, EventArgs e)
        {
            UnverifiedEmployees = Employees.Where(w => w.VerificationStatus == StringConstants.Status.UNVERIFIED).ToList();
            BookmarkedEmployees = Employees.Where(w => w.BookmarkRemarks != null && w.BookmarkRemarks != "").ToList();
            SILEmployees = Employees.Where(w => w.Adjustments != null && w.Adjustments.Any(a => a.Remarks.Contains("[SIL]"))).ToList();

            this.Text = $"Summary View of {BillingName}";
            Employees = Employees.OrderBy(ob => ob.FullName).ToList();

            cmbCompositeCategory.SelectedIndex = 0;

            PopulateTableByCategory(cmbCompositeCategory.Text);

            lblUnverifiedCount.Text = $"Unverified Employee(s): {UnverifiedEmployees.Count}";
            lblBookmarkCount.Text = $"Bookmarked Employee(s): {BookmarkedEmployees.Count}";
            lblSILCount.Text = $"Employee(s) on Service Incentive Leave (SIL): {SILEmployees.Count}";
        }

        private void PopulateTableByCategory(string category)
        {
            dgvEmployees.Columns.Clear();
            dgvEmployees.AutoGenerateColumns = false;
            ApplySettingsToTable();
            dgvEmployees.DataSource = category switch
            {
                StringConstants.Status.UNVERIFIED => UnverifiedEmployees,
                "Bookmarked" => BookmarkedEmployees,
                "On Service Incentive Leave" => SILEmployees,
                _ => Employees,
            };
        }

        private void ApplySettingsToTable()
        {
            ControlUtils.AddColumn(dgvEmployees, "EmployeeID", "ID", "EmployeeID", true, true);
            ControlUtils.AddColumn(dgvEmployees, "FullName", "Full Name", "FullName", true, true);
            ControlUtils.AddColumn(dgvEmployees, "Position", "Position", "Position", true, true);
            ControlUtils.AddColumn(dgvEmployees, "Department", "Department", "Department", true, true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnContinue_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to set this billing as exportable while there are still employees who are unverified, have a bookmark, or are on service incentive leave?", "Verification Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void cmbCompositeCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateTableByCategory(cmbCompositeCategory.Text);
        }
    }
}
