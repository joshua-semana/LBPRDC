using Dapper;
using LBPRDC.Source.Data;
using System.Data.SqlClient;
using System.Transactions;
using static LBPRDC.Source.Services.PositionService;

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

        public static List<Department> GetAllItems()
        {
            List<Department> items = new();

            try
            {
                using var connection = Database.Connect();
                string QuerySelect = "SELECT * FROM Departments";
                items = connection.Query<Department>(QuerySelect).ToList();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }

        public static List<Department> GetAllItemsByStatus(string status)
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
                        Status = @Status";
                items = connection.Query<Department>(QuerySelect, new
                {
                    Status = status
                }).ToList();
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

        public static List<Department> GetAllItemsForComboBox()
        {
            List<Department> items = new();

            try
            {
                Department blankItem = new()
                {
                    ID = 0,
                    Name = "(Choose Department)"
                };

                items.Add(blankItem);

                string query = "SELECT ID, Name FROM Departments WHERE Status = 'Active'";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Department item = new()
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Name = reader["Name"].ToString()
                        };

                        items.Add(item);
                    }
                }
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
                    $"SELECT DISTINCT '{name}' AS TableName FROM {name} WHERE DepartmentID = @DepartmentID"
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
                        Type = "DEFAULT",
                        Status = data.Status,
                        DepartmentID = newInsertedID
                    });

                    if (newInsertedID > 0)
                    {
                        LoggingService.LogActivity(new()
                        {
                            UserID = UserService.CurrentUser.UserID,
                            ActivityType = "Add",
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

        public static void Update(Department data)
        {
            try
            {
                using var connection = Database.Connect();

                string QueryUpdate = @"
                    UPDATE Departments SET
                        ClientID = @ClientID,
                        Code = @Code,
                        Name = @Name,
                        Description = @Description,
                        Status = @Status
                    WHERE
                        ID = @ID";

                connection.Execute(QueryUpdate, data);

                if (UserService.CurrentUser != null)
                {
                    LoggingService.Log newLog = new()
                    {
                        UserID = UserService.CurrentUser.UserID,
                        ActivityType = "Update",
                        ActivityDetails = $"This user updated an item under the department category with an ID of {data.ID}."
                    };

                    LoggingService.LogActivity(newLog);
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }

        public class History
        {
            public int HistoryID { get; set; }
            public string? EmployeeID { get; set; }
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
            public string? StatusName { get; internal set; }
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
                    Status = "Active"
                }).ToList();

                if (matchingHistory.Count > 0)
                {
                    int historyID = matchingHistory.Select(s => s.HistoryID).First();
                    UpdateStatusToInactiveByID(historyID);
                }

                bool isSuccessful = await AddToHistory(history);

                if (!isSuccessful)
                {
                    MessageBox.Show("Unable to add a history for department and location of this specific individual.");
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

        private static void UpdateStatusToInactiveByID(int historyID)
        {
            try
            {
                string updateQuery = "UPDATE EmployeeDepartmentLocationHistory SET Status = @Status WHERE HistoryID = @HistoryID";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Status", "Inactive");
                    command.Parameters.AddWithValue("@HistoryID", historyID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
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

        public static void UpdateHistory(HistoryUpdate data)
        {
            try
            {
                string updateQuery = "UPDATE EmployeeDepartmentLocationHistory SET " +
                    "DepartmentName = @DepartmentName, " +
                    "LocationName = @LocationName " +
                    "WHERE HistoryID = @HistoryID";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@DepartmentName", data.DepartmentName);
                    command.Parameters.AddWithValue("@LocationName", data.LocationName);
                    command.Parameters.AddWithValue("@HistoryID", data.HistoryID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }

        public static List<HistoryView> GetAllHistoryByID(string employeeId)
        {
            List<HistoryView> items = new();

            try
            {
                string query = "SELECT * FROM EmployeeDepartmentLocationHistory WHERE EmployeeID = @EmployeeID";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employeeId);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        HistoryView item = new()
                        {
                            HistoryID = Convert.ToInt32(reader["HistoryID"]),
                            EmployeeID = reader["EmployeeID"].ToString(),
                            DepartmentName = Convert.ToString(reader["DepartmentName"]) ?? "",
                            LocationName = Convert.ToString(reader["LocationName"]) ?? "",
                            Timestamp = Convert.ToDateTime(reader["Timestamp"]),
                            Remarks = reader["Remarks"].ToString(),
                            Status = reader["Status"].ToString()
                        };
                        item.EffectiveDate = item.Timestamp.ToString("MMMM dd, yyyy");
                        item.StatusName = (item.Status == "Active") ? "Current" : "Old";
                        items.Add(item);
                    }
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }
    }
}
