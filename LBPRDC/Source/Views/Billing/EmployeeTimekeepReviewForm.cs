using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;
using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace LBPRDC.Source.Views.Billing
{
    public partial class EmployeeTimekeepReviewForm : Form
    {
        public BillingControl? ParentControl { get; set; }
        public List<Entry> InitialEntries = new();
        public string BillingName = "";
        public string DateQuarter = "";
        public string DateCoverage = "";

        private List<Entry> CombinedEntries = new();
        private Dictionary<string, int> EmployeeIndexByDepartment = new();
        private Dictionary<string, List<Entry>> EntriesByDepartment = new();
        private string CurrentDepartment = "";

        private bool ChangesAreSaved = true;

        private Entry CurrentEmployee() => EntriesByDepartment[CurrentDepartment][GetCurrentIndex()];

        private void UpdateCurrentDepartment() => CurrentDepartment = cmbDepartment.Text;
        private int GetCurrentIndex() => EmployeeIndexByDepartment[CurrentDepartment];
        private int GetTotalOfEntriesByDepartment() => EntriesByDepartment[CurrentDepartment].Count;
        private static string GetTotalHours(TimeSpan time) => time == TimeSpan.Zero ? "" : $"{(int)time.TotalHours:D2}:{time.Minutes:D2}";

        public EmployeeTimekeepReviewForm()
        {
            InitializeComponent();
        }

        public void RefreshData()
        {
            DisplayEntryListByDepartment();
            DisplayCurrentEmployeeDetails();
        }

        private void EmployeeTimekeepReviewForm_Load(object sender, EventArgs e)
        {
            this.Text = $"{BillingName} | {DateQuarter} Quarter | {DateCoverage}";
            GetLatestEmployeeInformation();
            InitializeDepartmentComboBoxItems();
            GroupEntriesByDepartment();
            RefreshData();
        }

        private void GetLatestEmployeeInformation()
        {
            var employees = EmployeeService.GetAllEmployeesBase();
            foreach (var entry in InitialEntries)
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
            var departments = InitialEntries.DistinctBy(db => db.Department).Select(s => s.Department).ToList();
            cmbDepartment.DataSource = departments;
            cmbDepartment.DisplayMember = "Department";
            EmployeeIndexByDepartment = departments.ToDictionary(d => d, _ => 0);
            UpdateCurrentDepartment();
        }

        private void GroupEntriesByDepartment()
        {
            EntriesByDepartment = InitialEntries.GroupBy(gp => gp.Department).ToDictionary(group => group.Key, group => group.OrderBy(ob => ob.FullName).ToList());
        }

        private void DisplayEntryListByDepartment()
        {
            flowLeftEmployeeList.Controls.Clear();
            int index = 0;
            var initialEmployeeNumberedList = EntriesByDepartment[CurrentDepartment];

            List<Control> labelList = new();

            foreach (var entry in initialEmployeeNumberedList)
            {
                string status = (entry.Status == "Verified") ? "✔" : "•";

                Label label = new()
                {
                    Text = $"{status} {entry.EmployeeID} | {Utilities.StringFormat.ToSentenceCase(entry.FullName)}",
                    AutoSize = true,
                    MaximumSize = new Size(200, 50),
                    Cursor = Cursors.Hand,
                    ForeColor = (GetCurrentIndex() == index) ? Color.DarkGreen : Color.Black,
                    Padding = new Padding(0, 0, 0, 4),
                    Tag = index,
                    AccessibleName = entry.FullName,
                    AccessibleDescription = entry.EmployeeID
                };

                label.Click += Label_Click;
                label.MouseEnter += Label_MouseEnter;
                label.MouseLeave += Label_MouseLeave;
                labelList.Add(label);
                index++;
            }

            labelList = labelList.Where(w =>
                    w.AccessibleName.ToLower().Contains(txtSearch.Text) ||
                    w.AccessibleDescription.ToLower().Contains(txtSearch.Text)
                ).ToList();

            flowLeftEmployeeList.Controls.AddRange(labelList.ToArray());
        }

        private void DisplayCurrentEmployeeDetails()
        {
            UpdateCounter();
            PopulateAdjustmentTable();
            var person = CurrentEmployee();
            var time = person.TimeDetails;
            var status = (person.Status == "Verified") ? "(Verified) " : "";

            lblEmployeeInformation.Text = $"{status}{person.EmployeeID} | {Utilities.StringFormat.ToSentenceCase(person.FullName)} | {Utilities.StringFormat.ToSentenceCase(person.Position)} | {person.Location}";
            txtTotalRegularHours.Text = time.RegularHours.TotalHours.ToString();
            txtRegularInDays.Text = (time.RegularHours.TotalHours / 8).ToString();
            txtUndertime.Text = time.UnderTime.TotalMinutes.ToString();
            txtLegalHolidayDays_100.Text = (time.LegalHoliday_100.TotalHours / 8).ToString();
            txtLegalHolidayHours_100.Text = time.LegalHoliday_100.TotalHours.ToString();

            txtTotalHours.Text = GetTotalHours(((time.RegularHours - time.UnderTime) + time.LegalHoliday_100));

            txtRegular_125.Text = GetTotalHours(time.RegOT_125);
            txtRestDaySpecialHoliday_130.Text = GetTotalHours(time.RestDayAndSpecialOT_130);
            txtRestDay_150.Text = GetTotalHours(time.RestDayOT_150);
            txtRestDayExcess_169.Text = GetTotalHours(time.RestDayOTExcess_169);
            txtSpecialHolidayExcess_195.Text = GetTotalHours(time.SpecialExcessOT_195);
            txtLegalHoliday_200.Text = GetTotalHours(time.LegalHolidayOT_200);
            txtRegularHoliday_160.Text = GetTotalHours(time.RegularHoliday_160);

            txtNight_10.Text = GetTotalHours(time.NightDiff_10);
            txtNight_20.Text = GetTotalHours(time.NightDiff_20);
            txtNight_50.Text = GetTotalHours(time.NightDiff_50);
            txtNight_125.Text = GetTotalHours(time.NightDiff_125);
            txtNight_130.Text = GetTotalHours(time.NightDiff_130);
            txtNight_150.Text = GetTotalHours(time.NightDiff_150);

            txtTimekeepRemarks.Text = person.InitialRemarks;

            btnVerify.Text = (person?.Status == "Verified") ? "Unverify" : "Verify";
        }

        private void PopulateAdjustmentTable()
        {
            var adjustmentList = CurrentEmployee()?.Adjustments?.ToList() ?? new List<EntryAdjustments>();
            dgvAdjustments.Columns.Clear();
            dgvAdjustments.AutoGenerateColumns = false;
            ApplySettingsToTable();
            dgvAdjustments.DataSource = adjustmentList;
        }

        private void ApplySettingsToTable()
        {
            ControlUtils.AddColumn(dgvAdjustments, "ID", "", "ID");
            ControlUtils.AddColumn(dgvAdjustments, "Type", "Type", "Type");
            ControlUtils.AddColumn(dgvAdjustments, "Operation", "Operation", "Operation");
            ControlUtils.AddColumn(dgvAdjustments, "RawInputValue", "Input", "RawInputValue");
            ControlUtils.AddColumn(dgvAdjustments, "RawOriginalValue", "From", "RawOriginalValue");
            ControlUtils.AddColumn(dgvAdjustments, "RawNewAdjustedValue", "To", "RawNewAdjustedValue");
            ControlUtils.AddColumn(dgvAdjustments, "Units", "Unit", "Units");
            ControlUtils.AddColumn(dgvAdjustments, "AppliedDate", "Date", "AppliedDate");
        }

        private void UpdateCounter()
        {
            lblEntryCounter.Text = $"{GetCurrentIndex() + 1} out of {GetTotalOfEntriesByDepartment()} employees under \"{CurrentDepartment}\" department.";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (GetCurrentIndex() != GetTotalOfEntriesByDepartment() - 1)
            {
                EmployeeIndexByDepartment[CurrentDepartment]++;
                RefreshData();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (GetCurrentIndex() != 0)
            {
                EmployeeIndexByDepartment[CurrentDepartment]--;
                RefreshData();
            }
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EntriesByDepartment.Count > 0)
            {
                UpdateCurrentDepartment();
                RefreshData();
            }
        }

        private void Label_Click(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                int index = (int)label.Tag;
                EmployeeIndexByDepartment[CurrentDepartment] = index;
                txtSearch.Text = String.Empty;
                RefreshData();
            }
        }

        private void Label_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                label.Font = new Font(label.Font, FontStyle.Underline);
            }
        }

        private void Label_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                label.Font = new Font(label.Font, FontStyle.Regular);
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RefreshData();
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            CurrentEmployee().CustomRemarks = txtCustomRemarks.Text;

            CombinedEntries = EntriesByDepartment.Values.SelectMany(listOfEntries => listOfEntries).OrderBy(ob => ob.FullName).ToList();

            if (await Task.Run(() => BillingService.UpdateJSONData(CombinedEntries, BillingName)))
            {
                MessageBox.Show("You have successfully saved your progress.", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ChangesAreSaved = true;
            }

            Cursor = Cursors.Default;
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            var person = EntriesByDepartment[CurrentDepartment][GetCurrentIndex()];
            person.Status = (btnVerify.Text == "Verify") ? "Verified" : "Unverified";
            ChangesAreSaved = false;
            RefreshData();
        }

        private void EmployeeTimekeepReviewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (!ChangesAreSaved && !ExitConfirmationUtil.CloseProgress())
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnAddAdjustment_Click(object sender, EventArgs e)
        {
            using AddAdjustmentForm adjustmentForm = new()
            {
                ParentConrol = this,
                CurrentEmployee = CurrentEmployee(),
                AdjustmentListCount = dgvAdjustments.RowCount + 1
            };

            if (adjustmentForm.ShowDialog() == DialogResult.OK)
            {
                var adjustmentList = CurrentEmployee()?.Adjustments?.ToList() ?? new List<EntryAdjustments>();
                adjustmentList.Add(adjustmentForm.Adjustment);
                CurrentEmployee().Adjustments = adjustmentList.ToArray();

                ApplyNewValueToTimeRecord(adjustmentForm.Adjustment.Type, adjustmentForm.Adjustment.NewAdjustedValue);

                ChangesAreSaved = false;
                RefreshData();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvAdjustments.SelectedRows.Count > 0)
            {
                int currentAdjustmentID = Convert.ToInt32(dgvAdjustments.SelectedRows[0].Cells[0].Value);
                var adjustmentList = CurrentEmployee()?.Adjustments?.ToList();
                var entryToRemove = adjustmentList.First(f => f.ID == currentAdjustmentID);

                ApplyNewValueToTimeRecord(entryToRemove.Type, entryToRemove.OriginalValue);

                adjustmentList.Remove(entryToRemove);
                CurrentEmployee().Adjustments = adjustmentList.ToArray();

                ChangesAreSaved = false;
                RefreshData();
            }
        }

        private void ApplyNewValueToTimeRecord(string type, TimeSpan newValue)
        {
            switch (type)
            {
                case "Regular Days":
                    CurrentEmployee().TimeDetails.RegularHours = newValue;
                    break;

                case "Undertime":
                    CurrentEmployee().TimeDetails.UnderTime = newValue;
                    break;

                case "Legal Holiday 100%":
                    CurrentEmployee().TimeDetails.LegalHoliday_100 = newValue;
                    break;

                case "Regular Overtime 125%":
                    CurrentEmployee().TimeDetails.RegOT_125 = newValue;
                    break;

                case "Regular Holiday 160%":
                    CurrentEmployee().TimeDetails.RegularHoliday_160 = newValue;
                    break;

                case "Rest Day and Special Overtime 130%":
                    CurrentEmployee().TimeDetails.RestDayAndSpecialOT_130 = newValue;
                    break;

                case "Rest Day Overtime 150%":
                    CurrentEmployee().TimeDetails.RestDayOT_150 = newValue;
                    break;

                case "Rest Day Overtime Excess 169%":
                    CurrentEmployee().TimeDetails.RestDayOTExcess_169 = newValue;
                    break;

                case "Special Excess Overtime 195%":
                    CurrentEmployee().TimeDetails.SpecialExcessOT_195 = newValue;
                    break;

                case "Legal Holiday Overtime 200%":
                    CurrentEmployee().TimeDetails.LegalHoliday_100 = newValue;
                    break;

                case "Legal Holiday Overtime 260%":
                    CurrentEmployee().TimeDetails.LegalHolidayOT_260 = newValue;
                    break;

                case "Night Differential 10%":
                    CurrentEmployee().TimeDetails.NightDiff_10 = newValue;
                    break;

                case "Night Differential 20%":
                    CurrentEmployee().TimeDetails.NightDiff_20 = newValue;
                    break;

                case "Night Differential 50%":
                    CurrentEmployee().TimeDetails.NightDiff_50 = newValue;
                    break;

                case "Night Differential 125%":
                    CurrentEmployee().TimeDetails.NightDiff_125 = newValue;
                    break;

                case "Night Differential 130%":
                    CurrentEmployee().TimeDetails.NightDiff_130 = newValue;
                    break;

                case "Night Differential 150%":
                    CurrentEmployee().TimeDetails.NightDiff_150 = newValue;
                    break;
            }
        }

        private void btnClearRemarks_Click(object sender, EventArgs e)
        {
            txtCustomRemarks.Text = "";
        }
    }
}
