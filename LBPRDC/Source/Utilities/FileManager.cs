using OfficeOpenXml;

namespace LBPRDC.Source.Utilities
{
    internal class FileManager
    {
        public static string? OpenFile()
        {
            using OpenFileDialog openFile = new();
            openFile.Title = "Select an Excel File";
            openFile.Filter = "Excel Files|*.xlsx";
            openFile.Multiselect = false;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                return openFile.FileName;
            }

            return null;
        }

        public static string? ChooseSavingPath(string filename)
        {
            using SaveFileDialog saveFileDialog = new();
            saveFileDialog.FileName = filename;
            saveFileDialog.Title = "Select the saving path for the Excel Report";
            saveFileDialog.Filter = "Excel Files|*.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog.FileName;
            }

            return null;
        }

        public static bool isFileNotEmpty(string filePath)
        {
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                if (package.Workbook.Worksheets[0].Dimension == null)
                {
                    MessageBox.Show("The file you have loaded is empty. Please select another file.", "Empty Excel File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            return true;
        }

        public static bool isFileAdheresTo(string filePath, string format)
        {
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var sheet = package.Workbook.Worksheets[0];

                if (format == "Add Batch")
                {
                    for (int i = 1; i <= FileFormatConstants.addBatchFormat.Count; i++)
                    {
                        if (FileFormatConstants.addBatchFormat[i - 1] != sheet.Cells[1, i].Text)
                        {
                            MessageBox.Show("The content of this file is not supported by this operation. Please select another file.", "Excel File Not Valid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}
