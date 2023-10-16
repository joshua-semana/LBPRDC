using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LBPRDC.Source.Services.CivilStatusService;

namespace LBPRDC.Source.Services
{
    internal class EmploymentStatusService
    {
        public class EmploymentStatusItems
        {
            public int ID { get; set; }
            public string? Status { get; set; }
        }

        public static List<EmploymentStatusItems> GetEmploymentStatusItems()
        {
            List<EmploymentStatusItems> items = new();

            try
            {
                EmploymentStatusItems blankItem = new()
                {
                    ID = 0,
                    Status = "(Choose Status)"
                };
                items.Add(blankItem);

                string query = "SELECT ID, Status FROM EmploymentStatus";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        EmploymentStatusItems item = new()
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Status = reader["Status"].ToString()
                        };

                        items.Add(item);
                    }
                }
            } 
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }

            return items;
        }

        public static string? GetStatusByID(int id)
        {
            string result = string.Empty;

            try
            {
                string query = "SELECT Status FROM EmploymentStatus WHERE ID = @ID";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result = reader["Status"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }

            return result;
        }

        public class NewHistory
        {
            public string? EmployeeID { get; set; }
            public int EmploymentStatusID { get; set; }
            public DateTime? Timestamp { get; set; }
            public string? Remarks { get; set; }
        }

        public static void AddToHistory(NewHistory history)
        {
            try
            {
                string query = "INSERT INTO EmployeeEmploymentHistory (EmployeeID, EmploymentStatusID, Timestamp, Remarks)" +
                    "VALUES (@EmployeeID, @EmploymentStatusID, @Timestamp, @Remarks)";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", history.EmployeeID);
                    command.Parameters.AddWithValue("@EmploymentStatusID", history.EmploymentStatusID);
                    command.Parameters.AddWithValue("@Timestamp", history.Timestamp);
                    command.Parameters.AddWithValue("@Remarks", history.Remarks);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }
    }
}
