using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;
using static LBPRDC.Source.Views.Shared.DynamicCheckedListBoxControl;

namespace LBPRDC.Source.Views.Logs
{
    public partial class LogsControl : UserControl
    {
        readonly UserControl loadingControl = new ucLoading() { Dock = DockStyle.Fill };

        public LogsControl()
        {
            InitializeComponent();
            this.Controls.Add(loadingControl);
            loadingControl.BringToFront();
        }

        private async void LogsControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                await GetFilters();
                ApplyFilterAndSearchThenPopulate();
            }
        }

        private void ApplyFilterAndSearchThenPopulate()
        {
            List<string> types = dchkListFilterType.GetCheckedItems().Select(s => s.Name).ToList();
            string searchWord = txtSearch.Text.Trim().ToLower();

            PopulateTableWithFilterAndSearch(types, searchWord);
        }

        private async Task GetFilters()
        {
            var types = await LoggingService.GetAllDistinctTypes(dtpDate.Value);
            dchkListFilterType.SetItems(types.Select(s => new CheckedListBoxItems(0, s)).ToList());
            dchkListFilterType.DisplayItems();
        }

        private async void PopulateTableWithFilterAndSearch(List<string> types, string searchWord)
        {
            ShowLoadingProgressBar(true);
            var (Items, TotalCount) = await LoggingService.GetFilteredItems(types, searchWord, dtpDate.Value);

            dgvLogs.Columns.Clear();
            dgvLogs.AutoGenerateColumns = false;
            ApplySettingsToTable();
            lblRowCounter.Text = ControlUtils.GetTableRowCount(Items.Count, TotalCount, "log");
            dgvLogs.DataSource = Items;

            ShowLoadingProgressBar(false);
        }

        private void ApplySettingsToTable()
        {
            ControlUtils.AddColumn(dgvLogs, "ID", "ID", "ID", true, true);
            ControlUtils.AddColumn(dgvLogs, "UserID", "User ID", "UserID", true, true);
            ControlUtils.AddColumn(dgvLogs, "FullName", "User Name", "FullName", true, true);
            ControlUtils.AddColumn(dgvLogs, "Type", "Type", "Type", true, true);
            ControlUtils.AddColumn(dgvLogs, "Details", "Details", "Details", true, true);
            ControlUtils.AddColumn(dgvLogs, "Timestamp", "Date & Time", "Timestamp", true, true);
        }

        private void ResetTableSearchFilter()
        {
            dtpDate.Value = DateTime.Now;
            txtSearch.Text = string.Empty;
            ControlUtils.ResetFilters(flowFilters);
            ApplyFilterAndSearchThenPopulate();
        }

        private void ShowLoadingProgressBar(bool state)
        {
            loadingControl.Visible = state;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetTableSearchFilter();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            ApplyFilterAndSearchThenPopulate();
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ApplyFilterAndSearchThenPopulate();
            }
        }

        private async void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            dchkListFilterType.ClearCheckedItems();
            await GetFilters();
            ApplyFilterAndSearchThenPopulate();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFilterAndSearchThenPopulate();
        }
    }
}
