using LBPRDC.Source.Config;
using Microsoft.EntityFrameworkCore;
using static LBPRDC.Source.Data.Database;

namespace LBPRDC.Source.Services
{
    internal class UserService
    {
        public static Models.User CurrentUser { get; set; } = new();

        public static void SetCurrentUser(Models.User user)
        {
            CurrentUser = user;
        }

        public static void ClearCurrentUser()
        {
            CurrentUser = new Models.User();
        }

        public static async Task<bool> Authenticate(string username, string password)
        {
            try
            {
                using var context = new Context();
                var user = await context.Users.Where(w => w.Username == username).FirstOrDefaultAsync();
                if (user == null) { return false; }

                bool result = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

                return result;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<List<Models.User.View>> GetUsers(int? ID = null, string? Username = null)
        {
            List<Models.User.View> users = new();

            try
            {
                using var context = new Context();
                var query = context.Users.AsQueryable();

                if (ID.HasValue)
                {
                    query = query.Where(w => w.ID == ID);
                }

                if (Username != null)
                {
                    query = query.Where(w => w.Username == Username);
                }

                users = await query.Select(s => new Models.User.View
                {
                    ID = s.ID,
                    UserRoleID = s.UserRoleID,
                    Username = s.Username,
                    FirstName = s.FirstName,
                    MiddleName = s.MiddleName,
                    LastName = s.LastName,
                    Email = s.Email,
                    PositionTitle = s.PositionTitle,
                    Status = s.Status,
                    RegistrationDate = s.RegistrationDate,
                    LastLoginDate = s.LastLoginDate,
                    UserRoleName = s._UserRole.Name
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

                await LoggingService.AddLog(new()
                {
                    UserID = CurrentUser.ID,
                    Type = MessagesConstants.Operation.ADD,
                    Details = $"Added User: {newUser.ID} - {newUser.Username}"
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

        public static async Task<bool> UpdateCurrentUserBasicInformation(Models.User updatedUser)
        {
            try
            {
                using var context = new Context();
                var user = await context.Users.FindAsync(updatedUser.ID);
                if (user == null) { return false; }

                user.FirstName = updatedUser.FirstName;
                user.MiddleName = updatedUser.MiddleName;
                user.LastName = updatedUser.LastName;
                user.Email = updatedUser.Email;
                user.PositionTitle = updatedUser.PositionTitle;

                await context.SaveChangesAsync();

                await LoggingService.AddLog(new()
                {
                    UserID = CurrentUser.ID,
                    Type = MessagesConstants.Operation.UPDATE,
                    Details = $"Updated their basic information"
                });

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> UpdateCurrentUserPassword(Models.User updatedUser)
        {
            try
            {
                using var context = new Context();
                var user = await context.Users.FindAsync(updatedUser.ID);
                if (user == null) { return false; }

                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(updatedUser.PasswordHash);

                await context.SaveChangesAsync();

                await LoggingService.AddLog(new()
                {
                    UserID = CurrentUser.ID,
                    Type = MessagesConstants.Operation.UPDATE,
                    Details = $"Updated their password"
                });

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> UpdateUserStatusRole(Models.User data)
        {
            try
            {
                using var context = new Context();
                var user = await context.Users.FindAsync(data.ID);
                if (user == null) { return false; }

                user.UserRoleID = data.UserRoleID;
                user.Status = data.Status;

                await context.SaveChangesAsync();

                await LoggingService.AddLog(new()
                {
                    UserID = CurrentUser.ID,
                    Type = MessagesConstants.Operation.UPDATE,
                    Details = $"Update user's status and/or role: {data.ID}"
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
                var user = await context.Users.FindAsync(data.ID);
                if (user == null) { return false; }

                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(data.PasswordHash);

                await context.SaveChangesAsync();

                await LoggingService.AddLog(new()
                {
                    UserID = CurrentUser.ID,
                    Type = MessagesConstants.Operation.RESET_PASSWORD,
                    Details = $"Resets password: {data.ID}"
                });

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }
    }
}
