using LBPRDC.Source.Config;
using LBPRDC.Source.Services;
using System.Globalization;

namespace LBPRDC.Source.Views.Billing
{
    public partial class AddAdjustmentForm : Form
    {
        public EmployeeTimekeepReviewForm? ParentConrol { get; set; }
        public EntryAdjustments Adjustment { get; private set; }
        public int AdjustmentListCount { get; set; }

        public Entry CurrentEmployee = new();
        public string InputFormat = "";
        public string SelectedDays = "";

        public AddAdjustmentForm()
        {
            InitializeComponent();
        }

        private void AddAdjustmentForm_Load(object sender, EventArgs e)
        {
            this.Text = $"Adjustment for {CurrentEmployee.EmployeeID}";
            InitializeCustomCalendar();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            grpDetails.Enabled = cmbCategory.SelectedIndex != -1;
            chkSIL.Enabled = (cmbCategory.Text == "Regular Days" || cmbCategory.Text == "Undertime");
            PopulateDetails();
        }

        private static string GetTotalHours(TimeSpan time) => $"{(int)time.TotalHours:D2}:{time.Minutes:D2}";

        private void PopulateDetails()
        {
            var time = CurrentEmployee.TimeDetails;
            InputFormat = txtInputValueUnits.Text = txtInitialValueUnits.Text = "hour(s):minute(s)";
            switch (cmbCategory.Text)
            {
                case "Regular Days":
                    txtInitialValue.Text = (time.RegularHours.TotalHours / 8).ToString();
                    InputFormat = txtInputValueUnits.Text = txtInitialValueUnits.Text = "day(s)";
                    break;

                case "Undertime":
                    txtInitialValue.Text = time.UnderTime.TotalMinutes.ToString();
                    InputFormat = txtInputValueUnits.Text = txtInitialValueUnits.Text = "minute(s)";
                    break;

                case "Legal Holiday 100%":
                    txtInitialValue.Text = (time.LegalHoliday_100.TotalHours / 8).ToString();
                    txtInitialValueUnits.Text = "day(s)";
                    break;

                case "Regular Overtime 125%":
                    txtInitialValue.Text = (GetTotalHours(time.RegOT_125)).ToString();
                    break;

                case "Regular Holiday 160%":
                    txtInitialValue.Text = (GetTotalHours(time.RegularHoliday_160)).ToString();
                    break;

                case "Rest Day/Special Holiday 130%":
                    txtInitialValue.Text = (GetTotalHours(time.RestDaySpecialOT_130)).ToString();
                    break;

                case "Rest Day Special Holiday 150%":
                    txtInitialValue.Text = (GetTotalHours(time.RestDaySpecialOT_150)).ToString();
                    break;

                case "Rest Day/Special Holiday Excess 169%":
                    txtInitialValue.Text = (GetTotalHours(time.RestDaySpecialOTExcess_169)).ToString();
                    break;

                case "Special Holiday Excess Overtime 195%":
                    txtInitialValue.Text = (GetTotalHours(time.SpecialExcessOT_195)).ToString();
                    break;

                case "Legal Holiday Overtime 200%":
                    txtInitialValue.Text = (GetTotalHours(time.LegalHolidayOT_200)).ToString();
                    break;

                case "Legal Holiday Overtime 260%":
                    txtInitialValue.Text = (GetTotalHours(time.LegalHolidayOT_260)).ToString();
                    break;

                case "Night Differential 10%":
                    txtInitialValue.Text = (GetTotalHours(time.NightDiff_10)).ToString();
                    break;

                case "Night Differential 20%":
                    txtInitialValue.Text = (GetTotalHours(time.NightDiff_20)).ToString();
                    break;

                case "Night Differential 50%":
                    txtInitialValue.Text = (GetTotalHours(time.NightDiff_50)).ToString();
                    break;

                case "Night Differential 125%":
                    txtInitialValue.Text = (GetTotalHours(time.NightDiff_125)).ToString();
                    break;

                case "Night Differential 130%":
                    txtInitialValue.Text = (GetTotalHours(time.NightDiff_130)).ToString();
                    break;

                case "Night Differential 150%":
                    txtInitialValue.Text = (GetTotalHours(time.NightDiff_150)).ToString();
                    break;

                default:
                    MessageBox.Show("There seems to be an error with the adustment category selection. Please try again", "Category Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    break;
            }
        }

        private void grpDetails_EnabledChanged(object sender, EventArgs e)
        {
            cmbOperation.SelectedIndex = (grpDetails.Enabled == true) ? 0 : -1;
        }

        private void txtInputValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtInputValue_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (InputFormat == "hour(s):minute(s)" && textBox.Text.Length == 2 && !textBox.Text.Contains(':'))
            {
                textBox.Text = textBox.Text.Insert(2, ":");
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private bool IsTimeFormatValid(string input) => System.Text.RegularExpressions.Regex.IsMatch(input, @"^\d{2}:\d{2}$");

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (AreRequiredFieldsAreFilled() == false)
            {
                MessageBox.Show("Please fill up the necessary fields to add an adjustment.", "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (InputFormat == "hour(s):minute(s)" && !IsTimeFormatValid(txtInputValue.Text))
            {
                MessageBox.Show("The input value is invalid. The correct format for this category is '00:00', just like the format stated in the units textbox.", "Format Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Adjustment = new()
            {
                ID = AdjustmentListCount++,
                Type = cmbCategory.Text,
                Operation = cmbOperation.Text,
                InputValue = (cmbOperation.Text == MessagesConstants.Add.TITLE) ? $"+{txtInputValue.Text}" : $"-{txtInputValue.Text}",
                Units = InputFormat,
                AppliedDate = SelectedDays,
                Remarks = (chkSIL.Checked) ? $"[SIL] {txtRemarks.Text}" : txtRemarks.Text
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool AreRequiredFieldsAreFilled()
        {
            if (string.IsNullOrEmpty(txtInputValue.Text)) return false;
            if (string.IsNullOrEmpty(SelectedDays)) return false; // TENTATIVE
            return true;
        }

        private Dictionary<DateTime, List<DateTime>> selectedDatesByMonth = new();
        private DateTime displayedMonth;
        private TableLayoutPanel calendar;

        private void InitializeCustomCalendar()
        {
            displayedMonth = DateTime.Now.Date;
            selectedDatesByMonth[displayedMonth] = new List<DateTime>();

            pnlCalendar.Controls.Add(CreateCalendarTable());
            UpdateCalendar();
        }

        private TableLayoutPanel CreateCalendarTable()
        {
            calendar = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle,
                ColumnCount = 7
            };

            return calendar;
        }

        private void UpdateCalendar()
        {
            calendar.Controls.Clear();

            calendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28f));
            calendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28f));
            calendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28f));
            calendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28f));
            calendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28f));
            calendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28f));
            calendar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28f));

            for (int i = 0; i < 7; i++)
            {
                Label dayLabel = new()
                {
                    Text = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedDayNames[i],
                    TextAlign = ContentAlignment.MiddleCenter
                };
                calendar.Controls.Add(dayLabel, i, 0);
            }

            lblMonthYear.Text = "Date: " + displayedMonth.ToString("MMMM, yyyy");

            int daysInMonth = DateTime.DaysInMonth(displayedMonth.Year, displayedMonth.Month);

            DateTime firstDayOfMonth = new DateTime(displayedMonth.Year, displayedMonth.Month, 1);
            int offset = (int)firstDayOfMonth.DayOfWeek;

            List<DateTime> selectedDates = selectedDatesByMonth.TryGetValue(displayedMonth, out var dates) ? dates : new List<DateTime>();

            for (int i = 0; i < daysInMonth; i++)
            {
                DateTime day = firstDayOfMonth.AddDays(i);
                Button dayButton = new()
                {
                    Text = (i + 1).ToString(),
                    Tag = day.Date,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                dayButton.Click += DayButton_Click;

                int row = (int)((i + offset) / 7) + 1;
                int col = (i + offset) % 7;

                calendar.Controls.Add(dayButton, col, row);

                if (selectedDates.Contains(day.Date))
                {
                    dayButton.BackColor = Color.LightBlue;
                }
            }
        }

        private void DayButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            DateTime selectedDate = ((DateTime)clickedButton.Tag).Date;  // Ensure we're working with the date part only

            if (!selectedDatesByMonth.TryGetValue(displayedMonth, out var selectedDates))
            {
                selectedDatesByMonth[displayedMonth] = selectedDates = new List<DateTime>();
            }

            if (selectedDates.Contains(selectedDate))
            {
                selectedDates.Remove(selectedDate);
                clickedButton.BackColor = SystemColors.Control;
            }
            else
            {
                selectedDates.Add(selectedDate);
                clickedButton.BackColor = Color.LightBlue;
            }

            DisplaySelectedDates();
        }

        private void DisplaySelectedDates()
        {
            List<string> formattedDates = new();

            foreach (var selectedMonth in selectedDatesByMonth.Keys)
            {
                List<DateTime> selectedDates = selectedDatesByMonth[selectedMonth];

                if (selectedDates.Count > 0)
                {
                    string formattedDate = selectedMonth.ToString("MM.");

                    if (selectedDates.Count == 1)
                    {
                        formattedDate += selectedDates[0].ToString("dd.yy");
                    }
                    else
                    {
                        List<string> dayParts = new();

                        for (int i = 0; i < selectedDates.Count; i++)
                        {
                            DateTime currentDate = selectedDates[i];
                            string dayPart = currentDate.ToString("dd");

                            while (i + 1 < selectedDates.Count &&
                                   selectedDates[i + 1].Month == currentDate.Month &&
                                   selectedDates[i + 1].Year == currentDate.Year)
                            {
                                i++;
                                currentDate = selectedDates[i];
                                dayPart += $",{currentDate:dd}";
                            }

                            if (currentDate == selectedDates[i])
                            {
                                dayPart += $".{currentDate:yy}";
                            }

                            dayParts.Add(dayPart);
                        }

                        formattedDate += string.Join(", ", dayParts);
                    }

                    formattedDates.Add(formattedDate);
                }
            }

            SelectedDays = (formattedDates.Count > 0) ? string.Join(", ", formattedDates) : string.Empty;

            lblDatePreview.Text = formattedDates.Count > 0
                ? "Date Preview: " + string.Join(", ", formattedDates)
                : "Please select date(s) to preview.";
        }

        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            displayedMonth = displayedMonth.AddMonths(1);
            UpdateCalendar();
        }

        private void btnPrevMonth_Click(object sender, EventArgs e)
        {
            displayedMonth = displayedMonth.AddMonths(-1);
            UpdateCalendar();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtInputValue.Text = "";
            txtRemarks.Text = "";
            selectedDatesByMonth.Clear();
            displayedMonth = DateTime.Now.Date;
            chkSIL.Checked = false;
            UpdateCalendar();
            lblDatePreview.Text = "Please select date(s) to preview.";
        }
    }
}
