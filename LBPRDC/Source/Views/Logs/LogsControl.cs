﻿using LBPRDC.Source.Services;
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

        private async void PopulateFilters()
        {
            var logs = await LoggingService.GetAllItems();
            InitializeFilter(dchkListFilterType, logs.DistinctBy(d => d.ActivityType).Select(s => new CheckedListBoxItems(0, s.ActivityType)).ToList());
        }

        private static void InitializeFilter(DynamicCheckedListBoxControl control, List<CheckedListBoxItems> items)
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
            var (Items, TotalCount) = await Task.Run(() => LoggingService.GetFilteredItems(types, searchWord, dtpDate.Value));

            dgvLogs.Columns.Clear();
            dgvLogs.AutoGenerateColumns = false;
            ApplySettingsToTable();
            lblRowCounter.Text = ControlUtils.GetTableRowCount(Items.Count, TotalCount, "log");
            dgvLogs.DataSource = Items;

            ShowLoadingProgressBar(false);
        }

        private void ApplySettingsToTable()
        {
            ControlUtils.AddColumn(dgvLogs, "Timestamp", "Date & Time", "Timestamp", true, true);
            ControlUtils.AddColumn(dgvLogs, "FullName", "Full Name", "FullName", true, true);
            ControlUtils.AddColumn(dgvLogs, "ActivityType", "Type", "ActivityType", true, true);
            ControlUtils.AddColumn(dgvLogs, "ActivityDetails", "Details", "ActivityDetails", true, true);
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

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilterAndSearchThenPopulate();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFilterAndSearchThenPopulate();
        }
    }
}
