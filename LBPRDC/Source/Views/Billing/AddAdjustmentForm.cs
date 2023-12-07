using LBPRDC.Source.Services;

namespace LBPRDC.Source.Views.Billing
{
    public partial class AddAdjustmentForm : Form
    {
        public EmployeeTimekeepReviewForm? ParentConrol { get; set; }
        public EntryAdjustments Adjustment { get; private set; }
        public int AdjustmentListCount { get; set; }

        public Entry CurrentEmployee = new();
        public string InputFormat = "";

        public AddAdjustmentForm()
        {
            InitializeComponent();
        }

        private void AddAdjustmentForm_Load(object sender, EventArgs e)
        {
            this.Text = $"Adjustment for {CurrentEmployee.EmployeeID}";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            grpDetails.Enabled = (cmbCategory.SelectedIndex == -1) ? false : true;
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
                    InputFormat = txtInputValueUnits.Text = txtInitialValueUnits.Text = "day(s)";
                    break;

                case "Regular Overtime 125%":
                    txtInitialValue.Text = (GetTotalHours(time.RegOT_125)).ToString();
                    break;

                case "Regular Holiday 160%":
                    txtInitialValue.Text = (GetTotalHours(time.RegularHoliday_160)).ToString();
                    break;

                case "Rest Day and Special Overtime 130%":
                    txtInitialValue.Text = (GetTotalHours(time.RestDayAndSpecialOT_130)).ToString();
                    break;

                case "Rest Day Overtime 150%":
                    txtInitialValue.Text = (GetTotalHours(time.RestDayOT_150)).ToString();
                    break;

                case "Rest Day Overtime Excess 169%":
                    txtInitialValue.Text = (GetTotalHours(time.RestDayOTExcess_169)).ToString();
                    break;

                case "Special Excess Overtime 195%":
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
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
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

            btnAdd.Enabled = (textBox.Text.Length > 0) ? true : false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtInputValue.Text = "";
            dtpDate.Value = DateTime.Now;
        }

        private bool IsTimeFormatValid(string input) => System.Text.RegularExpressions.Regex.IsMatch(input, @"^\d{2}:\d{2}$");

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (InputFormat == "hour(s):minute(s)" && !IsTimeFormatValid(txtInputValue.Text))
            {
                MessageBox.Show("The input value is invalid. The correct format for this category is '00:00', just like the format stated in the units textbox.", "Format Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CurrentEmployee.Adjustments != null)
            {
                var tempList = CurrentEmployee.Adjustments.ToList().Where(a => a.Type.Contains(cmbCategory.Text)).ToList();

                if (tempList.Count > 0)
                {
                    MessageBox.Show("You already have this adjustment; please remove the first one in order to add this specific adjustment with a new value again.", "Adjustment Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string operation = cmbOperation.Text;

            TimeSpan initialValueInTime = TimeSpan.Zero;
            TimeSpan inputValueInTime = TimeSpan.Zero;
            string rawOutput = "";

            switch (InputFormat)
            {
                case "day(s)":
                    int initialValue = Convert.ToInt32(txtInitialValue.Text);
                    int inputValue = Convert.ToInt32(txtInputValue.Text);
                    initialValueInTime = TimeSpan.FromHours(initialValue * 8);
                    inputValueInTime = TimeSpan.FromHours(inputValue * 8);
                    rawOutput = ((operation == "Add") ? initialValue + inputValue : initialValue - inputValue).ToString();
                    break;

                case "minute(s)":
                    initialValueInTime = TimeSpan.FromMinutes(Convert.ToInt32(txtInitialValue.Text));
                    inputValueInTime = TimeSpan.FromMinutes(Convert.ToInt32(txtInputValue.Text));
                    TimeSpan temp1 = (operation == "Add") ? initialValueInTime.Add(inputValueInTime) : initialValueInTime.Subtract(inputValueInTime);
                    rawOutput = temp1.TotalMinutes.ToString();
                    break;

                case "hour(s):minute(s)":
                    initialValueInTime = ExcelService.ParseTime(txtInitialValue.Text);
                    inputValueInTime = ExcelService.ParseTime(txtInputValue.Text);
                    TimeSpan temp2 = (operation == "Add") ? initialValueInTime.Add(inputValueInTime) : initialValueInTime.Subtract(inputValueInTime);
                    rawOutput = GetTotalHours(temp2).ToString();
                    break;
            }

            TimeSpan newValue = (operation == "Add") ? initialValueInTime.Add(inputValueInTime) : initialValueInTime.Subtract(inputValueInTime);

            Adjustment = new()
            {
                ID = AdjustmentListCount++,
                Type = cmbCategory.Text,
                OriginalValue = initialValueInTime,
                Operation = cmbOperation.Text,
                InputValue = inputValueInTime,
                NewAdjustedValue = newValue,
                RawOriginalValue = txtInitialValue.Text,
                RawInputValue = txtInputValue.Text,
                RawNewAdjustedValue = rawOutput,
                Units = InputFormat,
                AppliedDate = dtpDate.Value.ToString("MMM dd, yyyy")
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
