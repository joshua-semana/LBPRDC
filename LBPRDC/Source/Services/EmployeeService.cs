using LBPRDC.Source.Views.EmployeeFlow;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBPRDC.Source.Services
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
        public string? Department { get; set; }
        public string? EmailAddress1 { get; set; }
        public string? EmailAddress2 { get; set; }
        public string? ContactNumber1 { get; set; }
        public string? ContactNumber2 { get; set; }
        public int CivilStatusID { get; set; }
        public int PositionID { get; set; }
        public int EmploymentStatusID { get; set; }
        public int SuffixID { get; set; }
        public string? FullName { get; set; }
        public string? EmailAddress { get; set; }
        public string? ContactNumber { get; set; }
        public string? CivilStatus { get; set; }
        public string? PositionCode { get; set; }
        public string? PositionName { get; set; }
        public string? Position { get; set; }
        public string? EmploymentStatus { get; set; }
        public string? Suffix { get; set; }
    }

    public class NewEmployee : Employee
    {
        public DateTime StartDate { get; set; }
        public string? PositionTitle { get; set; }
        public string? Remarks { get; set; }
    }

    internal class EmployeeService
    {
        private static UserPreference preference;
        public static List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            preference = PreferenceManager.LoadPreference();
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
                                LastName = reader["LastName"].ToString(),
                                FirstName = reader["FirstName"].ToString(),
                                MiddleName = reader["MiddleName"].ToString(),
                                Gender = reader["Gender"].ToString(),
                                Birthday = reader["Birthday"] as DateTime?,
                                Education = reader["Education"].ToString(),
                                Department = reader["Department"].ToString(),
                                EmailAddress1 = reader["EmailAddress1"].ToString(),
                                EmailAddress2 = reader["EmailAddress2"].ToString(),
                                ContactNumber1 = reader["ContactNumber1"].ToString(),
                                ContactNumber2 = reader["ContactNumber2"].ToString(),
                                CivilStatusID = Convert.ToInt32(reader["CivilStatusID"]),
                                PositionID = Convert.ToInt32(reader["PositionID"]),
                                EmploymentStatusID = Convert.ToInt32(reader["EmploymentStatusID"]),
                                SuffixID = Convert.ToInt32(reader["SuffixID"]),
                            };

                            emp.CivilStatus = CivilStatusService.GetStatusByID(emp.CivilStatusID);
                            emp.PositionCode = PositionService.GetCodeByID(emp.PositionID);
                            emp.PositionName = PositionService.GetNameByID(emp.PositionID);
                            emp.EmploymentStatus = EmploymentStatusService.GetStatusByID(emp.EmploymentStatusID);
                            emp.Suffix = SuffixService.GetSuffixByID(emp.SuffixID);

                            if (preference.ShowName)
                            {
                                string middleInitial = string.IsNullOrWhiteSpace(emp.MiddleName) ? "" : $"{emp.MiddleName[0]}.";
                                emp.FullName = preference.SelectedNameFormat switch
                                {
                                    NameFormat.Full1 => $"{emp.FirstName} {middleInitial} {emp.LastName} {emp.Suffix}".Trim(),
                                    NameFormat.Full2 => $"{emp.LastName}, {emp.FirstName} {middleInitial} {emp.Suffix}".Trim(),
                                    NameFormat.FirstAndLastOnly => $"{emp.FirstName} {emp.LastName}".Trim(),
                                    _ => "Error"
                                };
                            }

                            if (preference.ShowEmailAddress)
                            {
                                emp.EmailAddress = preference.SelectedEmailFormat switch
                                {
                                    EmailFormat.FirstOnly => emp.EmailAddress1,
                                    EmailFormat.Both => string.Join(" / ", emp.EmailAddress1, emp.EmailAddress2),
                                    _ => "Error"
                                };
                            }

                            if (preference.ShowContactNumber)
                            {
                                emp.ContactNumber = preference.SelectedContactFormat switch
                                {
                                    ContactFormat.FirstOnly => emp.ContactNumber1,
                                    ContactFormat.Both => string.Join(" / ", emp.ContactNumber1, emp.ContactNumber2),
                                    _ => "Error"
                                };
                            }

                            if (preference.ShowPosition )
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
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }

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
            catch (Exception ex)
            {
                return ExceptionHandler.HandleException(ex);
            }
        }

        public static async Task<bool> AddNewEmployee(NewEmployee employee)
        {
            try
            {
                string query = "INSERT INTO Employee (EmployeeID, LastName, FirstName, MiddleName, SuffixID, Gender, Birthday, Education, Department, EmailAddress1, EmailAddress2, ContactNumber1, ContactNumber2, CivilStatusID, PositionID, EmploymentStatusID) " +
                    "VALUES (@EmployeeID, @LastName, @FirstName, @MiddleName, @SuffixID, @Gender, @Birthday, @Education, @Department, @EmailAddress1, @EmailAddress2, @ContactNumber1, @ContactNumber2, @CivilStatusID, @PositionID, @EmploymentStatusID)";

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
                    command.Parameters.AddWithValue("@Department", employee.Department);
                    command.Parameters.AddWithValue("@EmailAddress1", employee.EmailAddress1);
                    command.Parameters.AddWithValue("@EmailAddress2", employee.EmailAddress2);
                    command.Parameters.AddWithValue("@ContactNumber1", employee.ContactNumber1);
                    command.Parameters.AddWithValue("@ContactNumber2", employee.ContactNumber2);
                    command.Parameters.AddWithValue("@CivilStatusID", employee.CivilStatusID);
                    command.Parameters.AddWithValue("@PositionID", employee.PositionID);
                    command.Parameters.AddWithValue("@EmploymentStatusID", employee.EmploymentStatusID);

                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }

                PositionService.NewHistory newPosition = new()
                {
                    EmployeeID = employee.EmployeeID,
                    PositionID = employee.PositionID,
                    PositionTitle = employee.PositionTitle,
                    Timestamp = employee.StartDate,
                    Remarks = employee.Remarks,
                };

                PositionService.AddToHistory(newPosition);

                CivilStatusService.NewHistory newCivilStatus = new()
                {
                    EmployeeID = employee.EmployeeID,
                    CivilStatusID = employee.CivilStatusID,
                    Timestamp = employee.StartDate,
                    Remarks = "Status when hired."
                };

                CivilStatusService.AddToHistory(newCivilStatus);

                EmploymentStatusService.NewHistory newEmploymentStatus = new()
                {
                    EmployeeID = employee.EmployeeID,
                    EmploymentStatusID = employee.EmploymentStatusID,
                    Timestamp = employee.StartDate,
                    Remarks = "Status when hired."
                };

                EmploymentStatusService.AddToHistory(newEmploymentStatus);

                if (UserManager.Instance.CurrentUser != null)
                {
                    LoggingService.LogActivity(UserManager.Instance.CurrentUser.UserID, "Added New Employee", $"This user added new employee with ID: {employee.EmployeeID}");
                }

                return true;
            } 
            catch (Exception ex)
            {
                return ExceptionHandler.HandleException(ex);
            }
        }
    }
}
