namespace LBPRDC.Source.Models
{
    public class EmployeeArchive
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public string ClientName { get; set; } = "";
        public string EmployeeID { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string MiddleName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Suffix { get; set; } = "";
        public string Gender { get; set; } = "";
        public string Position { get; set; } = "";
        public string Classification { get; set; } = "";
        public string Department { get; set; } = "";
        public string Location { get; set; } = "";
        public string EmailAddress1 { get; set; } = "";
        public string EmailAddress2 { get; set; } = "";
        public string ContactNumber1 { get; set; } = "";
        public string ContactNumber2 { get; set; } = "";
        public string EmploymentStatus { get; set; } = "";
        public string Remarks { get; set; } = "";
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
