namespace LBPRDC.Source.Utilities
{
    internal class FileFormatConstants
    {
        public static readonly List<string> addBatchFormat = new()
        {
            "EMPLOYEE ID",
            "LAST NAME",
            "FIRST NAME",
            "MIDDLE NAME",
            "SUFFIX",
            "GENDER",
            "BIRTHDAY",
            "EDUCATION",
            "DEPARTMENT",
            "EMAIL ADDRESS 1",
            "EMAIL ADDRESS 2",
            "CONTACT NUMBER 1",
            "CONTACT NUMBER 2",
            "CIVIL STATUS",
            "POSITION",
            "POSITION TITLE",
            "START DATE",
            "NEW POSITION",
            "NEW POSITION TITLE",
            "EFFECTIVE DATE",
            "EMPLOYMENT STATUS"
        };

        public static readonly List<string> ExcelTimekeepWorksheetFormat = new()
        {
            "Scanning Number",
            "Name",
            "Date",
            "PAYROLL DOCS FILE NAME",
            "PAYROLL DOCS FILE NAME",
            "Regular Hours",
            "Legal Holiday -UNWORKED",
            "Reg OT",
            "Rest Day OT",
            "RDOT Excess",
            "Special Holiday OT",
            "Special Holiday Excess OT",
            "Legal Holiday OT",
            "Legal Holiday OT",
            "Rest Day OT",
            "Reg Holiday OT",
            "TOTAL OT",
            "Night Differential",
            "Night Differential",
            "Night Differential",
            "Night Differential",
            "Night Differential",
            "Night Differential",
            "TOTAL NDOT",
            "UT",
            "Absent"
        };

        public static readonly List<string> ExcelReportWorksheetFormat = new()
        {
            "PAYROLL COMPUTATION - SHFC"
        };
    }
}
