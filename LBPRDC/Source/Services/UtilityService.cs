using Dapper;
using LBPRDC.Source.Config;
using LBPRDC.Source.Data;
using System.Reflection;

namespace LBPRDC.Source.Services
{
    internal class UtilityService
    {
        private static bool IsValidTableName(string tableName)
        {
            HashSet<string> allowedTableNames = new();

            var categoryProps = typeof(StringConstants.DBTableNames).GetFields(BindingFlags.Public | BindingFlags.Static);

            foreach (var category in categoryProps)
            {
                allowedTableNames.Add(category.GetValue(null)?.ToString());
            }

            return allowedTableNames.Contains(tableName);
        }

        public static bool Delete(string tableName, int id)
        {
            try
            {
                if (!IsValidTableName(tableName))
                {
                    MessageBox.Show("You are accessing a table that is not whitelisted.", MessagesConstants.Error.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                using var connection = Database.Connect();
                using var transaction = connection?.BeginTransaction();

                try
                {
                    string QueryDelete = @$"
                        DELETE FROM
                            {tableName}
                        WHERE
                            ID = @ID";

                    int affectedRows = connection.Execute(QueryDelete, new
                    {
                        ID = id
                    }, transaction);

                    if (affectedRows > 0)
                    {
                        transaction?.Commit();
                    }
                }
                catch (Exception)
                {
                    transaction?.Rollback();
                    return false;
                }

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }
    }
}
