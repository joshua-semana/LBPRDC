using OfficeOpenXml;

namespace LBPRDC.Source.Services
{
    internal class ExcelService
    {
        public static string[] GetExcelWorksheetNames(string filePath)
        {
            List<string> sheetNames = new();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheets = package.Workbook.Worksheets;
                sheetNames.AddRange(worksheets.Select(sheet => sheet.Name).ToList());
            }

            return sheetNames.ToArray();
        }
    }
}
