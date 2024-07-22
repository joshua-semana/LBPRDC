using LBPRDC.Source.Config;
using Microsoft.EntityFrameworkCore;
using static LBPRDC.Source.Data.Database;

namespace LBPRDC.Source.Services
{
    internal class UserRoleService
    {
        public static async Task<Models.UserRole> GetType(int ID)
        {
            Models.UserRole type = new();

            try
            {
                using var context = new Context();

                var result = await context.UserRoles.FindAsync(ID);
                if (result != null)
                {
                    type = result;
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return type;
        }

        public static async Task<List<Models.UserRole>> GetItemsForComboBox(bool WithDefault = true, bool? ExcludeAdmin = false)
        {
            List<Models.UserRole> items = new();

            try
            {
                if (WithDefault)
                {
                    items.Add(new Models.UserRole
                    {
                        ID = 0,
                        Name = StringConstants.ComboBox.DEFAULT_USER_ROLE
                    });
                }

                using var context = new Context();

                var query = context.UserRoles.AsQueryable();

                if (ExcludeAdmin != null && ExcludeAdmin == true)
                {
                    query = query.Where(w => w.IsAdmin == false);
                }

                var result = await query
                    .Select(s => new Models.UserRole
                    {
                        ID = s.ID,
                        Name = s.Name,
                    })
                    .ToListAsync();

                items.AddRange(result);
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }
    }
}
