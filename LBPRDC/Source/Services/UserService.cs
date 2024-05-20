using LBPRDC.Source.Config;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static LBPRDC.Source.Data.Database;
using static LBPRDC.Source.Config.StringConstants;

namespace LBPRDC.Source.Services
{
    internal class UserService
    {

        public class User
        {
            public int UserID { get; set; }
            public string Username { get; set; } = "";
            public string Password { get; set; } = "";
            public string Email { get; set; } = "";
            public string FirstName { get; set; } = "";
            public string LastName { get; set;} = "";
            public string Role { get; set; } = "";
            public string Status { get; set; } = "";
            public DateTime RegistrationDate { get; set; }
            public DateTime LastLoginDate { get; set; }
            public string MiddleName { get; set; } = "";
            public string PositionTitle { get; set; } = "";

        }

        public static Models.User CurrentUser { get; set; } = new Models.User();

        public static void SetCurrentUser(Models.User user)
        {
            CurrentUser = user;
        }

        public static void ClearCurrentUser()
        {
            CurrentUser = new Models.User();
        }

        public static async Task<List<Models.User>> GetUsers(int? ID = null, string? Username = null)
        {
            List<Models.User> users = new();

            try
            {
                using var context = new Context();
                var query = context.Users.AsQueryable();

                if (ID.HasValue)
                {
                    query = query.Where(w => w.UserID == ID);
                }

                if (Username != null)
                {
                    query = query.Where(w => w.Username == Username);
                }

                users = await query.Select(s => new Models.User
                {
                    UserID = s.UserID,
                    Username = s.Username,
                    Email = s.Email,
                    FirstName = s.FirstName,
                    MiddleName = s.MiddleName,
                    LastName = s.LastName,
                    PositionTitle = s.PositionTitle,
                    Role = s.Role,
                    Status = s.Status,
                    RegistrationDate = s.RegistrationDate,
                    LastLoginDate = s.LastLoginDate
                })
                .ToListAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return users;
        }

        public static async Task<bool> Add(Models.User newUser)
        {
            try
            {
                using var context = new Context();

                newUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newUser.PasswordHash);

                context.Users.Add(newUser);
                await context.SaveChangesAsync();

                await LoggingService.LogActivity(new()
                {
                    UserID = CurrentUser.UserID,
                    ActivityType = MessagesConstants.Operation.ADD,
                    ActivityDetails = $"Added User: {newUser.UserID} - {newUser.Username}"
                });

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task UpdateLastLoginDate(int ID)
        {
            try
            {
                using var context = new Context();
                var user = await context.Users.FindAsync(ID);

                if (user  == null) { return; }

                user.LastLoginDate = DateTime.Now;
                await context.SaveChangesAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> UpdateUserStatusRole(Models.User data)
        {
            try
            {
                using var context = new Context();
                var user = await context.Users.FindAsync(data.UserID);

                if (user == null) { return false; }

                user.Role = data.Role;
                user.Status = data.Status;

                await context.SaveChangesAsync();

                await LoggingService.LogActivity(new()
                {
                    UserID = CurrentUser.UserID,
                    ActivityType = MessagesConstants.Operation.UPDATE,
                    ActivityDetails = $"Update User's Status and/or Role: {data.UserID}"
                });

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> ResetPassword(Models.User data)
        {
            try
            {
                using var context = new Context();

                var user = await context.Users.FindAsync(data.UserID);

                if (user == null) { return false; }

                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(data.PasswordHash);

                await context.SaveChangesAsync();

                await LoggingService.LogActivity(new()
                {
                    UserID = CurrentUser.UserID,
                    ActivityType = MessagesConstants.Operation.RESET_PASSWORD,
                    ActivityDetails = $"Resets Password: {data.UserID}"
                });

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> UpdateUserBasicInformation(User user)
        {
            try
            {
                string updateQuery = "UPDATE Users SET " +
                    "FirstName = @FirstName, " +
                    "LastName = @LastName, " +
                    "Email = @Email," +
                    "MiddleName = @MiddleName," +
                    "PositionTitle = @PositionTitle " +
                    "WHERE UserID = @UserID";

                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@MiddleName", user.MiddleName);
                    command.Parameters.AddWithValue("@PositionTitle", user.PositionTitle);
                    command.Parameters.AddWithValue("@UserID", user.UserID);

                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }
                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> UpdatePassword(User user)
        {
            try
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);

                string updateQuery = "UPDATE Users SET " +
                    "PasswordHash = @PasswordHash " +
                    "WHERE UserID = @UserID";

                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                    command.Parameters.AddWithValue("@UserID", user.UserID);

                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }
                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }
    }
}
