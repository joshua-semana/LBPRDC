using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;
using System.Data;
using static LBPRDC.Source.Services.EmployeeService;

namespace LBPRDC.Source.Views.EmployeeFlow
{
    public partial class UpdateDepartmentLocationForm : Form
    {
        public string? EmployeeId { get; set; }
        public ucEmployees? ParentControl { get; set; }

        private readonly List<Control> requiredFields;

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
            if (EmployeeId != null)
            {
                InitializeEmployeeInformation(EmployeeId);
                InitializeDepartmentComboBoxItems();
            }
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

        private void InitializeDepartmentComboBoxItems()
        {
            cmbDepartment.DataSource = DepartmentService.GetAllItemsForComboBox();
            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "ID";
        }

        private void InitializeEmployeeInformation(string ID)
        {
            List<EmployeeService.Employee> employees = EmployeeService.GetAllEmployees();

            var employee = employees.First(w => w.EmployeeID == ID);
            
            txtEmployeeID.Text = employee.EmployeeID;
            txtFullName.Text = $"{employee.LastName}, {employee.FirstName} {employee.MiddleName}";
            txtCurrentDepartment.Text = employee.Department;
            txtCurrentLocation.Text = employee.Location;
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetLocationComboBoxItems();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ControlUtils.AreRequiredFieldsFilled(requiredFields))
            {
                var result1 = MessageBox.Show("Are you sure you want to update this employee's information?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result1 == DialogResult.No) return;

                UpdateEmployeeInformation();
            }
        }
        private async void UpdateEmployeeInformation()
        {
            EmployeeService.EmployeeDepartmentLocationUpdate data = new()
            {
                EmployeeID = txtEmployeeID.Text,
                DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue),
                LocationID = Convert.ToInt32(cmbLocation.SelectedValue),
                Remarks = txtRemarks.Text,
                Date = DateTime.Now,
            };

            bool isUpdated = await EmployeeService.UpdateEmployeeDepartmentLocation(data);

            if (isUpdated)
            {
                MessageBox.Show("You have successfully updated this employee's department and location information.", "Update Employee Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ParentControl?.ApplyFilterAndSearchThenPopulate();
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to cancel this operation?", "Cancel Operation Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
