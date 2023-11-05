using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;
using System.Data;
using static LBPRDC.Source.Services.EmployeeService;

namespace LBPRDC.Source.Views.EmployeeFlow
{
    public partial class UpdatePositionForm : Form
    {
        public string? EmployeeId { get; set; }
        public ucEmployees? ParentControl { get; set; }

        private readonly List<Control> requiredFields;

        public UpdatePositionForm()
        {
            InitializeComponent();

            requiredFields = new List<Control>
            {
                cmbPosition
            };
        }

        private void UpdatePositionForm_Load(object sender, EventArgs e)
        {
            if (EmployeeId != null)
            {
                InitializeEmployeeInformation(EmployeeId);
                InitializePositionComboBoxItems();
            }
        }

        private void InitializePositionComboBoxItems()
        {
            cmbPosition.DataSource = PositionService.GetAllItemsForComboBox();
            cmbPosition.DisplayMember = "Name";
            cmbPosition.ValueMember = "ID";
        }

        private void InitializeEmployeeInformation(string ID)
        {
            List<EmployeeService.Employee> employees = EmployeeService.GetAllEmployees();
            List<PositionService.History> positions = PositionService.GetAllHistory();

            var employee = employees.First(w => w.EmployeeID == ID);
            var currentPosition = positions.First(w => w.EmployeeID == ID && w.Status == "Active");

            txtEmployeeID.Text = employee.EmployeeID;
            txtFullName.Text = $"{employee.LastName}, {employee.FirstName} {employee.MiddleName}";
            txtCurrentPosition.Tag = employee.PositionID;
            txtCurrentPosition.Text = $"{employee.PositionCode} - {employee.PositionName}";
            txtCurrentPositionTitle.Text = currentPosition.PositionTitle;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ControlUtils.AreRequiredFieldsFilled(requiredFields))
            {
                var result1 = MessageBox.Show("Are you sure you want to update this employee's position information?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result1 == DialogResult.No) return;

                UpdateEmployeeInformation();
            }
        }
        private async void UpdateEmployeeInformation()
        {
            EmployeeService.EmployeePositionUpdate data = new()
            {
                EmployeeID = txtEmployeeID.Text,
                OldPositionID = Convert.ToInt32(txtCurrentPosition.Tag),
                PositionID = Convert.ToInt32(cmbPosition.SelectedValue),
                PositionTitle = txtPositionTitle.Text.ToUpper().Trim(),
                Remarks = txtRemarks.Text,
                Date = dtpEffectiveDate.Value
            };

            bool isUpdated = await EmployeeService.UpdateEmployeePosition(data);

            if (isUpdated)
            {
                MessageBox.Show("You have successfully updated this employee's position information.", "Update Employee Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
