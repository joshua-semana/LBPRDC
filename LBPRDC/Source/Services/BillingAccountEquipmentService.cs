using LBPRDC.Source.Config;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.Style;
using static LBPRDC.Source.Data.Database;

namespace LBPRDC.Source.Services
{
    internal class BillingAccountEquipmentService
    {
        public static async Task<bool> Add(Models.Billing.Account.Equipment data)
        {
            try
            {
                using var context = new Context();
                context.BillingAccountEquipments.Add(data);
                int affectedRows = await context.SaveChangesAsync();
                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> RemoveByID(int AccountID)
        {
            try
            {
                using var context = new Context();

                var accountToDelete = await context.BillingAccountEquipments.FindAsync(AccountID);

                if (accountToDelete != null)
                {
                    context.BillingAccountEquipments.Remove(accountToDelete);
                    await context.SaveChangesAsync();
                }

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<Models.Billing.Account> GetAccountByBillingID(int BillingID)
        {
            Models.Billing.Account account = new();

            try
            {
                using var context = new Context();
                account = await context.BillingAccounts
                    .Where(a => a.BillingID == BillingID)
                    .FirstAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return account;
        }

        public static async Task<Models.Billing.AccountsWithType?> GetAccountsWithTypeByBillingId(int BillingID)
        {
            Models.Billing.AccountsWithType? account = new();

            try
            {
                using var context = new Context();
                account = await context.BillingAccountEquipments
                    .Where(b => b.BillingID == BillingID)
                    .Select(b => new Models.Billing.AccountsWithType
                    {
                        AccountNumber = b.AccountNumber,
                        EntryType = b.EntryType,
                    })
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return account;
        }

        public static async Task<bool> UpdateBillingValue(int AccountID, decimal Value)
        {
            try
            {
                using var context = new Context();
                var account = await context.BillingAccountEquipments.FindAsync(AccountID);
                if (account == null)
                {
                    return false;
                }
                account.BilledValue = Value;
                account.Balance = Value;
                account.NetBilling = NumericConstants.GetNetBilling(Value);

                int result = await context.SaveChangesAsync();

                return (result > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }
    }
}
