using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;
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
        private BackgroundWorker dataLoader;

        public ucEmployees()
        {
            InitializeComponent();

            this.Controls.Add(loadingControl);

            dataLoader = new BackgroundWorker();
            dataLoader.DoWork += DataLoadingWorker_DoWork;
            dataLoader.RunWorkerCompleted += DataLoadingWorker_RunWorkerCompleted;

            ShowLoadingProgressBar();

            dataLoader.RunWorkerAsync();
        }

        private void DataLoadingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = EmployeeService.GetAllEmployees();
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
            this.Controls.Remove(loadingControl);
            loadingControl.Visible = false;
            dgvEmployees.Visible = true;
        }

        private void DataLoadingWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                dgvEmployees.DataSource = e.Result;

                HideLoadingProgressBar();
            }
            else
            {
                MessageBox.Show("Error loading data: " + e.Error.Message);
            }
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
                            var viewRawDataForm = new frmViewRawData(selectedFile);
                            viewRawDataForm.ShowDialog();
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
            var employeeDataEntryForm = new frmEmployeeDataEntry();
            employeeDataEntryForm.ShowDialog();
        }
    }
}
