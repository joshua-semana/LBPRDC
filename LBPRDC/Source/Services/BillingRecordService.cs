using Dapper;
using LBPRDC.Source.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static LBPRDC.Source.Data.Database;
using LBPRDC.Source.Config;
using System.ComponentModel;
using static LBPRDC.Source.Models.Billing;

namespace LBPRDC.Source.Services
{
    public class BillingRecord : EmployeeBase
    {
        public int BillingID { get; set; }
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

    internal class BillingRecordService
    {
        // Entity Frameworks

        public static async Task<List<string>> GetAccountNumbersByIDAsync(int BillingID)
        {
            List<string> accountsList = new();

            try
            {
                using var context = new Context();

                var regularAccounts = await context.BillingRecord
                    .Where(br => !string.IsNullOrEmpty(br.RegularAccountNumber) && br.BillingID == BillingID)
                    .Select(br => br.RegularAccountNumber)
                    .Distinct()
                    .ToListAsync();

                var overtimeAccounts = await context.BillingRecord
                    .Where(br => !string.IsNullOrEmpty(br.OvertimeAccountNumber) && br.BillingID == BillingID)
                    .Select(br => br.OvertimeAccountNumber)
                    .Distinct()
                    .ToListAsync();

                accountsList.AddRange(regularAccounts);
                accountsList.AddRange(overtimeAccounts);
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return accountsList;
        }

        public static async Task<List<Models.Billing.AccountsWithType>> GetAccountsWithTypeByBillingID(int BillingID)
        {
            List<Models.Billing.AccountsWithType> accountsWithTypeList = new();

            try
            {
                using var context = new Context();

                var regularAccountsQuery = await context.BillingRecord
                    .Where(b => b.RegularAccountNumber != "" && b.BillingID == BillingID)
                    .Select(b => new Models.Billing.AccountsWithType
                    {
                        AccountNumber = b.RegularAccountNumber,
                        //EntryType = b.EntryType
                        EntryType = StringConstants.Type.REGULAR
                    })
                    .Distinct()
                    .ToListAsync();

                var overtimeAccountsQuery = await context.BillingRecord
                    .Where(b => b.OvertimeAccountNumber != "" && b.BillingID == BillingID)
                    .Select(b => new Models.Billing.AccountsWithType
                    {
                        AccountNumber = b.OvertimeAccountNumber,
                        //EntryType = b.EntryType
                        EntryType = StringConstants.Type.REGULAR
                    })
                    .Distinct()
                    .ToListAsync();;

                accountsWithTypeList.AddRange(regularAccountsQuery);
                accountsWithTypeList.AddRange(overtimeAccountsQuery);

                //var accountsWithTypeQuery = regularAccountsQuery.Union(overtimeAccountsQuery);
                //accountsWithTypeList = await accountsWithTypeQuery.ToListAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return accountsWithTypeList;
        }

        public static async Task<bool> RemoveRecordsByID(int BillingID) // THIS IS FOR OVERWRITING THE BILLING's TIMEKEEP FILE
        {
            try
            {
                using var context = new Context();
                var recordsToDelete = await context.BillingRecord
                    .Where(br => br.BillingID == BillingID)
                    .ToListAsync();

                if (recordsToDelete.Any())
                {
                    context.BillingRecord.RemoveRange(recordsToDelete);
                    await context.SaveChangesAsync();
                }

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<List<Models.Billing.Record.View>> GetAllBillingRecordInfoByIDs(int ClientID, string EmployeeID)
        {
            List<Models.Billing.Record.View> records = new();
            try
            {
                using var context = new Context();

                records = await context.BillingRecord
                    .Where(br => br.ClientID == ClientID && br.EmployeeID == EmployeeID)
                    .Select(br => new Models.Billing.Record.View {
                        ID = br.ID,
                        ClientID = br.ClientID,
                        BillingID = br.BillingID,
                        Guid = br.Guid,
                        EntryType = br.EntryType,
                        EmployeeID = br.EmployeeID,
                        FullName = br.FullName,
                        Position = br.Position,
                        Department = br.Department,
                        SalaryRate = br.SalaryRate,
                        BillingRate = br.BillingRate,
                        TimeDetailJSON = br.TimeDetailJSON,
                        RegularAccountNumber = br.RegularAccountNumber,
                        OvertimeAccountNumber = br.OvertimeAccountNumber,
                        RegularBillingValue = br.RegularBillingValue,
                        OvertimeBillingValue = br.OvertimeBillingValue,
                        RegularCollectedValue = br.RegularCollectedValue,
                        OvertimeCollectedValue = br.OvertimeCollectedValue,
                        RegularCollectedDate = br.RegularCollectedDate,
                        OvertimeCollectedDate = br.OvertimeCollectedDate,
                        TimekeepRemarks = br.TimekeepRemarks,
                        UserRemarks = br.UserRemarks,
                        RegularAdjustmentRemarks = br.RegularAdjustmentRemarks,
                        OvertimeAdjustmentRemarks = br.OvertimeAdjustmentRemarks,
                        Description = br.Description,
                        Status = br.Status,
                        Timestamp = br.Timestamp,
                        BillingName = br.Billing.Name
                    })
                    .ToListAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return records;
        }

        public static async Task<List<Models.Billing.Record>> GetRecordsByBillingId(int BillingID)
        {
            List<Models.Billing.Record> records = new();
            try
            {
                using var context = new Context();

                records = await context.BillingRecord
                    .Where(br => br.BillingID == BillingID)
                    .ToListAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return records;
        }

        public static async Task<List<Models.Billing.Record.TotalGross>> GetGrossBillingAndDepartmentByIDAsync(int BillingID)
        {
            List<Models.Billing.Record.TotalGross> totalDetails = new();

            try
            {
                using var context = new Context();

                var regularTotals = await context.BillingRecord
                    .Where(br => br.BillingID == BillingID && !string.IsNullOrEmpty(br.RegularAccountNumber))
                    .GroupBy(br => new
                    {
                        AccountNumber = br.RegularAccountNumber,
                        Department = br.Department
                    })
                    .Select(group => new Models.Billing.Record.TotalGross
                    {
                        AccountNumber = group.Key.AccountNumber,
                        Department = group.Key.Department,
                        GrossBilling = group.Sum(br => br.RegularBillingValue)
                    })
                    .ToListAsync();

                var overtimeTotals = await context.BillingRecord
                    .Where(br => br.BillingID == BillingID && !string.IsNullOrEmpty(br.OvertimeAccountNumber))
                    .GroupBy(br => new
                    {
                        AccountNumber = br.OvertimeAccountNumber,
                        Department = br.Department
                    })
                    .Select(group => new Models.Billing.Record.TotalGross
                    {
                        AccountNumber = group.Key.AccountNumber,
                        Department = group.Key.Department,
                        GrossBilling = group.Sum(br => br.OvertimeBillingValue)
                    })
                    .ToListAsync();

                totalDetails.AddRange(regularTotals);
                totalDetails.AddRange(overtimeTotals);
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return totalDetails ;
        }

        public static async Task<bool> UpdateStatusByIDAsync(int BillingID, string Status)
        {
            try
            {
                using var context = new Context();

                var recordsToUpdate = await context.BillingRecord
                    .Where(br => br.BillingID == BillingID)
                    .ToListAsync();

                foreach (var record in recordsToUpdate)
                {
                    record.Status = Status;
                }

                int affectedRows = await context.SaveChangesAsync();

                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> UpdateCollectedValuesAsync(List<Models.Billing.Record> Records, string Type)
        {
            try
            {
                using var connection = Database.Connect();
                using var transaction = connection?.BeginTransaction();
                try
                {
                    string QueryUpdate = @$"
                    UPDATE BillingRecord SET
                        {Type}CollectedValue = @{Type}CollectedValue
                    WHERE
                        BillingID = @BillingID AND {Type}AccountNumber = @{Type}AccountNumber AND Guid = @Guid";

                    await connection.ExecuteAsync(QueryUpdate, Records, transaction);

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




























        public static List<BillingRecord> GetRecordsByBillingName(string billingName)
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

        public static List<BillingRecord> GetRecordsByAccount(string billingName, string accountNumber)
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

        public static List<BillingRecord> GetUnreleasedRecords(int BillingID)
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
                        Status = @Status AND BillingID = @BillingID";

                records = connection.Query<BillingRecord>(QuerySelect, new
                {
                    Status = StringConstants.Status.UNRELEASED,
                    BillingID
                }).ToList();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return records;
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

        public static List<AccountsDetails> GetGrossBillingAndDepartmentByName(int BillingID)
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
                        BillingID = @BillingID
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
                        BillingID = @BillingID
                    GROUP BY
                        OvertimeAccountNumber,
                        Department
                    HAVING
                        OvertimeAccountNumber IS NOT NULL AND OvertimeAccountNumber != ''";
                using var connection = Database.Connect();
                accountsDetails = connection.Query<AccountsDetails>(QuerySelect, new { BillingID }).ToList();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return accountsDetails;
        }

        public static List<Guid> GetGuids()
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

        public static bool Add(int BillingID, string billingName, List<BillingRecord> billingRecords)
        {
            var existingRecords = GetUnreleasedRecords(BillingID);

            try
            {
                string QueryInsert = @"
                    INSERT INTO BillingRecord (
                        ClientID,
                        BillingID,
                        Guid,
                        EmployeeID,
                        FullName,
                        EntryType,
                        Position,
                        Department,
                        TimeDetailJSON,
                        SalaryRate,
                        BillingRate,
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
                    ) VALUES (
                        @ClientID,
                        @BillingID,
                        @Guid,
                        @EmployeeID,
                        @FullName,
                        @EntryType,
                        @Position,
                        @Department,
                        @TimeDetailJSON,
                        @SalaryRate,
                        @BillingRate,
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

        public static bool UpdateCollectedValues(List<BillingRecord> employeeRecord, string type)
        {
            try
            {
                using var connection = Database.Connect();
                using var transaction = connection?.BeginTransaction();
                try
                {
                    string QueryUpdate = @$"
                    UPDATE BillingRecord SET
                        {type}CollectedValue = @{type}CollectedValue
                    WHERE
                        BillingName = @BillingName AND {type}AccountNumber = @{type}AccountNumber AND Guid = @Guid";

                    connection.Execute(QueryUpdate, employeeRecord, transaction);

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

        public static bool UpdateRecordsStatus(string billingName, string status)
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

        public static async Task<bool> UpdateCollectionDatesAsync(Models.Billing.Record Record, string Type)
        {
            try
            {
                int affectedRows = 0;
                using var context = new Context(); 

                if (Type == StringConstants.Type.REGULAR)
                {
                    var records = await context.BillingRecord
                        .Where(br => br.BillingID == Record.BillingID && br.RegularAccountNumber == Record.RegularAccountNumber)
                        .ToListAsync();

                    foreach (var record in records)
                    {
                        record.RegularCollectedDate = Record.RegularCollectedDate;
                    }

                    affectedRows = await context.SaveChangesAsync();
                }
                else if (Type == StringConstants.Type.OVERTIME)
                {
                    var records = await context.BillingRecord
                        .Where(br => br.BillingID == Record.BillingID && br.OvertimeAccountNumber == Record.OvertimeAccountNumber)
                        .ToListAsync();

                    foreach (var record in records)
                    {
                        record.OvertimeCollectedDate = Record.OvertimeCollectedDate;
                    }

                    affectedRows = await context.SaveChangesAsync();
                }

                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static bool RemoveRecordsByBillingName(string billingName) // THIS IS FOR OVERWRITING THE BILLING's TIMEKEEP FILE
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

        public static async Task<bool> RemoveRecordsByGuid(List<Guid> recordGuid, int BillingID) // USED FOR REMOVING CUSTOM ENTRY WHEN REMOVED IN THE ADJUSTMENT FORM
        {
            try
            {
                using var context = new Context();

                var entriesToRemove = await context.BillingRecord
                    .Where(br => recordGuid.Contains(br.Guid) && br.BillingID == BillingID)
                    .ToListAsync();

                context.BillingRecord.RemoveRange(entriesToRemove);

                var affectedRows = await context.SaveChangesAsync();

                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }
    }
}
