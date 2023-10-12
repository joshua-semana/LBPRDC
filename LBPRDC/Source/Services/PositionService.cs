using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LBPRDC.Source.Services.EmploymentStatusService;

namespace LBPRDC.Source.Services
{
    internal class PositionService
    {
        public class PositionItems
        {
            public int ID { get; set; }
            public string? Code { get; set; }
            public string? Name { get; set; }
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
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }

            return items;
        }
    }
}
