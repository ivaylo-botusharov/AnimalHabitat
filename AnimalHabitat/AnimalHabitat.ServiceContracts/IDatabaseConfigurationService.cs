using AnimalHabitat.Data.Contexts;

namespace AnimalHabitat.ServiceContracts
{
    public interface IDatabaseConfigurationService
    {
        void SeedData(EcologyContext context, MasterContext masterContext);
    }
}
