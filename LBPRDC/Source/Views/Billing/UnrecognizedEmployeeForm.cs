using LBPRDC.Source.Config;
using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;

namespace LBPRDC.Source.Views.Billing
{
    public partial class UnrecognizedEmployeeForm : Form
    {
        public List<EmployeeBase> Employees { get; set; }

        public UnrecognizedEmployeeForm()
        {
            InitializeComponent();
        }

        private void UnrecognizedEmployeeForm_Load(object sender, EventArgs e)
        {
            Employees = Employees.OrderBy(ob => ob.FullName).ToList();
            dgvEmployees.Columns.Clear();
            dgvEmployees.AutoGenerateColumns = false;
            ApplySettingsToTable();
            dgvEmployees.DataSource = Employees;
        }

        private void ApplySettingsToTable()
        {
            ControlUtils.AddColumn(dgvEmployees, "EmployeeID", "ID", "EmployeeID", true, true);
            ControlUtils.AddColumn(dgvEmployees, "FullName", "Full Name", "FullName", true, true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(MessagesConstants.Cancel.QUESTION, MessagesConstants.Cancel.TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
