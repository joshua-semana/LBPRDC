using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;
using OfficeOpenXml;
using static LBPRDC.Source.Config.MessagesConstants;

namespace LBPRDC.Source.Views.Billing
{
    public partial class UploadAccrualsForm : Form
    {
        public BillingControl? ParentControl { get; set; } = null;
        public int BillingID { get; set; }
        public string BillingName { get; set; } = "";

        private readonly List<Control> RequiredFields;

        public UploadAccrualsForm()
        {
            InitializeComponent();

            RequiredFields = new()
            {
                txtFilePath
            };
        }

        private void UploadAccrualsForm_Load(object sender, EventArgs e)
        {
            if (BillingID == 0)
            {
                MessageBox.Show(Error.MISSING_BILLING, ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            this.Text = $"Upload accruals file to '{BillingName}'";
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
            cmbWorksheet.Items.Clear();
            cmbWorksheet.Enabled = worksheets.Length > 0;
            cmbWorksheet.Items.AddRange(worksheets);
            cmbWorksheet.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            if (ControlUtils.AreRequiredFieldsFilled(RequiredFields))
            {
                ToggleInputs(false);

                if (!ExcelService.AreAccrualsSheetValid(txtFilePath.Text, cmbWorksheet.Text))
                {
                    ToggleInputs(true);
                    return;
                }

                string selectedSheetName = cmbWorksheet.Text;

                var accrualsEntries = await Task.Run(() => ExcelService.FetchAccruals(txtFilePath.Text, selectedSheetName));
                if (accrualsEntries.Count > 0 && await Task.Run(() => BillingService.UpdateAccrualsJSON(accrualsEntries, BillingID)))
                {
                    MessageBox.Show("You have successfully uploaded an accruals file to this billing.", "Upload Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ParentControl?.ResetTableSearch();
                    Close();
                }
                else
                {
                    MessageBox.Show("Failed to upload accruals data to this billing. Please try again.", "Upload Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                ToggleInputs(true);
            }
        }

        private void ToggleInputs(bool state)
        {
            Cursor = (state == true) ? Cursors.Default : Cursors.WaitCursor;
            btnConfirm.Text = (state == true) ? "Confirm" : "Uploading";
            btnConfirm.Enabled = state;
            btnCancel.Enabled = state;
            btnSelect.Enabled = state;
            cmbWorksheet.Enabled = state;
        }
    }
}
