using LBPRDC.Source.Utilities;
using OfficeOpenXml;
using System.DirectoryServices;
using System.Text.Json;

namespace LBPRDC.Source.Services
{
    public class Entry : EmployeeBase
    {
        public EntryTimeDetails? TimeDetails { get; set; }
        public EntryAdjustments[]? Adjustments { get; set; }
        public string[]? AdjustmentRemarks { get; set; }
        public string? InitialRemarks { get; set; } // Timekeeping Remarks
        public string? CustomRemarks { get; set; } // Your Remarks
        public string? Status { get; set; }
    }

    public class EntryTimeDetails
    {
        public TimeSpan RegularHours { get; set; }
        public TimeSpan LegalHoliday_100 { get; set; }
        public TimeSpan RegOT_125 { get; set; }
        public TimeSpan RestDayAndSpecialOT_130 { get; set; }
        public TimeSpan RestDayOTExcess_169 { get; set; }
        public TimeSpan SpecialExcessOT_195 { get; set; }
        public TimeSpan LegalHolidayOT_200 { get; set; }
        public TimeSpan LegalHolidayOT_260 { get; set; }
        public TimeSpan RestDayOT_150 { get; set; }
        public TimeSpan RegularHoliday_160 { get; set; }
        public TimeSpan NightDiff_10 { get; set; }
        public TimeSpan NightDiff_125 { get; set; }
        public TimeSpan NightDiff_130 { get; set; }
        public TimeSpan NightDiff_150 { get; set; }
        public TimeSpan NightDiff_20 { get; set; }
        public TimeSpan NightDiff_50 { get; set; }
        public TimeSpan UnderTime { get; set; }
        public TimeSpan Absent { get; set; }
    }

    public class EntryAdjustments
    {
        public int ID { get; set; }
        public string? Type { get; set; }
        public string? Operation { get; set; }
        public TimeSpan OriginalValue { get; set; }
        public TimeSpan InputValue { get; set; }
        public TimeSpan NewAdjustedValue { get; set; }
        public string? RawOriginalValue { get; set; }
        public string? RawInputValue { get; set; }
        public string? RawNewAdjustedValue { get; set; }
        public string? Units { get; set; }
        public string AppliedDate { get; set; }
    }

    public class EntryReportRemarks : EmployeeBase
    {
        public string? Remarks { get; set; }
    }

    internal class ExcelService
    {
        public static string? OpenFile()
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Title = "Select an Excel File";
                openFile.Filter = "Excel Files|*.xlsx";
                openFile.Multiselect = false;

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    return openFile.FileName;
                }
            }

            return null;
        }

        public static bool AreWorksheetsValid(string filePath, string reportSheet, string timekeepSheet)
        {
            using var file = new ExcelPackage(new FileInfo(filePath));

            var selectedReportWorksheet = file.Workbook.Worksheets[reportSheet];
            var selectedTimekeepSheet = file.Workbook.Worksheets[timekeepSheet];

            for (int i = 1; i <= FileFormatConstants.ExcelReportWorksheetFormat.Count; i++)
            {
                var text = selectedReportWorksheet.Cells[2, i].Text.ToString();
                if (!selectedReportWorksheet.Cells[2, i].Text.Contains(FileFormatConstants.ExcelReportWorksheetFormat[i - 1]))
                {
                    MessageBox.Show("The content of the report worksheet is not supported by this operation. Header columns do not match the set header constant format. Please select another worksheet. ", "Excel Worksheet Not Valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            for (int i = 1; i <= FileFormatConstants.ExcelTimekeepWorksheetFormat.Count; i++)
            {
                if (!selectedTimekeepSheet.Cells[1, i].Text.Contains(FileFormatConstants.ExcelTimekeepWorksheetFormat[i - 1]))
                {
                    MessageBox.Show("The content of the timekeep worksheet is not supported by this operation. Header columns do not match the set header constant format. Please select another worksheet. ", "Excel Worksheet Not Valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

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

        public static Dictionary<string, string> GetAllIdentifiers(string filePath, string sheetName, int idColumn, int nameColumn)
        {
            Dictionary<string, string> rowData = new();

            using var file = new ExcelPackage(new FileInfo(filePath));
            var sheet = file.Workbook.Worksheets[sheetName];

            int rowCount = sheet.Dimension.Rows;

            for (int row = 2; row < rowCount; row++)
            {
                object idValue = sheet.Cells[row, idColumn].Value;
                object nameValue = sheet.Cells[row, nameColumn].Value;

                if (idValue == null || idValue.ToString() == "#REF!" || nameValue.ToString() == "#REF!" || nameValue.ToString() == "#N/A") continue;

                string id = idValue.ToString();
                string name = nameValue.ToString();

                if (rowData.ContainsKey(id)) continue;

                rowData.Add(id, name);
            }

            return rowData;
        }

        public static TimeSpan ParseTime(string timeString)
        {
            string[] parts = timeString.Split(':');

            if (parts.Length != 2 || !int.TryParse(parts[0], out int hours) || !int.TryParse(parts[1], out int minutes))
            {
                return TimeSpan.Zero;
            }

            return new TimeSpan(hours, minutes, 0);
        }

        public static string GetTime(string value)
        {
            try
            {
                if (value == null || value == "")
                {
                    return "00:00";
                }

                if (value.Length == 1 && char.IsDigit(value[0]))
                {
                    return $"{value}:00";
                }

                if (decimal.TryParse(value, out decimal decimalValue))
                {
                    decimal targetValue = 0.3333333m;
                    decimal tolerance = 0.0000001m; 

                    if (Math.Abs(decimalValue - targetValue) < tolerance)
                    {
                        int hours = (int)Math.Round((decimalValue * 24));
                        return $"{hours:d2}:00";
                    }

                    if (decimalValue % 1 == 0.3m || decimalValue % 1 == 0.5m)
                    {
                        int hours = (int)decimalValue;
                        int minutes = 30;
                        return $"{hours:D2}:{minutes:D2}";
                    }
                }

                if (DateTime.TryParse(value, out DateTime dateTimeValue))
                {
                    return dateTimeValue.ToString("HH:mm");
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return "00:00";
        }

        public static List<Entry> PreProcessEntries(string filePath, string reportSheetName ,string timekeepSheetName)
        {
            List<Entry> entries = new();
            List<EntryReportRemarks> remarks = new();
            try
            {
                using var file = new ExcelPackage(new FileInfo(filePath));
                var reportSheet = file.Workbook.Worksheets[reportSheetName];
                var timekeepSheet = file.Workbook.Worksheets[timekeepSheetName];

                int reportRowCount = reportSheet.Dimension.Rows;
                int timekeepRowCount = timekeepSheet.Dimension.Rows;

                var employeeBase = EmployeeService.GetAllEmployeesBase();

                // Getting of remarks from the report
                for (int row = 7; row < reportRowCount; row++)
                {
                    string idValue = reportSheet.Cells[row, 1].Value?.ToString();
                    string nameValue = reportSheet.Cells[row, 2].Value?.ToString();

                    if (idValue == null || idValue == "#REF!" || idValue == "#N/A" || nameValue == "#REF!" || nameValue == "#N/A") continue;

                    var TimekeepRemarks = reportSheet.Cells[row, 30].Text;
                    
                    if (!remarks.Any(e => e.EmployeeID == idValue.ToString()))
                    {
                        remarks.Add(new EntryReportRemarks
                        {
                            EmployeeID = idValue,
                            Remarks = TimekeepRemarks
                        });
                    }
                }

                // Getting of data from Timekeep Sheet
                for (int row = 2; row < timekeepRowCount; row++)
                {
                    string idValue = timekeepSheet.Cells[row, 1].Value?.ToString();
                    string nameValue = timekeepSheet.Cells[row, 2].Value?.ToString();

                    if (idValue == null || idValue == "#REF!" || idValue == "#N/A" || nameValue == "#REF!" || nameValue == "#N/A") continue;

                    var RegularHours = ParseTime(GetTime(timekeepSheet.Cells[row, 6].Text));
                    var LegalHoliday_100 = ParseTime(GetTime(timekeepSheet.Cells[row, 7].Text));
                    var RegOT_125 = ParseTime(GetTime(timekeepSheet.Cells[row, 8].Text));
                    var RestDayOT_130 = ParseTime(GetTime(timekeepSheet.Cells[row, 9].Text));
                    var RestDayOTExcess_169 = ParseTime(GetTime(timekeepSheet.Cells[row, 10].Text));
                    var SpecialHolidayOT_130 = ParseTime(GetTime(timekeepSheet.Cells[row, 11].Text));
                    var SpecialExcessOT_195 = ParseTime(GetTime(timekeepSheet.Cells[row, 12].Text));
                    var LegalHolidayOT_200 = ParseTime(GetTime(timekeepSheet.Cells[row, 13].Text));
                    var LegalHolidayOT_260 = ParseTime(GetTime(timekeepSheet.Cells[row, 14].Text));
                    var RestDayOT_150 = ParseTime(GetTime(timekeepSheet.Cells[row, 15].Text));
                    var RegularHoliday_160 = ParseTime(GetTime(timekeepSheet.Cells[row, 16].Text));
                    var NightDiff_10 = ParseTime(GetTime(timekeepSheet.Cells[row, 18].Text));
                    var NightDiff_125 = ParseTime(GetTime(timekeepSheet.Cells[row, 19].Text));
                    var NightDiff_130 = ParseTime(GetTime(timekeepSheet.Cells[row, 20].Text));
                    var NightDiff_150 = ParseTime(GetTime(timekeepSheet.Cells[row, 21].Text));
                    var NightDiff_20 = ParseTime(GetTime(timekeepSheet.Cells[row, 22].Text));
                    var NightDiff_50 = ParseTime(GetTime(timekeepSheet.Cells[row, 23].Text));
                    var UnderTime = ParseTime(GetTime(timekeepSheet.Cells[row, 25].Text));
                    var Absent = ParseTime(GetTime(timekeepSheet.Cells[row, 26].Text));

                    if (entries.Any(e => e.EmployeeID == idValue.ToString()))
                    {
                        var currentEntry = entries.First(f => f.EmployeeID == idValue).TimeDetails;
                        currentEntry.RegularHours += RegularHours;
                        currentEntry.LegalHoliday_100 += LegalHoliday_100;
                        currentEntry.RegOT_125 += RegOT_125;
                        currentEntry.RestDayAndSpecialOT_130 += RestDayOT_130.Add(SpecialHolidayOT_130);
                        currentEntry.RestDayOTExcess_169 += RestDayOTExcess_169;
                        currentEntry.SpecialExcessOT_195 += SpecialExcessOT_195;
                        currentEntry.LegalHolidayOT_200 += LegalHolidayOT_200;
                        currentEntry.LegalHolidayOT_260 += LegalHolidayOT_260;
                        currentEntry.RestDayOT_150 += RestDayOT_150;
                        currentEntry.RegularHoliday_160 += RegularHoliday_160;
                        currentEntry.NightDiff_10 += NightDiff_10;
                        currentEntry.NightDiff_125 += NightDiff_125;
                        currentEntry.NightDiff_130 += NightDiff_130;
                        currentEntry.NightDiff_150 += NightDiff_150;
                        currentEntry.NightDiff_20 += NightDiff_20;
                        currentEntry.NightDiff_50 += NightDiff_50;
                        currentEntry.UnderTime += UnderTime;
                        currentEntry.Absent += Absent;
                    }
                    else
                    {
                        var currentEmployee = employeeBase.First(f => f.EmployeeID == idValue);

                        entries.Add(new Entry
                        {
                            EmployeeID = idValue.ToString(),
                            FullName = $"{currentEmployee.LastName}, {currentEmployee.FirstName} {currentEmployee.MiddleName}".Trim(),
                            Position = currentEmployee.Position,
                            Department = currentEmployee.Department,
                            Location = currentEmployee.Location,
                            TimeDetails = new EntryTimeDetails
                            {
                                RegularHours = RegularHours,
                                LegalHoliday_100 = LegalHoliday_100,
                                RegOT_125 = RegOT_125,
                                RestDayAndSpecialOT_130 = RestDayOT_130.Add(SpecialHolidayOT_130),
                                RestDayOTExcess_169 = RestDayOTExcess_169,
                                SpecialExcessOT_195 = SpecialExcessOT_195,
                                LegalHolidayOT_200 = LegalHolidayOT_200,
                                LegalHolidayOT_260 = LegalHolidayOT_260,
                                RestDayOT_150 = RestDayOT_150,
                                RegularHoliday_160 = RegularHoliday_160,
                                NightDiff_10 = NightDiff_10,
                                NightDiff_125 = NightDiff_125,
                                NightDiff_130 = NightDiff_130,
                                NightDiff_150 = NightDiff_150,
                                NightDiff_20 = NightDiff_20,
                                NightDiff_50 = NightDiff_50,
                                UnderTime = UnderTime,
                                Absent = Absent,
                            },
                            Status = "Unverified"
                        });
                    }
                }

                //Getting the remarks and saving it to each entries
                foreach (var entry in entries)
                {
                    string? timekeepRemarks = remarks.FirstOrDefault(f => f.EmployeeID == entry.EmployeeID).Remarks;
                    entry.InitialRemarks = timekeepRemarks;
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
            
            return entries;
        }

        public static bool SaveEntries(List<Entry> entries, string fileName)
        {
            try
            {
                string appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string appDataSubDir = Path.Combine(appDataDir, "LBPRDC");
                Directory.CreateDirectory(appDataSubDir);
                string settingsFilePath = Path.Combine(appDataSubDir, $"{fileName}.json");

                string json = JsonSerializer.Serialize(entries);
                File.WriteAllText(settingsFilePath, json);

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static List<Entry> LoadEntries(string fileName)
        {
            List<Entry> entries = new();

            try
            {
                string appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string filePath = Path.Combine(appDataDir, "LBPRDC", $"{fileName}.json");

                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    return JsonSerializer.Deserialize<List<Entry>>(json);
                }
                else
                {
                    MessageBox.Show("Saved progress cannot be loaded. Please upload another file to proceed.", "Error Loading Progress", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return entries;
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return entries;
        }
    }
}
