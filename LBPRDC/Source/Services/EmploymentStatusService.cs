using Dapper;
using LBPRDC.Source.Config;
using LBPRDC.Source.Data;
using Microsoft.EntityFrameworkCore;
using static LBPRDC.Source.Data.Database;

namespace LBPRDC.Source.Services
{
    public class EmploymentStatusService
    {
        public class EmploymentStatus
        {
            public int ID { get; set; }
            public string? Name { get; set; }
            public string? Status { get; set; }
            public string? Description { get; set; }
        }

        // ENTITY FRAMEWORK
        public static async Task RemoveHistoryByEmployeeID(int EmployeeID)
        {
            try
            {
                using var context = new Context();
                var historiesToRemove = await context.EmployeeEmploymentHistory
                    .Where(h => h.EmployeeID == EmployeeID)
                    .ToListAsync();

                if (historiesToRemove.Any())
                {
                    context.EmployeeEmploymentHistory.RemoveRange(historiesToRemove);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
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












        public static List<EmploymentStatus> GetAllItems()
        {
            List<EmploymentStatus> items = new();

            try
            {
                using var connection = Database.Connect();
                string QuerySelect = "SELECT * FROM EmploymentStatus";
                items = connection.Query<EmploymentStatus>(QuerySelect).ToList();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }

        public static List<EmploymentStatus> GetAllItemsByStatus(string Status)
        {
            List<EmploymentStatus> items = new();

            try
            {
                using var connection = Database.Connect();
                string QuerySelect = @"
                    SELECT 
                        * 
                    FROM 
                        EmploymentStatus
                    WHERE
                        Status = @Status";
                items = connection.Query<EmploymentStatus>(QuerySelect, new
                {
                    Status
                }).ToList();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }

        public static List<EmploymentStatus> GetAllItemsForComboBox()
        {
            List<EmploymentStatus> items = new();

            try
            {
                items.Add(new EmploymentStatus
                {
                    ID = 0,
                    Name = StringConstants.ComboBox.DEFAULT_EMPLOYMENT_STATUS
                });

                using var connection = Database.Connect();
                string QuerySelect = "SELECT ID, Name FROM EmploymentStatus WHERE Status = @Status";

                var result = connection.Query<EmploymentStatus>(QuerySelect, new
                {
                    Status = StringConstants.Status.ACTIVE
                }).ToList();

                items.AddRange(result);
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }

        public static List<string> GetExistenceByID(int employmentStatusID)
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
                    $"SELECT DISTINCT '{name}' AS TableName FROM {name} WHERE EmploymentStatusID = @EmploymentStatusID"
                ).ToList();

                QueryCheckExistense = string.Join(" UNION ALL ", selectQueries);

                databaseTableNames = connection.Query<string>(QueryCheckExistense, new
                {
                    EmploymentStatusID = employmentStatusID
                }).ToList();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return databaseTableNames;
        }

        public static async Task <bool> Add(EmploymentStatus data)
        {
            try
            {
                using var connection = Database.Connect();

                string QueryUpdate = @"
                    INSERT INTO EmploymentStatus (
                        Name, 
                        Description, 
                        Status
                    ) VALUES (
                        @Name, 
                        @Description, 
                        @Status
                    )";

                int affectedRows = await connection.ExecuteAsync(QueryUpdate, new
                {
                    data.Name,
                    data.Description,
                    data.Status
                });

                if (UserService.CurrentUser != null)
                {
                    LoggingService.LogActivity(new()
                    {
                        UserID = UserService.CurrentUser.UserID,
                        ActivityType = MessagesConstants.Add.TITLE,
                        ActivityDetails = $"This user added a new item for the employment status category with a name of {data.Name}."
                    });
                }
                else
                {
                    return false;
                }

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
                            ActivityDetails = $"This user updated an item under the employment status category with an ID of {data.ID}."
                        });
                    }
                }
                
                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        private static bool AreEqual(Models.EmploymentStatus item1, Models.EmploymentStatus item2)
        {
            return item1.Name == item2.Name &&
                   item1.Description == item2.Description &&
                   item1.Status == item2.Status;
        }

        public class History
        {
            public int HistoryID { get; set; }
            public int EmployeeID { get; set; }
            public int EmploymentStatusID { get; set; }
            public DateTime? Timestamp { get; set; }
            public string? Remarks { get; set; }
            public string? Status { get; set; }
        }

        public class HistoryUpdate
        {
            public int HistoryID { get; set; }
            public int EmploymentStatusID { get; set; }
            public DateTime? Timestamp { get; set; }
        }

        public class HistoryView : History
        {
            public string? Name { get; set; }
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
                        EmployeeEmploymentHistory
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
                }

                bool isSuccessful = await AddToHistory(history);

                if (!isSuccessful)
                {
                    MessageBox.Show("Unable to add a history for civil status of this specific individual.");
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
                    string QuerySelect = @"
                        INSERT INTO EmployeeEmploymentHistory (
                            EmployeeID,
                            EmploymentStatusID,
                            Timestamp,
                            Remarks,
                            Status
                        ) VALUES (
                            @EmployeeID,
                            @EmploymentStatusID,
                            @Timestamp,
                            @Remarks,
                            @Status
                        )";

                    int affectedRows = await connection.ExecuteAsync(QuerySelect, history, transaction);

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
                    UPDATE EmployeeEmploymentHistory SET 
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

        public static List<History> GetAllHistory()
        {
            List<History> items = new();

            try
            {
                using var connection = Database.Connect();

                string QuerySelect = "SELECT * FROM EmployeeEmploymentHistory";

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
                    UPDATE EmployeeEmploymentHistory SET
                        EmploymentStatusID = @EmploymentStatusID,
                        TimeStamp = @TimeStamp
                    WHERE 
                        HistoryID = @HistoryID";

                await connection.ExecuteAsync(QueryUpdate, data);
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }

        public static List<HistoryView> GetAllHistoryByID(int EmployeeID)
        {
            List<HistoryView> items = new();

            try
            {
                using var connection = Database.Connect();

                string QuerySelect = @"
                    SELECT 
                        * 
                    FROM 
                        EmployeeEmploymentHistory 
                    WHERE 
                        EmployeeID = @EmployeeID";

                items = connection.Query<HistoryView>(QuerySelect, new
                {
                    EmployeeID
                }).ToList();

                var allItems = GetAllItems();

                foreach (var item in items)
                {
                    var currentItem = allItems.First(f => f.ID == item.EmploymentStatusID);
                    item.Name = Utilities.StringFormat.ToSentenceCase(currentItem.Name);
                    item.EffectiveDate = item.Timestamp?.ToString(StringConstants.Date.DEFAULT);
                    item.StatusName = (item.Status == StringConstants.Status.ACTIVE) ? StringConstants.DisplayStatus.CURRENT : StringConstants.DisplayStatus.OLD;
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }
    }
}
