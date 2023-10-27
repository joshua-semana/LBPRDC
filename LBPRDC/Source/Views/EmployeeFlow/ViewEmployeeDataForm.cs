
using LBPRDC.Source.Services;

namespace LBPRDC.Source.Views.EmployeeFlow
{
    public partial class ViewEmployeeDataForm : Form
    {
        public string? EmployeeId { get; set; }
        public ViewEmployeeDataForm()
        {
            InitializeComponent();
        }

        private void ViewEmployeeDataForm_Load(object sender, EventArgs e)
        {
            if (EmployeeId != null)
            {
                InitializeEmployeeInformation(EmployeeId);
            }
        }

        private void InitializeEmployeeInformation(string employeeId)
        {
            List<EmployeeService.Employee> employees = EmployeeService.GetAllEmployees();
            List<PositionService.History> positions = PositionService.GetAllHistory();
            PreviousEmployeeService.PreviousEmployee record = PreviousEmployeeService.GetRecordByEmployeeID(employeeId);

            var employee = employees.First(e => e.EmployeeID == employeeId);
            var initialPosition = positions.First(p => p.EmployeeID == employeeId && p.Remarks == "[Initial Status]");
            string noContent = "-";

            lblFullName.Text = $"{employee.LastName}, {employee.FirstName} {employee.MiddleName}";
            lblGender.Text = Utilities.StringFormat.ToSentenceCase(employee.Gender);
            lblBirthday.Text = employee.Birthday?.ToString("MMMM dd, yyyy") ?? noContent;
            lblEducation.Text = string.IsNullOrWhiteSpace(employee.Education) ? noContent : employee.Education;
            lblCivilStatus.Text = Utilities.StringFormat.ToSentenceCase(employee.CivilStatus);
            lblEmailAddress1.Text = string.IsNullOrWhiteSpace(employee.EmailAddress1) ? noContent : employee.EmailAddress1;
            lblEmailAddress2.Text = string.IsNullOrWhiteSpace(employee.EmailAddress2) ? noContent : employee.EmailAddress2;
            lblContactNumber1.Text = string.IsNullOrWhiteSpace(employee.ContactNumber1) ? noContent : employee.ContactNumber1;
            lblContactNumber2.Text = string.IsNullOrWhiteSpace(employee.ContactNumber2) ? noContent : employee.ContactNumber2;
            lblIdentificationCode.Text = employeeId.ToString();
            lblStartDate.Text = initialPosition.Timestamp?.ToString("MMMM dd, yyyy") ?? noContent;
            lblPosition.Text = $"{employee.PositionCode} - {Utilities.StringFormat.ToSentenceCase(employee.PositionName)}";
            lblDepartment.Text = employee.Department;
            lblLocation.Text = employee.Location;
            lblStatus.Text = Utilities.StringFormat.ToSentenceCase(employee.EmploymentStatus);
            lblRemarks.Text = string.IsNullOrWhiteSpace(employee.Remarks) ? noContent : employee.Remarks;
            lblPreviousEmployee.Text = (record.HasRecord) ? "Yes" : "No";
            lblPeriod.Text = (record.HasRecord) ? $"{record.StartDate?.ToString("MMMM dd, yyyy")} to {record.EndDate?.ToString("MMMM dd, yyyy")}" : "N/A";
            lblInformation.Text = (record.HasRecord) ? $"({record.Position}) {record.Information}" : "N/A";
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
