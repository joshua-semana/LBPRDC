using LBPRDC.Source.Config;
using Microsoft.EntityFrameworkCore;
using static LBPRDC.Source.Data.Database;

namespace LBPRDC.Source.Services
{
    internal class PayFrequencyService
    {
        public static int CurrentPayFrequencyID { get; set; } = 0;

        public static void SetPayFrequencyID(int ID)
        {
            CurrentPayFrequencyID = ID;
        }

        public static void ClearPayFrequencyID()
        {
            CurrentPayFrequencyID = 0;
        }

        public static async Task<List<Models.PayFrequency>> GetAllItems()
        {
            List<Models.PayFrequency> payFrequencies = new();

            try
            {
                using var context = new Context();
                payFrequencies = await context.PayFrequencies.ToListAsync();
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return payFrequencies;
        }

        public static async Task<List<Models.PayFrequency>> GetAllItemsForComboBox(bool WithDefault = true)
        {
            List<Models.PayFrequency> items = new();

            try
            {
                if (WithDefault)
                {
                    items.Add(new Models.PayFrequency
                    {
                        ID = 0,
                        Name = StringConstants.ComboBox.DEFAULT_PAY_FREQUENCY,
                    });
                }

                using var context = new Context();

                var result = await context.PayFrequencies.AsQueryable()
                    .Select(d => new Models.PayFrequency
                    {
                        ID = d.ID,
                        Name = d.Name,
                    })
                    .ToListAsync();

                items.AddRange(result);
            }
            catch (Exception ex) { ExceptionHandler.HandleException(ex); }

            return items;
        }


    }
}
