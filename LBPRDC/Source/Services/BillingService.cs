using System.Data.SqlClient;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Text.Json;
using System.Web;

namespace LBPRDC.Source.Services
{
    internal class BillingService
    {
        public class Billing
        {
            public int ID { get; set; }
            public int UserID { get; set; }
            public string? Name { get; set; }
            public int Month { get; set; }
            public int Year { get; set; }
            public int Quarter { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public DateTime Timestamp { get; set; }
            public string? JSONData { get; set; }
            public string? VerificationStatus { get; set; }
            public string? Description { get; set; }
            public string? Status { get; set; }
        }

        public class BillingView : Billing
        {
            public string? FullName { get; set; }
            public string? MonthName { get; set; }
            public string? QuarterName { get; set; }
            public string? FormattedStartDate { get; set; }
            public string? FormattedEndDate { get; set; }
        }

        public static int GetItemCountByName(string name)
        {
            int totalCount = 0;

            try
            {
                string queryCount = $"SELECT COUNT(*) FROM Billing WHERE Name = '{name}'";
                using SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString());
                connection.Open();

                using SqlCommand command = new(queryCount, connection);
                totalCount = (int) command.ExecuteScalar();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return totalCount;
        }

        public static (List<BillingView>, int TotalCount) GetFilteredItems(string searchWord)
        {
            List<BillingView> billings = new();
            int TotalCount = 0;

            try
            {
                string QueryCount = "SELECT COUNT(*) FROM Billing WHERE Status = 'Active'";

                string QueryGet = "SELECT Billing.*, Users.FirstName, Users.LastName " +
                                  "FROM Billing " +
                                  "INNER JOIN Users " +
                                  "ON Billing.UserID = Users.UserID " +
                                  "WHERE Billing.Status = 'Active'";

                if (!string.IsNullOrEmpty(searchWord))
                {
                    QueryGet += $" AND (Billing.Name LIKE '%{searchWord}%'" +
                                $" OR Users.FirstName + ' ' + Users.LastName LIKE '%{searchWord}%')";
                }

                QueryGet += " ORDER BY Timestamp DESC";

                using SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString());
                connection.Open();

                using SqlCommand commandCount = new(QueryCount, connection);
                TotalCount = (int) commandCount.ExecuteScalar();

                using SqlCommand command = new(QueryGet, connection);
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string[] monthNames = DateTimeFormatInfo.CurrentInfo.MonthNames;

                    BillingView billing = new()
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        UserID = Convert.ToInt32(reader["UserID"]),
                        Name = Convert.ToString(reader["Name"]),
                        Month = Convert.ToInt32(reader["Month"]),
                        Year = Convert.ToInt32(reader["Year"]),
                        Quarter = Convert.ToInt32(reader["Quarter"]),
                        StartDate = Convert.ToDateTime(reader["StartDate"]),
                        EndDate = Convert.ToDateTime(reader["EndDate"]),
                        Timestamp = Convert.ToDateTime(reader["Timestamp"]),
                        JSONData = Convert.ToString(reader["JSONData"]) != "" ? "✔️ (Uploaded)" : "",
                        VerificationStatus = (Convert.ToString(reader["VerificationStatus"]) == "Yes") ? "Yes" : "",
                        Description = Convert.ToString(reader["Description"]),
                        FullName = $"{Convert.ToString(reader["FirstName"])} {Convert.ToString(reader["LastName"])}",
                        MonthName = monthNames[Convert.ToInt32(reader["Month"]) - 1],
                        QuarterName = (Convert.ToInt32(reader["Quarter"]) == 1) ? "1st" : "2nd",
                        FormattedStartDate = Convert.ToDateTime(reader["StartDate"]).ToString("MMMM dd, yyyy"),
                        FormattedEndDate = Convert.ToDateTime(reader["EndDate"]).ToString("MMMM dd, yyyy"),
                        Status = Convert.ToString(reader["Status"])
                    };

                    billings.Add(billing);
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return (billings, TotalCount);
        }

        public static async Task<bool> Add(Billing data)
        {
            try
            {
                string QueryAdd = "INSERT INTO Billing (UserID, Name, Month, Year, Quarter, StartDate, EndDate, Timestamp, JSONData, VerificationStatus, Description, Status) " +
                                  "VALUES (@UserID, @Name, @Month, @Year, @Quarter, @StartDate, @EndDate, @Timestamp, @JSONData, @VerificationStatus, @Description, @Status)";

                using SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString());
                using SqlCommand command = new(QueryAdd, connection);

                command.Parameters.AddWithValue("@UserID", data.UserID);
                command.Parameters.AddWithValue("@Name", data.Name);
                command.Parameters.AddWithValue("@Month", data.Month);
                command.Parameters.AddWithValue("@Year", data.Year);
                command.Parameters.AddWithValue("@Quarter", data.Quarter);
                command.Parameters.AddWithValue("@StartDate", data.StartDate);
                command.Parameters.AddWithValue("@EndDate", data.EndDate);
                command.Parameters.AddWithValue("@Timestamp", DateTime.Now);
                command.Parameters.AddWithValue("@JSONData", String.Empty);
                command.Parameters.AddWithValue("@VerificationStatus", "No");
                //command.Parameters.AddWithValue("@BaseFile", Array.Empty<byte>());
                //command.Parameters.AddWithValue("@OutputFile", Array.Empty<byte>());
                command.Parameters.AddWithValue("@Description", data.Description);
                command.Parameters.AddWithValue("@Status", data.Status);

                connection.Open();
                await command.ExecuteNonQueryAsync();

                if (UserService.CurrentUser != null)
                {
                    LoggingService.Log newLog = new()
                    {
                        UserID = UserService.CurrentUser.UserID,
                        ActivityType = "New Billing",
                        ActivityDetails = $"This user added a new billing record with a name of {data.Name}."
                    };

                    LoggingService.LogActivity(newLog);
                }

                return true;

            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static bool UpdateFileUploadStatus(string billingName, string status)
        {
            try
            {
                string QueryUpdate = "UPDATE Billing SET " +
                    $"IsFileUploaded = '{status}' " +
                    $"WHERE Name = '{billingName}'";
                using SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString());
                using SqlCommand command = new(QueryUpdate, connection);
                connection.Open();

                command.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static bool UpdateJSONData(List<Entry> entries, string billingName)
        {
            try
            {
                string json = JsonSerializer.Serialize(entries);
                string QueryUpdate = "UPDATE BILLING SET " +
                    $"JSONData = '{json}' " +
                    $"WHERE Name = '{billingName}'";
                using SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString());
                using SqlCommand command = new(QueryUpdate, connection);
                connection.Open();
                command.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static List<Entry> LoadJSONData(string billingName)
        {
            List<Entry> entries = new();

            try
            {
                string QueryUpdate = $"SELECT JSONData FROM Billing WHERE Name = '{billingName}'";
                using SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString());
                using SqlCommand command = new(QueryUpdate, connection);
                connection.Open();
                
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string json = Convert.ToString(reader["JSONData"]);
                    var entry = JsonSerializer.Deserialize<List<Entry>>(json);
                    entries.AddRange(entry);
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return entries;
        }

        public static bool UpdateStatus(string billingName, string status)
        {
            try
            {
                string QueryUpdate = "UPDATE Billing SET " +
                    $"Status = '{status}' " +
                    $"WHERE Name = '{billingName}'";
                using SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString());
                using SqlCommand command = new(QueryUpdate, connection);
                connection.Open();
                var output = command.ExecuteNonQuery();
                return (output > 0) ? true : false;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }
    }
}
