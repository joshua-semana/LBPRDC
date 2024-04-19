using Dapper;
using LBPRDC.Source.Config;
using LBPRDC.Source.Data;
using Microsoft.EntityFrameworkCore;
using static LBPRDC.Source.Data.Database;

namespace LBPRDC.Source.Services
{
    internal class DepartmentService
    {
        public class Department
        {
            public int ID { get; set; }
            public int ClientID { get; set; }
            public string? Code { get; set; }
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
                var historiesToRemove = await context.EmployeeDepartmentLocationHistory
                    .Where(h => h.EmployeeID == EmployeeID)
                    .ToListAsync();

                if (historiesToRemove.Any())
                {
                    context.EmployeeDepartmentLocationHistory.RemoveRange(historiesToRemove);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }

        public static async Task<List<Models.Department>> GetAllItems()
        {
            List<Models.Department> items = new();

            try
            {
                using var context = new Context();
                items = await context.Departments.ToListAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }

        public static async Task<List<Models.Department>> GetAllItemsForComboBox(bool WithDefault = true)
        {
            List<Models.Department> items = new();

            try
            {
                if (WithDefault)
                {
                    items.Add(new Models.Department
                    {
                        ID = 0,
                        Name = StringConstants.ComboBox.DEFAULT_DEPARTMENT
                    });
                }

                using var context = new Context();

                var result = await context.Departments
                    .Where(d => d.Status.Equals(StringConstants.Status.ACTIVE))
                    .Select(d => new Models.Department()
                    {
                        ID = d.ID,
                        Name = d.Name,
                    })
                    .ToListAsync();

                items.AddRange(result);
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }

        public static async Task<List<Models.Department>> GetItemsByClientID(int ClientID)
        {
            List<Models.Department> items = new();

            try
            {
                using var context = new Context();
                items = await context.Departments
                    .Where(p => p.ClientID == ClientID)
                    .ToListAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }















        public static List<Department> GetAllItemsByStatusAndClientID(string status, int clientID)
        {
            List<Department> items = new();

            try
            {
                using var connection = Database.Connect();
                string QuerySelect = @"
                    SELECT 
                        * 
                    FROM 
                        Departments
                    WHERE
                        Status = @Status 
                    AND 
                        ClientID = @ClientID";
                items = connection.Query<Department>(QuerySelect, new
                {
                    Status = status,
                    ClientID = clientID
                }).ToList();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }

        public static async Task<List<Models.Department>> GetAllItemsForComboBoxByClientID(int ClientID = 0, bool WithDefault = true)
        {
            List<Models.Department> items = new();

            try
            {
                if (WithDefault)
                {
                    items.Add(new Models.Department
                    {
                        ID = 0,
                        Name = StringConstants.ComboBox.DEFAULT_DEPARTMENT
                    });
                }

                using var context = new Context();

                var result = await context.Departments
                    .Where(d => 
                        d.Status.Equals(StringConstants.Status.ACTIVE) &&
                        d.ClientID.Equals(ClientID))
                    .Select(d => new Models.Department()
                    {
                        ID = d.ID,
                        Name = d.Name,
                    })
                    .ToListAsync();

                items.AddRange(result);
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }

        public static List<string> GetExistenceByID(int departmentID)
        {
            List<string> databaseTableNames = new();

            try
            {
                using var connection = Database.Connect();

                string QueryCheckExistense = "";
                List<string> tableNames = new()
                {
                    "Employee",
                    "Locations"
                };

                List<string> selectQueries = tableNames.Select(name =>
                    $"SELECT '{name}' AS TableName FROM {name} WHERE DepartmentID = @DepartmentID"
                ).ToList();

                QueryCheckExistense = string.Join(" UNION ALL ", selectQueries);

                databaseTableNames = connection.Query<string>(QueryCheckExistense, new
                {
                    DepartmentID = departmentID
                }).ToList();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return databaseTableNames;
        }

        public static async Task<bool> Add(Department data)
        {
            try
            {
                using var connection = Database.Connect();
                using var transaction = connection?.BeginTransaction();

                try
                {
                    string QueryUpdate = @"
                    INSERT INTO Departments (
                        Code,
                        ClientID,
                        Name, 
                        Description, 
                        Status
                    ) VALUES (
                        @Code,
                        @ClientID,
                        @Name, 
                        @Description, 
                        @Status
                    );

                    SELECT SCOPE_IDENTITY();";

                    int newInsertedID = await connection.ExecuteScalarAsync<int>(QueryUpdate, data, transaction);
                    transaction?.Commit();

                    await LocationService.Add(new LocationService.Location
                    {
                        Name = "None",
                        Description = $"Default none value for '{data.Name}' department.",
                        Type = StringConstants.Type.DEFAULT,
                        Status = data.Status,
                        DepartmentID = newInsertedID
                    });

                    if (newInsertedID > 0)
                    {
                        LoggingService.LogActivity(new()
                        {
                            UserID = UserService.CurrentUser.UserID,
                            ActivityType = MessagesConstants.Add.TITLE,
                            ActivityDetails = $"This user added a new item for the department category with a name of {data.Name}."
                        });
                    }

                    return true;
                }
                catch (Exception)
                {
                    transaction?.Rollback();
                    return false;
                }
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> Update(Models.Department data)
        {
            try
            {
                using var context = new Context();

                var item = await context.Departments.FindAsync(data.ID);

                if (item == null) { return false; }
                if (AreEqual(item, data)) { return true; }

                item.ClientID = data.ClientID;
                item.Code = data.Code;
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
                            ActivityDetails = $"This user updated an item under the department category with an ID of {data.ID}."
                        });
                    }
                }

                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        private static bool AreEqual(Models.Department item1, Models.Department item2)
        {
            return item1.ClientID == item2.ClientID &&
                   item1.Code == item2.Code &&
                   item1.Name == item2.Name &&
                   item1.Description == item2.Description &&
                   item1.Status == item2.Status;
        }

        public class History
        {
            public int HistoryID { get; set; }
            public int EmployeeID { get; set; }
            public int DepartmentID { get; set; }
            public int LocationID { get; set; }
            public string DepartmentName { get; set; } = "";
            public string LocationName { get; set; } = "";
            public DateTime Timestamp { get; set; } = DateTime.MinValue;
            public string? Remarks { get; set; }
            public string? Status { get; set; }
        }

        public class HistoryUpdate
        {
            public int HistoryID { get; set; }
            public string DepartmentName { get; set; } = "";
            public string LocationName { get; set; } = "";
        }

        public class HistoryView : History
        {
            public string EffectiveDate { get; set; } = "";
            public string StatusName { get; internal set; } = "";
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
                        EmployeeDepartmentLocationHistory
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
                    string QuerySelect = @"
                        INSERT INTO EmployeeDepartmentLocationHistory (
                            EmployeeID,
                            DepartmentName,
                            LocationName,
                            Timestamp,
                            Remarks,
                            Status
                        ) VALUES (
                            @EmployeeID,
                            @DepartmentName,
                            @LocationName,
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
                    UPDATE EmployeeDepartmentLocationHistory SET 
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

                string QuerySelect = "SELECT * FROM EmployeeDepartmentLocationHistory";

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
                    UPDATE EmployeeDepartmentLocationHistory SET
                        DepartmentName = @DepartmentName,
                        LocationName = @LocationName
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
                        EmployeeDepartmentLocationHistory 
                    WHERE 
                        EmployeeID = @EmployeeID";

                items = connection.Query<HistoryView>(QuerySelect, new
                {
                    EmployeeID
                }).ToList();

                foreach (var item in items)
                {
                    item.EffectiveDate = item.Timestamp.ToString(StringConstants.Date.DEFAULT);
                    item.StatusName = (item.Status == StringConstants.Status.ACTIVE) ? StringConstants.DisplayStatus.CURRENT : StringConstants.DisplayStatus.OLD;
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }
    }
}
