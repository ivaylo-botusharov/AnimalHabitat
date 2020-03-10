using System.Linq;
using Ecology.Data.Models;

namespace Ecology.Data.Repositories.Contracts
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        IQueryable<Country> GetCountriesByEcoregionId(int ecoregionId);
    }
}
