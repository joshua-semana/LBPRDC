using System.Data.SqlClient;
using static LBPRDC.Source.Services.EmployeeService;

namespace LBPRDC.Source.Services
{
    internal class CivilStatusService
    {
        public class CivilStatus
        {
            public int ID { get; set; }
            public string? Name { get; set; }
            public string? Status { get; set; }
            public string? Description { get; set; }
        }

        public static List<CivilStatus> GetAllItems()
        {
            List<CivilStatus> items = new();

            try
            {
                string query = "SELECT * FROM CivilStatus";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        CivilStatus item = new()
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

        public static List<CivilStatus> GetAllItemsForComboBox()
        {
            List<CivilStatus> items = new();

            try
            {
                CivilStatus blankItem = new()
                {
                    ID = 0,
                    Name = "(Choose Status)"
                };

                items.Add(blankItem);

                string query = "SELECT ID, Name FROM CivilStatus WHERE Status = 'Active'";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        CivilStatus item = new()
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

        public static async Task<bool> Add(CivilStatus data)
        {
            try
            {
                string QueryUpdate = "INSERT INTO CivilStatus (Name, Description, Status) " +
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
                        ActivityDetails = $"This user added a new item for the civil status category with a name of {data.Name}."
                    };

                    LoggingService.LogActivity(newLog);
                }

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static void Update(CivilStatus data)
        {
            try
            {
                string QueryUpdate = "UPDATE CivilStatus SET " +
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
                        ActivityDetails = $"This user updated an item under the civil status category with an ID of {data.ID}."
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
            public int CivilStatusID { get; set; }
            public DateTime? Timestamp { get; set; }
            public string? Remarks { get; set; }
            public string? Status { get; set; }
        }

        public class HistoryUpdate
        {
            public int HistoryID { get; set; }
            public int CivilStatusID { get; set; }
        }

        public class HistoryView : History
        {
            public string? CivilStatusName { get; set; }
            public string? EffectiveDate { get; set; }
            public string? StatusName { get; set; }
        }

        public static void AddNewHistory(History history)
        {
            try
            {
                string query = "SELECT HistoryID FROM EmployeeCivilStatusHistory WHERE EmployeeID = @EmployeeID AND Status = 'Active'";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", history.EmployeeID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int historyID = Convert.ToInt32(reader["HistoryID"]);
                            UpdateStatusToInactiveByID(historyID);
                        }
                        AddToHistory(history);
                    }
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }

        public static void AddToHistory(History history)
        {
            try
            {
                string query = "INSERT INTO EmployeeCivilStatusHistory (EmployeeID, CivilStatusID, Timestamp, Remarks, Status)" +
                    "VALUES (@EmployeeID, @CivilStatusID, @Timestamp, @Remarks, @Status)";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", history.EmployeeID);
                    command.Parameters.AddWithValue("@CivilStatusID", history.CivilStatusID);
                    command.Parameters.AddWithValue("@Timestamp", history.Timestamp);
                    command.Parameters.AddWithValue("@Remarks", history.Remarks);
                    command.Parameters.AddWithValue("@Status", history.Status);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }

        private static void UpdateStatusToInactiveByID(int historyID)
        {
            try
            {
                string updateQuery = "UPDATE EmployeeCivilStatusHistory SET Status = @Status WHERE HistoryID = @HistoryID";
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
                string query = "SELECT * FROM EmployeeCivilStatusHistory";
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
                            CivilStatusID = Convert.ToInt32(reader["CivilStatusID"]),
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
                string updateQuery = "UPDATE EmployeeCivilStatusHistory SET " +
                    "CivilStatusID = @CivilStatusID " +
                    "WHERE HistoryID = @HistoryID";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@CivilStatusID", data.CivilStatusID);
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
                string query = "SELECT * FROM EmployeeCivilStatusHistory WHERE EmployeeID = @EmployeeID";
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
                            CivilStatusID = Convert.ToInt32(reader["CivilStatusID"]),
                            Timestamp = reader["Timestamp"] as DateTime?,
                            Remarks = reader["Remarks"].ToString(),
                            Status = reader["Status"].ToString()
                        };
                        var civilstatus = GetAllItems().First(f => f.ID == item.CivilStatusID);
                        item.CivilStatusName = Utilities.StringFormat.ToSentenceCase(civilstatus.Name);
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
