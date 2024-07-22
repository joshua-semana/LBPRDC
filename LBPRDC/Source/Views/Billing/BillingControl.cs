using LBPRDC.Source.Config;
using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;
using LBPRDC.Source.Models;

namespace LBPRDC.Source.Views.Billing
{
    public partial class BillingControl : UserControl
    {
        private string ClientName { get; set; } = "";

        UserControl loadingControl = new ucLoading() { Dock = DockStyle.Fill };

        private string? OfficerName = "";
        private string? OfficerPosition = "";

        private readonly string NOT_RELEASED = "Not Yet Released";
        private readonly string NOT_COLLECTED = "Not Yet Collected";
        private readonly string COLLECTING = "Still Collecting";
        private readonly string COLLECTED = "Collected";

        private string selectedBillingName = "";
        private bool isBillingReleased = false;

        private int BillingID = 0;
        private int ClientID = 0;
        private Models.Billing CurrentViewingBillingCompleteInfo = new(); // Only populated when user clicks "View Details" button


        public BillingControl()
        {
            InitializeComponent();
            this.Controls.Add(loadingControl);
            loadingControl.BringToFront();
        }

        public void ApplySearchThenPopulate()
        {
            string searchWord = txtSearch.Text.Trim().ToLower();
            PopulateTableWithSearch(searchWord, ClientID);
        }

        public void ResetTableSearch()
        {
            txtSearch.Text = string.Empty;
            ApplySearchThenPopulate();
        }

        public void CloseDetails()
        {
            pnlLeft.Enabled = true;
            pnlRight.Visible = false;
            ClearInputs();
        }

        public void ResetView()
        {
            pnlLeft.Enabled = true;
            pnlRight.Visible = false;
        }

        private void ClearInputs()
        {
            ControlUtils.ClearInputs(pnlRightBody);
            ControlUtils.ClearInputs(grpBillingInformation);
            ControlUtils.ClearInputs(grpStatementOfAccounts);
            ControlUtils.ClearInputs(grpPurpose);
        }

        private void BillingControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                InitializeClientComboBoxItems();
                //ApplySearchThenPopulate(); // Commented since it do this function because of the automatic selection change of cmbClient
            }
        }

        private async void InitializeClientComboBoxItems()
        {
            cmbClient.DataSource = await ClientService.GetAllItemsForComboBox(StringConstants.Status.ACTIVE, false);
            cmbClient.DisplayMember = nameof(Client.Name);
            cmbClient.ValueMember = nameof(Models.Client.ID);
            cmbClient.MouseWheel += ComboBoxUtils.HandleMouseWheel;
            cmbClient.KeyDown += ComboBoxUtils.HandleKeyDown;
        }

        private async void PopulateTableWithSearch(string searchWord, int clientID)
        {
            ShowLoadingProgressBar(true);
            var (Items, TotalCount) = await Task.Run(() => BillingService.GetFilteredItems(searchWord, clientID));

            dgvBillings.Columns.Clear();
            dgvBillings.AutoGenerateColumns = false;
            ApplySettingsToTable();
            lblRowCounter.Text = ControlUtils.GetTableRowCount(Items.Count, TotalCount, "billing");
            dgvBillings.DataSource = Items;

            if (dgvBillings.Rows.Count > 0)
            {
                dgvBillings.CurrentCell = dgvBillings.Rows[0].Cells[0];
            }

            ShowLoadingProgressBar(false);
        }

        private void ApplySettingsToTable()
        {
            ControlUtils.AddColumn(dgvBillings, "ID", "ID", "ID", true, true);
            ControlUtils.AddColumn(dgvBillings, "LockStatus", "", "LockStatus", true, true);
            ControlUtils.AddColumn(dgvBillings, "Name", "Billing Name", "Name", true, true);
            ControlUtils.AddColumn(dgvBillings, "QuarterName", "Quarter", "QuarterName", true, true);
            ControlUtils.AddColumn(dgvBillings, "FormattedStartDate", "Start Date", "FormattedStartDate", true, true);
            ControlUtils.AddColumn(dgvBillings, "FormattedEndDate", "End Date", "FormattedEndDate", true, true);
            ControlUtils.AddColumn(dgvBillings, "ConstantJSON", "Timekeep", "ConstantJSON", true, true);
            ControlUtils.AddColumn(dgvBillings, "VerificationStatus", "Verified", "VerificationStatus", true, true);
            ControlUtils.AddColumn(dgvBillings, "AccrualsJSON", "Accruals", "AccrualsJSON", true, true);
            ControlUtils.AddColumn(dgvBillings, "Year", "Year", "Year", false, true);
            ControlUtils.AddColumn(dgvBillings, "Month", "Month", "Month", false, true);
            //dgvBillings.Columns[dgvBillings.Columns["VerificationStatus"].Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void dgvBillings_SelectionChanged(object sender, EventArgs e)
        {
            bool hasIDColumn = dgvBillings.Columns.Cast<DataGridViewColumn>().Any(column => column.Name == "ID");
            bool hasNameColumn = dgvBillings.Columns.Cast<DataGridViewColumn>().Any(column => column.Name == "Name");
            bool hasLockStatusColumn = dgvBillings.Columns.Cast<DataGridViewColumn>().Any(column => column.Name == "LockStatus");

            if (dgvBillings.Rows.Count > 0 && dgvBillings.SelectedRows.Count > 0 && dgvBillings.Columns.Count > 0)
            {
                if (hasNameColumn)
                {
                    selectedBillingName = dgvBillings.SelectedRows[0].Cells["Name"].Value.ToString() ?? "";
                    BillingID = Convert.ToInt32(dgvBillings.SelectedRows[0].Cells["ID"].Value);
                }
                if (hasLockStatusColumn)
                {
                    object status = dgvBillings.SelectedRows[0].Cells["LockStatus"].Value;
                    isBillingReleased = ((string)status == "🔒");
                }
            }
        }

        private void ShowLoadingProgressBar(bool state)
        {
            loadingControl.Visible = state;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewBillingForm newBillingForm = new()
            {
                ParentControl = this,
                ClientID = Convert.ToInt32(cmbClient.SelectedValue)
            };
            newBillingForm.ShowDialog();
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ApplySearchThenPopulate();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplySearchThenPopulate();
        }

        private async void UpdateOrDuplicateBilling(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (CurrentViewingBillingCompleteInfo != null)
            {
                Models.Billing.Account accountEquipment = new();

                if (txtEquipmentIncludedStatus.Text == StringConstants.Status.YES)
                {
                    accountEquipment = await BillingAccountService.GetEquipmentAccountByBillingID(BillingID);
                }

                BillingInformationForm form = new()
                {
                    ParentControl = this,
                    ClientID = ClientID,
                    BillingCompleteInfo = CurrentViewingBillingCompleteInfo,
                    AccountEquipmentInfo = accountEquipment,
                    Type = button.Tag.ToString()
                };

                form.ShowDialog();
            }
        }





        private async void btnView_Click(object sender, EventArgs e)
        {
            if (BillingID == 0) { return; }
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                var billing = await BillingService.GetBillingDetailsById(BillingID);

                if (billing == null)
                {
                    MessageBox.Show(MessagesConstants.Error.ACTION, MessagesConstants.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                CurrentViewingBillingCompleteInfo = billing;
                PopulateBillingInformation(billing);

                var combinedAccountsList = new List<Models.Billing.AccountsWithType>();
                if (isBillingReleased)
                {
                    combinedAccountsList.AddRange(await BillingAccountService.GetAccountsWithTypeByBillingIdAndType(BillingID, StringConstants.Type.REGULAR));
                }
                else
                {
                    combinedAccountsList.AddRange(await BillingRecordService.GetAccountsWithTypeByBillingID(BillingID));
                }

                if (billing.IsEquipmentIncluded)
                {
                    var billingAccountEquipment = await BillingAccountService.GetAccountsWithTypeByBillingIdAndType(BillingID, StringConstants.Type.EQUIPMENT);
                    if (billingAccountEquipment != null)
                    {
                        combinedAccountsList.AddRange(billingAccountEquipment);
                    }
                }

                PopulateAccountsComboBox(combinedAccountsList);

                pnlLeft.Enabled = false;
                pnlRight.Visible = true;

                cmbStatementOfAccounts.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void PopulateBillingInformation(Models.Billing data)
        {
            ControlUtils.ClearInputs(grpBillingInformation);
            txtCreationDate.Text = data.Timestamp.ToString(StringConstants.Date.DEFAULT);
            txtReleaseDate.Text = (data.ReleaseDate.HasValue) ? data.ReleaseDate.Value.ToString(StringConstants.Date.DEFAULT) : StringConstants.Status.NOT_RELEASED;
            txtDescription.Text = data.Description;
            txtOICandPosition.Text = $"{Utilities.StringFormat.ToSentenceCase(data.OfficerName)} - {Utilities.StringFormat.ToSentenceCase(data.OfficerPosition)}";
            txtEquipmentIncludedStatus.Text = (data.IsEquipmentIncluded) ? StringConstants.Status.YES : StringConstants.Status.NO;
        }

        private void PopulateAccountsComboBox(List<Models.Billing.AccountsWithType> accountsWithTypes)
        {
            cmbStatementOfAccounts.Items.Clear();

            if (accountsWithTypes.Any())
            {
                foreach (var item in accountsWithTypes)
                {
                    cmbStatementOfAccounts.Items.Add(new
                    {
                        Text = item.AccountNumber,
                        Tag = item.EntryType
                    });
                }
            }
            else
            {
                cmbStatementOfAccounts.Items.Add(new
                {
                    Text = StringConstants.ComboBox.NOTHING_FOUND,
                    Tag = StringConstants.ComboBox.NOTHING
                });
            }

            cmbStatementOfAccounts.DisplayMember = "Text";
            cmbStatementOfAccounts.ValueMember = "Tag";
        }

        private void cmbStatementOfAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pnlRight.Visible == true && cmbStatementOfAccounts.Items.Count > 0)
            {
                var selectedItem = (dynamic)cmbStatementOfAccounts.SelectedItem;
                cmbStatementOfAccounts.Tag = selectedItem.Tag;

                PopulateSelectedAccountInformation();
            }
        }

        public async void PopulateSelectedAccountInformation()
        {
            ClearAccountInformation(grpStatementOfAccounts);

            if (ClientID == 0 || cmbStatementOfAccounts.Tag == null)
            {
                MessageBox.Show(MessagesConstants.Error.MISSING_CLIENT, MessagesConstants.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                CloseDetails();
                return;
            }

            if (cmbStatementOfAccounts.Text == StringConstants.ComboBox.NOTHING_FOUND)
            {
                grpStatementOfAccounts.Enabled = false;
            }
            else
            {
                grpStatementOfAccounts.Enabled = true;

                var accountDetails = await BillingAccountService.GetAccountDetailsByNumberAndBillingID(cmbStatementOfAccounts.Text, BillingID);

                if (accountDetails != null)
                {
                    if (isBillingReleased)
                    {
                        txtBilledValue.Text = $"{accountDetails.BilledValue:N2}";
                        txtNetBilling.Text = $"{accountDetails.NetBilling:N2}";
                        txtCollectionDate.Text = (accountDetails.CollectionDate == null) ? NOT_COLLECTED : accountDetails.CollectionDate.Value.ToString(StringConstants.Date.DEFAULT);
                        txtReceiptNumber.Text = accountDetails.OfficialReceiptNumber.ToString();
                        txtAmountCollected.Text = (accountDetails.CollectedValue > 0) ? $"{accountDetails.CollectedValue:N2}" : "";
                        txtBalance.Text = $"{accountDetails.Balance:N2}";
                        txtStatus.Text = accountDetails.Purpose;
                        btnCollectAccount.Text = (txtCollectionDate.Text == NOT_COLLECTED) ? MessagesConstants.Action.COLLECT : MessagesConstants.Action.UPDATE;
                        txtAccountRemarks.Text = accountDetails.Remarks;
                        btnCollectAccount.Enabled = true;
                        btnUpdateRemarks.Enabled = true;
                        txtAccountRemarks.ReadOnly = false;
                    }
                    else
                    {
                        txtBilledValue.Text = NOT_RELEASED;
                    }
                }
                else
                {
                    txtBilledValue.Text = StringConstants.Status.NO_DATA;
                }

                if (!isBillingReleased)
                {
                    txtBilledValue.Text = StringConstants.Status.NOT_RELEASED;
                    txtAccountRemarks.ReadOnly = true;
                    btnUpdateRemarks.Enabled = false;
                    btnCollectAccount.Enabled = false;
                }

                bool isStatusUpdateEnabled = txtStatus.Text == COLLECTING;
                btnForAdjustment.Enabled = btnForRebilling.Enabled = isStatusUpdateEnabled;
            }
        }

        private void ClearAccountInformation(Control container)
        {
            foreach (Control control in container.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Text = "";
                }

                if (control is GroupBox groupBox)
                {
                    ClearAccountInformation(groupBox);
                }
            }
        }








        private void btnCloseDetails_Click(object sender, EventArgs e)
        {
            CloseDetails();
        }

        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            CollectAccountForm form = new()
            {
                ParentControl = this,
                BillingID = CurrentViewingBillingCompleteInfo.ID,
                AccountNumber = cmbStatementOfAccounts.Text,
                BillingValue = (txtBilledValue.Text != "") ? Convert.ToDecimal(txtBilledValue.Text) : 0,
                OfficialReceiptNumber = txtReceiptNumber.Text,
                CollectionDate = (txtCollectionDate.Text != NOT_COLLECTED) ? Convert.ToDateTime(txtCollectionDate.Text) : DateTime.Now,
                EntryType = cmbStatementOfAccounts.Tag.ToString() ?? "",
            };
            form.ShowDialog();
        }

        private void btnViewAccountRecord_Click(object sender, EventArgs e)
        {
            if (cmbStatementOfAccounts.Text == "Nothing Found") { return; }

            object lockStatus = dgvBillings.SelectedRows[0].Cells["LockStatus"].Value;
            string? accountNumber = cmbStatementOfAccounts.Text.ToString();
            bool isCollected = txtCollectionDate.Text == NOT_COLLECTED;
            bool isInCollectionMode = txtStatus.Text == COLLECTING || txtStatus.Text == COLLECTED;

            ViewAccountBillings accountsForm = new()
            {
                ParentControl = this,
                BillingID = CurrentViewingBillingCompleteInfo.ID,
                AccountNumber = accountNumber,
                BillingName = selectedBillingName,
                IsReleased = (string)lockStatus == "🔒" && !isCollected && isInCollectionMode,
                AccountType = cmbStatementOfAccounts.Tag.ToString() ?? string.Empty,
            };

            accountsForm.ShowDialog();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            AddAccountForm form = new()
            {
                ParentControl = this,
                BillingName = selectedBillingName
            };

            form.ShowDialog();
        }

        private async void btnUpdateRemarks_Click(object sender, EventArgs e)
        {
            Models.Billing.Account newAccountInfo = new()
            {
                BillingID = BillingID,
                AccountNumber = cmbStatementOfAccounts.Text,
                Remarks = txtAccountRemarks.Text
            };

            bool isUpdated = await BillingAccountService.UpdateRemarks(newAccountInfo);

            if (isUpdated)
            {
                MessageBox.Show("You have successfully updated this account's remarks information.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("There is a problem updating this account's remarks information.", MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pnlLeftBody_EnabledChanged(object sender, EventArgs e)
        {
            if (FindForm() is frmMain FrmMain)
            {
                FrmMain.pnlSideNav.Enabled = pnlLeftBody.Enabled;
            }
        }

        private void cmbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClient.Items.Count > 0)
            {
                var selectedClient = (Models.Client)cmbClient.SelectedItem;
                ClientID = selectedClient.ID;
                ClientName = selectedClient.Name;
                BillingID = 0;
            }
            else
            {
                ClientID = 0;
                ClientName = "";
            }

            ApplySearchThenPopulate();
        }

        // Table Events and Context Menu

        private void dgvBillings_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvBillings.Rows[e.RowIndex].Selected = true;
                var location = dgvBillings.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;

                string? timekeepValue = dgvBillings.SelectedRows[0].Cells["ConstantJSON"].Value.ToString();
                string? verifiedValue = dgvBillings.SelectedRows[0].Cells["VerificationStatus"].Value.ToString();
                string? accrualsValue = dgvBillings.SelectedRows[0].Cells["AccrualsJSON"].Value.ToString();

                cntxtMenuViewVerify.Enabled = !string.IsNullOrEmpty(timekeepValue);
                cntxtMenuRelease.Enabled = !isBillingReleased && (!string.IsNullOrEmpty(timekeepValue) && !string.IsNullOrEmpty(verifiedValue) && !string.IsNullOrEmpty(accrualsValue));
                cntxtMenuUpload.Enabled = !isBillingReleased;

                menuExportBilling.Enabled = !string.IsNullOrEmpty(verifiedValue);
                menuExportBalancing.Enabled = !string.IsNullOrEmpty(verifiedValue) && !string.IsNullOrEmpty(accrualsValue);
                menuExportLetter.Enabled = !string.IsNullOrEmpty(accrualsValue);

                cntxtMenuArchive.Enabled = !isBillingReleased;

                cntxtBillingActions.Show(dgvBillings, location);
            }
        }

        //DONE
        private void cntxtMenuViewVerify_Click(object sender, EventArgs e)
        {
            var (constantEntries, editableEntries) = BillingService.GetConstantAndEditableJSON(BillingID);

            if (constantEntries.Count == 0 || editableEntries.Count == 0) return;

            string? dateQuarter = dgvBillings.SelectedRows[0].Cells["QuarterName"].Value.ToString();
            string? startDate = dgvBillings.SelectedRows[0].Cells["FormattedStartDate"].Value.ToString();
            string? endDate = dgvBillings.SelectedRows[0].Cells["FormattedEndDate"].Value.ToString();

            EmployeeTimekeepReviewForm form = new()
            {
                BillingID = BillingID,
                ClientID = ClientID,
                ConstantEntries = constantEntries,
                EditableEntries = editableEntries,
                ParentControl = this,
                BillingName = selectedBillingName,
                DateQuarter = dateQuarter,
                DateCoverage = $"{startDate} - {endDate}",
                LockStatus = (isBillingReleased) ? "Lock" : "Unlock"
            };
            form.ShowDialog();
        }

        private void cntxtMenuRelease_Click(object sender, EventArgs e)
        {
            ReleaseBillingForm form = new()
            {
                BillingID = BillingID,
                ClientID = ClientID,
                ParentControl = this,
            };
            form.ShowDialog();
        }

        // DONE
        private void menuUploadTimekeep_Click(object sender, EventArgs e)
        {
            string Type = StringConstants.Operations.NEW;
            string? verifiedValue = dgvBillings.SelectedRows[0].Cells["VerificationStatus"].Value.ToString();

            bool isVerified = !(verifiedValue == null || verifiedValue == string.Empty);

            if (dgvBillings.SelectedRows[0].Cells["ConstantJSON"].Value.ToString() != "")
            {
                var output = MessageBox.Show("Are you sure you want to overwrite new file to this billing? All your saved or current progress in this billing will be remove and overwritten.", "File Upload Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (output == DialogResult.Yes)
                {
                    Type = StringConstants.Operations.OVERWRITE;
                }
                else if (output == DialogResult.No)
                {
                    return;
                }
            }

            UploadFileForm uploadFileForm = new()
            {
                ParentControl = this,
                ClientID = ClientID,
                BillingID = BillingID,
                Type = Type,
                IsVerified = isVerified,
                BillingName = selectedBillingName,
            };
            uploadFileForm.ShowDialog();
        }

        // DONE
        private void menuUploadAccruals_Click(object sender, EventArgs e)
        {
            if (dgvBillings.SelectedRows[0].Cells["AccrualsJSON"].Value.ToString() != "")
            {
                var output = MessageBox.Show("Are you sure you want to overwrite new accrual file to this billing?", "File Upload Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (output == DialogResult.No)
                {
                    return;
                }
            }

            UploadAccrualsForm form = new()
            {
                ParentControl = this,
                BillingID = BillingID,
                BillingName = selectedBillingName
            };
            form.ShowDialog();
        }

        //DONE
        private void menuExportBilling_Click(object sender, EventArgs e)
        {
            if (dgvBillings.SelectedRows[0].Cells["ConstantJSON"].Value.ToString() == "")
            {
                MessageBox.Show("Please upload a timekeeping file to this billing before you can proceed with the verification of employee timekeeping information.", "Verify Billing Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dgvBillings.SelectedRows[0].Cells["VerificationStatus"].Value.ToString() == "")
            {
                MessageBox.Show("Please verify the timekeeping information of the employees to proceed with exporting this billing. If you haven't, please upload an Excel file first containing a report and timekeeping work sheet.", "Export Billing Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var (constantEntries, editableEntries) = BillingService.GetConstantAndEditableJSON(BillingID);

            if (constantEntries.Count == 0 || editableEntries.Count == 0)
            {
                MessageBox.Show("Error in getting the entry data of this billing. Please call for support.", "Error Loading Employee Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var filePath = FileManager.ChooseSavingPath($"({ClientName}) {selectedBillingName} Register Report");
            if (filePath == null) return;

            string exportType = (isBillingReleased) ? "Released" : "Unreleased";

            frmLoading loadingForm = new()
            {
                BooleanProcess = Task.Run(() => ExcelService.ExportBilling(BillingID, ClientID, editableEntries, selectedBillingName, filePath, exportType, new List<Guid>())),
                Description = "Generating a report, please wait ..."
            };

            var result = loadingForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                MessageBox.Show($"Export of '{selectedBillingName}' billing register report is complete.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (result == DialogResult.Abort)
            {
                MessageBox.Show($"There seems to be a problem exporting this file. If you are overwriting this to an existing file, make sure that the selected file is not currently open.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // DONE
        private void menuExportBalancing_Click(object sender, EventArgs e)
        {
            var filePath = FileManager.ChooseSavingPath($"({ClientName}) {selectedBillingName} Balancing Report");
            if (filePath == null) return;

            frmLoading loadingForm = new()
            {
                BooleanProcess = Task.Run(() => ExcelService.ExportBalancing(ClientID, BillingID, filePath)),
                Description = "Generating a report, please wait ..."
            };

            var result = loadingForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                MessageBox.Show($"Export of '{selectedBillingName}' balancing report is complete.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (result == DialogResult.Abort)
            {
                //MessageBox.Show($"There seems to be a problem exporting this file. If you are overwriting this to an existing file, make sure that the selected file is not currently open.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // DONE
        private void menuExportTransmittal_Click(object sender, EventArgs e)
        {
            var filePath = FileManager.ChooseSavingPath($"({ClientName}) {selectedBillingName} Transmittal Report");
            if (filePath == null) return;

            frmLoading loadingForm = new()
            {
                BooleanProcess = Task.Run(() => TransmittalService.ExportSummary(BillingID, ClientID, filePath)),
                Description = "Generating a report, please wait ..."
            };

            var result = loadingForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                MessageBox.Show($"Export of '{selectedBillingName}' transmittal report is complete.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (result == DialogResult.Abort)
            {
                MessageBox.Show($"There seems to be a problem exporting this file. If you are overwriting this to an existing file, make sure that the selected file is not currently open.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // DONE
        private async void cntxtMenuArchive_Click(object sender, EventArgs e)
        {
            if (BillingID == 0) return;
            var output = MessageBox.Show("Are you sure you want to archive this billing record?", "Archive Billing Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (output == DialogResult.No) return;
            if (await Task.Run(() => BillingService.UpdateStatusByID(BillingID, StringConstants.Status.INACTIVE)))
            {
                MessageBox.Show($"You have successfully archived the {selectedBillingName} billing.", "Archive Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                await LoggingService.AddLog(new()
                {
                    UserID = UserService.CurrentUser.ID,
                    Type = "Archive",
                    Details = $"This user has archive a billing with a name of {selectedBillingName}."
                });

                ApplySearchThenPopulate();
            }
        }
    }
}
