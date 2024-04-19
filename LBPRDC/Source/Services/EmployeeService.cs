using Dapper;
using LBPRDC.Source.Config;
using LBPRDC.Source.Data;
using LBPRDC.Source.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
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
        public decimal SalaryRate { get; set; }
        public decimal BillingRate { get; set; }
    }

    public class EmployeeCompositeType : EmployeeBase
    {
        public string? Type { get; set; }
    }

    internal class EmployeeService
    {
        public class Employee : EmployeeBase
        {
            public string? Gender { get; set; }
            public DateTime? Birthday { get; set; }
            public string? Education { get; set; }
            public int LocationID { get; set; }
            public string? EmailAddress1 { get; set; }
            public string? EmailAddress2 { get; set; }
            public string? ContactNumber1 { get; set; }
            public string? ContactNumber2 { get; set; }
            public int CivilStatusID { get; set; }
            public int EmploymentStatusID { get; set; }
            public int SuffixID { get; set; }
            public string? Remarks { get; set; }
            public int WageID { get; set; }

            public string? EmailAddress { get; set; }
            public string? ContactNumber { get; set; }
            public string? CivilStatus { get; set; }
            public string? PositionCode { get; set; }
            public string? PositionName { get; set; }
            public string? EmploymentStatus { get; set; }
            public string? Suffix { get; set; }
        }

        public class EmployeeHistory : Employee
        {
            public DateTime StartDate { get; set; }
            public DateTime PositionEffectiveDate { get; set; }
            public DateTime StatusEffectiveDate { get; set; }
            public string? PositionTitle { get; set; }
            public bool? isPreviousEmployee { get; set; }
            public string? PreviousPosition { get; set; }
            public DateTime PreviousFrom { get; set; }
            public DateTime PreviousTo { get; set; }
            public string? OtherInformation { get; set; }
        }

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
            public string? PositionTitle { get; set; }
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
                employees = await context.Employee
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

        public static async Task<List<Models.Employee.View>> GetAllEmployeeInfoByClientID(int ClientID, int? EmployeeID = null)
        {
            List<Models.Employee.View> employees = new();

            try
            {
                using var context = new Context();
                var query = context.Employee.Where(e => e.ClientID == ClientID);

                if (EmployeeID.HasValue)
                {
                    query = query.Where(e => e.ID == EmployeeID);
                }

                employees = await query.Select(e => new Models.Employee.View
                {
                    ID = e.ID,
                    EmployeeID = e.EmployeeID,
                    ClientID = e.ClientID,
                    LastName = e.LastName,
                    FirstName = e.FirstName,
                    MiddleName = e.MiddleName,
                    Gender = e.Gender,
                    Birthday = e.Birthday,
                    Education = e.Education,
                    EmailAddress1 = e.EmailAddress1,
                    EmailAddress2 = e.EmailAddress2,
                    ContactNumber1 = e.ContactNumber1,
                    ContactNumber2 = e.ContactNumber2,
                    SuffixID = e.SuffixID,
                    DepartmentID = e.DepartmentID,
                    LocationID = e.LocationID,
                    CivilStatusID = e.CivilStatusID,
                    PositionID = e.PositionID,
                    EmploymentStatusID = e.EmploymentStatusID,
                    Remarks = e.Remarks,
                    WageID = e.WageID,
                    ClientName = e.Client.Description,
                    FullName = $"{e.LastName}, {e.FirstName} {e.MiddleName} {(e.Suffix.Name.Equals(StringConstants.Status.NONE) ? "" : e.Suffix.Name)}",
                    SuffixName = e.Suffix.Name,
                    DepartmentName = e.Department.Name,
                    LocationName = e.Location.Name,
                    CivilStatusName = e.CivilStatus.Name,
                    PositionName = e.Position.Name,
                    EmploymentStatusName = e.EmploymentStatus.Name,
                    WageName = e.Wage.Name
                })
                .ToListAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return employees;
        }

        public static async Task<List<Models.Employee.TableView>> GetEmployeesWithPreferenceByClientID(int ClientID)
        {
            var preference = UserPreferenceManager.LoadPreference();
            List<Models.Employee.TableView> employees = new();

            try
            {
                using var context = new Context();
                employees = await context.Employee
                    .Include(e => e.Suffix)
                    .Include(e => e.Position)
                    .Include(e => e.Wage)
                    .Where(e => e.ClientID == ClientID)
                    .Select(e => new Models.Employee.TableView
                    {
                        ID = e.ID,
                        EmployeeID = e.EmployeeID,
                        ClientID = e.ClientID,
                        LastName = e.LastName,
                        FirstName = e.FirstName,
                        MiddleName = e.MiddleName,
                        Gender = e.Gender,
                        Birthday = e.Birthday,
                        Education = e.Education,
                        EmailAddress1 = e.EmailAddress1,
                        EmailAddress2 = e.EmailAddress2,
                        ContactNumber1 = e.ContactNumber1,
                        ContactNumber2 = e.ContactNumber2,
                        SuffixID = e.SuffixID,
                        DepartmentID = e.DepartmentID,
                        LocationID = e.LocationID,
                        CivilStatusID = e.CivilStatusID,
                        PositionID = e.PositionID,
                        EmploymentStatusID = e.EmploymentStatusID,
                        WageID = e.WageID,
                        Remarks = e.Remarks,
                        ClientName = e.Client.Description,
                        SuffixName = e.Suffix.Name,
                        DepartmentName = e.Department.Name,
                        LocationName = e.Location.Name,
                        CivilStatusName = e.CivilStatus.Name,
                        PositionName = e.Position.Name,
                        EmploymentStatusName = e.EmploymentStatus.Name,
                        WageName = e.Wage.Name,
                        FullName = GetPreferenceFullNameFormat(e, preference),
                        PositionInfo = GetPreferencePosition(e, preference),
                        JoinedEmailAddress = GetPreferenceEmailFormat(e, preference),
                        JoinedContactNumber = GetPreferenceContactNumber(e, preference),
                        BillingRate = e.Position.BillingRate,
                        SalaryRate = e.Position.SalaryRate,
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























        public static async Task<List<EmployeeBase>> GetAllEmployeesBase()
        {
            List<EmployeeBase> employees = new();

            try
            {
                string querySelect = "SELECT ID, EmployeeID, LastName, FirstName, MiddleName, DepartmentID, PositionID, LocationID FROM Employee";
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

        //private static UserPreference preference;

        public static async Task<List<Employee>> GetAllEmployees()
        {
            List<Employee> employees = new();
            var preference = UserPreferenceManager.LoadPreference();
            try
            {
                string query = "SELECT * FROM Employee";

                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var CivilStatus = CivilStatusService.GetAllItems();
                        var EmploymentStatus = EmploymentStatusService.GetAllItems();
                        var Suffix = SuffixService.GetAllItems();
                        var Department = await DepartmentService.GetAllItems();
                        var Location = LocationService.GetAllItems();
                        var Position = await PositionService.GetAllItems();

                        while (reader.Read())
                        {
                            Employee emp = new()
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                EmployeeID = Convert.ToString(reader["EmployeeID"]),
                                ClientID = Convert.ToInt32(reader["ClientID"]),
                                LastName = Utilities.StringFormat.ToSentenceCase(Convert.ToString(reader["LastName"])),
                                FirstName = Utilities.StringFormat.ToSentenceCase(Convert.ToString(reader["FirstName"])),
                                MiddleName = Utilities.StringFormat.ToSentenceCase(Convert.ToString(reader["MiddleName"])),
                                Gender = Convert.ToString(reader["Gender"]),
                                Birthday = Convert.ToDateTime(reader["Birthday"]),
                                Education = Convert.ToString(reader["Education"]),
                                DepartmentID = Convert.ToInt32(reader["DepartmentID"]),
                                LocationID = Convert.ToInt32(reader["LocationID"]),
                                EmailAddress1 = Convert.ToString(reader["EmailAddress1"]),
                                EmailAddress2 = Convert.ToString(reader["EmailAddress2"]),
                                ContactNumber1 = Convert.ToString(reader["ContactNumber1"]),
                                ContactNumber2 = Convert.ToString(reader["ContactNumber2"]),
                                CivilStatusID = Convert.ToInt32(reader["CivilStatusID"]),
                                PositionID = Convert.ToInt32(reader["PositionID"]),
                                EmploymentStatusID = Convert.ToInt32(reader["EmploymentStatusID"]),
                                SuffixID = Convert.ToInt32(reader["SuffixID"]),
                                Remarks = Convert.ToString(reader["Remarks"])
                            };

                            var position = Position.First(f => f.ID == emp.PositionID);
                            emp.PositionName = position.Name;
                            emp.PositionCode = position.Code;
                            emp.BillingRate = Convert.ToDecimal(position.BillingRate);
                            emp.SalaryRate = Convert.ToDecimal(position.SalaryRate);
                            emp.CivilStatus = CivilStatus.First(f => f.ID == emp.CivilStatusID).Name;
                            emp.EmploymentStatus = EmploymentStatus.First(f => f.ID == emp.EmploymentStatusID).Name;
                            emp.Suffix = Suffix.First(f => f.ID == emp.SuffixID).Name;
                            emp.Department = Department.First(f => f.ID == emp.DepartmentID).Name;
                            emp.Location = Location.First(f => f.ID == emp.LocationID).Name;

                            if (preference.ShowName)
                            {
                                string middleInitial = string.IsNullOrWhiteSpace(emp.MiddleName) ? "" : $"{emp.MiddleName[0]}.";
                                string? suffix = emp.Suffix == "None" ? "" : emp.Suffix;
                                emp.FullName = preference.SelectedNameFormat switch
                                {
                                    NameFormat.Full1 => $"{emp.FirstName} {middleInitial} {emp.LastName} {suffix}".Trim(),
                                    NameFormat.Full2 => $"{emp.LastName}, {emp.FirstName} {middleInitial} {suffix}".Trim(),
                                    NameFormat.FirstAndLastOnly => $"{emp.FirstName} {emp.LastName}".Trim(),
                                    NameFormat.LastNameOnly => emp.LastName,
                                    _ => MessagesConstants.Error.TITLE
                                };
                            }

                            if (preference.ShowEmailAddress)
                            {
                                string?[] emailAddresses = new[] { emp.EmailAddress1, emp.EmailAddress2 };
                                emp.EmailAddress = preference.SelectedEmailFormat switch
                                {
                                    EmailFormat.FirstOnly => emp.EmailAddress1,
                                    EmailFormat.Both => string.Join(" / ", emailAddresses.Where(email => !string.IsNullOrWhiteSpace(email))),
                                    _ => MessagesConstants.Error.TITLE
                                };
                            }

                            if (preference.ShowContactNumber)
                            {
                                string?[] contactNumbers = new[] { emp.ContactNumber1, emp.ContactNumber2 };
                                emp.ContactNumber = preference.SelectedContactFormat switch
                                {
                                    ContactFormat.FirstOnly => emp.ContactNumber1,
                                    ContactFormat.Both => string.Join(" / ", contactNumbers.Where(number => !string.IsNullOrWhiteSpace(number))),
                                    _ => MessagesConstants.Error.TITLE
                                };
                            }

                            if (preference.ShowPosition)
                            {
                                emp.Position = preference.SelectedPositionFormat switch
                                {
                                    PositionFormat.NameOnly => emp.PositionName,
                                    PositionFormat.CodeOnly => emp.PositionCode,
                                    PositionFormat.Both => string.Join(" - ", emp.PositionCode, emp.PositionName),
                                    _ => MessagesConstants.Error.TITLE
                                };
                            }

                            employees.Add(emp);
                        }
                    }
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return employees;
        }

        public static bool IDExists(int ClientID, string EmployeeID)
        {
            try
            {
                using var connection = Database.Connect();

                string QueryCount = @"
                    SELECT 
                        COUNT(*) 
                    FROM 
                        Employee 
                    WHERE
                        ClientID = @ClientID
                    AND
                        EmployeeID = @EmployeeID";

                int totalCount = connection.QueryFirstOrDefault<int>(QueryCount, new
                {
                    ClientID,
                    EmployeeID
                });

                return totalCount > 0;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> AddNewEmployee(EmployeeHistory data)
        {
            try
            {
                using var connection = Database.Connect();
                using var transaction = connection?.BeginTransaction();

                try
                {
                    string QueryInsert = @"
                        INSERT INTO Employee (
                            EmployeeID,
                            ClientID,
                            LastName,
                            FirstName,
                            MiddleName,
                            SuffixID,
                            Gender,
                            Birthday,
                            Education,
                            DepartmentID,
                            LocationID,
                            EmailAddress1,
                            EmailAddress2,
                            ContactNumber1,
                            ContactNumber2,
                            CivilStatusID,
                            PositionID,
                            EmploymentStatusID,
                            Remarks,
                            WageID
                        ) VALUES (
                            @EmployeeID,
                            @ClientID,
                            @LastName,
                            @FirstName,
                            @MiddleName,
                            @SuffixID,
                            @Gender,
                            @Birthday,
                            @Education,
                            @DepartmentID,
                            @LocationID,
                            @EmailAddress1,
                            @EmailAddress2,
                            @ContactNumber1,
                            @ContactNumber2,
                            @CivilStatusID,
                            @PositionID,
                            @EmploymentStatusID,
                            @Remarks,
                            @WageID)";

                    int affectedRows = await connection.ExecuteAsync(QueryInsert, data, transaction);

                    if (affectedRows > 0)
                    {
                        transaction?.Commit();

                        string QueryMax = @"
                            SELECT
                                MAX(ID)
                            FROM
                                Employee";

                        int lastInsertedID = connection.QueryFirstOrDefault<int>(QueryMax);

                        if (lastInsertedID == 0)
                        {
                            transaction?.Rollback();
                            return false;
                        }

                        var departmentList = await DepartmentService.GetAllItems();
                        List<Location> locationList = LocationService.GetAllItems();

                        PositionService.History newPosition = new()
                        {
                            EmployeeID = lastInsertedID,
                            PositionID = data.PositionID,
                            PositionTitle = data.PositionTitle,
                            SalaryRate = 0,
                            BillingRate = 0,
                            Timestamp = data.StartDate,
                            Remarks = StringConstants.Status.INITIAL,
                            Status = StringConstants.Status.ACTIVE
                        };

                        CivilStatusService.History newCivilStatus = new()
                        {
                            EmployeeID = lastInsertedID,
                            CivilStatusID = data.CivilStatusID,
                            Timestamp = data.StartDate,
                            Remarks = StringConstants.Status.INITIAL,
                            Status = StringConstants.Status.ACTIVE
                        };

                        DepartmentService.History newDepartmentLocation = new()
                        {
                            EmployeeID = lastInsertedID,
                            DepartmentName = departmentList.First(w => w.ID == data.DepartmentID).Name ?? "",
                            LocationName = locationList.First(w => w.ID == data.LocationID).Name ?? "",
                            Timestamp = data.StartDate,
                            Remarks = StringConstants.Status.INITIAL,
                            Status = StringConstants.Status.ACTIVE
                        };

                        EmploymentStatusService.History newEmploymentStatus = new()
                        {
                            EmployeeID = lastInsertedID,
                            EmploymentStatusID = data.EmploymentStatusID,
                            Timestamp = data.StartDate,
                            Remarks = StringConstants.Status.INITIAL,
                            Status = StringConstants.Status.ACTIVE
                        };

                        PositionService.AddNewHistory(newPosition);
                        CivilStatusService.AddNewHistory(newCivilStatus);
                        DepartmentService.AddNewHistory(newDepartmentLocation);
                        EmploymentStatusService.AddNewHistory(newEmploymentStatus);

                        if (Convert.ToBoolean(data.isPreviousEmployee))
                        {
                            PreviousEmployeeService.PreviousEmployee entry = new()
                            {
                                EmployeeID = lastInsertedID,
                                Position = data.PreviousPosition,
                                StartDate = data.PreviousFrom,
                                EndDate = data.PreviousTo,
                                Information = data.OtherInformation
                            };

                            PreviousEmployeeService.AddRecord(entry);
                        }

                        if (UserService.CurrentUser != null)
                        {
                            LoggingService.Log newLog = new()
                            {
                                UserID = UserService.CurrentUser.UserID,
                                ActivityType = MessagesConstants.Add.TITLE,
                                ActivityDetails = $"This user added a new employee with ID of {data.EmployeeID}."
                            };

                            LoggingService.LogActivity(newLog);
                        }
                    }
                    return true;
                }
                catch (Exception e)
                {
                    transaction?.Rollback();
                    MessageBox.Show(e.Message);
                    return false;
                }
            } 
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> UpdateEmployee(EmployeeHistory employee)
        {
            try
            {
                using var connection = Database.Connect();
                using var transaction = connection?.BeginTransaction();

                try
                {
                    string QueryUpdate = @"
                        UPDATE Employee SET
                            EmployeeID = @EmployeeID,
                            LastName = @LastName,
                            FirstName = @FirstName,
                            MiddleName = @MiddleName,
                            SuffixID = @SuffixID,
                            Gender = @Gender,
                            Birthday = @Birthday,
                            Education = @Education,
                            DepartmentID = @DepartmentID,
                            LocationID = @LocationID,
                            EmailAddress1 = @EmailAddress1,
                            EmailAddress2 = @EmailAddress2,
                            ContactNumber1 = @ContactNumber1,
                            ContactNumber2 = @ContactNumber2,
                            CivilStatusID = @CivilStatusID,
                            PositionID = @PositionID,
                            EmploymentStatusId = @EmploymentStatusId,
                            Remarks = @Remarks,
                            WageID = @WageID
                        WHERE 
                            ID = @ID;";

                    int affectedRows = await connection.ExecuteAsync(QueryUpdate, employee, transaction);

                    if (affectedRows > 0)
                    {
                        transaction?.Commit();
                        int positionHistoryID = PositionService.GetAllHistory().First(w => w.EmployeeID == employee.ID && w.Status == StringConstants.Status.ACTIVE).HistoryID;
                        int civilStatusHistoryID = CivilStatusService.GetAllHistory().First(w => w.EmployeeID == employee.ID && w.Status == StringConstants.Status.ACTIVE).HistoryID;
                        int departmentlocationHistoryID = DepartmentService.GetAllHistory().First(w => w.EmployeeID == employee.ID && w.Status == StringConstants.Status.ACTIVE).HistoryID;
                        int employmentStatusHistoryID = EmploymentStatusService.GetAllHistory().First(w => w.EmployeeID == employee.ID && w.Status == StringConstants.Status.ACTIVE).HistoryID;
                        bool hasRecord = PreviousEmployeeService.RecordExists(employee.ID);

                        PositionService.UpdateHistory(new()
                        {
                            HistoryID = positionHistoryID,
                            PositionID = employee.PositionID,
                            PositionTitle = employee.PositionTitle,
                            Timestamp = employee.PositionEffectiveDate,
                        });

                        CivilStatusService.UpdateHistory(new()
                        {
                            HistoryID = civilStatusHistoryID,
                            CivilStatusID = employee.CivilStatusID
                        });

                        DepartmentService.UpdateHistory(new()
                        {
                            HistoryID = departmentlocationHistoryID,
                            DepartmentName = employee.Department ?? "",
                            LocationName = employee.Location ?? ""
                        });

                        EmploymentStatusService.UpdateHistory(new()
                        {
                            HistoryID = employmentStatusHistoryID,
                            EmploymentStatusID = employee.EmploymentStatusID,
                            Timestamp = employee.StatusEffectiveDate
                        });

                        PreviousEmployeeService.PreviousEmployee updatedPreviousEmployee = new()
                        {
                            EmployeeID = employee.ID,
                            Position = employee.PreviousPosition,
                            StartDate = employee.PreviousFrom,
                            EndDate = employee.PreviousTo,
                            Information = employee.OtherInformation
                        };

                        if (!hasRecord && Convert.ToBoolean(employee.isPreviousEmployee))
                        {
                            PreviousEmployeeService.AddRecord(updatedPreviousEmployee);
                        }
                        else if (hasRecord && Convert.ToBoolean(employee.isPreviousEmployee))
                        {
                            PreviousEmployeeService.UpdateRecord(updatedPreviousEmployee);
                        }
                        else if (hasRecord && Convert.ToBoolean(!employee.isPreviousEmployee))
                        {
                            PreviousEmployeeService.DeleteRecord(employee.ID);
                        }                        

                        if (UserService.CurrentUser != null)
                        {
                            LoggingService.Log newLog = new()
                            {
                                UserID = UserService.CurrentUser.UserID,
                                ActivityType = "Edit",
                                ActivityDetails = $"This user has edited the information of an employee with the ID {employee.EmployeeID}."
                            };

                            LoggingService.LogActivity(newLog);
                        }
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

        public static async Task<bool> UpdateEmployeePosition(EmployeePositionUpdate data)
        {
            try
            {
                using var context = new Context();

                var employee = await context.Employee.FindAsync(data.EmployeeID);

                if (employee == null)
                {
                    return false;
                }

                employee.PositionID = data.PositionID;

                int affectedRows = await context.SaveChangesAsync();

                if (affectedRows > 0)
                {
                    PositionService.History newHistory = new()
                    {
                        EmployeeID = data.EmployeeID,
                        OldPositionID = data.OldPositionID,
                        PositionID = data.PositionID,
                        PositionTitle = data.PositionTitle,
                        SalaryRate = 0,
                        BillingRate = 0,
                        Timestamp = data.Date,
                        Remarks = data.Remarks,
                        Status = StringConstants.Status.ACTIVE
                    };

                    PositionService.AddNewHistory(newHistory);

                    if (UserService.CurrentUser != null)
                    {
                        LoggingService.LogActivity(new()
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
                var employee = await context.Employee.FindAsync(data.EmployeeID);

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

                        LoggingService.LogActivity(newLog);
                    }
                }

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> UpdateEmployeeCivilStatus(EmployeeCivilStatusUpdate data)
        {
            try
            {
                using var context = new Context();
                var employee = await context.Employee.FindAsync(data.EmployeeID);

                if (employee == null)
                {
                    return false;
                }

                employee.CivilStatusID = data.CivilStatusID;

                int affectedRows = await context.SaveChangesAsync();

                if (affectedRows > 0)
                {
                    CivilStatusService.History newHistory = new()
                    {
                        EmployeeID = data.EmployeeID,
                        CivilStatusID = data.CivilStatusID,
                        Timestamp = data.Date,
                        Remarks = data.Remarks,
                        Status = StringConstants.Status.ACTIVE
                    };

                    CivilStatusService.AddNewHistory(newHistory);

                    if (UserService.CurrentUser != null)
                    {
                        LoggingService.Log newLog = new()
                        {
                            UserID = UserService.CurrentUser.UserID,
                            ActivityType = MessagesConstants.UPDATE,
                            ActivityDetails = $"This user has updated the civil status of employee with the ID {data.EmployeeID}."
                        };

                        LoggingService.LogActivity(newLog);
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

                var employee = await context.Employee.FindAsync(data.EmployeeID);

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

                        LoggingService.LogActivity(newLog);
                    }
                }

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

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
                    Birthday = employee.Birthday,
                    Education = employee.Education,
                    Department = employee.DepartmentName,
                    Location = employee.LocationName,
                    EmailAddress1 = employee.EmailAddress1,
                    EmailAddress2 = employee.EmailAddress2,
                    ContactNumber1 = employee.ContactNumber1,
                    ContactNumber2 = employee.ContactNumber2,
                    CivilStatus = employee.CivilStatusName,
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
                    LoggingService.LogActivity(new()
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

                await CivilStatusService.RemoveHistoryByEmployeeID(EmployeeID);
                await DepartmentService.RemoveHistoryByEmployeeID(EmployeeID);
                await EmploymentStatusService.RemoveHistoryByEmployeeID(EmployeeID);
                await PositionService.RemoveHistoryByEmployeeID(EmployeeID);
                await RemoveHistoryByEmployeeID(EmployeeID);

                var employeeToRemove = await context.Employee.FindAsync(EmployeeID);

                if (employeeToRemove != null)
                {
                    context.Employee.Remove(employeeToRemove);
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
