
using System.Data.SqlClient;

namespace LBPRDC.Source.Services
{
    internal class DepartmentService
    {
        public class Department
        {
            public int ID { get; set; }
            public string? Name { get; set; }
            public string? Description { get; set; }
            public string? Status { get; set; }
        }

        public static List<Department> GetAllItems()
        {
            List<Department> items = new();

            try
            {
                string query = "SELECT * FROM Departments";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Department item = new()
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

        public static List<Department> GetAllItemsForComboBox()
        {
            List<Department> items = new();

            try
            {
                string query = "SELECT ID, Name FROM Departments WHERE Status = 'Active'";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Department item = new()
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
