using LBPRDC.Source.Config;
using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;

namespace LBPRDC.Source.Views.Billing
{
    public partial class EmployeeTimekeepReviewForm : Form
    {
        public BillingControl? ParentControl { get; set; }
        public int BillingID { get; set; }
        public int ClientID { get; set; }

        public List<Entry> ConstantEntries = new();
        public List<Entry> EditableEntries = new();
        public string BillingName = "";
        public string DateQuarter = "";
        public string DateCoverage = "";

        public string LockStatus = "";

        private Dictionary<string, int> CurrentIndexByDepartment = new();
        private Dictionary<string, List<Entry>> GroupedEntriesByDepartment = new();

        private string CurrentDepartment = "";
        private bool ChangesAreSaved = true;

        private void GroupEntriesByDepartment() => GroupedEntriesByDepartment = EditableEntries.GroupBy(gp => gp.Department).ToDictionary(group => group.Key, group => group.OrderBy(ob => ob.FullName).ToList());
        private Entry CurrentEmployee() => GroupedEntriesByDepartment[CurrentDepartment][GetCurrentIndex()];
        private void UpdateCurrentDepartment() => CurrentDepartment = cmbDepartment.Text;
        private int GetCurrentIndex() => CurrentIndexByDepartment[CurrentDepartment];
        private int GetTotalOfEntriesByDepartment() => GroupedEntriesByDepartment[CurrentDepartment].Count;
        private static string GetTotalHours(TimeSpan time) => time == TimeSpan.Zero ? "" : $"{(int)time.TotalHours:D2}:{time.Minutes:D2}";
        private static string ConvertToHoursMinutes(TimeSpan time) => $"{(int)time.TotalHours:D2}:{time.Minutes:D2}";
        private async void SaveProgress() => await Task.Run(() => BillingService.UpdateEditableJSON(EditableEntries, BillingName));

        private EntryTimeDetails CustomEntryOriginalTime()
        {
            return new EntryTimeDetails
            {
                RegularHours = TimeSpan.Zero,
                LegalHoliday_100 = TimeSpan.Zero,
                RegOT_125 = TimeSpan.Zero,
                RestDaySpecialOT_130 = TimeSpan.Zero,
                RestDaySpecialOTExcess_169 = TimeSpan.Zero,
                SpecialExcessOT_195 = TimeSpan.Zero,
                LegalHolidayOT_200 = TimeSpan.Zero,
                LegalHolidayOT_260 = TimeSpan.Zero,
                RestDaySpecialOT_150 = TimeSpan.Zero,
                RegularHoliday_160 = TimeSpan.Zero,
                NightDiff_10 = TimeSpan.Zero,
                NightDiff_125 = TimeSpan.Zero,
                NightDiff_130 = TimeSpan.Zero,
                NightDiff_150 = TimeSpan.Zero,
                NightDiff_20 = TimeSpan.Zero,
                NightDiff_50 = TimeSpan.Zero,
                UnderTime = TimeSpan.Zero,
                Absent = TimeSpan.Zero,
            };
        }

        public EmployeeTimekeepReviewForm()
        {
            InitializeComponent();
        }

        private void EmployeeTimekeepReviewForm_Load(object sender, EventArgs e)
        {
            if (BillingID == 0 && ClientID == 0)
            {
                MessageBox.Show(MessagesConstants.Error.MISSING_CLIENT_BILLING, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            this.Text = $"{BillingName}";

            SetButtonsState(LockStatus == "Unlock");
            GetLatestEmployeeInformation();
            InitializeDepartmentComboBoxItems();
            GroupEntriesByDepartment();
            RefreshDisplayInformation();
        }

        private void SetButtonsState(bool state)
        {
            btnInsertEntry.Enabled = state;
            btnRemoveEntry.Enabled = state;
            btnAddAdjustment.Enabled = state;
            btnRemove.Enabled = state;
            grpRemarks.Enabled = state;
            btnVerify.Enabled = state;
            btnSave.Enabled = state;
            btnVerifyBilling.Enabled = state;
            grpExport.Enabled = state;
        }

        private async void GetLatestEmployeeInformation()
        {
            //var employees = await EmployeeService.GetAllEmployeesBase();
            var employeeList = await EmployeeService.GetEmployees(ClientID);
            var positions = await PositionService.GetAllItems();
            foreach (var entry in EditableEntries)
            {
                var emp = employeeList.FirstOrDefault(f => f.EmployeeID == entry.EmployeeID);
                string? position = positions.FirstOrDefault(f => f.ID == entry.PositionID)?.Name;
                if (emp != null)
                {
                    entry.Department = emp.DepartmentName;
                    entry.DepartmentID = emp.DepartmentID;
                    entry.Position = position ?? entry.Position;
                    entry.Location = emp.LocationName;
                    entry.FullName = $"{emp.LastName}, {emp.FirstName} {emp.MiddleName[..1]}.";
                }
                else
                {
                    entry.Position = position ?? entry.Position;
                    entry.FullName = $"{entry.LastName}, {entry.FirstName} {entry.MiddleName[..1]}.";
                }
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

        private async void DisplayEmployeeList()
        {
            flowLeftEmployeeList.Controls.Clear();

            List<Control> labelList = new();
            int index = 0;
            var Positions = await PositionService.GetAllItems();

            foreach (var employee in GroupedEntriesByDepartment[CurrentDepartment])
            {
                string statusSIL = "";
                string position = "";
                string status = (employee.VerificationStatus == "Verified") ? "✔" : "•";
                var adjustmentList = employee?.Adjustments?.ToList() ?? new List<EntryAdjustments>();

                if (adjustmentList != null)
                {
                    var adjustmentWithSIL = adjustmentList.Where(w => w.Remarks.Contains("[SIL]")).ToList();
                    statusSIL = (adjustmentWithSIL.Count > 0) ? " SIL |" : "";
                }

                var employeeCount = GroupedEntriesByDepartment[CurrentDepartment].Where(w => w.EmployeeID == employee.EmployeeID).ToList().Count;
                if (employeeCount > 1)
                {
                    position = $" | {Positions.First(f => f.ID == employee.PositionID).Code}";
                }

                Label label = new()
                {
                    Text = $"{status}{statusSIL} {employee.EmployeeID} | {Utilities.StringFormat.ToSentenceCase(employee.FullName)}{position}",
                    AutoSize = true,
                    MaximumSize = new Size(260, 50),
                    Padding = new Padding(0, 0, 0, 12),
                    Cursor = Cursors.Hand,
                    Font = new Font("Arial", 11, FontStyle.Regular),
                    ForeColor = (GetCurrentIndex() == index) ? Color.DarkGreen : (string.IsNullOrEmpty(employee.BookmarkRemarks) ? Color.Black : Color.Red),
                    Tag = index,
                    AccessibleName = $"{employee.EmployeeID} {employee.FullName}",
                    AccessibleDescription = statusSIL,
                };

                label.Click += EmployeeListLabel_Click;
                label.MouseEnter += EmployeeListLabel_MouseEnter;
                label.MouseLeave += EmployeeListLabel;
                labelList.Add(label);
                index++;
            }

            labelList = labelList.Where(w =>
                    w.AccessibleName.ToLower().Contains(txtSearch.Text) ||
                    w.AccessibleDescription.ToLower().Contains(txtSearch.Text)
                ).ToList();

            flowLeftEmployeeList.Controls.AddRange(labelList.ToArray());

            int selectedIndex = GetCurrentIndex();
            if (selectedIndex >= 0 && selectedIndex < labelList.Count)
            {
                Control selectedLabel = labelList[selectedIndex];
                int scrollPosition = selectedLabel.Top - flowLeftEmployeeList.AutoScrollPosition.Y;
                pnlLeftBody.AutoScrollPosition = new Point(0, scrollPosition);
            }
        }

        private void DisplayEmployeeInformation()
        {
            PopulateAdjustmentTable();
            PopulateAdjustmentSummary();

            var person = CurrentEmployee();
            var time = person.TimeDetails;
            string status = (person.VerificationStatus == "Verified") ? "(Verified) " : "";
            btnRemoveEntry.Enabled = (person.EntryType == StringConstants.Type.CUSTOM);

            lblEmployeeInformation.Text = $"{status}{person.EmployeeID} | {Utilities.StringFormat.ToSentenceCase(person.FullName)} | {Utilities.StringFormat.ToSentenceCase(person.Position)} | Location: {person.Location} | Rate: {person.DailyBillingRate.ToString("C2").Replace("$", "₱")}";

            txtRegularInDays.Text = (time.RegularHours.TotalHours / 8).ToString();
            txtTotalRegularHours.Text = time.RegularHours.TotalHours.ToString();
            txtUndertime.Text = time.UnderTime.TotalMinutes.ToString();
            txtLegalHolidayDays_100.Text = (time.LegalHoliday_100.TotalHours / 8).ToString();
            txtLegalHolidayHours_100.Text = time.LegalHoliday_100.TotalHours.ToString();
            txtRenderedRegularHours.Text = GetTotalHours((time.RegularHours - time.UnderTime) + time.LegalHoliday_100);

            txtRegular_125.Text = GetTotalHours(time.RegOT_125);
            txtRestDaySpecialHoliday_130.Text = GetTotalHours(time.RestDaySpecialOT_130);
            txtRestDay_150.Text = GetTotalHours(time.RestDaySpecialOT_150);
            txtRestDayExcess_169.Text = GetTotalHours(time.RestDaySpecialOTExcess_169);
            txtSpecialHolidayExcess_195.Text = GetTotalHours(time.SpecialExcessOT_195);
            txtLegalHoliday_200.Text = GetTotalHours(time.LegalHolidayOT_200);
            txtLegalHoliday_260.Text = GetTotalHours(time.LegalHolidayOT_260);
            txtRegularHoliday_160.Text = GetTotalHours(time.RegularHoliday_160);
            TimeSpan totalOvertime = time.RegOT_125 + time.RestDaySpecialOT_130 + time.RestDaySpecialOT_150 + time.RestDaySpecialOTExcess_169 + time.SpecialExcessOT_195 + time.LegalHolidayOT_200 + time.LegalHolidayOT_260 + time.RegularHoliday_160;
            txtRenderedOvertimeHours.Text = GetTotalHours(totalOvertime);

            txtNight_10.Text = GetTotalHours(time.NightDiff_10);
            txtNight_20.Text = GetTotalHours(time.NightDiff_20);
            txtNight_50.Text = GetTotalHours(time.NightDiff_50);
            txtNight_125.Text = GetTotalHours(time.NightDiff_125);
            txtNight_130.Text = GetTotalHours(time.NightDiff_130);
            txtNight_150.Text = GetTotalHours(time.NightDiff_150);

            txtTimekeepRemarks.Text = person.TimekeepRemarks;
            txtCustomRemarks.Text = person.FinalReportRemarks;
            txtBookmarkReason.Text = person.BookmarkRemarks;

            radYesExport.Checked = person.ExportIncluded;
            radNoExport.Checked = !person.ExportIncluded;

            btnVerify.Text = (person?.VerificationStatus == "Verified") ? "✘ Unverify" : "✔ Verify";
            lblEntryCounter.Text = $"{GetCurrentIndex() + 1} out of {GetTotalOfEntriesByDepartment()} employees under \"{CurrentDepartment}\" department.";
        }

        private void PopulateAdjustmentTable()
        {
            var adjustmentList = CurrentEmployee()?.Adjustments?.ToList() ?? new List<EntryAdjustments>();
            dgvAdjustments.Columns.Clear();
            dgvAdjustments.AutoGenerateColumns = false;
            GetColumnsForAdjustmentTable();
            dgvAdjustments.DataSource = adjustmentList;
        }

        private void GetColumnsForAdjustmentTable()
        {
            ControlUtils.AddColumn(dgvAdjustments, "ID", "", "ID", true, true);
            ControlUtils.AddColumn(dgvAdjustments, "Type", "Type", "Type", true, true);
            ControlUtils.AddColumn(dgvAdjustments, "InputValue", "Input", "InputValue", true, true);
            ControlUtils.AddColumn(dgvAdjustments, "Units", "Unit", "Units", true, true);
            ControlUtils.AddColumn(dgvAdjustments, "AppliedDate", "Date", "AppliedDate", true, true);
            ControlUtils.AddColumn(dgvAdjustments, "Remarks", "Remarks", "Remarks", true, true);
        }

        private void PopulateAdjustmentSummary()
        {
            List<AdjustmentSummary> summaryList = new();

            if (dgvAdjustments.Rows.Count > 0)
            {
                try
                {
                    foreach (DataGridViewRow row in dgvAdjustments.Rows)
                    {
                        string type = (string)row.Cells["Type"].Value;
                        string inputValue = (string)row.Cells["InputValue"].Value;
                        string units = (string)row.Cells["Units"].Value;
                        string date = (string)row.Cells["AppliedDate"].Value;
                        string remark = (string)row.Cells["Remarks"].Value;

                        var summary = summaryList.FirstOrDefault(s => s.Type == type);

                        if (summary == null)
                        {
                            EntryTimeDetails originalValues = new();
                            if (CurrentEmployee().EntryType == StringConstants.Type.REGULAR)
                            {
                                originalValues = ConstantEntries.First(f => f.Guid == CurrentEmployee().Guid).TimeDetails;
                            }
                            else if (CurrentEmployee().EntryType == StringConstants.Type.CUSTOM)
                            {
                                originalValues = CustomEntryOriginalTime();
                            }

                            if (originalValues == null) continue;

                            string originalValue = type switch
                            {
                                "Regular Days" => (originalValues.RegularHours.TotalHours / 8).ToString(),
                                "Undertime" => (originalValues.UnderTime.TotalMinutes).ToString(),
                                "Legal Holiday 100%" => ConvertToHoursMinutes(originalValues.LegalHoliday_100).ToString(),
                                "Regular Overtime 125%" => ConvertToHoursMinutes(originalValues.RegOT_125).ToString(),
                                "Regular Holiday 160%" => ConvertToHoursMinutes(originalValues.RegularHoliday_160).ToString(),
                                "Rest Day/Special Holiday 130%" => ConvertToHoursMinutes(originalValues.RestDaySpecialOT_130).ToString(),
                                "Rest Day Special Holiday 150%" => ConvertToHoursMinutes(originalValues.RestDaySpecialOT_150).ToString(),
                                "Rest Day/Special Holiday Excess 169%" => ConvertToHoursMinutes(originalValues.RestDaySpecialOTExcess_169).ToString(),
                                "Special Holiday Excess Overtime 195%" => ConvertToHoursMinutes(originalValues.SpecialExcessOT_195).ToString(),
                                "Legal Holiday Overtime 200%" => ConvertToHoursMinutes(originalValues.LegalHolidayOT_200).ToString(),
                                "Legal Holiday Overtime 260%" => ConvertToHoursMinutes(originalValues.LegalHolidayOT_260).ToString(),
                                "Night Differential 10%" => ConvertToHoursMinutes(originalValues.NightDiff_10).ToString(),
                                "Night Differential 20%" => ConvertToHoursMinutes(originalValues.NightDiff_20).ToString(),
                                "Night Differential 50%" => ConvertToHoursMinutes(originalValues.NightDiff_50).ToString(),
                                "Night Differential 125%" => ConvertToHoursMinutes(originalValues.NightDiff_125).ToString(),
                                "Night Differential 130%" => ConvertToHoursMinutes(originalValues.NightDiff_130).ToString(),
                                "Night Differential 150%" => ConvertToHoursMinutes(originalValues.NightDiff_150).ToString(),
                                _ => TimeSpan.Zero.ToString(),
                            };

                            if (units == "day(s)" || units == "minute(s)")
                            {
                                int newValue = Convert.ToInt32(originalValue) + Convert.ToInt32(inputValue);
                                summaryList.Add(new AdjustmentSummary
                                {
                                    Type = type,
                                    OriginalValue = originalValue,
                                    InputValueTotal = inputValue,
                                    NewValue = newValue.ToString(),
                                    Units = units
                                });
                                UpdateTimeDetailByType(type, TimeFormat.ToTimeSpan(units, newValue), false);
                            }
                            else if (units == "hour(s):minute(s)")
                            {
                                TimeSpan newValue = TimeFormat.ParseTimeString(originalValue).Add(TimeFormat.ParseTimeString(inputValue));
                                summaryList.Add(new AdjustmentSummary
                                {
                                    Type = type,
                                    OriginalValue = originalValue,
                                    InputValueTotal = inputValue,
                                    NewValue = ConvertToHoursMinutes(newValue),
                                    Units = units
                                });
                                UpdateTimeDetailByType(type, newValue, false);
                            }
                        }
                        else
                        {
                            if (summary.Units == "day(s)" || summary.Units == "minute(s)")
                            {
                                int total = Convert.ToInt32(summary.InputValueTotal) + Convert.ToInt32(inputValue);
                                summary.InputValueTotal = (total > 0) ? $"+{total}" : total.ToString();
                                int newTotalValue = Convert.ToInt32(summary.OriginalValue) + Convert.ToInt32(summary.InputValueTotal);
                                summary.NewValue = (newTotalValue).ToString();
                                UpdateTimeDetailByType(type, TimeFormat.ToTimeSpan(units, newTotalValue), false);
                            }
                            else if (summary.Units == "hour(s):minute(s)")
                            {
                                TimeSpan total = TimeFormat.ParseTimeString(summary.InputValueTotal).Add(TimeFormat.ParseTimeString(inputValue));
                                summary.InputValueTotal = (total > TimeSpan.Zero) ? $"+{ConvertToHoursMinutes(total)}" : ConvertToHoursMinutes(total);
                                TimeSpan newTotalValue = TimeFormat.ParseTimeString(summary.OriginalValue).Add(TimeFormat.ParseTimeString(summary.InputValueTotal));
                                summary.NewValue = newTotalValue.ToString();
                                UpdateTimeDetailByType(type, newTotalValue, false);
                            }
                        }
                    }
                }
                catch (Exception ex) { ExceptionHandler.HandleException(ex); }
            }

            dgvAdjustmentSummary.Columns.Clear();
            dgvAdjustmentSummary.AutoGenerateColumns = false;
            GetColumnsForAdjustmentummaryTable();
            dgvAdjustmentSummary.DataSource = summaryList;

            GetAdjustmentRemarks();
        }

        private void GetColumnsForAdjustmentummaryTable()
        {
            ControlUtils.AddColumn(dgvAdjustmentSummary, "Type", "Type", "Type", true, true);
            ControlUtils.AddColumn(dgvAdjustmentSummary, "OriginalValue", "Original", "OriginalValue", true, true);
            ControlUtils.AddColumn(dgvAdjustmentSummary, "InputValueTotal", "Input", "InputValueTotal", true, true);
            ControlUtils.AddColumn(dgvAdjustmentSummary, "NewValue", "Output", "NewValue", true, true);
            ControlUtils.AddColumn(dgvAdjustmentSummary, "Units", "Unit", "Units", true, true);
        }

        private void ClearAdjustmentRemarks() => CurrentEmployee().AdjustmentRemarks = Array.Empty<AdjustmentRemarks>();

        private void GetAdjustmentRemarks()
        {
            List<AdjustmentRemarks> remarksList = new();
            ClearAdjustmentRemarks();
            if (dgvAdjustmentSummary.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvAdjustmentSummary.Rows)
                {
                    string timeType = (string)row.Cells["Type"].Value;
                    string addend = (string)row.Cells["InputValueTotal"].Value;
                    string prefix = (addend[..1] == "+") ? "ADD" : "LESS";
                    string unit = (string)row.Cells["Units"].Value switch
                    {
                        "day(s)" => "day(s)",
                        "minute(s)" => "min(s)",
                        "hour(s):minute(s)" => "",
                        _ => ""
                    };

                    List<string> details = new();
                    foreach (var adjustment in CurrentEmployee().Adjustments.ToList().Where(f => f.Type == timeType))
                    {
                        string detail = $"[{adjustment.InputValue} in {adjustment.AppliedDate}]";
                        if (!string.IsNullOrEmpty(adjustment.Remarks) || !string.IsNullOrWhiteSpace(adjustment.Remarks))
                        {
                            detail += "-" + adjustment.Remarks.Trim();
                        }
                        details.Add(detail);
                    }

                    string type = "", typeCode = "";
                    Dictionary<string, (string, string)> typeMappings = new()
                    {
                        { "Regular Days", ("regular", "REG") },
                        { "Undertime", ("regular", "UT") },
                        { "Legal Holiday 100%", ("regular", "LH 100%") },
                        { "Regular Overtime 125%", ("overtime", "REG OT 125%") },
                        { "Regular Holiday 160%", ("overtime", "RHOT 160%") },
                        { "Rest Day/Special Holiday 130%", ("overtime", "RDOT/SHOT 130%") },
                        { "Rest Day Special Holiday 150%", ("overtime", "RDOT 150%") },
                        { "Rest Day/Special Holiday Excess 169%", ("overtime", "RDOT Excess 169%") },
                        { "Special Holiday Excess Overtime 195%", ("overtime", "SHOT Excess") },
                        { "Legal Holiday Overtime 200%", ("overtime", "LHOT 200%") },
                        { "Legal Holiday Overtime 260%", ("overtime", "LHOT 260%") },
                        { "Night Differential 10%", ("overtime", "NDOT 10%") },
                        { "Night Differential 20%", ("overtime", "NDOT 20%") },
                        { "Night Differential 50%", ("overtime", "NDOT 50%") },
                        { "Night Differential 125%", ("overtime", "NDOT 125%") },
                        { "Night Differential 130%", ("overtime", "NDOT 130%") },
                        { "Night Differential 150%", ("overtime", "NDOT 150%") }
                    };

                    if (typeMappings.ContainsKey(timeType))
                    {
                        (type, typeCode) = typeMappings[timeType];
                    }
                    else
                    {
                        MessageBox.Show("This adjustment is not added to the export file. Error Code: ETRF-0001", "Error Adjustment for Export", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (type == "" || typeCode == "")
                    {
                        MessageBox.Show("This adjustment is not added to the export file. Error Code: ETRF-0002", "Error Adjustment for Export", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string total = (addend.Length > 1) ? addend[1..] : addend;

                    remarksList.Add(new AdjustmentRemarks
                    {
                        Type = type,
                        TimeType = timeType,
                        Value = $"({prefix} \"{typeCode}\" {total} {unit} {string.Join(", ", details.ToArray())})"
                    });
                }
            }

            CurrentEmployee().AdjustmentRemarks = remarksList.ToArray();
        }

        private void UpdateTimeDetailByType(string type, TimeSpan newValue, bool reset)
        {
            EntryTimeDetails originalTime = new();
            if (CurrentEmployee().EntryType == StringConstants.Type.REGULAR)
            {
                originalTime = ConstantEntries.First(f => f.Guid == CurrentEmployee().Guid).TimeDetails;
            }
            else if (CurrentEmployee().EntryType == StringConstants.Type.CUSTOM)
            {
                originalTime = CustomEntryOriginalTime();
            }
            switch (type)
            {
                case "Regular Days":
                    CurrentEmployee().TimeDetails.RegularHours = (reset) ? originalTime.RegularHours : newValue;
                    break;

                case "Undertime":
                    CurrentEmployee().TimeDetails.UnderTime = (reset) ? originalTime.UnderTime : newValue;
                    break;

                case "Legal Holiday 100%":
                    CurrentEmployee().TimeDetails.LegalHoliday_100 = (reset) ? originalTime.LegalHoliday_100 : newValue;
                    break;

                case "Regular Overtime 125%":
                    CurrentEmployee().TimeDetails.RegOT_125 = (reset) ? originalTime.RegOT_125 : newValue;
                    break;

                case "Regular Holiday 160%":
                    CurrentEmployee().TimeDetails.RegularHoliday_160 = (reset) ? originalTime.RegularHoliday_160 : newValue;
                    break;

                case "Rest Day/Special Holiday 130%":
                    CurrentEmployee().TimeDetails.RestDaySpecialOT_130 = (reset) ? originalTime.RestDaySpecialOT_130 : newValue;
                    break;

                case "Rest Day Special Holiday 150%":
                    CurrentEmployee().TimeDetails.RestDaySpecialOT_150 = (reset) ? originalTime.RestDaySpecialOT_150 : newValue;
                    break;

                case "Rest Day/Special Holiday Excess 169%":
                    CurrentEmployee().TimeDetails.RestDaySpecialOTExcess_169 = (reset) ? originalTime.RestDaySpecialOTExcess_169 : newValue;
                    break;

                case "Special Holiday Excess Overtime 195%":
                    CurrentEmployee().TimeDetails.SpecialExcessOT_195 = (reset) ? originalTime.SpecialExcessOT_195 : newValue;
                    break;

                case "Legal Holiday Overtime 200%":
                    CurrentEmployee().TimeDetails.LegalHolidayOT_200 = (reset) ? originalTime.LegalHoliday_100 : newValue;
                    break;

                case "Legal Holiday Overtime 260%":
                    CurrentEmployee().TimeDetails.LegalHolidayOT_260 = (reset) ? originalTime.LegalHolidayOT_260 : newValue;
                    break;

                case "Night Differential 10%":
                    CurrentEmployee().TimeDetails.NightDiff_10 = (reset) ? originalTime.NightDiff_10 : newValue;
                    break;

                case "Night Differential 20%":
                    CurrentEmployee().TimeDetails.NightDiff_20 = (reset) ? originalTime.NightDiff_20 : newValue;
                    break;

                case "Night Differential 50%":
                    CurrentEmployee().TimeDetails.NightDiff_50 = (reset) ? originalTime.NightDiff_50 : newValue;
                    break;

                case "Night Differential 125%":
                    CurrentEmployee().TimeDetails.NightDiff_125 = (reset) ? originalTime.NightDiff_125 : newValue;
                    break;

                case "Night Differential 130%":
                    CurrentEmployee().TimeDetails.NightDiff_130 = (reset) ? originalTime.NightDiff_130 : newValue;
                    break;

                case "Night Differential 150%":
                    CurrentEmployee().TimeDetails.NightDiff_150 = (reset) ? originalTime.NightDiff_150 : newValue;
                    break;

                default:
                    MessageBox.Show($"Error updating the time detail of current employee.\nEntered type: {type}\nEntered value: {newValue}\nError Code: ETRF-0003", "Time Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void RefreshDisplayInformation()
        {
            DisplayEmployeeList();
            DisplayEmployeeInformation();
        }

        // PAGINATION BUTTONS
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (GetCurrentIndex() != GetTotalOfEntriesByDepartment() - 1)
            {
                CurrentIndexByDepartment[CurrentDepartment]++;
                RefreshDisplayInformation();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (GetCurrentIndex() != 0)
            {
                CurrentIndexByDepartment[CurrentDepartment]--;
                RefreshDisplayInformation();
            }
        }

        // EMPLOYEE LIST CONTROLS
        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GroupedEntriesByDepartment.Count > 0)
            {
                UpdateCurrentDepartment();
                RefreshDisplayInformation();
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DisplayEmployeeList();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DisplayEmployeeList();
        }

        private void btnInsertEntry_Click(object sender, EventArgs e)
        {
            InsertCustomEntryForm form = new()
            {
                ClientID = ClientID,
                BillingName = BillingName,
                EditableEntries = EditableEntries
            };
            if (form.ShowDialog() == DialogResult.OK)
            {
                EditableEntries = form.EditableEntries;
                ChangesInBilling(true);
                InitializeDepartmentComboBoxItems();
                GroupEntriesByDepartment();
                DisplayEmployeeInformation();
                //RefreshDisplayInformation();
            }
        }

        List<Guid> removedEntries = new();
        private void btnRemoveEntry_Click(object sender, EventArgs e)
        {
            var output = MessageBox.Show("Are you sure you want to remove this custom entry?", "Remove Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (output == DialogResult.Yes)
            {
                var entryToRemove = EditableEntries.First(w => w.Guid == CurrentEmployee().Guid);
                removedEntries.Add(entryToRemove.Guid);
                EditableEntries.Remove(entryToRemove);
                ChangesInBilling(true);
                InitializeDepartmentComboBoxItems();
                GroupEntriesByDepartment();
                DisplayEmployeeInformation();
                //RefreshDisplayInformation();
            }
        }

        // BUTTONS WITH ACTIONS
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (removedEntries.Any())
            {
                bool result = await BillingRecordService.RemoveRecordsByGuid(removedEntries, BillingID);

                if (result)
                {
                    removedEntries.Clear();
                }
            }

            SaveProgress();
            ChangesInBilling(false);
            if (await Task.Run(() => BillingService.UpdateVerificationStatus(BillingID, StringConstants.Status.UNVERIFIED)))
            {
                ParentControl?.ApplySearchThenPopulate();
            }

        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            CurrentEmployee().VerificationStatus = (btnVerify.Text == "✔ Verify") ? "Verified" : StringConstants.Status.UNVERIFIED;
            ChangesInBilling(true);
            if (btnVerify.Text == "Verify")
            {
                btnNext.PerformClick();
            }
            RefreshDisplayInformation();
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
                ChangesInBilling(true);
                RefreshDisplayInformation();
            }
        }

        private void btnRemoveAdjustment_Click(object sender, EventArgs e)
        {
            if (dgvAdjustments.SelectedRows.Count > 0)
            {
                int currentAdjustmentID = Convert.ToInt32(dgvAdjustments.SelectedRows[0].Cells[0].Value);
                string currentType = (string)dgvAdjustments.SelectedRows[0].Cells[1].Value;
                var adjustmentList = CurrentEmployee()?.Adjustments?.ToList();

                int specificTypeCount = adjustmentList.Count(c => c.Type == currentType);
                if (specificTypeCount == 1)
                {
                    UpdateTimeDetailByType(currentType, TimeSpan.Zero, true);
                }

                var entryToRemove = adjustmentList.First(f => f.ID == currentAdjustmentID);
                adjustmentList.Remove(entryToRemove);
                CurrentEmployee().Adjustments = adjustmentList.ToArray();
                ChangesInBilling(true);
                RefreshDisplayInformation();
            }
        }

        // REMARKS BUTTON EVENTS
        private void btnClearRemarks_Click(object sender, EventArgs e)
        {
            txtCustomRemarks.Text = "";
        }

        private void btnApplyRemarks_Click(object sender, EventArgs e)
        {
            CurrentEmployee().FinalReportRemarks = txtCustomRemarks.Text;
            MessageBox.Show("Custom remarks are applied to this employee.", "Custom Remarks Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ChangesInBilling(true);
            DisplayEmployeeInformation();
        }

        private void btnClearBookmark_Click(object sender, EventArgs e)
        {
            txtBookmarkReason.Text = "";
        }

        private void btnApplyBookmark_Click(object sender, EventArgs e)
        {
            CurrentEmployee().BookmarkRemarks = txtBookmarkReason.Text;
            MessageBox.Show("Bookmark reasons are applied to this employee.", "Bookmark Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ChangesInBilling(true);
            DisplayEmployeeInformation();
        }

        // EMPLOYEE LIST LABELS EVENTS
        private void EmployeeListLabel_Click(object? sender, EventArgs e)
        {
            if (sender is Label label)
            {
                int index = (int)label.Tag;
                CurrentIndexByDepartment[CurrentDepartment] = index;
                txtSearch.Text = String.Empty;
                RefreshDisplayInformation();
            }
        }

        private void EmployeeListLabel_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is Label label) label.Font = new Font(label.Font, FontStyle.Underline);
        }

        private void EmployeeListLabel(object? sender, EventArgs e)
        {
            if (sender is Label label) label.Font = new Font(label.Font, FontStyle.Regular);
        }

        // OTHER EVENTS
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

        private async void btnVerifyBilling_Click(object sender, EventArgs e)
        {
            List<Entry> employeeList = new();
            foreach (var employee in EditableEntries)
            {
                if (employee.ExportIncluded && employee.VerificationStatus == StringConstants.Status.UNVERIFIED || !string.IsNullOrEmpty(employee.BookmarkRemarks) || (employee.Adjustments != null && employee.Adjustments.Any(a => a.Remarks.Contains("[SIL]"))))
                {
                    employeeList.Add(employee);
                }
                else if (!employee.ExportIncluded)
                {
                    removedEntries.Add(employee.Guid);
                }
            }

            if (employeeList.Count > 0)
            {
                SummaryView form = new()
                {
                    ParentControl = this,
                    Employees = employeeList,
                    BillingName = BillingName
                };

                if (form.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }

            var hasExportEmployees = EditableEntries.Any(a => a.ExportIncluded == true);

            if (!hasExportEmployees)
            {
                MessageBox.Show("You must include at least 1 employee in export in order to mark this billing as verified.", "Finish Billing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmLoading loadingForm = new()
            {
                BooleanProcess = Task.Run(() => ExcelService.ExportBilling(BillingID, ClientID, EditableEntries, BillingName, "", "Unreleased", removedEntries)),
                Description = "Generating a temporary billing record, please wait ..."
            };
            loadingForm.ShowDialog();

            if (loadingForm.DialogResult == DialogResult.OK)
            {
                SaveProgress();
                if (await Task.Run(() => BillingService.UpdateVerificationStatus(BillingID, "Verified")))
                {
                    MessageBox.Show($"You have successfully set the status of '{BillingName}' as verified.", "Verified Successfuly", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChangesInBilling(false);
                    this.Close();
                    ParentControl?.ApplySearchThenPopulate();
                }
            }
            else if (loadingForm.DialogResult == DialogResult.Abort)
            {
                MessageBox.Show($"There is a problem generating a temporary billing record; please try again. If the error persists, please save your progress and call for support.", MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void radYesExport_Click(object sender, EventArgs e)
        {
            if (radYesExport.Checked)
            {
                ChangesInBilling(true);
                CurrentEmployee().ExportIncluded = true;
            }
        }

        private void radNoExport_Click(object sender, EventArgs e)
        {
            if (radNoExport.Checked)
            {
                ChangesInBilling(true);
                CurrentEmployee().ExportIncluded = false;
            }
        }

        private void ChangesInBilling(bool state)
        {
            ChangesAreSaved = !state;
            if (!state)
            {
                this.Text = this.Text.Replace("(Modified)", "");
            }
            else
            {
                if (!this.Text.Contains("(Modified)"))
                {
                    this.Text += " (Modified)";
                }
            }
        }

        private void dgvAdjustments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
