using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            List<EmployeeService.Employee> employee = EmployeeService.GetAllEmployees();
            List<PositionService.History> positionHistory = PositionService.GetAllHistory();

            employee = employee.Where(w => w.EmployeeID == ID).ToList();
            txtEmployeeID.Text = employee.First().EmployeeID;
            txtFullName.Text = $"{employee.First().LastName}, {employee.First().FirstName} {employee.First().MiddleName}";
            txtCurrentPosition.Text = $"{employee.First().PositionCode} - {employee.First().PositionName}";
            txtCurrentPositionTitle.Text = positionHistory.Where(w => w.EmployeeID == ID && w.Status == "Active").First().PositionTitle;
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
                PositionID = Convert.ToInt32(cmbPosition.SelectedValue),
                PositionTitle = txtPositionTitle.Text.ToUpper().Trim(),
                Remarks = txtRemarks.Text,
                Date = dtpEffectiveDate.Value
            };

            bool isUpdated = await EmployeeService.UpdateEmployeePosition(data);

            if (isUpdated)
            {
                MessageBox.Show("You have successfully updated this employee's position information.", "Update Employee Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ParentControl?.PopulateTable();
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to cancel this operation?", "Cancel Adding of Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
