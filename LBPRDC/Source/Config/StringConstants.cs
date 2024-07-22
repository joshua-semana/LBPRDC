namespace LBPRDC.Source.Config
{
    public class StringConstants
    {
        public static class UserRole
        {
            public const string ADMIN = "Admin";
            public const string STANDARD = "Standard";
        }

        public static class Wage
        {
            public const string DAILY = "Daily";
            public const string MONTHLY = "Monthly";
        }

        public static class Status
        {
            public const string INITIAL = "Initial Status";
            public const string ACTIVE = "Active";
            public const string INACTIVE = "Inactive";
            public const string VERIFIED = "Verified";
            public const string UNVERIFIED = "Unverified";
            public const string LOCK = "Lock";
            public const string UNLOCK = "Unlock";
            public const string YES = "Yes";
            public const string NO = "No";
            public const string NOT_RELEASED = "Not Yet Released";
            public const string NOT_COLLECTED = "Not Yet Collected";
            public const string COLLECTING = "Still Collecting";
            public const string COLLECTED = "Collected";
            public const string NONE = "None";
            public const string RELEASED = "Released";
            public const string UNRELEASED = "Unreleased";
            public const string NO_DATA = "No Data";
        }

        public class InitialRemarks
        {
            public const string POSITION = "Initial Position";
            public const string EMPLOYMENT_STATUS = "Initial Employment Status";
            public const string DEPARTMENT_AND_LOCATION = "Initial Department & Location";
        }

        public class Type
        {
            public const string REGULAR = "Regular";
            public const string OVERTIME = "Overtime";
            public const string CUSTOM = "Custom";
            public const string EQUIPMENT = "Equipment";
            public const string DEFAULT = "Default";
            public const string USER_ENTRY = "User Entry";
        }

        public class DisplayStatus
        {
            public const string RIGHT_ARROW = ">";
            public const string CURRENT = "Current";
            public const string OLD = "Old";
        }

        public static class Date
        {
            public const string DEFAULT = "MMMM dd, yyyy";
        }

        public static class ComboBox
        {
            public const string NOTHING = "Nothing";
            public const string NOTHING_FOUND = "Nothing Found";
            public const string DEFAULT_USER_ROLE = "(Choose Role)";
            public const string DEFAULT_SUFFIX = "(Choose Suffix)";
            public const string DEFAULT_EMPLOYMENT_STATUS = "(Choose Employment Status)";
            public const string DEFAULT_PAY_FREQUENCY = "(Choose Pay Frequency)";
            public const string DEFAULT_CLIENT = "(Choose Client)";
            public const string DEFAULT_CLASSIFICATION = "(Choose Classification)";
            public const string DEFAULT_WAGE = "(Choose Wage Type)";
            public const string DEFAULT_POSITION = "(Choose Position)";
            public const string DEFAULT_DEPARTMENT = "(Choose Department)";
            public const string DEFAULT_LOCATION = "(Choose Location)";
        }

        public static class Remarks
        {
            public const string DEFAULT_BILLING_EQUIPMENT = "Supplies and Equipment Billing";
        }

        public static class SheetName
        {
            public const string UNDEFINED = "??";
            public const string ADJUSTMENT = "Adjustments";
            public const string BALANCING = "Balancing";
            public const string OVERTIME = "Overtime";
        }

        // START OF CATEGORIES CONTROL

        public static class Operations
        {
            public const string UPDATE = "Update";
            public const string DELETE = "Delete";
            public const string DUPLICATE = "Duplicate";
            public const string OVERWRITE = "Overwrite";
            public const string NEW = "New";
        }

        public static class Categories
        {
            public const string CLIENT = "Clients";
            public const string CLASSIFICATION = "Classifications";
            public const string WAGE = "Wages";
            public const string POSITION = "Positions";
            public const string DEPARTMENT = "Departments";
            public const string LOCATION = "Locations";
            public const string EMPLOYMENT_STATUS = "Employment Status";
        }

        public static class CategoriesSingular
        {
            public const string PAY_FREQUENCY = "Pay Frequency";
            public const string CLIENT = "Client";
            public const string CLASSIFICATION = "Classification";
            public const string WAGE = "Wage";
            public const string POSITION = "Position";
            public const string DEPARTMENT = "Department";
            public const string LOCATION = "Location";
            public const string EMPLOYMENT_STATUS = "Employment Status";
        }

        public static class DBTableNames
        {
            public const string CLIENT = "Clients";
            public const string CLASSIFICATION = "Classifications";
            public const string POSITION = "Position";
            public const string DEPARTMENT = "Departments";
            public const string LOCATION = "Locations";
            public const string EMPLOYMENT_STATUS = "EmploymentStatus";
            public const string WAGE = "Wages";
        }

        // END OF CATEGORIES CONTROL

        // START OF MAIN FORM

        public static readonly string[] Greetings =
        {
            "Hello,",
            "Hi,",
            "Hey,",
            "Hey there,",
            "Hi there,",
            "Greetings,",
            "Howdy,",
            "Salutations,",
            "What's up,",
            "Yo,",
            "Hiya,",
            "Aloha,",
            "Hola,",
            "Bonjour,",
            "Ciao,",
            "Sup,",
            "How's it going,",
            "How are you,",
            "Wassup,"
        };

        // END OF MAIN FORM
    }
}
