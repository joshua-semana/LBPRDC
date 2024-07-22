using LBPRDC.Source.Config;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace LBPRDC.Source.Services
{
    internal class TransmittalService
    {
        static readonly string colorWhite = "#ffffff";
        static readonly string colorBlue = "#cfe2f3";
        static readonly string colorPurple = "#8e7cc3";
        static readonly string colorGreen = "#d9ead3";
        static readonly string colorRed = "#ead1dc";
        static readonly string colorLightYellow = "#fff2cc";
        static readonly string colorDarkYellow = "#ffff00";
        static readonly string colorOrange = "#ffd966";

        private static void InsertText(
            ExcelWorksheet sheet,
            string cellRange,
            string value,
            bool isMerged = false,
            string bgColor = "#FFFFFF",
            int fontSize = 11)
        {
            sheet.Cells[cellRange].Value = value;
            sheet.Cells[cellRange].Merge = isMerged;
            sheet.Cells[cellRange].Style.Fill.PatternType = ExcelFillStyle.Solid;
            sheet.Cells[cellRange].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(bgColor));
            sheet.Cells[cellRange].Style.Font.Size = fontSize;
        }

        private static void InsertNumber(
            ExcelWorksheet sheet,
            string cellRange,
            decimal value)
        {
            sheet.Cells[cellRange].Value = value;
            sheet.Cells[cellRange].Style.Numberformat.Format = "#,##0.00";
        }

        private static void InsertFormulaForBalance(
            ExcelWorksheet sheet,
            string cellRange,
            string value)
        {
            sheet.Cells[cellRange].Formula = value;
            sheet.Cells[cellRange].Calculate();
            var formulaResult = sheet.Cells[cellRange].Value;
            string bgColor = (formulaResult != null && (double)formulaResult > 0) ? colorDarkYellow : colorWhite;
            sheet.Cells[cellRange].Style.Fill.PatternType = ExcelFillStyle.Solid;
            sheet.Cells[cellRange].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(bgColor));
        }

        private static void InsertTotal(
            ExcelWorksheet sheet,
            List<string> columns,
            int row,
            int startRow)
        {
            sheet.Cells[$"D{row}"].Value = "TOTAL";
            foreach (string column in columns)
            {
                sheet.Cells[$"{column}{row}"].Formula = $"=SUM({column}{startRow}:{column}{row - 1})";
                sheet.Cells[$"{column}{row}"].Calculate();
            }
            sheet.Cells[$"A{row}:L{row}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            sheet.Cells[$"A{row}:L{row}"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(colorOrange));
        }

        private static void SetBorders(ExcelWorksheet sheet, string cellRange, ExcelBorderStyle borderStyle)
        {
            sheet.Cells[cellRange].Style.Border.Top.Style = borderStyle;
            sheet.Cells[cellRange].Style.Border.Left.Style = borderStyle;
            sheet.Cells[cellRange].Style.Border.Right.Style = borderStyle;
            sheet.Cells[cellRange].Style.Border.Bottom.Style = borderStyle;
        }

        private static void SetLeftBorders(ExcelWorksheet sheet, string cellRange, ExcelBorderStyle borderStyle) => sheet.Cells[cellRange].Style.Border.Left.Style = borderStyle;
        private static void SetRightBorders(ExcelWorksheet sheet, string cellRange, ExcelBorderStyle borderStyle) => sheet.Cells[cellRange].Style.Border.Right.Style = borderStyle;
        private static void SetBottomBorders(ExcelWorksheet sheet, string cellRange, ExcelBorderStyle borderStyle) => sheet.Cells[cellRange].Style.Border.Bottom.Style = borderStyle;
        private static void SetToCenter(ExcelWorksheet sheet, string cellRange) => sheet.Cells[cellRange].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        private static void SetToRight(ExcelWorksheet sheet, string cellRange) => sheet.Cells[cellRange].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
        private static void SetToMiddle(ExcelWorksheet sheet, string cellRange) => sheet.Cells[cellRange].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
        private static void SetToBold(ExcelWorksheet sheet, string cellRange) => sheet.Cells[cellRange].Style.Font.Bold = true;
        private static void SetRowHeight(ExcelWorksheet sheet, int row, int height) => sheet.Row(row).Height = height;
        private static void SetColumnWidth(ExcelWorksheet sheet, int row, int width) => sheet.Column(row).Width = width;
        private static void SetFormatToMoney(ExcelWorksheet sheet, string cellRange) => sheet.Cells[cellRange].Style.Numberformat.Format = "#,##0.00";


        public static async Task<bool> ExportSummary(int BillingID, int ClientID, string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            if (BillingID == 0 || ClientID == 0)
            {
                MessageBox.Show(MessagesConstants.Error.MISSING_CLIENT_BILLING, MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var client = await ClientService.GetClientByID(ClientID);
            var billing = await BillingService.GetBillingDetailsById(BillingID);
            var accounts = await BillingAccountService.GetItemsByBillingID(BillingID);

            if (billing == null || accounts.Count == 0) return false;

            try
            {
                using var package = new ExcelPackage();
                var summarySheet = package.Workbook.Worksheets.Add("SUMMARY");

                AddSummaryTitle(summarySheet, client.Description, billing.StartDate.ToString("MMMM"), billing.EndDate.ToString("yyyy"));
                AddHeaderTitles(summarySheet);

                int row = 8, startRow = 8;

                accounts = accounts.OrderBy(ob => ob.Classification).ToList();

                foreach (var account in accounts)
                {
                    var releaseDate = (billing.ReleaseDate.HasValue) ? billing.ReleaseDate.Value.ToString(StringConstants.Date.DEFAULT) : "Not Yet Released";
                    string classification = account.Classification ?? "";

                    string periodDate = "";
                    if (!classification.ToUpper().Contains(StringConstants.Type.OVERTIME))
                    {
                        periodDate = $"{billing.StartDate:MMMM dd}-{billing.EndDate:dd, yyyy}";
                    }
                    else
                    {
                        string startDate = (billing.Quarter == 1) ? $"{billing.StartDate:MMMM dd}" : $"{billing.StartDate:MMMM} 1";
                        string endDate = $"{billing.EndDate:dd, yyyy}";
                        periodDate = $"{startDate}-{endDate}";
                    }

                    var accountNumber = $"{account.AccountNumber}";
                    var grossAmount = account.BilledValue;
                    // TODO ADJUSTMENT
                    // TODO REVISION
                    var collectedDate = (account.CollectionDate.HasValue) ? account.CollectionDate.Value.ToString(StringConstants.Date.DEFAULT) : "";
                    var orNumber = account.OfficialReceiptNumber;
                    var collectedValue = account.CollectedValue;
                    var balance = account.Balance;

                    InsertText(summarySheet, $"A{row}", releaseDate);
                    InsertText(summarySheet, $"B{row}", periodDate);
                    InsertText(summarySheet, $"C{row}", classification.ToUpper());
                    InsertText(summarySheet, $"D{row}", accountNumber);
                    InsertNumber(summarySheet, $"E{row}", grossAmount);
                    InsertText(summarySheet, $"I{row}", collectedDate);
                    InsertText(summarySheet, $"J{row}", orNumber);
                    InsertNumber(summarySheet, $"K{row}", collectedValue);
                    InsertNumber(summarySheet, $"L{row}", balance);
                    InsertFormulaForBalance(summarySheet, $"L{row}", $"=E{row}-K{row}");

                    SetRowHeight(summarySheet, row, 22);
                    row += 1;
                }

                InsertTotal(summarySheet, new() { "E", "F", "H", "K", "L" }, row, startRow);
                SetRowHeight(summarySheet, row, 22);

                string contentWithHeaders = $"A6:L{row}";
                string contentOnly = $"A{startRow}:L{row}";

                SetBorders(summarySheet, $"A{startRow}:L{row - 1}", ExcelBorderStyle.Thin);
                SetLeftBorders(summarySheet, $"A6:A{row}", ExcelBorderStyle.Medium);
                SetRightBorders(summarySheet, $"L6:L{row}", ExcelBorderStyle.Medium);
                SetBottomBorders(summarySheet, $"A{row}:L{row}", ExcelBorderStyle.Medium);
                
                SetToCenter(summarySheet, contentWithHeaders);
                SetToMiddle(summarySheet, contentWithHeaders);

                SetToRight(summarySheet, $"E{startRow}:E{row}");
                SetToRight(summarySheet, $"F{startRow}:F{row}");
                SetToRight(summarySheet, $"H{startRow}:H{row}");
                SetToRight(summarySheet, $"K{startRow}:K{row}");
                SetToRight(summarySheet, $"L{startRow}:L{row}");

                SetFormatToMoney(summarySheet, $"E{row}:L{row}");
                SetToBold(summarySheet, $"D{row}:L{row}");

                SetColumnSizes(summarySheet);

                try
                {
                    package.SaveAs(new FileInfo(filePath));
                }
                catch (Exception ex) { return ExceptionHandler.HandleException(ex); }

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        private static void AddSummaryTitle(ExcelWorksheet sheet, string clientName, string month, string year)
        {
            InsertText(sheet, "A2:C2", $"SUMMARY OF BILLING STATEMENT FOR {month} {year}", true);
            InsertText(sheet, "A3:C3", clientName, true);
            InsertText(sheet, "A4:C4", $"AS OF {DateTime.Now:MMMM dd, yyyy}", true);
        }

        private static void AddHeaderTitles(ExcelWorksheet sheet)
        {
            string titlesCells = "A6:L7";
            InsertText(sheet, "A6:E6", "BILLING", true, colorBlue, 14);
            InsertText(sheet, "A7", "BILLING DATES", false, colorBlue, 10);
            InsertText(sheet, "B7", "BILLING PERIOD", false, colorBlue, 10);
            InsertText(sheet, "C7", "CLASSIFICATION", false, colorBlue, 10);
            InsertText(sheet, "D7", "SOA NUMBER", false, colorBlue, 10);
            InsertText(sheet, "E7", "GROSS AMOUNT", false, colorBlue, 10);
            InsertText(sheet, "F6:F7", "ADJUSTMENT", true, colorPurple);
            InsertText(sheet, "G6:H6", "REVISION", true, colorGreen, 14);
            InsertText(sheet, "G7", "REVISED DATE", false, colorGreen, 10);
            InsertText(sheet, "H7", "GROSS AMOUNT", false, colorGreen, 10);
            InsertText(sheet, "I6:K6", "COLLECTION", true, colorRed, 14);
            InsertText(sheet, "I7", "COLLECTED ON", false, colorRed, 10);
            InsertText(sheet, "J7", "OR NUMBER", false, colorRed, 10);
            InsertText(sheet, "K7", "AMOUNT", false, colorRed, 10);
            InsertText(sheet, "L6:L7", "BALANCE", true, colorLightYellow, 14);
            SetRowHeight(sheet, 6, 36);
            SetRowHeight(sheet, 7, 36);
            SetBorders(sheet, titlesCells, ExcelBorderStyle.Medium);
            SetToBold(sheet, titlesCells);
        }

        private static void SetColumnSizes(ExcelWorksheet sheet)
        {
            SetColumnWidth(sheet, 1, 20);
            SetColumnWidth(sheet, 2, 20);
            SetColumnWidth(sheet, 3, 30);
            SetColumnWidth(sheet, 4, 35);
            SetColumnWidth(sheet, 5, 20);
            SetColumnWidth(sheet, 6, 15);
            SetColumnWidth(sheet, 7, 15);
            SetColumnWidth(sheet, 8, 15);
            SetColumnWidth(sheet, 9, 20);
            SetColumnWidth(sheet, 10, 15);
            SetColumnWidth(sheet, 11, 20);
            SetColumnWidth(sheet, 12, 20);
        }
    }
}
