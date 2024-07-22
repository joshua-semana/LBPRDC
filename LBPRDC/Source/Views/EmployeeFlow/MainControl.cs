using LBPRDC.Source.Config;
using LBPRDC.Source.Services;
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

        private UserPreference preference = new();
        private int EmployeeID;
        private string strEmployeeID = "";

        private int ClientID;

        private const int COLUMN_ID = 0;
        private const int COLUMN_EMPLOYEE_ID = 1;

        public ucEmployees()
        {
            InitializeComponent();
            this.Controls.Add(loadingControl);
            loadingControl.BringToFront();
        }

        public void ApplyFilterAndSearchThenPopulate()
        {
            if (ClientID != 0)
            {
                List<int> deparmentIDs = dchkListFilterDepartments.GetCheckedItems().Select(s => s.ID).ToList();
                List<int> positionIDs = dchkListFilterPositions.GetCheckedItems().Select(s => s.ID).ToList();
                List<int> employmentStatusIDs = dchkListFilterEmploymentStatus.GetCheckedItems().Select(s => s.ID).ToList();
                List<int> wageIDs = dchkListFilterWageType.GetCheckedItems().Select(s => s.ID).ToList();
                string searchWord = txtSearch.Text.Trim().ToLower();

                PopulateTableWithFilterAndSearch(deparmentIDs, positionIDs, employmentStatusIDs, wageIDs, searchWord, ClientID);
            }
        }

        public void ResetTableSearchFilter()
        {
            preference = UserPreferenceManager.LoadPreference();
            txtSearch.Text = string.Empty;
            ControlUtils.ResetFilters(flowFilters);
            ApplyFilterAndSearchThenPopulate();
        }

        private void ucEmployees_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                InitializeClientComboBoxItems();
                ClientID = Convert.ToInt32(cmbClient.SelectedValue);

                //ApplyFilterAndSearchThenPopulate();
                //PopulateFilters();
            }
        }

        private async void InitializeClientComboBoxItems()
        {
            cmbClient.DataSource = await ClientService.GetAllItemsForComboBox(StringConstants.Status.ACTIVE, false);
            cmbClient.DisplayMember = nameof(Models.Client.Name);
            cmbClient.ValueMember = nameof(Models.Client.ID);
            cmbClient.MouseWheel += ComboBoxUtils.HandleMouseWheel;
            cmbClient.KeyDown += ComboBoxUtils.HandleKeyDown;
        }

        private async void PopulateFilters()
        {
            var positions = await PositionService.GetAllItemsForComboBoxByClientID(ClientID, false);
            var wages = await WageService.GetWagesAsync();
            var departments = await DepartmentService.GetItems(ClientID, StringConstants.Status.ACTIVE);
            var employmentStatus = await EmploymentStatusService.GetItems(StringConstants.Status.ACTIVE);

            InitializeFilter(
                lblFilterDepartments,
                dchkListFilterDepartments,
                departments
                    .Select(s => new CheckedListBoxItems(s.ID, s.Name))
                    .ToList()
            );
            InitializeFilter(
                lblFilterPositions,
                dchkListFilterPositions,
                positions
                    .Select(s => new CheckedListBoxItems(s.ID, Utilities.StringFormat.ToSentenceCase(s.Name)))
                    .ToList()
            );
            InitializeFilter(
                lblFilterEmploymentStatus,
                dchkListFilterEmploymentStatus,
                employmentStatus
                    .Select(s => new CheckedListBoxItems(s.ID, Utilities.StringFormat.ToSentenceCase(s.Name)))
                    .ToList()
            );
            InitializeFilter(
                lblFilterWageType,
                dchkListFilterWageType,
                wages
                    .Where(w => w.Status == StringConstants.Status.ACTIVE)
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
            label.Visible = items.Count > 0;
            control.SetItems(items);
            control.DisplayItems();
        }

        private async void PopulateTableWithFilterAndSearch(List<int> departmentIDs, List<int> positionIDs, List<int> employmentStatusIDs, List<int> wageIDs, string searchWord, int clientID)
        {
            ShowLoadingProgressBar(true);
            var employees = await EmployeeService.GetEmployeesTableViewByClientID(clientID);

            dgvEmployees.Columns.Clear();

            if (employees.Count > 0)
            {
                dgvEmployees.AutoGenerateColumns = false;

                var filteredEmployees = employees;

                if (wageIDs != null && wageIDs.Count > 0)
                {
                    filteredEmployees = filteredEmployees.Where(employee => wageIDs.Contains(employee.WageID)).ToList();
                }
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
            else
            {
                lblRowCounter.Text = "No record found.";
            }

            ShowLoadingProgressBar(false);
        }

        private void ApplySettingsToTable()
        {
            ControlUtils.AddColumn(dgvEmployees, "ID", "ID", "ID", true, true);
            ControlUtils.AddColumn(dgvEmployees, "EmployeeID", "Employee ID", "EmployeeID", preference.ShowEmployeeID, true);
            if (preference.ShowName)
            {
                if (preference.SelectedNameFormat == NameFormat.Separated)
                {
                    ControlUtils.AddColumn(dgvEmployees, "FirstName", "First Name", "FirstName", true, true);
                    ControlUtils.AddColumn(dgvEmployees, "MiddleName", "Middle Name", "MiddleName", true, true);
                    ControlUtils.AddColumn(dgvEmployees, "LastName", "Last Name", "LastName", true, true);
                    ControlUtils.AddColumn(dgvEmployees, "SuffixName", "Suffix", "SuffixName", true, true);
                }
                else
                {
                    ControlUtils.AddColumn(dgvEmployees, "FullName", "Name", "FullName", true, true);
                }
            }
            ControlUtils.AddColumn(dgvEmployees, "Gender", "Gender", "Gender", preference.ShowGender, true);
            ControlUtils.AddColumn(dgvEmployees, "JoinedEmailAddress", "Email Address", "JoinedEmailAddress", preference.ShowEmailAddress, true);
            ControlUtils.AddColumn(dgvEmployees, "JoinedContactNumber", "Contact Number", "JoinedContactNumber", preference.ShowContactNumber, true);
            ControlUtils.AddColumn(dgvEmployees, "ClassificationName", "Classification", "ClassificationName", preference.ShowClassification, true);
            ControlUtils.AddColumn(dgvEmployees, "DepartmentName", "Department", "DepartmentName", preference.ShowDepartment, true);
            ControlUtils.AddColumn(dgvEmployees, "LocationName", "Location", "LocationName", preference.ShowLocation, true);
            ControlUtils.AddColumn(dgvEmployees, "PositionInfo", "Position", "PositionInfo", preference.ShowPosition, true);
            ControlUtils.AddColumn(dgvEmployees, "WageName", "Wage Type", "WageName", preference.ShowWageType, true);
            ControlUtils.AddColumn(dgvEmployees, "SalaryRate", "Salary Rate", "SalaryRate", preference.ShowSalaryRate, true);
            ControlUtils.AddColumn(dgvEmployees, "BillingRate", "Billing Rate", "BillingRate", preference.ShowBillingRate, true);
            ControlUtils.AddColumn(dgvEmployees, "EmploymentStatusName", "Status", "EmploymentStatusName", preference.ShowEmploymentStatus, true);
        }

        private void ShowLoadingProgressBar(bool state)
        {
            loadingControl.Visible = state;
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            if (ClientID == 0)
            {
                MessageBox.Show("You must first add a client in order to add an employee.");
                return;
            }

            frmNewEntryEmployee newEntryForm = new()
            {
                ParentControl = this,
                ClientID = ClientID,
                ClientName = cmbClient.Text
            };
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
            ViewEmployeeDataForm frmViewEmployeeData = new()
            {
                ClientID = ClientID,
                EmployeeID = EmployeeID
            };
            frmViewEmployeeData.ShowDialog();
        }

        private void cntxtMenuViewBillings_Click(object sender, EventArgs e)
        {
            if (strEmployeeID == "")
            {
                return;
            }

            ViewBillingsForm form = new()
            {
                EmployeeID = strEmployeeID,
                ClientID = ClientID,
            };
            form.ShowDialog();
        }

        private void cntxtMenuEdit_Click(object sender, EventArgs e)
        {
            EditEmployeeForm frmEditEmployee = new()
            {
                ParentControl = this,
                EmployeeID = EmployeeID,
                ClientID = ClientID
            };
            frmEditEmployee.ShowDialog();
        }

        private async void cntxtMenuArchive_Click(object sender, EventArgs e)
        {
            if (EmployeeID == 0 || ClientID == 0) return;
            var output = MessageBox.Show("Are you sure you want to archive this employee?", "Archive Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (output == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;
                if (await Task.Run(() => EmployeeService.ArchiveEmployee(EmployeeID, ClientID)))
                {
                    MessageBox.Show("You have successfully archived this employee.", "Archive Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ApplyFilterAndSearchThenPopulate();
                }
                Cursor = Cursors.Default;
            }
        }

        private void menuUpdatePosition_Click(object sender, EventArgs e)
        {
            UpdatePositionForm frmUpdatePosition = new()
            {
                ParentControl = this,
                EmployeeID = EmployeeID,
                ClientID = ClientID
            };
            frmUpdatePosition.ShowDialog();
        }

        private void menuUpdateEmploymentStatus_Click(object sender, EventArgs e)
        {
            UpdateEmploymentStatusForm frmUpdateEmploymentStatus = new()
            {
                ParentControl = this,
                EmployeeID = EmployeeID,
                ClientID = ClientID
            };
            frmUpdateEmploymentStatus.ShowDialog();
        }

        private void menuUpdateDepartmentLocation_Click(object sender, EventArgs e)
        {
            UpdateDepartmentLocationForm frmUpdateDepartmentLocation = new()
            {
                ParentControl = this,
                EmployeeID = EmployeeID,
                ClientID = ClientID
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
            ViewHistory frmViewHistory = new()
            {
                HistoryType = type,
                EmployeeID = EmployeeID,
                ClientID = ClientID
            };
            frmViewHistory.ShowDialog();
        }

        private void menuHistoryPosition_Click(object sender, EventArgs e)
        {
            ViewEmployeeHistory("Position");
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

        private void cmbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClient.Items.Count > 0)
            {
                var selectedClient = (Models.Client)cmbClient.SelectedItem;
                ClientID = selectedClient.ID;
                ResetTableSearchFilter();
                PopulateFilters();
            }
            else
            {
                ClientID = 0;
            }
        }

        private void dgvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmployees.Columns.Count > 1 && dgvEmployees.Rows.Count > 0 && dgvEmployees.SelectedRows.Count > 0)
            {
                EmployeeID = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells[COLUMN_ID].Value);
                strEmployeeID = Convert.ToString(dgvEmployees.SelectedRows[0].Cells[COLUMN_EMPLOYEE_ID].Value) ?? "";
            }
            else
            {
                EmployeeID = 0;
                strEmployeeID = "";
            }
        }
    }
}
