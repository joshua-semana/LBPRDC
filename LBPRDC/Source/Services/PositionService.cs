using OfficeOpenXml.FormulaParsing.Excel.Functions.Finance.Implementations;
using System.Data.SqlClient;
using System.Security.Permissions;
using static LBPRDC.Source.Services.CivilStatusService;
using static LBPRDC.Source.Services.LocationService;
using static LBPRDC.Source.Services.PositionService;

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
            public string? Status { get; set; }
            public string? Description { get; set; }
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

        public static async Task<bool> Add(Position data)
        {
            try
            {
                string QueryUpdate = "INSERT INTO Position (Code, Name, SalaryRate, BillingRate, Description, Status) " +
                    "VALUES (@Code, @Name, @SalaryRate, @BillingRate, @Description, @Status); " +
                    "SELECT SCOPE_IDENTITY();"; // <-- This is to get the last inserted ID

                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(QueryUpdate, connection))
                {
                    command.Parameters.AddWithValue("@Code", data.Code);
                    command.Parameters.AddWithValue("@Name", data.Name);
                    command.Parameters.AddWithValue("@SalaryRate", data.SalaryRate);
                    command.Parameters.AddWithValue("@BillingRate", data.BillingRate);
                    command.Parameters.AddWithValue("@Description", data.Description);
                    command.Parameters.AddWithValue("@Status", data.Status);
                    connection.Open();
                    var insertedId = await command.ExecuteScalarAsync();

                    RatesHistory newRates = new()
                    {
                        PositionID = Convert.ToInt32(insertedId),
                        SalaryRate = data.SalaryRate,
                        BillingRate = data.BillingRate
                    };

                    AddRatesHistory(newRates);
                }

                if (UserService.CurrentUser != null)
                {
                    LoggingService.Log newLog = new()
                    {
                        UserID = UserService.CurrentUser.UserID,
                        ActivityType = "Add",
                        ActivityDetails = $"This user added a new item for the position category with a name of {data.Name}."
                    };

                    LoggingService.LogActivity(newLog);
                }

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static void Update(Position data)
        {
            try
            {
                string QueryUpdate = "UPDATE Position SET " +
                    "Code = @Code, " +
                    "Name = @Name, " +
                    "SalaryRate = @SalaryRate, " +
                    "BillingRate = @BillingRate, " +
                    "Description = @Description, " +
                    "Status = @Status " +
                    "WHERE ID = @ID";

                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(QueryUpdate, connection))
                {
                    command.Parameters.AddWithValue("@Code", data.Code);
                    command.Parameters.AddWithValue("@Name", data.Name);
                    command.Parameters.AddWithValue("@SalaryRate", data.SalaryRate);
                    command.Parameters.AddWithValue("@BillingRate", data.BillingRate);
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
                        ActivityDetails = $"This user updated an item under the position category with an ID of {data.ID}."
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
            public int OldPositionID { get; set; }
            public int PositionID { get; set; }
            public string? PositionTitle { get; set; }
            public decimal SalaryRate { get; set; }
            public decimal BillingRate { get; set; }
            public DateTime? Timestamp { get; set; }
            public string? Remarks { get; set; }
            public string? Status { get; set; }
        }

        public class HistoryUpdate
        {
            public int HistoryID { get; set; }
            public int PositionID { get; set; }
            public string? PositionTitle { get; set; }
            public DateTime? Timestamp { get; set; }
        }

        public class HistoryView : History
        {
            public string? PositionName { get; set; }
            public string? EffectiveDate { get; set; }
            public string? StatusName { get; set; }
        }

        public static void AddNewHistory(History history)
        {
            try
            {
                string query = "SELECT HistoryID FROM EmployeePositionHistory WHERE EmployeeID = @EmployeeID AND Status = 'Active'";
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
                            UpdateRatesByID(history.OldPositionID, historyID);
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
                string query = "INSERT INTO EmployeePositionHistory (EmployeeID, PositionID, PositionTitle, SalaryRate, BillingRate, Timestamp, Remarks, Status)" +
                    "VALUES (@EmployeeID, @PositionID, @PositionTitle, @SalaryRate, @BillingRate, @Timestamp, @Remarks, @Status)";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", history.EmployeeID);
                    command.Parameters.AddWithValue("@PositionID", history.PositionID);
                    command.Parameters.AddWithValue("@PositionTitle", history.PositionTitle);
                    command.Parameters.AddWithValue("@SalaryRate", history.SalaryRate);
                    command.Parameters.AddWithValue("@BillingRate", history.BillingRate);
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
                string updateQuery = "UPDATE EmployeePositionHistory SET Status = @Status WHERE HistoryID = @HistoryID";
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

        private static void UpdateRatesByID(int OldPositionID, int historyID)
        {
            try
            {
                var rate = GetAllItems().First(f => f.ID == OldPositionID);

                string updateQuery = "UPDATE EmployeePositionHistory SET " +
                    "SalaryRate = @SalaryRate, " +
                    "BillingRate = @BillingRate " +
                    "WHERE HistoryID = @HistoryID";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@SalaryRate", rate.SalaryRate);
                    command.Parameters.AddWithValue("@BillingRate", rate.BillingRate);
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
                string query = "SELECT * FROM EmployeePositionHistory";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        History item = new() {
                            HistoryID = Convert.ToInt32(reader["HistoryID"]),
                            EmployeeID = reader["EmployeeID"].ToString(),
                            PositionID = Convert.ToInt32(reader["PositionId"]),
                            PositionTitle = reader["PositionTitle"].ToString(),
                            SalaryRate = Convert.ToDecimal(reader["SalaryRate"]),
                            BillingRate = Convert.ToDecimal(reader["BillingRate"]),
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
                string updateQuery = "UPDATE EmployeePositionHistory SET " +
                    "PositionID = @PositionID, " +
                    "PositionTitle = @PositionTitle, " +
                    "Timestamp = @Timestamp " +
                    "WHERE HistoryID = @HistoryID";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@PositionID", data.PositionID);
                    command.Parameters.AddWithValue("@PositionTitle", data.PositionTitle);
                    command.Parameters.AddWithValue("@Timestamp", data.Timestamp);
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
                string query = "SELECT * FROM EmployeePositionHistory WHERE EmployeeID = @EmployeeID";
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
                            PositionID = Convert.ToInt32(reader["PositionId"]),
                            PositionTitle = Utilities.StringFormat.ToSentenceCase(reader["PositionTitle"].ToString()),
                            SalaryRate = Convert.ToDecimal(reader["SalaryRate"]),
                            BillingRate = Convert.ToDecimal(reader["BillingRate"]),
                            Timestamp = reader["Timestamp"] as DateTime?,
                            Remarks = reader["Remarks"].ToString(),
                            Status = reader["Status"].ToString()
                        };
                        var position = GetAllItems().First(f => f.ID == item.PositionID);
                        item.PositionName = $"{position.Code} - {Utilities.StringFormat.ToSentenceCase(position.Name)}";
                        item.SalaryRate = (item.Status == "Active") ? position.SalaryRate : item.SalaryRate;
                        item.BillingRate = (item.Status == "Active") ? position.BillingRate : item.BillingRate;
                        item.EffectiveDate = item.Timestamp.Value.ToString("MMMM dd, yyyy");
                        item.StatusName = (item.Status == "Active") ? "Current" : "Old";
                        items.Add(item);
                    }
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }

        public class RatesHistory
        {
            public int PositionID { get; set; }
            public decimal SalaryRate { get; set; }
            public decimal BillingRate { get; set; }
        }

        public class RatesHistoryView
        {
            public string? Status { get; set; }
            public decimal SalaryRate { get; set; }
            public decimal BillingRate { get; set; }
            public DateTime Timestamp { get; set; }
        }

        public static void AddRatesHistory(RatesHistory history)
        {
            try
            {
                string queryAdd = "INSERT INTO PositionRatesHistory (PositionID, SalaryRate, BillingRate, TimeStamp) " +
                    "VALUES (@PositionID, @SalaryRate, @BillingRate, @TimeStamp)";
                using (SqlConnection connection =  new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(queryAdd, connection))
                {
                    command.Parameters.AddWithValue("@PositionID", history.PositionID);
                    command.Parameters.AddWithValue("@SalaryRate", history.SalaryRate);
                    command.Parameters.AddWithValue("@BillingRate", history.BillingRate);
                    command.Parameters.AddWithValue("@TimeStamp", DateTime.Now);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }

        public static List<RatesHistoryView> GetRatesHistoryByID(int? positionID)
        {
            List<RatesHistoryView> histories = new();

            try
            {
                string query = "SELECT * FROM PositionRatesHistory WHERE PositionID = @PositionID " +
                    "ORDER BY Timestamp DESC";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(new(query), connection))
                {
                    command.Parameters.AddWithValue("@PositionID", positionID);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        RatesHistoryView history = new()
                        {
                            SalaryRate = Convert.ToDecimal(reader["SalaryRate"]),
                            BillingRate = Convert.ToDecimal(reader["BillingRate"]),
                            Timestamp = Convert.ToDateTime(reader["Timestamp"])
                        };

                        histories.Add(history);
                    }
                }

                if (histories.Count > 0)
                {
                    histories[0].Status = "Current";
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return histories;
        }
    }
}
