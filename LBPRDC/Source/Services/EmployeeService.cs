using Dapper;
using LBPRDC.Source.Config;
using LBPRDC.Source.Data;
using LBPRDC.Source.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Reflection;
using static LBPRDC.Source.Config.StringConstants;
using static LBPRDC.Source.Data.Database;
using static LBPRDC.Source.Services.LocationService;

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
        public class EmployeeUpdateBase
        {
            public int EmployeeID { get; set; }
            public DateTime Date { get; set; }
            public string? Remarks { get; set; }
        }

        public class EmployeePositionUpdate : EmployeeUpdateBase
        {
            public int OldPositionID { get; set; }
            public int PositionID { get; set; }
            public string PositionTitle { get; set; } = "";
        }

        public class EmployeeDepartmentLocationUpdate : EmployeeUpdateBase 
        {
            public int DepartmentID { get; set; }
            public int LocationID { get; set; }
            public string DepartmentName { get; set; } = "";
            public string LocationName { get; set; } = "";
        }

        public class EmployeeCivilStatusUpdate : EmployeeUpdateBase
        {
            public int CivilStatusID { get; set; }
        }

        public class EmployeeEmploymentStatusUpdate : EmployeeUpdateBase
        {
            public int EmploymentStatusID { get; set; }
        }

        // Entity Framework

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

        public static async Task<List<Models.Employee.View>> GetAllEmployeeInfoByClientID(int ClientID, int? ID = null)
        {
            List<Models.Employee.View> employees = new();

            try
            {
                using var context = new Context();
                var query = context.Employees.Where(e => e.ClientID == ClientID);

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

                await LoggingService.LogActivity(new()
                {
                    UserID = UserService.CurrentUser.UserID,
                    ActivityType = MessagesConstants.Operation.ADD,
                    ActivityDetails = $"{MessagesConstants.Operation.ADD}ed Employee: {employee.ID} - {employee.EmployeeID}"
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

                await LoggingService.LogActivity(new()
                {
                    UserID = UserService.CurrentUser.UserID,
                    ActivityType = MessagesConstants.Operation.UPDATE,
                    ActivityDetails = $"{MessagesConstants.Operation.UPDATE}d Employee: {entity.ID} - {entity.EmployeeID}"
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

        public static async Task<bool> UpdateEmployeePosition(EmployeePositionUpdate data)
        {
            try
            {
                using var context = new Context();

                var employee = await context.Employees.FindAsync(data.EmployeeID);

                if (employee == null) { return false; }

                employee.PositionID = data.PositionID;

                int affectedRows = await context.SaveChangesAsync();

                if (affectedRows > 0)
                {
                    Models.Position.HistoryAdditional newHistory = new()
                    {
                        EmployeeID = data.EmployeeID,
                        OldPositionID = data.OldPositionID,
                        PositionID = data.PositionID,
                        PositionTitle = data.PositionTitle,
                        DailySalaryRate = 0,
                        DailyBillingRate = 0,
                        MonthlySalaryRate = 0,
                        MonthlyBillingRate = 0,
                        Timestamp = data.Date,
                        Remarks = data.Remarks,
                        Status = StringConstants.Status.ACTIVE
                    };

                    PositionService.AddNewHistory(newHistory);

                    if (UserService.CurrentUser != null)
                    {
                        await LoggingService.LogActivity(new()
                        {
                            UserID = UserService.CurrentUser.UserID,
                            ActivityType = MessagesConstants.UPDATE,
                            ActivityDetails = $"This user has promoted/demoted the position of employee with the ID {data.EmployeeID}."
                        });
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> UpdateEmployeeDepartmentLocation(EmployeeDepartmentLocationUpdate data)
        {
            try
            {
                using var context = new Context();
                var employee = await context.Employees.FindAsync(data.EmployeeID);

                if (employee == null)
                {
                    return false;
                }

                employee.DepartmentID = data.DepartmentID;
                employee.LocationID = data.LocationID;

                int affectedRows = await context.SaveChangesAsync();

                if (affectedRows > 0)
                {
                    DepartmentService.History newHistory = new()
                    {
                        EmployeeID = data.EmployeeID,
                        DepartmentName = data.DepartmentName,
                        LocationName = data.LocationName,
                        Timestamp = data.Date,
                        Remarks = data.Remarks,
                        Status = StringConstants.Status.ACTIVE
                    };

                    DepartmentService.AddNewHistory(newHistory);

                    if (UserService.CurrentUser != null)
                    {
                        LoggingService.Log newLog = new()
                        {
                            UserID = UserService.CurrentUser.UserID,
                            ActivityType = MessagesConstants.UPDATE,
                            ActivityDetails = $"This user has updated the department and location of employee with the ID {data.EmployeeID}."
                        };

                        await LoggingService.LogActivity(newLog);
                    }
                }

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> UpdateEmployeeEmploymentStatus(EmployeeEmploymentStatusUpdate data)
        {
            try
            {
                using var context = new Context();

                var employee = await context.Employees.FindAsync(data.EmployeeID);

                if (employee == null)
                {
                    return false;
                }

                employee.EmploymentStatusID = data.EmploymentStatusID;
                int affectedRows = await context.SaveChangesAsync();

                if (affectedRows > 0)
                {
                    EmploymentStatusService.History newHistory = new()
                    {
                        EmployeeID = data.EmployeeID,
                        EmploymentStatusID = data.EmploymentStatusID,
                        Timestamp = data.Date,
                        Remarks = data.Remarks,
                        Status = StringConstants.Status.ACTIVE
                    };

                    EmploymentStatusService.AddNewHistory(newHistory);

                    if (UserService.CurrentUser != null)
                    {
                        LoggingService.Log newLog = new()
                        {
                            UserID = UserService.CurrentUser.UserID,
                            ActivityType = MessagesConstants.UPDATE,
                            ActivityDetails = $"This user has updated the employment status of employee with the ID {data.EmployeeID}."
                        };

                        await LoggingService.LogActivity(newLog);
                    }
                }

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        // TODO
        public static async Task<bool> ArchiveEmployee(int EmployeeID, int ClientID)
        {
            try
            {
                using var context = new Context();
                bool isRemoved = false;
                var employees = await GetAllEmployeeInfoByClientID(ClientID);
                var employee = employees.FirstOrDefault(e => e.ID == EmployeeID);

                if (employee == null)
                {
                    return false;
                }

                Models.EmployeeArchive employeeArchive = new()
                {
                    ClientID = employee.ClientID,
                    ClientName = employee.ClientName,
                    EmployeeID = employee.EmployeeID,
                    LastName = employee.LastName,
                    FirstName = employee.FirstName,
                    MiddleName = employee.MiddleName,
                    Suffix = employee.SuffixName,
                    Gender = employee.Gender,
                    Department = employee.DepartmentName,
                    Location = employee.LocationName,
                    EmailAddress1 = employee.EmailAddress1,
                    EmailAddress2 = employee.EmailAddress2,
                    ContactNumber1 = employee.ContactNumber1,
                    ContactNumber2 = employee.ContactNumber2,
                    Position = employee.PositionName,
                    EmploymentStatus = employee.EmploymentStatusName,
                    Remarks = employee.Remarks
                };

                context.EmployeeArchives.Add(employeeArchive);
                int result = await context.SaveChangesAsync();

                if (result > 0)
                {
                    isRemoved = await RemoveEmployeeRecord(EmployeeID);
                }

                if (isRemoved && UserService.CurrentUser != null)
                {
                    await LoggingService.LogActivity(new()
                    {
                        UserID = UserService.CurrentUser.UserID,
                        ActivityType = MessagesConstants.Archive.TITLE,
                        ActivityDetails = $"This user has archived an employee with the ID: {EmployeeID}."
                    });
                }

                return isRemoved;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        private static async Task<bool> RemoveEmployeeRecord(int EmployeeID)
        {
            try
            {
                using var context = new Context();

                await DepartmentService.RemoveHistoryByEmployeeID(EmployeeID);
                await EmploymentStatusService.RemoveHistoryByEmployeeID(EmployeeID);
                await PositionService.RemoveHistoryByEmployeeID(EmployeeID);
                await RemoveHistoryByEmployeeID(EmployeeID);

                var employeeToRemove = await context.Employees.FindAsync(EmployeeID);

                if (employeeToRemove != null)
                {
                    context.Employees.Remove(employeeToRemove);
                    await context.SaveChangesAsync();
                }
                else
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task RemoveHistoryByEmployeeID(int EmployeeID)
        {
            try
            {
                using var context = new Context();
                var historiesToRemove = await context.EmployeePreviousRecord
                    .Where(h => h.EmployeeID == EmployeeID)
                    .ToListAsync();

                if (historiesToRemove.Any())
                {
                    context.EmployeePreviousRecord.RemoveRange(historiesToRemove);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }
    }
}
