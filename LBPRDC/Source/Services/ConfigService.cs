using System.Data.SqlClient;

namespace LBPRDC.Source.Services
{
    internal class ConfigService
    {
        public static (int MinYear, int MaxYear) GetBillingComboBoxYearConfig()
        {
            int MinYear = 0;
            int MaxYear = 0;
            try
            {
                string query = "SELECT Name, Data FROM Config WHERE Name IN ('MinYearComboBox', 'MaxYearComboBox')";
                using SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString());
                using SqlCommand command = new(query, connection);

                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string name = Convert.ToString(reader["Name"]);
                    int data = Convert.ToInt32(reader["Data"]);

                    switch (name)
                    {
                        case "MinYearComboBox":
                            MinYear = data;
                            break;

                        case "MaxYearComboBox":
                            MaxYear = data;
                            break;
                    }
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return (MinYear, MaxYear);
        }
    }
}
