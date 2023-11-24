using LBPRDC.Source.Services;
using LBPRDC.Source.Utilities;
using OfficeOpenXml;

namespace LBPRDC.Source.Views.Billing
{
    public partial class UploadFileForm : Form
    {
        public UploadFileForm()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                string? selectedFile = FileManager.OpenFile();

                if (selectedFile != null)
                {
                    this.Cursor = Cursors.WaitCursor;
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    txtFilePath.Text = selectedFile;
                    PopulateAndEnableWorksheetSelection(ExcelService.GetExcelWorksheetNames(selectedFile));
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void PopulateAndEnableWorksheetSelection(string[] worksheets)
        {
            cmbWorkSheet.Items.Clear();
            cmbWorkSheet.Enabled = worksheets.Length > 0;
            btnVerify.Enabled = worksheets.Length > 0;
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
    }
}
