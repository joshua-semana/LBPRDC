
using System.Data.SqlClient;
using static LBPRDC.Source.Services.EmploymentStatusService;

namespace LBPRDC.Source.Services
{
    internal class LocationService
    {
        public class Location
        {
            public int? ID { get; set; }
            public string? Name { get; set; }
            public int? DepartmentID { get; set; }
            public string? DepartmentName { get; set; }
            public string? Status { get; set; }
            public string? Description { get; set; }
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

        public static List<Location> GetAllItemsForComboBoxByID(int ID)
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

        public static List<Location> GetAllItemsForCategories()
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
                            DepartmentID = reader["DepartmentID"] is DBNull ? null : Convert.ToInt32(reader["DepartmentID"]),
                            Description = reader["Description"].ToString(),
                            Status = reader["Status"].ToString()
                        };

                        item.DepartmentName = item.DepartmentID.HasValue
                            ? DepartmentService.GetAllItems().First(d => d.ID == item.DepartmentID.Value).Name
                            : "None";

                        items.Add(item);
                    }
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }

        public static async Task<bool> Add(Location data)
        {
            try
            {
                string QueryUpdate = "INSERT INTO Locations (Name, DepartmentID, Description, Status) " +
                    "VALUES (@Name, @DepartmentID, @Description, @Status)";

                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(QueryUpdate, connection))
                {
                    command.Parameters.AddWithValue("@Name", data.Name);
                    command.Parameters.AddWithValue("@DepartmentID", data.DepartmentID);
                    command.Parameters.AddWithValue("@Description", data.Description);
                    command.Parameters.AddWithValue("@Status", data.Status);
                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }

                if (UserService.CurrentUser != null)
                {
                    LoggingService.Log newLog = new()
                    {
                        UserID = UserService.CurrentUser.UserID,
                        ActivityType = "Add",
                        ActivityDetails = $"This user added a new item for the location category with a name of {data.Name}."
                    };

                    LoggingService.LogActivity(newLog);
                }

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static void Update(Location data)
        {
            try
            {
                string QueryUpdate = "UPDATE Locations SET " +
                    "Name = @Name, " +
                    "DepartmentID = @DepartmentID, " +
                    "Description = @Description, " +
                    "Status = @Status " +
                    "WHERE ID = @ID";

                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(QueryUpdate, connection))
                {
                    command.Parameters.AddWithValue("@Name", data.Name);
                    command.Parameters.AddWithValue("@DepartmentID", data.DepartmentID);
                    command.Parameters.AddWithValue("@Description", data.Description);
                    command.Parameters.AddWithValue("@Status", data.Status);
                    command.Parameters.AddWithValue("@ID", data.ID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }

                if (UserService.CurrentUser != null)
                {
                    LoggingService.Log newLog = new()
                    {
                        UserID = UserService.CurrentUser.UserID,
                        ActivityType = "Update",
                        ActivityDetails = $"This user updated an item under the location category with an ID of {data.ID}."
                    };

                    LoggingService.LogActivity(newLog);
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }
    }
}
