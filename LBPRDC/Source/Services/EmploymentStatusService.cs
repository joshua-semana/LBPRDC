using LBPRDC.Source.Config;
using Microsoft.EntityFrameworkCore;
using static LBPRDC.Source.Data.Database;

namespace LBPRDC.Source.Services
{
    public class EmploymentStatusService
    {
        public static async Task<List<Models.EmploymentStatus>> GetItems(string? Status = null)
        {
            List<Models.EmploymentStatus> items = new();

            try
            {
                using var context = new Context();
                var query = context.EmploymentStatus.AsQueryable();

                if (Status != null)
                {
                    query = query.Where(w => w.Status == Status);
                }

                items = await query.ToListAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }

        public static async Task<List<Models.EmploymentStatus>> GetAllItemsForComboBox(bool withDefault = true)
        {
            List<Models.EmploymentStatus> items = new();

            try
            {
                if (withDefault)
                {
                    items.Add(new Models.EmploymentStatus
                    {
                        ID = 0,
                        Name = StringConstants.ComboBox.DEFAULT_EMPLOYMENT_STATUS
                    });
                }

                using var context = new Context();

                var result = await context.EmploymentStatus
                    .Where(w => w.Status.Equals(StringConstants.Status.ACTIVE))
                    .Select(s => new Models.EmploymentStatus
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

        public static async Task<bool> Add(Models.EmploymentStatus data)
        {
            try
            {
                using var context = new Context();
                context.EmploymentStatus.Add(data);
                await context.SaveChangesAsync();

                await LoggingService.AddLog(new()
                {
                    UserID = UserService.CurrentUser.ID,
                    Type = MessagesConstants.Add.TITLE,
                    Details = $"Added a new employment status: {data.Name}"
                });

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> Update(Models.EmploymentStatus data)
        {
            try
            {
                using var context = new Context();
                var item = await context.EmploymentStatus.FindAsync(data.ID);
                if (item == null) { return false; }

                item.Name = data.Name;
                item.Description = data.Description;
                item.Status = data.Status;

                await context.SaveChangesAsync();

                await LoggingService.AddLog(new()
                {
                    UserID = UserService.CurrentUser.ID,
                    Type = MessagesConstants.UPDATE,
                    Details = $"Updated an employment status information with an ID: {data.ID}"
                });

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        // HISTORY-RELATED

        public static async Task<List<Models.EmploymentStatus.HistoryView>> GetHistoriesWithView(int EmployeeID)
        {
            List<Models.EmploymentStatus.HistoryView> histories = new();

            try
            {
                using var context = new Context();

                histories = await context.EmployeeEmploymentHistory
                    .Include(i => i._EmploymentStatus)
                    .Where(w => w.EmployeeID == EmployeeID)
                    .Select(s => new Models.EmploymentStatus.HistoryView 
                    { 
                        EmploymentStatusName = s._EmploymentStatus.Name,
                        EffectiveDate = s.Timestamp.ToString(StringConstants.Date.DEFAULT),
                        Remarks = s.Remarks,
                        Status = s.Status
                    })
                    .ToListAsync();

                foreach (var history in histories)
                {
                    history.Indicator = (history.Status == StringConstants.Status.ACTIVE) ? StringConstants.DisplayStatus.RIGHT_ARROW : "";
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return histories;
        }

        public static async Task<Models.EmploymentStatus.History?> GetEmployeeHistory(int EmployeeID, string Status = StringConstants.Status.ACTIVE)
        {
            Models.EmploymentStatus.History? record = new();

            try
            {
                using var context = new Context();
                record = await context.EmployeeEmploymentHistory
                    .Where(h => h.EmployeeID == EmployeeID && h.Status == Status)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return record;
        }
    }
}
