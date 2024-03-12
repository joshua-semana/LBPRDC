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

    public class ClientExistence
    {
        public string TableName { get; set; } = "";
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
                        Name = "(Choose Client)"
                    });
                }

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

        public static List<string> GetExistenceByID(int clientID)
        {
            List<string> clients = new();

            try
            {
                using var connection = Database.Connect();

                string QueryCheckExistense = "";
                List<string> tableNames = new()
                {
                    "Billing",
                    "BillingAccounts",
                    "BillingRecord",
                    "Position",
                    "Departments",
                    "Employee"
                };

                List<string> selectQueries = tableNames.Select(name =>
                    $"SELECT DISTINCT '{name}' AS TableName FROM {name} WHERE ClientID = @ClientID"
                ).ToList();

                QueryCheckExistense = string.Join(" UNION ALL ", selectQueries);

                clients = connection.Query<string>(QueryCheckExistense, new
                {
                    ClientID = clientID
                }).ToList();

            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return clients;
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
