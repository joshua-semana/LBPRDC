using LBPRDC.Source.Config;
using LBPRDC.Source.Utilities;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Configuration;
using System.Text.Json;
using static LBPRDC.Source.Config.StringConstants;

namespace LBPRDC.Source.Services
{
    public class Entry : EmployeeBase
    {
        public Guid Guid { get; set; }
        public EntryTimeDetails? TimeDetails { get; set; }
        public EntryAdjustments[]? Adjustments { get; set; }
        public AdjustmentRemarks[]? AdjustmentRemarks { get; set; }
        public string? TimekeepRemarks { get; set; } // Timekeeping Remarks
        public string? FinalReportRemarks { get; set; } // Your Remarks
        public string? BookmarkRemarks { get; set; } // If has data, turn the emloyee name in list to be color red.
        public string? VerificationStatus { get; set; }
        public string? EntryType { get; set; } // Regular Entry or Custom Entry
        public bool ExportIncluded { get; set; }
    }

    public class EntryTimeDetails
    {
        public TimeSpan RegularHours { get; set; }
        public TimeSpan LegalHoliday_100 { get; set; }
        public TimeSpan RegOT_125 { get; set; }
        public TimeSpan RestDaySpecialOT_130 { get; set; }
        public TimeSpan RestDaySpecialOT_150 { get; set; }
        public TimeSpan RestDaySpecialOTExcess_169 { get; set; }
        public TimeSpan SpecialExcessOT_195 { get; set; }
        public TimeSpan LegalHolidayOT_200 { get; set; }
        public TimeSpan LegalHolidayOT_260 { get; set; }
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

    public class EntryReportRemarks : EmployeeBase
    {
        public string? TimekeepRemarks { get; set; }
    }

    public class AdjustmentOvertimePair
    {
        public string? FullName { get; set; }
        public string? PositionCode { get; set; }
        public string? Value { get; set; }
    }

    public class BalancingRowDetails
    {
        public string? AccrualsFullName { get; set; }
        public string? BillingFullName { get; set; }
        public decimal? AccrualsValue { get; set; }
        public decimal? BillingValue { get; set; }
        public string? BillingRemarks { get; set; }
    }

    public class AccrualsEntry
    {
        public string EmployeeID { get; set; } = "";
        public string EmployeeName { get; set; } = "";
        public string EmployeePosition { get; set; } = "";
        public decimal BillingRate { get; set; }
        public decimal RegularBillingValue { get; set; }
        public decimal OvertimeBillingValue { get; set; }
        public bool HasAdded { get; set; } = false;
        public string Department { get; set; } = "";
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

        public static bool AreTimekeepSheetsValid(string filePath, string reportSheet, string timekeepSheet)
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
                    MessageBox.Show("The content of the timekeep worksheet is not supported by this operation. Header columns do not match the set header constant format. Please select another worksheet.", "Excel Worksheet Not Valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        public static bool AreAccrualsSheetValid(string filePath, string sheet)
        {
            using var file = new ExcelPackage(new FileInfo(filePath));

            var selectedSheet = file.Workbook.Worksheets[sheet];

            for (int i = 1; i <= FileFormatConstants.ExcelAccrualsWorksheetFormat.Count; i++)
            {
                var text = selectedSheet.Cells[2, i].Text.ToString();
                if (!selectedSheet.Cells[7, i].Text.Contains(FileFormatConstants.ExcelAccrualsWorksheetFormat[i - 1]))
                {
                    MessageBox.Show("The content of the worksheet is not supported by this operation. Header columns do not match the set header constant format. Please select another worksheet.", "Excel Worksheet Not Valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public static Dictionary<string, string> GetAllIdentifiers(string filePath, string sheetName)
        {
            int CONFIG_TIMEKEEP_ROW_START = Convert.ToInt32(ConfigurationManager.AppSettings["TimekeepRow_Start"]);
            string CONFIG_TIMEKEEP_COLUMN_EMPLOYEEID = ConfigurationManager.AppSettings["TimekeepColumn_Identifier_EmployeeID"] ?? "A";
            string CONFIG_TIMEKEEP_COLUMN_EMPLOYEENAME = ConfigurationManager.AppSettings["TimekeepColumn_Identifier_EmployeeName"] ?? "B";

            Dictionary<string, string> rowData = new();

            using var file = new ExcelPackage(new FileInfo(filePath));
            var sheet = file.Workbook.Worksheets[sheetName];
            int rowCount = sheet.Dimension.Rows;

            for (int row = CONFIG_TIMEKEEP_ROW_START; row < rowCount; row++)
            {
                object idValue = sheet.Cells[$"{CONFIG_TIMEKEEP_COLUMN_EMPLOYEEID}{row}"].Value;
                object nameValue = sheet.Cells[$"{CONFIG_TIMEKEEP_COLUMN_EMPLOYEENAME}{row}"].Value;

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

        public static async Task<List<Entry>> PreProcessEntries(int ClientID, string filePath, string reportSheetName, string timekeepSheetName)
        {
            int CONFIG_TIMEKEEP_ROW_START = Convert.ToInt32(ConfigurationManager.AppSettings["TimekeepRow_Start"]);
            string CONFIG_TIMEKEEP_COLUMN_EMPLOYEEID = ConfigurationManager.AppSettings["TimekeepColumn_EmployeeID"] ?? "A";
            string CONFIG_TIMEKEEP_COLUMN_EMPLOYEENAME = ConfigurationManager.AppSettings["TimekeepColumn_EmployeeName"] ?? "B";
            string CONFIG_TIMEKEEP_COLUMN_DATE = ConfigurationManager.AppSettings["TimekeepColumn_Date"] ?? "C";
            string CONFIG_TIMEKEEP_COLUMN_REGULARHOURS = ConfigurationManager.AppSettings["TimekeepColumn_RegularHours"] ?? "F";
            string CONFIG_TIMEKEEP_COLUMN_LEGALHOLIDAY_100 = ConfigurationManager.AppSettings["TimekeepColumn_LegalHoliday_100"] ?? "G";
            string CONFIG_TIMEKEEP_COLUMN_REGOVERTIME_125 = ConfigurationManager.AppSettings["TimekeepColumn_RegOvertime_125"] ?? "H";
            string CONFIG_TIMEKEEP_COLUMN_RESTDAYOVERTIME_130 = ConfigurationManager.AppSettings["TimekeepColumn_RestDayOvertime_130"] ?? "I";
            string CONFIG_TIMEKEEP_COLUMN_RESTDAYOVERTIMEEXCESS_169 = ConfigurationManager.AppSettings["TimekeepColumn_RestDayOvertimeExcess_169"] ?? "J";
            string CONFIG_TIMEKEEP_COLUMN_SPECIALHOLIDAYOVERTIME_130 = ConfigurationManager.AppSettings["TimekeepColumn_SpecialHolidayOvertime_130"] ?? "K";
            string CONFIG_TIMEKEEP_COLUMN_SPECIALEXCESSOVERTIME_195 = ConfigurationManager.AppSettings["TimekeepColumn_SpecialExcessOvertime_195"] ?? "L";
            string CONFIG_TIMEKEEP_COLUMN_LEGALHOLIDAYOVERTIME_200 = ConfigurationManager.AppSettings["TimekeepColumn_LegalHolidayOvertime_200"] ?? "M";
            string CONFIG_TIMEKEEP_COLUMN_LEGALHOLIDAYOVERTIME_260 = ConfigurationManager.AppSettings["TimekeepColumn_LegalHolidayOvertime_260"] ?? "N";
            string CONFIG_TIMEKEEP_COLUMN_RESTDAYOVERTIME_150 = ConfigurationManager.AppSettings["TimekeepColumn_RestDayOvertime_150"] ?? "O";
            string CONFIG_TIMEKEEP_COLUMN_REGULARHOLIDAY = ConfigurationManager.AppSettings["TimekeepColumn_RegularHoliday"] ?? "P";
            string CONFIG_TIMEKEEP_COLUMN_NIGHTDIFFERENTIAL_10 = ConfigurationManager.AppSettings["TimekeepColumn_NightDifferential_10"] ?? "R";
            string CONFIG_TIMEKEEP_COLUMN_NIGHTDIFFERENTIAL_125 = ConfigurationManager.AppSettings["TimekeepColumn_NightDifferential_125"] ?? "S";
            string CONFIG_TIMEKEEP_COLUMN_NIGHTDIFFERENTIAL_130 = ConfigurationManager.AppSettings["TimekeepColumn_NightDifferential_130"] ?? "T";
            string CONFIG_TIMEKEEP_COLUMN_NIGHTDIFFERENTIAL_150 = ConfigurationManager.AppSettings["TimekeepColumn_NightDifferential_150"] ?? "U";
            string CONFIG_TIMEKEEP_COLUMN_NIGHTDIFFERENTIAL_20 = ConfigurationManager.AppSettings["TimekeepColumn_NightDifferential_20"] ?? "V";
            string CONFIG_TIMEKEEP_COLUMN_NIGHTDIFFERENTIAL_50 = ConfigurationManager.AppSettings["TimekeepColumn_NightDifferential_50"] ?? "W";
            string CONFIG_TIMEKEEP_COLUMN_UNDERTIME = ConfigurationManager.AppSettings["TimekeepColumn_UnderTime"] ?? "Y";
            string CONFIG_TIMEKEEP_COLUMN_ABSENT = ConfigurationManager.AppSettings["TimekeepColumn_Absent"] ?? "Z";

            List<Entry> entries = new();
            List<EntryReportRemarks> remarks = new();

            try
            {
                using var file = new ExcelPackage(new FileInfo(filePath));
                var reportSheet = file.Workbook.Worksheets[reportSheetName];
                var timekeepSheet = file.Workbook.Worksheets[timekeepSheetName];

                int reportRowCount = reportSheet.Dimension.Rows;
                int timekeepRowCount = timekeepSheet.Dimension.Rows;

                // Getting the remarks from the report sheet
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
                            TimekeepRemarks = TimekeepRemarks
                        });
                    }
                }

                // Getting data from Timekeep Sheet
                var employees = await EmployeeService.GetEmployees(ClientID);
                var allPositionHistory = await PositionService.GetHistories();
                var positionAndRates = await PositionService.GetItems(ClientID);

                var databaseGuids = new HashSet<Guid>(BillingRecordService.GetGuids());

                for (int row = CONFIG_TIMEKEEP_ROW_START; row < timekeepRowCount; row++)
                {
                    Guid newGuid = Guid.NewGuid();
                    while (databaseGuids.Contains(newGuid))
                    {
                        newGuid = Guid.NewGuid();
                    }

                    string? idValue = timekeepSheet.Cells[$"{CONFIG_TIMEKEEP_COLUMN_EMPLOYEEID}{row}"].Value?.ToString();
                    string? nameValue = timekeepSheet.Cells[$"{CONFIG_TIMEKEEP_COLUMN_EMPLOYEENAME}{row}"].Value?.ToString();
                    string Date = timekeepSheet.Cells[$"{CONFIG_TIMEKEEP_COLUMN_DATE}{row}"].Text;

                    if (idValue == null || idValue == "#REF!" || idValue == "#N/A" || nameValue == "#REF!" || nameValue == "#N/A" || Date == null || Date == string.Empty) continue;

                    var RegularHours = ParseTime(GetTime(timekeepSheet.Cells[$"{CONFIG_TIMEKEEP_COLUMN_REGULARHOURS}{row}"].Text));
                    var LegalHoliday_100 = ParseTime(GetTime(timekeepSheet.Cells[$"{CONFIG_TIMEKEEP_COLUMN_LEGALHOLIDAY_100}{row}"].Text));
                    var RegOT_125 = ParseTime(GetTime(timekeepSheet.Cells[$"{CONFIG_TIMEKEEP_COLUMN_REGOVERTIME_125}{row}"].Text));
                    var RestDayOT_130 = ParseTime(GetTime(timekeepSheet.Cells[$"{CONFIG_TIMEKEEP_COLUMN_RESTDAYOVERTIME_130}{row}"].Text));
                    var RestDayOTExcess_169 = ParseTime(GetTime(timekeepSheet.Cells[$"{CONFIG_TIMEKEEP_COLUMN_RESTDAYOVERTIMEEXCESS_169}{row}"].Text));
                    var SpecialHolidayOT_130 = ParseTime(GetTime(timekeepSheet.Cells[$"{CONFIG_TIMEKEEP_COLUMN_SPECIALHOLIDAYOVERTIME_130}{row}"].Text));
                    var SpecialExcessOT_195 = ParseTime(GetTime(timekeepSheet.Cells[$"{CONFIG_TIMEKEEP_COLUMN_SPECIALEXCESSOVERTIME_195}{row}"].Text));
                    var LegalHolidayOT_200 = ParseTime(GetTime(timekeepSheet.Cells[$"{CONFIG_TIMEKEEP_COLUMN_LEGALHOLIDAYOVERTIME_200}{row}"].Text));
                    var LegalHolidayOT_260 = ParseTime(GetTime(timekeepSheet.Cells[$"{CONFIG_TIMEKEEP_COLUMN_LEGALHOLIDAYOVERTIME_260}{row}"].Text));
                    var RestDayOT_150 = ParseTime(GetTime(timekeepSheet.Cells[$"{CONFIG_TIMEKEEP_COLUMN_RESTDAYOVERTIME_150}{row}"].Text));
                    var RegularHoliday_160 = ParseTime(GetTime(timekeepSheet.Cells[$"{CONFIG_TIMEKEEP_COLUMN_REGULARHOLIDAY}{row}"].Text));
                    var NightDiff_10 = ParseTime(GetTime(timekeepSheet.Cells[$"{CONFIG_TIMEKEEP_COLUMN_NIGHTDIFFERENTIAL_10}{row}"].Text));
                    var NightDiff_125 = ParseTime(GetTime(timekeepSheet.Cells[$"{CONFIG_TIMEKEEP_COLUMN_NIGHTDIFFERENTIAL_125}{row}"].Text));
                    var NightDiff_130 = ParseTime(GetTime(timekeepSheet.Cells[$"{CONFIG_TIMEKEEP_COLUMN_NIGHTDIFFERENTIAL_130}{row}"].Text));
                    var NightDiff_150 = ParseTime(GetTime(timekeepSheet.Cells[$"{CONFIG_TIMEKEEP_COLUMN_NIGHTDIFFERENTIAL_150}{row}"].Text));
                    var NightDiff_20 = ParseTime(GetTime(timekeepSheet.Cells[$"{CONFIG_TIMEKEEP_COLUMN_NIGHTDIFFERENTIAL_20}{row}"].Text));
                    var NightDiff_50 = ParseTime(GetTime(timekeepSheet.Cells[$"{CONFIG_TIMEKEEP_COLUMN_NIGHTDIFFERENTIAL_50}{row}"].Text));
                    var UnderTime = ParseTime(GetTime(timekeepSheet.Cells[$"{CONFIG_TIMEKEEP_COLUMN_UNDERTIME}{row}"].Text));
                    var Absent = ParseTime(GetTime(timekeepSheet.Cells[$"{CONFIG_TIMEKEEP_COLUMN_ABSENT}{row}"].Text));

                    var employeeIntID = employees.First(f => f.EmployeeID == idValue).ID;
                    var positions = allPositionHistory.Where(w => w.EmployeeID == employeeIntID).OrderByDescending(ob => ob.Timestamp).ToList();
                    int positionID = GetPositionIdByDate(positions, Convert.ToDateTime(Date));

                    if (entries.Any(e => e.EmployeeID == idValue.ToString() && e.PositionID == positionID))
                    {
                        var currentEntry = entries.First(f => f.EmployeeID == idValue && f.PositionID == positionID).TimeDetails;
                        currentEntry.RegularHours += RegularHours;
                        currentEntry.LegalHoliday_100 += LegalHoliday_100;
                        currentEntry.RegOT_125 += RegOT_125;
                        currentEntry.RestDaySpecialOT_130 += RestDayOT_130.Add(SpecialHolidayOT_130);
                        currentEntry.RestDaySpecialOTExcess_169 += RestDayOTExcess_169;
                        currentEntry.SpecialExcessOT_195 += SpecialExcessOT_195;
                        currentEntry.LegalHolidayOT_200 += LegalHolidayOT_200;
                        currentEntry.LegalHolidayOT_260 += LegalHolidayOT_260;
                        currentEntry.RestDaySpecialOT_150 += RestDayOT_150;
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
                        var currentEmployee = employees.First(f => f.EmployeeID == idValue);

                        entries.Add(new Entry
                        {
                            Guid = newGuid,
                            EmployeeID = idValue.ToString(),
                            FullName = currentEmployee.FullName,
                            PositionID = positionID,
                            Department = currentEmployee.DepartmentName,
                            Location = currentEmployee.LocationName,
                            DailyBillingRate = positionAndRates.First(f => f.ID == positionID).DailyBillingRate,
                            DailySalaryRate = positionAndRates.First(f => f.ID == positionID).DailySalaryRate,
                            TimeDetails = new EntryTimeDetails
                            {
                                RegularHours = RegularHours,
                                LegalHoliday_100 = LegalHoliday_100,
                                RegOT_125 = RegOT_125,
                                RestDaySpecialOT_130 = RestDayOT_130.Add(SpecialHolidayOT_130),
                                RestDaySpecialOTExcess_169 = RestDayOTExcess_169,
                                SpecialExcessOT_195 = SpecialExcessOT_195,
                                LegalHolidayOT_200 = LegalHolidayOT_200,
                                LegalHolidayOT_260 = LegalHolidayOT_260,
                                RestDaySpecialOT_150 = RestDayOT_150,
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
                            EntryType = StringConstants.Type.REGULAR,
                            VerificationStatus = StringConstants.Status.UNVERIFIED,
                            ExportIncluded = true
                        });
                    }
                }

                //Getting the remarks and saving it to each entries
                foreach (var entry in entries)
                {
                    string timekeepRemarks = remarks.FirstOrDefault(f => f.EmployeeID == entry.EmployeeID)?.TimekeepRemarks ?? "Error getting remarks for this employee.";
                    entry.TimekeepRemarks = timekeepRemarks;
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
            
            return entries;
        }

        public static int GetPositionIdByDate(List<Models.Position.History> positions, DateTime date)
        {
            for (int i = 0; i < positions.Count; i++)
            {
                if (date.Date >= positions[i].Timestamp.Date)
                {
                    return positions[i].PositionID;
                }
            }
            return positions[positions.Count - 1].PositionID;
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

        public static bool HasContentInOvertime(Entry entry)
        {
            return entry.TimeDetails != null &&
                   (entry.TimeDetails.RegOT_125 != TimeSpan.Zero || entry.TimeDetails.RestDaySpecialOT_130 != TimeSpan.Zero ||
                    entry.TimeDetails.RestDaySpecialOTExcess_169 != TimeSpan.Zero || entry.TimeDetails.SpecialExcessOT_195 != TimeSpan.Zero ||
                    entry.TimeDetails.LegalHolidayOT_200 != TimeSpan.Zero || entry.TimeDetails.LegalHolidayOT_260 != TimeSpan.Zero ||
                    entry.TimeDetails.RestDaySpecialOT_150 != TimeSpan.Zero || entry.TimeDetails.RegularHoliday_160 != TimeSpan.Zero ||
                    entry.TimeDetails.NightDiff_10 != TimeSpan.Zero || entry.TimeDetails.NightDiff_125 != TimeSpan.Zero ||
                    entry.TimeDetails.NightDiff_130 != TimeSpan.Zero || entry.TimeDetails.NightDiff_150 != TimeSpan.Zero ||
                    entry.TimeDetails.NightDiff_20 != TimeSpan.Zero || entry.TimeDetails.NightDiff_50 != TimeSpan.Zero);
        }

        private static void ConvertToMoney(ExcelWorksheet sheet, string cell) => sheet.Cells[cell].Style.Numberformat.Format = "#,##0.00";
        private static void ConvertToParenthesis(ExcelWorksheet sheet, string cell) => sheet.Cells[cell].Style.Numberformat.Format = "(0)";
        private static void ConvertToDecimal(ExcelWorksheet sheet, string cell) => sheet.Cells[cell].Style.Numberformat.Format = "0.00";
        private static void ConvertToTime(ExcelWorksheet sheet, string cell) => sheet.Cells[cell].Style.Numberformat.Format = "[h]:mm";
        private static void SetCellToCenter(ExcelWorksheet sheet, string cell) => sheet.Cells[cell].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        private static void SetCellToBold(ExcelWorksheet sheet, string cell) => sheet.Cells[cell].Style.Font.Bold = true;
        private static void DecreaseRowHeight(ExcelWorksheet sheet, int row) => sheet.Row(row).Height = 5.25;
        private static void IncreaseRowHeight(ExcelWorksheet sheet, int row) => sheet.Row(row).Height = 48;
        private static void ComputeColumnTotal(ExcelWorksheet sheet, int start, int row, string col) => sheet.Cells[$"{col}{row}"].Formula = $"=ROUND(SUMPRODUCT({col}{start}:{col}{row - 2}, --(MOD(ROW({col}{start}:{col}{row - 2}), 2) =0)), 2)";

        private static List<BillingRecord> BillingRecords = new();

        public static async Task<bool> ExportBilling(int BillingID, int ClientID, List<Entry> entries, string billingName, string filePath, string exportType, List<Guid> removedEntries)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            if (BillingID == 0 || ClientID == 0)
            {
                MessageBox.Show(MessagesConstants.Error.MISSING_CLIENT_BILLING, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var clientInfo = await ClientService.GetClientByID(ClientID);
            var billing = await BillingService.GetBillingDetailsById(BillingID);
            var departments = await DepartmentService.GetItems(ClientID);
            var positionAndRates = await PositionService.GetItems(ClientID);

            try
            {
                using var package = new ExcelPackage();

                var groupedEntries = entries.GroupBy(entry => entry.Department);
                var adjustmentSheet = package.Workbook.Worksheets.Add(StringConstants.SheetName.ADJUSTMENT.ToUpper());

                int adjRow = 1;
                
                foreach (var department in groupedEntries)
                {
                    List<AdjustmentOvertimePair> overtimePairs = new();

                    string departmentName = department.Key?.ToString() ?? StringConstants.SheetName.UNDEFINED;
                    string? departmentCode = departments.First(f => f.Name == department.Key).Code ?? StringConstants.SheetName.UNDEFINED;
                    var regularSheet = package.Workbook.Worksheets.Add(departmentName.ToUpper());
                    var overtimeSheet = package.Workbook.Worksheets.Add($"{departmentName.ToUpper()} {StringConstants.Type.OVERTIME.ToUpper()}");

                    (string dateCoverage, string regularAccountNumber) = SetReportHeadersRegular(clientInfo, regularSheet, departmentCode, billing.StartDate, billing.EndDate);
                    string overtimeAccountNumber = SetReportHeadersOvertime(clientInfo, overtimeSheet, departmentCode, billing.Quarter, billing.StartDate, billing.EndDate);

                    if (department.Any(a => a.AdjustmentRemarks != null && a.AdjustmentRemarks.Any(aa => aa.Type == "regular")))
                    {
                        adjRow = AddAdjustmentTitle(adjustmentSheet, adjRow, departmentName);
                    }

                    int regIndex = 1, overIndex = 1;
                    int regRow = 8, overRow = 8;

                    foreach (var entry in department)
                    {
                        // Addition of entries to regular and overtime department sheet
                        if (!entry.ExportIncluded) continue;
                        (regIndex, regRow) = AddToRegularSheet(BillingID, ClientID, regularSheet, entry, regIndex, regRow, regularAccountNumber, billingName, exportType);
                        if (HasContentInOvertime(entry)) (overIndex, overRow) = AddToOvertimeSheet(BillingID, ClientID, overtimeSheet, entry, overIndex, overRow, overtimeAccountNumber, billingName, exportType);

                        // Addition of Adjustment Rows
                        if (entry.AdjustmentRemarks == null) continue;
                        string regularRemarks = string.Join(", ", entry.AdjustmentRemarks.Where(w => w.Type == "regular").Select(s => s.Value).ToArray());
                        if (!string.IsNullOrEmpty(regularRemarks))
                        {
                            string? positionCode = positionAndRates.First(f => f.ID == entry.PositionID).Code;
                            adjRow = AddAdjustmentRow(adjustmentSheet, adjRow, $"{entry.FullName} | {positionCode}", regularRemarks);
                        }

                        string overtimeRemarks = string.Join(", ", entry.AdjustmentRemarks.Where(w => w.Type == "overtime").Select(s => s.Value).ToArray());
                        if (!string.IsNullOrEmpty(overtimeRemarks))
                        {
                            overtimePairs.Add(new()
                            {
                                FullName = entry.FullName,
                                PositionCode = positionAndRates.First(f => f.ID == entry.PositionID).Code,
                                Value = overtimeRemarks
                            });
                        }
                    }

                    SetPrintSettings(regularSheet, dateCoverage);
                    SetPrintSettings(overtimeSheet, dateCoverage);

                    if (overtimePairs.Count > 0)
                    {
                        adjRow = AddAdjustmentTitle(adjustmentSheet, adjRow, $"{departmentName.ToUpper()} {StringConstants.Type.OVERTIME.ToUpper()}");
                        foreach (var pair in overtimePairs)
                        {
                            adjRow = AddAdjustmentRow(adjustmentSheet, adjRow, $"{pair.FullName} | {pair.PositionCode}", pair.Value);
                        }
                    }

                    adjRow += 1;

                    regularSheet.Cells[$"A{regRow - 1}:J{regRow - 1}"].Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    overtimeSheet.Cells[$"A{overRow - 1}:U{overRow - 1}"].Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    DecreaseRowHeight(regularSheet, regRow);
                    DecreaseRowHeight(overtimeSheet, overRow);

                    regRow++; overRow++;
                    ComputeRegularTotal(regularSheet, regRow);
                    ComputeOvertimeTotal(overtimeSheet, overRow);
                    overtimeSheet.Calculate();
                    var t1 = overtimeSheet.Cells[$"U{overRow}"].Value; // GOT THE GROSS BILLING

                    regRow++; overRow++;
                    DecreaseRowHeight(regularSheet, regRow);
                    DecreaseRowHeight(overtimeSheet, overRow);

                    regRow++; overRow++;
                    AddNetBilling(regularSheet, regRow, "I", "J");
                    AddNetBilling(overtimeSheet, overRow, "T", "U");

                    regRow += 2; overRow += 2;
                    AddFooter(regularSheet, regRow, billing.OfficerName, billing.OfficerPosition);
                    AddFooter(overtimeSheet, overRow, billing.OfficerName, billing.OfficerPosition);
                    SetCellToBold(regularSheet, $"A{regRow - 4}:J{regRow + 2}");
                    SetCellToBold(overtimeSheet, $"A{overRow - 4}:U{overRow + 2}");
                    SetColumnWidthsRegular(regularSheet);
                    SetColumnWidthsOvertime(overtimeSheet);
                }

                // Add legend within the end of the Adjustment Sheet
                adjRow = AddAdjustmentTitle(adjustmentSheet, adjRow, "LEGEND");
                AddLegend(adjustmentSheet, adjRow);
                SetColumnWidthsAdjustment(adjustmentSheet);

                if (filePath != "")
                {
                    try
                    {
                        package.SaveAs(new FileInfo(filePath));
                    }
                    catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
                }

                if (exportType == StringConstants.Status.UNRELEASED)
                {
                    if (removedEntries.Any())
                    {
                        await BillingRecordService.RemoveRecordsByGuid(removedEntries, BillingID);
                    }

                    var output = BillingRecordService.Add(BillingID, billingName, BillingRecords);
                    if (output)
                    {
                        BillingRecords.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Error in saving temporary billing records, you cannot process accruals balancing if you encounter this error.", "Error Saving Billing Records", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    return output;
                }

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        private static int AddAdjustmentTitle(ExcelWorksheet sheet, int row, string title)
        {
            var cell = sheet.Cells[$"A{row}:B{row}"];
            cell.Value = title;
            cell.Merge = true;
            cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
            cell.Style.Fill.BackgroundColor.SetColor(Color.PaleGreen);
            SetCellToBold(sheet, $"A{row}:B{row}");
            return row += 1;
        }

        private static int AddAdjustmentRow(ExcelWorksheet sheet, int row, string value1, string value2)
        {
            sheet.Cells[$"A{row}"].Value = value1;
            sheet.Cells[$"B{row}"].Value = value2;
            return row += 1;
        }

        private static void AddLegend(ExcelWorksheet sheet, int row)
        {
            Dictionary<string, string> legendMapping = new()
            {
                { "Regular Days", "REG" },
                { "Undertime", "UT" },
                { "Legal Holiday 100%", "LH 100%" },
                { "Regular Overtime 125%", "REG OT 125%" },
                { "Regular Holiday 160%", "RHOT 160%" },
                { "Rest Day/Special Holiday 130%", "RDOT/SHOT 130%" },
                { "Rest Day Special Holiday 150%", "RDOT 150%" },
                { "Rest Day/Special Holiday Excess 169%", "RDOT Excess 169%" },
                { "Special Holiday Excess Overtime 195%", "SHOT Excess" },
                { "Legal Holiday Overtime 200%", "LHOT 200%" },
                { "Legal Holiday Overtime 260%", "LHOT 260%" },
                { "Night Differential 10%", "NDOT 10%" },
                { "Night Differential 20%", "NDOT 20%" },
                { "Night Differential 50%", "NDOT 50%" },
                { "Night Differential 125%", "NDOT 125%" },
                { "Night Differential 130%", "NDOT 130%" },
                { "Night Differential 150%", "NDOT 150%" },
            };

            foreach (var (key, value) in legendMapping)
            {
                AddAdjustmentRow(sheet, row, value, key);
                row++;
            }
        }

        private static (string, string) SetReportHeadersRegular(Models.Client Client, ExcelWorksheet sheet, string departmentCode, DateTime startDate, DateTime endDate)
        {
            string headerStartDate = startDate.ToString("MMMM dd");
            string headerEndDate = endDate.ToString("yyyy");
            string soaStartDate = startDate.ToString("MM-dd");
            string soaEndDate = endDate.ToString("yy");

            DecreaseRowHeight(sheet, 5);
            IncreaseRowHeight(sheet, 7);

            string dateCoverage = $"{headerStartDate.ToUpper()}-{endDate.Day}, {headerEndDate}";

            AddHeader(sheet, "A1:J1", "LBP RESOURCES AND DEVELOPMENT CORPORATION", 14, true);
            AddHeader(sheet, "A2:J2", "STATEMENT OF ACCOUNT", 14, true);
            AddHeader(sheet, "A3:J3", $"CLIENT: {Client.Description.ToUpper()}", 14, true);
            AddHeader(sheet, "A4:J4", $"FOR THE PERIOD OF {dateCoverage}", 14, true);

            string accountNumber = $"{Client.Name.ToUpper()}-{departmentCode}-{soaStartDate}-{endDate.Day}-{soaEndDate}";

            AddAccountNumber(sheet, "H", "I", accountNumber);

            AddHeader(sheet, "A7", "No.", 11, true);
            AddHeader(sheet, "B7", "Name", 11, true);
            AddHeader(sheet, "C7", "Position", 11, true);
            AddHeader(sheet, "D7", "Billing Rate", 11, true);
            AddHeader(sheet, "E7", "# of worked days", 11, true);
            AddHeader(sheet, "F7", "Reg Bill Wrk days", 11, true);
            AddHeader(sheet, "G7", "UTIME", 11, true);
            AddHeader(sheet, "H7", "LH (100%)", 11, true);
            AddHeader(sheet, "I7", "Net Reg Bill", 11, true);
            AddHeader(sheet, "J7", "Gross Billing", 11, true);

            AddMediumBorders(sheet, "A7:J7");
            return (dateCoverage, accountNumber);
        }

        private static (int, int) AddToRegularSheet(int BillingID, int ClientID, ExcelWorksheet sheet, Entry entry, int index, int row, string accountNumber, string billingName, string exportType)
        {
            sheet.Cells[$"A{row}"].Value = index;
            sheet.Cells[$"B{row}"].Value = $"{entry.FullName}{(entry.FinalReportRemarks != null && entry.FinalReportRemarks != "" ? " - " + entry.FinalReportRemarks : "")}";
            sheet.Cells[$"B{row + 1}"].Value = entry.EmployeeID;
            sheet.Cells[$"C{row}"].Value = entry.Position;
            sheet.Cells[$"D{row}"].Value = entry.DailyBillingRate;
            sheet.Cells[$"E{row}"].Value = entry.TimeDetails?.RegularHours.TotalHours / 8;
            sheet.Cells[$"F{row}"].Formula = $"=ROUND(D{row}*E{row},2)";
            sheet.Cells[$"G{row + 1}"].Value = (entry.TimeDetails?.UnderTime.TotalMinutes > 0) ? entry.TimeDetails.UnderTime.TotalMinutes : "";
            sheet.Cells[$"G{row}"].Formula = $"=IF(G{row + 1}<>\"\", ROUND(G{row + 1}*D{row}/8/60*-1,2), 0)";
            sheet.Cells[$"H{row + 1}"].Value = (entry.TimeDetails?.LegalHoliday_100.TotalHours / 8 > 0) ? entry.TimeDetails?.LegalHoliday_100.TotalHours / 8 : "";
            sheet.Cells[$"H{row}"].Formula = $"=IF(H{row + 1}<>\"\", ROUND(D{row}*H{row + 1},2), 0)";
            sheet.Cells[$"I{row}"].Formula = $"=ROUND(SUM(F{row}:H{row}),2)";
            sheet.Cells[$"J{row}"].Formula = $"=ROUND(I{row},2)";

            ConvertToMoney(sheet, $"D{row}");
            ConvertToMoney(sheet, $"F{row}:J{row}");
            ConvertToParenthesis(sheet, $"G{row + 1}");
            ConvertToDecimal(sheet, $"H{row + 1}");
            ConvertToDecimal(sheet, $"E{row}");

            AddThinBorders(sheet, $"A{row}:J{row + 1}");
            sheet.Cells[$"A{row}:J{row}"].Style.Border.Bottom.Style = ExcelBorderStyle.None;
            sheet.Cells[$"A{row}:A{row + 1}"].Style.Border.Left.Style = ExcelBorderStyle.Medium;
            sheet.Cells[$"J{row}"].Style.Border.Right.Style = ExcelBorderStyle.Medium;
            sheet.Cells[$"J{row + 1}"].Style.Border.Right.Style = ExcelBorderStyle.Medium;

            SetCellToCenter(sheet, $"A{row}");
            SetCellToCenter(sheet, $"C{row}");

            if (exportType == StringConstants.Status.UNRELEASED)
            {
                sheet.Calculate();
                var billingValue = Convert.ToDecimal(sheet.Cells[$"J{row}"].Value);

                AddToBillingRecordList(BillingID, ClientID, entry, accountNumber, billingValue, "regular");
            }

            return (index += 1, row += 2);
        }

        private static void ComputeRegularTotal(ExcelWorksheet sheet, int row)
        {
            sheet.Cells[$"E{row}"].Value = "TOTAL";
            SetCellToCenter(sheet, $"E{row}");

            ComputeColumnTotal(sheet, 8, row, "F");
            ComputeColumnTotal(sheet, 8, row, "G");
            ComputeColumnTotal(sheet, 8, row, "H");
            ComputeColumnTotal(sheet, 8, row, "I");
            sheet.Cells[$"J{row}"].Formula = $"=ROUND(SUM(J8:J{row-2}), 2)";

            ConvertToMoney(sheet, $"F{row}:J{row}");
            AddDoubleBorders(sheet, $"F{row}:J{row}");
        }

        private static string SetReportHeadersOvertime(Models.Client client, ExcelWorksheet sheet, string departmentCode, int quarter, DateTime startDate, DateTime endDate)
        {
            string headerStartDate = startDate.ToString("MMMM dd");
            string headerEndDate = endDate.ToString("yyyy");
            
            string soaStartDate = (quarter == 1) ? startDate.ToString("MM-dd") : $"{startDate:MM}-01";
            string soaEndDate = endDate.ToString("yy");

            DecreaseRowHeight(sheet, 5);
            IncreaseRowHeight(sheet, 7);

            AddHeader(sheet, "A1:U1", "LBP RESOURCES AND DEVELOPMENT CORPORATION", 14, true);
            AddHeader(sheet, "A2:U2", "STATEMENT OF ACCOUNT", 14, true);
            AddHeader(sheet, "A3:U3", $"CLIENT: {client.Description.ToUpper()}", 14, true);
            AddHeader(sheet, "A4:U4", $"FOR THE PERIOD OF {headerStartDate.ToUpper()}-{endDate.Day}, {headerEndDate}", 14, true);

            string accountNumber = $"{client.Name}-{departmentCode}-OT-{soaStartDate}-{endDate.Day}-{soaEndDate}";

            AddAccountNumber(sheet, "S", "T", accountNumber);

            AddHeader(sheet, "A7", "No.", 11, true);
            AddHeader(sheet, "B7", "Name", 11, true);
            AddHeader(sheet, "C7", "Position", 11, true);
            AddHeader(sheet, "D7", "Billing Rate", 11, true);
            AddHeader(sheet, "E7", "# of worked days", 11, true);
            AddHeader(sheet, "F7", "Reg OT (125%)", 11, true);
            AddHeader(sheet, "G7", "RDOT/SHOT (130%)", 11, true);
            AddHeader(sheet, "H7", "RDOT (150%)", 11, true);
            AddHeader(sheet, "I7", "RDOT Excess (169%)", 11, true);
            AddHeader(sheet, "J7", "SHOT Excess (195%)", 11, true);
            AddHeader(sheet, "K7", "LHOT (200%)", 11, true);
            AddHeader(sheet, "L7", "LHOT (260%)", 11, true);
            AddHeader(sheet, "M7", "Reg Holiday OT (160%)", 11, true);
            AddHeader(sheet, "N7", "NDOT (10%)", 11, true);
            AddHeader(sheet, "O7", "NDOT (20%)", 11, true);
            AddHeader(sheet, "P7", "NDOT (50%)", 11, true);
            AddHeader(sheet, "Q7", "NDOT (125%)", 11, true);
            AddHeader(sheet, "R7", "NDOT (130%)", 11, true);
            AddHeader(sheet, "S7", "NDOT (150%)", 11, true);
            AddHeader(sheet, "T7", "TOTAL OT", 11, true);
            AddHeader(sheet, "U7", "Gross Billing", 11, true);

            AddMediumBorders(sheet, "A7:U7");
            return accountNumber;
        }

        static decimal ComputeTime(decimal billingRate, double percent, TimeSpan time) => Math.Round((billingRate / 8) * Convert.ToDecimal(percent) * Convert.ToDecimal(time.TotalHours), 2, MidpointRounding.AwayFromZero);

        private static (int, int) AddToOvertimeSheet(int BillingID, int ClientID, ExcelWorksheet sheet, Entry entry, int index, int row, string accountNumber, string billingName, string exportType)
        {
            var time = entry.TimeDetails;
            decimal convertedRate = Convert.ToDecimal(entry.DailyBillingRate);
            sheet.Cells[$"A{row}"].Value = index;
            sheet.Cells[$"B{row}"].Value = $"{entry.FullName}{(entry.FinalReportRemarks != null && entry.FinalReportRemarks != "" ? " - " + entry.FinalReportRemarks : "")}";
            sheet.Cells[$"B{row + 1}"].Value = entry.EmployeeID;
            sheet.Cells[$"C{row}"].Value = entry.Position;
            sheet.Cells[$"D{row}"].Value = entry.DailyBillingRate;
            sheet.Cells[$"E{row}"].Value = time?.RegularHours.TotalHours / 8;

            sheet.Cells[$"F{row + 1}"].Value = (time?.RegOT_125 > TimeSpan.Zero) ? time.RegOT_125 : "";
            sheet.Cells[$"G{row + 1}"].Value = (time?.RestDaySpecialOT_130 > TimeSpan.Zero) ? time.RestDaySpecialOT_130 : "";
            sheet.Cells[$"H{row + 1}"].Value = (time?.RestDaySpecialOT_150 > TimeSpan.Zero) ? time.RestDaySpecialOT_150 : "";
            sheet.Cells[$"I{row + 1}"].Value = (time?.RestDaySpecialOTExcess_169 > TimeSpan.Zero) ? time.RestDaySpecialOTExcess_169 : "";
            sheet.Cells[$"J{row + 1}"].Value = (time?.SpecialExcessOT_195 > TimeSpan.Zero) ? time.SpecialExcessOT_195 : "";
            sheet.Cells[$"K{row + 1}"].Value = (time?.LegalHolidayOT_200 > TimeSpan.Zero) ? time.LegalHolidayOT_200 : "";
            sheet.Cells[$"L{row + 1}"].Value = (time?.LegalHolidayOT_260 > TimeSpan.Zero) ? time.LegalHolidayOT_260 : "";
            sheet.Cells[$"M{row + 1}"].Value = (time?.RegularHoliday_160 > TimeSpan.Zero) ? time.RegularHoliday_160 : "";
            sheet.Cells[$"N{row + 1}"].Value = (time?.NightDiff_10 > TimeSpan.Zero) ? time.NightDiff_10 : "";
            sheet.Cells[$"O{row + 1}"].Value = (time?.NightDiff_20 > TimeSpan.Zero) ? time.NightDiff_20 : "";
            sheet.Cells[$"P{row + 1}"].Value = (time?.NightDiff_50 > TimeSpan.Zero) ? time.NightDiff_50 : "";
            sheet.Cells[$"Q{row + 1}"].Value = (time?.NightDiff_125 > TimeSpan.Zero) ? time.NightDiff_125 : "";
            sheet.Cells[$"R{row + 1}"].Value = (time?.NightDiff_130 > TimeSpan.Zero) ? time.NightDiff_130 : "";
            sheet.Cells[$"S{row + 1}"].Value = (time?.NightDiff_150 > TimeSpan.Zero) ? time.NightDiff_150 : "";

            sheet.Cells[$"F{row}"].Formula = $"=IF(F{row + 1}<>\"\", ROUND((D{row}/8)*125%*(F{row + 1}*24),2), 0)";
            sheet.Cells[$"G{row}"].Formula = $"=IF(G{row + 1}<>\"\", ROUND((D{row}/8)*130%*(G{row + 1}*24),2), 0)";
            sheet.Cells[$"H{row}"].Formula = $"=IF(H{row + 1}<>\"\", ROUND((D{row}/8)*150%*(H{row + 1}*24),2), 0)";
            sheet.Cells[$"I{row}"].Formula = $"=IF(I{row + 1}<>\"\", ROUND((D{row}/8)*169%*(I{row + 1}*24),2), 0)";
            sheet.Cells[$"J{row}"].Formula = $"=IF(J{row + 1}<>\"\", ROUND((D{row}/8)*195%*(J{row + 1}*24),2), 0)";
            sheet.Cells[$"K{row}"].Formula = $"=IF(K{row + 1}<>\"\", ROUND((D{row}/8)*200%*(K{row + 1}*24),2), 0)";
            sheet.Cells[$"L{row}"].Formula = $"=IF(L{row + 1}<>\"\", ROUND((D{row}/8)*260%*(L{row + 1}*24),2), 0)";
            sheet.Cells[$"M{row}"].Formula = $"=IF(M{row + 1}<>\"\", ROUND((D{row}/8)*160%*(M{row + 1}*24),2), 0)";
            sheet.Cells[$"N{row}"].Formula = $"=IF(N{row + 1}<>\"\", ROUND((D{row}/8)*1%*(N{row + 1}*24),2), 0)";
            sheet.Cells[$"O{row}"].Formula = $"=IF(O{row + 1}<>\"\", ROUND((D{row}/8)*2%*(O{row + 1}*24),2), 0)";
            sheet.Cells[$"P{row}"].Formula = $"=IF(P{row + 1}<>\"\", ROUND((D{row}/8)*5%*(P{row + 1}*24),2), 0)";
            sheet.Cells[$"Q{row}"].Formula = $"=IF(Q{row + 1}<>\"\", ROUND((D{row}/8)*12.5%*(Q{row + 1}*24),2), 0)";
            sheet.Cells[$"R{row}"].Formula = $"=IF(R{row + 1}<>\"\", ROUND((D{row}/8)*13%*(R{row + 1}*24),2), 0)";
            sheet.Cells[$"S{row}"].Formula = $"=IF(S{row + 1}<>\"\", ROUND((D{row}/8)*15%*(S{row + 1}*24),2), 0)";

            sheet.Cells[$"T{row}"].Formula = $"=ROUND(SUM(F{row}:S{row}),2)";
            sheet.Cells[$"U{row}"].Formula = $"=ROUND(T{row},2)";

            ConvertToTime(sheet, $"F{row + 1}:S{row + 1}");
            ConvertToMoney(sheet, $"D{row}");
            ConvertToMoney(sheet, $"F{row}:U{row}");
            ConvertToDecimal(sheet, $"E{row}");

            AddThinBorders(sheet, $"A{row}:U{row + 1}");
            sheet.Cells[$"A{row}:U{row}"].Style.Border.Bottom.Style = ExcelBorderStyle.None;
            sheet.Cells[$"A{row}:A{row + 1}"].Style.Border.Left.Style = ExcelBorderStyle.Medium;
            sheet.Cells[$"U{row}"].Style.Border.Right.Style = ExcelBorderStyle.Medium;
            sheet.Cells[$"U{row + 1}"].Style.Border.Right.Style = ExcelBorderStyle.Medium;

            SetCellToCenter(sheet, $"A{row}");
            SetCellToCenter(sheet, $"C{row}");

            if (exportType == StringConstants.Status.UNRELEASED)
            {
                decimal regot_125 = ComputeTime(convertedRate, 1.25, time.RegOT_125);
                decimal rdshot_130 = ComputeTime(convertedRate, 1.30, time.RestDaySpecialOT_130);
                decimal rdot_150 = ComputeTime(convertedRate, 1.50, time.RestDaySpecialOT_150);
                decimal rhot_excess_169 = ComputeTime(convertedRate, 1.69, time.RestDaySpecialOTExcess_169);
                decimal shot_excess_195 = ComputeTime(convertedRate, 1.95, time.SpecialExcessOT_195);
                decimal lhot_200 = ComputeTime(convertedRate, 2.00, time.LegalHolidayOT_200);
                decimal lhot_260 = ComputeTime(convertedRate, 2.60, time.LegalHolidayOT_260);
                decimal rhot_160 = ComputeTime(convertedRate, 1.60, time.RegularHoliday_160);
                decimal ndot_10 = ComputeTime(convertedRate, 0.01, time.NightDiff_10);
                decimal ndot_20 = ComputeTime(convertedRate, 0.02, time.NightDiff_20);
                decimal ndot_50 = ComputeTime(convertedRate, 0.05, time.NightDiff_50);
                decimal ndot_125 = ComputeTime(convertedRate, 0.125, time.NightDiff_125);
                decimal ndot_130 = ComputeTime(convertedRate, 0.13, time.NightDiff_130);
                decimal ndot_150 = ComputeTime(convertedRate, 0.15, time.NightDiff_150);

                decimal billingValue = regot_125 + rdshot_130 + rdot_150 + rhot_excess_169 + shot_excess_195 + lhot_200 +
                      lhot_260 + rhot_160 + ndot_10 + ndot_20 + ndot_50 + ndot_125 + ndot_130 + ndot_150;

                AddToBillingRecordList(BillingID, ClientID, entry, accountNumber, billingValue, "overtime");
            }

            return (index += 1, row += 2);
        }

        private static void ComputeOvertimeTotal(ExcelWorksheet sheet, int row)
        {
            sheet.Cells[$"E{row}"].Value = "TOTAL";
            SetCellToCenter(sheet, $"E{row}");

            ComputeColumnTotal(sheet, 8, row, "F");
            ComputeColumnTotal(sheet, 8, row, "G");
            ComputeColumnTotal(sheet, 8, row, "H");
            ComputeColumnTotal(sheet, 8, row, "I");
            ComputeColumnTotal(sheet, 8, row, "J");
            ComputeColumnTotal(sheet, 8, row, "K");
            ComputeColumnTotal(sheet, 8, row, "L");
            ComputeColumnTotal(sheet, 8, row, "M");
            ComputeColumnTotal(sheet, 8, row, "N");
            ComputeColumnTotal(sheet, 8, row, "O");
            ComputeColumnTotal(sheet, 8, row, "P");
            ComputeColumnTotal(sheet, 8, row, "Q");
            ComputeColumnTotal(sheet, 8, row, "R");
            ComputeColumnTotal(sheet, 8, row, "S");
            ComputeColumnTotal(sheet, 8, row, "T");
            sheet.Cells[$"U{row}"].Formula = $"=ROUND(SUM(U8:U{row - 2}), 2)";

            ConvertToMoney(sheet, $"F{row}:U{row}");
            AddDoubleBorders(sheet, $"F{row}:U{row}");
        }

        private static void AddNetBilling(ExcelWorksheet sheet, int row, string colHeader, string colValue)
        {
            sheet.Cells[$"{colHeader}{row}"].Value = "NET BILLING";
            sheet.Cells[$"{colValue}{row}"].Formula = $"=ROUND({colValue}{row - 2}-({colValue}{row - 2}/1.12*0.07),2)";
            ConvertToMoney(sheet, $"{colValue}{row}");
        }

        private static void AddFooter(ExcelWorksheet sheet, int row, string officerName, string officerPosition)
        {
            sheet.Cells[$"B{row}"].Value = "Prepared By:";
            sheet.Cells[$"E{row}"].Value = "Checked By:";

            row += 2;
            var user = UserService.CurrentUser;
            sheet.Cells[$"B{row}"].Value = $"{user?.FirstName?.ToUpper()} {user?.LastName?.ToUpper()}";
            AddUnderlineBorders(sheet, $"B{row}");
            SetCellToCenter(sheet, $"B{row}");

            sheet.Cells[$"E{row}:H{row}"].Merge = true;
            sheet.Cells[$"E{row}:H{row}"].Value = officerName;
            AddUnderlineBorders(sheet, $"E{row}:H{row}");
            SetCellToCenter(sheet, $"E{row}:H{row}");

            row++;
            sheet.Cells[$"B{row}"].Value = user?.PositionTitle;
            SetCellToCenter(sheet, $"B{row}");

            sheet.Cells[$"E{row}:H{row}"].Merge = true;
            sheet.Cells[$"E{row}:H{row}"].Value = Utilities.StringFormat.ToSentenceCase(officerPosition);
            SetCellToCenter(sheet, $"E{row}:H{row}");
        }

        private static void SetPrintSettings(ExcelWorksheet sheet, string dateCoverage)
        {
            var printSettings = sheet.PrinterSettings;
            sheet.HeaderFooter.OddFooter.CenteredText = "Page &P of &N";
            sheet.HeaderFooter.OddFooter.RightAlignedText = "&\"Calibri,Bold\"&A\n&\"Calibri,Italic\"" + dateCoverage;
            printSettings.Orientation = eOrientation.Landscape;
            printSettings.RepeatRows = sheet.Cells["6:7"];
            printSettings.FitToPage = true;
            printSettings.FitToWidth = 1;
            printSettings.FitToHeight = 2;
        }

        private static void SetColumnWidthsAdjustment(ExcelWorksheet sheet)
        {
            sheet.Cells[sheet.Dimension.Address].AutoFitColumns();
        }

        private static void SetColumnWidthsRegular(ExcelWorksheet sheet)
        {
            //sheet.Cells[sheet.Dimension.Address].AutoFitColumns();
            sheet.Column(1).Width = 6;
            sheet.Column(2).AutoFit();
            //sheet.Column(2).Width = 45;
            sheet.Column(3).Width = 22;
            sheet.Column(4).Width = 13;
            sheet.Column(5).Width = 8;
            for (int i = 6; i <= 10; i++)
            {
                sheet.Column(i).Width = 12;
            }
        }

        private static void SetColumnWidthsOvertime(ExcelWorksheet sheet)
        {
            sheet.Column(1).Width = 6;
            sheet.Column(2).AutoFit();
            sheet.Column(3).Width = 22;
            sheet.Column(4).Width = 13;
            sheet.Column(5).Width = 8;
            for (int i = 6; i <= 26; i++)
            {
                sheet.Column(i).Width = 12;
            }
        }

        private static void AddHeader(ExcelWorksheet sheet, string cellRange, string value, int fontSize, bool boldState)
        {
            sheet.Cells[cellRange].Merge = true;
            sheet.Cells[cellRange].Value = value;
            sheet.Cells[cellRange].Style.WrapText = true;
            sheet.Cells[cellRange].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            sheet.Cells[cellRange].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            sheet.Cells[cellRange].Style.Font.Size = fontSize;
            sheet.Cells[cellRange].Style.Font.Bold = boldState;
        }

        private static void AddAccountNumber(ExcelWorksheet sheet, string cellHeader, string cellValue, string value)
        {
            sheet.Cells[$"{cellHeader}6"].Value = "SOA NO.";
            sheet.Cells[$"{cellHeader}6"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

            sheet.Cells[$"{cellValue}6"].Value = value;
            sheet.Cells[$"{cellValue}6"].Style.Font.Bold = true;
        }

        // BORDERS

        static void AddMediumBorders(ExcelWorksheet sheet, string cell)
        {
            sheet.Cells[cell].Style.Border.Top.Style = ExcelBorderStyle.Medium;
            sheet.Cells[cell].Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
            sheet.Cells[cell].Style.Border.Left.Style = ExcelBorderStyle.Medium;
            sheet.Cells[cell].Style.Border.Right.Style = ExcelBorderStyle.Medium;
        }

        static void AddThinBorders(ExcelWorksheet sheet, string cell)
        {
            sheet.Cells[cell].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            sheet.Cells[cell].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            sheet.Cells[cell].Style.Border.Right.Style = ExcelBorderStyle.Thin;
        }

        static void AddDoubleBorders(ExcelWorksheet sheet, string cell)
        {
            sheet.Cells[cell].Style.Border.Bottom.Style = ExcelBorderStyle.Double;
        }

        static void AddUnderlineBorders(ExcelWorksheet sheet, string cell)
        {
            sheet.Cells[cell].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        }

        private static void AddToBillingRecordList(int BillingID, int ClientID, Entry entry, string accountNumber, decimal billingValue, string timeType)
        {
            try
            {
                string joinedAdjustmentRemarks = (entry.AdjustmentRemarks != null) ? string.Join(", ", entry.AdjustmentRemarks.Where(w => w.Type == timeType).Select(s => s.Value).ToArray()) : "";

                if (timeType == "regular")
                {
                    string timeJSON = JsonSerializer.Serialize(entry.TimeDetails);
                    
                    BillingRecords.Add(new()
                    {
                        ClientID = ClientID,
                        BillingID = BillingID,
                        Guid = entry.Guid,
                        EmployeeID = entry.EmployeeID,
                        FullName = entry.FullName,
                        EntryType = entry.EntryType,
                        Position = entry.Position,
                        Department = entry.Department,
                        TimeDetailJSON = timeJSON,
                        DailySalaryRate = entry.DailySalaryRate,
                        DailyBillingRate = entry.DailyBillingRate,
                        //BillingName = billingName,
                        RegularAccountNumber = accountNumber,
                        OvertimeAccountNumber = "",
                        RegularBillingValue = billingValue,
                        RegularCollectedValue = 0,
                        OvertimeCollectedValue = 0,
                        RegularCollectedDate = null,
                        OvertimeCollectedDate = null,
                        TimekeepRemarks = entry.TimekeepRemarks ?? "",
                        UserRemarks = entry.FinalReportRemarks ?? "",
                        RegularAdjustmentRemarks = joinedAdjustmentRemarks,
                        OvertimeAdjustmentRemarks = "",
                        Description = entry.VerificationStatus,
                        Status = "Unreleased",
                        Timestamp = DateTime.Now
                    });
                }
                else if (timeType == "overtime")
                {
                    var record = BillingRecords.FirstOrDefault(f => f.Guid == entry.Guid);
                    if (record != null)
                    {
                        record.OvertimeAccountNumber = accountNumber;
                        record.OvertimeBillingValue = billingValue;
                        record.OvertimeAdjustmentRemarks = joinedAdjustmentRemarks;
                    }
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }

        public static List<AccrualsEntry> FetchAccruals(string filePath, string accrualSheetName)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            List<AccrualsEntry> accruals = new();

            try
            {
                using var file = new ExcelPackage(new FileInfo(filePath));
                var sheet = file.Workbook.Worksheets[accrualSheetName];

                int totalRowCount = sheet.Dimension.Rows;

                List<string> invalidEntries = new()
                {
                    "GRAND TOTAL",
                    "Prepared by:"
                };

                for (int row = 8; row < totalRowCount; row += 2)
                {
                    string? employeeName = sheet.Cells[$"C{row}"].Value?.ToString();
                    string? employeeID = sheet.Cells[$"C{row + 1}"].Value?.ToString();
                    string? employeePosition = sheet.Cells[$"D{row}"].Value?.ToString();

                    if (string.IsNullOrEmpty(employeeName) && string.IsNullOrEmpty(employeeID) && string.IsNullOrEmpty(employeePosition)) { continue; }
                    else if (invalidEntries.Contains(employeeName) || invalidEntries.Contains(employeeID)) { break; }
                    
                    decimal billingRate = (sheet.Cells[$"F{row}"].Value.ToString().Trim() == "-") ? 0 : Math.Round(Convert.ToDecimal(sheet.Cells[$"F{row}"].Value), 2, MidpointRounding.AwayFromZero);
                    decimal regularBillingValue = (sheet.Cells[$"K{row}"].Value.ToString().Trim() == "-") ? 0 : Math.Round(Convert.ToDecimal(sheet.Cells[$"K{row}"].Value), 2, MidpointRounding.AwayFromZero);
                    decimal overtimeBillingValue = (sheet.Cells[$"BU{row}"].Value.ToString().Trim() == "-") ? 0 : Math.Round(Convert.ToDecimal(sheet.Cells[$"BU{row}"].Value), 2, MidpointRounding.AwayFromZero);

                    accruals.Add(new()
                    {
                        EmployeeName = employeeName,
                        EmployeeID = employeeID,
                        EmployeePosition = employeePosition,
                        BillingRate = billingRate,
                        RegularBillingValue = regularBillingValue,
                        OvertimeBillingValue = overtimeBillingValue
                    });
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return accruals;
        }

        // BALANCING

        public static async Task<bool> ExportBalancing(int ClientID, int BillingID, string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            if (BillingID == 0 || ClientID == 0)
            {
                MessageBox.Show(MessagesConstants.Error.MISSING_CLIENT_BILLING, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                var billing = await BillingService.GetBillingDetailsById(BillingID);
                var employeesList = await EmployeeService.GetEmployees(ClientID);
                var departmentsList = await DepartmentService.GetItems(ClientID);
                var positionsList = await PositionService.GetItems(ClientID);
                var billingRecords = await BillingRecordService.GetRecordsByBillingId(BillingID);
                var groupedRecords = billingRecords.GroupBy(gb => gb.Department).ToList();
                var uploadedAccruals = JsonSerializer.Deserialize<List<AccrualsEntry>>(billing.AccrualsJSON);

                if (!uploadedAccruals.Any())
                {
                    MessageBox.Show(MessagesConstants.Error.MISSING_ACCRUALS, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                foreach (var entry in uploadedAccruals)
                {
                    var matchedEntry = employeesList.FirstOrDefault(f => entry.EmployeeID.Contains(f.EmployeeID));
                    if (matchedEntry != null)
                    {
                        entry.Department = matchedEntry.DepartmentName.ToUpper();
                    }
                }

                string startDate = billing.StartDate.ToString("MMMM dd");
                string endDate = billing.EndDate.ToString("dd, yyyy");

                using var package = new ExcelPackage();
                var balancingSheet = package.Workbook.Worksheets.Add(StringConstants.SheetName.BALANCING);

                int row = 1;
                int startRow = 0;

                AddHeader(balancingSheet, $"A{row}:F{row}", $"{startDate}-{endDate}", 14, true);
                IncreaseRowHeight(balancingSheet, row);

                row += 1;

                foreach (var department in groupedRecords)
                {
                    startRow = row = SetBalancingHeaders(balancingSheet, department.Key.ToUpper(), row);

                    List<BalancingRowDetails> regularDetailsList = new();
                    List<BalancingRowDetails> overtimeDetailsList = new();

                    foreach (var record in department)
                    {
                        var accrualsEntry = uploadedAccruals.FirstOrDefault(a => a.EmployeeID.Contains(record.EmployeeID) && a.EmployeePosition == record.Position.ToUpper());
                        var position = positionsList.FirstOrDefault(f => f.Name == record.Position);
                        string remarks = record.UserRemarks ?? "";
                        string recordIdentity = $"{record.FullName} ({position?.Code}){(string.IsNullOrEmpty(remarks) ? "" : $" - {remarks}")}";

                        if (accrualsEntry != null)
                        {
                            var accrualsPosition = positionsList.FirstOrDefault(f => f.Name == accrualsEntry.EmployeePosition);
                            string accrualsIdentity = $"{accrualsEntry.EmployeeName} ({((accrualsPosition != null) ? accrualsPosition?.Code : accrualsEntry.EmployeePosition)})";
                            
                            accrualsEntry.HasAdded = true;

                            regularDetailsList.Add(new()
                            {
                                AccrualsFullName = accrualsIdentity,
                                AccrualsValue = accrualsEntry.RegularBillingValue,
                                BillingFullName = recordIdentity,
                                BillingValue = record.RegularBillingValue,
                                BillingRemarks = record.RegularAdjustmentRemarks
                            });

                            overtimeDetailsList.Add(new()
                            {
                                AccrualsFullName = accrualsIdentity,
                                AccrualsValue = accrualsEntry.OvertimeBillingValue,
                                BillingFullName = recordIdentity,
                                BillingValue = record.OvertimeBillingValue,
                                BillingRemarks = record.OvertimeAdjustmentRemarks
                            });
                        }
                        else
                        {
                            regularDetailsList.Add(new()
                            {
                                AccrualsFullName = "",
                                AccrualsValue = 0,
                                BillingFullName = recordIdentity,
                                BillingValue = record.RegularBillingValue,
                                BillingRemarks = record.RegularAdjustmentRemarks
                            });

                            overtimeDetailsList.Add(new()
                            {
                                AccrualsFullName = "",
                                AccrualsValue = 0,
                                BillingFullName = recordIdentity,
                                BillingValue = record.OvertimeBillingValue,
                                BillingRemarks = record.OvertimeAdjustmentRemarks
                            });
                        }
                    }

                    foreach (var skippedAccrual in uploadedAccruals.Where(w => w.Department == department.Key.ToUpper() && !w.HasAdded))
                    {
                        var accrualsPosition = positionsList.FirstOrDefault(f => f.Name == skippedAccrual.EmployeePosition);
                        string accrualsIdentity = $"{skippedAccrual.EmployeeName} ({((accrualsPosition != null) ? accrualsPosition?.Code : skippedAccrual.EmployeePosition)})";

                        skippedAccrual.HasAdded = true;

                        regularDetailsList.Add(new()
                        {
                            AccrualsFullName = accrualsIdentity,
                            AccrualsValue = skippedAccrual.RegularBillingValue,
                            BillingFullName = "",
                            BillingValue = 0,
                            BillingRemarks = ""
                        });

                        overtimeDetailsList.Add(new()
                        {
                            AccrualsFullName = accrualsIdentity,
                            AccrualsValue = skippedAccrual.OvertimeBillingValue,
                            BillingFullName = "",
                            BillingValue = 0,
                            BillingRemarks = ""
                        });
                    }

                    if (regularDetailsList.Any())
                    {
                        foreach (var item in regularDetailsList)
                        {
                            row = AddBalancingRow(balancingSheet, item.AccrualsFullName, item.AccrualsValue, item.BillingFullName, item.BillingValue, item.BillingRemarks, row);
                        }
                    }

                    balancingSheet.Cells[$"B{row}"].Formula = $"=SUM(B{startRow}:B{row - 1})";
                    balancingSheet.Cells[$"E{row}"].Formula = $"=SUM(E{startRow}:E{row - 1})";
                    SetCellToBold(balancingSheet, $"B{row}, E{row}");
                    row += 1;

                    startRow = row = SetBalancingHeaders(balancingSheet, $"{department.Key.ToUpper()} {StringConstants.Type.OVERTIME.ToUpper()}", row);

                    if (overtimeDetailsList.Any())
                    {
                        foreach (var item in overtimeDetailsList)
                        {
                            row = AddBalancingRow(balancingSheet, item.AccrualsFullName, item.AccrualsValue, item.BillingFullName, item.BillingValue, item.BillingRemarks, row);
                        }
                    }

                    balancingSheet.Cells[$"B{row}"].Formula = $"=SUM(B{startRow}:B{row - 1})";
                    balancingSheet.Cells[$"E{row}"].Formula = $"=SUM(E{startRow}:E{row - 1})";
                    SetCellToBold(balancingSheet, $"B{row}, E{row}");
                    row += 1;
                }

                row += 1;
                AddHeader(balancingSheet, $"A{row}:B{row}", "UNCATEGORIZED ACCRUALS REGULAR", 12, true);
                row += 1;

                foreach (var entry in uploadedAccruals.Where(w => !w.HasAdded))
                {
                    var accrualsPosition = positionsList.FirstOrDefault(f => f.Name == entry.EmployeePosition);
                    string accrualsIdentity = $"{entry.EmployeeName} ({((accrualsPosition != null) ? accrualsPosition?.Code : entry.EmployeePosition)})";
                    row = AddBalancingRow(balancingSheet, accrualsIdentity, entry.RegularBillingValue, "", 0, "", row);
                }

                row += 1;
                AddHeader(balancingSheet, $"A{row}:B{row}", "UNCATEGORIZED ACCRUALS OVERTIME", 12, true);
                row += 1;

                foreach (var entry in uploadedAccruals.Where(w => !w.HasAdded))
                {
                    var accrualsPosition = positionsList.FirstOrDefault(f => f.Name == entry.EmployeePosition);
                    string accrualsIdentity = $"{entry.EmployeeName} ({((accrualsPosition != null) ? accrualsPosition?.Code : entry.EmployeePosition)})";
                    row = AddBalancingRow(balancingSheet, accrualsIdentity, entry.OvertimeBillingValue, "", 0, "", row);
                }

                ConvertToMoney(balancingSheet, "B");
                ConvertToMoney(balancingSheet, "C");
                ConvertToMoney(balancingSheet, "E");
                balancingSheet.Cells[balancingSheet.Dimension.Address].AutoFitColumns();

                try
                {
                    package.SaveAs(new FileInfo(filePath));
                }
                catch {
                    MessageBox.Show($"There seems to be a problem exporting this file. If you are overwriting this to an existing file, make sure that the selected file is not currently open.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false; 
                }

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static int SetBalancingHeaders(ExcelWorksheet sheet, string departmentName, int row)
        {
            row += 1;
            AddHeader(sheet, $"A{row}:B{row}", departmentName, 12, true);
            AddUnderlineBorders(sheet, $"A{row}:F{row}");
            AddHeader(sheet, $"A{row + 1}:B{row + 1}", "Accruals", 11, false);
            AddHeader(sheet, $"D{row + 1}:E{row + 1}", "Billing", 11, false);
            AddHeader(sheet, $"F{row + 1}", "Remarks", 11, false);
            AddUnderlineBorders(sheet, $"A{row + 1}:F{row + 1}");
            return row += 2;
        }

        public static int AddBalancingRow(ExcelWorksheet sheet, string accrualsName, decimal? accrualsValue, string billingName, decimal? billingValue, string remarks, int row)
        {
            sheet.Cells[$"A{row}"].Value = accrualsName;
            sheet.Cells[$"B{row}"].Value = accrualsValue;
            sheet.Cells[$"C{row}"].Formula = $"=E{row}-B{row}";
            sheet.Cells[$"D{row}"].Value = billingName;
            sheet.Cells[$"E{row}"].Value = billingValue;
            sheet.Cells[$"F{row}"].Value = remarks;
            return row += 1;
        }
    }
}
