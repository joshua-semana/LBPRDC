using LBPRDC.Source.Utilities;
using System.Data.SqlClient;
using Dapper;
using LBPRDC.Source.Data;
using static LBPRDC.Source.Services.CivilStatusService;
using static LBPRDC.Source.Services.DepartmentService;
using static LBPRDC.Source.Services.EmployeeService;
using static LBPRDC.Source.Services.EmploymentStatusService;
using static LBPRDC.Source.Services.LocationService;
using static LBPRDC.Source.Services.PositionService;
using static LBPRDC.Source.Services.SuffixService;
using System.Collections.Generic;
using System.Net.Mail;
using System.Transactions;

namespace LBPRDC.Source.Services
{
    public class EmployeeBase
    {
        public string? EmployeeID { get; set; }
        public int ClientID { get; set; }
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
            public string? EmployeeID { get; set; }
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

        public static List<EmployeeBase> GetAllEmployeesBase()
        {
            List<EmployeeBase> employees = new();

            try
            {
                string querySelect = "SELECT EmployeeID, LastName, FirstName, MiddleName, DepartmentID, PositionID, LocationID FROM Employee";
                using SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString());
                using SqlCommand command = new(querySelect, connection);
                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();

                var Department = DepartmentService.GetAllItems();
                var Location = LocationService.GetAllItems();
                var Position = PositionService.GetAllItems();

                while (reader.Read())
                {
                    EmployeeBase employee = new()
                    {
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

        private static UserPreference preference;
        public static List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new();
            preference = UserPreferenceManager.LoadPreference();
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
                        var Department = DepartmentService.GetAllItems();
                        var Location = LocationService.GetAllItems();
                        var Position = PositionService.GetAllItems();

                        while (reader.Read())
                        {
                            Employee emp = new()
                            {
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
                                    _ => "Error"
                                };
                            }

                            if (preference.ShowEmailAddress)
                            {
                                string?[] emailAddresses = new[] { emp.EmailAddress1, emp.EmailAddress2 };
                                emp.EmailAddress = preference.SelectedEmailFormat switch
                                {
                                    EmailFormat.FirstOnly => emp.EmailAddress1,
                                    EmailFormat.Both => string.Join(" / ", emailAddresses.Where(email => !string.IsNullOrWhiteSpace(email))),
                                    _ => "Error"
                                };
                            }

                            if (preference.ShowContactNumber)
                            {
                                string?[] contactNumbers = new[] { emp.ContactNumber1, emp.ContactNumber2 };
                                emp.ContactNumber = preference.SelectedContactFormat switch
                                {
                                    ContactFormat.FirstOnly => emp.ContactNumber1,
                                    ContactFormat.Both => string.Join(" / ", contactNumbers.Where(number => !string.IsNullOrWhiteSpace(number))),
                                    _ => "Error"
                                };
                            }

                            if (preference.ShowPosition)
                            {
                                emp.Position = preference.SelectedPositionFormat switch
                                {
                                    PositionFormat.NameOnly => emp.PositionName,
                                    PositionFormat.CodeOnly => emp.PositionCode,
                                    PositionFormat.Both => string.Join(" - ", emp.PositionCode, emp.PositionName),
                                    _ => "Error"
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

        public static bool IDExists(string ID)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Employee WHERE EmployeeID = @ID";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
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
                        Remarks
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
                        @Remarks)";

                    int affectedRows = await connection.ExecuteAsync(QueryInsert, data, transaction);

                    if (affectedRows > 0)
                    {
                        List<Department> departmentList = DepartmentService.GetAllItems();
                        List<Location> locationList = LocationService.GetAllItems();

                        const string REMARKS_INITIAL = "Initial Status";
                        const string STATUS_ACTIVE = "Active";

                        PositionService.History newPosition = new()
                        {
                            EmployeeID = data.EmployeeID,
                            PositionID = data.PositionID,
                            PositionTitle = data.PositionTitle,
                            SalaryRate = 0,
                            BillingRate = 0,
                            Timestamp = data.StartDate,
                            Remarks = REMARKS_INITIAL,
                            Status = STATUS_ACTIVE
                        };

                        CivilStatusService.History newCivilStatus = new()
                        {
                            EmployeeID = data.EmployeeID,
                            CivilStatusID = data.CivilStatusID,
                            Timestamp = data.StartDate,
                            Remarks = REMARKS_INITIAL,
                            Status = STATUS_ACTIVE
                        };

                        DepartmentService.History newDepartmentLocation = new()
                        {
                            EmployeeID = data.EmployeeID,
                            DepartmentName = departmentList.First(w => w.ID == data.DepartmentID).Name ?? "",
                            LocationName = locationList.First(w => w.ID == data.LocationID).Name ?? "",
                            Timestamp = data.StartDate,
                            Remarks = REMARKS_INITIAL,
                            Status = STATUS_ACTIVE
                        };

                        EmploymentStatusService.History newEmploymentStatus = new()
                        {
                            EmployeeID = data.EmployeeID,
                            EmploymentStatusID = data.EmploymentStatusID,
                            Timestamp = data.StartDate,
                            Remarks = REMARKS_INITIAL,
                            Status = STATUS_ACTIVE
                        };

                        PositionService.AddNewHistory(newPosition);
                        CivilStatusService.AddNewHistory(newCivilStatus);
                        DepartmentService.AddNewHistory(newDepartmentLocation);
                        EmploymentStatusService.AddNewHistory(newEmploymentStatus);

                        if (Convert.ToBoolean(data.isPreviousEmployee))
                        {
                            PreviousEmployeeService.PreviousEmployee entry = new()
                            {
                                EmployeeID = data.EmployeeID,
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
                                ActivityType = "Add",
                                ActivityDetails = $"This user added a new employee with ID of {data.EmployeeID}."
                            };

                            LoggingService.LogActivity(newLog);
                        }
                    }
                    transaction?.Commit();
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
                            Remarks = @Remarks
                        WHERE 
                            EmployeeID = @EmployeeID;";

                    int affectedRows = await connection.ExecuteAsync(QueryUpdate, employee, transaction);

                    if (affectedRows > 0)
                    {
                        transaction?.Commit();
                        int positionHistoryID = PositionService.GetAllHistory().First(w => w.EmployeeID == employee.EmployeeID && w.Status == "Active").HistoryID;
                        int civilStatusHistoryID = CivilStatusService.GetAllHistory().First(w => w.EmployeeID == employee.EmployeeID && w.Status == "Active").HistoryID;
                        int departmentlocationHistoryID = DepartmentService.GetAllHistory().First(w => w.EmployeeID == employee.EmployeeID && w.Status == "Active").HistoryID;
                        int employmentStatusHistoryID = EmploymentStatusService.GetAllHistory().First(w => w.EmployeeID == employee.EmployeeID && w.Status == "Active").HistoryID;
                        bool hasRecord = PreviousEmployeeService.RecordExists(employee.EmployeeID);

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
                            EmployeeID = employee.EmployeeID,
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
                            PreviousEmployeeService.DeleteRecord(employee.EmployeeID);
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
                string updateQuery = "UPDATE Employee SET " +
                    "PositionID = @PositionID " +
                    "WHERE EmployeeID = @EmployeeID";

                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@PositionID", data.PositionID);
                    command.Parameters.AddWithValue("@EmployeeID", data.EmployeeID);

                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }

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
                    Status = "Active"
                };

                PositionService.AddNewHistory(newHistory);

                if (UserService.CurrentUser != null)
                {
                    LoggingService.Log newLog = new()
                    {
                        UserID = UserService.CurrentUser.UserID,
                        ActivityType = "Update",
                        ActivityDetails = $"This user has promoted/demoted the position of employee with the ID {data.EmployeeID}."
                    };

                    LoggingService.LogActivity(newLog);
                }

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> UpdateEmployeeDepartmentLocation(EmployeeDepartmentLocationUpdate data)
        {
            try
            {
                string updateQuery = "UPDATE Employee SET " +
                    "DepartmentID = @DepartmentID, " +
                    "LocationID = @LocationID " +
                    "WHERE EmployeeID = @EmployeeID";

                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@DepartmentID", data.DepartmentID);
                    command.Parameters.AddWithValue("@LocationID", data.LocationID);
                    command.Parameters.AddWithValue("@EmployeeID", data.EmployeeID);

                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }

                DepartmentService.History newHistory = new()
                {
                    EmployeeID = data.EmployeeID,
                    DepartmentName = data.DepartmentName,
                    LocationName = data.LocationName,
                    Timestamp = data.Date,
                    Remarks = data.Remarks,
                    Status = "Active"
                };

                DepartmentService.AddNewHistory(newHistory);

                if (UserService.CurrentUser != null)
                {
                    LoggingService.Log newLog = new()
                    {
                        UserID = UserService.CurrentUser.UserID,
                        ActivityType = "Update",
                        ActivityDetails = $"This user has updated the department and location of employee with the ID {data.EmployeeID}."
                    };

                    LoggingService.LogActivity(newLog);
                }

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> UpdateEmployeeCivilStatus(EmployeeCivilStatusUpdate data)
        {
            try
            {
                string updateQuery = "UPDATE Employee SET " +
                    "CivilStatusID = @CivilStatusID " +
                    "WHERE EmployeeID = @EmployeeID";

                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@CivilStatusID", data.CivilStatusID);
                    command.Parameters.AddWithValue("@EmployeeID", data.EmployeeID);

                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }

                CivilStatusService.History newHistory = new()
                {
                    EmployeeID = data.EmployeeID,
                    CivilStatusID = data.CivilStatusID,
                    Timestamp = data.Date,
                    Remarks = data.Remarks,
                    Status = "Active"
                };

                CivilStatusService.AddNewHistory(newHistory);

                if (UserService.CurrentUser != null)
                {
                    LoggingService.Log newLog = new()
                    {
                        UserID = UserService.CurrentUser.UserID,
                        ActivityType = "Update",
                        ActivityDetails = $"This user has updated the civil status of employee with the ID {data.EmployeeID}."
                    };

                    LoggingService.LogActivity(newLog);
                }

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> UpdateEmployeeEmploymentStatus(EmployeeEmploymentStatusUpdate data)
        {
            try
            {
                string updateQuery = "UPDATE Employee SET " +
                    "EmploymentStatusID = @EmploymentStatusID " +
                    "WHERE EmployeeID = @EmployeeID";

                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@EmploymentStatusID", data.EmploymentStatusID);
                    command.Parameters.AddWithValue("@EmployeeID", data.EmployeeID);

                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }

                EmploymentStatusService.History newHistory = new()
                {
                    EmployeeID = data.EmployeeID,
                    EmploymentStatusID = data.EmploymentStatusID,
                    Timestamp = data.Date,
                    Remarks = data.Remarks,
                    Status = "Active"
                };

                EmploymentStatusService.AddNewHistory(newHistory);

                if (UserService.CurrentUser != null)
                {
                    LoggingService.Log newLog = new()
                    {
                        UserID = UserService.CurrentUser.UserID,
                        ActivityType = "Update",
                        ActivityDetails = $"This user has updated the employment status of employee with the ID {data.EmployeeID}."
                    };

                    LoggingService.LogActivity(newLog);
                }

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static bool ArchiveEmployee(string EmployeeID)
        {
            try
            {
                var Suffix = SuffixService.GetAllItems();
                var Department = DepartmentService.GetAllItems();
                var Location = LocationService.GetAllItems();
                var CivilStatus = CivilStatusService.GetAllItems();
                var Position = PositionService.GetAllItems();
                var EmploymentStatus = EmploymentStatusService.GetAllItems();

                string QuerySelect = $"SELECT * FROM Employee WHERE EmployeeID = '{EmployeeID}'";
                using SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString());
                using SqlCommand commandSelect = new(QuerySelect, connection);
                connection.Open();
                using SqlDataReader reader = commandSelect.ExecuteReader();

                if (reader.Read())
                {
                    Employee employee = new()
                    {
                        EmployeeID = Convert.ToString(reader["EmployeeID"]),
                        LastName = Convert.ToString(reader["LastName"]),
                        FirstName = Convert.ToString(reader["FirstName"]),
                        MiddleName = Convert.ToString(reader["MiddleName"]),
                        Suffix = Suffix.First(f => f.ID == Convert.ToInt32(reader["SuffixID"])).Name,
                        Gender = Convert.ToString(reader["Gender"]),
                        Birthday = Convert.ToDateTime(reader["Birthday"]),
                        Education = Convert.ToString(reader["Education"]),
                        Department = Department.First(f => f.ID == Convert.ToInt32(reader["DepartmentID"])).Name,
                        Location = Location.First(f => f.ID == Convert.ToInt32(reader["LocationID"])).Name,
                        EmailAddress1 = Convert.ToString(reader["EmailAddress1"]),
                        EmailAddress2 = Convert.ToString(reader["EmailAddress2"]),
                        ContactNumber1 = Convert.ToString(reader["ContactNumber1"]),
                        ContactNumber2 = Convert.ToString(reader["ContactNumber2"]),
                        CivilStatus = CivilStatus.First(f => f.ID == Convert.ToInt32(reader["CivilStatusID"])).Name,
                        Position = Position.First(f => f.ID == Convert.ToInt32(reader["PositionID"])).Name,
                        EmploymentStatus = EmploymentStatus.First(f => f.ID == Convert.ToInt32(reader["EmploymentStatusID"])).Name,
                        Remarks = Convert.ToString(reader["Remarks"])
                    };

                    AddToArchive(employee);
                    RemoveEmployeeRecord(EmployeeID);

                    if (UserService.CurrentUser != null)
                    {
                        LoggingService.Log newLog = new()
                        {
                            UserID = UserService.CurrentUser.UserID,
                            ActivityType = "Archive",
                            ActivityDetails = $"This user has archived an employee with the ID {EmployeeID}."
                        };

                        LoggingService.LogActivity(newLog);
                    }
                }
                else
                {
                    MessageBox.Show("There seems to be a problem archiving this employee. Please contact support");
                    return false;
                }
                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        private static void AddToArchive(Employee employee)
        {
            try
            {
                string QueryInsert = "INSERT INTO Archive_Employee (EmployeeID, LastName, FirstName, MiddleName, Suffix, Gender, Birthday, Education, Department, Location, EmailAddress1, EmailAddress2, ContactNumber1, ContactNumber2, CivilStatus, Position, EmploymentStatus, Remarks) " +
                                "VALUES (@EmployeeID, @LastName, @FirstName, @MiddleName, @Suffix, @Gender, @Birthday, @Education, @Department, @Location, @EmailAddress1, @EmailAddress2, @ContactNumber1, @ContactNumber2, @CivilStatus, @Position, @EmploymentStatus, @Remarks)";
                using SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString());
                using SqlCommand commandInsert = new(QueryInsert, connection);
                commandInsert.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                commandInsert.Parameters.AddWithValue("@LastName", employee.LastName);
                commandInsert.Parameters.AddWithValue("@FirstName", employee.FirstName);
                commandInsert.Parameters.AddWithValue("@MiddleName", employee.MiddleName);
                commandInsert.Parameters.AddWithValue("@Suffix", employee.Suffix);
                commandInsert.Parameters.AddWithValue("@Gender", employee.Gender);
                commandInsert.Parameters.AddWithValue("@Birthday", employee.Birthday);
                commandInsert.Parameters.AddWithValue("@Education", employee.Education);
                commandInsert.Parameters.AddWithValue("@Department", employee.Department);
                commandInsert.Parameters.AddWithValue("@Location", employee.Location);
                commandInsert.Parameters.AddWithValue("@EmailAddress1", employee.EmailAddress1);
                commandInsert.Parameters.AddWithValue("@EmailAddress2", employee.EmailAddress2);
                commandInsert.Parameters.AddWithValue("@ContactNumber1", employee.ContactNumber1);
                commandInsert.Parameters.AddWithValue("@ContactNumber2", employee.ContactNumber2);
                commandInsert.Parameters.AddWithValue("@CivilStatus", employee.CivilStatus);
                commandInsert.Parameters.AddWithValue("@Position", employee.Position);
                commandInsert.Parameters.AddWithValue("@EmploymentStatus", employee.EmploymentStatus);
                commandInsert.Parameters.AddWithValue("@Remarks", employee.Remarks);
                connection.Open();
                commandInsert.ExecuteNonQuery();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }

        private static void RemoveEmployeeRecord(string EmployeeID)
        {
            try
            {
                string QueryDelete = $"DELETE FROM EmployeeCivilStatusHistory WHERE EmployeeID = '{EmployeeID}';" +
                            $"DELETE FROM EmployeeDepartmentLocationHistory WHERE EmployeeID = '{EmployeeID}';" +
                            $"DELETE FROM EmployeeEmploymentHistory WHERE EmployeeID = '{EmployeeID}';" +
                            $"DELETE FROM EmployeePositionHistory WHERE EmployeeID = '{EmployeeID}';" +
                            $"DELETE FROM EmployeePreviousRecord WHERE EmployeeID = '{EmployeeID}';" +
                            $"DELETE FROM Employee WHERE EmployeeID = '{EmployeeID}';";
                using SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString());
                using SqlCommand commandDelete = new(QueryDelete, connection);
                connection.Open();
                commandDelete.ExecuteNonQuery();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }
    }
}
