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
        public static void LogActivity(int userID, string activityType, string activityDetails)
        {
            try
            {
                string query = "INSERT INTO AuditLogs (UserID, ActivityType, ActivityDetails, Timestamp) " +
                               "VALUES (@UserID, @ActivityType, @ActivityDetails, @Timestamp)";

                using (SqlConnection connection = new SqlConnection(Data.DataAccessHelper.GetConnectionString()))

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@ActivityType", activityType);
                    command.Parameters.AddWithValue("@ActivityDetails", activityDetails);
                    command.Parameters.AddWithValue("@Timestamp", DateTime.Now);

                    connection.Open();

                    command.ExecuteNonQuery();
                };
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }
    }
}
