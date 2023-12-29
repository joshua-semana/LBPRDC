using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;
using System.Globalization;

namespace LBPRDC.Source.Views.Billing
{
    public partial class NewBillingForm : Form
    {
        public BillingControl? ParentControl { get; set; }

        private List<Control> RequiredFields;

        DateTime startDate, endDate;

        public NewBillingForm()
        {
            InitializeComponent();
            InitializeMonthsComboBox();
            InitializeYearComboBox();

            RequiredFields = new()
            {
                txtBillingName
            };
        }

        private void InitializeMonthsComboBox()
        {
            string[] monthNames = DateTimeFormatInfo.CurrentInfo.MonthNames;
            cmbMonth.Items.AddRange(monthNames);
            cmbMonth.Items.Remove("");
            cmbMonth.SelectedIndex = DateTime.Now.Month - 1;
        }

        private void InitializeYearComboBox()
        {
            var (min, max) = ConfigService.GetBillingComboBoxYearConfig();
            int currentYear = DateTime.Now.Year;
            for (int year = currentYear - min; year <= currentYear + max; year++)
            {
                cmbYear.Items.Add(year);
            }
            cmbYear.SelectedItem = currentYear;
        }

        private void UpdateDatePreviewRange()
        {
            int selectedMonth = cmbMonth.SelectedIndex + 1;
            int selectedYear = Convert.ToInt32(cmbYear.SelectedItem);

            if (radFirst.Checked)
            {
                startDate = new DateTime(selectedYear, selectedMonth, 1);
                endDate = new DateTime(selectedYear, selectedMonth, 15);
            }
            else
            {
                startDate = new DateTime(selectedYear, selectedMonth, 16);
                endDate = new DateTime(selectedYear, selectedMonth, DateTime.DaysInMonth(selectedYear, selectedMonth));
            }

            txtFromDatePreview.Text = startDate.ToString("MMMM dd, yyyy");
            txtToDatePreview.Text = endDate.ToString("MMMM dd, yyyy");
        }

        private void btnPreviewDateRange_Click(object sender, EventArgs e)
        {
            UpdateDatePreviewRange();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (ControlUtils.AreRequiredFieldsFilled(RequiredFields))
            {
                int nameCount = BillingService.GetItemCountByName(txtBillingName.Text);
                if (nameCount > 0)
                {
                    MessageBox.Show("This billing name has already been used. Please enter another billing name to continue.", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                AddNewBillingRecord();
            }
        }

        private async void AddNewBillingRecord()
        {
            BillingService.Billing newBilling = new()
            {
                UserID = UserService.CurrentUser.UserID,
                Name = Utilities.StringFormat.ToSentenceCase(txtBillingName.Text),
                Month = cmbMonth.SelectedIndex + 1,
                Year = Convert.ToInt32(cmbYear.SelectedItem),
                Quarter = (radFirst.Checked) ? 1 : 2,
                StartDate = startDate,
                EndDate = endDate,
                Description = txtDescription.Text,
                Status = "Active"
            };

            var isAdded = await BillingService.Add(newBilling);
            if (isAdded == true)
            {
                MessageBox.Show("You have successfully added a new billing.", "New Billing Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (UserService.CurrentUser != null)
                {
                    LoggingService.Log newLog = new()
                    {
                        UserID = UserService.CurrentUser.UserID,
                        ActivityType = "Add",
                        ActivityDetails = $"This user has added a new billing named as {newBilling.Name}."
                    };

                    LoggingService.LogActivity(newLog);
                }
                ParentControl?.ResetTableSearch();
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to cancel this operation?", "Cancel Operation Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void UpdateDateRange_ControlChanged(object sender, EventArgs e)
        {
            btnPreviewDateRange.PerformClick();
        }

        private void NewBillingForm_Load(object sender, EventArgs e)
        {
            btnPreviewDateRange.PerformClick();
        }
    }
}
