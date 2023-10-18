using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBPRDC.Source.Services
{
    internal class LoggingService
    {
        public class Log
        {
            public int UserID { get; set; }
            public string? Type { get; set; }
            public string? Details { get; set; }
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
                    command.Parameters.AddWithValue("@ActivityType", log.Type);
                    command.Parameters.AddWithValue("@ActivityDetails", log.Details);
                    command.Parameters.AddWithValue("@Timestamp", DateTime.Now);

                    connection.Open();

                    command.ExecuteNonQuery();
                };
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }
    }
}
