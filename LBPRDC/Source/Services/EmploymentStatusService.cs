using Dapper;
using LBPRDC.Source.Data;
using System.Data.SqlClient;

namespace LBPRDC.Source.Services
{
    internal class EmploymentStatusService
    {
        public class EmploymentStatus
        {
            public int ID { get; set; }
            public string? Name { get; set; }
            public string? Status { get; set; }
            public string? Description { get; set; }
        }

        public static List<EmploymentStatus> GetAllItems()
        {
            List<EmploymentStatus> items = new();

            try
            {
                string query = "SELECT * FROM EmploymentStatus";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        EmploymentStatus item = new()
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Name = reader["Name"].ToString(),
                            Description = reader["Description"].ToString(),
                            Status = reader["Status"].ToString()
                        };

                        items.Add(item);
                    }
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }

        public static List<EmploymentStatus> GetAllItemsByStatus(string status)
        {
            List<EmploymentStatus> items = new();

            try
            {
                using var connection = Database.Connect();
                string QuerySelect = "SELECT * FROM EmploymentStatus WHERE Status = @Status";
                items = connection.Query<EmploymentStatus>(QuerySelect, new
                {
                    Status = status
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
                EmploymentStatus blankItem = new()
                {
                    ID = 0,
                    Name = "(Choose Status)"
                };

                items.Add(blankItem);

                string query = "SELECT ID, Name FROM EmploymentStatus WHERE Status = 'Active'";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        EmploymentStatus item = new()
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
                string QueryUpdate = "INSERT INTO EmploymentStatus (Name, Description, Status) " +
                    "VALUES (@Name, @Description, @Status)";

                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(QueryUpdate, connection))
                {
                    command.Parameters.AddWithValue("@Name", data.Name);
                    command.Parameters.AddWithValue("@Description", data.Description);
                    command.Parameters.AddWithValue("@Status", data.Status);
                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }

                if (UserService.CurrentUser != null)
                {
                    LoggingService.Log newLog = new()
                    {
                        UserID = UserService.CurrentUser.UserID,
                        ActivityType = "Add",
                        ActivityDetails = $"This user added a new item for the employment status category with a name of {data.Name}."
                    };

                    LoggingService.LogActivity(newLog);
                }

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static void Update(EmploymentStatus data)
        {
            try
            {
                string QueryUpdate = "UPDATE EmploymentStatus SET " +
                    "Name = @Name, " +
                    "Description = @Description, " +
                    "Status = @Status " +
                    "WHERE ID = @ID";

                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(QueryUpdate, connection))
                {
                    command.Parameters.AddWithValue("@Name", data.Name);
                    command.Parameters.AddWithValue("@Description", data.Description);
                    command.Parameters.AddWithValue("@Status", data.Status);
                    command.Parameters.AddWithValue("@ID", data.ID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }

                if (UserService.CurrentUser != null)
                {
                    LoggingService.Log newLog = new()
                    {
                        UserID = UserService.CurrentUser.UserID,
                        ActivityType = "Update",
                        ActivityDetails = $"This user updated an item under the employment status category with an ID of {data.ID}."
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

        private static void UpdateStatusToInactiveByID(int historyID)
        {
            try
            {
                string updateQuery = "UPDATE EmployeeEmploymentHistory SET Status = @Status WHERE HistoryID = @HistoryID";
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
                string query = "SELECT * FROM EmployeeEmploymentHistory";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        History item = new()
                        {
                            HistoryID = Convert.ToInt32(reader["HistoryID"]),
                            EmployeeID = reader["EmployeeID"].ToString(),
                            EmploymentStatusID = Convert.ToInt32(reader["EmploymentStatusID"]),
                            Timestamp = reader["Timestamp"] as DateTime?,
                            Remarks = reader["Remarks"].ToString(),
                            Status = reader["Status"].ToString()
                        };

                        items.Add(item);
                    }
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }

        public static void UpdateHistory(HistoryUpdate data)
        {
            try
            {
                string updateQuery = "UPDATE EmployeeEmploymentHistory SET " +
                    "EmploymentStatusID = @EmploymentStatusID, " +
                    "Timestamp = @Timestamp " +
                    "WHERE HistoryID = @HistoryID";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@EmploymentStatusID", data.EmploymentStatusID);
                    command.Parameters.AddWithValue("@Timestamp", data.Timestamp);
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
                string query = "SELECT * FROM EmployeeEmploymentHistory WHERE EmployeeID = @EmployeeID";
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
                            EmploymentStatusID = Convert.ToInt32(reader["EmploymentStatusID"]),
                            Timestamp = reader["Timestamp"] as DateTime?,
                            Remarks = reader["Remarks"].ToString(),
                            Status = reader["Status"].ToString()
                        };
                        var employmentStatus = GetAllItems().First(f => f.ID == item.EmploymentStatusID);
                        item.Name = Utilities.StringFormat.ToSentenceCase(employmentStatus.Name);
                        item.EffectiveDate = item.Timestamp.Value.ToString("MMMM dd, yyyy");
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
