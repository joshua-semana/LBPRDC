using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BCrypt.Net;
using static LBPRDC.Source.Services.EmployeeService;
using System.DirectoryServices;
using OfficeOpenXml.ConditionalFormatting;

namespace LBPRDC.Source.Services
{
    internal class UserService
    {

        public class User
        {
            public int UserID { get; set; }
            public string? Username { get; set; }
            public string? Password { get; set; }
            public string? Email { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set;}
            public string? Role { get; set; }
            public string? Status { get; set; }
            public DateTime? RegistrationDate { get; set; }
            public DateTime? LastLoginDate { get; set; }
        }

        public static User? CurrentUser { get; set; }

        public static void SetCurrentUser(User user)
        {
            CurrentUser = user;
        }

        public static void ClearCurrentUser()
        {
            CurrentUser = null;
        }

        public static List<User> GetAllUsers()
        {
            List<User> users = new();
            try
            {
                string query = "SELECT * FROM Users";

                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User user = new()
                            {
                                UserID = Convert.ToInt32(reader["UserID"]),
                                Username = Convert.ToString(reader["Username"]),
                                FirstName = Convert.ToString(reader["FirstName"]),
                                LastName = Convert.ToString(reader["LastName"]),
                                Email = Convert.ToString(reader["Email"]),
                                Role = Convert.ToString(reader["Role"]),
                                Status = Convert.ToString(reader["Status"]),
                                RegistrationDate = Convert.ToDateTime(reader["RegistrationDate"]),
                                LastLoginDate = Convert.ToDateTime(reader["LastLoginDate"])
                            };

                            users.Add(user);
                        }
                    }
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return users;
        }

        public static async Task<bool> Add(User newUser)
        {
            try
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newUser.Password);

                string query = "INSERT INTO Users (Username, PasswordHash, Email, FirstName, LastName, Role, Status, RegistrationDate, LastLoginDate) " +
                               "VALUES (@Username, @PasswordHash, @Email, @FirstName, @LastName, @Role, @Status, @RegistrationDate, @LastLoginDate)";

                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", newUser.Username);
                    command.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                    command.Parameters.AddWithValue("@Email", newUser.Email);
                    command.Parameters.AddWithValue("@FirstName", newUser.FirstName);
                    command.Parameters.AddWithValue("@LastName", newUser.LastName);
                    command.Parameters.AddWithValue("@Role", "Standard");
                    command.Parameters.AddWithValue("@Status", "Active");
                    command.Parameters.AddWithValue("@RegistrationDate", DateTime.Now);
                    command.Parameters.AddWithValue("@LastLoginDate", DateTime.Now);

                    connection.Open();
                    await command.ExecuteNonQueryAsync();

                    if (CurrentUser != null)
                    {
                        LoggingService.Log newLog = new()
                        {
                            UserID = CurrentUser.UserID,
                            ActivityType = "Add",
                            ActivityDetails = $"This user added a new user account with username of {newUser.Username}."
                        };

                        LoggingService.LogActivity(newLog);
                    }
                }
                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static void UpdateLastLoginDate(string username)
        {
            try
            {
                string query = "UPDATE Users SET LastLoginDate = @LastLoginDate WHERE Username = @Username";

                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@LastLoginDate", DateTime.Now);

                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> UpdateUserStatusRole(User user)
        {
            try
            {
                string query = "UPDATE Users SET " +
                    "Role = @Role, " +
                    "Status = @Status " +
                    "WHERE UserID = @UserID";

                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@Role", user.Role);
                    command.Parameters.AddWithValue("@Status", user.Status);
                    command.Parameters.AddWithValue("@UserID", user.UserID);

                    connection.Open();
                    await command.ExecuteNonQueryAsync();

                    if (CurrentUser != null)
                    {
                        LoggingService.Log newLog = new()
                        {
                            UserID = CurrentUser.UserID,
                            ActivityType = "Update",
                            ActivityDetails = $"This user updated a user's status and/or role with a username of {user.Username}."
                        };

                        LoggingService.LogActivity(newLog);
                    }
                }
                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> ResetPassword(User user)
        {
            try
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);

                string updateQuery = "UPDATE Users SET PasswordHash = @PasswordHash WHERE UserID = @UserID";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                    command.Parameters.AddWithValue("@UserID", user.UserID);

                    connection.Open();
                    await command.ExecuteNonQueryAsync();

                    if (CurrentUser != null)
                    {
                        LoggingService.Log newLog = new()
                        {
                            UserID = CurrentUser.UserID,
                            ActivityType = "Reset",
                            ActivityDetails = $"This user resets the password of a user with ID of {user.UserID}."
                        };

                        LoggingService.LogActivity(newLog);
                    }
                }
                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }
    }
}
