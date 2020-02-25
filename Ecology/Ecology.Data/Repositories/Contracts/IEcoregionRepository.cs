using System.Linq;
using Ecology.Data.Models;

namespace Ecology.Data.Repositories.Contracts
{
    public interface IEcoregionRepository : IGenericRepository<Ecoregion>
    {
        IQueryable<Ecoregion> GetEcoregionsByRealmIdBiomeId(int realmId, int biomeId);

        IQueryable<Ecoregion> GetEcoregionsByCountryId(int countryId);
    }
}
