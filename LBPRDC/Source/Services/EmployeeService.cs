using LBPRDC.Source.Config;
using LBPRDC.Source.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using static LBPRDC.Source.Config.StringConstants;
using static LBPRDC.Source.Data.Database;

namespace LBPRDC.Source.Services
{
    public class EmployeeBase
    {
        public int ID { get; set; }
        public string? EmployeeID { get; set; }
        public int ClientID { get; set; }
        public string ClientName { get; set; } = "";
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? FullName { get; set; }
        public string? Department { get; set; }
        public int DepartmentID { get; set; }
        public string? Position { get; set; }
        public int PositionID { get; set; }
        public string? Location { get; set; }
        public decimal DailySalaryRate { get; set; }
        public decimal DailyBillingRate { get; set; }
        // TODO : Add the MonthlyRates
    }

    internal class EmployeeService
    {
        public static async Task<List<Models.Employee.Identifier>> GetAllIdentifiersByClientID(int ClientID)
        {
            List<Models.Employee.Identifier> employees = new();

            try
            {
                using var context = new Context();
                employees = await context.Employees
                    .Where(e => e.ClientID == ClientID)
                    .Select(e => new Models.Employee.Identifier
                    {
                        ID = e.ID,
                        EmployeeID = e.EmployeeID,
                    })
                    .ToListAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return employees;
        }

        public static async Task<List<Models.Employee.View>> GetEmployees(int? ClientID = null, int? ID = null)
        {
            List<Models.Employee.View> employees = new();

            try
            {
                using var context = new Context();
                var query = context.Employees
                    .Include(i => i.Suffix)
                    .Include(i => i.EmploymentStatus)
                    .Include(i => i.Client)
                    .Include(i => i.Classification)
                    .Include(i => i.Wage)
                    .Include(i => i.Position)
                    .Include(i => i.Department)
                    .Include(i => i.Location)
                    .AsQueryable();

                if (ClientID.HasValue)
                {
                    query = query.Where(w => w.ClientID == ClientID);
                }

                if (ID.HasValue)
                {
                    query = query.Where(e => e.ID == ID);
                }

                employees = await query.Select(e => new Models.Employee.View
                {
                    ID = e.ID,
                    FullName = $"{e.LastName}, {e.FirstName} {e.MiddleName} {(e.Suffix.Name.Equals(Status.NONE) ? "" : e.Suffix.Name)}",
                    EmployeeID = e.EmployeeID,
                    FirstName = e.FirstName,
                    MiddleName = e.MiddleName,
                    LastName = e.LastName,
                    Gender = e.Gender,

                    EmailAddress1 = e.EmailAddress1,
                    EmailAddress2 = e.EmailAddress2,
                    ContactNumber1 = e.ContactNumber1,
                    ContactNumber2 = e.ContactNumber2,
                    Remarks = e.Remarks,

                    SuffixID = e.SuffixID,
                    SuffixName = e.Suffix.Name,
                    EmploymentStatusID = e.EmploymentStatusID,
                    EmploymentStatusName = e.EmploymentStatus.Name,

                    ClientID = e.ClientID,
                    ClientName = e.Client.Description,
                    ClassificationID = e.ClassificationID,
                    ClassificationName = e.Classification.Name,
                    WageID = e.WageID,
                    WageName = e.Wage.Name,
                    PositionID = e.PositionID,
                    PositionName = e.Position.Name,
                    DepartmentID = e.DepartmentID,
                    DepartmentName = e.Department.Name,
                    LocationID = e.LocationID,
                    LocationName = e.Location.Name,
                })
                .ToListAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return employees;
        }

        public static async Task<List<Models.Employee.TableView>> GetEmployeesTableViewByClientID(int ClientID)
        {
            var preference = UserPreferenceManager.LoadPreference();
            List<Models.Employee.TableView> employees = new();

            try
            {
                using var context = new Context();
                employees = await context.Employees
                    .Include(e => e.Suffix)
                    .Include(e => e.Position)
                    .Include(e => e.Wage)
                    .Where(e => e.ClientID == ClientID)
                    .Select(e => new Models.Employee.TableView
                    {
                        ID = e.ID,
                        FullName = GetPreferenceFullNameFormat(e, preference),
                        EmployeeID = e.EmployeeID,
                        FirstName = e.FirstName,
                        MiddleName = e.MiddleName,
                        LastName = e.LastName,
                        Gender = e.Gender,

                        EmailAddress1 = e.EmailAddress1,
                        EmailAddress2 = e.EmailAddress2,
                        JoinedEmailAddress = GetPreferenceEmailFormat(e, preference),
                        ContactNumber1 = e.ContactNumber1,
                        ContactNumber2 = e.ContactNumber2,
                        JoinedContactNumber = GetPreferenceContactNumber(e, preference),
                        Remarks = e.Remarks,

                        SuffixID = e.SuffixID,
                        SuffixName = e.Suffix.Name,
                        EmploymentStatusID = e.EmploymentStatusID,
                        EmploymentStatusName = e.EmploymentStatus.Name,

                        ClientID = e.ClientID,
                        ClientName = e.Client.Description,
                        ClassificationID = e.ClassificationID,
                        ClassificationName = e.Classification.Name,
                        WageID = e.WageID,
                        WageName = e.Wage.Name,
                        PositionID = e.PositionID,
                        PositionName = e.Position.Name,
                        PositionInfo = GetPreferencePosition(e, preference),
                        DepartmentID = e.DepartmentID,
                        DepartmentName = e.Department.Name,
                        LocationID = e.LocationID,
                        LocationName = e.Location.Name,

                        BillingRate = (e.Wage.Name.ToUpper() == Wage.DAILY.ToUpper()) ? e.Position.DailyBillingRate : e.Position.MonthlyBillingRate,
                        SalaryRate = (e.Wage.Name.ToUpper() == Wage.DAILY.ToUpper()) ? e.Position.DailySalaryRate : e.Position.MonthlySalaryRate,
                    })
                    .ToListAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return employees;
        }

        private static string GetPreferenceFullNameFormat(Models.Employee e, UserPreference preference)
        {
            string middleInitial = string.IsNullOrWhiteSpace(e.MiddleName) ? "" : $"{e.MiddleName[0]}.";
            string suffix = e.Suffix.Name == "None" ? "" : e.Suffix.Name;

            return preference.SelectedNameFormat switch
            {
                NameFormat.Full1 => $"{e.FirstName} {middleInitial} {e.LastName} {suffix}".Trim(),
                NameFormat.Full2 => $"{e.LastName}, {e.FirstName} {middleInitial} {suffix}".Trim(),
                NameFormat.FirstAndLastOnly => $"{e.FirstName} {e.LastName}".Trim(),
                NameFormat.LastNameOnly => e.LastName,
                _ => MessagesConstants.Error.TITLE
            };
        }
        private static string GetPreferencePosition(Models.Employee e, UserPreference preference)
        {
            return preference.SelectedPositionFormat switch
            {
                PositionFormat.NameOnly => e.Position.Name,
                PositionFormat.CodeOnly => e.Position.Code,
                PositionFormat.Both => string.Join(" - ", e.Position.Code, e.Position.Name),
                _ => MessagesConstants.Error.TITLE
            };
        }

        private static string GetPreferenceEmailFormat(Models.Employee e, UserPreference preference)
        {
            string?[] emailAddresses = new[] { e.EmailAddress1, e.EmailAddress2 };

            return preference.SelectedEmailFormat switch
            {
                EmailFormat.FirstOnly => e.EmailAddress1,
                EmailFormat.Both => string.Join(" / ", emailAddresses.Where(email => !string.IsNullOrWhiteSpace(email))),
                _ => MessagesConstants.Error.TITLE
            };
        }

        private static string GetPreferenceContactNumber(Models.Employee e, UserPreference preference)
        {
            string?[] contactNumbers = new[] { e.ContactNumber1, e.ContactNumber2 };

            return preference.SelectedContactFormat switch
            {
                ContactFormat.FirstOnly => e.ContactNumber1,
                ContactFormat.Both => string.Join(" / ", contactNumbers.Where(number => !string.IsNullOrWhiteSpace(number))),
                _ => MessagesConstants.Error.TITLE
            };
        }

        public static async Task<bool> AddEmployee(Models.Employee employee, Models.Employee.MoreInfo moreInfo)
        {
            using var context = new Context();
            using var transaction = await context.Database.BeginTransactionAsync();

            try
            {
                context.Employees.Add(employee);
                await context.SaveChangesAsync();

                context.EmployeePositionHistory.Add(new()
                {
                    EmployeeID = employee.ID,
                    PositionID = employee.PositionID,
                    PositionTitle = moreInfo.CurrentPositionTitle,
                    WageType = moreInfo.WageName,
                    DailySalaryRate = 0,
                    DailyBillingRate = 0,
                    MonthlySalaryRate = 0,
                    MonthlyBillingRate = 0,
                    Timestamp = moreInfo.OfficialStartDate,
                    Remarks = InitialRemarks.POSITION,
                    Status = Status.ACTIVE
                });

                context.EmployeeDepartmentLocationHistory.Add(new()
                {
                    EmployeeID = employee.ID,
                    DepartmentName = moreInfo.DepartmentName,
                    LocationName = moreInfo.LocationName,
                    Timestamp = moreInfo.OfficialStartDate,
                    Remarks = InitialRemarks.DEPARTMENT_AND_LOCATION,
                    Status = Status.ACTIVE
                });

                context.EmployeeEmploymentHistory.Add(new()
                {
                    EmployeeID = employee.ID,
                    EmploymentStatusID = employee.EmploymentStatusID,
                    Timestamp = moreInfo.OfficialStartDate,
                    Remarks = InitialRemarks.EMPLOYMENT_STATUS,
                    Status = Status.ACTIVE
                });

                if (moreInfo.IsFormerEmployee)
                {
                    context.EmployeePreviousRecord.Add(new()
                    {
                        EmployeeID = employee.ID,
                        Position = moreInfo.FormerPositionTitle,
                        StartDate = moreInfo.FormerStartDate,
                        EndDate = moreInfo.FormerEndDate,
                        Information = moreInfo.MoreFormerInformation
                    });
                }

                await context.SaveChangesAsync();
                await transaction.CommitAsync();

                await LoggingService.AddLog(new()
                {
                    UserID = UserService.CurrentUser.ID,
                    Type = MessagesConstants.Operation.ADD,
                    Details = $"{MessagesConstants.Operation.ADD}ed Employee: {employee.ID} - {employee.EmployeeID}"
                });

                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                ExceptionHandler.HandleException(ex);
                return false;
            }
        }

        public static async Task<bool> UpdateEmployee(Models.Employee updatedEntity, Models.Employee.MoreInfo moreInfo)
        {
            using var context = new Context();
            using var transaction = await context.Database.BeginTransactionAsync();

            try
            {
                var entity = await context.Employees.FindAsync(updatedEntity.ID);
                if (entity == null) { return false; }

                if (!UtilityService.AreEqual(entity, updatedEntity))
                {
                    var properties = typeof(Models.Employee).GetProperties();
                    foreach (var property in properties)
                    {
                        var updatedValue = property.GetValue(updatedEntity);
                        var currentValue = property.GetValue(entity);

                        if (!Equals(updatedValue, currentValue))
                        {
                            property.SetValue(entity, updatedValue);
                        }
                    }
                }

                var historyPositionID = await context.EmployeePositionHistory.Where(f => f.EmployeeID == entity.ID && f.Status == Status.ACTIVE).Select(s => s.HistoryID).FirstAsync();
                var historyPositionEntity = await context.EmployeePositionHistory.FindAsync(historyPositionID) ?? throw new Exception();

                historyPositionEntity.PositionID = entity.PositionID;
                historyPositionEntity.PositionTitle = moreInfo.CurrentPositionTitle;
                historyPositionEntity.Timestamp = moreInfo.PositionEffectiveDate;
                historyPositionEntity.WageType = moreInfo.WageName;

                var historyDepartmentLocationID = await context.EmployeeDepartmentLocationHistory.Where(f => f.EmployeeID == entity.ID && f.Status == Status.ACTIVE).Select(s => s.HistoryID).FirstAsync();
                var historyDepartmentLocationEntity = await context.EmployeeDepartmentLocationHistory.FindAsync(historyDepartmentLocationID) ?? throw new Exception();

                historyDepartmentLocationEntity.DepartmentName = moreInfo.DepartmentName;
                historyDepartmentLocationEntity.LocationName = moreInfo.LocationName;

                var historyEmploymentStatusID = await context.EmployeeEmploymentHistory.Where(f => f.EmployeeID == entity.ID && f.Status == Status.ACTIVE).Select(s => s.HistoryID).FirstAsync();
                var historyEmploymentStatusEntity = await context.EmployeeEmploymentHistory.FindAsync(historyEmploymentStatusID) ?? throw new Exception();

                historyEmploymentStatusEntity.EmploymentStatusID = entity.EmploymentStatusID;
                historyEmploymentStatusEntity.Timestamp = moreInfo.StatusEffectiveDate;

                var historyPreviousRecordEntity = context.EmployeePreviousRecord.Where(f => f.EmployeeID == entity.ID);
                bool hasPreviousRecord = await historyPreviousRecordEntity.AnyAsync();
                bool isFormerEmployee = Convert.ToBoolean(moreInfo.IsFormerEmployee);

                if (!hasPreviousRecord && isFormerEmployee)
                {
                    context.EmployeePreviousRecord.Add(new()
                    {
                        EmployeeID = entity.ID,
                        Position = moreInfo.FormerPositionTitle,
                        StartDate = moreInfo.FormerStartDate,
                        EndDate = moreInfo.FormerEndDate,
                        Information = moreInfo.MoreFormerInformation
                    });
                }
                else if (hasPreviousRecord)
                {
                    var historyPreviousRecordID = await historyPreviousRecordEntity.Select(s => s.ID).FirstAsync();
                    var historyCurrentPreviousRecordEntity = await context.EmployeePreviousRecord.FindAsync(historyPreviousRecordID) ?? throw new Exception();

                    if (isFormerEmployee)
                    {
                        historyCurrentPreviousRecordEntity.Position = moreInfo.FormerPositionTitle;
                        historyCurrentPreviousRecordEntity.StartDate = moreInfo.FormerStartDate;
                        historyCurrentPreviousRecordEntity.EndDate = moreInfo.FormerEndDate;
                        historyCurrentPreviousRecordEntity.Information = moreInfo.MoreFormerInformation;
                    }
                    else
                    {
                        context.EmployeePreviousRecord.Remove(historyCurrentPreviousRecordEntity);
                    }
                }

                await context.SaveChangesAsync();
                await transaction.CommitAsync();

                await LoggingService.AddLog(new()
                {
                    UserID = UserService.CurrentUser.ID,
                    Type = MessagesConstants.Operation.UPDATE,
                    Details = $"{MessagesConstants.Operation.UPDATE}d Employee: {entity.ID} - {entity.EmployeeID}"
                });

                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                ExceptionHandler.HandleException(ex);
                return false;
            }
        }

        public static async Task<bool> IDExists(int ClientID, string EmployeeID)
        {
            try
            {
                using var context = new Context();

                var entities = await context.Employees
                    .Where(w => w.ClientID == ClientID && w.EmployeeID == EmployeeID)
                    .ToListAsync();

                return entities.Any();
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> UpdateEmployeePosition(Models.Position.HistoryAdditional data, int ClientID)
        {
            try
            {
                using var context = new Context();
                using var transaction = await context.Database.BeginTransactionAsync();

                try
                {
                    var employee = await context.Employees.FindAsync(data.EmployeeID);
                    if (employee == null) { return false; }

                    employee.PositionID = data.PositionID;

                    var formerPosition = await context.Position
                        .Where(w => w.ClientID == ClientID && w.ID == data.OldPositionID)
                        .FirstOrDefaultAsync();

                    var activeHistoryEntity = await context.EmployeePositionHistory
                        .Where(w => w.EmployeeID == data.EmployeeID && w.Status == data.Status)
                        .FirstOrDefaultAsync();

                    if (formerPosition == null || activeHistoryEntity == null) { throw new Exception(); }

                    activeHistoryEntity.DailySalaryRate = formerPosition.DailySalaryRate;
                    activeHistoryEntity.DailyBillingRate = formerPosition.DailyBillingRate;
                    activeHistoryEntity.MonthlySalaryRate = formerPosition.MonthlySalaryRate;
                    activeHistoryEntity.MonthlyBillingRate = formerPosition.MonthlyBillingRate;
                    activeHistoryEntity.Status = StringConstants.Status.INACTIVE;

                    context.EmployeePositionHistory.Add(data);

                    await context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    await LoggingService.AddLog(new()
                    {
                        UserID = UserService.CurrentUser.ID,
                        Type = MessagesConstants.UPDATE,
                        Details = $"Promoted/demoted the position of an employee with the ID: {data.EmployeeID} under Client: {ClientID}"
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

        public static async Task<bool> UpdateEmployeeDepartmentLocation(Models.Department.HistoryAdditional data)
        {
            try
            {
                using var context = new Context();
                using var transaction = await context.Database.BeginTransactionAsync();

                try
                {
                    var employee = await context.Employees.FindAsync(data.EmployeeID);

                    if (employee == null) { return false; }

                    employee.DepartmentID = data.DepartmentID;
                    employee.LocationID = data.LocationID;

                    var activeHistoryEntity = await context.EmployeeDepartmentLocationHistory
                        .Where(w => w.Status == Status.ACTIVE)
                        .FirstOrDefaultAsync() ?? throw new Exception();

                    activeHistoryEntity.Status = Status.INACTIVE;

                    context.EmployeeDepartmentLocationHistory.Add(new()
                    {
                        EmployeeID = data.EmployeeID,
                        DepartmentName = data.DepartmentName,
                        LocationName = data.LocationName,
                        Timestamp = data.Timestamp,
                        Remarks = data.Remarks,
                        Status = Status.ACTIVE
                    });

                    await context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    await LoggingService.AddLog(new()
                    {
                        UserID = UserService.CurrentUser.ID,
                        Type = MessagesConstants.UPDATE,
                        Details = $"Updated the department and location of an employee with the ID: {data.EmployeeID}"
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

        public static async Task<bool> UpdateEmployeeEmploymentStatus(Models.EmploymentStatus.History data)
        {
            try
            {
                using var context = new Context();
                using var transaction = await context.Database.BeginTransactionAsync();

                try
                {
                    var employee = await context.Employees.FindAsync(data.EmployeeID);

                    if (employee == null) { return false; }

                    employee.EmploymentStatusID = data.EmploymentStatusID;

                    var activeHistoryEntity = await context.EmployeeEmploymentHistory
                        .Where(w => w.Status == Status.ACTIVE)
                        .FirstOrDefaultAsync() ?? throw new Exception();

                    activeHistoryEntity.Status = Status.INACTIVE;

                    context.EmployeeEmploymentHistory.Add(new()
                    {
                        EmployeeID = data.EmployeeID,
                        EmploymentStatusID = data.EmploymentStatusID,
                        Timestamp = data.Timestamp,
                        Remarks = data.Remarks,
                        Status = Status.ACTIVE
                    });

                    await LoggingService.AddLog(new()
                    {
                        UserID = UserService.CurrentUser.ID,
                        Type = MessagesConstants.UPDATE,
                        Details = $"Updated the employment status of an employee with the ID {data.EmployeeID}"
                    });

                    await context.SaveChangesAsync();
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

        public static async Task<bool> ArchiveEmployee(int EmployeeID, int ClientID)
        {
            try
            {
                using var context = new Context();
                using var transaction = await context.Database.BeginTransactionAsync();

                try
                {
                    var employees = await GetEmployees(ClientID, EmployeeID);
                    if (!employees.Any()) { return false; }
                    var e = employees.First();

                    context.EmployeeArchives.Add(new()
                    {
                        ClientID = e.ClientID,
                        ClientName = e.ClientName,
                        EmployeeID = e.EmployeeID,
                        FirstName = e.FirstName,
                        MiddleName = e.MiddleName,
                        LastName = e.LastName,
                        Suffix = e.SuffixName,
                        Gender = e.Gender,
                        EmailAddress1 = e.EmailAddress1,
                        EmailAddress2 = e.EmailAddress2,
                        ContactNumber1 = e.ContactNumber1,
                        ContactNumber2 = e.ContactNumber2,
                        EmploymentStatus = e.EmploymentStatusName,
                        Classification = e.ClassificationName,
                        Position = e.PositionName,
                        Department = e.DepartmentName,
                        Location = e.LocationName,
                        Remarks = e.Remarks,
                        Timestamp = DateTime.Now
                    });

                    var employeeDepartmentLocationHistory = await context.EmployeeDepartmentLocationHistory.Where(h => h.EmployeeID == EmployeeID).ToListAsync();
                    var employeeEmploymentHistory = await context.EmployeeEmploymentHistory.Where(h => h.EmployeeID == EmployeeID).ToListAsync();
                    var employeePositionHistory = await context.EmployeePositionHistory.Where(h => h.EmployeeID == EmployeeID).ToListAsync();
                    var employeeFormerRecord = await context.EmployeePreviousRecord.Where(h => h.EmployeeID == EmployeeID).ToListAsync();
                    var employeeToRemove = await context.Employees.FindAsync(EmployeeID) ?? throw new Exception();

                    if (employeeDepartmentLocationHistory.Any())
                    {
                        context.EmployeeDepartmentLocationHistory.RemoveRange(employeeDepartmentLocationHistory);
                    }

                    if (employeeEmploymentHistory.Any())
                    {
                        context.EmployeeEmploymentHistory.RemoveRange(employeeEmploymentHistory);
                    }

                    if (employeePositionHistory.Any())
                    {
                        context.EmployeePositionHistory.RemoveRange(employeePositionHistory);
                    }

                    if (employeeFormerRecord.Any())
                    {
                        context.EmployeePreviousRecord.RemoveRange(employeeFormerRecord);
                    }

                    context.Employees.Remove(employeeToRemove);

                    await context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    await LoggingService.AddLog(new()
                    {
                        UserID = UserService.CurrentUser.ID,
                        Type = MessagesConstants.Operation.ARCHIVE,
                        Details = $"Archived an employee with an ID: {EmployeeID}"
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

        // TODO: Don't know if I still need this one
        public static async Task<List<EmployeeBase>> GetAllEmployeesBase()
        {
            List<EmployeeBase> employees = new();

            try
            {
                string querySelect = "SELECT ID, EmployeeID, LastName, FirstName, MiddleName, DepartmentID, PositionID, LocationID FROM Employees";
                using SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString());
                using SqlCommand command = new(querySelect, connection);
                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();

                var Department = await DepartmentService.GetAllItems();
                var Location = LocationService.GetAllItems();
                var Position = await PositionService.GetAllItems();

                while (reader.Read())
                {
                    EmployeeBase employee = new()
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        EmployeeID = Convert.ToString(reader["EmployeeID"]),
                        LastName = Convert.ToString(reader["LastName"]),
                        FirstName = Convert.ToString(reader["FirstName"]),
                        MiddleName = Convert.ToString(reader["MiddleName"]),
                        Department = Department.First(f => f.ID == Convert.ToInt32(reader["DepartmentID"])).Name,
                        Location = Location.First(f => f.ID == Convert.ToInt32(reader["LocationID"])).Name,
                        Position = Position.First(f => f.ID == Convert.ToInt32(reader["PositionID"])).Name,
                    };

                    employees.Add(employee);
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return employees;
        }
    }
}
