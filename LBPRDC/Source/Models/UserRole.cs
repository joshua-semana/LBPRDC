namespace LBPRDC.Source.Models
{
    public class UserRole
    {
        public int ID { get; set; }
        public string Name { get; set; } = "";
        public bool IsAdmin { get; set; }
        public string Description { get; set; } = "";
    }
}
