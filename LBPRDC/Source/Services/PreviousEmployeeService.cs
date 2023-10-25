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
            public int ID { get; set; }
            public bool HasRecord { get; set; }
            public string? EmployeeID { get; set; }
            public string? Position { get; set; }
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public string? Information { get; set; }
        }

        public static void AddRecord(PreviousEmployee employee)
        {
            try
            {
                string query = "INSERT INTO EmployeePreviousRecord (EmployeeID, Position, StartDate, EndDate, Information) " +
                               "VALUES (@EmployeeID, @Position, @StartDate, @EndDate, @Information)";

                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                    command.Parameters.AddWithValue("@Position", employee.Position);
                    command.Parameters.AddWithValue("@StartDate", employee.StartDate);
                    command.Parameters.AddWithValue("@EndDate", employee.EndDate);
                    command.Parameters.AddWithValue("@Information", employee.Information);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }

        public static PreviousEmployee GetRecordByEmployeeID(string ID)
        {
            PreviousEmployee record = new();

            try
            {
                string query = "SELECT * FROM EmployeePreviousRecord WHERE EmployeeID = @EmployeeID";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", ID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            record = new()
                            {
                                HasRecord = true,
                                ID = Convert.ToInt32(reader["ID"]),
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

        public static bool RecordExists(string ID)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM EmployeePreviousRecord WHERE EmployeeID = @EmployeeID";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", ID);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static void UpdateRecord(PreviousEmployee data)
        {
            try
            {
                string updateQuery = "UPDATE EmployeePreviousRecord SET " +
                    "Position = @Position," +
                    "StartDate = @StartDate," +
                    "EndDate = @EndDate," +
                    "Information = @Information " +
                    "WHERE EmployeeID = @EmployeeID";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Position", data.Position);
                    command.Parameters.AddWithValue("@StartDate", data.StartDate);
                    command.Parameters.AddWithValue("@EndDate", data.EndDate);
                    command.Parameters.AddWithValue("@Information", data.Information);
                    command.Parameters.AddWithValue("@EmployeeID", data.EmployeeID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }

        public static void DeleteRecord(string EmployeeID)
        {
            try
            {
                string updateQuery = "DELETE FROM EmployeePreviousRecord WHERE EmployeeID = @EmployeeID";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }
    }
}
