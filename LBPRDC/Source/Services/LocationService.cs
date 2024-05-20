using Dapper;
using LBPRDC.Source.Config;
using LBPRDC.Source.Data;
using Microsoft.EntityFrameworkCore;
using static LBPRDC.Source.Data.Database;

namespace LBPRDC.Source.Services
{
    internal class LocationService
    {
        public class Location
        {
            public int? ID { get; set; }
            public string Type { get; set; } = StringConstants.Type.USER_ENTRY; // DEFAULT or USER_ENTRY
            public string? Name { get; set; }
            public int? DepartmentID { get; set; }
            //public string? DepartmentName { get; set; } // Only intended to use for the viewing in Categories Control Table
            public string? Status { get; set; }
            public string? Description { get; set; }
        }

        // Entity Framework

        public static async Task<List<Models.Location.View>> GetAllItemsWithView()
        {
            List<Models.Location.View> items = new();

            try
            {
                using var context = new Context();
                items = await context.Locations.Select(s => new Models.Location.View
                {
                    ID = s.ID,
                    Type = s.Type,
                    Name = s.Name,
                    DepartmentID = s.DepartmentID,
                    Status = s.Status,
                    Description = s.Description,
                    DepartmentName = s.Department.Name
                })
                .ToListAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }

        public static List<Location> GetAllItems()
        {
            List<Location> items = new();

            try
            {
                using var connection = Database.Connect();

                string QuerySelect = "SELECT * FROM Locations";

                items = connection.Query<Location>(QuerySelect).ToList();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }

        public static async Task<List<Models.Location>> GetAllItemsForComboBoxByID(int departmentID)
        {
            List<Models.Location> items = new();

            try
            {
                using var context = new Context();

                items = await context.Locations
                    .Where(l => 
                        l.Status == StringConstants.Status.ACTIVE &&
                        l.DepartmentID == departmentID)
                    .Select(l => new Models.Location()
                    {
                        ID = l.ID,
                        Name = l.Name,
                    })
                    .ToListAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }

        public static async Task RemoveDefaultByDepartmentID(int DepartmentID)
        {
            try
            {
                using var context = new Context();

                var locationToRemove = await context.Locations
                    .Where(l => l.DepartmentID == DepartmentID && l.Type == StringConstants.Type.DEFAULT)
                    .FirstAsync();

                context.Locations.Remove(locationToRemove);

                await context.SaveChangesAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> Add(Location data)
        {
            try
            {
                using var connection = Database.Connect();
                using var transaction = connection?.BeginTransaction();

                try
                {
                    string QueryInsert = @"
                        INSERT INTO Locations (
                            Type,
                            Name, 
                            DepartmentID,
                            Description, 
                            Status
                        ) VALUES (
                            @Type,
                            @Name, 
                            @DepartmentID,
                            @Description, 
                            @Status
                        )";

                    int affectedRows = await connection.ExecuteAsync(QueryInsert, data, transaction);
                    transaction?.Commit();

                    if (affectedRows > 0)
                    {
                        LoggingService.Log newLog = new()
                        {
                            UserID = UserService.CurrentUser.UserID,
                            ActivityType = MessagesConstants.Add.TITLE,
                            ActivityDetails = $"This user added a new item for the location category with a name of {data.Name}."
                        };
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

        public static async Task<bool> Update(Models.Location data)
        {
            try
            {
                using var context = new Context();

                var item = await context.Locations.FindAsync(data.ID);

                if (item == null) { return false; }
                if (AreEqual(item, data)) { return true; }

                item.Name = data.Name;
                item.DepartmentID = data.DepartmentID;
                item.Description = data.Description;
                item.Status = data.Status;

                int affectedRows = await context.SaveChangesAsync();

                if (affectedRows > 0)
                {
                    if (UserService.CurrentUser != null)
                    {
                        await LoggingService.LogActivity(new()
                        {
                            UserID = UserService.CurrentUser.UserID,
                            ActivityType = MessagesConstants.UPDATE,
                            ActivityDetails = $"This user updated an item under the location category with an ID of {data.ID}."
                        });
                    }
                }
                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        private static bool AreEqual(Models.Location item1, Models.Location item2)
        {
            return item1.Name == item2.Name &&
                   item1.DepartmentID == item2.DepartmentID &&
                   item1.Description == item2.Description &&
                   item1.Status == item2.Status;
        }
    }
}
