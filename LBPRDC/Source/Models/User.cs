namespace LBPRDC.Source.Models
{
    public class User
    {
        public int ID { get; set; }
        public int UserRoleID { get; set; }
        public string Username { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string MiddleName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string PositionTitle { get; set; } = "";
        public string Status { get; set; } = "";
        public DateTime RegistrationDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public UserRole _UserRole { get; set; }

        public class View : User
        {
            public string UserRoleName { get; set; } = "";
        }
    }
}
