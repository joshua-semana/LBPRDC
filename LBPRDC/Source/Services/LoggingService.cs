using Microsoft.EntityFrameworkCore;
using static LBPRDC.Source.Data.Database;

namespace LBPRDC.Source.Services
{
    internal class LoggingService
    {
        public static async Task AddLog(Models.AuditLog log)
        {
            try
            {
                using var context = new Context();
                await context.AuditLogs.AddAsync(log);
                await context.SaveChangesAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }

        public static async Task<List<string>> GetAllDistinctTypes(DateTime? date = null)
        {
            List<string> types = new();

            try
            {
                using var context = new Context();

                var query = context.AuditLogs.AsQueryable();

                if (date != null)
                {
                    DateTime startDate = date.Value.Date;
                    DateTime endDate = date.Value.Date.AddDays(1).AddTicks(-1);

                    query = query.Where(w => w.Timestamp >= startDate && w.Timestamp <= endDate);
                }

                types = await query.Select(s => s.Type).Distinct().ToListAsync();
                types.Sort();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return types;
        }

        public static async Task<(List<Models.AuditLog.View> Items, int TotalCount)> GetFilteredItems(List<string>? types = null, string? search = null, DateTime? date = null)
        {
            List<Models.AuditLog.View> logs = new();
            int count = 0;

            try
            {
                using var context = new Context();

                var query = context.AuditLogs.Include(i => i.User).AsQueryable();

                if (types != null && types.Any())
                {
                    query = query.Where(w => types.Contains(w.Type));
                }

                if (!string.IsNullOrEmpty(search))
                {
                    string pattern = $"%{search}%";
                    query = query
                        .Where(w => EF.Functions.Like(w.Details, pattern) || 
                                    EF.Functions.Like(w.User.FirstName + " " + w.User.LastName, pattern));
                }

                if (date != null && date.HasValue)
                {
                    DateTime startDate = date.Value.Date;
                    DateTime endDate = date.Value.Date.AddDays(1).AddTicks(-1);

                    query = query.Where(w => w.Timestamp >= startDate && w.Timestamp <= endDate);
                    count = await context.AuditLogs.Where(w => w.Timestamp >= startDate && w.Timestamp <= endDate).CountAsync();
                }
                else
                {
                    count = await context.AuditLogs.CountAsync();
                }

                var result = await query
                    .Select(s => new Models.AuditLog.View
                    {
                        ID = s.ID,
                        UserID = s.UserID,
                        FullName = $"{s.User.FirstName} {s.User.LastName}",
                        Type = s.Type,
                        Details = s.Details,
                        Timestamp = s.Timestamp,
                    })
                    .OrderByDescending(o => o.Timestamp)
                    .ToListAsync();

                logs = result;
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return (logs, count);
        }
    }
}
