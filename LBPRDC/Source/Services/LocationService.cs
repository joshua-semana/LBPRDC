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

        // TODO: Being used for GetEmployeeBase in EmployeeService which is to be remove
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

        public static async Task<List<Models.Location.View>> GetAllItemsWithView()
        {
            List<Models.Location.View> items = new();

            try
            {
                using var context = new Context();
                items = await context.Locations
                    .Include(i => i.Department)
                    .Where(w => w.Department.Client.PayFrequencyID == PayFrequencyService.CurrentPayFrequencyID)
                    .Select(s => new Models.Location.View
                    {
                        ID = s.ID,
                        Type = s.Type,
                        Name = s.Name,
                        DepartmentID = s.DepartmentID,
                        Status = s.Status,
                        Description = s.Description,
                        DepartmentClientName = s.Department.Client.Name,
                        DepartmentName = s.Department.Name
                    })
                    .ToListAsync();
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
                    .Include(i => i.Department)
                    .Where(w => w.Department.Client.PayFrequencyID == PayFrequencyService.CurrentPayFrequencyID)
                    .Where(l => l.Status == StringConstants.Status.ACTIVE && l.DepartmentID == departmentID)
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

        public static async Task<bool> Add(Models.Location data)
        {
            try
            {
                using var context = new Context();
                context.Locations.Add(data);
                await context.SaveChangesAsync();

                await LoggingService.AddLog(new()
                {
                    UserID = UserService.CurrentUser.ID,
                    Type = MessagesConstants.Add.TITLE,
                    Details = $"Added a new location: {data.Name}"
                });

                return true;
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

                item.Name = data.Name;
                item.DepartmentID = data.DepartmentID;
                item.Description = data.Description;
                item.Status = data.Status;

                await context.SaveChangesAsync();

                await LoggingService.AddLog(new()
                {
                    UserID = UserService.CurrentUser.ID,
                    Type = MessagesConstants.UPDATE,
                    Details = $"Updated a location's information with ID: {data.ID}"
                });

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }
    }
}
