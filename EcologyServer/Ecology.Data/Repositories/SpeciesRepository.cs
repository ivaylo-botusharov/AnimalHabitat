using Ecology.Data.Contexts;
using Ecology.Data.Models;
using Ecology.Data.Repositories.Contracts;

namespace Ecology.Data.Repositories
{
    public class SpeciesRepository : GenericRepository<Species>, ISpeciesRepository
    {
        private readonly EcologyContext context;

        public SpeciesRepository(EcologyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
