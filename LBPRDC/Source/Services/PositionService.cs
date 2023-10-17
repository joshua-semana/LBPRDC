﻿using System.Data.SqlClient;

namespace LBPRDC.Source.Services
{
    internal class PositionService
    {
        public class Position
        {
            public int ID { get; set; }
            public string? Code { get; set; }
            public string? Name { get; set; }
            public decimal SalaryRate { get; set; }
            public decimal BillingRate { get; set; }
        }

        public class PositionItems : Position
        {
            public string DisplayText => $"{Code} - {Name}";
        }

        public static List<PositionItems> GetPositionItems()
        {
            List<PositionItems> items = new();

            try
            {
                PositionItems blankItem = new()
                {
                    ID = 0,
                    Code = "(Choose Position)",
                    Name = ""
                };
                items.Add(blankItem);

                string query = "SELECT ID, Code, Name FROM Position";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        PositionItems item = new()
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString()
                        };

                        items.Add(item);
                    }
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }

        public static List<Position> GetPositionDetailsByID(int id)
        {
            List<Position> items = new();

            try
            {
                string query = "SELECT * FROM Position WHERE ID = @ID";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Position item = new()
                            {
                                Code = reader["Code"].ToString(),
                                Name = reader["Name"].ToString(),
                                SalaryRate = Convert.ToDecimal(reader["SalaryRate"]),
                                BillingRate = Convert.ToDecimal(reader["BillingRate"])
                            };

                            items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }

        public class NewHistory
        {
            public string? EmployeeID { get; set; }
            public int PositionID { get; set; }
            public string? PositionTitle { get; set; }
            public DateTime? Timestamp { get; set; }
            public string? Remarks { get; set;}
        }

        public static void AddToHistory(NewHistory history)
        {
            try
            {
                string query = "INSERT INTO EmployeePositionHistory (EmployeeID, PositionID, PositionTitle, Timestamp, Remarks)" +
                    "VALUES (@EmployeeID, @PositionID, @PositionTitle, @Timestamp, @Remarks)";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", history.EmployeeID);
                    command.Parameters.AddWithValue("@PositionID", history.PositionID);
                    command.Parameters.AddWithValue("@PositionTitle", history.PositionTitle);
                    command.Parameters.AddWithValue("@Timestamp", history.Timestamp);
                    command.Parameters.AddWithValue("@Remarks", history.Remarks);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }
    }
}
