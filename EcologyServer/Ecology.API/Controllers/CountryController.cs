using System.Linq;
using AutoMapper;
using Ecology.API.Models;
using Ecology.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Ecology.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService countryService;
        private readonly IMapper mapper;

        public CountryController(ICountryService countryService, IMapper mapper)
        {
            this.countryService = countryService;
            this.mapper = mapper;
        }

        // GET: api/country
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<CountryViewModel> countries = this.mapper
                .ProjectTo<CountryViewModel>(this.countryService.GetCountries());

            return this.Ok(countries);
        }

        // GET: api/country/ecoregion/1
        [HttpGet("Ecoregion/{ecoregionId}", Name = "GetByEcoregionId")]
        public IActionResult GetByEcoregionId(int ecoregionId)
        {
            IQueryable<CountryViewModel> filteredCountries = this.mapper.ProjectTo<CountryViewModel>(
                this.countryService.GetCountriesByEcoregionId(ecoregionId));

            return this.Ok(filteredCountries);
        }
    }
}