using System.Linq;
using Ecology.Data.Models;

namespace Ecology.ServiceContracts
{
    public interface ICountryService
    {
        Country GetCountryById(int id);

        IQueryable<Country> GetCountries();

        IQueryable<Country> GetCountriesByEcoregionId(int ecoregionId);
    }
}
