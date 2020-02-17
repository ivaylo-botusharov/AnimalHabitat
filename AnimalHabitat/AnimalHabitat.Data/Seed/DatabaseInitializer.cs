using System;
using System.Data.SqlClient;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using AnimalHabitat.Data.Contexts;

namespace AnimalHabitat.Data.Seed
{
    public static class DatabaseInitializer
    {  
        public static void SeedData(EcologyContext animalHabitatContext, MasterContext masterContext)
        {
            bool databaseExists = (animalHabitatContext.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists();

            if (!databaseExists)
            {
                string filePath = Path.Combine(AppContext.BaseDirectory, "Seed", "AnimalHabitat.sql");
                string seedSql = File.ReadAllText(filePath);

                string masterDbConnectionString = masterContext.Database.GetDbConnection().ConnectionString;

                // Overview (SMO): https://docs.microsoft.com/en-us/sql/relational-databases/server-management-objects-smo/overview-smo?view=sql-server-2017
                using (SqlConnection connection = new SqlConnection(masterDbConnectionString))
                {
                    Server server = new Server(new ServerConnection(connection));
                    //https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2014/ms199350%28v%3dsql.120%29
                    server.ConnectionContext.ExecuteNonQuery(seedSql);
                }
            }
        }
    }
}
