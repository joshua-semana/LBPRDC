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
                InitializePositionComboBoxItems();
                InitializeCivilStatusComboBoxItems();
                InitializeEmploymentStatusComboBoxItems();
                InitializeSuffixComboBoxItems();
                InitializeGenderComboBoxItems();
                InitializeDepartmentComboBoxItems();
            }
        }

        private void InitializePositionComboBoxItems()
        {
            cmbPosition.DataSource = PositionService.GetAllItemsForComboBox();
            cmbPosition.DisplayMember = "Name";
            cmbPosition.ValueMember = "ID";
        }

        private void InitializeCivilStatusComboBoxItems()
        {
            cmbCivilStatus.DataSource = CivilStatusService.GetAllItemsForComboBox();
            cmbCivilStatus.DisplayMember = "Name";
            cmbCivilStatus.ValueMember = "ID";
        }

        private void InitializeEmploymentStatusComboBoxItems()
        {
            cmbEmploymentStatus.DataSource = EmploymentStatusService.GetAllItemsForComboBox();
            cmbEmploymentStatus.DisplayMember = "Name";
            cmbEmploymentStatus.ValueMember = "ID";
        }

        private void InitializeSuffixComboBoxItems()
        {
            cmbSuffix.DataSource = SuffixService.GetAllItemsForComboBox();
            cmbSuffix.DisplayMember = "Name";
            cmbSuffix.ValueMember = "ID";
        }

        private void InitializeDepartmentComboBoxItems()
        {
            cmbDepartment.DataSource = DepartmentService.GetAllItemsForComboBox();
            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "ID";
        }

        private void GetLocationComboBoxItems()
        {
            if (cmbDepartment.SelectedIndex != 0)
            {
                cmbLocation.Enabled = true;
                int DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue);
                cmbLocation.DataSource = LocationService.GetAllItemsForComboBox(DepartmentID);
                cmbLocation.DisplayMember = "Name";
                cmbLocation.ValueMember = "ID";
            }
            else
            {
                cmbLocation.DataSource = null;
                cmbLocation.Enabled = false;
            }
        }

        private void InitializeGenderComboBoxItems()
        {
            cmbGender.SelectedIndex = 0;
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

            List<EmployeeService.Employee> record = EmployeeService.GetAllEmployees();
            record = record.Where(w => w.EmployeeID == ID).ToList();
            txtFirstName.Text = record.First().FirstName;
            txtMiddleName.Text = record.First().MiddleName;
            txtLastName.Text = record.First().LastName;
            txtEducation.Text = record.First().Education;
            dtpBirthday.Value = record.First().Birthday.Value;
            txtEmailAddress1.Text = record.First().EmailAddress1;
            txtEmailAddress2.Text = record.First().EmailAddress2;
            txtContactNumber1.Text = record.First().ContactNumber1;
            txtContactNumber2.Text = record.First().ContactNumber2;
            txtEmployeeID.Text = record.First().EmployeeID;
            txtRemarks.Text = record.First().Remarks;
        }

        private void chkPreviousEmployee_CheckedChanged(object sender, EventArgs e)
        {
            grpPreviousWork.Enabled = chkPreviousEmployee.Checked;
        }
    }
}
