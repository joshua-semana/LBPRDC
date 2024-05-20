using LBPRDC.Source.Config;
using System.Diagnostics.CodeAnalysis;

namespace LBPRDC.Source.Models
{
    public class Classification
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        [NotNull]
        public string Name { get; set; } = "";
        public string Status { get; set; } = StringConstants.Status.ACTIVE;
        public string Description { get; set; } = "";
        public Client Client { get; set; }

        public class TableView : Classification
        {
            public string ClientName { get; set; } = "";
        }
    }
}
