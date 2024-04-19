using Dapper;
using LBPRDC.Source.Data;
using Microsoft.EntityFrameworkCore;
using static LBPRDC.Source.Data.Database;

namespace LBPRDC.Source.Services
{
    internal class PreviousEmployeeService
    {
        public class PreviousEmployee
        {
            public int ID { get; set; }
            public bool HasRecord { get; set; }
            public int EmployeeID { get; set; }
            public string? Position { get; set; }
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public string? Information { get; set; }
        }

        // Entity Framework

        public static async Task<Models.Employee.History> GetEmployeeHistory(int EmployeeID)
        {
            Models.Employee.History record = new();

            try
            {
                using var context = new Context();
                var output = await context.EmployeePreviousRecord
                    .Where(h => h.EmployeeID == EmployeeID)
                    .Select(h => new Models.Employee.History 
                    {
                        ID = h.ID,
                        EmployeeID = h.EmployeeID,
                        Position = h.Position,
                        StartDate = h.StartDate,
                        EndDate = h.EndDate,
                        Information = h.Information,
                    })
                    .FirstOrDefaultAsync();

                if (output != null)
                {
                    output.HasRecord = true;
                    record = output;
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return record;
        }

        public static async void AddRecord(PreviousEmployee data)
        {
            try
            {
                using var connection = Database.Connect();

                string QueryInsert = @"
                    INSERT INTO EmployeePreviousRecord (
                        EmployeeID, 
                        Position, 
                        StartDate, 
                        EndDate, 
                        Information
                    ) VALUES (
                        @EmployeeID, 
                        @Position, 
                        @StartDate, 
                        @EndDate, 
                        @Information
                    )";

                await connection.ExecuteAsync(QueryInsert, data);
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }

        public static PreviousEmployee GetRecordByEmployeeID(int EmployeeID)
        {
            PreviousEmployee record = new();

            try
            {
                using var connection = Database.Connect();

                string QuerySelect = @"
                    SELECT
                        *
                    FROM
                        EmployeePreviousRecord
                    WHERE
                        EmployeeID = @EmployeeID";

                var output = connection.QueryFirstOrDefault<PreviousEmployee>(QuerySelect, new
                {
                    EmployeeID
                });

                if (output != null)
                {
                    output.HasRecord = true;
                    record = output;
                }
                else
                {
                    record = new()
                    {
                        HasRecord = false
                    };
                }
            }
            catch (Exception ex) { ExceptionHandler.HandleException (ex); }

            return record;
        }

        public static bool RecordExists(int EmployeeID)
        {
            try
            {
                using var connection = Database.Connect();

                string QueryCount = @"
                    SELECT 
                        COUNT(*) 
                    FROM 
                        EmployeePreviousRecord 
                    WHERE 
                        EmployeeID = @EmployeeID";

                int totalCount = connection.ExecuteScalar<int>(QueryCount, new
                {
                    EmployeeID
                });

                return totalCount > 0;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async void UpdateRecord(PreviousEmployee data)
        {
            try
            {
                using var connection = Database.Connect();
                
                string QueryUpdate = @"
                    UPDATE EmployeePreviousRecord SET 
                        Position = @Position,
                        StartDate = @StartDate,
                        EndDate = @EndDate,
                        Information = @Information 
                    WHERE 
                        ID = @ID";

                await connection.ExecuteAsync(QueryUpdate, data);
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }

        public static async void DeleteRecord(int EmployeeID)
        {
            try
            {
                using var connection = Database.Connect();

                string QueryDelete = @"
                    DELETE 
                    FROM 
                        EmployeePreviousRecord 
                    WHERE 
                        EmployeeID = @EmployeeID";

                await connection.ExecuteAsync(QueryDelete, new
                {
                    EmployeeID
                });
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }
        }
    }
}
