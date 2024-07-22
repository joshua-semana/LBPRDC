namespace LBPRDC.Source.Models
{
    public class AuditLog
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Type { get; set; } = "";
        public string Details { get; set; } = "";
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public User User { get; set; }

        public class View : AuditLog
        {
            public string FullName { get; set; } = "";
        }
    }
}
