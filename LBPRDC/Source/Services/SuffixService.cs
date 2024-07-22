using LBPRDC.Source.Config;
using Microsoft.EntityFrameworkCore;
using static LBPRDC.Source.Data.Database;

namespace LBPRDC.Source.Services
{
    internal class SuffixService
    {
        public static async Task<List<Models.Suffix>> GetAllItemsForComboBox(bool WithDefault = true)
        {
            List<Models.Suffix> items = new();

            try
            {
                if (WithDefault)
                {
                    items.Add(new Models.Suffix
                    {
                        ID = 0,
                        Name = StringConstants.ComboBox.DEFAULT_SUFFIX
                    });
                }

                using var context = new Context();

                var result = await context.Suffixes
                    .Where(w => w.Status.Equals(StringConstants.Status.ACTIVE))
                    .Select(s => new Models.Suffix
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
    }
}
