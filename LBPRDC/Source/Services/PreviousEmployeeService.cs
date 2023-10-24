using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBPRDC.Source.Services
{
    internal class PreviousEmployeeService
    {
        public class PreviousEmployee
        {
            public bool HasRecord { get; set; }
            public string? EmployeeID { get; set; }
            public string? Position { get; set; }
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public string? Information { get; set; }
        }

        public static void AddRecord(PreviousEmployee emp)
        {
            try
            {
                string query = "INSERT INTO PreviousEmployee (EmployeeID, Position, StartDate, EndDate, Information) " +
                               "VALUES (@EmployeeID, @Position, @StartDate, @EndDate, @Information)";

                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", emp.EmployeeID);
                    command.Parameters.AddWithValue("@Position", emp.Position);
                    command.Parameters.AddWithValue("@StartDate", emp.StartDate);
                    command.Parameters.AddWithValue("@EndDate", emp.EndDate);
                    command.Parameters.AddWithValue("@Information", emp.Information);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }

        public static PreviousEmployee GetRecordByEmployeeID(string empID)
        {
            PreviousEmployee record = new();

            try
            {
                string query = "SELECT * FROM PreviousEmployee WHERE EmployeeID = @EmployeeID";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", empID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            record = new()
                            {
                                HasRecord = true,
                                EmployeeID = reader["EmployeeID"].ToString(),
                                Position = reader["Position"].ToString(),
                                StartDate = reader["StartDate"] as DateTime?,
                                EndDate = reader["EndDate"] as DateTime?,
                                Information = reader["Information"].ToString(),
                            };
                        }
                        else
                        {
                            record = new()
                            {
                                HasRecord = false
                            };
                        }
                    }
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException (ex); }

            return record;
        }
    }
}
