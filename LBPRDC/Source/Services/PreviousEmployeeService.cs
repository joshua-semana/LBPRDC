using Microsoft.EntityFrameworkCore;
using static LBPRDC.Source.Data.Database;

namespace LBPRDC.Source.Services
{
    internal class PreviousEmployeeService
    {
        public static async Task<List<Models.Employee.History>> GetEmployeeFormerHistory(int ID)
        {
            List<Models.Employee.History> record = new();

            try
            {
                using var context = new Context();
                record = await context.EmployeePreviousRecord
                    .Where(h => h.EmployeeID == ID)
                    .ToListAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return record;
        }
    }
}
