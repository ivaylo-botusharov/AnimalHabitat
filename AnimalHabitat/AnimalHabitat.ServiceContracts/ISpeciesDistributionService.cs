using System.Linq;
using AnimalHabitat.Data.Models;

namespace AnimalHabitat.ServiceContracts
{
    public interface ISpeciesDistributionService
    {
        SpeciesDistribution GetSpeciesDistributionById(int id);

        IQueryable<SpeciesDistribution> GetSpeciesDistributions();

        void AddSpeciesDistribution(SpeciesDistribution speciesDistribution);
    }
}
