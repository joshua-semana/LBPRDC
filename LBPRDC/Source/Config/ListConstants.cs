namespace LBPRDC.Source.Config
{
    public class ListConstants
    {
        public static class EntityTableRefs
        {
            public static List<string> FOR_CLIENTS { get; set; } = new() { "Classifications", "Billing", "BillingAccounts", "BillingRecord", "Position", "Departments", "Employees" };
            public static List<string> FOR_CLASSIFICATIONS { get; set; } = new() { "Employees" };
            public static List<string> FOR_WAGES { get; set; } = new() { "Employees" };
            public static List<string> FOR_POSITIONS { get; set; } = new() { "Employees" };
            public static List<string> FOR_DEPARTMENTS { get; set; } = new() { "Employees", "Locations" };
            public static List<string> FOR_LOCATIONS { get; set; } = new() { "Employees" };
            public static List<string> FOR_CIVIL_STATUS { get; set; } = new() { "Employees" };
            public static List<string> FOR_EMPLOYMENT_STATUS { get; set; } = new() { "Employees" };
        }
    }
}
