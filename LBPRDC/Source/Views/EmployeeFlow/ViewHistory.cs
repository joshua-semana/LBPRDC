
using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;
using System.Security.Cryptography.Xml;

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
        }

        private void InitializeEmployeeInformation()
        {
            List<EmployeeService.Employee> employees = EmployeeService.GetAllEmployees();
            var employee = employees.First(e => e.EmployeeID == EmployeeId);
            txtEmployeeID.Text = EmployeeId;
            txtFullName.Text = $"{employee.LastName}, {employee.FirstName} {employee.MiddleName}";
        }

        private async void PopulateTableWithPositions()
        {
            List<PositionService.HistoryView> records = await Task.Run(() => PositionService.GetAllHistoryByID(EmployeeId));
            dgvHistory.Columns.Clear();
            dgvHistory.AutoGenerateColumns = false;
            AddColumn("Status", "Status", "Status");
            AddColumn("PositionName", "Position", "PositionName");
            AddColumn("PositionTitle", "Title", "PositionTitle");
            AddColumn("EffectiveDate", "Effective Date", "EffectiveDate");
            AddColumn("Remarks", "Remarks", "Remarks");
            dgvHistory.DataSource = records;
        }

        private async void PopulateTableWithCivilStatus()
        {
            List<CivilStatusService.HistoryView> records = await Task.Run(() => CivilStatusService.GetAllHistoryByID(EmployeeId));
            dgvHistory.Columns.Clear();
            dgvHistory.AutoGenerateColumns = false;
            AddColumn("Status", "Status", "Status");
            AddColumn("CivilStatusName", "Civil Status", "CivilStatusName");
            AddColumn("EffectiveDate", "Effective Date", "EffectiveDate");
            AddColumn("Remarks", "Remarks", "Remarks");
            dgvHistory.DataSource = records;
        }

        private async void PopulateTableWithEmploymentStatus()
        {
            List<EmploymentStatusService.HistoryView> records = await Task.Run(() => EmploymentStatusService.GetAllHistoryByID(EmployeeId));
            dgvHistory.Columns.Clear();
            dgvHistory.AutoGenerateColumns = false;
            AddColumn("Status", "Status", "Status");
            AddColumn("Name", "Status Name", "Name");
            AddColumn("EffectiveDate", "Effective Date", "EffectiveDate");
            AddColumn("Remarks", "Remarks", "Remarks");
            dgvHistory.DataSource = records;
        }

        private async void PopulateTableWithDepartmentLocation()
        {
            List<DepartmentService.HistoryView> records = await Task.Run(() => DepartmentService.GetAllHistoryByID(EmployeeId));
            dgvHistory.Columns.Clear();
            dgvHistory.AutoGenerateColumns = false;
            AddColumn("Status", "Status", "Status");
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
