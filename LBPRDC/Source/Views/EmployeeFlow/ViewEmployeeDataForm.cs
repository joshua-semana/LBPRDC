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
            string noContent = "-";
            var employeeList = await EmployeeService.GetEmployees(ClientID, EmployeeID);

            if (employeeList == null && !employeeList.Any())
            {
                MessageBox.Show(MessagesConstants.Error.MISSING_EMPLOYEE, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            var e = employeeList.First();

            lblIdentificationCode.Text = e.EmployeeID;
            lblFullName.Text = Utilities.StringFormat.ToSentenceCase(e.FullName.Trim());
            lblGender.Text = e.Gender;
            lblEmailAddress1.Text = e.EmailAddress1 ?? noContent;
            lblEmailAddress2.Text = e.EmailAddress2 ?? noContent;
            lblContactNumber1.Text = e.ContactNumber1 ?? noContent;
            lblContactNumber2.Text = e.ContactNumber2 ?? noContent;
            lblRemarks.Text = e.Remarks ?? noContent;
            lblClassification.Text = e.ClassificationName;
            lblWageType.Text = e.WageName;
            lblPosition.Text = e.PositionName;
            lblDepartment.Text = e.DepartmentName;
            lblLocation.Text = e.LocationName;
            lblStatus.Text = e.EmploymentStatusName;

            var positions = await PositionService.GetAllEmployeeHistory(EmployeeID);
            var initialPosition = positions.Where(p => p.Remarks == StringConstants.InitialRemarks.POSITION).First();
            var currentPosition = positions.Where(p => p.Status == StringConstants.Status.ACTIVE).First();

            lblStartDate.Text = initialPosition.Timestamp.ToString(StringConstants.Date.DEFAULT) ?? noContent;
            lblEffectiveDate.Text = currentPosition.Timestamp.ToString(StringConstants.Date.DEFAULT) ?? noContent;

            var employeePreviousRecordList = await PreviousEmployeeService.GetEmployeeFormerHistory(EmployeeID);
            bool isFormerEmployee = employeePreviousRecordList.Any();

            if (isFormerEmployee)
            {
                var entity = employeePreviousRecordList.First();
                var formerPosition = Utilities.StringFormat.ToSentenceCase(entity.Position);
                lblPreviousEmployee.Text = "Yes";
                lblPeriod.Text = $"{entity.StartDate.ToString(StringConstants.Date.DEFAULT)} to {entity.EndDate.ToString(StringConstants.Date.DEFAULT)}";
                lblInformation.Text = $"({formerPosition}) {entity.Information}";
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
                EmployeeID = EmployeeID,
                ClientID = ClientID
            };
            frmViewHistory.ShowDialog();
        }
    }
}
