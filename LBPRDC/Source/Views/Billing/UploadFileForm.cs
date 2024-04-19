using LBPRDC.Source.Config;
using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;
using OfficeOpenXml;
using static LBPRDC.Source.Config.MessagesConstants;

namespace LBPRDC.Source.Views.Billing
{
    public partial class UploadFileForm : Form
    {
        public BillingControl? ParentControl { get; set; }
        public int ClientID { get; set; }
        public int BillingID { get; set; }
        public string Type { get; set; } = "";
        public bool IsVerified { get; set; }
        public string BillingName { get; set; } = "";

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
            if (ClientID == 0 || BillingID == 0)
            {
                MessageBox.Show(Error.MISSING_BILLING, ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

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
            var result = MessageBox.Show(MessagesConstants.Cancel.QUESTION, MessagesConstants.Cancel.TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

                if (Type == StringConstants.Operations.OVERWRITE)
                {
                    var recordsAreRemoved = await Task.Run(() => BillingRecordService.RemoveRecordsByID(BillingID));
                    if (!recordsAreRemoved)
                    {
                        MessageBox.Show("There's a problem overwriting the timekeeping file of this billing; please try again. If the error still persists, please call for support.", "Error Overwriting Timekeep File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                var entries = await Task.Run(() => ExcelService.PreProcessEntries(ClientID, txtFilePath.Text, reportSheetName, timekeepSheetName));

                if (entries.Count > 0 && await Task.Run(() => BillingService.UpdateConstantAndEditableJSON(entries, BillingID)))
                {
                    if (IsVerified)
                    {
                        await Task.Run(() => BillingService.UpdateVerificationStatus(BillingID, StringConstants.Status.UNVERIFIED));
                    }

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

        private async Task<List<EmployeeBase>> CheckEmployeeExistense()
        {
            List<EmployeeBase> nonExistingEmployees = new();

            var employeeIdentifiers = await EmployeeService.GetAllIdentifiersByClientID(ClientID);
            var timekeepIdentifiers = ExcelService.GetAllIdentifiers(filePath, timekeepSheetName);

            foreach (var (id, name) in timekeepIdentifiers)
            {
                //if (!employeeList.Any(emp => emp.EmployeeID.EndsWith(id.Substring(id.Length - 4)))) // This matches LB-M1-1234 with 1234 only
                if (!employeeIdentifiers.Any(emp => emp.EmployeeID.Equals(id)))
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
