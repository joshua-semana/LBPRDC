using LBPRDC.Source.Services;
using OfficeOpenXml;

namespace LBPRDC.Source.Views.Billing
{
    public partial class UploadFileForm : Form
    {
        public BillingControl? ParentControl { get; set; }

        public string billingName { get; set; }

        private string filePath = "", sheetName = "";

        public UploadFileForm()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                string? selectedFile = ExcelService.OpenFile();

                if (selectedFile != null)
                {
                    Cursor = Cursors.WaitCursor;
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    txtFilePath.Text = selectedFile;
                    PopulateAndEnableWorksheetSelection(ExcelService.GetExcelWorksheetNames(selectedFile));
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void PopulateAndEnableWorksheetSelection(string[] worksheets)
        {
            cmbWorkSheet.Items.Clear();
            cmbWorkSheet.Enabled = worksheets.Length > 0;
            cmbWorkSheet.Items.AddRange(worksheets);
            cmbWorkSheet.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to cancel this operation?", "Cancel Operation Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            ToggleInputs(false);
            bool isWorkSheetValid = ExcelService.isWorksheetMatchesTo(txtFilePath.Text, cmbWorkSheet.Text);

            if (isWorkSheetValid)
            {
                filePath = txtFilePath.Text;
                sheetName = cmbWorkSheet.Text;

                var unrecognizedEmployees = await Task.Run(() => CheckEmployeeExistense());

                if (unrecognizedEmployees.Count > 0)
                {
                    UnrecognizedEmployeeForm unrecognizedEmployee = new()
                    {
                        Employees = unrecognizedEmployees
                    };
                    unrecognizedEmployee.ShowDialog();
                }
                else
                {
                    var entries = await Task.Run(() => ExcelService.PreProcessEntries(txtFilePath.Text, sheetName));

                    if (entries.Count > 0)
                    {
                        var isAdded = await Task.Run(() => ExcelService.SaveEntries(entries, billingName));
                        var isUpdated = await Task.Run(() => BillingService.UpdateFileUploadStatus(billingName, "Yes"));
                        if (isAdded && isUpdated)
                        {
                            ToggleInputs(true);
                            MessageBox.Show("You have successfully uploaded a timekeep file to this billing.", "Upload Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ParentControl?.ResetTableSearch();
                            this.Close();
                        }
                    }
                }
            }
        }

        private List<EmployeeBase> CheckEmployeeExistense()
        {
            List<EmployeeBase> nonExistingEmployees = new();

            var employeeList = EmployeeService.GetAllEmployeesBase();
            var identifiersDictionary = ExcelService.GetAllIdentifiers(filePath, sheetName, 1, 2);

            foreach (var (id, name) in identifiersDictionary)
            {
                if (!employeeList.Any(emp => emp.EmployeeID.EndsWith(id.Substring(id.Length - 4))))
                {
                    EmployeeBase emp = new()
                    {
                        EmployeeID = id,
                        FullName = name
                    };

                    nonExistingEmployees.Add(emp);
                }
            }
            return nonExistingEmployees;
        }

        private void ToggleInputs(bool state)
        {
            Cursor = (state == true) ? Cursors.Default : Cursors.WaitCursor;
            btnConfirm.Text = (state == true) ? "Confirm" : "Uploading";
            btnConfirm.Enabled = state;
            btnCancel.Enabled = state;
            btnSelect.Enabled = state;
            cmbWorkSheet.Enabled = state;
        }
    }
}
