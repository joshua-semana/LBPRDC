using Microsoft.EntityFrameworkCore;
using static LBPRDC.Source.Data.Database;

namespace LBPRDC.Source.Services
{
    internal class AccessPermissionService
    {
        public static Models.AccessPermission.Permissions CurrentUserPermissions { get; set; } = new();

        public static void SetPermissions(Models.AccessPermission.Permissions Instance, List<Models.RolePermission.View> Permissions)
        {
            var type = Instance.GetType();

            foreach (var permission in Permissions)
            {
                var property = type.GetProperty(permission.AccessPermissionName);

                if (property != null && property.PropertyType == typeof(bool) && property.CanWrite)
                {
                    property.SetValue(Instance, true);
                }
            }
        }

        public static void SetAllPermissionsByBool(Models.AccessPermission.Permissions Instance, bool State)
        {
            var type = Instance.GetType();

            foreach (var property in type.GetProperties())
            {
                if (property.PropertyType == typeof(bool) && property.CanWrite)
                {
                    property.SetValue(Instance, State);
                }
            }
        }

        public static async Task<List<Models.AccessPermission>> GetAllPermissions()
        {
            List<Models.AccessPermission> permissions = new();

            try
            {
                using var context = new Context();
                permissions = await context.AccessPermissions.ToListAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return permissions;
        }
    }
}
