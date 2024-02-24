using Dapper;
using LBPRDC.Source.Data;

namespace LBPRDC.Source.Services
{
    public class BillingAccount
    {
        public int ID { get; set; }
        public string? BillingName { get; set; }
        public string? AccountNumber { get; set; }
        public string? EntryType { get; set; } // Regular or Custom
        public string? OfficialReceiptNumber { get; set; }
        public string? Classification { get; set; }
        public decimal BilledValue { get; set; }
        public decimal NetBilling { get; set; }
        public decimal CollectedValue { get; set; }
        public DateTime? CollectionDate { get; set; }
        public decimal Balance { get; set; }
        public string? Purpose { get; set; }
        public DateTime Timestamp { get; set; }
        public string? Remarks { get; set; }
    }

    public class AccountsComboBoxDetails
    {
        public string? AccountNumber { get; set; }
        public string? EntryType { get; set; } // Regular Entry or Custom Entry
    }

    public class AccountsDetails
    {
        public string? AccountNumber { get; set; }
        public string? Department { get; set; }
        public decimal GrossBilling { get; set; }
    }

    public class EquipmentAccountDetails
    {
        public string AccountNumber { get; set; } = string.Empty;
        public decimal BilledValue { get; set; }
    }

    internal class BillingAccountService
    {
        public static List<BillingAccount> GetAllByBillingName(string billingName)
        {
            List<BillingAccount> accounts = new();

            try
            {
                using var connection = Database.Connect();

                string QuerySelect = @"
                    SELECT * 
                    FROM 
                        BillingAccounts 
                    WHERE 
                        BillingName = @BillingName";

                accounts = connection.Query<BillingAccount>(QuerySelect, new
                {
                    BillingName = billingName
                }).ToList();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return accounts;
        }

        public static BillingAccount GetDetails(string accountNumber, string billingName)
        {
            BillingAccount billingAccount = new();

            try
            {
                using var connection = Database.Connect();

                string QuerySelect = @"
                    SELECT * 
                    FROM 
                        BillingAccounts 
                    WHERE 
                        AccountNumber = @AccountNumber AND BillingName = @BillingName";

                billingAccount = connection.QueryFirst<BillingAccount>(QuerySelect, new
                {
                    AccountNumber = accountNumber,
                    BillingName = billingName
                });
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return billingAccount;
        }

        public static EquipmentAccountDetails? GetEquipmentDetails(string billingName)
        {
            EquipmentAccountDetails? billingAccount = new();

            try
            {
                using var connection = Database.Connect();

                string QuerySelect = @"
                    SELECT 
                        AccountNumber,
                        BilledValue
                    FROM 
                        BillingAccounts 
                    WHERE 
                        Classification = @Classification AND BillingName = @BillingName";

                billingAccount = connection.QueryFirstOrDefault<EquipmentAccountDetails>(QuerySelect, new
                {
                    Classification = "SHFC Equipment",
                    BillingName = billingName
                });
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return billingAccount;
        }

        public static List<AccountsComboBoxDetails> GetCustomEntryForComboBox(string billingName)
        {
            List<AccountsComboBoxDetails> customAccounts = new();

            try
            {
                using var connection = Database.Connect();

                string QuerySelect = @"
                    SELECT 
                        AccountNumber,
                        EntryType
                    FROM 
                        BillingAccounts 
                    WHERE 
                        BillingName = @BillingName AND EntryType = @EntryType";

                customAccounts = connection.Query<AccountsComboBoxDetails>(QuerySelect, new
                {
                    BillingName = billingName,
                    EntryType = "Custom Entry"
                }).ToList();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return customAccounts;
        }

        public static decimal GetCollectedValue(string accountNumber, string billingName)
        {
            decimal value = -1;
            try
            {
                using var connection = Database.Connect();

                string QuerySelect = @"
                    SELECT
                        CollectedValue
                    FROM
                        BillingAccounts
                    WHERE
                        AccountNumber = @AccountNumber AND BillingName = @BillingName";

                value = connection.QueryFirstOrDefault<decimal>(QuerySelect, new
                {
                    AccountNumber = accountNumber,
                    BillingName = billingName
                });
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
            return value;
        }

        public static bool Add(List<BillingAccount> accounts, string billingName)
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
                            EntryType,
                            OfficialReceiptNumber, 
                            Classification,
                            BilledValue,
                            NetBilling, 
                            CollectedValue, 
                            CollectionDate, 
                            Balance,
                            Purpose,
                            Timestamp, 
                            Remarks
                        )
                        VALUES (
                            @BillingName, 
                            @AccountNumber,
                            @EntryType,
                            @OfficialReceiptNumber, 
                            @Classification,
                            @BilledValue,
                            @NetBilling, 
                            @CollectedValue, 
                            @CollectionDate, 
                            @Balance,
                            @Purpose,
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
                            ActivityType = "New Account",
                            ActivityDetails = $"User added account(s) for a billing named {billingName}."
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

        public static bool UpdateCollectedValue(string accountNumber, string billingName, decimal value)
        {
            try
            {
                using var connection = Database.Connect();

                string QueryUpdate = @"
                    UPDATE BillingAccounts SET
                        CollectedValue = @CollectedValue
                    WHERE
                        AccountNumber = @AccountNumber AND BillingName = @BillingName";

                int affectedRows = connection.Execute(QueryUpdate, new
                {
                    CollectedValue = value,
                    AccountNumber = accountNumber,
                    BillingName = billingName
                });

                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static bool UpdateBalance(string accountNumber, string billingName, decimal value)
        {
            try
            {
                using var connection = Database.Connect();

                string QueryUpdate = @"
                    UPDATE BillingAccounts SET
                        Balance = @Balance
                    WHERE
                        AccountNumber = @AccountNumber AND BillingName = @BillingName";

                int affectedRows = connection.Execute(QueryUpdate, new
                {
                    Balance = value,
                    AccountNumber = accountNumber,
                    BillingName = billingName
                });

                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static bool UpdatePurpose(string accountNumber, string billingName, string purpose)
        {
            try
            {
                using var connection = Database.Connect();

                string QueryUpdate = @"
                    UPDATE BillingAccounts SET
                        Purpose = @Purpose
                    WHERE
                        AccountNumber = @AccountNumber AND BillingName = @BillingName";

                int affectedRows = connection.Execute(QueryUpdate, new
                {
                    Purpose = purpose,
                    AccountNumber = accountNumber,
                    BillingName = billingName
                });

                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static bool UpdateInformation(BillingAccount accountInfo)
        {
            try
            {
                using var connection = Database.Connect();

                string QueryUpdate = @"
                    UPDATE BillingAccounts SET
                        OfficialReceiptNumber = @OfficialReceiptNumber,
                        CollectionDate = @CollectionDate,
                        Purpose = @Purpose
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

        public static bool UpdateRemarks(BillingAccount accountInfo)
        {
            try
            {
                using var connection = Database.Connect();

                string QueryUpdate = @"
                    UPDATE BillingAccounts SET
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

        public static bool UpdateEquipmentValue(string accountNumber, string billingName, decimal value, decimal netValue)
        {
            try
            {
                using var connection = Database.Connect();

                string QueryUpdate = @"
                    UPDATE BillingAccounts SET
                        BilledValue = @BilledValue,
                        NetBilling = @NetBilling,
                        Balance = @Balance
                    WHERE
                        AccountNumber = @AccountNumber AND BillingName = @BillingName";

                int affectedRows = connection.Execute(QueryUpdate, new
                {
                    BilledValue = value,
                    NetBilling = netValue,
                    Balance = value,
                    AccountNumber = accountNumber,
                    BillingName = billingName
                });

                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static bool Remove(string billingName, string accountNumber)
        {
            try
            {
                using var connection = Database.Connect();
                using var transaction = connection?.BeginTransaction();

                try
                {
                    string QueryRemove = @"
                        DELETE
                        FROM
                            BillingAccounts
                        WHERE
                            BillingName = @BillingName AND AccountNumber = @AccountNumber";

                    int affectedRows = connection.Execute(QueryRemove, new
                    {
                        BillingName = billingName,
                        AccountNumber = accountNumber
                    }, transaction);

                    transaction?.Commit();

                    if (affectedRows > 0)
                    {
                        LoggingService.LogActivity(new()
                        {
                            UserID = UserService.CurrentUser.UserID,
                            ActivityType = "Remove Account",
                            ActivityDetails = $"User has removed a statement of account: {accountNumber} under billing: {billingName}"
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
    }
}
