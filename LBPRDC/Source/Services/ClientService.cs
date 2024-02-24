using Dapper;
using LBPRDC.Source.Data;

namespace LBPRDC.Source.Services
{
    public class Client
    {
        public int ID { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Status { get; set; } = "Active";
    }

    internal class ClientService
    {
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

        public static Client GetClientDetailsByID(int id)
        {
            Client clientDetails = new();

            try
            {
                using var connection = Database.Connect();
                string QuerySelect = "SELECT * FROM Clients WHERE ID = @ID";
                clientDetails = connection.QueryFirstOrDefault<Client>(QuerySelect, new {
                    ID = id
                }) ?? new();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return clientDetails;
        }

        public static List<Client> GetClientsForComboBoxByStatus(string status)
        {
            List<Client> items = new();

            try
            {
                items.Add(new Client
                {
                    ID = 0,
                    Name = "(Choose Client)"
                });

                using var connection = Database.Connect();
                string QuerySelect = "SELECT ID, Name FROM Clients WHERE Status = @Status";

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
                    string QuerySelect = @"
                        INSERT INTO Clients (
                            Name,
                            Description,
                            Status
                        ) VALUES (
                            @Name,
                            @Description,
                            @Status
                        )";

                    var affectedRows = await connection.ExecuteAsync(QuerySelect, client, transaction);
                    transaction?.Commit();

                    if (affectedRows > 0)
                    {
                        LoggingService.LogActivity(new()
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

        public static bool Update(Client client)
        {
            try
            {
                using var connection = Database.Connect();

                string QueryUpdate = @"
                    UPDATE Clients SET
                        Name = @Name,
                        Description = @Description,
                        Status = @Status
                    WHERE
                        ID = @ID";

                int affectedRows = connection.Execute(QueryUpdate, client);

                return (affectedRows > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }
    }
}
