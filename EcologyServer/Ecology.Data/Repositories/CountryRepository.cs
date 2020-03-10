using System.Linq;
using Ecology.Data.Contexts;
using Ecology.Data.Models;
using Ecology.Data.Repositories.Contracts;

namespace Ecology.Data.Repositories
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        private readonly EcologyContext context;

        public CountryRepository(EcologyContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable<Country> GetCountriesByEcoregionId(int ecoregionId)
        {
            IQueryable<Country> countries = this
                .All()
                .Where(c => c.EcoregionCountry.Any(ec => ec.EcoregionId == ecoregionId));

            return countries;
        }
    }
}
