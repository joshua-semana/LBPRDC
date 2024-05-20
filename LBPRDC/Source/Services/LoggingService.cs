using System.Data.SqlClient;

namespace LBPRDC.Source.Services
{
    internal class LoggingService
    {
        public class Log
        {
            public int LogID { get; set; }
            public int UserID { get; set; }
            public string ActivityType { get; set; } = "";
            public string ActivityDetails { get; set; } = "";
            public DateTime? Timestamp { get; set; } = DateTime.Now;
            public string FullName { get; set; } = "";
        }

        public static async Task LogActivity(Log log)
        {
            try
            {
                string query = "INSERT INTO AuditLogs (UserID, ActivityType, ActivityDetails, Timestamp) " +
                               "VALUES (@UserID, @ActivityType, @ActivityDetails, @Timestamp)";

                using (SqlConnection connection = new SqlConnection(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", log.UserID);
                    command.Parameters.AddWithValue("@ActivityType", log.ActivityType);
                    command.Parameters.AddWithValue("@ActivityDetails", log.ActivityDetails);
                    command.Parameters.AddWithValue("@Timestamp", DateTime.Now);

                    connection.Open();

                    await command.ExecuteNonQueryAsync();
                };
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }

        public static async Task<List<Log>> GetAllItems()
        {
            List<Log> items = new();

            try
            {
                string query = "SELECT * FROM AuditLogs";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Log item = new()
                        {
                            LogID = reader["LogID"] as int? ?? 0,
                            UserID = reader["UserID"] as int? ?? 0,
                            ActivityType = reader["ActivityType"] as string,
                            ActivityDetails = reader["ActivityDetails"] as string,
                            Timestamp = reader["Timestamp"] as DateTime?
                        };

                        var users = await UserService.GetUsers(item.UserID);

                        if (users != null)
                        {
                            var currentUser = users.First();
                            item.FullName = $"{currentUser.FirstName} {currentUser.LastName}";
                        }

                        items.Add(item);
                    }
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }

        public static (List<Log> Items, int TotalCount) GetFilteredItems(List<string> activityTypes, string searchWord, DateTime? filterDate)
        {
            List<Log> items = new();
            int totalCount = 0;

            try
            {
                string query = "SELECT AuditLogs.*, Users.FirstName, Users.LastName " +
                               "FROM AuditLogs " +
                               "INNER JOIN Users " +
                               "ON AuditLogs.UserID = Users.UserID " +
                               "WHERE 1 = 1";
                string queryCount = "SELECT COUNT(*) FROM AuditLogs";

                if (activityTypes != null && activityTypes.Count > 0)
                {
                    string activityTypeFilter = string.Join(",", activityTypes.Select(type => $"'{type}'"));
                    query += $" AND AuditLogs.ActivityType IN ({activityTypeFilter})";
                }

                if (!string.IsNullOrEmpty(searchWord))
                {
                    query += $" AND (AuditLogs.ActivityDetails LIKE '%{searchWord}%'" +
                             $" OR Users.FirstName + ' ' + Users.LastName LIKE '%{searchWord}%')";
                }

                if (filterDate.HasValue)
                {
                    query += $" AND FORMAT(AuditLogs.Timestamp, 'yyyy-MM-dd') = @Date";
                }

                query += " ORDER BY Timestamp DESC";

                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                {
                    connection.Open();

                    using (SqlCommand commandCount = new(queryCount, connection))
                    {
                        totalCount = (int)commandCount.ExecuteScalar();
                    }

                    using (SqlCommand command = new(query, connection))
                    {
                        if (filterDate.HasValue)
                        {
                            command.Parameters.AddWithValue("@Date", filterDate.Value.Date);
                        }

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Log item = new()
                            {
                                LogID = reader["LogID"] as int? ?? 0,
                                UserID = reader["UserID"] as int? ?? 0,
                                ActivityType = reader["ActivityType"] as string,
                                ActivityDetails = reader["ActivityDetails"] as string,
                                Timestamp = reader["Timestamp"] as DateTime?,
                                FullName = $"{reader["FirstName"]} {reader["LastName"]}"
                            };

                            items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return (items, totalCount);
        }
    }
}
