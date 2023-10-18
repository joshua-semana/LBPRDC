
using System.Data.SqlClient;

namespace LBPRDC.Source.Services
{
    internal class SectionService
    {
        public class Section
        {
            public int? ID { get; set; }
            public string? Name { get; set; }
            public int DepartmentID { get; set; }
            public string? Description { get; set; }
            public string? Status { get; set; }
        }

        public static List<Section> GetAllItems()
        {
            List<Section> items = new();

            try
            {
                string query = "SELECT * FROM Sections";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Section item = new()
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

        public static List<Section> GetAllItemsForComboBox(int ID)
        {
            List<Section> items = new();

            Section defaultItem = new()
            {
                ID = 1,
                Name = "None"
            };

            items.Add(defaultItem);

            try
            {
                string query = "SELECT ID, Name FROM Sections WHERE DepartmentID = @ID AND Status = 'Active'";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Section item = new()
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
