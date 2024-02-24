using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;
using System.Globalization;
using System.Transactions;

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
                txtBillingName,
                txtOfficerInCharge,
                txtOfficerPosition
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

            SetBillingName();
        }

        private void btnPreviewDateRange_Click(object sender, EventArgs e)
        {
            UpdateDatePreviewRange();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (ControlUtils.AreRequiredFieldsFilled(RequiredFields))
            {
                int nameCount = BillingService.GetItemCountByName(txtBillingName.Text.Trim());
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
            List<BillingAccount> newAccount = new();

            string billingName = Utilities.StringFormat.ToSentenceCase(txtBillingName.Text.Trim());

            Services.Billing newBilling = new()
            {
                UserID = UserService.CurrentUser.UserID,
                Name = billingName,
                OfficerName = txtOfficerInCharge.Text.ToUpper().Trim(),
                OfficerPosition = txtOfficerPosition.Text.ToUpper().Trim(),
                Month = cmbMonth.SelectedIndex + 1,
                Year = Convert.ToInt32(cmbYear.SelectedItem),
                Quarter = (radFirst.Checked) ? 1 : 2,
                StartDate = startDate,
                EndDate = endDate,
                Timestamp = DateTime.Now,
                ReleaseDate = null,
                ConstantJSON = String.Empty,
                EditableJSON = String.Empty,
                AccrualsJSON = String.Empty,
                VerificationStatus = "Unverified",
                IsEquipmentIncluded = chkIncludeEquipments.Checked,
                Description = txtDescription.Text.Trim(),
                Status = "Active",
                LockStatus = "Unlock"
            };

            using var transaction = new TransactionScope();

            try
            {
                await Task.Run(() => BillingService.Add(newBilling));

                if (chkIncludeEquipments.Checked)
                {
                    string accountYear = newBilling.Year.ToString();
                    string accountMonth = newBilling.Month.ToString("D3");
                    decimal equipmentGrossAmount = Convert.ToDecimal(txtEquipmentsBilledValue.Text);

                    newAccount.Add(new()
                    {
                        BillingName = newBilling.Name,
                        AccountNumber = $"SHFCEquip{accountYear}-{accountMonth}",
                        EntryType = "Custom Entry",
                        OfficialReceiptNumber = "",
                        Classification = "SHFC Equipment",
                        BilledValue = equipmentGrossAmount,
                        NetBilling = equipmentGrossAmount - Convert.ToDecimal((double)equipmentGrossAmount / 1.12 * 0.07),
                        CollectedValue = 0,
                        CollectionDate = null,
                        Balance = equipmentGrossAmount,
                        Purpose = "",
                        Timestamp = DateTime.Now,
                        Remarks = "Supplies and Equipment Billing"
                    });

                    await Task.Run(() => BillingAccountService.Add(newAccount, billingName));
                }

                transaction.Complete();

                MessageBox.Show("You have successfully added a new billing.", "New Billing Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ParentControl?.ResetTableSearch();
                this.Close();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text) || MessageBox.Show("Are you sure you want to cancel this operation?", "Cancel Operation Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

        private void SetBillingName()
        {
            txtBillingName.Text = $"{startDate:MMMM dd}-{endDate:dd, yyyy} Billing";
        }

        private void MoneyInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '.' || (e.KeyChar == '.' && (sender as TextBox)?.Text.Contains('.') == true)) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void chkIncludeEquipments_CheckedChanged(object sender, EventArgs e)
        {
            txtEquipmentsBilledValue.Enabled = chkIncludeEquipments.Checked;
            if (chkIncludeEquipments.Checked)
            {
                RequiredFields.Add(txtEquipmentsBilledValue);
            }
            else
            {
                RequiredFields.Remove(txtEquipmentsBilledValue);
            }
        }
    }
}
