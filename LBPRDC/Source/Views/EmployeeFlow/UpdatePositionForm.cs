using LBPRDC.Source.Config;
using LBPRDC.Source.Models;
using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;
using static LBPRDC.Source.Config.StringConstants;

namespace LBPRDC.Source.Views.EmployeeFlow
{
    public partial class UpdatePositionForm : Form
    {
        public int ClientID { get; set; }
        public int EmployeeID { get; set; }
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
            if (EmployeeID != 0 && ClientID != 0)
            {
                InitializeEmployeeInformation(ClientID, EmployeeID);
                InitializePositionComboBoxItems();
            }
            else
            {
                MessageBox.Show(MessagesConstants.Error.RETRIEVE_DATA, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private async void InitializePositionComboBoxItems()
        {
            cmbPosition.DataSource = await PositionService.GetAllItemsForComboBoxByClientID(ClientID);
            cmbPosition.DisplayMember = "Name";
            cmbPosition.ValueMember = "ID";
        }

        private async void InitializeEmployeeInformation(int ClientID, int EmployeeID)
        {
            var employees = await EmployeeService.GetEmployees(ClientID, EmployeeID);
            var positions = await PositionService.GetHistories(EmployeeID, Status.ACTIVE);

            if (employees.Any() && positions.Any())
            {
                var e = employees.First();
                var currentPosition = positions.First();

                txtEmployeeID.Text = e.EmployeeID;
                txtFullName.Text = $"{e.LastName}, {e.FirstName} {e.MiddleName}";
                txtCurrentPosition.Tag = e.PositionID;
                txtCurrentPosition.Text = e.PositionName;
                txtCurrentPositionTitle.Text = currentPosition.PositionTitle;
            }
            else
            {
                MessageBox.Show(MessagesConstants.Error.MISSING_EMPLOYEE, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
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
            bool isUpdated = await EmployeeService.UpdateEmployeePosition(new()
            {
                EmployeeID = EmployeeID,
                OldPositionID = Convert.ToInt32(txtCurrentPosition.Tag),
                PositionID = Convert.ToInt32(cmbPosition.SelectedValue),
                PositionTitle = txtPositionTitle.Text.ToUpper().Trim(),
                DailySalaryRate = 0,
                DailyBillingRate = 0,
                MonthlySalaryRate = 0,
                MonthlyBillingRate = 0,
                Remarks = txtRemarks.Text,
                Timestamp = dtpEffectiveDate.Value,
                Status = StringConstants.Status.ACTIVE
            },
            ClientID);

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
