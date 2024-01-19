using Dapper;
using LBPRDC.Source.Data;
using System.Collections.Immutable;
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
        public string? Description { get; set; }
        public string? Status { get; set; } // Active, Inactive (For Archive)
        public string? LockStatus { get; set; } // Lock, Unlock (If billing is released, lock the billing)
    }

    public class BillingRecord : EmployeeBase
    {
        public int ID { get; set; }
        public Guid Guid { get; set; }
        public string? EntryType { get; set; } // Regular Entry or Custom Entry
        public string? TimeDetailJSON { get; set; }
        public string? BillingName { get; set; }
        public string? RegularAccountNumber { get; set; }
        public string? OvertimeAccountNumber { get; set; }
        public decimal RegularBillingValue { get; set; }
        public decimal OvertimeBillingValue { get; set; }
        public decimal RegularCollectedValue { get; set; }
        public decimal OvertimeCollectedValue { get; set; }
        public DateTime? RegularCollectedDate { get; set; }
        public DateTime? OvertimeCollectedDate { get; set; }
        public string? TimekeepRemarks { get; set; }
        public string? UserRemarks { get; set; }
        public string? RegularAdjustmentRemarks { get; set; }
        public string? OvertimeAdjustmentRemarks { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; } // Unreleased and Released
        public DateTime Timestamp { get; set; }
    }

    public class BillingAccount
    {
        public int ID { get; set; }
        public string? BillingName { get; set; }
        public string? AccountNumber { get; set; }
        public int OfficialReceiptNumber { get; set; }
        public string? Department { get; set; }
        public decimal? BilledValue { get; set; }
        public decimal? NetBilling { get; set; }
        public decimal? CollectedValue { get; set; }
        public DateTime? CollectionDate { get; set; }
        public DateTime Timestamp { get; set; }
        public string? Remarks { get; set; }
    }

    public class AccountsDetails
    {
        public string? AccountNumber { get; set; }
        public string? Department { get; set; }
        public decimal GrossBilling { get; set; }
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

        public static Billing GetSpecificBillingDetailsByName(string billingName) // FOR BILLING INFORMATION WHEN USER CLICKS "VIEW DETAILS" BUTTON
        {
            Billing billing = new();

            try
            {
                using var connection = Database.Connect();

                string QuerySelect = @"
                    SELECT 
                        Timestamp,
                        ReleaseDate,
                        Description,
                        OfficerName, 
                        OfficerPosition 
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
                        Name = @Name";

                totalCount = connection.QueryFirstOrDefault<int>(QueryCount, new { Name = name });
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return totalCount;
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

        public static bool Add(Billing data)
        {
            try
            {
                using var connection = Database.Connect();
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
                        @Description, 
                        @Status,
                        @LockStatus
                    )";

                int affectedRows = connection.Execute(QueryInsert, data);

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
                        OfficerPosition = @OfficerPosition
                    WHERE
                        Name = @BillingName";

                int affectedRows = connection.Execute(QueryUpdate, new
                {
                    Description = billing.Description ?? "",
                    OfficerName = billing.OfficerName ?? "",
                    OfficerPosition = billing.OfficerPosition ?? "",
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
                List<string> accountNumbers = GetAccountNumbersByName(billingName);
                List<AccountsDetails> accountsTotalValues = GetGrossBillingAndDepartmentByName(billingName);

                foreach (var account in accountNumbers)
                {
                    var matchedAccount = accountsTotalValues.First(f => f.AccountNumber == account);
                    if (matchedAccount != null)
                    {
                        newBillingAccounts.Add(new()
                        {
                            BillingName = billingName,
                            AccountNumber = account,
                            OfficialReceiptNumber = -1,
                            Department = matchedAccount.Department,
                            BilledValue = matchedAccount.GrossBilling,
                            NetBilling = matchedAccount.GrossBilling - Convert.ToDecimal((double)matchedAccount.GrossBilling / 1.12 * 0.07),
                            CollectedValue = -1,
                            CollectionDate = null,
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
                    bool hasAdded = AddBillingAccounts(newBillingAccounts, billingName);

                    if (hasAdded)
                    {
                        bool updateStatus = UpdateBillingRecordsStatus(billingName, "Released");
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

                return (newBillingAccounts.Count > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        // BILLING ACCOUNTS

        public static bool AddBillingAccounts(List<BillingAccount> accounts, string billingName)
        {
            try
            {
                using var connection = Database.Connect();
                using var transaction = connection?.BeginTransaction();

                try
                {
                    string QueryInsert = @"
                        INSERT INTO BillingAccounts (
                            BillingName, 
                            AccountNumber, 
                            OfficialReceiptNumber, 
                            Department,
                            BilledValue,
                            NetBilling, 
                            CollectedValue, 
                            CollectionDate, 
                            Timestamp, 
                            Remarks
                        )
                        VALUES (
                            @BillingName, 
                            @AccountNumber, 
                            @OfficialReceiptNumber, 
                            @Department,
                            @BilledValue,
                            @NetBilling, 
                            @CollectedValue, 
                            @CollectionDate, 
                            @Timestamp, 
                            @Remarks
                        )";

                    int affectedRows = connection.Execute(QueryInsert, accounts, transaction);
                    transaction?.Commit();

                    if (affectedRows > 0)
                    {
                        LoggingService.LogActivity(new()
                        {
                            UserID = UserService.CurrentUser.UserID,
                            ActivityType = "Release",
                            ActivityDetails = $"User added accounts for a billing named {billingName}."
                        });
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

        public static bool UpdateBillingAccountInformation(BillingAccount accountInfo)
        {
            try
            {
                using var connection = Database.Connect();

                string QueryUpdate = @"
                    UPDATE BillingAccounts SET
                        CollectedValue = @CollectedValue,
                        OfficialReceiptNumber = @OfficialReceiptNumber,
                        CollectionDate = @CollectionDate,
                        Remarks = @Remarks
                    WHERE
                        BillingName = @BillingName AND AccountNumber = @AccountNumber";

                int affectedRows = connection.Execute(QueryUpdate, accountInfo);

                if (affectedRows > 0)
                {
                    LoggingService.LogActivity(new()
                    {
                        UserID = UserService.CurrentUser.UserID,
                        ActivityType = "Collect SOA",
                        ActivityDetails = $"User has updated the information of a statement of account: {accountInfo.AccountNumber} under billing: {accountInfo.BillingName}"
                    });
                }

                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static BillingAccount? GetAccountDetails(string accountNumber, string billingName)
        {
            BillingAccount? billingAccount = new();

            try
            {
                using var connection = Database.Connect();

                string QuerySelect = @"
                    SELECT * 
                    FROM 
                        BillingAccounts 
                    WHERE 
                        AccountNumber = @AccountNumber AND BillingName = @BillingName";

                billingAccount = connection.QueryFirstOrDefault<BillingAccount>(QuerySelect, new
                {
                    AccountNumber = accountNumber,
                    BillingName = billingName
                });
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return billingAccount;
        }

        public static List<string> GetAccountNumbersByName(string billingName)
        {
            List<string> accountNumberList = new();

            try
            {
                using var connection = Database.Connect();

                string QuerySelect = @"
                    SELECT
                        RegularAccountNumber
                    FROM
                        BillingRecord
                    WHERE
                        RegularAccountNumber IS NOT NULL AND RegularAccountNumber <> ''
                        AND BillingName = @BillingName
                    UNION
                    SELECT
                        OvertimeAccountNumber
                    FROM
                        BillingRecord
                    WHERE
                        OvertimeAccountNumber IS NOT NULL AND OvertimeAccountNumber <> ''
                        AND BillingName = @BillingName";

                accountNumberList = connection.Query<string>(QuerySelect, new { BillingName = billingName }).ToList();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return accountNumberList;
        }

        public static List<BillingRecord> GetBillingRecordsByAccount(string billingName, string accountNumber)
        {
            List<BillingRecord> records = new();
            try
            {
                using var connection = Database.Connect();

                string QuerySelect = @"
                    SELECT *
                    FROM
                        BillingRecord
                    WHERE
                        BillingName = @BillingName
                        AND (RegularAccountNumber = @AccountNumber OR OvertimeAccountNumber = @AccountNumber)";

                records = connection.Query<BillingRecord>(QuerySelect, new
                {
                    BillingName = billingName,
                    AccountNumber = accountNumber
                }).ToList();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return records;
        }

        public static List<AccountsDetails> GetGrossBillingAndDepartmentByName(string billingName)
        {
            List<AccountsDetails> accountsDetails = new();

            try
            {
                string QuerySelect = @"
                    SELECT
                        RegularAccountNumber AS AccountNumber,
                        Department,
                        SUM(RegularBillingValue) AS GrossBilling
                    FROM
                        BillingRecord
                    WHERE
                        BillingName = @BillingName
                    GROUP BY
                        RegularAccountNumber,
                        Department
                    HAVING
                        RegularAccountNumber IS NOT NULL AND RegularAccountNumber != ''
                    UNION
                    SELECT
                        OvertimeAccountNumber AS AccountNumber,
                        Department,
                        SUM(OvertimeBillingValue) AS GrossBilling
                    FROM
                        BillingRecord
                    WHERE
                        BillingName = @BillingName
                    GROUP BY
                        OvertimeAccountNumber,
                        Department
                    HAVING
                        OvertimeAccountNumber IS NOT NULL AND OvertimeAccountNumber != ''";
                using var connection = Database.Connect();
                accountsDetails = connection.Query<AccountsDetails>(QuerySelect, new { BillingName = billingName }).ToList();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return accountsDetails;
        }

        public static List<Guid> GetBillingRecordGuids()
        {
            List<Guid> guidList = new();

            try
            {
                string QuerySelect = "SELECT Guid FROM BillingRecord";
                using var connection = Database.Connect();
                guidList = connection.Query<Guid>(QuerySelect).ToList();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return guidList;
        }

        public static List<BillingRecord> GetBillingRecordsByBillingName(string billingName)
        {
            List<BillingRecord> records = new();

            try
            {
                using var connection = Database.Connect();

                string QuerySelect = @"
                    SELECT 
                        EmployeeID, 
                        FullName,
                        Position, 
                        Department, 
                        BillingRate,
                        RegularBillingValue, 
                        OvertimeBillingValue, 
                        UserRemarks, 
                        RegularAdjustmentRemarks,
                        OvertimeAdjustmentRemarks, 
                        Description 
                    FROM 
                        BillingRecord 
                    WHERE 
                        BillingName = @BillingName";

                records = connection.Query<BillingRecord>(QuerySelect, new { BillingName = billingName }).ToList();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return records;
        }

        public static List<BillingRecord> GetUnreleasedRecords(string billingName)
        {
            List<BillingRecord> records = new();
            try
            {
                using var connection = Database.Connect();

                string QuerySelect = @"
                    SELECT 
                        ID, 
                        Guid 
                    FROM 
                        BillingRecord 
                    WHERE 
                        Status = @Status AND BillingName = @BillingName";

                records = connection.Query<BillingRecord>(QuerySelect, new
                {
                    Status = "Unreleased",
                    BillingName = billingName
                }).ToList();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return records;
        }

        public static bool AddBillingRecords(string billingName, List<BillingRecord> billingRecords)
        {
            var existingRecords = GetUnreleasedRecords(billingName);

            try
            {
                string QueryInsert = @"
                    INSERT INTO BillingRecord (
                        Guid,
                        EmployeeID,
                        FullName,
                        EntryType,
                        Position,
                        Department,
                        TimeDetailJSON,
                        SalaryRate,
                        BillingRate,
                        BillingName,
                        RegularAccountNumber,
                        OvertimeAccountNumber,
                        RegularBillingValue,
                        OvertimeBillingValue,
                        RegularCollectedValue,
                        OvertimeCollectedValue,
                        RegularCollectedDate,
                        OvertimeCollectedDate,
                        TimekeepRemarks,
                        UserRemarks,
                        RegularAdjustmentRemarks,
                        OvertimeAdjustmentRemarks,
                        Description,
                        Status,
                        Timestamp
                    ) 
                    VALUES (
                        @Guid,
                        @EmployeeID,
                        @FullName,
                        @EntryType,
                        @Position,
                        @Department,
                        @TimeDetailJSON,
                        @SalaryRate,
                        @BillingRate,
                        @BillingName,
                        @RegularAccountNumber,
                        @OvertimeAccountNumber,
                        @RegularBillingValue,
                        @OvertimeBillingValue,
                        @RegularCollectedValue,
                        @OvertimeCollectedValue,
                        @RegularCollectedDate,
                        @OvertimeCollectedDate,
                        @TimekeepRemarks,
                        @UserRemarks,
                        @RegularAdjustmentRemarks,
                        @OvertimeAdjustmentRemarks,
                        @Description,
                        @Status,
                        @Timestamp
                    )";

                string QueryUpdate = @"
                    UPDATE BillingRecord SET 
                        EmployeeID = @EmployeeID,
                        FullName = @FullName,
                        EntryType = @EntryType,
                        Position = @Position,
                        Department = @Department,
                        TimeDetailJSON = @TimeDetailJSON,
                        SalaryRate = @SalaryRate,
                        BillingRate = @BillingRate,
                        BillingName = @BillingName,
                        RegularAccountNumber = @RegularAccountNumber,
                        OvertimeAccountNumber = @OvertimeAccountNumber,
                        RegularBillingValue = @RegularBillingValue,
                        OvertimeBillingValue = @OvertimeBillingValue,
                        RegularCollectedValue = @RegularCollectedValue,
                        OvertimeCollectedValue = @OvertimeCollectedValue,
                        RegularCollectedDate = @RegularCollectedDate,
                        OvertimeCollectedDate = @OvertimeCollectedDate,
                        TimekeepRemarks = @TimekeepRemarks,
                        UserRemarks = @UserRemarks,
                        RegularAdjustmentRemarks = @RegularAdjustmentRemarks,
                        OvertimeAdjustmentRemarks = @OvertimeAdjustmentRemarks,
                        Description = @Description,
                        Status = @Status,
                        Timestamp = @Timestamp
                    WHERE 
                        ID = @ID";

                using var connection = Database.Connect();
                if (connection != null)
                {
                    using SqlTransaction transaction = connection.BeginTransaction();

                    foreach (var record in billingRecords)
                    {
                        var existingRecord = existingRecords.FirstOrDefault(f => f.Guid == record.Guid);
                        if (existingRecord == null)
                        {
                            connection.Execute(QueryInsert, record, transaction);
                        }
                        else
                        {
                            record.ID = existingRecord.ID;
                            connection.Execute(QueryUpdate, record, transaction);
                        }
                    }

                    transaction.Commit();
                    return true;
                }
                return false;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static bool RemoveBillingRecordsByBillingName(string billingName) // THIS IS FOR OVERWRITING THE BILLING's TIMEKEEP FILE
        {
            try
            {
                using var connection = Database.Connect();
                using var transaction = connection?.BeginTransaction();

                try
                {
                    string QueryDelete = @"
                        DELETE FROM 
                            BillingRecord 
                        WHERE 
                            BillingName = @BillingName";

                    connection.Execute(QueryDelete, new { BillingName = billingName }, transaction);

                    transaction?.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction?.Rollback();
                    return false;
                }
                
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static bool RemoveBillingRecordsByGuid(List<Guid> recordGuid) // USED FOR REMOVING CUSTOM ENTRY WHEN REMOVED IN THE ADJUSTMENT FORM
        {
            try
            {
                using var connection = Database.Connect();
                using var transaction = connection?.BeginTransaction();

                try
                {
                    string QueryDelete = @"
                        DELETE FROM 
                            BillingRecord 
                        WHERE 
                            Guid = @Guid";

                    connection.Execute(QueryDelete, new { Guid = recordGuid }, transaction);

                    transaction?.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction?.Rollback();
                    return false;
                }

            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static bool UpdateBillingRecordsStatus(string billingName, string status)
        {
            try
            {
                using var connection = Database.Connect();
                using var transaction = connection?.BeginTransaction();
                try
                {
                    string QueryUpdate = @"
                        UPDATE BillingRecord SET 
                            Status = @Status 
                        WHERE 
                            BillingName = @BillingName";

                    connection.Execute(QueryUpdate, new
                    {
                        Status = status,
                        BillingName = billingName
                    }, transaction);

                    transaction?.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction?.Rollback();
                    return false;
                }
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        // ACCRUALS - BALANCING

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
    }
}
