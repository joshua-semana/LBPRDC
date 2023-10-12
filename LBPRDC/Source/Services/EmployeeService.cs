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
        public string? Suffix { get; set; }
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
    }

    public class NewEmployee : Employee
    {
        public DateTime StartDate { get; set; }
        public string? PositionTitle { get; set; }
    }

    internal class EmployeeService
    {
        public static List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            try
            {
                string query = "SELECT * FROM Employee";

                using (SqlConnection connection = new SqlConnection(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee emp = new Employee()
                            {
                                EmployeeID = reader["EmployeeID"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                FirstName = reader["FirstName"].ToString(),
                                MiddleName = reader["MiddleName"].ToString(),
                                Suffix = reader["Suffix"].ToString(),
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
                                EmploymentStatusID = Convert.ToInt32("EmploymentStatusID")
                            };

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

        public void AddNewEmployee(NewEmployee employee)
        {
            try
            {
                string query = "INSERT INTO Employee (EmployeeID, LastName, FirstName, MiddleName, Suffix, Gender, Birthday, Education, Department, EmailAddress1, EmailAddress2, ContactNumber1, ContactNumber2, CivilStatusID, PositionID, EmploymentStatusID) " +
                    "VALUES (@EmployeeID, @LastName, @FirstName, @MiddleName, @Suffix, @Gender, @Birthday, @Education, @Department, @EmailAddress1, @EmailAddress2, @ContactNumber1, @ContactNumber2, @CivilStatusID, @PositionID, @EmploymentStatusID)";

                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@MiddleName", employee.MiddleName);
                    command.Parameters.AddWithValue("@Suffix", employee.Suffix);
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
                    command.ExecuteNonQuery();
                }
            } 
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }
    }
}
