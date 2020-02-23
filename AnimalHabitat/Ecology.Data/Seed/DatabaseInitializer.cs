using Ecology.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Data.SqlClient;
using System.IO;

namespace Ecology.Data.Seed
{
    public static class DatabaseInitializer
    {  
        public static void SeedData(EcologyContext ecologyContext, MasterContext masterContext)
        {
            bool databaseExists = (ecologyContext.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists();

            if (!databaseExists)
            {
                string filePath = Path.Combine(AppContext.BaseDirectory, "Seed", "Ecology.sql");
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
