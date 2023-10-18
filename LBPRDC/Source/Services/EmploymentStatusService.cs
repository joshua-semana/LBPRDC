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
        public class EmploymentStatus
        {
            public int ID { get; set; }
            public string? Name { get; set; }
            public string? Description { get; set; }
            public string? Status { get; set; }
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
