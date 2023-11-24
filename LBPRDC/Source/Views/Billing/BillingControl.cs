using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;
using Microsoft.VisualBasic;

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
            ControlUtils.AddColumn(dgvBillings, "FullName", "Created By", "FullName");
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
            UploadFileForm uploadFileForm = new();
            uploadFileForm.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplySearchThenPopulate();
        }
    }
}
