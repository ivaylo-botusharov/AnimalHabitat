using AnimalHabitat.Data.Contexts;
using AnimalHabitat.Data.Seed;
using AnimalHabitat.ServiceContracts;

namespace AnimalHabitat.Services
{
    public class DatabaseConfigurationService : IDatabaseConfigurationService
    {
        public void SeedData(EcologyContext context, MasterContext masterContext)
        {
            DatabaseInitializer.SeedData(context, masterContext);
        }
    }
}
