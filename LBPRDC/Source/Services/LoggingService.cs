using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LBPRDC.Source.Services.DepartmentService;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LBPRDC.Source.Services
{
    internal class LoggingService
    {
        public class Log
        {
            public int LogID { get; set; }
            public int UserID { get; set; }
            public string? ActivityType { get; set; }
            public string? ActivityDetails { get; set; }
            public DateTime? Timestamp { get; set; }
            public string? FullName { get; set; }
        }

        public static void LogActivity(Log log)
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

                    command.ExecuteNonQuery();
                };
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }

        public static List<Log> GetAllItems()
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

                        var users = UserService.GetAllUsers();
                        var currentUser = users.First(f => f.UserID == item.UserID);

                        item.FullName = $"{currentUser.FirstName} {currentUser.LastName}";
                        items.Add(item);
                    }
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }
    }
}
