using LBPRDC.Source.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LBPRDC.Source.Services
{
    
    internal class EmployeeService
    {
        public class Employee
        {
            public string? EmployeeID { get; set; }
            public string? LastName { get; set; }
            public string? FirstName { get; set; }
            public string? MiddleName { get; set; }
            public string? Gender { get; set; }
            public DateTime? Birthday { get; set; }
            public string? Education { get; set; }
            public int DepartmentID { get; set; }
            public int LocationID { get; set; }
            public string? EmailAddress1 { get; set; }
            public string? EmailAddress2 { get; set; }
            public string? ContactNumber1 { get; set; }
            public string? ContactNumber2 { get; set; }
            public int CivilStatusID { get; set; }
            public int PositionID { get; set; }
            public int EmploymentStatusID { get; set; }
            public int SuffixID { get; set; }
            public string? Remarks { get; set; }

            public string? FullName { get; set; }
            public string? EmailAddress { get; set; }
            public string? ContactNumber { get; set; }
            public string? CivilStatus { get; set; }
            public string? PositionCode { get; set; }
            public string? PositionName { get; set; }
            public string? Position { get; set; }
            public string? EmploymentStatus { get; set; }
            public string? Suffix { get; set; }
            public decimal SalaryRate { get; set; }
            public decimal BillingRate { get; set; }
            public string? Department { get; set; }
            public string? Location { get; set; }
        }

        public class EmployeeHistory : Employee
        {
            public DateTime EffectiveDate { get; set; }
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
            public int PositionID { get; set; }
            public string? PositionTitle { get; set; }
        }

        public class EmployeeDepartmentLocationUpdate : EmployeeUpdateBase 
        {
            public int DepartmentID { get; set; }
            public int LocationID { get; set; }
        }

        public class EmployeeCivilStatusUpdate : EmployeeUpdateBase
        {
            public int CivilStatusID { get; set; }
        }

        public class EmployeeEmploymentStatusUpdate : EmployeeUpdateBase
        {
            public int EmploymentStatusID { get; set; }
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
                        while (reader.Read())
                        {
                            Employee emp = new()
                            {
                                EmployeeID = reader["EmployeeID"].ToString(),
                                LastName = Utilities.StringFormat.ToSentenceCase((string)reader["LastName"]),
                                FirstName = Utilities.StringFormat.ToSentenceCase((string)reader["FirstName"]),
                                MiddleName = Utilities.StringFormat.ToSentenceCase((string)reader["MiddleName"]),
                                Gender = reader["Gender"].ToString(),
                                Birthday = reader["Birthday"] as DateTime?,
                                Education = reader["Education"].ToString(),
                                DepartmentID = Convert.ToInt32(reader["DepartmentID"]),
                                LocationID = Convert.ToInt32(reader["LocationID"]),
                                EmailAddress1 = reader["EmailAddress1"].ToString(),
                                EmailAddress2 = reader["EmailAddress2"].ToString(),
                                ContactNumber1 = reader["ContactNumber1"].ToString(),
                                ContactNumber2 = reader["ContactNumber2"].ToString(),
                                CivilStatusID = Convert.ToInt32(reader["CivilStatusID"]),
                                PositionID = Convert.ToInt32(reader["PositionID"]),
                                EmploymentStatusID = Convert.ToInt32(reader["EmploymentStatusID"]),
                                SuffixID = Convert.ToInt32(reader["SuffixID"]),
                                Remarks = reader["Remarks"].ToString()
                            };

                            emp.CivilStatus = CivilStatusService.GetAllItems().Where(w => w.ID == emp.CivilStatusID).Select(s => s.Name).FirstOrDefault()?.ToString();
                            emp.EmploymentStatus = EmploymentStatusService.GetAllItems().Where(w => w.ID == emp.EmploymentStatusID).Select(s => s.Name).FirstOrDefault()?.ToString();
                            emp.Suffix = SuffixService.GetAllItems().Where(w => w.ID == emp.SuffixID).Select(s => s.Name).FirstOrDefault()?.ToString();
                            emp.PositionName = PositionService.GetAllItems().Where(w => w.ID == emp.PositionID).Select(s => s.Name).FirstOrDefault()?.ToString();
                            emp.PositionCode = PositionService.GetAllItems().Where(w => w.ID == emp.PositionID).Select(s => s.Code).FirstOrDefault()?.ToString();
                            emp.BillingRate = Convert.ToDecimal(PositionService.GetAllItems().Where(w => w.ID == emp.PositionID).Select(s => s.BillingRate).FirstOrDefault());
                            emp.SalaryRate = Convert.ToDecimal(PositionService.GetAllItems().Where(w => w.ID == emp.PositionID).Select(s => s.SalaryRate).FirstOrDefault());
                            emp.Department = DepartmentService.GetAllItems().Where(w => w.ID == emp.DepartmentID).Select(s => s.Name).FirstOrDefault()?.ToString();
                            emp.Location = LocationService.GetAllItems().Where(w => w.ID == emp.LocationID).Select(s => s.Name).FirstOrDefault()?.ToString();

                            if (preference.ShowName)
                            {
                                string middleInitial = string.IsNullOrWhiteSpace(emp.MiddleName) ? "" : $"{emp.MiddleName[0]}.";
                                string suffix = emp.Suffix == "None" ? "" : emp.Suffix;
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
                                string[] emailAddresses = new[] { emp.EmailAddress1, emp.EmailAddress2 };
                                emp.EmailAddress = preference.SelectedEmailFormat switch
                                {
                                    EmailFormat.FirstOnly => emp.EmailAddress1,
                                    EmailFormat.Both => string.Join(" / ", emailAddresses.Where(email => !string.IsNullOrWhiteSpace(email))),
                                    _ => "Error"
                                };
                            }

                            if (preference.ShowContactNumber)
                            {
                                string[] contactNumbers = new[] { emp.ContactNumber1, emp.ContactNumber2 };
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

        public static async Task<bool> AddNewEmployee(EmployeeHistory employee)
        {
            try
            {
                string query = "INSERT INTO Employee (EmployeeID, LastName, FirstName, MiddleName, SuffixID, Gender, Birthday, Education, DepartmentID, LocationID, EmailAddress1, EmailAddress2, ContactNumber1, ContactNumber2, CivilStatusID, PositionID, EmploymentStatusID, Remarks) " +
                               "VALUES (@EmployeeID, @LastName, @FirstName, @MiddleName, @SuffixID, @Gender, @Birthday, @Education, @DepartmentID, @LocationID, @EmailAddress1, @EmailAddress2, @ContactNumber1, @ContactNumber2, @CivilStatusID, @PositionID, @EmploymentStatusID, @Remarks)";

                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@MiddleName", employee.MiddleName);
                    command.Parameters.AddWithValue("@SuffixID", employee.SuffixID);
                    command.Parameters.AddWithValue("@Gender", employee.Gender);
                    command.Parameters.AddWithValue("@Birthday", employee.Birthday);
                    command.Parameters.AddWithValue("@Education", employee.Education);
                    command.Parameters.AddWithValue("@DepartmentID", employee.DepartmentID);
                    command.Parameters.AddWithValue("@LocationID", employee.LocationID);
                    command.Parameters.AddWithValue("@EmailAddress1", employee.EmailAddress1);
                    command.Parameters.AddWithValue("@EmailAddress2", employee.EmailAddress2);
                    command.Parameters.AddWithValue("@ContactNumber1", employee.ContactNumber1);
                    command.Parameters.AddWithValue("@ContactNumber2", employee.ContactNumber2);
                    command.Parameters.AddWithValue("@CivilStatusID", employee.CivilStatusID);
                    command.Parameters.AddWithValue("@PositionID", employee.PositionID);
                    command.Parameters.AddWithValue("@EmploymentStatusID", employee.EmploymentStatusID);
                    command.Parameters.AddWithValue("@Remarks", employee.Remarks);

                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }

                PositionService.History newPosition = new()
                {
                    EmployeeID = employee.EmployeeID,
                    PositionID = employee.PositionID,
                    PositionTitle = employee.PositionTitle,
                    Timestamp = employee.EffectiveDate,
                    Remarks = "[Initial Status]",
                    Status = "Active"
                };

                CivilStatusService.History newCivilStatus = new()
                {
                    EmployeeID = employee.EmployeeID,
                    CivilStatusID = employee.CivilStatusID,
                    Timestamp = employee.EffectiveDate,
                    Remarks = "[Initial Status]",
                    Status = "Active"
                };

                DepartmentService.History newDepartmentLocation = new()
                { 
                    EmployeeID = employee.EmployeeID,
                    DepartmentID = employee.DepartmentID,
                    LocationID = employee.LocationID,
                    Timestamp = employee.EffectiveDate,
                    Remarks = "[Initial Status]",
                    Status = "Active"
                };

                EmploymentStatusService.History newEmploymentStatus = new()
                {
                    EmployeeID = employee.EmployeeID,
                    EmploymentStatusID = employee.EmploymentStatusID,
                    Timestamp = employee.EffectiveDate,
                    Remarks = "[Initial Status]",
                    Status = "Active"
                };

                PositionService.AddNewHistory(newPosition);
                CivilStatusService.AddNewHistory(newCivilStatus);
                DepartmentService.AddNewHistory(newDepartmentLocation);
                EmploymentStatusService.AddNewHistory(newEmploymentStatus);

                if ((bool)employee.isPreviousEmployee)
                {
                    PreviousEmployeeService.PreviousEmployee entry = new()
                    {
                        EmployeeID = employee.EmployeeID,
                        Position = employee.PreviousPosition,
                        StartDate = employee.PreviousFrom,
                        EndDate = employee.PreviousTo,
                        Information = employee.OtherInformation
                    };

                    PreviousEmployeeService.AddRecord(entry);
                }

                if (UserService.CurrentUser != null)
                {
                    LoggingService.Log newLog = new()
                    { 
                        UserID = UserService.CurrentUser.UserID,
                        Type = "Added New Employee",
                        Details = $"This user added a new employee with ID of {employee.EmployeeID}."
                    };

                    LoggingService.LogActivity(newLog);
                }

                return true;
            } 
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> UpdateEmployee(EmployeeHistory employee)
        {
            try
            {
                string updateQuery = "UPDATE Employee SET " +
                    "LastName = @LastName, " +
                    "FirstName = @FirstName, " +
                    "MiddleName = @MiddleName, " +
                    "SuffixID = @SuffixID, " +
                    "Gender = @Gender, " +
                    "Birthday = @Birthday, " +
                    "Education = @Education, " +
                    "DepartmentID = @DepartmentID, " +
                    "LocationID = @LocationID, " +
                    "EmailAddress1 = @EmailAddress1, " +
                    "EmailAddress2 = @EmailAddress2, " +
                    "ContactNumber1 = @ContactNumber1, " +
                    "ContactNumber2 = @ContactNumber2, " +
                    "CivilStatusID = @CivilStatusID, " +
                    "PositionID = @PositionID, " +
                    "EmploymentStatusId = @EmploymentStatusId, " +
                    "Remarks = @Remarks " +
                    "WHERE EmployeeID = @EmployeeID";

                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@MiddleName", employee.MiddleName);
                    command.Parameters.AddWithValue("@SuffixID", employee.SuffixID);
                    command.Parameters.AddWithValue("@Gender", employee.Gender);
                    command.Parameters.AddWithValue("@Birthday", employee.Birthday);
                    command.Parameters.AddWithValue("@Education", employee.Education);
                    command.Parameters.AddWithValue("@DepartmentID", employee.DepartmentID);
                    command.Parameters.AddWithValue("@LocationID", employee.LocationID);
                    command.Parameters.AddWithValue("@EmailAddress1", employee.EmailAddress1);
                    command.Parameters.AddWithValue("@EmailAddress2", employee.EmailAddress2);
                    command.Parameters.AddWithValue("@ContactNumber1", employee.ContactNumber1);
                    command.Parameters.AddWithValue("@ContactNumber2", employee.ContactNumber2);
                    command.Parameters.AddWithValue("@CivilStatusID", employee.CivilStatusID);
                    command.Parameters.AddWithValue("@PositionID", employee.PositionID);
                    command.Parameters.AddWithValue("@EmploymentStatusID", employee.EmploymentStatusID);
                    command.Parameters.AddWithValue("@Remarks", employee.Remarks);
                    command.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);

                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }

                int positionHistoryID = PositionService.GetAllHistory().Where(w => w.EmployeeID == employee.EmployeeID && w.Status == "Active").First().HistoryID;
                int civilStatusHistoryID = CivilStatusService.GetAllHistory().Where(w => w.EmployeeID == employee.EmployeeID && w.Status == "Active").First().HistoryID;
                int departmentlocationHistoryID = DepartmentService.GetAllHistory().Where(w => w.EmployeeID == employee.EmployeeID && w.Status == "Active").First().HistoryID;
                int employmentStatusHistoryID = EmploymentStatusService.GetAllHistory().Where(w => w.EmployeeID == employee.EmployeeID && w.Status == "Active").First().HistoryID;
                bool hasRecord = PreviousEmployeeService.RecordExists(employee.EmployeeID);

                PositionService.HistoryUpdate updatedPosition = new()
                {
                    HistoryID = positionHistoryID,
                    PositionID = employee.PositionID,
                    PositionTitle = employee.PositionTitle
                };

                CivilStatusService.HistoryUpdate updatedCivilStatus = new()
                {
                    HistoryID = civilStatusHistoryID,
                    CivilStatusID = employee.CivilStatusID
                };

                DepartmentService.HistoryUpdate updatedDepartmentLocation = new()
                {
                    HistoryID = departmentlocationHistoryID,
                    DepartmentID = employee.DepartmentID,
                    LocationID = employee.LocationID
                };

                EmploymentStatusService.HistoryUpdate updatedEmploymentStatus = new()
                {
                    HistoryID = employmentStatusHistoryID,
                    EmploymentStatusID = employee.EmploymentStatusID
                };

                PreviousEmployeeService.PreviousEmployee updatedPreviousEmployee = new()
                {
                    EmployeeID = employee.EmployeeID,
                    Position = employee.PreviousPosition,
                    StartDate = employee.PreviousFrom,
                    EndDate = employee.PreviousTo,
                    Information = employee.OtherInformation
                };

                if (!hasRecord && (bool)employee.isPreviousEmployee)
                {
                    PreviousEmployeeService.AddRecord(updatedPreviousEmployee);
                }
                else if (hasRecord && (bool)employee.isPreviousEmployee)
                {
                    PreviousEmployeeService.UpdateRecord(updatedPreviousEmployee);
                }
                else if (hasRecord && (bool) !employee.isPreviousEmployee)
                {
                    PreviousEmployeeService.DeleteRecord(employee.EmployeeID);
                }

                PositionService.UpdateHistory(updatedPosition);
                CivilStatusService.UpdateHistory(updatedCivilStatus);
                DepartmentService.UpdateHistory(updatedDepartmentLocation);
                EmploymentStatusService.UpdateHistory(updatedEmploymentStatus);

                if (UserService.CurrentUser != null)
                {
                    LoggingService.Log newLog = new()
                    {
                        UserID = UserService.CurrentUser.UserID,
                        Type = "Updated Employee Information",
                        Details = $"This user has edited the information of an employee with the ID {employee.EmployeeID}."
                    };

                    LoggingService.LogActivity(newLog);
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
                    PositionID = data.PositionID,
                    PositionTitle = data.PositionTitle,
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
                        Type = "Promoted/Demoted Employee Position",
                        Details = $"This user has promoted/demoted the position of employee with the ID {data.EmployeeID}."
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
                    DepartmentID = data.DepartmentID,
                    LocationID = data.LocationID,
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
                        Type = "Updated Employee Department and Location",
                        Details = $"This user has updated the department and location of employee with the ID {data.EmployeeID}."
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
                        Type = "Updated Employee Civil Status",
                        Details = $"This user has updated the civil status of employee with the ID {data.EmployeeID}."
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
                        Type = "Updated Employee Employment Status",
                        Details = $"This user has updated the employment status of employee with the ID {data.EmployeeID}."
                    };

                    LoggingService.LogActivity(newLog);
                }

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }
    }
}
