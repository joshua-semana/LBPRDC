using Dapper;
using LBPRDC.Source.Config;
using LBPRDC.Source.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using static LBPRDC.Source.Data.Database;

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
        // Entity Framework

        public static async Task<List<Models.Billing.Account>> GetItemsByBillingID(int BillingID)
        {
            List<Models.Billing.Account> accountsList = new();

            try
            {
                using var context = new Context();
                accountsList = await context.BillingAccounts.Where(ba => ba.BillingID == BillingID).ToListAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return accountsList;
        }

        public static async Task<List<Models.Billing.AccountsWithType>> GetAccountsWithTypeByBillingIdAndType(int BillingID, string EntryType)
        {
            List<Models.Billing.AccountsWithType> accountsWithTypeList = new();

            try
            {
                using var context = new Context();
                accountsWithTypeList = await context.BillingAccounts
                    .Where(b => b.BillingID == BillingID && b.EntryType == EntryType)
                    .Select(b => new Models.Billing.AccountsWithType
                    {
                        AccountNumber = b.AccountNumber,
                        EntryType = b.EntryType,
                    })
                    .ToListAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return accountsWithTypeList;
        }

        public static async Task<Models.Billing.Account> GetAccountDetailsByNumberAndBillingID(string AccountNumber, int BillingID)
        {
            Models.Billing.Account accountDetails = new();

            try
            {
                using var context = new Context();
                var selectedAccount = await context.BillingAccounts
                    .Where(b => b.BillingID == BillingID && b.AccountNumber == AccountNumber)
                    .FirstOrDefaultAsync();

                if (selectedAccount != null)
                {
                    accountDetails = selectedAccount;
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return accountDetails;
        }

        public static async Task<Models.Billing.Account> GetEquipmentAccountByBillingID(int BillingID)
        {
            Models.Billing.Account accountDetails = new();

            try
            {
                using var context = new Context();
                var selectedAccount = await context.BillingAccounts
                    .Where(b => b.BillingID == BillingID && b.EntryType == StringConstants.Type.EQUIPMENT)
                    .FirstOrDefaultAsync();

                if (selectedAccount != null)
                {
                    accountDetails = selectedAccount;
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return accountDetails;
        }

        public static async Task<bool> AddManyAsync(List<Models.Billing.Account> Accounts)
        {
            try
            {
                using var context = new Context();
                context.BillingAccounts.AddRange(Accounts);
                int affectedRows = await context.SaveChangesAsync();
                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> AddSingleAsync(Models.Billing.Account Account)
        {
            try
            {
                using var context = new Context();
                context.BillingAccounts.Add(Account);
                int affectedRows = await context.SaveChangesAsync();
                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> UpdateBillingValue(int AccountID, decimal Value)
        {
            try
            {
                using var context = new Context();
                var account = await context.BillingAccounts.FindAsync(AccountID);
                if (account == null)
                {
                    return false;
                }
                account.BilledValue = Value;
                account.Balance = Value;
                account.NetBilling = Value - NumericConstants.GetNetBilling(Value);

                int result = await context.SaveChangesAsync();

                return (result > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> RemoveByID(int AccountID)
        {
            try
            {
                using var context = new Context();

                var accountToDelete = await context.BillingAccounts.FindAsync(AccountID);

                if (accountToDelete != null)
                {
                    context.BillingAccounts.Remove(accountToDelete);
                    await context.SaveChangesAsync();
                }

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }




        //public static Models.Billing.Account GetDetailsAsync(int BillingID, string AccountNumber)
        //{
        //    Models.Billing.Account account = new();

        //    try
        //    {
        //        using var context = new Context();




        //        using var connection = Database.Connect();

        //        string QuerySelect = @"
        //            SELECT * 
        //            FROM 
        //                BillingAccounts 
        //            WHERE 
        //                AccountNumber = @AccountNumber AND BillingName = @BillingName";

        //        billingAccount = connection.QueryFirst<BillingAccount>(QuerySelect, new
        //        {
        //            AccountNumber = accountNumber,
        //            BillingName = billingName
        //        });
        //    }
        //    catch (Exception ex) { ExceptionHandler.HandleException(ex); }

        //    return account;
        //}



















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

        // TODO

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
                    EntryType = StringConstants.Type.CUSTOM
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

        public static async Task<bool> AddSingle(Models.Billing.Account data)
        {
            try
            {
                using var context = new Context();
                context.BillingAccounts.Add(data);
                int affectedRows = await context.SaveChangesAsync();
                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex);  }
        }

        public static async Task<bool> Add(List<BillingAccount> accounts, string billingName)
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
                        await LoggingService.AddLog(new()
                        {
                            UserID = UserService.CurrentUser.ID,
                            Type = "New Account",
                            Details = $"User added account(s) for a billing named {billingName}."
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

        public static bool UpdateCollectedValue(string accountNumber, int BillingID, decimal value)
        {
            try
            {
                using var connection = Database.Connect();

                string QueryUpdate = @"
                    UPDATE BillingAccounts SET
                        CollectedValue = @CollectedValue
                    WHERE
                        AccountNumber = @AccountNumber AND BillingID = @BillingID";

                int affectedRows = connection.Execute(QueryUpdate, new
                {
                    CollectedValue = value,
                    AccountNumber = accountNumber,
                    BillingID
                });

                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static bool UpdateBalance(string accountNumber, int BillingID, decimal value)
        {
            try
            {
                using var connection = Database.Connect();

                string QueryUpdate = @"
                    UPDATE BillingAccounts SET
                        Balance = @Balance
                    WHERE
                        AccountNumber = @AccountNumber AND BillingID = @BillingID";

                int affectedRows = connection.Execute(QueryUpdate, new
                {
                    Balance = value,
                    AccountNumber = accountNumber,BillingID
                });

                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static bool UpdatePurpose(string accountNumber, int BillingID, string purpose)
        {
            try
            {
                using var connection = Database.Connect();

                string QueryUpdate = @"
                    UPDATE BillingAccounts SET
                        Purpose = @Purpose
                    WHERE
                        AccountNumber = @AccountNumber AND BillingID = @BillingID";

                int affectedRows = connection.Execute(QueryUpdate, new
                {
                    Purpose = purpose,
                    AccountNumber = accountNumber,
                    BillingID
                });

                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> UpdateInformationAsync(Models.Billing.Account Account)
        {
            try
            {
                using var context = new Context();

                var account = await context.BillingAccounts
                    .Where(ba => ba.BillingID == Account.BillingID && ba.AccountNumber == Account.AccountNumber)
                    .FirstAsync();

                if (account == null)
                {
                    return false;
                }

                account.OfficialReceiptNumber = Account.OfficialReceiptNumber;
                account.CollectionDate = Account.CollectionDate;
                account.Purpose = Account.Purpose;

                int affectedRows = await context.SaveChangesAsync();

                if (affectedRows > 0)
                {
                    await LoggingService.AddLog(new()
                    {
                        UserID = UserService.CurrentUser.ID,
                        Type = "Collect SOA",
                        Details = $"User has updated the information of a statement of account: {Account.AccountNumber} under billing ID: {Account.BillingID}"
                    });
                }

                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> UpdateRemarks(Models.Billing.Account accountInfo)
        {
            try
            {
                using var context = new Context();

                var account = await context.BillingAccounts
                    .Where(ba => ba.BillingID == accountInfo.BillingID && ba.AccountNumber == accountInfo.AccountNumber)
                    .FirstAsync();

                if (account == null) { return false; }
                account.Remarks = accountInfo.Remarks;
                await context.SaveChangesAsync();

                await LoggingService.AddLog(new()
                {
                    UserID = UserService.CurrentUser.ID,
                    Type = "Update",
                    Details = $"User has updated the information of a statement of account: {accountInfo.AccountNumber} under billing ID: {accountInfo.BillingID}"
                });

                return true;
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

        public static async Task<bool> Remove(string billingName, string accountNumber)
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
                        await LoggingService.AddLog(new()
                        {
                            UserID = UserService.CurrentUser.ID,
                            Type = "Remove Account",
                            Details = $"User has removed a statement of account: {accountNumber} under billing: {billingName}"
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
