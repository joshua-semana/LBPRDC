using System.Data.SqlClient;

namespace LBPRDC.Source.Services
{
    internal class CivilStatusService
    {
        public class CivilStatus
        {
            public int ID { get; set; }
            public string? Name { get; set; }
            public string? Description { get; set; }
            public string? Status { get; set; }
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
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }
    }
}
