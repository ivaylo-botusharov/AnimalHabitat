using Ecology.Data.Models;
using System.Linq;

namespace Ecology.Data.Repositories.Contracts
{
    public interface IEcoregionRepository : IGenericRepository<Ecoregion>
    {
        IQueryable<Ecoregion> GetEcoregionsByRealmIdBiomeId(int realmId, int biomeId);
    }
}
