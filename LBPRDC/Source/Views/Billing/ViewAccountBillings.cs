using LBPRDC.Source.Config;
using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;
using System.ComponentModel;

namespace LBPRDC.Source.Views.Billing
{
    public partial class ViewAccountBillings : Form
    {
        public BillingControl? ParentControl { get; set; }
        public int BillingID { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
        public string BillingName { get; set; } = string.Empty;
        public string AccountType { get; set; } = string.Empty;
        public bool IsReleased { get; set; } = false;

        private decimal totalGrossBilling = 0;
        private string transactionType = string.Empty;
        private bool isRegularEntry = false;

        public ViewAccountBillings()
        {
            InitializeComponent();
        }

        private void ViewAccountBillings_Load(object sender, EventArgs e)
        {
            if (BillingID == 0)
            {
                MessageBox.Show(MessagesConstants.Error.MISSING_BILLING, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            Text = BillingName;
            lblAccountNumber.Text = $"SOA No.: {AccountNumber}";

            transactionType = AccountNumber.Contains("OT") ? StringConstants.Type.OVERTIME : StringConstants.Type.REGULAR;
            btnUpdate.Enabled = IsReleased;

            isRegularEntry = !string.IsNullOrEmpty(AccountType) && AccountType == StringConstants.Type.REGULAR;

            FetchData();
        }

        public async void FetchData()
        {
            switch (AccountType)
            {
                case StringConstants.Type.REGULAR:
                    var regularRecordList = await BillingRecordService.GetRecordsByBillingId(BillingID);
                    var records = regularRecordList.Where(r => r.RegularAccountNumber == AccountNumber || r.OvertimeAccountNumber == AccountNumber).ToList();
                    var totals = await BillingRecordService.GetGrossBillingAndDepartmentByIDAsync(BillingID);
                    PopulateRegularBillingTable(records);
                    PopulateRegularAccountNumberValues(totals);
                    break;

                case StringConstants.Type.EQUIPMENT:
                    var equipmentRecord = await BillingAccountService.GetEquipmentAccountByBillingID(BillingID);
                    PopulateEquipmentBillingTable(equipmentRecord);
                    PopulateEquipmentAccountNumberValues(equipmentRecord);
                    break;

                default:
                    MessageBox.Show("Error");
                    Close();
                    break;
            }


            //if (isRegularEntry)
            //{
            //    var records = await BillingRecordService.GetRecordsAsync(BillingID, AccountNumber);
            //    var totals = await BillingRecordService.GetGrossBillingAndDepartmentByIDAsync(BillingID);
            //    PopulateRegularBillingTable(records);
            //    PopulateRegularAccountNumberValues(totals);

            //    //frmLoading form = new()
            //    //{
            //    //    AccountsTotalValuesProcess = Task.Run(() => BillingRecordService.GetGrossBillingAndDepartmentByName(BillingID)),
            //    //    Description = "Retrieving information, please wait..."
            //    //};

            //    //var output = form.ShowDialog();

            //    //if (output == DialogResult.OK)
            //    //{
            //    //    if (form.AccountsTotalValuesResult == null)
            //    //    {
            //    //        MessageBox.Show("There is a problem retrieving the billing records of this account. Please try again.", MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    //        Close();
            //    //    }

            //    //    PopulateRegularAccountNumberValues(form.AccountsTotalValuesResult);
            //    //}
            //    //else if (output == DialogResult.Abort)
            //    //{
            //    //    MessageBox.Show("There is a problem retrieving the billing records of this account. Please try again.", MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    //    Close();
            //    //}
            //}
            //else
            //{
            //    List<BillingAccount> accountDetails = new();

            //    frmLoading form = new()
            //    {
            //        BillingAccountProcess = Task.Run(() => BillingAccountService.GetDetails(AccountNumber, BillingName))
            //    };

            //    var output = form.ShowDialog();

            //    if (output == DialogResult.OK)
            //    {
            //        accountDetails.Add(form.BillingAccountResult ?? new());

            //        if (!accountDetails.Any())
            //        {
            //            MessageBox.Show("There is a problem retrieving the record of this account. Please try again.", MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            Close();
            //        }

            //        PopulateCustomBillingTable(accountDetails);
            //        PopulateCustomAccountNumberValues(accountDetails);
            //    }
            //    else if (output != DialogResult.Abort)
            //    {
            //        MessageBox.Show("There is a problem retrieving the billing records of this account. Please try again.", MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        Close();
            //    }
            //}
        }

        private void PopulateRegularAccountNumberValues(List<Models.Billing.Record.TotalGross> accountsTotal)
        {
            if (accountsTotal.Any())
            {
                totalGrossBilling = accountsTotal.First(f => f.AccountNumber == AccountNumber).GrossBilling;
                var totalNet = (double)totalGrossBilling - (double)NumericConstants.GetNetBilling(totalGrossBilling);
                lblTotalGrossValue.Text = $"Total Gross Billing: {totalGrossBilling:N2}";
                lblTotalNetValue.Text = $"Total Net Billing: {totalNet:N2}";
            }
            else
            {
                lblTotalGrossValue.Text = "Total Gross Billing: (Can't retrieve information)";
                lblTotalNetValue.Text = "Total Net Billing: (Can't retrieve information)";
            }
        }

        private void PopulateRegularBillingTable(List<Models.Billing.Record> list)
        {
            dgvBillings.CellContentClick -= DgvBillings_CellContentClick;

            BindingList<Models.Billing.Record> bindingRecords = new(list.OrderBy(ob => ob.FullName).ToList());
            dgvBillings.Columns.Clear();
            dgvBillings.AutoGenerateColumns = false;
            ApplyRegularSettingsToTable();
            dgvBillings.Columns["Guid"].Visible = false;
            dgvBillings.DataSource = bindingRecords;

            dgvBillings.CellContentClick += DgvBillings_CellContentClick;
        }

        private void ApplyRegularSettingsToTable()
        {
            ControlUtils.AddColumn(dgvBillings, "Guid", "Guid", "Guid", false, true);
            ControlUtils.AddColumn(dgvBillings, "EntryType", "Type", "EntryType", true, true);
            ControlUtils.AddColumn(dgvBillings, "EmployeeID", "ID", "EmployeeID", true, true);
            ControlUtils.AddColumn(dgvBillings, "FullName", "Name", "FullName", true, true);
            ControlUtils.AddColumn(dgvBillings, "Position", "Position", "Position", true, true);
            ControlUtils.AddColumn(dgvBillings, "UserRemarks", "Your Remarks", "UserRemarks", true, true);
            ControlUtils.AddColumn(dgvBillings, "Description", "Status", "Description", true, true);
            ControlUtils.AddColumn(dgvBillings, $"{transactionType}BillingValue", "Gross Billing", $"{transactionType}BillingValue", true, true);
            ControlUtils.AddColumn(dgvBillings, $"{transactionType}CollectedValue", "Collected Value", $"{transactionType}CollectedValue", true, !IsReleased);
            ControlUtils.AddColumn(dgvBillings, $"{transactionType}CollectedDate", "Collected Date", $"{transactionType}CollectedDate", true, true);
            ControlUtils.AddColumn(dgvBillings, $"{transactionType}AdjustmentRemarks", "Adjustments", $"{transactionType}AdjustmentRemarks", true, true);
            if (IsReleased)
            {
                DataGridViewButtonColumn colAction = new()
                {
                    HeaderText = "Action",
                    Text = "Collect",
                    UseColumnTextForButtonValue = true
                };
                dgvBillings.Columns.Add(colAction);
            }
        }

        private void PopulateEquipmentBillingTable(Models.Billing.Account equipment)
        {
            List<Models.Billing.Account> equipmentsList = new()
            {
                equipment
            };
            dgvBillings.Columns.Clear();
            dgvBillings.AutoGenerateColumns = false;
            ApplyEquipmentSettingsToTable();
            dgvBillings.DataSource = equipmentsList;
        }

        private void ApplyEquipmentSettingsToTable()
        {
            ControlUtils.AddColumn(dgvBillings, "Classification", "Classification", "Classification", true, true);
            ControlUtils.AddColumn(dgvBillings, "BilledValue", "Gross Billing", "BilledValue", true, true);
            ControlUtils.AddColumn(dgvBillings, "CollectedValue", "Collected Value", "CollectedValue", true, !IsReleased);
            ControlUtils.AddColumn(dgvBillings, "CollectedDate", "Collected Date", "CollectedDate", true, true);
        }

        private void PopulateEquipmentAccountNumberValues(Models.Billing.Account equipment)
        {
            totalGrossBilling = equipment.BilledValue;
            var totalNet = equipment.NetBilling;
            lblTotalGrossValue.Text = $"Total Gross Billing: {totalGrossBilling:N2}";
            lblTotalNetValue.Text = $"Total Net Billing: {totalNet:N2}";
        }




















        private void PopulateCustomAccountNumberValues(List<BillingAccount> accounts)
        {
            if (accounts.Any())
            {
                var account = accounts.First(f => f.AccountNumber == AccountNumber);
                totalGrossBilling = account.BilledValue;
                var totalNet = account.NetBilling;
                lblTotalGrossValue.Text = $"Total Gross Billing: {totalGrossBilling:N2}";
                lblTotalNetValue.Text = $"Total Net Billing: {totalNet:N2}";
            }
            else
            {
                lblTotalGrossValue.Text = "Total Gross Billing: (Can't retrieve information)";
                lblTotalNetValue.Text = "Total Net Billing: (Can't retrieve information)";
            }
        }

        private void PopulateCustomBillingTable(List<BillingAccount> accounts)
        {
            dgvBillings.Columns.Clear();
            dgvBillings.AutoGenerateColumns = false;
            ApplyCustomSettingsToTable();
            dgvBillings.DataSource = accounts;
        }

        private void ApplyCustomSettingsToTable()
        {
            ControlUtils.AddColumn(dgvBillings, "Classification", "Classification", "Classification", true, true);
            ControlUtils.AddColumn(dgvBillings, "BilledValue", "Gross Billing", "BilledValue", true, true);
            ControlUtils.AddColumn(dgvBillings, "CollectedValue", "Collected Value", "CollectedValue", true, !IsReleased);
            ControlUtils.AddColumn(dgvBillings, "CollectedDate", "Collected Date", "CollectedDate", true, true);
        }

        private void DgvBillings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (IsReleased && e.RowIndex >= 0 && e.ColumnIndex == dgvBillings.Columns.Count - 1)
            {
                object guidValue = dgvBillings.Rows[e.RowIndex].Cells["Guid"].Value;
                object employeeFullName = dgvBillings.Rows[e.RowIndex].Cells["FullName"].Value;
                object grossBilling = dgvBillings.SelectedRows[0].Cells[$"{transactionType}BillingValue"].Value;
                dgvBillings.SelectedRows[0].Cells[$"{transactionType}CollectedValue"].Value = grossBilling;

                //CollectEmployeeBillingForm form = new()
                //{
                //    ParentControl = this,
                //    BillingName = BillingName,
                //    AccountNumber = AccountNumber,
                //    EmployeeGuid = (Guid)guidValue,
                //    EmployeeName = employeeFullName.ToString(),
                //    GrossBillingValue = Convert.ToDecimal(grossBilling),
                //    CollectedValue = Convert.ToDecimal(collectedValue),
                //    AccountGrossBillingValue = totalGrossBilling
                //};

                //form.ShowDialog();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ViewAccountBillings_FormClosed(object sender, FormClosedEventArgs e)
        {
            ParentControl?.PopulateSelectedAccountInformation();
        }

        private void dgvBillings_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string collectedValueColumnName = (isRegularEntry) ? $"{transactionType}CollectedValue" : "CollectedValue";

            if (e.ColumnIndex == dgvBillings.Columns[collectedValueColumnName].Index)
            {
                e.ThrowException = false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (isRegularEntry)
            {
                DoUpdateForRegular();
            }
            else
            {
                DoUpdateForCustom();
            }
        }

        private async void DoUpdateForRegular()
        {
            List<Models.Billing.Record> records = new();
            int errorCount = 0;
            decimal totalCollectedValue = 0;

            foreach (DataGridViewRow row in dgvBillings.Rows)
            {
                object guidValue = row.Cells["Guid"].Value;
                object collectedValue = row.Cells[$"{transactionType}CollectedValue"].Value;

                if (decimal.TryParse(collectedValue?.ToString(), out decimal decimalValue))
                {
                    totalCollectedValue += decimalValue;
                    records.Add(new()
                    {
                        BillingID = BillingID,
                        RegularAccountNumber = AccountNumber,
                        OvertimeAccountNumber = AccountNumber,
                        RegularCollectedValue = decimalValue,
                        OvertimeCollectedValue = decimalValue,
                        Guid = (Guid)guidValue
                    });
                }
                else
                {
                    errorCount++;
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                }
            }

            if (errorCount > 0)
            {
                MessageBox.Show("There are invalid entries, please review your inputs.", "Invalid Entries", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmLoading form = new()
            {
                BooleanProcess = Task.Run(() => BillingRecordService.UpdateCollectedValuesAsync(records, transactionType))
            };

            DialogResult result = form.ShowDialog();

            if (result == DialogResult.OK && await UpdateAccountCollectionBalancePurpose(totalCollectedValue))
            {
                MessageBox.Show("You have successfully updated the collected values of this account's employees.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else if (result == DialogResult.Abort)
            {
                MessageBox.Show("There is a problem updating the collected values of employees. Please try again.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void DoUpdateForCustom()
        {
            decimal totalCollectedValue = 0;

            foreach (DataGridViewRow row in dgvBillings.Rows)
            {
                object collectedValue = row.Cells["CollectedValue"].Value;
                totalCollectedValue += Convert.ToDecimal(collectedValue);
            }

            if (await UpdateAccountCollectionBalancePurpose(totalCollectedValue))
            {
                MessageBox.Show("You have successfully updated the collected value of this account.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private async Task<bool> UpdateAccountCollectionBalancePurpose(decimal totalCollectedValue)
        {
            decimal newBalanceValue = totalGrossBilling - totalCollectedValue;

            bool hasCollectedValueUpdated = await Task.Run(() => BillingAccountService.UpdateCollectedValue(AccountNumber, BillingID, totalCollectedValue));
            bool hasBalanceValueUpdated = await Task.Run(() => BillingAccountService.UpdateBalance(AccountNumber, BillingID, newBalanceValue));

            string purpose = (newBalanceValue == 0) ? "Collected" : "Still Collecting";

            await Task.Run(() => BillingAccountService.UpdatePurpose(AccountNumber, BillingID, purpose));

            return hasCollectedValueUpdated && hasBalanceValueUpdated;
        }
    }
}
