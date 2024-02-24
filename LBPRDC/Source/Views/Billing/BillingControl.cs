using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;
using System.Windows.Forms;

namespace LBPRDC.Source.Views.Billing
{
    public partial class BillingControl : UserControl
    {
        UserControl loadingControl = new ucLoading() { Dock = DockStyle.Fill };

        private string? OfficerName = "";
        private string? OfficerPosition = "";

        private readonly string NOT_RELEASED = "Not Yet Released";
        private readonly string NOT_COLLECTED = "Not Yet Collected";
        private readonly string COLLECTING = "Still Collecting";
        private readonly string COLLECTED = "Collected";

        private string selectedBillingName = "";
        private bool isBillingReleased = false;
        

        public BillingControl()
        {
            InitializeComponent();
            this.Controls.Add(loadingControl);
            loadingControl.BringToFront();
        }

        public void ApplySearchThenPopulate()
        {
            string searchWord = txtSearch.Text.Trim().ToLower();
            PopulateTableWithSearch(searchWord);
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
                ApplySearchThenPopulate();
            }
        }

        private async void PopulateTableWithSearch(string searchWord)
        {
            ShowLoadingProgressBar(true);
            var (Items, TotalCount) = await Task.Run(() => BillingService.GetFilteredItems(searchWord));

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
            bool hasNameColumn = dgvBillings.Columns.Cast<DataGridViewColumn>().Any(column => column.Name == "Name");
            bool hasLockStatusColumn = dgvBillings.Columns.Cast<DataGridViewColumn>().Any(column => column.Name == "LockStatus");

            if (dgvBillings.Rows.Count > 0 && dgvBillings.SelectedRows.Count > 0 && dgvBillings.Columns.Count > 0)
            {
                if (hasNameColumn)
                {
                    selectedBillingName = dgvBillings.SelectedRows[0].Cells["Name"].Value.ToString() ?? "";
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

        private void cntxtMenuViewVerify_Click(object sender, EventArgs e)
        {
            var (constantEntries, editableEntries) = BillingService.GetConstantAndEditableJSON(selectedBillingName);

            if (constantEntries.Count == 0 || editableEntries.Count == 0) return;

            string? dateQuarter = dgvBillings.SelectedRows[0].Cells["QuarterName"].Value.ToString();
            string? startDate = dgvBillings.SelectedRows[0].Cells["FormattedStartDate"].Value.ToString();
            string? endDate = dgvBillings.SelectedRows[0].Cells["FormattedEndDate"].Value.ToString();

            EmployeeTimekeepReviewForm form = new()
            {
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

        private void cntxtMenuDuplicate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedBillingName))
            {
                frmLoading form = new()
                {
                    EquipmentDetailsProcess = Task.Run(() => BillingAccountService.GetEquipmentDetails(selectedBillingName))
                };

                DialogResult result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    if (form.EquipmentDetailsResult != null)
                    {
                        var equipmentAccount = form.EquipmentDetailsResult;

                        BillingInformationForm billingInformationForm = new()
                        {
                            IsEquipmentIncluded = true,
                            EquipmentAccountNumber = equipmentAccount.AccountNumber,
                            EquipmentsAmount = equipmentAccount.BilledValue,
                            BillingName = selectedBillingName,
                            Type = "Duplicate",
                            ParentControl = this,
                        };
                        billingInformationForm.ShowDialog();
                    }
                    else
                    {
                        BillingInformationForm billingInformationForm = new()
                        {
                            IsEquipmentIncluded = false,
                            BillingName = selectedBillingName,
                            Type = "Duplicate",
                            ParentControl = this,
                        };
                        billingInformationForm.ShowDialog();
                    }
                }
                else if (result == DialogResult.Abort)
                {
                    MessageBox.Show("There's a problem retrieving the information of this billing, please try again.", "Error Retrieving Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cntxtMenuRelease_Click(object sender, EventArgs e)
        {
            ReleaseBillingForm form = new()
            {
                BillingName = selectedBillingName,
                ParentControl = this,
            };
            form.ShowDialog();
        }

        private void menuUploadTimekeep_Click(object sender, EventArgs e)
        {
            string uploadType = "New";
            if (dgvBillings.SelectedRows[0].Cells["ConstantJSON"].Value.ToString() != "")
            {
                var output = MessageBox.Show("Are you sure you want to overwrite new file to this billing? All your saved or current progress in this billing will be remove and overwritten.", "File Upload Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (output == DialogResult.Yes)
                {
                    uploadType = "Overwrite";
                }
                else if (output == DialogResult.No)
                {
                    return;
                }
            }

            UploadFileForm uploadFileForm = new()
            {
                BillingName = selectedBillingName,
                UploadType = uploadType,
                ParentControl = this,
            };
            uploadFileForm.ShowDialog();
        }

        private void menuUploadAccruals_Click(object sender, EventArgs e)
        {
            string uploadType = "New";
            if (dgvBillings.SelectedRows[0].Cells["AccrualsJSON"].Value.ToString() != "")
            {
                var output = MessageBox.Show("Are you sure you want to overwrite new accrual file to this billing?", "File Upload Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (output == DialogResult.Yes)
                {
                    uploadType = "Overwrite";
                }
                else if (output == DialogResult.No)
                {
                    return;
                }
            }

            UploadAccrualsForm form = new()
            {
                BillingName = selectedBillingName,
                UploadType = uploadType,
                ParentControl = this,
            };
            form.ShowDialog();
        }

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

            var (constantEntries, editableEntries) = BillingService.GetConstantAndEditableJSON(selectedBillingName);

            if (constantEntries.Count == 0 || editableEntries.Count == 0)
            {
                MessageBox.Show("Error in getting the entry data of this billing. Please call for support.", "Error Loading Employee Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var filePath = FileManager.ChooseSavingPath($"{selectedBillingName} Register Report");
            if (filePath == null) return;

            string exportType = (isBillingReleased) ? "Released" : "Unreleased";

            frmLoading loadingForm = new()
            {
                BooleanProcess = Task.Run(() => ExcelService.ExportBilling(editableEntries, selectedBillingName, filePath, exportType, new List<Guid>())),
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

        private void menuExportBalancing_Click(object sender, EventArgs e)
        {
            var filePath = FileManager.ChooseSavingPath($"{selectedBillingName} Balancing Report");
            if (filePath == null) return;

            frmLoading loadingForm = new()
            {
                BooleanProcess = Task.Run(() => ExcelService.ExportBalancing(selectedBillingName, filePath)),
                Description = "Generating a report, please wait ..."
            };

            var result = loadingForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                MessageBox.Show($"Export of '{selectedBillingName}' balancing report is complete.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (result == DialogResult.Abort)
            {
                MessageBox.Show($"There seems to be a problem exporting this file. If you are overwriting this to an existing file, make sure that the selected file is not currently open.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuExportTransmittal_Click(object sender, EventArgs e)
        {
            var filePath = FileManager.ChooseSavingPath($"{selectedBillingName} Transmittal Report");
            if (filePath == null) return;

            frmLoading loadingForm = new()
            {
                BooleanProcess = Task.Run(() => TransmittalService.ExportSummary(selectedBillingName, filePath)),
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

        private async void cntxtMenuArchive_Click(object sender, EventArgs e)
        {
            var output = MessageBox.Show("Are you sure you want to archive this billing record?", "Archive Billing Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (output == DialogResult.No) return;
            if (await Task.Run(() => BillingService.UpdateStatus(selectedBillingName, "Inactive")))
            {
                MessageBox.Show($"You have successfully archived the {selectedBillingName} billing.", "Archive Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (UserService.CurrentUser != null)
                {
                    LoggingService.Log newLog = new()
                    {
                        UserID = UserService.CurrentUser.UserID,
                        ActivityType = "Archive",
                        ActivityDetails = $"This user has archive a billing with a name of {selectedBillingName}."
                    };
                    LoggingService.LogActivity(newLog);
                }
                ApplySearchThenPopulate();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedBillingName))
            {
                ViewBillingDetails(selectedBillingName);
            }
        }

        private void btnCloseDetails_Click(object sender, EventArgs e)
        {
            CloseDetails();
        }

        private void btnUpdateBillingInformation_Click(object sender, EventArgs e)
        {
            BillingInformationForm form = new()
            {
                IsReleased = isBillingReleased,
                BillingName = selectedBillingName,
                Type = "Update",
                ParentControl = this,
                BillingInformation = new Services.Billing
                {
                    Description = txtDescription.Text,
                    OfficerName = OfficerName,
                    OfficerPosition = OfficerPosition,
                    Year = (int)dgvBillings.SelectedRows[0].Cells["Year"].Value,
                    Month = (int)dgvBillings.SelectedRows[0].Cells["Month"].Value,
                },
                IsEquipmentIncluded = (txtSuppliesAndEquipmentsAccount.Text != "None"),
                EquipmentAccountNumber = (txtSuppliesAndEquipmentsAccount.Text != "None") ? txtSuppliesAndEquipmentsAccount.Text : "",
                EquipmentsAmount = string.IsNullOrEmpty(txtSuppliesAndEquipmentsAmount.Text) ? 0 : Convert.ToDecimal(txtSuppliesAndEquipmentsAmount.Text)
            };
            form.ShowDialog();
        }

        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            try
            {
                CollectAccountForm form = new()
                {
                    ParentControl = this,
                    BillingName = selectedBillingName,
                    AccountNumber = cmbStatementOfAccounts.Text,
                    BillingValue = (txtBilledValue.Text != "") ? Convert.ToDecimal(txtBilledValue.Text) : 0,
                    OfficialReceiptNumber = txtReceiptNumber.Text,
                    CollectionDate = (txtCollectionDate.Text != NOT_COLLECTED) ? Convert.ToDateTime(txtCollectionDate.Text) : DateTime.Now,
                };
                form.ShowDialog();
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnViewAccountRecord_Click(object sender, EventArgs e)
        {
            if (cmbStatementOfAccounts.Text == "Nothing Found") { return; }

            object lockStatus = dgvBillings.SelectedRows[0].Cells["LockStatus"].Value;
            string? accountNumber = cmbStatementOfAccounts.Text.ToString();
            bool isCollected = txtCollectionDate.Text != NOT_COLLECTED;
            bool isInCollectionMode = txtStatus.Text == COLLECTING || txtStatus.Text == COLLECTED;

            ViewAccountBillings accountsForm = new()
            {
                ParentControl = this,
                AccountNumber = accountNumber,
                BillingName = selectedBillingName,
                IsReleased = (string)lockStatus == "🔒" && isCollected && isInCollectionMode,
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

        private void PopulateBillingDetails(BillingWithEquipment billingDetails)
        {
            ControlUtils.ClearInputs(pnlRightBody);
            ControlUtils.ClearInputs(grpBillingInformation);
            if (billingDetails == null)
            {
                txtCreationDate.Text = "Error retrieving data ...";
                txtReleaseDate.Text = "Error retrieving data ...";
                txtDescription.Text = "Error retrieving data ...";
                txtOICandPosition.Text = "Error retrieving data ...";
            }
            else
            {
                OfficerName = billingDetails.OfficerName;
                OfficerPosition = billingDetails.OfficerPosition;

                txtCreationDate.Text = billingDetails.Timestamp.ToString("MMMM dd, yyyy");
                txtReleaseDate.Text = (billingDetails.ReleaseDate.HasValue) ? billingDetails.ReleaseDate.Value.ToString("MMMM dd, yyyy") : NOT_RELEASED;
                txtDescription.Text = billingDetails.Description;
                txtOICandPosition.Text = billingDetails.OfficerName + " / " + billingDetails.OfficerPosition;

                string equipmentAccountNumber = billingDetails.EquipmentAccountNumber;

                txtSuppliesAndEquipmentsAccount.Text = equipmentAccountNumber;
                txtSuppliesAndEquipmentsAmount.Text = (equipmentAccountNumber != "None") ? $"{billingDetails.EquipmentBilledValue:N2}" : "";

            }
            btnUpdateBillingInformation.Enabled = billingDetails != null;
        }

        private void ViewBillingDetails(string billingName) // WHEN USER CLICKS THE VIEW DETAILS OF A BILLING
        {
            frmLoading form = new()
            {
                BillingWithEquipmentProcess = Task.Run(() => BillingService.GetSpecificBillingDetailsByName(billingName)),
                StringListProcess = Task.Run(() => BillingRecordService.GetAccountNumbersByName(billingName)),
                AccountsCollectionProcess = Task.Run(() => BillingAccountService.GetCustomEntryForComboBox(billingName)),
                Description = "Retrieving information, please wait ..."
            };

            var output = form.ShowDialog();

            if (output == DialogResult.OK)
            {
                PopulateBillingDetails(form.BillingWithEquipmentResult);
                cmbStatementOfAccounts.Items.Clear();

                if (form.StringListResult.Any())
                {
                    foreach (var accountName in form.StringListResult)
                    {
                        cmbStatementOfAccounts.Items.Add(new
                        {
                            Text = accountName,
                            Tag = "Regular Entry"
                        });
                    }
                }

                if (form.AccountsCollectionResult.Any())
                {
                    foreach (var account in form.AccountsCollectionResult)
                    {
                        cmbStatementOfAccounts.Items.Add(new
                        {
                            Text = account.AccountNumber,
                            Tag = account.EntryType // Custom Entry
                        });
                    }
                }

                if (cmbStatementOfAccounts.Items.Count < 1)
                {
                    cmbStatementOfAccounts.Items.Add(new
                    {
                        Text = "Nothing Found",
                        Tag = "Nothing"
                    });
                }

                cmbStatementOfAccounts.DisplayMember = "Text";
                cmbStatementOfAccounts.ValueMember = "Tag";

                pnlLeft.Enabled = false;
                pnlRight.Visible = true;

                cmbStatementOfAccounts.SelectedIndex = 0;
            }
            else if (output == DialogResult.Abort)
            {
                MessageBox.Show("There is a problem retrieving the information of this billing, please try again.", "Error Retreiving Billing Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pnlLeft.Enabled = true;
                pnlRight.Visible = false;
            }
        }

        private void cmbStatementOfAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pnlRight.Visible == true)
            {
                FetchAccountDetailsAndPopulate();
            }
            UpdateAccountComboBoxTag();
        }

        private void UpdateAccountComboBoxTag()
        {
            if (cmbStatementOfAccounts.SelectedItem != null)
            {
                var selectedItem = (dynamic)cmbStatementOfAccounts.SelectedItem;
                cmbStatementOfAccounts.Tag = selectedItem.Tag;
            }
        }

        public void FetchAccountDetailsAndPopulate()
        {
            if (cmbStatementOfAccounts.Text != "Nothing Found")
            {
                string? accountNumber = cmbStatementOfAccounts.Text.ToString();

                frmLoading form = new()
                {
                    BillingAccountProcess = Task.Run(() => BillingAccountService.GetDetails(accountNumber, selectedBillingName))
                };

                var output = form.ShowDialog();

                if (output == DialogResult.OK)
                {
                    PopulateAccountInformation(form.BillingAccountResult, true);
                }
                else if (output == DialogResult.Abort)
                {
                    MessageBox.Show("There's a problem retrieving the information of this statement of account, please try again.", "Error Retrieving Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnCollectAccount.Enabled = false;
                }
            }
            else
            {
                PopulateAccountInformation(null, false);
            }
        }

        private void PopulateAccountInformation(BillingAccount? account, bool hasBillingRecord)
        {
            //ControlUtils.ClearInputs(grpStatementOfAccounts);
            ControlUtils.ClearInputs(grpPurpose);

            if (account != null)
            {
                txtAccountRemarks.Text = account.Remarks;

                if (!isBillingReleased)
                {
                    txtBilledValue.Text = NOT_RELEASED;
                }
                else
                {
                    txtBilledValue.Text = $"{account.BilledValue:N2}";
                    txtNetBilling.Text = $"{account.NetBilling:N2}";
                    txtCollectionDate.Text = (account.CollectionDate == null) ? NOT_COLLECTED : account.CollectionDate.Value.ToString("MMMM dd, yyyy");
                    txtReceiptNumber.Text = account.OfficialReceiptNumber?.ToString();
                    txtAmountCollected.Text = (account.CollectedValue > 0) ? $"{account.CollectedValue:N2}" : "";
                    txtBalance.Text = $"{account.Balance:N2}";
                    txtStatus.Text = account.Purpose;
                    btnCollectAccount.Enabled = true;
                    txtAccountRemarks.ReadOnly = false;
                    btnUpdateRemarks.Enabled = true;
                    btnCollectAccount.Text = (txtCollectionDate.Text == NOT_COLLECTED) ? "Collect" : "Update";
                }
            }
            else
            {
                txtBilledValue.Text = (hasBillingRecord) ? NOT_RELEASED : "";
                txtAccountRemarks.ReadOnly = true;
                btnUpdateRemarks.Enabled = false;
                btnCollectAccount.Enabled = false;
            }

            bool isStatusUpdateEnabled = txtStatus.Text == COLLECTING;
            btnForAdjustment.Enabled = btnForRebilling.Enabled = isStatusUpdateEnabled;
        }

        private void btnUpdateRemarks_Click(object sender, EventArgs e)
        {
            BillingAccount newAccountInformation = new()
            {
                BillingName = selectedBillingName,
                AccountNumber = cmbStatementOfAccounts.Text,
                Remarks = txtAccountRemarks.Text
            };

            frmLoading form = new()
            {
                BooleanProcess = Task.Run(() => BillingAccountService.UpdateRemarks(newAccountInformation))
            };

            DialogResult result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                MessageBox.Show("You have successfully updated this account's remarks information.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (result == DialogResult.Abort)
            {
                MessageBox.Show("There is a problem updating this account's remarks information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pnlLeftBody_EnabledChanged(object sender, EventArgs e)
        {
            if (FindForm() is frmMain FrmMain)
            {
                FrmMain.pnlSideNav.Enabled = pnlLeftBody.Enabled;
            }
        }
    }
}
