using System.Linq;
using Ecology.Data.Models;

namespace Ecology.ServiceContracts
{
    public interface ISpeciesDistributionService
    {
        SpeciesDistribution GetSpeciesDistributionById(int id);

        IQueryable<SpeciesDistribution> GetSpeciesDistributions();

        void AddSpeciesDistribution(SpeciesDistribution speciesDistribution);
    }
}
