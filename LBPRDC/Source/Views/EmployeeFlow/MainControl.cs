﻿using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;
using LBPRDC.Source.Views.Employee;
using LBPRDC.Source.Views.EmployeeFlow;
using LBPRDC.Source.Views.Shared;
using OfficeOpenXml;
using System.Data;
using static LBPRDC.Source.Views.Shared.DynamicCheckedListBoxControl;

namespace LBPRDC.Source.Views
{
    public partial class ucEmployees : UserControl
    {
        UserControl loadingControl = new ucLoading() { Dock = DockStyle.Fill };

        private UserPreference preference;
        private string EmployeeID;

        public ucEmployees()
        {
            InitializeComponent();
            this.Controls.Add(loadingControl);
            loadingControl.BringToFront();
        }

        public void ApplyFilterAndSearchThenPopulate()
        {
            List<int> deparmentIDs = dchkListFilterDepartments.GetCheckedItems().Select(s => s.ID).ToList();
            List<int> positionIDs = dchkListFilterPositions.GetCheckedItems().Select(s => s.ID).ToList();
            List<int> employmentStatusIDs = dchkListFilterEmploymentStatus.GetCheckedItems().Select(s => s.ID).ToList();
            string searchWord = txtSearch.Text.Trim().ToLower();

            PopulateTableWithFilterAndSearch(deparmentIDs, positionIDs, employmentStatusIDs, searchWord);
        }

        public void ResetTableSearchFilter()
        {
            txtSearch.Text = string.Empty;
            ControlUtils.ResetFilters(flowFilters);
            ApplyFilterAndSearchThenPopulate();
        }

        private void ucEmployees_VisibleChanged(object sender, EventArgs e)
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
                lblFilterDepartments,
                dchkListFilterDepartments,
                DepartmentService.GetAllItems()
                    .Select(s => new CheckedListBoxItems(s.ID, s.Name))
                    .ToList()
            );
            InitializeFilter(
                lblFilterPositions,
                dchkListFilterPositions,
                PositionService.GetAllItems()
                    .Select(s => new CheckedListBoxItems(s.ID, Utilities.StringFormat.ToSentenceCase(s.Name)))
                    .ToList()
            );
            InitializeFilter(
                lblFilterEmploymentStatus,
                dchkListFilterEmploymentStatus,
                EmploymentStatusService.GetAllItems()
                    .Select(s => new CheckedListBoxItems(s.ID, Utilities.StringFormat.ToSentenceCase(s.Name)))
                    .ToList()
            );
            //Do not remove, still working, UI are just hidden
            //InitializeFilter(lblFilterLocations, dchkListFilterLocations, LocationService.GetAllItems().Select(s => new CheckedListBoxItems(Convert.ToInt32(s.ID), s.Name)).ToList());
            //InitializeFilter(lblFilterCivilStatus, dchkListFilterCivilStatus, CivilStatusService.GetAllItems().Select(s => new CheckedListBoxItems(s.ID, s.Name)).ToList());
            //InitializeFilter(lblFilterGender, dchkListFilterGender, new() { new CheckedListBoxItems(1, "MALE"), new CheckedListBoxItems(2, "FEMALE") });
        }

        private static void InitializeFilter(Label label, DynamicCheckedListBoxControl control, List<CheckedListBoxItems> items)
        {
            if (items.Count > 0)
            {
                control.SetItems(items);
                control.DisplayItems();
            }
        }

        private async void PopulateTableWithFilterAndSearch(List<int> departmentIDs, List<int> positionIDs, List<int> employmentStatusIDs, string searchWord)
        {
            ShowLoadingProgressBar(true);
            preference = UserPreferenceManager.LoadPreference();
            List<EmployeeService.Employee> employees = await Task.Run(() => EmployeeService.GetAllEmployees());

            dgvEmployees.Columns.Clear();

            if (employees.Count > 0)
            {
                dgvEmployees.AutoGenerateColumns = false;

                List<EmployeeService.Employee> filteredEmployees = employees;

                if (departmentIDs != null && departmentIDs.Count > 0)
                {
                    filteredEmployees = filteredEmployees.Where(employee => departmentIDs.Contains(employee.DepartmentID)).ToList();
                }
                if (positionIDs != null && positionIDs.Count > 0)
                {
                    filteredEmployees = filteredEmployees.Where(employee => positionIDs.Contains(employee.PositionID)).ToList();
                }
                if (employmentStatusIDs != null && employmentStatusIDs.Count > 0)
                {
                    filteredEmployees = filteredEmployees.Where(employee => employmentStatusIDs.Contains(employee.EmploymentStatusID)).ToList();
                }

                if (!string.IsNullOrEmpty(searchWord))
                {
                    filteredEmployees = filteredEmployees
                        .Where(employee =>
                            employee.EmployeeID.ToLower().Contains(searchWord) ||
                            employee.FirstName.ToLower().Contains(searchWord) ||
                            employee.MiddleName.ToLower().Contains(searchWord) ||
                            employee.LastName.ToLower().Contains(searchWord))
                        .ToList();
                }

                ApplySettingsToTable();
                lblRowCounter.Text = ControlUtils.GetTableRowCount(filteredEmployees.Count, employees.Count, "employee");
                dgvEmployees.DataSource = filteredEmployees;
            }

            ShowLoadingProgressBar(false);
        }

        private void ApplySettingsToTable()
        {
            if (preference.ShowEmployeeID) { ControlUtils.AddColumn(dgvEmployees, "EmployeeID", "ID", "EmployeeID"); }
            if (preference.ShowName)
            {
                if (preference.SelectedNameFormat == NameFormat.Full1 ||
                    preference.SelectedNameFormat == NameFormat.Full2 ||
                    preference.SelectedNameFormat == NameFormat.FirstAndLastOnly)
                {
                    ControlUtils.AddColumn(dgvEmployees, "FullName", "Full Name", "FullName");
                }
                else if (preference.SelectedNameFormat == NameFormat.LastNameOnly)
                {
                    ControlUtils.AddColumn(dgvEmployees, "LastName", "Last Name", "LastName");
                }
                else if (preference.SelectedNameFormat == NameFormat.Separated)
                {
                    ControlUtils.AddColumn(dgvEmployees, "FirstName", "First Name", "FirstName");
                    ControlUtils.AddColumn(dgvEmployees, "MiddleName", "Middle Name", "MiddleName");
                    ControlUtils.AddColumn(dgvEmployees, "LastName", "Last Name", "LastName");
                    ControlUtils.AddColumn(dgvEmployees, "Suffix", "Suffix", "Suffix");
                }
            }
            if (preference.ShowGender) { ControlUtils.AddColumn(dgvEmployees, "Gender", "Gender", "Gender"); }
            if (preference.ShowBirthday) { ControlUtils.AddColumn(dgvEmployees, "Birthday", "Birthday", "Birthday"); }
            if (preference.ShowEducation) { ControlUtils.AddColumn(dgvEmployees, "Education", "Education", "Education"); }
            if (preference.ShowCivilStatus) { ControlUtils.AddColumn(dgvEmployees, "CivilStatus", "Civil Status", "CivilStatus"); }
            if (preference.ShowEmailAddress) { ControlUtils.AddColumn(dgvEmployees, "EmailAddress", "Email Address", "EmailAddress"); }
            if (preference.ShowContactNumber) { ControlUtils.AddColumn(dgvEmployees, "ContactNumber", "Contact Number", "ContactNumber"); }
            if (preference.ShowDepartment) { ControlUtils.AddColumn(dgvEmployees, "Department", "Department", "Department"); }
            if (preference.ShowLocation) { ControlUtils.AddColumn(dgvEmployees, "Location", "Location", "Location"); }
            if (preference.ShowPosition) { ControlUtils.AddColumn(dgvEmployees, "Position", "Position", "Position"); }
            if (preference.ShowSalaryRate) { ControlUtils.AddColumn(dgvEmployees, "SalaryRate", "Salary Rate", "SalaryRate"); }
            if (preference.ShowBillingRate) { ControlUtils.AddColumn(dgvEmployees, "BillingRate", "Billing Rate", "BillingRate"); }
            if (preference.ShowEmploymentStatus) { ControlUtils.AddColumn(dgvEmployees, "EmploymentStatus", "Status", "EmploymentStatus"); }
        }

        private void ShowLoadingProgressBar(bool state)
        {
            loadingControl.Visible = state;
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            frmNewEntryEmployee newEntryForm = new();
            newEntryForm.ParentControl = this;
            newEntryForm.ShowDialog();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmSettingsEmployee settingEmployeeForm = new();
            settingEmployeeForm.ParentControl = this;
            settingEmployeeForm.ShowDialog();
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

        private void dgvEmployees_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    dgvEmployees.Rows[e.RowIndex].Selected = true;
                    var location = dgvEmployees.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
                    cntxtEmployeeActions.Show(dgvEmployees, location);
                }
            }
        }

        private void cntxtMenuView_Click(object sender, EventArgs e)
        {
            EmployeeID = dgvEmployees.SelectedRows[0].Cells[0].Value.ToString();
            ViewEmployeeDataForm frmViewEmployeeData = new()
            {
                EmployeeId = EmployeeID
            };
            frmViewEmployeeData.ShowDialog();
        }

        private void cntxtMenuEdit_Click(object sender, EventArgs e)
        {
            EmployeeID = dgvEmployees.SelectedRows[0].Cells[0].Value.ToString();
            EditEmployeeForm frmEditEmployee = new()
            {
                ParentControl = this,
                EmployeeId = EmployeeID
            };
            frmEditEmployee.ShowDialog();
        }

        private async void cntxtMenuArchive_Click(object sender, EventArgs e)
        {
            var output = MessageBox.Show("Are you sure you want to archive this employee?", "Archive Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (output == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;
                EmployeeID = dgvEmployees.SelectedRows[0].Cells[0].Value.ToString();
                if (await Task.Run(() => EmployeeService.ArchiveEmployee(EmployeeID)))
                {
                    MessageBox.Show("You have successfully archived this employee.", "Archive Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ApplyFilterAndSearchThenPopulate();
                }
                Cursor = Cursors.Default;
            }
        }

        private void menuUpdatePosition_Click(object sender, EventArgs e)
        {
            EmployeeID = dgvEmployees.SelectedRows[0].Cells[0].Value.ToString();
            UpdatePositionForm frmUpdatePosition = new()
            {
                ParentControl = this,
                EmployeeId = EmployeeID
            };
            frmUpdatePosition.ShowDialog();
        }

        private void menuUpdateCivilStatus_Click(object sender, EventArgs e)
        {
            EmployeeID = dgvEmployees.SelectedRows[0].Cells[0].Value.ToString();
            UpdateCivilStatusForm frmUpdateCivilStatus = new()
            {
                ParentControl = this,
                EmployeeId = EmployeeID
            };
            frmUpdateCivilStatus.ShowDialog();
        }

        private void menuUpdateEmploymentStatus_Click(object sender, EventArgs e)
        {
            string employeeID = dgvEmployees.SelectedRows[0].Cells[0].Value.ToString();
            UpdateEmploymentStatusForm frmUpdateEmploymentStatus = new()
            {
                ParentControl = this,
                EmployeeId = employeeID
            };
            frmUpdateEmploymentStatus.ShowDialog();
        }

        private void menuUpdateDepartmentLocation_Click(object sender, EventArgs e)
        {
            string employeeID = dgvEmployees.SelectedRows[0].Cells[0].Value.ToString();
            UpdateDepartmentLocationForm frmUpdateDepartmentLocation = new()
            {
                ParentControl = this,
                EmployeeId = employeeID
            };
            frmUpdateDepartmentLocation.ShowDialog();
        }

        private void btnAddBatch_Click(object sender, EventArgs e)
        {
            try
            {
                string? selectedFile = FileManager.OpenFile();

                if (selectedFile != null)
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    if (FileManager.isFileNotEmpty(selectedFile))
                    {
                        if (FileManager.isFileAdheresTo(selectedFile, "Add Batch"))
                        {
                            frmAddBatchEmployees addBatchForm = new(selectedFile);
                            addBatchForm.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        private void ViewEmployeeHistory(string type)
        {
            string employeeID = dgvEmployees.SelectedRows[0].Cells[0].Value.ToString();
            ViewHistory frmViewHistory = new()
            {
                HistoryType = type,
                EmployeeId = employeeID
            };
            frmViewHistory.ShowDialog();
        }

        private void menuHistoryPosition_Click(object sender, EventArgs e)
        {
            ViewEmployeeHistory("Position");
        }

        private void menuHistoryCivilStatus_Click(object sender, EventArgs e)
        {
            ViewEmployeeHistory("Civil Status");
        }

        private void menuHistoryEmploymentStatus_Click(object sender, EventArgs e)
        {
            ViewEmployeeHistory("Employment Status");
        }

        private void menuHistoryDepartmentLocation_Click(object sender, EventArgs e)
        {
            ViewEmployeeHistory("Department and Location");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFilterAndSearchThenPopulate();
        }
    }
}
