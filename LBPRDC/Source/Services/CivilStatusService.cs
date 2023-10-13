using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LBPRDC.Source.Services.SuffixService;

namespace LBPRDC.Source.Services
{
    internal class CivilStatusService
    {
        public class CivilStatusItems
        {
            public int ID { get; set; }
            public string? Status { get; set; }
        }

        public static List<CivilStatusItems> GetCivilStatusItems()
        {
            List<CivilStatusItems> items = new();

            try
            {
                CivilStatusItems blankItem = new()
                {
                    ID = 0,
                    Status = "(Choose Status)"
                };
                items.Add(blankItem);

                string query = "SELECT ID, Status FROM CivilStatus";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) 
                    {
                        CivilStatusItems item = new()
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

        public class NewHistory
        {
            public string? EmployeeID { get; set; }
            public int CivilStatusID { get; set; }
            public DateTime? Timestamp { get; set; }
            public string? Remarks { get; set; }
        }

        public static void AddToHistory(NewHistory history)
        {
            try
            {
                string query = "INSERT INTO EmployeeCivilStatusHistory (EmployeeID, CivilStatusID, Timestamp, Remarks)" +
                    "VALUES (@EmployeeID, @CivilStatusID, @Timestamp, @Remarks)";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", history.EmployeeID);
                    command.Parameters.AddWithValue("@CivilStatusID", history.CivilStatusID);
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
