using Dapper;
using LBPRDC.Source.Config;
using LBPRDC.Source.Data;
using Microsoft.EntityFrameworkCore;
using static LBPRDC.Source.Data.Database;

namespace LBPRDC.Source.Services
{
    internal class WageService
    {
        public static async Task<List<Models.Wage>> GetWagesAsync()
        {
            List<Models.Wage> wages = new();

            try
            {
                using var context = new Context();
                wages = await context.Wages.ToListAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return wages;
        }

        public static async Task<bool> Add(Models.Wage data)
        {
            try
            {
                using var context = new Context();
                context.Wages.Add(data);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> Update(Models.Wage data)
        {
            try
            {
                using var context = new Context();

                var item = await context.Wages.FindAsync(data.ID);

                if (item == null) { return false; }
                if (AreEqual(item, data)) { return true; }

                item.Name = data.Name;
                item.Description = data.Description;
                item.Status = data.Status;

                int affectedRows = await context.SaveChangesAsync();

                if (affectedRows > 0)
                {
                    if (UserService.CurrentUser != null)
                    {
                        LoggingService.LogActivity(new()
                        {
                            UserID = UserService.CurrentUser.UserID,
                            ActivityType = MessagesConstants.UPDATE,
                            ActivityDetails = $"This user updated an item under the wage category with an ID of {data.ID}."
                        });
                    }
                }

                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        private static bool AreEqual(Models.Wage item1, Models.Wage item2)
        {
            return item1.Name == item2.Name &&
                   item1.Description == item2.Description &&
                   item1.Status == item2.Status;
        }

        public static List<string> GetExistenceByID(int WageID)
        {
            List<string> databaseTableNames = new();

            try
            {
                using var connection = Database.Connect();

                string QueryCheckExistense = "";
                List<string> tableNames = new()
                {
                    "Employee"
                };

                List<string> selectQueries = tableNames.Select(name =>
                    $"SELECT DISTINCT '{name}' AS TableName FROM {name} WHERE WageID = @WageID"
                ).ToList();

                QueryCheckExistense = string.Join(" UNION ALL ", selectQueries);

                databaseTableNames = connection.Query<string>(QueryCheckExistense, new
                {
                    WageID
                }).ToList();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return databaseTableNames;
        }

        public static async Task<List<Models.Wage>> GetAllItemsForComboBox(bool WithDefault = true)
        {
            List<Models.Wage> items = new();

            try
            {
                if (WithDefault)
                {
                    items.Add(new Models.Wage
                    {
                        ID = 0,
                        Name = StringConstants.ComboBox.DEFAULT_WAGE
                    });
                }

                using var context = new Context();

                var result = await context.Wages
                    .Where(w => w.Status.Equals(StringConstants.Status.ACTIVE))
                    .Select(s => new Models.Wage
                    {
                        ID = s.ID,
                        Name = s.Name
                    })
                    .ToListAsync();

                items.AddRange(result);
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }
    }
}
