using System.Linq;
using Ecology.Data.Models;
using Ecology.Data.UnitOfWork;
using Ecology.ServiceContracts;

namespace Ecology.Services
{
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork unitOfWork;

        public CountryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Country GetCountryById(int id)
        {
            Country country = this.unitOfWork.CountryRepository.GetById(id);

            return country;
        }

        public IQueryable<Country> GetCountries()
        {
            IQueryable<Country> countries = this.unitOfWork.CountryRepository.All();

            return countries;
        }

        public IQueryable<Country> GetCountriesByEcoregionId(int ecoregionId)
        {
            IQueryable<Country> filteredCountries = this.unitOfWork.CountryRepository
                .GetCountriesByEcoregionId(ecoregionId);

            return filteredCountries;
        }
    }
}
