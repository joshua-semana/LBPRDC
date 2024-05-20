using Dapper;
using LBPRDC.Source.Config;
using LBPRDC.Source.Data;
using Microsoft.EntityFrameworkCore;
using static LBPRDC.Source.Data.Database;

namespace LBPRDC.Source.Services
{
    public class Client
    {
        public int ID { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Status { get; set; } = StringConstants.Status.ACTIVE;
    }

    public class ClientExistence
    {
        public string TableName { get; set; } = "";
    }

    internal class ClientService
    {
        // Entity Framework

        public static async Task<Models.Client> GetClientByID(int ClientID)
        {
            Models.Client client = new();

            try
            {
                using var context = new Context();
                client = await context.Clients
                    .FirstAsync(c => c.ID == ClientID);
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return client;
        }



        public static List<Client> GetClients()
        {
            List<Client> clients = new();

            try
            {
                using var connection = Database.Connect();
                string QuerySelect = "SELECT * FROM Clients";
                clients = connection.Query<Client>(QuerySelect).ToList();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return clients;
        }

        public static async Task<Models.Client> GetDetailsByID(int ID)
        {
            Models.Client client = new();

            try
            {
                using var context = new Context();
                client = await context.Clients.FirstAsync(c => c.ID == ID);
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return client;
        }

        public static List<Client> GetClientsForComboBoxByStatus(string status, bool withDefault)
        {
            List<Client> items = new();

            try
            {
                if (withDefault)
                {
                    items.Add(new Client
                    {
                        ID = 0,
                        Name = "(Choose Client)",
                        Description = "(Choose Client)"
                    });
                }

                using var connection = Database.Connect();
                string QuerySelect = "SELECT ID, Name, Description FROM Clients WHERE Status = @Status";

                var result = connection.Query<Client>(QuerySelect, new
                {
                    Status = status
                }).ToList();

                items.AddRange(result);
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }

        public static async Task<bool> AddClient(Client client)
        {
            try
            {
                using var connection = Database.Connect();
                using var transaction = connection?.BeginTransaction();

                try
                {
                    string QueryInsert = @"
                        INSERT INTO Clients (
                            Name,
                            Description,
                            Status
                        ) VALUES (
                            @Name,
                            @Description,
                            @Status
                        )";

                    var affectedRows = await connection.ExecuteAsync(QueryInsert, client, transaction);
                    transaction?.Commit();

                    if (affectedRows > 0)
                    {
                        await LoggingService.LogActivity(new()
                        {
                            UserID = UserService.CurrentUser.UserID,
                            ActivityType = "New Client",
                            ActivityDetails = $"User added a new client"
                        });
                    }

                    return (affectedRows > 0);
                }
                catch (Exception)
                {
                    transaction?.Rollback();
                    return false;
                }
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
                if (AreEqual(item, data)) { return true; }

                item.Name = data.Name;
                item.Description = data.Description;
                item.Status = data.Status;

                await context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        private static bool AreEqual(Models.Client item1, Models.Client item2)
        {
            return item1.Name == item2.Name &&
                   item1.Description == item2.Description &&
                   item1.Status == item2.Status;
        }
    }
}
