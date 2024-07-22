namespace LBPRDC.Source.Models
{
    public class RolePermission
    {
        public int ID { get; set; }
        public int UserRoleID { get; set; }
        public int AccessPermissionID { get; set; }
        public UserRole _UserRole { get; set; }
        public AccessPermission _AccessPermission { get; set; }

        public class View : RolePermission
        {
            public string UserRoleName { get; set; } = "";
            public string AccessPermissionName { get; set; } = "";
        }
    }
}
