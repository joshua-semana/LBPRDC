using LBPRDC.Source.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using static LBPRDC.Source.Data.Database;

namespace LBPRDC
{
    internal static class Program
    {
        //public static Context DbContext { get; private set; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //var serviceProvider = new ServiceCollection()
            //    .AddDbContext<Context>(options =>
            //        options.UseSqlServer(DataAccessHelper.GetConnectionString()))
            //    .BuildServiceProvider();

            //// Resolve the DbContext from the service provider
            //DbContext = serviceProvider.GetRequiredService<Context>();

            Application.Run(new Source.Views.frmLogin());
        }
    }
}