using AnimalHabitat.Data.Contexts;

namespace AnimalHabitat.ServiceContracts
{
    public interface IDatabaseConfigurationService
    {
        void SeedData(AnimalHabitatContext context, MasterContext masterContext);
    }
}
