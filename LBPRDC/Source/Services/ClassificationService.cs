using Dapper;
using LBPRDC.Source.Config;
using LBPRDC.Source.Data;
using Microsoft.EntityFrameworkCore;
using static LBPRDC.Source.Data.Database;

namespace LBPRDC.Source.Services
{
    internal class ClassificationService
    {
        public static async Task<List<Models.Classification.TableView>> GetClassificationsForTableView()
        {
            List<Models.Classification.TableView> classifications = new();

            try
            {
                using var context = new Context();
                classifications = await context.Classifications
                    .Select(s => new Models.Classification.TableView
                    {
                        ID = s.ID,
                        ClientID = s.ClientID,
                        Name = s.Name,
                        Status = s.Status,
                        Description = s.Description,
                        ClientName = s.Client.Name
                    })
                    .ToListAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return classifications;
        }

        public static async Task<List<Models.Classification>> GetClassificationsByClientID(int ClientID)
        {
            List<Models.Classification> classifications = new();

            try
            {
                using var context = new Context();
                classifications = await context.Classifications
                    .Where(w => w.ClientID == ClientID)
                    .ToListAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return classifications;
        }

        public static async Task<List<Models.Classification>> GetAllItemsForComboBoxByClientID(int ClientID = 0, bool withDefault = true)
        {
            List<Models.Classification> items = new();

            try
            {
                if (withDefault)
                {
                    items.Add(new Models.Classification
                    {
                        ID = 0,
                        Name = StringConstants.ComboBox.DEFAULT_CLASSIFICATION
                    });
                }

                using var context = new Context();

                var result = await context.Classifications
                    .Where(w =>
                        w.Status.Equals(StringConstants.Status.ACTIVE) &&
                        w.ClientID.Equals(ClientID))
                    .Select(s => new Models.Classification
                    {
                        ID = s.ID,
                        Name = s.Name
                    })
                    .ToListAsync();

                items.AddRange(result);
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }

        public static async Task<bool> AddClassification(Models.Classification entity)
        {
            try
            {
                using var context = new Context();
                context.Classifications.Add(entity);
                int result = await context.SaveChangesAsync();

                if (result > 0)
                {
                    await LoggingService.LogActivity(new()
                    {
                        UserID = UserService.CurrentUser.UserID,
                        ActivityType = "Add",
                        ActivityDetails = $"Added Classification: {entity.ID} - {entity.Name}"
                    });
                }

                return (result > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> UpdateClassification(Models.Classification updatedEntity)
        {
            try
            {
                using var context = new Context();

                var entity = await context.Classifications.FindAsync(updatedEntity.ID);

                if (entity == null) { return false; }
                if (AreEqual(entity, updatedEntity)) { return true; }

                entity.Name = updatedEntity.Name;
                entity.Status = updatedEntity.Status;
                entity.Description = updatedEntity.Description;

                context.Entry(entity).State = EntityState.Modified;

                int result = await context.SaveChangesAsync();

                if (result > 0)
                {
                    await LoggingService.LogActivity(new()
                    {
                        UserID = UserService.CurrentUser.UserID,
                        ActivityType = "Update",
                        ActivityDetails = $"Updated Classification: {entity.ID} - {entity.Name}"
                    });
                }

                return (result > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        private static bool AreEqual(Models.Classification entity1, Models.Classification entity2)
        {
            return entity1.Name == entity2.Name &&
                   entity1.Status == entity2.Status &&
                   entity1.Description == entity2.Description;
        }

        public static List<string> GetExistenceByID(int ID)
        {
            List<string> databaseTableNames = new();

            try
            {
                using var connection = Database.Connect();

                string QueryCheckExistense = "";
                List<string> tableNames = new()
                {
                    "Employee"
                };

                List<string> selectQueries = tableNames.Select(name =>
                    $"SELECT DISTINCT '{name}' AS TableName FROM {name} WHERE ClassificationID = @ClassificationID"
                ).ToList();

                QueryCheckExistense = string.Join(" UNION ALL ", selectQueries);

                databaseTableNames = connection.Query<string>(QueryCheckExistense, new
                {
                    ID
                }).ToList();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return databaseTableNames;
        }
    }
}
