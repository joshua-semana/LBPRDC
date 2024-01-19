using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;
using OfficeOpenXml.Drawing.Chart;

namespace LBPRDC.Source.Views.Billing
{
    public partial class BillingControl : UserControl
    {
        private string? OfficerName = "";
        private string? OfficerPosition = "";

        public BillingControl()
        {
            InitializeComponent();
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
            ControlUtils.ClearInputs(pnlRightBody);
            ControlUtils.ClearInputs(grpBillingInformation);
            ControlUtils.ClearInputs(grpStatementOfAccounts);
        }

        public void FetchAccountAndPopulate()
        {
            if (cmbStatementOfAccounts.Text != "Nothing Found")
            {
                string? billingName = dgvBillings.SelectedRows[0].Cells["Name"].Value.ToString();
                string? accountNumber = cmbStatementOfAccounts.Text.ToString();

                frmLoading form = new()
                {
                    BillingAccountProcess = Task.Run(() => BillingService.GetAccountDetails(accountNumber, billingName))
                };

                var output = form.ShowDialog();

                if (output == DialogResult.OK)
                {
                    PopulateAccountInformation(form.BillingAccountResult, true);
                    btnUpdateAccount.Enabled = true;
                }
                else if (output == DialogResult.Abort)
                {
                    MessageBox.Show("There's a problem retrieving the information of this statement of account, please try again.", "Error Retrieving Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnUpdateAccount.Enabled = false;
                }
            }
            else
            {
                PopulateAccountInformation(null, false);
            }
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
            //ShowLoadingProgressBar(true);
            var (Items, TotalCount) = await Task.Run(() => BillingService.GetFilteredItems(searchWord));

            dgvBillings.Columns.Clear();
            dgvBillings.AutoGenerateColumns = false;
            ApplySettingsToTable();
            lblRowCounter.Text = ControlUtils.GetTableRowCount(Items.Count, TotalCount, "billing");
            dgvBillings.DataSource = Items;

            //ShowLoadingProgressBar(false);
        }

        private void ApplySettingsToTable()
        {
            ControlUtils.AddColumn(dgvBillings, "LockStatus", "", "LockStatus");
            ControlUtils.AddColumn(dgvBillings, "Name", "Billing Name", "Name");
            ControlUtils.AddColumn(dgvBillings, "QuarterName", "Quarter", "QuarterName");
            ControlUtils.AddColumn(dgvBillings, "FormattedStartDate", "Start Date", "FormattedStartDate");
            ControlUtils.AddColumn(dgvBillings, "FormattedEndDate", "End Date", "FormattedEndDate");
            ControlUtils.AddColumn(dgvBillings, "ConstantJSON", "Timekeep", "ConstantJSON");
            ControlUtils.AddColumn(dgvBillings, "VerificationStatus", "Verified", "VerificationStatus");
            ControlUtils.AddColumn(dgvBillings, "AccrualsJSON", "Accruals", "AccrualsJSON");
            //dgvBillings.Columns[dgvBillings.Columns["VerificationStatus"].Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    dgvBillings.Rows[e.RowIndex].Selected = true;
                    var location = dgvBillings.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;

                    string? lockStatusValue = dgvBillings.SelectedRows[0].Cells["LockStatus"].Value.ToString();
                    string? timekeepValue = dgvBillings.SelectedRows[0].Cells["ConstantJSON"].Value.ToString();
                    string? verifiedValue = dgvBillings.SelectedRows[0].Cells["VerificationStatus"].Value.ToString();
                    string? accrualsValue = dgvBillings.SelectedRows[0].Cells["AccrualsJSON"].Value.ToString();

                    cntxtMenuViewVerify.Enabled = !string.IsNullOrEmpty(timekeepValue);
                    cntxtMenuRelease.Enabled = lockStatusValue == "🔓" && (!string.IsNullOrEmpty(timekeepValue) && !string.IsNullOrEmpty(verifiedValue) && !string.IsNullOrEmpty(accrualsValue));
                    cntxtMenuUpload.Enabled = lockStatusValue == "🔓";

                    menuExportBilling.Enabled = !string.IsNullOrEmpty(verifiedValue);
                    menuExportBalancing.Enabled = !string.IsNullOrEmpty(verifiedValue) && !string.IsNullOrEmpty(accrualsValue);
                    menuExportLetter.Enabled = !string.IsNullOrEmpty(accrualsValue);

                    cntxtMenuArchive.Enabled = lockStatusValue == "🔓";

                    cntxtBillingActions.Show(dgvBillings, location);
                }
            }
        }

        private void cntxtMenuViewVerify_Click(object sender, EventArgs e)
        {
            var (constantEntries, editableEntries) = BillingService.GetConstantAndEditableJSON(dgvBillings.SelectedRows[0].Cells["Name"].Value.ToString());

            if (constantEntries.Count == 0 || editableEntries.Count == 0) return;

            string? lockStatusValue = dgvBillings.SelectedRows[0].Cells["LockStatus"].Value.ToString();
            string? billingName = dgvBillings.SelectedRows[0].Cells["Name"].Value.ToString();
            string? dateQuarter = dgvBillings.SelectedRows[0].Cells["QuarterName"].Value.ToString();
            string? startDate = dgvBillings.SelectedRows[0].Cells["FormattedStartDate"].Value.ToString();
            string? endDate = dgvBillings.SelectedRows[0].Cells["FormattedEndDate"].Value.ToString();

            EmployeeTimekeepReviewForm form = new()
            {
                ConstantEntries = constantEntries,
                EditableEntries = editableEntries,
                ParentControl = this,
                BillingName = billingName,
                DateQuarter = dateQuarter,
                DateCoverage = $"{startDate} - {endDate}",
                LockStatus = (lockStatusValue == "🔓") ? "Unlock" : "Lock"
            };
            form.ShowDialog();
        }

        private void cntxtMenuDuplicate_Click(object sender, EventArgs e)
        {
            BillingInformationForm form = new()
            {
                BillingName = dgvBillings.SelectedRows[0].Cells["Name"].Value.ToString(),
                Type = "Duplicate",
                ParentControl = this,
            };
            form.ShowDialog();
        }

        private void cntxtMenuRelease_Click(object sender, EventArgs e)
        {
            ReleaseBillingForm form = new()
            {
                BillingName = dgvBillings.SelectedRows[0].Cells["Name"].Value.ToString(),
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
                BillingName = Convert.ToString(dgvBillings.SelectedRows[0].Cells["Name"].Value),
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
                BillingName = Convert.ToString(dgvBillings.SelectedRows[0].Cells["Name"].Value),
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

            string? billingName = dgvBillings.SelectedRows[0].Cells["Name"].Value.ToString();
            var (constantEntries, editableEntries) = BillingService.GetConstantAndEditableJSON(dgvBillings.SelectedRows[0].Cells["Name"].Value.ToString());

            if (constantEntries.Count == 0 || editableEntries.Count == 0)
            {
                MessageBox.Show("Error in getting the entry data of this billing. Please call for support.", "Error Loading Employee Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var filePath = FileManager.ChooseSavingPath($"{billingName} Register Report");
            if (filePath == null) return;

            string exportType = (dgvBillings.SelectedRows[0].Cells[0].Value.ToString() == "🔓") ? "Unreleased" : "Released";

            frmLoading loadingForm = new()
            {
                BooleanProcess = Task.Run(() => ExcelService.ExportBilling(editableEntries, billingName, filePath, exportType, new List<Guid>())),
                Description = "Generating a report, please wait ..."
            };

            var result = loadingForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                MessageBox.Show($"Export of '{billingName}' billing register report is complete.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (result == DialogResult.Abort)
            {
                MessageBox.Show($"There seems to be a problem exporting this file. If you are overwriting this to an existing file, make sure that the selected file is not currently open.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuExportBalancing_Click(object sender, EventArgs e)
        {
            string? billingName = dgvBillings.SelectedRows[0].Cells["Name"].Value.ToString();

            var filePath = FileManager.ChooseSavingPath($"{billingName} Balancing Report");
            if (filePath == null) return;

            frmLoading loadingForm = new()
            {
                BooleanProcess = Task.Run(() => ExcelService.ExportBalancing(billingName, filePath)),
                Description = "Generating a report, please wait ..."
            };

            var result = loadingForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                MessageBox.Show($"Export of '{billingName}' balancing report is complete.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (result == DialogResult.Abort)
            {
                MessageBox.Show($"There seems to be a problem exporting this file. If you are overwriting this to an existing file, make sure that the selected file is not currently open.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void cntxtMenuArchive_Click(object sender, EventArgs e)
        {
            string? billingName = dgvBillings.SelectedRows[0].Cells["Name"].Value.ToString();
            var output = MessageBox.Show("Are you sure you want to archive this billing record?", "Archive Billing Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (output == DialogResult.No) return;
            if (await Task.Run(() => BillingService.UpdateStatus(billingName, "Inactive")))
            {
                MessageBox.Show($"You have successfully archived the {billingName} billing.", "Archive Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (UserService.CurrentUser != null)
                {
                    LoggingService.Log newLog = new()
                    {
                        UserID = UserService.CurrentUser.UserID,
                        ActivityType = "Archive",
                        ActivityDetails = $"This user has archive a billing with a name of {billingName}."
                    };
                    LoggingService.LogActivity(newLog);
                }
                ApplySearchThenPopulate();
            }
        }

        private void PopulateBillingDetails(Services.Billing billingDetails)
        {
            if (billingDetails == null) { return; }

            OfficerName = billingDetails.OfficerName;
            OfficerPosition = billingDetails.OfficerPosition;

            txtCreationDate.Text = billingDetails.Timestamp.ToString("MMMM dd, yyyy");
            txtReleaseDate.Text = (billingDetails.ReleaseDate.HasValue) ? billingDetails.ReleaseDate.Value.ToString("MMMM dd, yyyy") : "Not Yet Released";
            txtDescription.Text = billingDetails.Description;
            txtOICandPosition.Text = billingDetails.OfficerName + " / " + billingDetails.OfficerPosition;
        }

        private void PopulateStatementOfAccountsCollection(List<string> collection)
        {
            cmbStatementOfAccounts.Items.Clear();
            btnViewAccountRecord.Enabled = cmbStatementOfAccounts.Enabled = collection.Count > 0;
            if (collection.Count > 0)
            {
                cmbStatementOfAccounts.Items.AddRange(collection.ToArray());
            }
            else
            {
                cmbStatementOfAccounts.Items.Add("Nothing Found");
            }
            cmbStatementOfAccounts.SelectedIndex = 0;

            btnUpdateAccount.Enabled = (cmbStatementOfAccounts.Text != "Nothing Found");
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (dgvBillings.SelectedRows.Count > 0)
            {
                string? billingName = dgvBillings.SelectedRows[0].Cells["Name"].Value.ToString();
                frmLoading form = new()
                {
                    BillingProcess = Task.Run(() => BillingService.GetSpecificBillingDetailsByName(billingName)),
                    StringListProcess = Task.Run(() => BillingService.GetAccountNumbersByName(billingName)),
                    Description = "Retrieving information, please wait ..."
                };

                var output = form.ShowDialog();

                if (output == DialogResult.OK)
                {
                    pnlLeft.Enabled = false;
                    PopulateBillingDetails(form.BillingResult);
                    PopulateStatementOfAccountsCollection(form.StringListResult);
                    pnlRight.Visible = true;
                }
                else if (output == DialogResult.Abort)
                {
                    MessageBox.Show("There is a problem retrieving the information of this billing, please try again.", "Error Retreiving Billing Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                BillingName = dgvBillings.SelectedRows[0].Cells["Name"].Value.ToString(),
                Type = "Update",
                ParentControl = this,
                BillingInformation = new Services.Billing
                {
                    Description = txtDescription.Text,
                    OfficerName = OfficerName,
                    OfficerPosition = OfficerPosition
                }
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
                    BillingName = dgvBillings.SelectedRows[0].Cells["Name"].Value?.ToString(),
                    AccountNumber = cmbStatementOfAccounts.Text,
                    BillingValue = (txtBilledValue.Text != "") ? Convert.ToDecimal(txtBilledValue.Text) : 0,
                    AmountCollected = (txtAmountCollected.Text != "") ? Convert.ToDecimal(txtAmountCollected.Text) : 0,
                    OfficialReceiptNumber = (txtReceiptNumber.Text != "") ? Convert.ToInt32(txtReceiptNumber.Text) : -1,
                    CollectionDate = (txtCollectionDate.Text != "Not Yet Collected") ? Convert.ToDateTime(txtCollectionDate.Text) : DateTime.Now,
                    Remarks = txtRemarks.Text
                };
                form.ShowDialog();
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbStatementOfAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            FetchAccountAndPopulate();
        }

        private void PopulateAccountInformation(BillingAccount? account, bool hasBillingRecord)
        {
            if (account != null)
            {
                txtBilledValue.Text = $"{account.BilledValue:N2}";
                txtNetBilling.Text = $"{account.NetBilling:N2}";
                txtCollectionDate.Text = (account.CollectionDate == null) ? "Not Yet Collected" : account.CollectionDate.Value.ToString("MMMM dd, yyyy");
                txtReceiptNumber.Text = (account.OfficialReceiptNumber == -1) ? "" : account.OfficialReceiptNumber.ToString();
                txtAmountCollected.Text = (account.CollectedValue == -1) ? "" : account.CollectedValue.ToString();
                txtRemarks.Text = account.Remarks;
                btnUpdateAccount.Enabled = true;
            }
            else
            {
                txtBilledValue.Text = (hasBillingRecord) ? "Not Yet Released" : "";
                btnUpdateAccount.Enabled = false;
            }
        }

        private void btnViewAccountRecord_Click(object sender, EventArgs e)
        {
            if (cmbStatementOfAccounts.Text != "Nothing Found")
            {
                string? billingName = dgvBillings.SelectedRows[0].Cells["Name"].Value.ToString();
                string? accountNumber = cmbStatementOfAccounts.Text.ToString();

                frmLoading form = new()
                {
                    BillingRecordProcess = Task.Run(() => BillingService.GetBillingRecordsByAccount(billingName, accountNumber)),
                    AccountsTotalValuesProcess = Task.Run(() => BillingService.GetGrossBillingAndDepartmentByName(billingName)),
                    Description = "Retrieving information, please wait..."
                };

                var output = form.ShowDialog();

                if (output == DialogResult.OK)
                {
                    if (form.BillingRecordResult == null)
                    {
                        MessageBox.Show("There is a problem retrieving the billing records of this account. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    ViewAccountBillings accountsForm = new()
                    {
                        ParentControl = this,
                        AccountNumber = accountNumber,
                        BillingName = billingName ?? "Billing Records",
                        BillingRecords = form.BillingRecordResult,
                        AccountsTotalValues = form.AccountsTotalValuesResult
                    };

                    accountsForm.ShowDialog();
                }
                else if (output == DialogResult.Abort)
                {
                    MessageBox.Show("There is a problem retrieving the billing records of this account. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
