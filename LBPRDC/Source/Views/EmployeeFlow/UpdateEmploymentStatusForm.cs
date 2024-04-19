﻿using LBPRDC.Source.Config;
using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;

namespace LBPRDC.Source.Views.EmployeeFlow
{
    public partial class UpdateEmploymentStatusForm : Form
    {
        public int EmployeeID { get; set; }
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
            if (EmployeeID != 0)
            {
                InitializeEmployeeInformation(EmployeeID);
                InitializePositionComboBoxItems();
            }
            else
            {
                MessageBox.Show(MessagesConstants.Error.RETRIEVE_DATA, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void InitializePositionComboBoxItems()
        {
            cmbEmploymentStatus.DataSource = EmploymentStatusService.GetAllItemsForComboBox();
            cmbEmploymentStatus.DisplayMember = "Name";
            cmbEmploymentStatus.ValueMember = "ID";
        }

        private async void InitializeEmployeeInformation(int ID)
        {
            var employees = await EmployeeService.GetAllEmployees();

            var employee = employees.First(w => w.ID == ID);

            txtEmployeeID.Text = employee.EmployeeID;
            txtFullName.Text = $"{employee.LastName}, {employee.FirstName} {employee.MiddleName}";
            txtCurrentEmploymentStatus.Text = employee.EmploymentStatus;
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

                var result1 = MessageBox.Show(MessagesConstants.Update.QUESTION, MessagesConstants.Update.TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result1 == DialogResult.No) return;

                UpdateEmployeeInformation();
            }
        }

        private async void UpdateEmployeeInformation()
        {
            EmployeeService.EmployeeEmploymentStatusUpdate data = new()
            {
                EmployeeID = EmployeeID,
                EmploymentStatusID = Convert.ToInt32(cmbEmploymentStatus.SelectedValue),
                Remarks = txtRemarks.Text,
                Date = DateTime.Now,
            };

            bool isUpdated = await EmployeeService.UpdateEmployeeEmploymentStatus(data);

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
            var result = MessageBox.Show(MessagesConstants.Cancel.QUESTION, MessagesConstants.Cancel.TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
