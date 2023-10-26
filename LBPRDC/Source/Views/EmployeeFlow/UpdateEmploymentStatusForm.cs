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
    public partial class UpdateEmploymentStatusForm : Form
    {
        public string? EmployeeId { get; set; }
        public ucEmployees? ParentControl { get; set; }

        private readonly List<Control> requiredFields;
        public UpdateEmploymentStatusForm()
        {
            InitializeComponent();

            requiredFields = new List<Control>
            {
                cmbEmploymentStatus
            };
        }

        private void UpdateEmploymentStatusForm_Load(object sender, EventArgs e)
        {
            if (EmployeeId != null)
            {
                InitializeEmployeeInformation(EmployeeId);
                InitializePositionComboBoxItems();
            }
        }

        private void InitializePositionComboBoxItems()
        {
            cmbEmploymentStatus.DataSource = EmploymentStatusService.GetAllItemsForComboBox();
            cmbEmploymentStatus.DisplayMember = "Name";
            cmbEmploymentStatus.ValueMember = "ID";
        }

        private void InitializeEmployeeInformation(string ID)
        {
            List<EmployeeService.Employee> employee = EmployeeService.GetAllEmployees();

            employee = employee.Where(w => w.EmployeeID == ID).ToList();
            txtEmployeeID.Text = employee.First().EmployeeID;
            txtFullName.Text = $"{employee.First().LastName}, {employee.First().FirstName} {employee.First().MiddleName}";
            txtCurrentEmploymentStatus.Text = employee.First().EmploymentStatus;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ControlUtils.AreRequiredFieldsFilled(requiredFields))
            {
                if (txtCurrentEmploymentStatus.Text == cmbEmploymentStatus.Text)
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
            EmployeeService.EmployeeEmploymentStatusUpdate data = new()
            {
                EmployeeID = txtEmployeeID.Text,
                EmploymentStatusID = Convert.ToInt32(cmbEmploymentStatus.SelectedValue),
                Remarks = txtRemarks.Text,
                Date = DateTime.Now,
            };

            bool isUpdated = await EmployeeService.UpdateEmployeeEmploymentStatus(data);

            if (isUpdated)
            {
                MessageBox.Show("You have successfully updated this employee's employment status information.", "Update Employee Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
