using LBPRDC.Source.Config;
using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;

namespace LBPRDC.Source.Views.EmployeeFlow
{
    public partial class UpdatePositionForm : Form
    {
        public int EmployeeID { get; set; }
        public int ClientID { get; set; }
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
                InitializeEmployeeInformation(EmployeeID);
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

        private async void InitializeEmployeeInformation(int ID)
        {
            var employees = await EmployeeService.GetAllEmployees();
            List<PositionService.History> positions = PositionService.GetAllHistory();

            var employee = employees.First(w => w.ID == ID);
            var currentPosition = positions.First(w => w.EmployeeID == ID && w.Status == StringConstants.Status.ACTIVE);

            ClientID = employee.ClientID;

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
                var result1 = MessageBox.Show(MessagesConstants.Update.QUESTION, MessagesConstants.Update.TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result1 == DialogResult.No) return;

                UpdateEmployeeInformation();
            }
        }
        private async void UpdateEmployeeInformation()
        {
            EmployeeService.EmployeePositionUpdate data = new()
            {
                EmployeeID = EmployeeID,
                OldPositionID = Convert.ToInt32(txtCurrentPosition.Tag),
                PositionID = Convert.ToInt32(cmbPosition.SelectedValue),
                PositionTitle = txtPositionTitle.Text.ToUpper().Trim(),
                Remarks = txtRemarks.Text,
                Date = dtpEffectiveDate.Value
            };

            bool isUpdated = await EmployeeService.UpdateEmployeePosition(data);

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
