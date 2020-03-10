using System.Linq;
using Ecology.Data.Models;

namespace Ecology.ServiceContracts
{
    public interface IEcoregionService
    {
        IQueryable<Ecoregion> GetEcoregions();

        IQueryable<Ecoregion> GetEcoregionsByRealmIdBiomeId(int realmId, int biomeId);

        IQueryable<Ecoregion> GetEcoregionsByCountryId(int countryId);
    }
}
