using AnimalHabitat.Data.Models;
using System.Linq;

namespace AnimalHabitat.Data.Repositories.Contracts
{
    public interface ISpeciesDistributionRepository : IGenericRepository<SpeciesDistribution>
    {
        SpeciesDistribution GetSpeciesDistributionById(int id);

        IQueryable<SpeciesDistribution> GetSpeciesDistributions();
    }
}
