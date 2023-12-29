using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;


namespace LBPRDC.Source.Views.Billing
{
    public partial class BillingControl : UserControl
    {
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
            ControlUtils.AddColumn(dgvBillings, "Name", "Billing Name", "Name");
            ControlUtils.AddColumn(dgvBillings, "QuarterName", "Quarter", "QuarterName");
            ControlUtils.AddColumn(dgvBillings, "FormattedStartDate", "Start Date", "FormattedStartDate");
            ControlUtils.AddColumn(dgvBillings, "FormattedEndDate", "End Date", "FormattedEndDate");
            ControlUtils.AddColumn(dgvBillings, "ConstantJSON", "File", "ConstantJSON");
            ControlUtils.AddColumn(dgvBillings, "VerificationStatus", "Verified", "VerificationStatus");
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

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (dgvBillings.Rows.Count > 0)
            {
                if (dgvBillings.SelectedRows[0].Cells[4].Value.ToString() != "")
                {
                    var output = MessageBox.Show("Are you sure you want to overwrite new file to this billing? All your saved or current progress in this billing will be remove and overwritten.", "File Upload Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (output == DialogResult.No) return;
                }

                UploadFileForm uploadFileForm = new()
                {
                    BillingName = Convert.ToString(dgvBillings.SelectedRows[0].Cells[0].Value),
                    ParentControl = this,
                };
                uploadFileForm.ShowDialog();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplySearchThenPopulate();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (dgvBillings.Rows.Count > 0)
            {
                if (dgvBillings.SelectedRows[0].Cells[4].Value.ToString() == "")
                {
                    MessageBox.Show("Please upload a timekeeping file to this billing before you can proceed with the verification of employee timekeeping information.", "Verify Billing Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var (constantEntries, editableEntries) = BillingService.LoadJSONData(dgvBillings.SelectedRows[0].Cells[0].Value.ToString());

                if (constantEntries.Count == 0 || editableEntries.Count == 0) return;

                string billingName = dgvBillings.SelectedRows[0].Cells[0].Value.ToString();
                string dateQuarter = dgvBillings.SelectedRows[0].Cells[1].Value.ToString();
                string fromDate = dgvBillings.SelectedRows[0].Cells[2].Value.ToString();
                string toDate = dgvBillings.SelectedRows[0].Cells[3].Value.ToString();

                EmployeeTimekeepReviewForm form = new()
                {
                    ConstantEntries = constantEntries,
                    EditableEntries = editableEntries,
                    ParentControl = this,
                    BillingName = billingName,
                    DateQuarter = dateQuarter,
                    DateCoverage = $"{fromDate} - {toDate}"
                };
                form.ShowDialog();
            }
        }

        private async void btnArchive_Click(object sender, EventArgs e)
        {
            if (dgvBillings.SelectedRows.Count > 0)
            {
                string billingName = dgvBillings.SelectedRows[0].Cells[0].Value.ToString();
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
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvBillings.SelectedRows.Count > 0)
            {
                if (dgvBillings.SelectedRows[0].Cells[4].Value.ToString() == "")
                {
                    MessageBox.Show("Please upload a timekeeping file to this billing before you can proceed with the verification of employee timekeeping information.", "Verify Billing Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dgvBillings.SelectedRows[0].Cells[5].Value.ToString() == "")
                {
                    MessageBox.Show("Please verify the timekeeping information of the employees to proceed with exporting this billing. If you haven't, please upload an Excel file first containing a report and timekeeping work sheet.", "Export Billing Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string billingName = dgvBillings.SelectedRows[0].Cells[0].Value.ToString();
                var (constantEntries, editableEntries) = BillingService.LoadJSONData(dgvBillings.SelectedRows[0].Cells[0].Value.ToString());

                if (constantEntries.Count == 0 || editableEntries.Count == 0)
                {
                    MessageBox.Show("Error in getting the entry data of this billing. Please call for support.", "Error Loading Employee Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ExcelService.ExportBilling(editableEntries, billingName);
            }
        }
    }
}
