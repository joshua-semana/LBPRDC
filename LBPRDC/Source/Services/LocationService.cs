using Dapper;
using LBPRDC.Source.Data;
using System.Data.SqlClient;

namespace LBPRDC.Source.Services
{
    internal class LocationService
    {
        public class Location
        {
            public int? ID { get; set; }
            public string Type { get; set; } = "USER_ENTRY"; // DEFAULT or USER_ENTRY
            public string? Name { get; set; }
            public int? DepartmentID { get; set; }
            //public string? DepartmentName { get; set; } // Only intended to use for the viewing in Categories Control Table
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

        public static List<Location> GetAllItemsForComboBoxByID(int departmentID)
        {
            List<Location> items = new();

            try
            {
                using var connection = Database.Connect();

                string QuerySelect = @"
                    SELECT
                        ID,
                        Name
                    FROM
                        Locations
                    WHERE
                        DepartmentID = @DepartmentID 
                    AND
                        Status = @Status";

                items = connection.Query<Location>(QuerySelect, new
                {
                    DepartmentID = departmentID,
                    Status = "Active"
                }).ToList();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }

        public static List<Location> GetAllItemsForCategories()
        {
            List<Location> items = new();

            try
            {
                using var connection = Database.Connect();

                string QuerySelect = "SELECT * FROM Locations";

                items = connection.Query<Location>(QuerySelect).ToList();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }

        public static List<string> GetExistenceByID(int locationID)
        {
            List<string> databaseTableNames = new();

            try
            {
                using var connection = Database.Connect();

                string QueryCheckExistense = "";
                List<string> tableNames = new()
                {
                    "Employee"
                };

                List<string> selectQueries = tableNames.Select(name =>
                    $"SELECT DISTINCT '{name}' AS TableName FROM {name} WHERE LocationID = @LocationID"
                ).ToList();

                QueryCheckExistense = string.Join(" UNION ALL ", selectQueries);

                databaseTableNames = connection.Query<string>(QueryCheckExistense, new
                {
                    LocationID = locationID
                }).ToList();

            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return databaseTableNames;
        }

        public static int hasNoneValueByDepartmentID(int departmentID)
        {
            int noneValueCount = -1;

            try
            {
                using var connection = Database.Connect();

                string QuerySelect = @"
                    SELECT 
                        Name
                    FROM
                        Locations
                    WHERE
                        DepartmentID = @DepartmentID
                    AND
                        Name = @Name";

                noneValueCount = connection.ExecuteScalar<int>(QuerySelect, new
                {
                    DepartmentID = departmentID,
                    Name = "None"
                });
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return noneValueCount;
        }

        public static async Task<bool> Add(Location data)
        {
            try
            {
                using var connection = Database.Connect();
                using var transaction = connection?.BeginTransaction();

                try
                {
                    string QueryInsert = @"
                        INSERT INTO Locations (
                            Type,
                            Name, 
                            DepartmentID,
                            Description, 
                            Status
                        ) VALUES (
                            @Type,
                            @Name, 
                            @DepartmentID,
                            @Description, 
                            @Status
                        )";

                    int affectedRows = await connection.ExecuteAsync(QueryInsert, data, transaction);
                    transaction?.Commit();

                    if (affectedRows > 0)
                    {
                        LoggingService.Log newLog = new()
                        {
                            UserID = UserService.CurrentUser.UserID,
                            ActivityType = "Add",
                            ActivityDetails = $"This user added a new item for the location category with a name of {data.Name}."
                        };
                    }

                    return (affectedRows > 0);
                }
                catch (Exception)
                {
                    transaction?.Rollback();
                    return false;
                }
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
