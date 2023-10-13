using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBPRDC.Source.Services
{
    internal class SuffixService
    {
        public class SuffixItems
        {
            public int ID { get; set; }
            public string? Name { get; set; }
        }

        public static List<SuffixItems> GetSuffixItems()
        {
            List<SuffixItems> items = new();

            try
            {
                string query = "SELECT ID, Name FROM Suffix";
                using (SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString()))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        SuffixItems item = new()
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Name = reader["Name"].ToString()
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
