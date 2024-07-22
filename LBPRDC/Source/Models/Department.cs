using LBPRDC.Source.Config;
using LBPRDC.Source.Services;

namespace LBPRDC.Source.Models
{
    public class Department
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public string Code { get; set; } = "";
        public string Name { get; set; } = "";
        public string Status { get; set; } = StringConstants.Status.ACTIVE;
        public string Description { get; set; } = "";
        public Client Client { get; set; }

        public class View : Department
        {
            public string ClientName { get; set; } = "";
        }

        public class History
        {
            public int HistoryID { get; set; }
            public int EmployeeID { get; set; }
            public string DepartmentName { get; set; } = "";
            public string LocationName { get; set; } = "";
            public DateTime Timestamp { get; set; } = DateTime.Now;
            public string Remarks { get; set; } = "";
            public string Status { get; set; } = StringConstants.Status.ACTIVE;
        }

        public class HistoryAdditional : History
        {
            public int DepartmentID { get; set; }
            public int LocationID { get; set; }
        }

        public class HistoryView : History
        {
            public string Indicator { get; set; } = "";
            public string EffectiveDate { get; set; } = "";

        }
    }
}
