using LBPRDC.Source.Services;

namespace LBPRDC.Source.Views.Billing
{
    public partial class EmployeeTimekeepReviewForm : Form
    {
        public BillingControl? ParentControl { get; set; }
        public List<Entry> Entries = new();
        private int CurrentIndex = 0;
        private string CurrentID = "";

        public EmployeeTimekeepReviewForm()
        {
            InitializeComponent();
        }

        private void EmployeeTimekeepReviewForm_Load(object sender, EventArgs e)
        {
            UpdateCounter();
            ViewDetails(CurrentIndex);
        }

        private static string GetTotalHours(TimeSpan time) => time == TimeSpan.Zero ? "" : $"{(int)time.TotalHours:D2}:{time.Minutes:D2}";

        private void ViewDetails(int index)
        {
            var person = Entries[index];
            var time = Entries[index].TimeDetails;

            CurrentID = person.ID;

            lblEmployeeInformation.Text = $"{person.ID} | {Utilities.StringFormat.ToSentenceCase(person.FullName)} | {Utilities.StringFormat.ToSentenceCase(person.Position)} | {person.Location}";
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
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (CurrentIndex != Entries.Count - 1)
            {
                CurrentIndex++;
                UpdateCounter();
                ViewDetails(CurrentIndex);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (CurrentIndex != 0)
            {
                CurrentIndex--;
                UpdateCounter();
                ViewDetails(CurrentIndex);
            }
        }

        private void UpdateCounter()
        {
            lblEntryCounter.Text = $"{CurrentIndex + 1} out of {Entries.Count} employees.";
        }
    }
}
