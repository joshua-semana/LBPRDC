using LBPRDC.Source.Config;

namespace LBPRDC.Source.Models
{
    public class Suffix
    {
        public int ID { get; set; }
        public string Name { get; set; } = "";
        public string Status { get; set; } = StringConstants.Status.ACTIVE;
        public string Description { get; set; } = "";
    }
}
