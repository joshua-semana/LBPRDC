using LBPRDC.Source.Config;
using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;
using System.Globalization;

namespace LBPRDC.Source.Views.Billing
{
    public partial class NewBillingForm : Form
    {
        public BillingControl? ParentControl { get; set; }
        public int ClientID { get; set; }

        private Models.Client Client = new();
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

        private async void NewBillingForm_Load(object sender, EventArgs e)
        {
            if (ClientID == 0)
            {
                MessageBox.Show(MessagesConstants.ERROR_RETRIEVE_CLIENT, MessagesConstants.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            Client = await ClientService.GetClientByID(ClientID);

            this.Text = $"New Billing for Client: {Client.Description}";

            btnPreviewDateRange.PerformClick();
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

            txtFromDatePreview.Text = startDate.ToString(StringConstants.Date.DEFAULT);
            txtToDatePreview.Text = endDate.ToString(StringConstants.Date.DEFAULT);

            SetBillingName();
        }

        private void btnPreviewDateRange_Click(object sender, EventArgs e)
        {
            UpdateDatePreviewRange();
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            if (ControlUtils.AreRequiredFieldsFilled(RequiredFields))
            {
                
                if (await BillingService.CheckExistence(txtBillingName.Text.Trim(), ClientID))
                {
                    MessageBox.Show(MessagesConstants.Billing.EXIST, MessagesConstants.INVALID_INPUT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                AddNewBillingRecord();
            }
        }

        private async void AddNewBillingRecord()
        {
            bool isAccountAdded = false;

            string billingName = Utilities.StringFormat.ToSentenceCase(txtBillingName.Text.Trim());

            Models.Billing billing = new()
            {
                ClientID = ClientID,
                UserID = UserService.CurrentUser.ID,
                Name = billingName,
                OfficerName = txtOfficerInCharge.Text.ToUpper().Trim(),
                OfficerPosition = txtOfficerPosition.Text.ToUpper().Trim(),
                Month = cmbMonth.SelectedIndex + 1,
                Year = Convert.ToInt32(cmbYear.SelectedItem),
                Quarter = (radFirst.Checked) ? 1 : 2,
                StartDate = startDate,
                EndDate = endDate,
                IsEquipmentIncluded = chkIncludeEquipments.Checked,
                Description = txtDescription.Text.Trim(),
            };

            var (isBillingAdded, billingID) = await BillingService.Add(billing);

            if (isBillingAdded)
            {
                if (chkIncludeEquipments.Checked)
                {
                    string accountYear = billing.Year.ToString();
                    string accountMonth = billing.Month.ToString("D3");
                    decimal equipmentGrossAmount = Convert.ToDecimal(txtEquipmentsBilledValue.Text);

                    Models.Billing.Account account = new()
                    {
                        ClientID = ClientID,
                        BillingID = billingID,
                        AccountNumber = $"{Client.Name}Equip{accountYear}-{accountMonth}",
                        EntryType = StringConstants.Type.EQUIPMENT,
                        Classification = $"{Client.Name} {StringConstants.Type.EQUIPMENT}",
                        BilledValue = equipmentGrossAmount,
                        NetBilling = equipmentGrossAmount - NumericConstants.GetNetBilling(equipmentGrossAmount),
                        Balance = equipmentGrossAmount
                    };

                    isAccountAdded = await BillingAccountService.AddSingleAsync(account);
                }
            }

            if (isBillingAdded && !chkIncludeEquipments.Checked)
            {
                MessageBox.Show(MessagesConstants.Add.SUCCESS_BILLING, MessagesConstants.SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (isBillingAdded && chkIncludeEquipments.Checked)
            {
                if (isAccountAdded)
                {
                    MessageBox.Show(MessagesConstants.Add.SUCCESS_BILLING, MessagesConstants.SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("A billing is added but the equipment does not. Please add it later as custom entry.", MessagesConstants.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show(MessagesConstants.Error.ACTION, MessagesConstants.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ParentControl?.ResetTableSearch();
            ParentControl?.ResetView();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text) || MessageBox.Show(MessagesConstants.CONFIRMATION_CANCEL_QUESTION, MessagesConstants.CONFIRMATION_CANCEL, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void UpdateDateRange_ControlChanged(object sender, EventArgs e)
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
