using System.Data.SqlClient;
using System.Globalization;
using System.Text.Json;

namespace LBPRDC.Source.Services
{
    public class EntryAdjustments
    {
        public int ID { get; set; }
        public string? Type { get; set; }
        public string? Operation { get; set; }
        public string? InputValue { get; set; }
        public string? Units { get; set; }
        public string? AppliedDate { get; set; }
        public string? Remarks { get; set; }
    }

    public class AdjustmentSummary
    {
        public string? Type { get; set; }
        public string? OriginalValue { get; set; }
        public string? InputValueTotal { get; set; }
        public string? NewValue { get; set; }
        public string? Units { get; set; }
    }

    public class AdjustmentRemarks
    {
        public string? Type { get; set; }
        public string? TimeType { get; set; }
        public string? Value { get; set; }
    }

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
            public string? ConstantJSON { get; set; }
            public string? EditableJSON { get; set; }
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

        public static BillingView GetBillingDetailsByName(string billingName)
        {
            BillingView billing = new();
            try
            {
                string QueryGet = $"SELECT * FROM Billing WHERE Name = '{billingName}'";
                using SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString());
                connection.Open();

                using SqlCommand command = new(QueryGet, connection);
                using SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string[] monthNames = DateTimeFormatInfo.CurrentInfo.MonthNames;
                    billing = new() 
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
                        ConstantJSON = Convert.ToString(reader["ConstantJSON"]),
                        EditableJSON = Convert.ToString(reader["EditableJSON"]),
                        VerificationStatus = Convert.ToString(reader["VerificationStatus"]),
                        Description = Convert.ToString(reader["Description"]),
                        MonthName = monthNames[Convert.ToInt32(reader["Month"]) - 1],
                        QuarterName = Convert.ToString(reader["Quarter"]),
                        FormattedStartDate = Convert.ToDateTime(reader["StartDate"]).ToString("MMMM dd, yyyy"),
                        FormattedEndDate = Convert.ToDateTime(reader["EndDate"]).ToString("MMMM dd, yyyy"),
                        Status = Convert.ToString(reader["Status"])
                    };
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
            return billing;
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
                        ConstantJSON = Convert.ToString(reader["ConstantJSON"]) != "" ? "✔️" : "",
                        EditableJSON = Convert.ToString(reader["EditableJSON"]),
                        VerificationStatus = (Convert.ToString(reader["VerificationStatus"]) == "Verified") ? "✔️" : "",
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
                string QueryAdd = "INSERT INTO Billing (UserID, Name, Month, Year, Quarter, StartDate, EndDate, Timestamp, ConstantJSON, EditableJSON, VerificationStatus, Description, Status) " +
                                  "VALUES (@UserID, @Name, @Month, @Year, @Quarter, @StartDate, @EndDate, @Timestamp, @ConstantJSON, @EditableJSON, @VerificationStatus, @Description, @Status)";

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
                command.Parameters.AddWithValue("@ConstantJSON", String.Empty);
                command.Parameters.AddWithValue("@EditableJSON", String.Empty);
                command.Parameters.AddWithValue("@VerificationStatus", "No");
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
                var output = command.ExecuteNonQuery();
                return (output > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static bool UploadJSON(List<Entry> entries, string billingName)
        {
            try
            {
                string json = JsonSerializer.Serialize(entries);
                string QueryUpdate = "UPDATE Billing SET " +
                    $"ConstantJSON = '{json}', " +
                    $"EditableJSON = '{json}' " +
                    $"WHERE Name = '{billingName}'";
                using SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString());
                using SqlCommand command = new(QueryUpdate, connection);
                connection.Open();
                var output = command.ExecuteNonQuery();
                return (output > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static bool UpdateEditableJSON(List<Entry> entries, string billingName)
        {
            try
            {
                string json = JsonSerializer.Serialize(entries);
                string QueryUpdate = "UPDATE Billing SET " +
                    $"EditableJSON = '{json}' " +
                    $"WHERE Name = '{billingName}'";
                using SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString());
                using SqlCommand command = new(QueryUpdate, connection);
                connection.Open();
                var output = command.ExecuteNonQuery();
                return (output > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
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
                return (output > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static bool UpdateVerificationStatus(string billingName, string status)
        {
            try
            {
                string QueryUpdate = "UPDATE Billing SET " +
                    $"VerificationStatus = '{status}' " +
                    $"WHERE Name = '{billingName}'";
                using SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString());
                using SqlCommand command = new(QueryUpdate, connection);
                connection.Open();
                var output = command.ExecuteNonQuery();
                return (output > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static (List<Entry>, List<Entry>) LoadJSONData(string billingName)
        {
            List<Entry> constantEntries = new();
            List<Entry> editableEntries = new();

            try
            {
                string QueryUpdate = $"SELECT ConstantJSON, EditableJSON FROM Billing WHERE Name = '{billingName}'";
                using SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString());
                using SqlCommand command = new(QueryUpdate, connection);
                connection.Open();
                
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string jsonConstant = Convert.ToString(reader["ConstantJSON"]);
                    var constantEntry = JsonSerializer.Deserialize<List<Entry>>(jsonConstant);
                    constantEntries.AddRange(constantEntry);

                    string jsonEditable = Convert.ToString(reader["EditableJSON"]);
                    var editableEntry = JsonSerializer.Deserialize<List<Entry>>(jsonEditable);
                    editableEntries.AddRange(editableEntry);
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return (constantEntries, editableEntries);
        }
    }
}
