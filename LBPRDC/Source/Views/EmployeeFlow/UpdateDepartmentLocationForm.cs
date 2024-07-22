using LBPRDC.Source.Config;
using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;

namespace LBPRDC.Source.Views.EmployeeFlow
{
    public partial class UpdateDepartmentLocationForm : Form
    {
        public int EmployeeID { get; set; }
        public int ClientID { get; set; }
        public ucEmployees? ParentControl { get; set; }

        private readonly List<Control> requiredFields;
        private List<Models.Department> DepartmentList = new();

        public UpdateDepartmentLocationForm()
        {
            InitializeComponent();

            requiredFields = new List<Control>
            {
                cmbDepartment
            };
        }

        private void UpdateDepartmentLocationForm_Load(object sender, EventArgs e)
        {
            if (EmployeeID != 0 || ClientID != 0)
            {
                InitializeDepartmentComboBoxItems();
                InitializeEmployeeInformation(ClientID, EmployeeID);
            }
            else
            {
                MessageBox.Show(MessagesConstants.Error.RETRIEVE_DATA, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private async void GetLocationComboBoxItems()
        {
            if (cmbDepartment.SelectedIndex != 0)
            {
                cmbLocation.Enabled = true;
                int DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue);
                cmbLocation.DataSource = await LocationService.GetAllItemsForComboBoxByID(DepartmentID);
                cmbLocation.DisplayMember = "Name";
                cmbLocation.ValueMember = "ID";
            }
            else
            {
                cmbLocation.DataSource = null;
                cmbLocation.Enabled = false;
            }
        }

        private async void InitializeDepartmentComboBoxItems()
        {
            DepartmentList = await DepartmentService.GetAllItemsForComboBox(ClientID);
            cmbDepartment.DataSource = DepartmentList;
            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "ID";
        }

        private async void InitializeEmployeeInformation(int ClientID, int EmployeeID)
        {
            var employees = await EmployeeService.GetEmployees(ClientID, EmployeeID);

            if (employees.Any())
            {
                var employee = employees.First();
                var departmentInfo = DepartmentList.Where(w => w.ID == employee.DepartmentID).FirstOrDefault();

                txtCurrentDepartment.Text = (departmentInfo != null) 
                    ? departmentInfo.Name
                    : $"{MessagesConstants.Error.TITLE} - {MessagesConstants.Error.CANT_RETRIEVE}";

                txtEmployeeID.Text = employee.EmployeeID;
                txtFullName.Text = $"{employee.LastName}, {employee.FirstName} {employee.MiddleName}";
                txtCurrentLocation.Text = employee.LocationName;
            }
            else
            {
                MessageBox.Show(MessagesConstants.Error.MISSING_EMPLOYEE, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetLocationComboBoxItems();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ControlUtils.AreRequiredFieldsFilled(requiredFields))
            {
                var result1 = MessageBox.Show(MessagesConstants.Update.QUESTION, MessagesConstants.Update.TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result1 == DialogResult.No) return;

                UpdateEmployeeInformation();
            }
        }
        private async void UpdateEmployeeInformation()
        {
            bool isUpdated = await EmployeeService.UpdateEmployeeDepartmentLocation(new()
            {
                EmployeeID = EmployeeID,
                DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue),
                LocationID = Convert.ToInt32(cmbLocation.SelectedValue),
                DepartmentName = cmbDepartment.Text,
                LocationName = cmbLocation.Text,
                Remarks = txtRemarks.Text,
                Timestamp = DateTime.Now,
            });

            if (isUpdated)
            {
                MessageBox.Show(MessagesConstants.Update.SUCCESS, MessagesConstants.SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ParentControl?.ApplyFilterAndSearchThenPopulate();
                this.Close();
            }
            else
            {
                MessageBox.Show(MessagesConstants.Error.ACTION, MessagesConstants.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
