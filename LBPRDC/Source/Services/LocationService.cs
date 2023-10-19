
using System.Data.SqlClient;

namespace LBPRDC.Source.Services
{
    internal class LocationService
    {
        public class Location
        {
            public int? ID { get; set; }
            public string? Name { get; set; }
            public int DepartmentID { get; set; }
            public string? Description { get; set; }
            public string? Status { get; set; }
        }

        public static List<Location> GetAllItems()
        {
            List<Location> items = new();

            try
            {
                string query = "SELECT * FROM Locations";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Location item = new()
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

        public static List<Location> GetAllItemsForComboBox(int ID)
        {
            List<Location> items = new();

            Location defaultItem = new()
            {
                ID = 1,
                Name = "None"
            };

            items.Add(defaultItem);

            try
            {
                string query = "SELECT ID, Name FROM Locations WHERE DepartmentID = @ID AND Status = 'Active'";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Location item = new()
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
    }
}
