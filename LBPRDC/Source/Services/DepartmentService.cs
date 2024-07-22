using LBPRDC.Source.Config;
using Microsoft.EntityFrameworkCore;
using static LBPRDC.Source.Data.Database;

namespace LBPRDC.Source.Services
{
    internal class DepartmentService
    {

        // TODO: To be removed, being used in EmployeeService GetEmployeeBase()
        public static async Task<List<Models.Department>> GetAllItems()
        {
            List<Models.Department> items = new();

            try
            {
                using var context = new Context();
                items = await context.Departments.ToListAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }

        public static async Task<List<Models.Department>> GetItems(int? ClientID = null, string? Status = null)
        {
            List<Models.Department> items = new();

            try
            {
                using var context = new Context();
                var query = context.Departments
                    .Include(i => i.Client)
                    .Where(w => w.Client.PayFrequencyID == PayFrequencyService.CurrentPayFrequencyID)
                    .AsQueryable();

                if (ClientID != null)
                {
                    query = query.Where(w => w.ClientID == ClientID);
                }

                if (Status != null)
                {
                    query = query.Where(w => w.Status == Status);
                }

                items = await query.ToListAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }

        public static async Task<List<Models.Department.View>> GetAllItemsWithView()
        {
            List<Models.Department.View> items = new();

            try
            {
                using var context = new Context();
                items = await context.Departments
                    .Include(i => i.Client)
                    .Where(w => w.Client.PayFrequencyID == PayFrequencyService.CurrentPayFrequencyID)
                    .Select(s => new Models.Department.View
                    {
                        ID = s.ID,
                        ClientID = s.ClientID,
                        Code = s.Code,
                        Name = s.Name,
                        Status = s.Status,
                        Description = s.Description,
                        ClientName = s.Client.Name
                    })
                    .ToListAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }

        public static async Task<List<Models.Department>> GetAllItemsForComboBox(int? ClientID = null, bool WithDefault = true)
        {
            List<Models.Department> items = new();

            try
            {
                if (WithDefault)
                {
                    items.Add(new Models.Department
                    {
                        ID = 0,
                        Name = StringConstants.ComboBox.DEFAULT_DEPARTMENT
                    });
                }

                using var context = new Context();
                var query = context.Departments
                    .Include(i => i.Client)
                    .Where(w => w.Client.PayFrequencyID == PayFrequencyService.CurrentPayFrequencyID)
                    .AsQueryable();

                if (ClientID != null)
                {
                    query = query.Where(w => w.ClientID == ClientID);
                }

                var result = await query
                    .Where(d => d.Status.Equals(StringConstants.Status.ACTIVE) && d.ClientID.Equals(ClientID))
                    .Select(d => new Models.Department()
                    {
                        ID = d.ID,
                        Name = $"{d.Code} - {d.Name}",
                    })
                    .ToListAsync();

                items.AddRange(result);
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }

        public static async Task<bool> Add(Models.Department data)
        {
            try
            {
                using var context = new Context();
                using var transaction = await context.Database.BeginTransactionAsync();
                

                try
                {
                    context.Departments.Add(data);
                    await context.SaveChangesAsync();

                    context.Locations.Add(new()
                    {
                        Name = "None",
                        Description = $"Default none value for '{data.Name}' department.",
                        Type = StringConstants.Type.DEFAULT,
                        Status = data.Status,
                        DepartmentID = data.ID
                    });

                    await context.SaveChangesAsync();

                    await LoggingService.AddLog(new()
                    {
                        UserID = UserService.CurrentUser.ID,
                        Type = MessagesConstants.Add.TITLE,
                        Details = $"Added a new department: {data.Name} under Client: {data.ClientID}"
                    });

                    await transaction.CommitAsync();

                    return true;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    return false;
                }
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> Update(Models.Department data)
        {
            try
            {
                using var context = new Context();
                using var transaction = await context.Database.BeginTransactionAsync();

                try
                {
                    var departmentEntity = await context.Departments.FindAsync(data.ID);

                    if (departmentEntity == null) { return false; }

                    departmentEntity.ClientID = data.ClientID;
                    departmentEntity.Code = data.Code;
                    departmentEntity.Name = data.Name;
                    departmentEntity.Description = data.Description;
                    departmentEntity.Status = data.Status;

                    var locationEntity = await context.Locations
                        .Where(w => w.DepartmentID == departmentEntity.ID &&
                                    w.Type == StringConstants.Type.DEFAULT)
                        .FirstOrDefaultAsync() ?? throw new Exception();

                    locationEntity.Description = $"Default none value for '{data.Name}' department.";

                    await context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    await LoggingService.AddLog(new()
                    {
                        UserID = UserService.CurrentUser.ID,
                        Type = MessagesConstants.UPDATE,
                        Details = $"Updated a department and/or default location's information with ID: {data.ID}"
                    });

                    return true;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    return false;
                }
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        // HISTORY-RELATED

        public static async Task<List<Models.Department.HistoryView>> GetHistoriesWithView(int EmployeeID)
        {
            List<Models.Department.HistoryView> histories = new();

            try
            {
                using var context = new Context();

                histories = await context.EmployeeDepartmentLocationHistory
                    .Where(w => w.EmployeeID == EmployeeID)
                    .Select(s => new Models.Department.HistoryView()
                    {
                        DepartmentName = s.DepartmentName,
                        LocationName = s.LocationName,
                        EffectiveDate = s.Timestamp.ToString(StringConstants.Date.DEFAULT),
                        Status = s.Status,
                        Remarks = s.Remarks
                    })
                    .ToListAsync();

                foreach (var history in histories)
                {
                    history.Indicator = (history.Status == StringConstants.Status.ACTIVE) ? StringConstants.DisplayStatus.RIGHT_ARROW : "";
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return histories;
        }
    }
}
