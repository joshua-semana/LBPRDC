namespace LBPRDC.Source.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string EmployeeID { get; set; } = "";
        public int ClientID { get; set; }
        public string LastName { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string MiddleName { get; set; } = "";
        public string Gender { get; set; } = "";
        public DateTime Birthday { get; set; }
        public string Education { get; set; } = "";
        public string EmailAddress1 { get; set; } = "";
        public string EmailAddress2 { get; set; } = "";
        public string ContactNumber1 { get; set; } = "";
        public string ContactNumber2 { get; set; } = "";
        public int SuffixID { get; set; }
        public int DepartmentID { get; set; }
        public int LocationID { get; set; }
        public int CivilStatusID { get; set; }
        public int PositionID { get; set; }
        public int EmploymentStatusID { get; set; }
        public string Remarks { get; set; } = "";
        public int WageID { get; set; }

        // Navigation Properties
        public Client Client { get; set; }
        public Department Department { get; set; }
        public Location Location { get; set; }
        public Position Position { get; set; }
        public CivilStatus CivilStatus { get; set; }
        public EmploymentStatus EmploymentStatus { get; set; }
        public Suffix Suffix { get; set; }
        public Wage Wage { get; set; }

        public class Identifier
        {
            public int ID { get; set; }
            public string EmployeeID { get; set; } = "";
        }

        public class View : Employee
        {
            public string ClientName { get; set; } = "";
            public string FullName { get; set; } = "";
            public string DepartmentName { get; set; } = "";
            public string LocationName { get; set; } = "";
            public string CivilStatusName { get; set; } = "";
            public string PositionName { get; set; } = "";
            public string EmploymentStatusName { get; set; } = "";
            public string SuffixName { get; set; } = "";
            public string WageName { get; set; } = "";
        }

        public class TableView : View
        {
            public string PositionInfo { get; set; } = "";
            public string JoinedEmailAddress { get; set; } = "";
            public string JoinedContactNumber { get; set; } = "";
            public decimal BillingRate { get; set; }
            public decimal SalaryRate { get; set; }
        }

        public class History // Previous Employee Record
        {
            public int ID { get; set; }
            public bool HasRecord { get; set; } = false;
            public int EmployeeID { get; set; }
            public string Position { get; set; } = "";
            public DateTime StartDate { get; set; } = DateTime.MinValue;
            public DateTime EndDate { get; set; } = DateTime.MinValue;
            public string Information { get; set; } = "";
        }
    }
}
