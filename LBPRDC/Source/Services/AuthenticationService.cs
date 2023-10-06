using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace LBPRDC.Source.Services
{
    internal class AuthenticationService
    {
        public static bool ValidateCredentials(string username, string password)
        {
            try
            {
                // By adding COLLATE Latin1_General_BIN, the word "admin" is not the same with "ADmin"
                string query = "SELECT PasswordHash FROM Users WHERE Username COLLATE Latin1_General_BIN = @Username";

                using (SqlConnection connection = new SqlConnection(Data.DataAccessHelper.GetConnectionString()))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);

                        string? storedPasswordHash = command.ExecuteScalar() as string;
                        if (storedPasswordHash != null)
                        {
                            bool passwordIsCorrect = BCrypt.Net.BCrypt.Verify(password, storedPasswordHash);
                            return passwordIsCorrect;
                        }
                    }
                }
                return false;
            } 
            catch (Exception ex)
            {
                return ExceptionHandler.HandleException(ex);
            }
        }
    }
}
