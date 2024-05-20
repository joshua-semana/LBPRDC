using Dapper;
using LBPRDC.Source.Config;
using LBPRDC.Source.Data;
using Microsoft.EntityFrameworkCore;
using static LBPRDC.Source.Data.Database;

namespace LBPRDC.Source.Services
{
    internal class PositionService
    {
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

        public static async Task<List<Models.Position.View>> GetAllItemsWithView()
        {
            List<Models.Position.View> items = new();

            try
            {
                using var context = new Context();
                items = await context.Position.Select(s => new Models.Position.View
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

        public static async Task<List<Models.Position>> GetItemsByClientID(int ClientID)
        {
            List<Models.Position> items = new();

            try
            {
                using var context = new Context();
                items = await context.Position
                    .Where(p => p.ClientID == ClientID)
                    .ToListAsync();
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

        // History Entity Framework

        public static async Task<Models.Position.History?> GetEmployeeHistory(int EmployeeID, string Status = StringConstants.Status.ACTIVE)
        {
            Models.Position.History? record = new();

            try
            {
                using var context = new Context();
                record = await context.EmployeePositionHistory
                    .Where(h => h.EmployeeID == EmployeeID && h.Status == Status)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return record;
        }

        public static async Task<List<Models.Position.History>> GetAllEmployeeHistory(int ID)
        {
            List<Models.Position.History> record = new();

            try
            {
                using var context = new Context();
                record = await context.EmployeePositionHistory
                    .Where(h => h.EmployeeID == ID)
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

                    await LoggingService.LogActivity(new()
                    {
                        UserID = UserService.CurrentUser.UserID,
                        ActivityType = MessagesConstants.Logs.TITLE_NEW_CATEGORY,
                        ActivityDetails = $"{MessagesConstants.Logs.NEW_POSITION}{data.Name}"
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
                using var transaction = await context.Database.BeginTransactionAsync();

                try
                {
                    var position = await context.Position.FindAsync(data.ID);

                    if (position == null)
                    {
                        return false;
                    }

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

                    if (UserService.CurrentUser != null)
                    {
                        await LoggingService.LogActivity(new()
                        {
                            UserID = UserService.CurrentUser.UserID,
                            ActivityType = MessagesConstants.UPDATE,
                            ActivityDetails = $"{MessagesConstants.Logs.UPDATE_POSITION}{data.ID}."
                        });
                    }

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

        public class History
        {
            public int HistoryID { get; set; }
            public int EmployeeID { get; set; }
            public int OldPositionID { get; set; }
            public int PositionID { get; set; }
            public string? PositionTitle { get; set; }
            public decimal DailySalaryRate { get; set; }
            public decimal DailyBillingRate { get; set; }
            public decimal MonthlySalaryRate { get; set; }
            public decimal MonthlyBillingRate { get; set; }
            public DateTime? Timestamp { get; set; }
            public string? Remarks { get; set; }
            public string? Status { get; set; }
        }

        public static async void AddNewHistory(Models.Position.HistoryAdditional history)
        {
            try
            {
                using var connection = Database.Connect();

                string QuerySelect = @"
                    SELECT
                        HistoryID
                    FROM
                        EmployeePositionHistory
                    WHERE
                        EmployeeID = @EmployeeID
                    AND
                        Status = @Status";

                List<Models.Position.History> matchingHistory = connection.Query<Models.Position.History>(QuerySelect, new
                {
                    history.EmployeeID,
                    Status = StringConstants.Status.ACTIVE
                }).ToList();

                if (matchingHistory.Count > 0)
                {
                    int historyID = matchingHistory.Select(s => s.HistoryID).First();
                    UpdateStatusToInactiveByID(historyID);
                    UpdateRatesByID(history.OldPositionID, historyID);
                }

                bool isSuccessful = await AddToHistory(history);

                if (!isSuccessful)
                {
                    MessageBox.Show(MessagesConstants.FAILED_HISTORY_ADD, MessagesConstants.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> AddToHistory(Models.Position.History data)
        {
            try
            {
                using var context = new Context();
                context.EmployeePositionHistory.Add(data);
                int affectedRows = await context.SaveChangesAsync();
                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        private static async void UpdateStatusToInactiveByID(int HistoryID)
        {
            try
            {
                using var connection = Database.Connect();

                string QueryUpdate = @"
                    UPDATE EmployeePositionHistory SET
                        Status = @Status
                    WHERE
                        HistoryID = @HistoryID";

                await connection.ExecuteAsync(QueryUpdate, new
                {
                    Status = StringConstants.Status.INACTIVE,
                    HistoryID
                });
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }

        private static async void UpdateRatesByID(int OldPositionID, int HistoryID)
        {
            try
            {
                //TODO: By ClientID ang Get ALl items ng Positions
                var positions = await GetAllItems();
                var CurrentPositionRate = positions.First(f => f.ID == OldPositionID);

                using var connection = Database.Connect();

                string QueryUpdate = @"
                    UPDATE EmployeePositionHistory SET
                        DailySalaryRate = @DailySalaryRate,
                        DailyBillingRate = @DailyBillingRate,
                        MonthlySalaryRate = @MonthlySalaryRate,
                        MonthlyBillingRate = @MonthlyBillingRate
                    WHERE 
                        HistoryID = @HistoryID";

                await connection.ExecuteAsync(QueryUpdate, new
                {
                    CurrentPositionRate.DailySalaryRate,
                    CurrentPositionRate.DailyBillingRate,
                    CurrentPositionRate.MonthlySalaryRate,
                    CurrentPositionRate.MonthlyBillingRate,
                    HistoryID
                });
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }

        public static List<History> GetAllHistory()
        {
            List<History> items = new();

            try
            {
                using var connection = Database.Connect();

                string QuerySelect = "SELECT * FROM EmployeePositionHistory";

                items = connection.Query<History>(QuerySelect).ToList();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }

        public static async Task<List<Models.Position.HistoryView>> GetAllHistoryByID(int ClientID, int EmployeeID)
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
                        PositionName = "",
                        PositionTitle = s.PositionTitle,
                        WageType = s.WageType,
                        DailySalaryRate = s.DailySalaryRate,
                        DailyBillingRate = s.DailyBillingRate,
                        MonthlySalaryRate = s.MonthlySalaryRate,
                        MonthlyBillingRate = s.MonthlyBillingRate,
                        Timestamp = s.Timestamp,
                        Status = s.Status,
                        Remarks = s.Remarks
                    })
                    .ToListAsync();

                var allPositions = await GetItemsByClientID(ClientID);

                foreach (var history in histories)
                {
                    var activePosition = allPositions.First(f => f.ID == history.PositionID);

                    history.PositionName = $"{activePosition.Code} - {Utilities.StringFormat.ToSentenceCase(activePosition.Name)}";
                    history.DailySalaryRate = (history.Status == StringConstants.Status.ACTIVE) ? activePosition.DailySalaryRate : history.DailySalaryRate;
                    history.DailyBillingRate = (history.Status == StringConstants.Status.ACTIVE) ? activePosition.DailyBillingRate : history.DailyBillingRate;
                    history.MonthlySalaryRate = (history.Status == StringConstants.Status.ACTIVE) ? activePosition.MonthlySalaryRate : history.MonthlySalaryRate;
                    history.MonthlyBillingRate = (history.Status == StringConstants.Status.ACTIVE) ? activePosition.MonthlyBillingRate : history.MonthlyBillingRate;
                    history.EffectiveDate = history.Timestamp.ToString(StringConstants.Date.DEFAULT);
                    history.Indicator = (history.Status == StringConstants.Status.ACTIVE) ? StringConstants.DisplayStatus.RIGHT_ARROW : "";
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return histories;
        }

        public static async Task RemoveHistoryByEmployeeID(int EmployeeID)
        {
            try
            {
                using var context = new Context();
                var historiesToRemove = await context.EmployeePositionHistory
                    .Where(h => h.EmployeeID == EmployeeID)
                    .ToListAsync();

                if (historiesToRemove.Any())
                {
                    context.EmployeePositionHistory.RemoveRange(historiesToRemove);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
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
