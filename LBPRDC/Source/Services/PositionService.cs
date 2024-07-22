using LBPRDC.Source.Config;
using Microsoft.EntityFrameworkCore;
using static LBPRDC.Source.Data.Database;

namespace LBPRDC.Source.Services
{
    internal class PositionService
    {
        public static async Task<List<Models.Position>> GetItems(int? ClientID = null)
        {
            List<Models.Position> items = new();

            try
            {
                using var context = new Context();
                var query = context.Position.AsQueryable();

                if (ClientID != null)
                {
                    query = query.Where(w => w.ClientID == ClientID);
                }

                items = await query.ToListAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }

        public static async Task<List<Models.Position.View>> GetAllItemsWithView()
        {
            List<Models.Position.View> items = new();

            try
            {
                using var context = new Context();
                items = await context.Position
                    .Include(i => i.Client)
                    .Where(w => w.Client.PayFrequencyID == PayFrequencyService.CurrentPayFrequencyID)
                    .Select(s => new Models.Position.View
                    {
                        ID = s.ID,
                        ClientID = s.ClientID,
                        Code = s.Code,
                        Name = s.Name,
                        DailySalaryRate = s.DailySalaryRate,
                        DailyBillingRate = s.DailyBillingRate,
                        MonthlySalaryRate = s.MonthlySalaryRate,
                        MonthlyBillingRate = s.MonthlyBillingRate,
                        Status = s.Status,
                        Description = s.Description,
                        ClientName = s.Client.Name
                    })
                    .ToListAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }

        // TODO: To be remove, use GetItems()
        public static async Task<List<Models.Position>> GetAllItems()
        {
            List<Models.Position> items = new();

            try
            {
                using var context = new Context();
                items = await context.Position.ToListAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }

        public static async Task<List<Models.Position>> GetAllItemsForComboBoxByClientID(int ClientID = 0, bool withDefault = true)
        {
            List<Models.Position> items = new();

            try
            {
                if (withDefault) 
                {
                    items.Add(new Models.Position
                    {
                        ID = 0,
                        Name = StringConstants.ComboBox.DEFAULT_POSITION
                    });
                }

                using var context = new Context();

                var result = await context.Position
                    .Include(i => i.Client)
                    .Where(w => w.Client.PayFrequencyID == PayFrequencyService.CurrentPayFrequencyID)
                    .Where(p => 
                        p.Status.Equals(StringConstants.Status.ACTIVE) &&
                        p.ClientID.Equals(ClientID))
                    .Select(p => new Models.Position
                    {
                        ID = p.ID,
                        Name = p.Name
                    })
                    .ToListAsync();

                items.AddRange(result);
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }

        public static async Task<List<Models.Position.History>> GetAllEmployeeHistory(int EmployeeID)
        {
            List<Models.Position.History> record = new();

            try
            {
                using var context = new Context();
                record = await context.EmployeePositionHistory
                    .Where(h => h.EmployeeID == EmployeeID)
                    .ToListAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return record;
        }

        public static async Task<bool> Add(Models.Position data)
        {
            try
            {
                using var context = new Context();
                using var transaction = await context.Database.BeginTransactionAsync();

                try
                {
                    context.Position.Add(data);
                    await context.SaveChangesAsync();

                    int newInsertedID = data.ID;

                    AddRatesHistory(new()
                    {
                        PositionID = newInsertedID,
                        DailySalaryRate = data.DailySalaryRate,
                        DailyBillingRate = data.DailyBillingRate,
                        MonthlySalaryRate = data.MonthlySalaryRate,
                        MonthlyBillingRate = data.MonthlyBillingRate,
                        Timestamp = DateTime.Now
                    });

                    await LoggingService.AddLog(new()
                    {
                        UserID = UserService.CurrentUser.ID,
                        Type = MessagesConstants.Logs.TITLE_NEW_CATEGORY,
                        Details = $"{MessagesConstants.Logs.NEW_POSITION}{data.Name}"
                    });

                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    return false;
                }
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> Update(Models.Position data)
        {
           
            try
            {
                using var context = new Context();
                var position = await context.Position.FindAsync(data.ID);

                if (position == null) { return false; }

                position.ClientID = data.ClientID;
                position.Code = data.Code;
                position.Name = data.Name;
                position.DailySalaryRate = data.DailySalaryRate;
                position.DailyBillingRate = data.DailyBillingRate;
                position.MonthlySalaryRate = data.MonthlySalaryRate;
                position.MonthlyBillingRate = data.MonthlyBillingRate;
                position.Description = data.Description;
                position.Status = data.Status;

                await context.SaveChangesAsync();

                await LoggingService.AddLog(new()
                {
                    UserID = UserService.CurrentUser.ID,
                    Type = MessagesConstants.Operation.UPDATE,
                    Details = $"{MessagesConstants.Logs.UPDATE_POSITION}{data.ID}."
                });
                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        // HISTORY-RELATED

        public static async Task<List<Models.Position.History>> GetHistories(int? EmployeeID = null, string? Status = null)
        {
            List<Models.Position.History> histories = new();

            try
            {
                using var context = new Context();

                var query = context.EmployeePositionHistory.AsQueryable();

                if (EmployeeID != null)
                {
                    query = query.Where(w => w.EmployeeID == EmployeeID);
                }

                if (Status != null) 
                {
                    query = query.Where(w => w.Status == Status);
                }

                histories = await query.ToListAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return histories;
        }

        public static async Task<List<Models.Position.HistoryView>> GetHistoriesWithView(int ClientID, int EmployeeID)
        {
            List<Models.Position.HistoryView> histories = new();

            try
            {
                using var context = new Context();

                histories = await context.EmployeePositionHistory
                    .Where(w => w.EmployeeID == EmployeeID)
                    .Select(s => new Models.Position.HistoryView
                    {
                        PositionID = s.PositionID,
                        PositionTitle = s.PositionTitle,
                        WageType = s.WageType,
                        DailySalaryRate = s.DailySalaryRate,
                        DailyBillingRate = s.DailyBillingRate,
                        MonthlySalaryRate = s.MonthlySalaryRate,
                        MonthlyBillingRate = s.MonthlyBillingRate,
                        EffectiveDate = s.Timestamp.ToString(StringConstants.Date.DEFAULT),
                        Status = s.Status,
                        Remarks = s.Remarks
                    })
                    .ToListAsync();

                var allPositions = await GetItems(ClientID);

                foreach (var history in histories)
                {
                    var activePosition = allPositions.First(f => f.ID == history.PositionID);

                    history.PositionName = $"{activePosition.Code} - {Utilities.StringFormat.ToSentenceCase(activePosition.Name)}";
                    history.DailySalaryRate = (history.Status == StringConstants.Status.ACTIVE) ? activePosition.DailySalaryRate : history.DailySalaryRate;
                    history.DailyBillingRate = (history.Status == StringConstants.Status.ACTIVE) ? activePosition.DailyBillingRate : history.DailyBillingRate;
                    history.MonthlySalaryRate = (history.Status == StringConstants.Status.ACTIVE) ? activePosition.MonthlySalaryRate : history.MonthlySalaryRate;
                    history.MonthlyBillingRate = (history.Status == StringConstants.Status.ACTIVE) ? activePosition.MonthlyBillingRate : history.MonthlyBillingRate;
                    history.Indicator = (history.Status == StringConstants.Status.ACTIVE) ? StringConstants.DisplayStatus.RIGHT_ARROW : "";
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return histories;
        }

        public static async void AddRatesHistory(Models.Position.RatesHistory data)
        {
            try
            {
                using var context = new Context();
                context.PositionRatesHistory.Add(data);
                await context.SaveChangesAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }

        public static async Task<List<Models.Position.RatesHistoryView>> GetRatesHistoryByID(int PositionID)
        {
            List<Models.Position.RatesHistoryView> histories = new();

            try
            {
                using var context = new Context();

                histories = await context.PositionRatesHistory
                    .Where(w => w.PositionID == PositionID)
                    .Select(s => new Models.Position.RatesHistoryView
                    {
                        Indicator = "",
                        DailySalaryRate = s.DailySalaryRate,
                        DailyBillingRate = s.DailyBillingRate,
                        MonthlySalaryRate = s.MonthlySalaryRate,
                        MonthlyBillingRate = s.MonthlyBillingRate,
                        Timestamp = s.Timestamp,
                    })
                    .OrderByDescending(h => h.Timestamp)
                    .ToListAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return histories;
        }
    }
}
