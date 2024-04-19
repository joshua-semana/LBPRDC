using Dapper;
using LBPRDC.Source.Config;
using LBPRDC.Source.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Transactions;
using static LBPRDC.Source.Data.Database;

namespace LBPRDC.Source.Services
{
    internal class PositionService
    {
        public class Position
        {
            public int ID { get; set; }
            public int ClientID { get; set; }
            public string? Code { get; set; }
            public string? Name { get; set; }
            public decimal SalaryRate { get; set; }
            public decimal BillingRate { get; set; }
            public string? Status { get; set; }
            public string? Description { get; set; }
        }

        // Entity Framework

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
















        public static List<string> GetExistenceByID(int positionID)
        {
            List<string> databaseTableNames = new();

            try
            {
                using var connection = Connect();

                string QueryCheckExistense = "";
                List<string> tableNames = new()
                {
                    "Employee"
                };

                List<string> selectQueries = tableNames.Select(name =>
                    $"SELECT DISTINCT '{name}' AS TableName FROM {name} WHERE PositionID = @PositionID"
                ).ToList();

                QueryCheckExistense = string.Join(" UNION ALL ", selectQueries);

                databaseTableNames = connection.Query<string>(QueryCheckExistense, new
                {
                    PositionID = positionID
                }).ToList();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return databaseTableNames;
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
                        SalaryRate = data.SalaryRate,
                        BillingRate = data.BillingRate
                    });

                    LoggingService.LogActivity(new()
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

        public static async Task<bool> Update(Position data)
        {
            try
            {
                using var context = new Context();
                using var transaction = await context.Database.BeginTransactionAsync();

                try
                {
                    var existingPosition = await context.Position.FindAsync(data.ID);

                    if (existingPosition == null)
                    {
                        return false;
                    }

                    existingPosition.ClientID = data.ClientID;
                    existingPosition.Code = data.Code;
                    existingPosition.Name = data.Name;
                    existingPosition.SalaryRate = data.SalaryRate;
                    existingPosition.BillingRate = data.BillingRate;
                    existingPosition.Description = data.Description;
                    existingPosition.Status = data.Status;

                    await context.SaveChangesAsync();

                    if (UserService.CurrentUser != null)
                    {
                        LoggingService.LogActivity(new()
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
            public decimal SalaryRate { get; set; }
            public decimal BillingRate { get; set; }
            public DateTime? Timestamp { get; set; }
            public string? Remarks { get; set; }
            public string? Status { get; set; }
        }

        public class HistoryUpdate
        {
            public int HistoryID { get; set; }
            public int PositionID { get; set; }
            public string? PositionTitle { get; set; }
            public DateTime? Timestamp { get; set; }
        }

        public class HistoryView : History
        {
            public string? PositionName { get; set; }
            public string? EffectiveDate { get; set; }
            public string? StatusName { get; set; }
        }

        public static async void AddNewHistory(History history)
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

                List<History> matchingHistory = connection.Query<History>(QuerySelect, new
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

        public static async Task<bool> AddToHistory(History history)
        {
            try
            {
                using var connection = Database.Connect();
                using var transaction = connection?.BeginTransaction();

                try
                {
                    string QueryInsert = @"
                        INSERT INTO EmployeePositionHistory (
                            EmployeeID,
                            PositionID,
                            PositionTitle,
                            SalaryRate,
                            BillingRate,
                            Timestamp,
                            Remarks,
                            Status
                        ) VALUES (
                            @EmployeeID,
                            @PositionID,
                            @PositionTitle,
                            @SalaryRate,
                            @BillingRate,
                            @Timestamp,
                            @Remarks,
                            @Status)";

                    int affectedRows = await connection.ExecuteAsync(QueryInsert, history, transaction);

                    if (affectedRows > 0)
                    {
                        transaction?.Commit();
                    }
                    else
                    {
                        transaction?.Rollback();
                        return false;
                    }
                }
                catch (Exception)
                {
                    transaction?.Rollback();
                    return false;
                }

                return true;
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
                var positions = await GetAllItems();
                var CurrentPositionRate = positions.First(f => f.ID == OldPositionID);

                using var connection = Database.Connect();

                string QueryUpdate = @"
                    UPDATE EmployeePositionHistory SET
                        SalaryRate = @SalaryRate,
                        BillingRate = @BillingRate 
                    WHERE 
                        HistoryID = @HistoryID";

                await connection.ExecuteAsync(QueryUpdate, new
                {
                    CurrentPositionRate.SalaryRate,
                    CurrentPositionRate.BillingRate,
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

        public static async void UpdateHistory(HistoryUpdate data)
        {
            try
            {
                using var connection = Database.Connect();

                string QueryUpdate = @"
                    UPDATE EmployeePositionHistory SET
                        PositionID = @PositionID,
                        PositionTitle = @PositionTitle,
                        Timestamp = @Timestamp
                    WHERE 
                        HistoryID = @HistoryID";

                await connection.ExecuteAsync(QueryUpdate, data);
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }

        public static async Task<List<HistoryView>> GetAllHistoryByID(int EmployeeID)
        {
            List<HistoryView> items = new();

            try
            {
                using var connection = Database.Connect();
                
                string QuerySelect = @"
                    SELECT 
                        * 
                    FROM 
                        EmployeePositionHistory 
                    WHERE 
                        EmployeeID = @EmployeeID";

                items = connection.Query<HistoryView>(QuerySelect, new {
                    EmployeeID
                }).ToList();

                var allItems = await GetAllItems();

                foreach (var item in items)
                {
                    var currentItem = allItems.First(f => f.ID == item.PositionID);
                    item.PositionName = $"{currentItem.Code} - {Utilities.StringFormat.ToSentenceCase(currentItem.Name)}";
                    item.SalaryRate = (item.Status == StringConstants.Status.ACTIVE) ? currentItem.SalaryRate : item.SalaryRate;
                    item.BillingRate = (item.Status == StringConstants.Status.ACTIVE) ? currentItem.BillingRate : item.BillingRate;
                    item.EffectiveDate = item.Timestamp?.ToString(StringConstants.Date.DEFAULT);
                    item.StatusName = (item.Status == StringConstants.Status.ACTIVE) ? StringConstants.DisplayStatus.CURRENT : StringConstants.DisplayStatus.OLD;
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
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


        public class RatesHistory
        {
            public int PositionID { get; set; }
            public decimal SalaryRate { get; set; }
            public decimal BillingRate { get; set; }
        }

        public class RatesHistoryView
        {
            public string? Status { get; set; }
            public decimal SalaryRate { get; set; }
            public decimal BillingRate { get; set; }
            public DateTime Timestamp { get; set; }
        }

        public static async void AddRatesHistory(RatesHistory history)
        {
            try
            {
                using var connection = Database.Connect();

                string QueryInsert = @"
                    INSERT INTO PositionRatesHistory (
                        PositionID, 
                        SalaryRate, 
                        BillingRate, 
                        TimeStamp
                    ) VALUES (
                        @PositionID, 
                        @SalaryRate, 
                        @BillingRate, 
                        @TimeStamp
                    )";

                await connection.ExecuteAsync(QueryInsert, new
                {
                    history.PositionID,
                    history.SalaryRate,
                    history.BillingRate,
                    TimeStamp = DateTime.Now
                });
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }

        public static List<RatesHistoryView> GetRatesHistoryByID(int PositionID)
        {
            List<RatesHistoryView> histories = new();

            try
            {
                using var connection = Database.Connect();

                string QuerySelect = @"
                    SELECT 
                        * 
                    FROM 
                        PositionRatesHistory 
                    WHERE 
                        PositionID = @PositionID 
                    ORDER BY 
                        Timestamp 
                    DESC";

                histories = connection.Query<RatesHistoryView>(QuerySelect, new
                {
                    PositionID
                }).ToList();

                if (histories.Count > 0)
                {
                    histories[0].Status = StringConstants.DisplayStatus.CURRENT;
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return histories;
        }
    }
}
