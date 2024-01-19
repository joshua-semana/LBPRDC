﻿using System.Configuration;
using System.Data.SqlClient;

namespace LBPRDC.Source.Data
{
    internal class DataAccessHelper
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        public static SqlConnection DBConnect()
        {
            SqlConnection connection = new(Data.DataAccessHelper.GetConnectionString());
            connection.Open();
            return connection;
        }
    }
}
