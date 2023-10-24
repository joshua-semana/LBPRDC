using LBPRDC.Source.Services;
using System.Data;

namespace LBPRDC.Source.Views.EmployeeFlow
{
    public partial class EditEmployeeForm : Form
    {
        public string? EmployeeId { get; set; }
        public ucEmployees? ParentControl { get; set; }

        private readonly List<Control> requiredFields;

        public EditEmployeeForm()
        {
            InitializeComponent();

            requiredFields = new List<Control>
            {
                txtFirstName,
                txtLastName,
                cmbGender,
                cmbCivilStatus,
                txtEmployeeID,
                cmbPosition,
                cmbEmploymentStatus,
                cmbDepartment
            };
        }

        private void EditEmployeeForm_Load(object sender, EventArgs e)
        {
            if (EmployeeId != null)
            {
                InitializeEmployeeInformation(EmployeeId);
            }
        }

        private void InitializePositionComboBoxItems(int value)
        {
            cmbPosition.DataSource = PositionService.GetAllItemsForComboBox();
            cmbPosition.DisplayMember = "Name";
            cmbPosition.ValueMember = "ID";
            cmbPosition.SelectedValue = value;
        }

        private void InitializeCivilStatusComboBoxItems(int value)
        {
            cmbCivilStatus.DataSource = CivilStatusService.GetAllItemsForComboBox();
            cmbCivilStatus.DisplayMember = "Name";
            cmbCivilStatus.ValueMember = "ID";
            cmbCivilStatus.SelectedValue = value;
        }

        private void InitializeEmploymentStatusComboBoxItems(int value)
        {
            cmbEmploymentStatus.DataSource = EmploymentStatusService.GetAllItemsForComboBox();
            cmbEmploymentStatus.DisplayMember = "Name";
            cmbEmploymentStatus.ValueMember = "ID";
            cmbEmploymentStatus.SelectedValue = value;
        }

        private void InitializeSuffixComboBoxItems(int value)
        {
            cmbSuffix.DataSource = SuffixService.GetAllItemsForComboBox();
            cmbSuffix.DisplayMember = "Name";
            cmbSuffix.ValueMember = "ID";
            cmbSuffix.SelectedValue = value;
        }

        private void InitializeDepartmentComboBoxItems(int value)
        {
            cmbDepartment.DataSource = DepartmentService.GetAllItemsForComboBox();
            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "ID";
            cmbDepartment.SelectedValue = value;
        }

        private void InitializeLocationComboBoxItems(int deparment, int value)
        {
            int DepartmentID = Convert.ToInt32(deparment);
            cmbLocation.DataSource = LocationService.GetAllItemsForComboBox(DepartmentID);
            cmbLocation.DisplayMember = "Name";
            cmbLocation.ValueMember = "ID";
            cmbLocation.SelectedValue = value;
        }

        private void InitializeGenderComboBoxItems(string value)
        {
            cmbGender.SelectedItem = value;
        }

        private void InitializeEmployeeInformation(string ID)
        {
            PreviousEmployeeService.PreviousEmployee previousRecord = PreviousEmployeeService.GetRecordByEmployeeID(ID);
            if (previousRecord.HasRecord)
            {
                chkPreviousEmployee.Checked = true;
                grpPreviousWork.Enabled = true;
                txtPreviousPosition.Text = previousRecord.Position;
                dtpFromDate.Value = previousRecord.StartDate.Value;
                dtpToDate.Value = previousRecord.EndDate.Value;
                txtOtherInformation.Text = previousRecord.Information;
            }

            List<EmployeeService.Employee> employee = EmployeeService.GetAllEmployees();
            employee = employee.Where(w => w.EmployeeID == ID).ToList();
            txtFirstName.Text = employee.First().FirstName;
            txtMiddleName.Text = employee.First().MiddleName;
            txtLastName.Text = employee.First().LastName;
            txtEducation.Text = employee.First().Education;
            dtpBirthday.Value = employee.First().Birthday.Value;
            txtEmailAddress1.Text = employee.First().EmailAddress1;
            txtEmailAddress2.Text = employee.First().EmailAddress2;
            txtContactNumber1.Text = employee.First().ContactNumber1;
            txtContactNumber2.Text = employee.First().ContactNumber2;
            txtEmployeeID.Text = employee.First().EmployeeID;
            txtRemarks.Text = employee.First().Remarks;
            InitializeGenderComboBoxItems(employee.First().Gender);
            InitializePositionComboBoxItems(employee.First().PositionID);
            InitializeCivilStatusComboBoxItems(employee.First().CivilStatusID);
            InitializeEmploymentStatusComboBoxItems(employee.First().EmploymentStatusID);
            InitializeSuffixComboBoxItems(employee.First().SuffixID);
            InitializeDepartmentComboBoxItems(employee.First().DepartmentID);
            InitializeLocationComboBoxItems(employee.First().DepartmentID, employee.First().LocationID);
        }

        private void chkPreviousEmployee_CheckedChanged(object sender, EventArgs e)
        {
            grpPreviousWork.Enabled = chkPreviousEmployee.Checked;
        }
    }
}
