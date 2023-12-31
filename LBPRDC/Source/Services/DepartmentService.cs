﻿using System.Data.SqlClient;

namespace LBPRDC.Source.Services
{
    internal class DepartmentService
    {
        public class Department
        {
            public int ID { get; set; }
            public string? Code { get; set; }
            public string? Name { get; set; }
            public string? Status { get; set; }
            public string? Description { get; set; }
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
                            Code = Convert.ToString(reader["Code"]),
                            Name = Convert.ToString(reader["Name"]),
                            Description = Convert.ToString(reader["Description"]),
                            Status = Convert.ToString(reader["Status"])
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
                Department blankItem = new()
                {
                    ID = 0,
                    Name = "(Choose Department)"
                };

                items.Add(blankItem);

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

        public static async Task<bool> Add(Department data)
        {
            try
            {
                string QueryUpdate = "INSERT INTO Departments (Code, Name, Description, Status) " +
                    "VALUES (@Code, @Name, @Description, @Status)";

                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(QueryUpdate, connection))
                {
                    command.Parameters.AddWithValue("@Cond", data.Code);
                    command.Parameters.AddWithValue("@Name", data.Name);
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
                        ActivityDetails = $"This user added a new item for the department category with a name of {data.Name}."
                    };

                    LoggingService.LogActivity(newLog);
                }

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static void Update(Department data)
        {
            try
            {
                string QueryUpdate = "UPDATE Departments SET " +
                    "Code = @Code, " +
                    "Name = @Name, " +
                    "Description = @Description, " +
                    "Status = @Status " +
                    "WHERE ID = @ID";

                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(QueryUpdate, connection))
                {
                    command.Parameters.AddWithValue("@Code", data.Code);
                    command.Parameters.AddWithValue("@Name", data.Name);
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
                        ActivityDetails = $"This user updated an item under the department category with an ID of {data.ID}."
                    };

                    LoggingService.LogActivity(newLog);
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }

        public class History
        {
            public int HistoryID { get; set; }
            public string? EmployeeID { get; set; }
            public int DepartmentID { get; set; }
            public int LocationID { get; set; }
            public DateTime? Timestamp { get; set; }
            public string? Remarks { get; set; }
            public string? Status { get; set; }
        }

        public class HistoryUpdate
        {
            public int HistoryID { get; set; }
            public int DepartmentID { get; set; }
            public int LocationID { get; set; }
        }

        public class HistoryView : History
        {
            public string? DepartmentName { get; set; }
            public string? LocationName { get; set; }
            public string? EffectiveDate { get; set; }
            public string? StatusName { get; internal set; }
        }

        public static void AddNewHistory(History history)
        {
            try
            {
                string query = "SELECT HistoryID FROM EmployeeDepartmentLocationHistory WHERE EmployeeID = @EmployeeID AND Status = 'Active'";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", history.EmployeeID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int historyID = Convert.ToInt32(reader["HistoryID"]);
                            UpdateStatusToInactiveByID(historyID);
                        }
                        AddToHistory(history);
                    }
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }

        public static void AddToHistory(History history)
        {
            try
            {
                string query = "INSERT INTO EmployeeDepartmentLocationHistory (EmployeeID, DepartmentID, LocationID, Timestamp, Remarks, Status)" +
                    "VALUES (@EmployeeID, @DepartmentID, @LocationID, @Timestamp, @Remarks, @Status)";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", history.EmployeeID);
                    command.Parameters.AddWithValue("@DepartmentID", history.DepartmentID);
                    command.Parameters.AddWithValue("@LocationID", history.LocationID);
                    command.Parameters.AddWithValue("@Timestamp", history.Timestamp);
                    command.Parameters.AddWithValue("@Remarks", history.Remarks);
                    command.Parameters.AddWithValue("@Status", history.Status);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }

        private static void UpdateStatusToInactiveByID(int historyID)
        {
            try
            {
                string updateQuery = "UPDATE EmployeeDepartmentLocationHistory SET Status = @Status WHERE HistoryID = @HistoryID";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Status", "Inactive");
                    command.Parameters.AddWithValue("@HistoryID", historyID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }

        public static List<History> GetAllHistory()
        {
            List<History> items = new();

            try
            {
                string query = "SELECT * FROM EmployeeDepartmentLocationHistory";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        History item = new()
                        {
                            HistoryID = Convert.ToInt32(reader["HistoryID"]),
                            EmployeeID = reader["EmployeeID"].ToString(),
                            DepartmentID = Convert.ToInt32(reader["DepartmentID"]),
                            LocationID = Convert.ToInt32(reader["LocationID"]),
                            Timestamp = reader["Timestamp"] as DateTime?,
                            Remarks = reader["Remarks"].ToString(),
                            Status = reader["Status"].ToString()
                        };

                        items.Add(item);
                    }
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }

        public static void UpdateHistory(HistoryUpdate data)
        {
            try
            {
                string updateQuery = "UPDATE EmployeeDepartmentLocationHistory SET " +
                    "DepartmentID = @DepartmentID, " +
                    "LocationID = @LocationID " +
                    "WHERE HistoryID = @HistoryID";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@DepartmentID", data.DepartmentID);
                    command.Parameters.AddWithValue("@LocationID", data.LocationID);
                    command.Parameters.AddWithValue("@HistoryID", data.HistoryID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }

        public static List<HistoryView> GetAllHistoryByID(string employeeId)
        {
            List<HistoryView> items = new();

            try
            {
                string query = "SELECT * FROM EmployeeDepartmentLocationHistory WHERE EmployeeID = @EmployeeID";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employeeId);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        HistoryView item = new()
                        {
                            HistoryID = Convert.ToInt32(reader["HistoryID"]),
                            EmployeeID = reader["EmployeeID"].ToString(),
                            DepartmentID = Convert.ToInt32(reader["DepartmentID"]),
                            LocationID = Convert.ToInt32(reader["LocationID"]),
                            Timestamp = reader["Timestamp"] as DateTime?,
                            Remarks = reader["Remarks"].ToString(),
                            Status = reader["Status"].ToString()
                        };
                        var department = GetAllItems().First(f => f.ID == item.DepartmentID);
                        var location = LocationService.GetAllItems().First(f => f.ID == item.LocationID);
                        item.DepartmentName = department.Name;
                        item.LocationName = location.Name;
                        item.EffectiveDate = item.Timestamp.Value.ToString("MMMM dd, yyyy");
                        item.StatusName = (item.Status == "Active") ? "Current" : "Old";
                        items.Add(item);
                    }
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }
    }
}
