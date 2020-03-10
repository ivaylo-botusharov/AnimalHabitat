using System.Linq;
using Ecology.Data.Models;

namespace Ecology.Data.Repositories.Contracts
{
    public interface IBiomeRepository : IGenericRepository<Biome>
    {
        IQueryable<Biome> GetBiomesByRealmId(int realmId);
    }
}
