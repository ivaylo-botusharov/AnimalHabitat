using System;
using System.Diagnostics;
using Ecology.Data.Contexts;
using Ecology.Data.Seed;
using Ecology.DTO.Exceptions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecology.API
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
                    var ecologyContext = services.GetRequiredService<EcologyContext>();
                    var masterContext = services.GetRequiredService<MasterContext>();

                    DatabaseInitializer.SeedData(ecologyContext, masterContext);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    throw new DatabaseSeedFailedException(ex.Message);
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
