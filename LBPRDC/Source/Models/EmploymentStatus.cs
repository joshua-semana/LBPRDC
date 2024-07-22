using LBPRDC.Source.Config;

namespace LBPRDC.Source.Models
{
    public class EmploymentStatus
    {
        public int ID { get; set; }
        public string Name { get; set; } = "";
        public string Status { get; set; } = StringConstants.Status.ACTIVE;
        public string Description { get; set; } = "";

        public class History
        {
            public int HistoryID { get; set; }
            public int EmployeeID { get; set; }
            public int EmploymentStatusID { get; set; }
            public DateTime Timestamp { get; set; } = DateTime.Now;
            public string Remarks { get; set; } = "";
            public string Status { get; set; } = StringConstants.Status.ACTIVE;
            public EmploymentStatus _EmploymentStatus { get; set; }
        }

        public class HistoryView : History
        {
            public string Indicator { get; set; } = "";
            public string EmploymentStatusName { get; set; } = "";
            public string EffectiveDate { get; set; } = "";
        }
    }
}
