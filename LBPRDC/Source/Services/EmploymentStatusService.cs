﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LBPRDC.Source.Services.CivilStatusService;

namespace LBPRDC.Source.Services
{
    internal class EmploymentStatusService
    {
        public class EmploymentStatusItems
        {
            public int ID { get; set; }
            public string? Status { get; set; }
        }

        public static List<EmploymentStatusItems> GetEmploymentStatusItems()
        {
            List<EmploymentStatusItems> items = new();

            try
            {
                EmploymentStatusItems blankItem = new()
                {
                    ID = 0,
                    Status = "(Choose Status)"
                };
                items.Add(blankItem);

                string query = "SELECT ID, Status FROM EmploymentStatus";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        EmploymentStatusItems item = new()
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Status = reader["Status"].ToString()
                        };

                        items.Add(item);
                    }
                }
            } 
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }

            return items;
        }
    }
}