

using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;

namespace LBPRDC.Source.Views.EmployeeFlow
{
    public partial class UpdateCivilStatusForm : Form
    {
        public string? EmployeeId { get; set; }
        public ucEmployees? ParentControl { get; set; }

        private readonly List<Control> requiredFields;
        public UpdateCivilStatusForm()
        {
            InitializeComponent();

            requiredFields = new List<Control>
            {
                cmbCivilStatus
            };
        }

        private void UpdateCivilStatusForm_Load(object sender, EventArgs e)
        {
            if (EmployeeId != null)
            {
                InitializeEmployeeInformation(EmployeeId);
                InitializePositionComboBoxItems();
            }
        }

        private void InitializePositionComboBoxItems()
        {
            cmbCivilStatus.DataSource = CivilStatusService.GetAllItemsForComboBox();
            cmbCivilStatus.DisplayMember = "Name";
            cmbCivilStatus.ValueMember = "ID";
        }

        private void InitializeEmployeeInformation(string ID)
        {
            List<EmployeeService.Employee> employee = EmployeeService.GetAllEmployees();

            employee = employee.Where(w => w.EmployeeID == ID).ToList();
            txtEmployeeID.Text = employee.First().EmployeeID;
            txtFullName.Text = $"{employee.First().LastName}, {employee.First().FirstName} {employee.First().MiddleName}";
            txtCurrentCivilStatus.Text = employee.First().CivilStatus;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ControlUtils.AreRequiredFieldsFilled(requiredFields))
            {
                if (txtCurrentCivilStatus.Text == cmbCivilStatus.Text)
                {
                    MessageBox.Show("Please select a different status. Cannot update to the same status", "Cannot Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var result1 = MessageBox.Show("Are you sure you want to update this employee's position information?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result1 == DialogResult.No) return;

                UpdateEmployeeInformation();
            }
        }

        private async void UpdateEmployeeInformation()
        {
            EmployeeService.EmployeeCivilStatusUpdate data = new()
            {
                EmployeeID = txtEmployeeID.Text,
                CivilStatusID = Convert.ToInt32(cmbCivilStatus.SelectedValue),
                Remarks = txtRemarks.Text,
                Date = DateTime.Now,
            };

            bool isUpdated = await EmployeeService.UpdateEmployeeCivilStatus(data);

            if (isUpdated)
            {
                MessageBox.Show("You have successfully updated this employee's civil status information.", "Update Employee Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ParentControl?.PopulateTable();
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
