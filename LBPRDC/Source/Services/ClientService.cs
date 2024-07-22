using LBPRDC.Source.Config;
using Microsoft.EntityFrameworkCore;
using static LBPRDC.Source.Data.Database;

namespace LBPRDC.Source.Services
{
    internal class ClientService
    {
        public static async Task<List<Models.Client>> GetItems(int? PayFrequencyID = null)
        {
            List<Models.Client> clients = new();

            try
            {
                using var context = new Context();
                var query = context.Clients.AsQueryable();

                if (PayFrequencyID != null)
                {
                    query = query.Where(w => w.PayFrequencyID == PayFrequencyService.CurrentPayFrequencyID);
                }
                
                clients = await query.ToListAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return clients;
        }

        public static async Task<Models.Client> GetClientByID(int ClientID)
        {
            Models.Client client = new();

            try
            {
                using var context = new Context();
                client = await context.Clients.FirstAsync(c => c.ID == ClientID);
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return client;
        }

        public static async Task<List<Models.Client.View>> GetItemsWithView()
        {
            List<Models.Client.View> clients = new();

            try
            {
                using var context = new Context();
                clients = await context.Clients
                    .Include(i => i.PayFrequency)
                    .Where(w => w.PayFrequencyID == PayFrequencyService.CurrentPayFrequencyID)
                    .Select(s => new Models.Client.View
                    {
                        ID = s.ID,
                        PayFrequencyID = s.PayFrequencyID,
                        Code = s.Code,
                        Name = s.Name,
                        Description = s.Description,
                        Status = s.Status,
                        PayFrequencyName = s.PayFrequency.Name,
                    })
                    .ToListAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return clients;
        }

        public static async Task<List<Models.Client>> GetAllItemsForComboBox(string? Status = null, bool WithDefault = true)
        {
            List<Models.Client> items = new();

            try
            {
                if (WithDefault)
                {
                    items.Add(new Models.Client
                    {
                        ID = 0,
                        Name = StringConstants.ComboBox.DEFAULT_CLIENT
                    });
                }

                using var context = new Context();
                var query = context.Clients
                    .Where(w => w.PayFrequencyID == PayFrequencyService.CurrentPayFrequencyID)
                    .AsQueryable();

                if (Status != null)
                {
                    query = query.Where(w => w.Status == Status);
                }

                var result = await query
                    .Select(d => new Models.Client
                    {
                        ID = d.ID,
                        Name = $"{d.Code} - {d.Name}",
                    })
                    .ToListAsync();

                items.AddRange(result);
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }

        public static async Task<bool> Add(Models.Client data)
        {
            try
            {
                using var context = new Context();
                context.Clients.Add(data);
                await context.SaveChangesAsync();

                await LoggingService.AddLog(new()
                {
                    UserID = UserService.CurrentUser.ID,
                    Type = MessagesConstants.Operation.ADD,
                    Details = $"Added new Client: {data.ID} - {data.Name}"
                });

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> Update(Models.Client data)
        {
            try
            {
                using var context = new Context();

                var item = await context.Clients.FindAsync(data.ID);

                if (item == null) { return false; }

                item.PayFrequencyID = data.PayFrequencyID;
                item.Code = data.Code;
                item.Name = data.Name;
                item.Description = data.Description;
                item.Status = data.Status;

                await context.SaveChangesAsync();

                await LoggingService.AddLog(new()
                {
                    UserID = UserService.CurrentUser.ID,
                    Type = MessagesConstants.Operation.UPDATE,
                    Details = $"Updated client's information with ID of: {data.ID}"
                });

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }
    }
}
