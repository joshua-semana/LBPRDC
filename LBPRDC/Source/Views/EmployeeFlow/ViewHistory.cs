using LBPRDC.Source.Services;

namespace LBPRDC.Source.Views.EmployeeFlow
{
    public partial class ViewHistory : Form
    {
        public string? EmployeeId { get; set; }
        public string? HistoryType { get; set; }

        public ViewHistory()
        {
            InitializeComponent();
        }

        private void ViewHistory_Load(object sender, EventArgs e)
        {
            if (EmployeeId != null)
            {
                switch (HistoryType)
                {
                    case "Position":
                        PopulateTableWithPositions();
                        break;
                    case "Civil Status":
                        PopulateTableWithCivilStatus();
                        break;
                    case "Employment Status":
                        PopulateTableWithEmploymentStatus();
                        break;
                    case "Department and Location":
                        PopulateTableWithDepartmentLocation();
                        break;
                }
                this.Text = $"Employee {HistoryType} History";
                InitializeEmployeeInformation();
            }
            else
            {
                MessageBox.Show("There seems to be a problem loading the data. Please try again.", "Error Loading Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void InitializeEmployeeInformation()
        {
            var employees = EmployeeService.GetAllEmployees();
            var employee = employees.First(e => e.EmployeeID == EmployeeId);
            txtEmployeeID.Text = EmployeeId;
            txtFullName.Text = $"{employee.LastName}, {employee.FirstName} {employee.MiddleName}";
        }

        private async void PopulateTableWithPositions()
        {
            var records = await Task.Run(() => PositionService.GetAllHistoryByID(EmployeeId));
            records = records.OrderByDescending(o => o.Timestamp).ToList();
            dgvHistory.Columns.Clear();
            dgvHistory.AutoGenerateColumns = false;
            AddColumn("StatusName", "", "StatusName");
            AddColumn("PositionName", "Position", "PositionName");
            AddColumn("PositionTitle", "Title", "PositionTitle");
            AddColumn("SalaryRate", "Salary Rate", "SalaryRate");
            AddColumn("BillingRate", "Billing Rate", "BillingRate");
            AddColumn("EffectiveDate", "Effective Date", "EffectiveDate");
            AddColumn("Remarks", "Remarks", "Remarks");
            dgvHistory.DataSource = records;
        }

        private async void PopulateTableWithCivilStatus()
        {
            var records = await Task.Run(() => CivilStatusService.GetAllHistoryByID(EmployeeId));
            records = records.OrderByDescending(o => o.Timestamp).ToList();
            dgvHistory.Columns.Clear();
            dgvHistory.AutoGenerateColumns = false;
            AddColumn("StatusName", "", "StatusName");
            AddColumn("CivilStatusName", "Civil Status", "CivilStatusName");
            AddColumn("EffectiveDate", "Effective Date", "EffectiveDate");
            AddColumn("Remarks", "Remarks", "Remarks");
            dgvHistory.DataSource = records;
        }

        private async void PopulateTableWithEmploymentStatus()
        {
            var records = await Task.Run(() => EmploymentStatusService.GetAllHistoryByID(EmployeeId));
            records = records.OrderByDescending(o => o.Timestamp).ToList();
            dgvHistory.Columns.Clear();
            dgvHistory.AutoGenerateColumns = false;
            AddColumn("StatusName", "", "StatusName");
            AddColumn("Name", "Status Name", "Name");
            AddColumn("EffectiveDate", "Effective Date", "EffectiveDate");
            AddColumn("Remarks", "Remarks", "Remarks");
            dgvHistory.DataSource = records;
        }

        private async void PopulateTableWithDepartmentLocation()
        {
            var records = await Task.Run(() => DepartmentService.GetAllHistoryByID(EmployeeId));
            records = records.OrderByDescending(o => o.Timestamp).ToList();
            dgvHistory.Columns.Clear();
            dgvHistory.AutoGenerateColumns = false;
            AddColumn("StatusName", "", "StatusName");
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
