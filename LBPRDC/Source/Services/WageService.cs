using LBPRDC.Source.Config;
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

                item.Name = data.Name;
                item.Description = data.Description;
                item.Status = data.Status;

                context.Entry(item).State = EntityState.Modified;

                await context.SaveChangesAsync();

                await LoggingService.AddLog(new()
                {
                    UserID = UserService.CurrentUser.ID,
                    Type = MessagesConstants.UPDATE,
                    Details = $"Updated wage's information with ID of: {data.ID}"
                });

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
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
