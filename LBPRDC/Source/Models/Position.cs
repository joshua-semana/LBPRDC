using LBPRDC.Source.Config;

namespace LBPRDC.Source.Models
{
    public class Position
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public string Code { get; set; } = "";
        public string Name { get; set; } = "";
        public decimal DailySalaryRate { get; set; }
        public decimal DailyBillingRate { get; set; }
        public decimal MonthlySalaryRate { get; set; }
        public decimal MonthlyBillingRate { get; set; }
        public string Status { get; set; } = StringConstants.Status.ACTIVE;
        public string Description { get; set; } = "";
        public Client Client { get; set; }

        public class View : Position
        {
            public string ClientName { get; set; } = "";
        }

        public class History
        {
            public int HistoryID { get; set; }
            public int EmployeeID { get; set; }
            public int PositionID { get; set; }
            public string WageType { get; set; } = "";
            public string PositionTitle { get; set; } = "";
            public decimal DailySalaryRate { get; set; }
            public decimal DailyBillingRate { get; set; }
            public decimal MonthlySalaryRate { get; set; }
            public decimal MonthlyBillingRate { get; set; }
            public DateTime Timestamp { get; set; } = DateTime.Now;
            public string Remarks { get; set; } = "";
            public string Status { get; set; } = StringConstants.Status.INACTIVE;
        }

        public class HistoryAdditional : History
        {
            public int OldPositionID { get; set; }
        }

        public class HistoryView : History
        {
            public string Indicator { get; set; } = "";
            public string PositionName { get; set; } = "";
            public string EffectiveDate { get; set; } = "";
        }

        public class RatesHistory
        {
            public int ID { get; set; }
            public int PositionID { get; set; }
            public decimal DailySalaryRate { get; set; }
            public decimal DailyBillingRate { get; set; }
            public decimal MonthlySalaryRate { get; set; }
            public decimal MonthlyBillingRate { get; set; }
            public DateTime Timestamp { get; set; } = DateTime.Now;
        }

        public class RatesHistoryView : RatesHistory
        {
            public string Indicator { get; set; } = "";
        }
    }
}
