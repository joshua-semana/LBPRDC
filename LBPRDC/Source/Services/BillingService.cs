using Dapper;
using LBPRDC.Source.Config;
using LBPRDC.Source.Data;
using System.Globalization;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using static LBPRDC.Source.Data.Database;
using Microsoft.EntityFrameworkCore.Diagnostics;

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
    public class Billing
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public int UserID { get; set; }
        public string? Name { get; set; }
        public string? OfficerName { get; set; }
        public string? OfficerPosition { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Quarter { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime Timestamp { get; set; }
        public string? ConstantJSON { get; set; }
        public string? EditableJSON { get; set; }
        public string? AccrualsJSON { get; set; }
        public string? VerificationStatus { get; set; }
        public bool IsEquipmentIncluded { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; } // Active, Inactive (For Archive)
        public string? LockStatus { get; set; } // Lock, Unlock (If billing is released, lock the billing)
    }

    public class BillingWithEquipment : Billing
    {
        public string EquipmentAccountNumber { get; set; } = string.Empty;
        public decimal EquipmentBilledValue { get; set; }
    }

    internal class BillingService
    {
        public class BillingView : Billing
        {
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? FullName { get; set; }
            public string? MonthName { get; set; }
            public string? QuarterName { get; set; }
            public string? FormattedStartDate { get; set; }
            public string? FormattedEndDate { get; set; }
        }

        // Entity Framework

        public static async Task<Models.Billing> GetBillingDetailsById(int BillingID)
        {
            Models.Billing billing = new();

            try
            {
                using var context = new Context();
                billing = await context.Billing
                    .Where(b => b.ID == BillingID)
                    .FirstAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return billing;
        }

        public static async Task<List<Models.Billing>> GetAllBillingByClientID(int ClientID)
        {
            List<Models.Billing> billing = new();

            try
            {
                using var context = new Context();
                billing = await context.Billing
                    .Where(b => b.ClientID == ClientID)
                    .ToListAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return billing;
        }

        public static async Task<bool> Update(Models.Billing Data)
        {
            try
            {
                using var context = new Context();
                var billing = await context.Billing.FindAsync(Data.ID);
                if (billing == null)
                {
                    return false;
                }
                billing.Description = Data.Description;
                billing.OfficerName = Data.OfficerName;
                billing.OfficerPosition = Data.OfficerPosition;
                billing.IsEquipmentIncluded = Data.IsEquipmentIncluded;
                int affectedRows = await context.SaveChangesAsync();

                if (affectedRows > 0)
                {
                    await LoggingService.AddLog(new()
                    {
                        UserID = UserService.CurrentUser.ID,
                        Type = MessagesConstants.UPDATE,
                        Details = $"User updated the information of billing '{billing.Name}'."
                    });
                }

                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<string> GetNewBillingNameForDuplication(string name)
        {
            string newName = name;

            try
            {
                using var context = new Context();

                var namesList = await context.Billing
                    .Select(s => s.Name)
                    .ToListAsync();

                int count = namesList.Where(w => w == name).Count();

                if (count > 0)
                {
                    int counter = count;

                    do
                    {
                        newName = $"{name} ({counter})";
                        counter++;
                        count = namesList.Where(w => w == newName).Count();
                    } while (count > 0);
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return newName;
        }













        public static Billing GetAllBillingDetailsByName(string billingName)
        {
            Billing billing = new();

            try
            {
                using var connection = Database.Connect();
                string QuerySelect = "SELECT * FROM Billing WHERE Name = @BillingName";
                billing = connection.QueryFirst<Billing>(QuerySelect, new { BillingName = billingName });
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return billing;
        }

        public static BillingWithEquipment GetSpecificBillingDetailsByName(string billingName) // FOR BILLING INFORMATION WHEN USER CLICKS "VIEW DETAILS" BUTTON
        {
            BillingWithEquipment billing = new();

            try
            {
                using var connection = Database.Connect();

                string QuerySelect = @"
                    SELECT 
                        Timestamp,
                        ReleaseDate,
                        Description,
                        OfficerName, 
                        OfficerPosition,
                        IsEquipmentIncluded
                    FROM 
                        Billing 
                    WHERE 
                        Name = @Name";

                billing = connection.QueryFirst<BillingWithEquipment>(QuerySelect, new { Name = billingName });

                if (billing.IsEquipmentIncluded)
                {
                    var equipmenDetails = BillingAccountService.GetEquipmentDetails(billingName);
                    billing.EquipmentAccountNumber = (equipmenDetails != null) ? equipmenDetails.AccountNumber : "Unable to retrieve data ...";
                    billing.EquipmentBilledValue = (equipmenDetails != null) ? equipmenDetails.BilledValue : 0;
                }
                else
                {
                    billing.EquipmentAccountNumber = "None";
                    billing.EquipmentBilledValue = 0;
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return billing;
        }

        public static Billing GetDetailsForTransmittalSummaryByName(string billingName)
        {
            Billing billing = new();

            try
            {
                using var connection = Database.Connect();

                string QuerySelect = @"
                    SELECT
                        OfficerName,
                        OfficerPosition,
                        Quarter,
                        StartDate,
                        EndDate,
                        ReleaseDate
                    FROM 
                        Billing 
                    WHERE 
                        Name = @Name";

                billing = connection.QueryFirst<Billing>(QuerySelect, new { Name = billingName });
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return billing;
        }

        public static async Task<bool> CheckExistence(string BillingName, int ClientID)
        {
            try
            {
                using var context = new Context();
                var count = await context.Billing.Where(b => b.Name == BillingName && b.ClientID == ClientID).CountAsync();
                return (count > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static (List<BillingView>, int TotalCount) GetFilteredItems(string searchWord, int ClientID)
        {
            List<BillingView> billings = new();
            int totalCount = 0;

            try
            {
                using var connection = Database.Connect();

                string QueryCount = @"
                    SELECT 
                        COUNT(*) 
                    FROM 
                        Billing 
                    WHERE 
                        Status = @Status AND ClientID = @ClientID";

                totalCount = connection.QueryFirstOrDefault<int>(QueryCount, new
                {
                    Status = StringConstants.Status.ACTIVE,
                    ClientID
                });

                string QuerySelect = @"
                    SELECT 
                        Billing.*, 
                        Users.FirstName, 
                        Users.LastName 
                    FROM 
                        Billing
                    INNER JOIN 
                        Users 
                    ON 
                        Billing.UserID = Users.ID 
                    WHERE 
                        Billing.Status = @Status
                    AND
                        Billing.ClientID = @ClientID";

                if (!string.IsNullOrEmpty(searchWord))
                {
                    QuerySelect += @" AND (Billing.Name LIKE @SearchWord OR Users.FirstName + ' ' + Users.LastName LIKE @SearchWord)";
                }

                QuerySelect += " ORDER BY Timestamp DESC";

                billings = connection.Query<BillingView>(QuerySelect, new {
                    Status = StringConstants.Status.ACTIVE,
                    ClientID,
                    SearchWord = $"%{searchWord}%"
                }).ToList();

                string[] monthNames = DateTimeFormatInfo.CurrentInfo.MonthNames;

                foreach (var billing in billings)
                {
                    if (billing != null)
                    {
                        billing.ConstantJSON = !string.IsNullOrEmpty(billing.ConstantJSON) ? "✔️" : "";
                        billing.AccrualsJSON = !string.IsNullOrEmpty(billing.AccrualsJSON) ? "✔️" : "";
                        billing.VerificationStatus = (billing.VerificationStatus == "Verified") ? "✔️" : "";
                        billing.FullName = $"{billing.FirstName} {billing.LastName}";
                        billing.MonthName = monthNames[billing.Month - 1];
                        billing.QuarterName = (billing.Quarter == 1) ? "1st" : "2nd";
                        billing.FormattedStartDate = billing.StartDate.ToString(StringConstants.Date.DEFAULT);
                        billing.FormattedEndDate = billing.EndDate.ToString(StringConstants.Date.DEFAULT);
                        billing.LockStatus = (billing.LockStatus == "Lock") ? "🔒" : "🔓";
                    }
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return (billings, totalCount);
        }

        public static (List<Entry>, List<Entry>) GetConstantAndEditableJSON(int BillingID)
        {
            List<Entry> constantEntries = new();
            List<Entry> editableEntries = new();

            try
            {
                using var connection = Database.Connect();
                string QuerySelect = @"
                    SELECT
                        ISNULL(ConstantJSON, '') AS ConstantJSON,
                        ISNULL(EditableJSON, '') AS EditableJSON
                    FROM
                        Billing
                    WHERE
                        ID = @BillingID";

                var billing = connection.QueryFirstOrDefault<Billing>(QuerySelect, new
                {
                    BillingID
                });

                if (billing != null)
                {
                    constantEntries.AddRange(JsonSerializer.Deserialize<List<Entry>>(billing.ConstantJSON));
                    editableEntries.AddRange(JsonSerializer.Deserialize<List<Entry>>(billing.EditableJSON));
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return (constantEntries, editableEntries);
        }

        public static List<AccrualsEntry> GetAccrualsJSON(string billingName)
        {
            List<AccrualsEntry> accrualsEntries = new();

            try
            {
                using var connection = Database.Connect();

                string QuerySelect = @"
                    SELECT 
                        AccrualsJSON 
                    FROM 
                        Billing 
                    WHERE 
                        Name = @BillingName";

                string jsonAccruals = connection.QueryFirst<string>(QuerySelect, new { BillingName = billingName });
                var accrualsEntryRange = JsonSerializer.Deserialize<List<AccrualsEntry>>(jsonAccruals);
                accrualsEntries.AddRange(accrualsEntryRange);
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return accrualsEntries;
        }

        public static async Task<(bool Success, int LatestInsertedID)> Add(Models.Billing data)
        {
            try
            {
                using var context = new Context();

                context.Billing.Add(data);
                int affectedRows = await context.SaveChangesAsync();

                if (affectedRows > 0)
                {
                    await LoggingService.AddLog(new()
                    {
                        UserID = UserService.CurrentUser.ID,
                        Type = MessagesConstants.Logs.TITLE_NEW_BILLING,
                        Details = $"{MessagesConstants.Logs.NEW_BILLING}{data.Name}."
                    });

                    return (true, data.ID);
                }

                return (false, -1);
            }
            catch (Exception ex) { return (ExceptionHandler.HandleException(ex), -1); }
        }

        public static async Task<bool> UpdateConstantAndEditableJSON(List<Entry> entries, int BillingID)
        {
            try
            {
                using var connection = Database.Connect();
                string QueryUpdate = @"
                    UPDATE Billing SET
                        ConstantJSON = @ConstantJSON,
                        EditableJSON = @EditableJSON
                    WHERE
                        ID = @ID";

                int affectedRows = connection.Execute(QueryUpdate, new { 
                    ConstantJSON = JsonSerializer.Serialize(entries), 
                    EditableJSON = JsonSerializer.Serialize(entries),
                    ID = BillingID
                });

                if (affectedRows > 0)
                {
                    await LoggingService.AddLog(new()
                    {
                        UserID = UserService.CurrentUser.ID,
                        Type = "Upload",
                        Details = $"User uploaded a report and timekeep data to a billing with ID of {BillingID}."
                    });
                }

                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> UpdateEditableJSON(List<Entry> entries, string billingName)
        {
            try
            {
                using var connection = Database.Connect();
                string QueryUpdate = @"
                    UPDATE Billing SET
                        EditableJSON = @EditableJSON
                    WHERE
                        Name = @BillingName";

                int affectedRows = connection.Execute(QueryUpdate, new
                {
                    EditableJSON = JsonSerializer.Serialize(entries),
                    BillingName = billingName
                });

                if (affectedRows > 0)
                {
                    await LoggingService.AddLog(new()
                    {
                        UserID = UserService.CurrentUser.ID,
                        Type = "Save",
                        Details = $"User saves a verification progress to a billing named as {billingName}."
                    });
                }

                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> UpdateAccrualsJSON(List<AccrualsEntry> accruals, int BillingID)
        {
            try
            {
                using var connection = Database.Connect();
                string QueryUpdate = @"
                    UPDATE Billing SET
                        AccrualsJSON = @AccrualsJSON
                    WHERE
                        ID = @ID";

                int affectedRows = connection.Execute(QueryUpdate, new
                {
                    AccrualsJSON = JsonSerializer.Serialize(accruals),
                    ID = BillingID
                });

                if (affectedRows > 0)
                {
                    await LoggingService.AddLog(new()
                    {
                        UserID = UserService.CurrentUser.ID,
                        Type = "Upload",
                        Details = $"User uploaded accruals data to a billing with ID of {BillingID}."
                    });
                }

                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> UpdateStatusByID(int BillingID, string status)
        {
            try
            {
                using var connection = Database.Connect();
                string QueryUpdate = @"
                    UPDATE Billing SET
                        Status = @Status
                    WHERE
                        ID = @ID";

                int affectedRows = connection.Execute(QueryUpdate, new
                {
                    Status = status,
                    ID = BillingID
                });

                if (affectedRows > 0)
                {
                    await LoggingService.AddLog(new()
                    {
                        UserID = UserService.CurrentUser.ID,
                        Type = MessagesConstants.UPDATE,
                        Details = $"User updated the status of a billing with ID of {BillingID} to {status}."
                    });
                }

                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> UpdateVerificationStatus(int BillingID, string status)
        {
            try
            {
                using var connection = Database.Connect();
                string QueryUpdate = @"
                    UPDATE Billing SET
                        VerificationStatus = @VerificationStatus
                    WHERE
                        ID = @ID";

                int affectedRows = connection.Execute(QueryUpdate, new { 
                    VerificationStatus = status,
                    ID = BillingID
                });

                if (affectedRows > 0)
                {
                    await LoggingService.AddLog(new()
                    {
                        UserID = UserService.CurrentUser.ID,
                        Type = MessagesConstants.UPDATE,
                        Details = $"User updated the verification status of a billing with ID of {BillingID} to {status}."
                    });
                }

                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> UpdateLockStatusByIDAsync(int BillingID, string Status, DateTime ReleaseDate)
        {
            try
            {
                using var context = new Context();

                var billing = await context.Billing.FindAsync(BillingID);

                if (billing == null)
                {
                    return false;
                }

                billing.LockStatus = Status;
                billing.ReleaseDate = ReleaseDate;

                int affectedRows = await context.SaveChangesAsync();

                if (affectedRows > 0)
                {
                    await LoggingService.AddLog(new()
                    {
                        UserID = UserService.CurrentUser.ID,
                        Type = MessagesConstants.UPDATE,
                        Details = $"User locked a billing with an ID of {BillingID}"
                    });
                }

                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> ReleaseBilling(int BillingID, int ClientID, DateTime releaseDate)
        {
            try
            {
                List<Models.Billing.Account> newBillingAccounts = new();
                var accountNumbers = await BillingRecordService.GetAccountNumbersByIDAsync(BillingID);
                var accountsTotalValues = await BillingRecordService.GetGrossBillingAndDepartmentByIDAsync(BillingID);

                foreach (var account in accountNumbers)
                {
                    var matchedAccount = accountsTotalValues.First(f => f.AccountNumber == account);

                    if (matchedAccount == null)
                    {
                        return false;
                    }

                    newBillingAccounts.Add(new()
                    {
                        ClientID = ClientID,
                        BillingID = BillingID,
                        AccountNumber = account,
                        Classification = $"{matchedAccount.Department} {(account.Contains("OT") ? StringConstants.Type.OVERTIME : string.Empty)}".Trim(),
                        BilledValue = matchedAccount.GrossBilling,
                        NetBilling = matchedAccount.GrossBilling - NumericConstants.GetNetBilling(matchedAccount.GrossBilling),
                        Balance = matchedAccount.GrossBilling,
                    });
                }

                if (newBillingAccounts.Count == 0)
                {
                    return false;
                }

                bool hasAdded = await BillingAccountService.AddManyAsync(newBillingAccounts);

                if (hasAdded)
                {
                    bool updateStatus = await BillingRecordService.UpdateStatusByIDAsync(BillingID, StringConstants.Status.RELEASED);
                    bool updateLockStatus = await UpdateLockStatusByIDAsync(BillingID, StringConstants.Status.LOCK, releaseDate);

                    if (updateStatus && updateLockStatus)
                    {
                        await LoggingService.AddLog(new()
                        {
                            UserID = UserService.CurrentUser.ID,
                            Type = "Release",
                            Details = $"User released a billing with ID of {BillingID}."
                        });
                    }

                    return updateStatus && updateLockStatus;
                }

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }
    }
}
