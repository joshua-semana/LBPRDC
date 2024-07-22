using Microsoft.EntityFrameworkCore;
using static LBPRDC.Source.Data.Database;
using static LBPRDC.Source.Models.AccessPermission;

namespace LBPRDC.Source.Services
{
    internal class RolePermissionService
    {
        public static async Task<List<Models.RolePermission.View>> GetAllPermission(int? RoleID = null)
        {
            List<Models.RolePermission.View> permissions = new();

            try
            {
                using var context = new Context();

                var query = context.RolePermissions.AsQueryable();

                if (RoleID != null)
                {
                    query = query.Where(w => w.UserRoleID == RoleID);
                }

                permissions = await query
                    .Include(i => i._UserRole)
                    .Include(i => i._AccessPermission)
                    .Select(s => new Models.RolePermission.View
                    {
                        ID = s.ID,
                        AccessPermissionID = s.AccessPermissionID,
                        AccessPermissionName = s._AccessPermission.Name
                    })
                    .ToListAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return permissions;
        }

        public static async Task<bool> UpdatePermissions(int userRoleID, List<int> permissionsToAdd, List<int> permissionsToDelete)
        {
            try
            {
                using var context = new Context();
                using var transaction = context.Database.BeginTransaction();

                try
                {
                    List<Models.RolePermission> permissionToAddList = new();
                    List<Models.RolePermission> permissionToDeleteList = new();

                    foreach (var permissionID in permissionsToAdd)
                    {
                        permissionToAddList.Add(new()
                        {
                            UserRoleID = userRoleID,
                            AccessPermissionID = permissionID
                        });
                    }

                    foreach (var permissionID in permissionsToDelete)
                    {
                        var rolePermission = await context.RolePermissions.Where(w => w.UserRoleID == userRoleID && w.AccessPermissionID == permissionID).FirstOrDefaultAsync();
                        if (rolePermission == null) { continue; }

                        permissionToDeleteList.Add(rolePermission);
                    }

                    context.RolePermissions.AddRange(permissionToAddList);
                    context.RolePermissions.RemoveRange(permissionToDeleteList);

                    //if (permissionToAddList.Any())
                    //{
                    //    if (permissionToAddList.Count == 1)
                    //    {
                    //        var permissionToAdd = permissionToAddList.First();
                    //        context.RolePermissions.Add(permissionToAdd);
                    //    }
                    //    else
                    //    {
                    //        context.RolePermissions.AddRange(permissionToAddList);
                    //    }
                    //}

                    //if (permissionToDeleteList.Any())
                    //{
                    //    if (permissionToDeleteList.Count == 1)
                    //    {
                    //        var permissionToDelete = permissionToDeleteList.First();
                    //        context.RolePermissions.Remove(permissionToDelete);
                    //    }
                    //    else
                    //    {
                    //        context.RolePermissions.RemoveRange(permissionToDeleteList);
                    //    }
                    //}

                    await context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return true;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    return false;
                }
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }
    }
}
