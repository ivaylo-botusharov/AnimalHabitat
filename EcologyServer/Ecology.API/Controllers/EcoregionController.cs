using System.Linq;
using AutoMapper;
using Ecology.API.Models;
using Ecology.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Ecology.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcoregionController : ControllerBase
    {
        private readonly IEcoregionService ecoregionService;
        private readonly IMapper mapper;

        public EcoregionController(IEcoregionService ecoregionService, IMapper mapper)
        {
            this.ecoregionService = ecoregionService;
            this.mapper = mapper;
        }

        // GET: api/ecoregion
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<EcoregionViewModel> ecoregions = this.mapper.ProjectTo<EcoregionViewModel>(this.ecoregionService.GetEcoregions());
            return this.Ok(ecoregions);
        }

        // GET: api/ecoregion/realm/1/biome/2
        [HttpGet("Realm/{realmId}/Biome/{biomeId}", Name = "GetByRealmIdBiomeId")]
        public IActionResult GetByRealmIdBiomeId(int realmId, int biomeId)
        {
            IQueryable<EcoregionViewModel> filteredEcoregions = this.mapper.ProjectTo<EcoregionViewModel>(
                this.ecoregionService.GetEcoregionsByRealmIdBiomeId(realmId, biomeId));

            return this.Ok(filteredEcoregions);
        }

        // GET: api/ecoregion/country/1
        [HttpGet("{countryId}", Name = "GetByCountryId")]
        public IActionResult GetByCountryId(int countryId)
        {
            IQueryable<EcoregionViewModel> filteredEcoregions = this.mapper.ProjectTo<EcoregionViewModel>(
                this.ecoregionService.GetEcoregionsByCountryId(countryId));

            return this.Ok(filteredEcoregions);
        }
    }
}