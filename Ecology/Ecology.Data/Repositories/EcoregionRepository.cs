using System.Linq;
using Ecology.Data.Contexts;
using Ecology.Data.Models;
using Ecology.Data.Repositories.Contracts;

namespace Ecology.Data.Repositories
{
    public class EcoregionRepository : GenericRepository<Ecoregion>, IEcoregionRepository
    {
        private readonly EcologyContext context;

        public EcoregionRepository(EcologyContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable<Ecoregion> GetEcoregionsByRealmIdBiomeId(int realmId, int biomeId)
        {
            IQueryable<Ecoregion> ecoregions = this.All().Where(e => e.RealmId == realmId && e.BiomeId == biomeId);

            return ecoregions;
        }

        public IQueryable<Ecoregion> GetEcoregionsByCountryId(int countryId)
        {
            IQueryable<Ecoregion> ecoregions = this
                .All()
                .Where(e => e.EcoregionCountry.Any(ec => ec.CountryId == countryId));

            return ecoregions;
        }
    }
}
