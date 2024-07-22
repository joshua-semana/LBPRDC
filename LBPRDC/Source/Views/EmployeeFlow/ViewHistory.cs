using LBPRDC.Source.Config;
using LBPRDC.Source.Services;

namespace LBPRDC.Source.Views.EmployeeFlow
{
    public partial class ViewHistory : Form
    {
        public int ClientID { get; set; }
        public int EmployeeID { get; set; }
        public string? HistoryType { get; set; }

        public ViewHistory()
        {
            InitializeComponent();
        }

        private void ViewHistory_Load(object sender, EventArgs e)
        {
            if (ClientID == 0 || EmployeeID == 0)
            {
                MessageBox.Show(MessagesConstants.Error.RETRIEVE_DATA, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            this.Text = $"Employee {HistoryType} History";
            InitializeEmployeeInformation(ClientID, EmployeeID);

            switch (HistoryType)
            {
                case "Position":
                    PopulateTableWithPositions();
                    break;
                case "Employment Status":
                    PopulateTableWithEmploymentStatus();
                    break;
                case "Department and Location":
                    PopulateTableWithDepartmentLocation();
                    break;
            }
        }

        private async void InitializeEmployeeInformation(int ClientID, int EmployeeID)
        {
            var employees = await EmployeeService.GetEmployees(ClientID, EmployeeID);

            if (employees.Any())
            {
                var employee = employees.First();
                txtEmployeeID.Text = employee.EmployeeID;
                txtFullName.Text = employee.FullName;
            }
            else
            {
                MessageBox.Show(MessagesConstants.Error.MISSING_EMPLOYEE, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private async void PopulateTableWithPositions()
        {
            var records = await Task.Run(() => PositionService.GetHistoriesWithView(ClientID, EmployeeID));
            records = records.OrderByDescending(o => o.Timestamp).ToList();
            dgvHistory.Columns.Clear();
            dgvHistory.AutoGenerateColumns = false;
            AddColumn("Indicator", "", "Indicator");
            AddColumn("PositionName", "Position", "PositionName");
            AddColumn("PositionTitle", "Title", "PositionTitle");
            AddColumn("WageType", "Wage Type", "WageType");
            AddColumn("DailySalaryRate", "Salary Rate (Daily)", "DailySalaryRate");
            AddColumn("DailyBillingRate", "Billing Rate (Daily)", "DailyBillingRate");
            AddColumn("MonthlySalaryRate", "Salary Rate (Monthly)", "MonthlySalaryRate");
            AddColumn("MonthlyBillingRate", "Billing Rate (Monthly)", "MonthlyBillingRate");
            AddColumn("EffectiveDate", "Effective Date", "EffectiveDate");
            AddColumn("Remarks", "Remarks", "Remarks");
            dgvHistory.DataSource = records;
        }

        private async void PopulateTableWithEmploymentStatus()
        {
            var records = await Task.Run(() => EmploymentStatusService.GetHistoriesWithView(EmployeeID));
            records = records.OrderByDescending(o => o.Timestamp).ToList();
            dgvHistory.Columns.Clear();
            dgvHistory.AutoGenerateColumns = false;
            AddColumn("Indicator", "", "Indicator");
            AddColumn("EmploymentStatusName", "Status Name", "EmploymentStatusName");
            AddColumn("EffectiveDate", "Effective Date", "EffectiveDate");
            AddColumn("Remarks", "Remarks", "Remarks");
            dgvHistory.DataSource = records;
        }

        private async void PopulateTableWithDepartmentLocation()
        {
            var records = await Task.Run(() => DepartmentService.GetHistoriesWithView(EmployeeID));
            records = records.OrderByDescending(o => o.Timestamp).ToList();
            dgvHistory.Columns.Clear();
            dgvHistory.AutoGenerateColumns = false;
            AddColumn("Indicator", "", "Indicator");
            AddColumn("DepartmentName", "Department", "DepartmentName");
            AddColumn("LocationName", "Location", "LocationName");
            AddColumn("EffectiveDate", "Effective Date", "EffectiveDate");
            AddColumn("Remarks", "Remarks", "Remarks");
            dgvHistory.DataSource = records;
        }

        private void AddColumn(string name, string header, string property)
        {
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                DataPropertyName = property
            });
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
