using LBPRDC.Source.Config;

namespace LBPRDC.Source.Models
{
    public class Location
    {
        public int ID { get; set; }
        public string Type { get; set; } = StringConstants.Type.USER_ENTRY; // DEFAULT or USER_ENTRY
        public string Name { get; set; } = "";
        public int DepartmentID { get; set; }
        public string Status { get; set; } = StringConstants.Status.ACTIVE;
        public string Description { get; set; } = "";
        public Department Department { get; set; }

        public class View : Location
        {
            public string DepartmentClientName { get; set; } = "";
            public string DepartmentName { get; set; } = "";
        }
    }
}
