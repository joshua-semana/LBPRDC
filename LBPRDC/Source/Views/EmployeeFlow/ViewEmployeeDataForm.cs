using LBPRDC.Source.Config;
using LBPRDC.Source.Services;

namespace LBPRDC.Source.Views.EmployeeFlow
{
    public partial class ViewEmployeeDataForm : Form
    {
        public int ClientID { get; set; }
        public int EmployeeID { get; set; }
        public ViewEmployeeDataForm()
        {
            InitializeComponent();
        }

        private void ViewEmployeeDataForm_Load(object sender, EventArgs e)
        {
            if (ClientID == 0 || EmployeeID == 0)
            {
                MessageBox.Show(MessagesConstants.Error.MISSING, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            InitializeEmployeeInformation();
        }

        private async void InitializeEmployeeInformation()
        {
            var employeeList = await EmployeeService.GetAllEmployeeInfoByClientID(ClientID, EmployeeID);

            if (employeeList == null && !employeeList.Any())
            {
                MessageBox.Show(MessagesConstants.Error.MISSING_EMPLOYEE, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            var employee = employeeList.First();

            var positions = await PositionService.GetAllEmployeeHistory(EmployeeID);
            var employeePreviousRecordList = await PreviousEmployeeService.GetEmployeeFormerHistory(EmployeeID);
            bool isFormerEmployee = employeePreviousRecordList.Any();

            var initialPosition = positions.Where(p => p.Remarks == StringConstants.InitialRemarks.POSITION).First();
            var currentPosition = positions.Where(p => p.Status == StringConstants.Status.ACTIVE).First();
            string noContent = "-";

            lblFullName.Text = $"{employee.LastName}, {employee.FirstName} {employee.MiddleName}";
            lblGender.Text = Utilities.StringFormat.ToSentenceCase(employee.Gender);
            lblEmailAddress1.Text = employee.EmailAddress1 ?? noContent;
            lblEmailAddress2.Text = employee.EmailAddress2 ?? noContent;
            lblContactNumber1.Text = employee.ContactNumber1 ?? noContent;
            lblContactNumber2.Text = employee.ContactNumber2 ?? noContent;
            lblIdentificationCode.Text = employee.EmployeeID.ToString();
            lblStartDate.Text = initialPosition.Timestamp.ToString(StringConstants.Date.DEFAULT) ?? noContent;
            lblWageType.Text = employee.WageName;
            lblPosition.Text = Utilities.StringFormat.ToSentenceCase(employee.PositionName);
            lblEffectiveDate.Text = currentPosition.Timestamp.ToString(StringConstants.Date.DEFAULT) ?? noContent;
            lblDepartment.Text = employee.DepartmentName;
            lblLocation.Text = employee.LocationName;
            lblStatus.Text = Utilities.StringFormat.ToSentenceCase(employee.EmploymentStatusName);
            lblRemarks.Text = employee.Remarks ?? noContent;

            if (isFormerEmployee)
            {
                var entity = employeePreviousRecordList.First();
                lblPreviousEmployee.Text = "Yes";
                lblPeriod.Text = $"{entity.StartDate.ToString(StringConstants.Date.DEFAULT)} to {entity.EndDate.ToString(StringConstants.Date.DEFAULT)}";
                lblInformation.Text = $"({entity.Position}) {entity.Information}";
            }
            else
            {
                lblPreviousEmployee.Text = "No";
                lblPeriod.Text = "N/A";
                lblInformation.Text = "N/A";
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnViewPositionHistory_Click(object sender, EventArgs e)
        {
            ViewHistory frmViewHistory = new()
            {
                HistoryType = "Position",
                EmployeeID = EmployeeID
            };
            frmViewHistory.ShowDialog();
        }
    }
}
