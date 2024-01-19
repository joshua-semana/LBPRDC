using System;
using System.Data.SqlClient;
using System.Windows.Forms; // Make sure to include this for MessageBox

namespace LBPRDC.Source.Data
{
    internal class Database
    {
        public static SqlConnection? Connect()
        {
            SqlConnection connection = new SqlConnection(DataAccessHelper.GetConnectionString());

            try
            {
                connection.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Connection failed. Error code: {ex.ErrorCode}\nMessage: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return connection;
        }
    }
}
