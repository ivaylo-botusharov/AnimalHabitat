using Ecology.Data.Contexts;
using Ecology.Data.Seed;
using Ecology.ServiceContracts;

namespace Ecology.Services
{
    public class DatabaseConfigurationService : IDatabaseConfigurationService
    {
        public void SeedData(EcologyContext context, MasterContext masterContext)
        {
            DatabaseInitializer.SeedData(context, masterContext);
        }
    }
}
