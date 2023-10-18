using System.Data.SqlClient;
using static LBPRDC.Source.Services.CivilStatusService;

namespace LBPRDC.Source.Services
{
    internal class PositionService
    {
        public class Position
        {
            public int ID { get; set; }
            public string? Code { get; set; }
            public string? Name { get; set; }
            public decimal SalaryRate { get; set; }
            public decimal BillingRate { get; set; }
            public string? Description { get; set; }
            public string? Status { get; set; }
        }

        public static List<Position> GetAllItems()
        {
            List<Position> items = new();

            try
            {
                string query = "SELECT * FROM Position";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Position item = new()
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                            SalaryRate = Convert.ToDecimal(reader["SalaryRate"]),
                            BillingRate = Convert.ToDecimal(reader["BillingRate"]),
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

        public static List<Position> GetAllItemsForComboBox()
        {
            List<Position> items = new();

            try
            {
                Position blankItem = new()
                {
                    ID = 0,
                    Name = "(Choose Position)"
                };

                items.Add(blankItem);

                string query = "SELECT ID, Name FROM Position WHERE Status = 'Active'";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Position item = new()
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
            public int PositionID { get; set; }
            public string? PositionTitle { get; set; }
            public DateTime? Timestamp { get; set; }
            public string? Remarks { get; set;}
        }

        public static void AddToHistory(NewHistory history)
        {
            try
            {
                string query = "INSERT INTO EmployeePositionHistory (EmployeeID, PositionID, PositionTitle, Timestamp, Remarks)" +
                    "VALUES (@EmployeeID, @PositionID, @PositionTitle, @Timestamp, @Remarks)";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", history.EmployeeID);
                    command.Parameters.AddWithValue("@PositionID", history.PositionID);
                    command.Parameters.AddWithValue("@PositionTitle", history.PositionTitle);
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
