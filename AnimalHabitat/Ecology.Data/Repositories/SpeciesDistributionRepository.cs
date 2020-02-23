using Ecology.Data.Contexts;
using Ecology.Data.Models;
using Ecology.Data.Repositories.Contracts;
using System.Linq;

namespace Ecology.Data.Repositories
{
    public class SpeciesDistributionRepository : GenericRepository<SpeciesDistribution>, ISpeciesDistributionRepository
    {
        private readonly EcologyContext context;

        public SpeciesDistributionRepository(EcologyContext context) : base(context)
        {
            this.context = context;
        }

        public SpeciesDistribution GetSpeciesDistributionById(int id)
        {
            SpeciesDistribution speciesDistribution = this.All().FirstOrDefault(sd => sd.Id == id);

            return speciesDistribution;
        }

        public IQueryable<SpeciesDistribution> GetSpeciesDistributions()
        {
            IQueryable<SpeciesDistribution> speciesDistributions = this.All();

            return speciesDistributions;
        }
    }
}
