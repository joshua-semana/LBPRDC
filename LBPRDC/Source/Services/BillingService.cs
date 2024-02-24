using Dapper;
using LBPRDC.Source.Data;
using System.Collections.Specialized;
using System.Globalization;
using System.Text.Json;
using static LBPRDC.Source.Services.BillingAccountService;

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

    public class BillingBase
    {
        public int ID { get; set; }
    }

    public class Billing : BillingBase
    {
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

        public static int GetItemCountByName(string name)
        {
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
                        Name LIKE @Name";

                totalCount = connection.QueryFirstOrDefault<int>(QueryCount, new { Name = name });
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return totalCount;
        }

        public static string GetNewBillingNameForDuplication(string name)
        {
            string newName = "";

            try
            {
                using var connection = Database.Connect();

                string QuerySelect = @"
                    SELECT 
                        Name 
                    FROM 
                        Billing";

                List<string> namesList = connection.Query<string>(QuerySelect).ToList();

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

        public static (List<BillingView>, int TotalCount) GetFilteredItems(string searchWord)
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
                        Status = 'Active'";

                totalCount = connection.QueryFirstOrDefault<int>(QueryCount);

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
                        Billing.UserID = Users.UserID 
                    WHERE 
                        Billing.Status = 'Active'";

                if (!string.IsNullOrEmpty(searchWord))
                {
                    QuerySelect += @" AND (Billing.Name LIKE @SearchWord OR Users.FirstName + ' ' + Users.LastName LIKE @SearchWord)";
                }

                QuerySelect += " ORDER BY Timestamp DESC";

                billings = connection.Query<BillingView>(QuerySelect, new { SearchWord = $"%{searchWord}%" }).ToList();

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
                        billing.FormattedStartDate = billing.StartDate.ToString("MMMM dd, yyyy");
                        billing.FormattedEndDate = billing.EndDate.ToString("MMMM dd, yyyy");
                        billing.LockStatus = (billing.LockStatus == "Lock") ? "🔒" : "🔓";
                    }
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return (billings, totalCount);
        }

        public static (List<Entry>, List<Entry>) GetConstantAndEditableJSON(string billingName)
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
                        Name = @BillingName";

                var billing = connection.QueryFirstOrDefault<Billing>(QuerySelect, new
                {
                    BillingName = billingName
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

        public static bool Add(Billing data)
        {
            try
            {
                using var connection = Database.Connect();
                using var transaction = connection?.BeginTransaction();
                
                try
                {
                    string QueryInsert = @"
                    INSERT INTO Billing (
                        UserID, 
                        Name, 
                        OfficerName,
                        OfficerPosition,
                        Month,
                        Year,
                        Quarter,
                        StartDate,
                        EndDate,
                        Timestamp,
                        ReleaseDate,
                        ConstantJSON,
                        EditableJSON,
                        AccrualsJSON,
                        VerificationStatus,
                        IsEquipmentIncluded,
                        Description, 
                        Status,
                        LockStatus
                    ) 
                    VALUES (
                        @UserID, 
                        @Name, 
                        @OfficerName,
                        @OfficerPosition,
                        @Month,
                        @Year,
                        @Quarter,
                        @StartDate,
                        @EndDate,
                        @Timestamp,
                        @ReleaseDate,
                        @ConstantJSON,
                        @EditableJSON,
                        @AccrualsJSON,
                        @VerificationStatus,
                        @IsEquipmentIncluded,
                        @Description, 
                        @Status,
                        @LockStatus
                    )";

                    int affectedRows = connection.Execute(QueryInsert, data, transaction);

                    transaction?.Commit();

                    if (affectedRows > 0)
                    {
                        LoggingService.LogActivity(new()
                        {
                            UserID = UserService.CurrentUser.UserID,
                            ActivityType = "New Billing",
                            ActivityDetails = $"User added a new billing record with a name of {data.Name}."
                        });
                    }

                    return (affectedRows > 0);
                }

                catch (Exception ex)
                {
                    transaction.Rollback();
                    return false;
                }
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static bool UpdateConstantAndEditableJSON(List<Entry> entries, string billingName)
        {
            try
            {
                using var connection = Database.Connect();
                string QueryUpdate = @"
                    UPDATE Billing SET
                        ConstantJSON = @ConstantJSON,
                        EditableJSON = @EditableJSON
                    WHERE
                        Name = @BillingName";

                int affectedRows = connection.Execute(QueryUpdate, new { 
                    ConstantJSON = JsonSerializer.Serialize(entries), 
                    EditableJSON = JsonSerializer.Serialize(entries),
                    BillingName = billingName
                });

                if (affectedRows > 0)
                {
                    LoggingService.LogActivity(new()
                    {
                        UserID = UserService.CurrentUser.UserID,
                        ActivityType = "Upload",
                        ActivityDetails = $"User uploaded a report and timekeep data to a billing named as {billingName}."
                    });
                }

                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static bool UpdateEditableJSON(List<Entry> entries, string billingName)
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
                    LoggingService.LogActivity(new()
                    {
                        UserID = UserService.CurrentUser.UserID,
                        ActivityType = "Save",
                        ActivityDetails = $"User saves a verification progress to a billing named as {billingName}."
                    });
                }

                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static bool UpdateAccrualsJSON(List<AccrualsEntry> accruals, string billingName)
        {
            try
            {
                using var connection = Database.Connect();
                string QueryUpdate = @"
                    UPDATE Billing SET
                        AccrualsJSON = @AccrualsJSON
                    WHERE
                        Name = @BillingName";

                int affectedRows = connection.Execute(QueryUpdate, new
                {
                    AccrualsJSON = JsonSerializer.Serialize(accruals),
                    BillingName = billingName
                });

                if (affectedRows > 0)
                {
                    LoggingService.LogActivity(new()
                    {
                        UserID = UserService.CurrentUser.UserID,
                        ActivityType = "Upload",
                        ActivityDetails = $"User uploaded accruals data to a billing named as {billingName}."
                    });
                }

                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static bool UpdateStatus(string billingName, string status)
        {
            try
            {
                using var connection = Database.Connect();
                string QueryUpdate = @"
                    UPDATE Billing SET
                        Status = @Status
                    WHERE
                        Name = @BillingName";

                int affectedRows = connection.Execute(QueryUpdate, new
                {
                    Status = status,
                    BillingName = billingName
                });

                if (affectedRows > 0)
                {
                    LoggingService.LogActivity(new()
                    {
                        UserID = UserService.CurrentUser.UserID,
                        ActivityType = "Update",
                        ActivityDetails = $"User updated the status of a billing named as {billingName} to {status}."
                    });
                }

                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static bool UpdateInformation(Billing billing)
        {
            try
            {
                using var connection = Database.Connect();
                string QueryUpdate = @"
                    UPDATE Billing SET
                        Description = @Description,
                        OfficerName = @OfficerName,
                        OfficerPosition = @OfficerPosition,
                        IsEquipmentIncluded = @IsEquipmentIncluded
                    WHERE
                        Name = @BillingName";

                int affectedRows = connection.Execute(QueryUpdate, new
                {
                    Description = billing.Description ?? "",
                    OfficerName = billing.OfficerName ?? "",
                    OfficerPosition = billing.OfficerPosition ?? "",
                    billing.IsEquipmentIncluded,
                    BillingName = billing.Name
                });

                if (affectedRows > 0)
                {
                    LoggingService.LogActivity( new()
                    {
                        UserID = UserService.CurrentUser.UserID,
                        ActivityType = "Update",
                        ActivityDetails = $"User updated the information of billing '{billing.Name}'."
                    });
                }

                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static bool UpdateVerificationStatus(string billingName, string status)
        {
            try
            {
                using var connection = Database.Connect();
                string QueryUpdate = @"
                    UPDATE Billing SET
                        VerificationStatus = @VerificationStatus
                    WHERE
                        Name = @BillingName";

                int affectedRows = connection.Execute(QueryUpdate, new { 
                    VerificationStatus = status,
                    BillingName = billingName
                });

                if (affectedRows > 0)
                {
                    LoggingService.LogActivity(new()
                    {
                        UserID = UserService.CurrentUser.UserID,
                        ActivityType = "Update",
                        ActivityDetails = $"User updated the verification status of a billing named as {billingName} to {status}."
                    });
                }

                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static bool UpdateLockStatus(string billingName, string lockStatus, DateTime releaseDate)
        {
            try
            {
                using var connection = Database.Connect();
                string QueryUpdate = @"
                    UPDATE Billing SET
                        ReleaseDate = @ReleaseDate,
                        LockStatus = @LockStatus
                    WHERE
                        Name = @BillingName";

                int affectedRows = connection.Execute(QueryUpdate, new
                {
                    ReleaseDate = releaseDate,
                    LockStatus = lockStatus,
                    BillingName = billingName
                });

                if (affectedRows > 0)
                {
                    LoggingService.LogActivity(new()
                    {
                        UserID = UserService.CurrentUser.UserID,
                        ActivityType = "Update",
                        ActivityDetails = $"User updated the lock status of a billing named as {billingName} to {lockStatus}."
                    });
                }

                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static bool ReleaseBilling(string billingName, DateTime releaseDate)
        {
            try
            {
                List<BillingAccount> newBillingAccounts = new();
                List<string> accountNumbers = BillingRecordService.GetAccountNumbersByName(billingName);
                List<AccountsDetails> accountsTotalValues = BillingRecordService.GetGrossBillingAndDepartmentByName(billingName);

                foreach (var account in accountNumbers)
                {
                    var matchedAccount = accountsTotalValues.First(f => f.AccountNumber == account);
                    if (matchedAccount != null)
                    {
                        newBillingAccounts.Add(new()
                        {
                            BillingName = billingName,
                            AccountNumber = account,
                            EntryType = "Regular Entry",
                            OfficialReceiptNumber = "",
                            Classification = $"{matchedAccount.Department} {(account.Contains("OT") ? "OVERTIME" : string.Empty)}".Trim(),
                            BilledValue = matchedAccount.GrossBilling,
                            NetBilling = matchedAccount.GrossBilling - Convert.ToDecimal((double)matchedAccount.GrossBilling / 1.12 * 0.07),
                            CollectedValue = 0,
                            CollectionDate = null,
                            Balance = matchedAccount.GrossBilling,
                            Purpose = "",
                            Timestamp = DateTime.Now,
                            Remarks = ""
                        });
                    }
                    else
                    {
                        return false;
                    }
                }

                if (newBillingAccounts.Count > 0)
                {
                    bool hasAdded = BillingAccountService.Add(newBillingAccounts, billingName);

                    if (hasAdded)
                    {
                        bool updateStatus = BillingRecordService.UpdateRecordsStatus(billingName, "Released");
                        bool updateLockStatus = UpdateLockStatus(billingName, "Lock", releaseDate);

                        if (updateStatus && updateLockStatus)
                        {
                            LoggingService.LogActivity(new()
                            {
                                UserID = UserService.CurrentUser.UserID,
                                ActivityType = "Release",
                                ActivityDetails = $"User released a billing named {billingName}."
                            });
                        }

                        return updateStatus && updateLockStatus;
                    }
                }
                else
                {
                    return false;
                }

                return (newBillingAccounts.Count > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }
    }
}
