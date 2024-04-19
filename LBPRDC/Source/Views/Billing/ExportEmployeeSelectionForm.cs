using LBPRDC.Source.Config;
using LBPRDC.Source.Services;

namespace LBPRDC.Source.Views.Billing
{
    public partial class ExportEmployeeSelectionForm : Form
    {
        public BillingControl? ParentControl { get; set; }
        public List<Entry> EditableEntries = new();
        public string BillingName = "";

        private Dictionary<string, int> CurrentIndexByDepartment = new();
        private Dictionary<string, List<Entry>> GroupedEntriesByDepartment = new();

        private string CurrentDepartment = "";

        private void GroupEntriesByDepartment() => GroupedEntriesByDepartment = EditableEntries.GroupBy(gp => gp.Department).ToDictionary(group => group.Key, group => group.OrderBy(ob => ob.FullName).ToList());
        private void UpdateCurrentDepartment() => CurrentDepartment = cmbDepartment.Text;
        private int GetCurrentIndex() => CurrentIndexByDepartment[CurrentDepartment];

        public ExportEmployeeSelectionForm()
        {
            InitializeComponent();
        }

        private void ExportEmployeeSelectionForm_Load(object sender, EventArgs e)
        {
            this.Text = $"Export File for {BillingName} Billing";
            GetLatestEmployeeInformation();
            InitializeDepartmentComboBoxItems();
            GroupEntriesByDepartment();
            DisplayEmployeeList();
        }

        private async void GetLatestEmployeeInformation()
        {
            var employees = await EmployeeService.GetAllEmployeesBase();
            foreach (var entry in EditableEntries)
            {
                var emp = employees.First(f => f.EmployeeID == entry.EmployeeID);
                entry.Department = emp.Department;
                entry.Position = emp.Position;
                entry.Location = emp.Location;
                entry.FullName = $"{emp.LastName}, {emp.FirstName} {emp.MiddleName}";
            }
        }

        private void InitializeDepartmentComboBoxItems()
        {
            var departments = EditableEntries.DistinctBy(db => db.Department).Select(s => s.Department).ToList();
            cmbDepartment.DataSource = departments;
            cmbDepartment.DisplayMember = "Department";
            CurrentIndexByDepartment = departments.ToDictionary(d => d, _ => 0);
            UpdateCurrentDepartment();
        }

        private void DisplayEmployeeList()
        {
            flowLeftList.Controls.Clear();
            List<Control> checkList = new();
            int index = 0;

            //CheckBox checkSelectAll = new()
            //{
            //    Text = "Select All",
            //    AutoSize = true,
            //    MaximumSize = new Size(275, 50),
            //    Padding = new Padding(0, 0, 0, 2),
            //    Cursor = Cursors.Hand,
            //    Checked = true,
            //    Font = new Font("Arial", 11, FontStyle.Regular),
            //    Tag = index
            //};

            //checkSelectAll.Click += CheckSelectAll_Click;

            //checkList.Add(checkSelectAll);
            //index++;

            foreach (var employee in GroupedEntriesByDepartment[CurrentDepartment])
            {
                string statusSIL = "";
                string status = (employee.VerificationStatus == "Verified") ? "✔" : "";
                var adjustmentList = employee?.Adjustments?.ToList() ?? new List<EntryAdjustments>();
                if (adjustmentList != null)
                {
                    var adjustmentWithSIL = adjustmentList.Where(w => w.Remarks.Contains("[SIL]")).ToList();
                    statusSIL = (adjustmentWithSIL.Count > 0) ? " SIL |" : "";
                }

                CheckBox check = new()
                {
                    Text = $"{status}{statusSIL} {employee.EmployeeID} | {Utilities.StringFormat.ToSentenceCase(employee.FullName)}",
                    AutoSize = true,
                    MaximumSize = new Size(275, 50),
                    Padding = new Padding(0, 0, 0, 2),
                    Cursor = Cursors.Hand,
                    Checked = employee.ExportIncluded,
                    Font = new Font("Arial", 11, FontStyle.Regular),
                    Tag = index,
                    AccessibleName = $"{employee.EmployeeID} {employee.FullName}",
                    AccessibleDescription = statusSIL,
                };

                checkList.Add(check);
                index++;
            }

            //labelList = labelList.Where(w =>
            //        w.AccessibleName.ToLower().Contains(txtSearch.Text) ||
            //        w.AccessibleDescription.ToLower().Contains(txtSearch.Text)
            //    ).ToList();

            flowLeftList.Controls.AddRange(checkList.ToArray());

            int selectedIndex = GetCurrentIndex();
            if (selectedIndex >= 0 && selectedIndex < checkList.Count)
            {
                Control selectedLabel = checkList[selectedIndex];
                int scrollPosition = selectedLabel.Top - flowLeftList.AutoScrollPosition.Y;
                pnlLeftContainer.AutoScrollPosition = new Point(0, scrollPosition);
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

        private void btnContinue_Click(object sender, EventArgs e)
        {
            DisplayEmployeeList();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            EditableEntries.ForEach(employee => employee.ExportIncluded = true);
            DisplayEmployeeList();
        }
    }
}
