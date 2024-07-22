using LBPRDC.Source.Config;
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
                    .Include(i => i.Client)
                    .Where(w => w.Client.PayFrequencyID == PayFrequencyService.CurrentPayFrequencyID)
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
                    .Include(i => i.Client)
                    .Where(w => w.Client.PayFrequencyID == PayFrequencyService.CurrentPayFrequencyID)
                    .Where(w => w.Status.Equals(StringConstants.Status.ACTIVE) && w.ClientID.Equals(ClientID))
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
                    await LoggingService.AddLog(new()
                    {
                        UserID = UserService.CurrentUser.ID,
                        Type = MessagesConstants.Operation.ADD,
                        Details = $"Added Classification: {entity.ID} - {entity.Name}"
                    });
                }

                return (result > 0);
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }

        public static async Task<bool> Update(Models.Classification updatedEntity)
        {
            try
            {
                using var context = new Context();

                var entity = await context.Classifications.FindAsync(updatedEntity.ID);

                if (entity == null) { return false; }

                entity.Name = updatedEntity.Name;
                entity.Status = updatedEntity.Status;
                entity.Description = updatedEntity.Description;

                context.Entry(entity).State = EntityState.Modified;

                int result = await context.SaveChangesAsync();

                await LoggingService.AddLog(new()
                {
                    UserID = UserService.CurrentUser.ID,
                    Type = MessagesConstants.Operation.UPDATE,
                    Details = $"Updated Classification: {entity.ID} - {entity.Name}"
                });

                return true;
            }
            catch (Exception ex) { return ExceptionHandler.HandleException(ex); }
        }
    }
}
