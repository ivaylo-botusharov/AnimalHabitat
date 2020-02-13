using System;
using System.Diagnostics;
using AnimalHabitat.Data.Contexts;
using AnimalHabitat.Data.Seed;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AnimalHabitat.API
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var animalHabitatContext = services.GetRequiredService<AnimalHabitatContext>();
                    var masterContext = services.GetRequiredService<MasterContext>();

                    DatabaseInitializer.SeedData(animalHabitatContext, masterContext);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    throw new Exception(ex.Message);
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.SetBasePath(AppContext.BaseDirectory);
                    config.AddJsonFile("Configuration/appdata.json", optional: false, reloadOnChange: false);
                    config.AddCommandLine(args);
                })
                .UseStartup<Startup>();
        }
    }
}
