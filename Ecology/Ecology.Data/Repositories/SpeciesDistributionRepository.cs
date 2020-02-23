using Ecology.Data.Contexts;
using Ecology.Data.Models;
using Ecology.Data.Repositories.Contracts;

namespace Ecology.Data.Repositories
{
    public class SpeciesDistributionRepository : GenericRepository<SpeciesDistribution>, ISpeciesDistributionRepository
    {
        private readonly EcologyContext context;

        public SpeciesDistributionRepository(EcologyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
