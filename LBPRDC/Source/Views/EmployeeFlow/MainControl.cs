using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;
using LBPRDC.Source.Views.Employee;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LBPRDC.Source.Views
{
    public partial class ucEmployees : UserControl
    {
        UserControl loadingControl = new ucLoading();
        //private BackgroundWorker dataLoader;

        public ucEmployees()
        {
            InitializeComponent();

            this.Controls.Add(loadingControl);

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

        public async void PopulateTable()
        {
            ShowLoadingProgressBar();
            await Task.Delay(500);
            List<Services.Employee> employees = await Task.Run(() => EmployeeService.GetAllEmployees());
            if (employees.Count > 0)
            {
                dgvEmployees.DataSource = employees;
            }
            HideLoadingProgressBar();
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
            newEntryForm.EmployeesControl = this;
            newEntryForm.ShowDialog();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmSettingsEmployee settingEmployeeForm = new();
            settingEmployeeForm.ShowDialog();
        }
    }
}
