
using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;
using LBPRDC.Source.Views.Shared;
using static LBPRDC.Source.Views.Shared.DynamicCheckedListBoxControl;

namespace LBPRDC.Source.Views.Logs
{
    public partial class LogsControl : UserControl
    {
        UserControl loadingControl = new ucLoading() { Dock = DockStyle.Fill };

        public LogsControl()
        {
            InitializeComponent();
            this.Controls.Add(loadingControl);
            loadingControl.BringToFront();
        }

        public void ApplyFilterAndSearchThenPopulate()
        {
            List<string> types = dchkListFilterType.GetCheckedItems().Select(s => s.Name).ToList();
            string searchWord = txtSearch.Text.Trim().ToLower();

            PopulateTableWithFilterAndSearch(types, searchWord);
        }

        public void ResetTableSearchFilter()
        {
            txtSearch.Text = string.Empty;
            ControlUtils.ResetFilters(flowFilters);
            ApplyFilterAndSearchThenPopulate();
        }

        private void LogsControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                ApplyFilterAndSearchThenPopulate();
                PopulateFilters();
            }
        }

        private void PopulateFilters()
        {
            InitializeFilter(
                dchkListFilterType,
                LoggingService.GetAllItems()
                    .DistinctBy(d => d.ActivityType)
                    .Select(s => new CheckedListBoxItems(0, s.ActivityType))
                    .ToList()
            );
        }

        private void InitializeFilter(DynamicCheckedListBoxControl control, List<CheckedListBoxItems> items)
        {
            if (items.Count > 0)
            {
                control.SetItems(items);
                control.DisplayItems();
            }
        }

        private async void PopulateTableWithFilterAndSearch(List<string> types, string searchWord)
        {
            ShowLoadingProgressBar(true);
            var logs = await Task.Run(() => LoggingService.GetAllItems());
            logs = logs.OrderByDescending(o => o.Timestamp).ToList();

            dgvLogs.Columns.Clear();

            if (logs.Count > 0)
            {
                dgvLogs.AutoGenerateColumns = false;

                var filteredLogs = logs;

                if (types != null && types.Count > 0)
                {
                    filteredLogs = filteredLogs.Where(log => types.Contains(log.ActivityType)).ToList();
                }

                if (!string.IsNullOrEmpty(searchWord))
                {
                    filteredLogs = filteredLogs
                        .Where(log =>
                            log.ActivityDetails.ToLower().Contains(searchWord) ||
                            log.FullName.ToLower().Contains(searchWord))
                        .ToList();
                }

                ApplySettingsToTable();
                lblRowCounter.Text = ControlUtils.GetTableRowCount(filteredLogs.Count, logs.Count);
                dgvLogs.DataSource = filteredLogs;
            }

            ShowLoadingProgressBar(false);
        }

        private void ApplySettingsToTable()
        {
            ControlUtils.AddColumn(dgvLogs, "Timestamp", "Date & Time", "Timestamp");
            ControlUtils.AddColumn(dgvLogs, "FullName", "Full Name", "FullName");
            ControlUtils.AddColumn(dgvLogs, "ActivityType", "Type", "ActivityType");
            ControlUtils.AddColumn(dgvLogs, "ActivityDetails", "Details", "ActivityDetails");
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
    }
}
