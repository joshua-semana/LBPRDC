using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;
using OfficeOpenXml;

namespace LBPRDC.Source.Views.Billing
{
    public partial class UploadFileForm : Form
    {
        public BillingControl? ParentControl { get; set; }
        public string BillingName { get; set; }
        public string UploadType { get; set; }

        private readonly List<Control> RequiredFields;

        private string filePath = "", reportSheetName = "", timekeepSheetName = "";

        public UploadFileForm()
        {
            InitializeComponent();

            RequiredFields = new()
            {
                txtFilePath
            };
        }

        private void UploadFileForm_Load(object sender, EventArgs e)
        {
            this.Text = BillingName;
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
            cmbTimekeepSheet.Items.Clear();
            cmbTimekeepSheet.Enabled = worksheets.Length > 0;
            cmbTimekeepSheet.Items.AddRange(worksheets);
            cmbTimekeepSheet.SelectedIndex = 0;

            cmbReportWorksheet.Items.Clear();
            cmbReportWorksheet.Enabled = worksheets.Length > 0;
            cmbReportWorksheet.Items.AddRange(worksheets);
            cmbReportWorksheet.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to cancel this operation?", "Cancel Operation Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            if (ControlUtils.AreRequiredFieldsFilled(RequiredFields))
            {
                ToggleInputs(false);

                if (!ExcelService.AreTimekeepSheetsValid(txtFilePath.Text, cmbReportWorksheet.Text, cmbTimekeepSheet.Text))
                {
                    ToggleInputs(true);
                    return;
                }

                filePath = txtFilePath.Text;
                reportSheetName = cmbReportWorksheet.Text;
                timekeepSheetName = cmbTimekeepSheet.Text;

                var unrecognizedEmployees = await Task.Run(() => CheckEmployeeExistense());

                if (unrecognizedEmployees.Count > 0)
                {
                    UnrecognizedEmployeeForm form = new()
                    {
                        Employees = unrecognizedEmployees
                    };
                    form.ShowDialog();
                    ToggleInputs(true);
                    return;
                }

                if (UploadType == "Overwrite")
                {
                    var recordsAreRemoved = await Task.Run(() => BillingService.RemoveBillingRecordsByBillingName(BillingName));
                    if (!recordsAreRemoved)
                    {
                        MessageBox.Show("There's a problem overwriting the timekeeping file of this billing; please try again. If the error still persists, please call for support.", "Error Overwriting Timekeep File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                var entries = await Task.Run(() => ExcelService.PreProcessEntries(txtFilePath.Text, reportSheetName, timekeepSheetName));

                if (entries.Count > 0 && await Task.Run(() => BillingService.UpdateConstantAndEditableJSON(entries, BillingName)) && await Task.Run(() => BillingService.UpdateVerificationStatus(BillingName, "Unverified")))
                {
                    MessageBox.Show("You have successfully uploaded a timekeep file to this billing.", "Upload Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ParentControl?.ResetTableSearch();
                    Close();
                }
                else
                {
                    MessageBox.Show("Failed to upload timekeep data to this billing. Please try again.", "Upload Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                ToggleInputs(true);
            }
        }

        private List<EmployeeBase> CheckEmployeeExistense()
        {
            List<EmployeeBase> nonExistingEmployees = new();

            var employeeList = EmployeeService.GetAllEmployeesBase();
            var identifiersDictionary = ExcelService.GetAllIdentifiers(filePath, timekeepSheetName, 1, 2);

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
            cmbReportWorksheet.Enabled = state;
            cmbTimekeepSheet.Enabled = state;
        }
    }
}
