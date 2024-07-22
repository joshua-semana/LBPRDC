using LBPRDC.Source.Config;

namespace LBPRDC.Source.Models
{
    public class Client
    {
        public int ID { get; set; }
        public int PayFrequencyID { get; set; }
        public string Code { get; set; } = "";
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Status { get; set; } = StringConstants.Status.ACTIVE;
        public PayFrequency PayFrequency { get; set; }

        public class View : Client
        {
            public string PayFrequencyName { get; set; } = "";
        }
    }
}
