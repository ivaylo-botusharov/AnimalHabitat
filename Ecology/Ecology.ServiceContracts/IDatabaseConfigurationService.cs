using Ecology.Data.Contexts;

namespace Ecology.ServiceContracts
{
    public interface IDatabaseConfigurationService
    {
        void SeedData(EcologyContext context, MasterContext masterContext);
    }
}
