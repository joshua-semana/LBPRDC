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
    }
}
