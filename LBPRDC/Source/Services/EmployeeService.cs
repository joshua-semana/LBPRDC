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
        public int ID { get; set; }
        public string? EmployeeID { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Suffix { get; set; }
        public string? DepartmentName { get; set; }
        public string? EmailAddress { get; set; }
        public string? ContactNumber { get; set; }
        public string? MarriageStatus { get; set; }
        public DateTime? DateOfUpdateOfMarriageStatus { get; set; }
        public DateTime DateHired { get; set; }
        public string? EmploymentStatus { get; set; }
        public DateTime? DateOfEmploymentStatusChange { get; set; }
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
                                ID = Convert.ToInt32(reader["ID"]),
                                EmployeeID = reader["EmployeeID"].ToString(),
                                FirstName = reader["FirstName"].ToString(),
                                MiddleName = reader["MiddleName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Suffix = reader["Suffix"].ToString(),
                                DepartmentName = reader["DepartmentName"].ToString(),
                                EmailAddress = reader["EmailAddress"].ToString(),
                                ContactNumber = reader["ContactNumber"].ToString(),
                                MarriageStatus = reader["MarriageStatus"].ToString(),
                                DateOfUpdateOfMarriageStatus = reader["DateOfUpdateOfMarriageStatus"] as DateTime?,
                                DateHired = Convert.ToDateTime(reader["DateHired"]),
                                EmploymentStatus = reader["EmploymentStatus"].ToString(),
                                DateOfEmploymentStatusChange = reader["DateOfEmploymentStatusChange"] as DateTime?
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
