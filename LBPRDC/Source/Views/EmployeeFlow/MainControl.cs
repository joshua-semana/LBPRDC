using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;
using LBPRDC.Source.Views.Employee;
using LBPRDC.Source.Views.Shared;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static LBPRDC.Source.Views.Shared.DynamicCheckedListBoxControl;

namespace LBPRDC.Source.Views
{
    public partial class ucEmployees : UserControl
    {
        UserControl loadingControl = new ucLoading();
        private UserPreference preference;
        //private BackgroundWorker dataLoader;

        public ucEmployees()
        {
            InitializeComponent();
            this.Controls.Add(loadingControl);
            PopulateFilters();
            //dataLoader = new BackgroundWorker();
            //dataLoader.DoWork += DataLoadingWorker_DoWork;
            //dataLoader.RunWorkerCompleted += DataLoadingWorker_RunWorkerCompleted;
            //ShowLoadingProgressBar();
            //dataLoader.RunWorkerAsync();
        }

        private void ShowLoadingProgressBar()
        {
            loadingControl.Dock = DockStyle.Fill;
            loadingControl.BringToFront();
            loadingControl.Visible = true;

            dgvEmployees.Visible = false;
        }

        private void HideLoadingProgressBar()
        {
            loadingControl.Visible = false;
            dgvEmployees.Visible = true;
        }

        private void ucEmployees_VisibleChanged(object sender, EventArgs e)
        {
            PopulateTable();
        }

        public async void PopulateFilters()
        {
            await Task.Run(() =>
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
                //InitializeFilter(lblFilterLocations, dchkListFilterLocations, LocationService.GetAllItems().Select(s => new CheckedListBoxItems(Convert.ToInt32(s.ID), s.Name)).ToList());
                //InitializeFilter(lblFilterCivilStatus, dchkListFilterCivilStatus, CivilStatusService.GetAllItems().Select(s => new CheckedListBoxItems(s.ID, s.Name)).ToList());
                //InitializeFilter(lblFilterGender, dchkListFilterGender, new() { new CheckedListBoxItems(1, "MALE"), new CheckedListBoxItems(2, "FEMALE") });
            });
        }

        private static void InitializeFilter(Label label, DynamicCheckedListBoxControl control, List<CheckedListBoxItems> items)
        {
            bool hasItems = items.Count > 0;
            label.Visible = hasItems;
            control.Visible = hasItems;
            if (hasItems)
            {
                control.SetItems(items);
            }
        }

        public async void PopulateTable()
        {
            ShowLoadingProgressBar();
            preference = UserPreferenceManager.LoadPreference();
            List<Services.Employee> employees = await Task.Run(() => EmployeeService.GetAllEmployees());

            dgvEmployees.Columns.Clear();

            if (employees.Count > 0)
            {
                dgvEmployees.AutoGenerateColumns = false;
                ApplySettingsToTable();
                dgvEmployees.DataSource = employees;
            }
            HideLoadingProgressBar();
        }

        public async void PopulateTableWithFilter(List<int> deparmentIDs, List<int> positionIDs, List<int> employmentStatusIDs)
        {
            ShowLoadingProgressBar();
            preference = UserPreferenceManager.LoadPreference();
            List<Services.Employee> employees = await Task.Run(() => EmployeeService.GetAllEmployees());

            dgvEmployees.Columns.Clear();

            if (employees.Count > 0)
            {
                dgvEmployees.AutoGenerateColumns = false;

                List<Services.Employee> filteredEmployees = employees;

                if (deparmentIDs.Count > 0)
                {
                    filteredEmployees = filteredEmployees.Where(employee => deparmentIDs.Contains(employee.DepartmentID)).ToList();
                }
                if (positionIDs.Count > 0)
                {
                    filteredEmployees = filteredEmployees.Where(employee => positionIDs.Contains(employee.PositionID)).ToList();
                }
                if (employmentStatusIDs.Count > 0)
                {
                    filteredEmployees = filteredEmployees.Where(employee => employmentStatusIDs.Contains(employee.EmploymentStatusID)).ToList();
                }

                ApplySettingsToTable();
                dgvEmployees.DataSource = filteredEmployees;
            }
            HideLoadingProgressBar();
        }

        public async void PopulateTableWithSearch(string searchword)
        {
            ShowLoadingProgressBar();
            preference = UserPreferenceManager.LoadPreference();
            List<Services.Employee> employees = await Task.Run(() => EmployeeService.GetAllEmployees());

            dgvEmployees.Columns.Clear();

            if (employees.Count > 0)
            {
                dgvEmployees.AutoGenerateColumns = false;

                List<Services.Employee> filteredEmployees = employees;

                filteredEmployees = filteredEmployees.Where(emp => searchword.Contains(emp.FullName)).ToList();

                ApplySettingsToTable();
                dgvEmployees.DataSource = filteredEmployees;
            }
            HideLoadingProgressBar();
        }

        private void ApplySettingsToTable()
        {
            if (preference.ShowEmployeeID) { AddColumn("EmployeeID", "ID", "EmployeeID"); }
            if (preference.ShowName)
            {
                if (preference.SelectedNameFormat == NameFormat.Full1 ||
                    preference.SelectedNameFormat == NameFormat.Full2 ||
                    preference.SelectedNameFormat == NameFormat.FirstAndLastOnly)
                {
                    AddColumn("FullName", "Full Name", "FullName");
                }
                else if (preference.SelectedNameFormat == NameFormat.LastNameOnly)
                {
                    AddColumn("LastName", "Last Name", "LastName");
                }
                else if (preference.SelectedNameFormat == NameFormat.Separated)
                {
                    AddColumn("FirstName", "First Name", "FirstName");
                    AddColumn("MiddleName", "Middle Name", "MiddleName");
                    AddColumn("LastName", "Last Name", "LastName");
                    AddColumn("Suffix", "Suffix", "Suffix");
                }
            }
            if (preference.ShowGender) { AddColumn("Gender", "Gender", "Gender"); }
            if (preference.ShowBirthday) { AddColumn("Birthday", "Birthday", "Birthday"); }
            if (preference.ShowEducation) { AddColumn("Education", "Education", "Education"); }
            if (preference.ShowCivilStatus) { AddColumn("CivilStatus", "Civil Status", "CivilStatus"); }
            if (preference.ShowEmailAddress) { AddColumn("EmailAddress", "Email Address", "EmailAddress"); }
            if (preference.ShowContactNumber) { AddColumn("ContactNumber", "Contact Number", "ContactNumber"); }
            if (preference.ShowDepartment) { AddColumn("Department", "Department", "Department"); }
            if (preference.ShowLocation) { AddColumn("Location", "Location", "Location"); }
            if (preference.ShowPosition) { AddColumn("Position", "Position", "Position"); }
            if (preference.ShowSalaryRate) { AddColumn("SalaryRate", "Salary Rate", "SalaryRate"); }
            if (preference.ShowBillingRate) { AddColumn("BillingRate", "Billing Rate", "BillingRate"); }
            if (preference.ShowEmploymentStatus) { AddColumn("EmploymentStatus", "Status", "EmploymentStatus"); }
        }

        private void AddColumn(string name, string header, string property)
        {
            dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                DataPropertyName = property
            });
        }

        private void btnAddBatch_Click(object sender, EventArgs e)
        {
            try
            {
                string? selectedFile = FileManager.OpenFile();

                if (selectedFile != null)
                {
                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

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

        private void ResetFilters()
        {
            foreach (Control control in flowFilters.Controls)
            {
                if (control is DynamicCheckedListBoxControl dynamicCheckbox)
                {
                    dynamicCheckbox.ClearCheckedItems();
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            PopulateTable();
            ResetFilters();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            List<int> deparmentIDs = dchkListFilterDepartments.GetCheckedItems().Select(s => s.ID).ToList();
            List<int> positionIDs = dchkListFilterPositions.GetCheckedItems().Select(s => s.ID).ToList();
            List<int> employmentStatusIDs = dchkListFilterEmploymentStatus.GetCheckedItems().Select(s => s.ID).ToList();
            if (deparmentIDs.Count > 0 || positionIDs.Count > 0 || employmentStatusIDs.Count > 0)
            {
                PopulateTableWithFilter(deparmentIDs, positionIDs, employmentStatusIDs);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PopulateTableWithSearch(txtSearch.Text.Trim());
        }

        //private void DataLoadingWorker_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    e.Result = EmployeeService.GetAllEmployees();
        //}

        //private void DataLoadingWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    if (e.Error == null)
        //    {
        //        dgvEmployees.AutoGenerateColumns = false;

        //        dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn
        //        {
        //            Name = "FullName",
        //            HeaderText = "Full Name",
        //            DataPropertyName = "FullName"
        //        });

        //        dgvEmployees.DataSource = e.Result;

        //        HideLoadingProgressBar();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Error loading data: " + e.Error.Message);
        //    }
        //}
    }
}
