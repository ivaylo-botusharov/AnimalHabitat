using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AnimalHabitat.Data.Contexts;
using AnimalHabitat.Data.Seed;
using AnimalHabitat.DTO;

namespace AnimalHabitat.Data
{
    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("Configuration/appdata.json", optional: true, reloadOnChange: true)
                .AddCommandLine(args)
                .Build();

            var services = new ServiceCollection();

            AppData appData = config.GetSection("AppData").Get<AppData>();

            services.AddDbContext<MasterContext>(options => options.UseSqlServer(appData.MasterDbConnectionString));

            services.AddDbContext<EcologyContext>(options =>
                options.UseSqlServer(appData.AnimalHabitatDbConnectionString));

            var serviceProvider = services.BuildServiceProvider();

            try
            {
                var northwindContext = serviceProvider.GetService<EcologyContext>();
                var masterContext = serviceProvider.GetService<MasterContext>();

                DatabaseInitializer.SeedData(northwindContext, masterContext);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            Environment.Exit(0);
        }
    }
}
