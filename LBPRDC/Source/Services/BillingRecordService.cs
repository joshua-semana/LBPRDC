using Dapper;
using LBPRDC.Source.Data;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LBPRDC.Source.Services
{
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

    internal class BillingRecordService
    {
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

        public static List<BillingRecord> GetAllBillingsByEmployeeID(string employeeID)
        {
            List<BillingRecord> records = new();
            try
            {
                using var connection = Database.Connect();

                string QuerySelect = @"
                    SELECT
                        EntryType,
                        Position,
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
                        UserRemarks,
                        RegularAdjustmentRemarks,
                        OvertimeAdjustmentRemarks,
                        Description,
                        Status,
                        Timestamp
                    FROM
                        BillingRecord
                    WHERE
                        EmployeeID = @EmployeeID";

                records = connection.Query<BillingRecord>(QuerySelect, new
                {
                    EmployeeID = employeeID
                }).ToList();
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

        public static bool Add(string billingName, List<BillingRecord> billingRecords)
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

        public static bool UpdateCollectionDates(BillingRecord record, string type)
        {
            try
            {
                using var connection = Database.Connect();
                using var transaction = connection?.BeginTransaction();
                try
                {
                    string QueryUpdate = @$"
                        UPDATE BillingRecord SET 
                            {type}CollectedDate = @{type}CollectedDate
                        WHERE 
                            BillingName = @BillingName AND {type}AccountNumber = @{type}AccountNumber";

                    connection.Execute(QueryUpdate, record, transaction);

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

        public static bool RemoveRecordsByGuid(List<Guid> recordGuid) // USED FOR REMOVING CUSTOM ENTRY WHEN REMOVED IN THE ADJUSTMENT FORM
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
    }
}
