using System.Linq;
using AnimalHabitat.Data.Models;
using AnimalHabitat.ServiceContracts;
using AutoMapper;
using Ecology.API.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace Ecology.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpeciesDistributionController : ControllerBase
    {
        private readonly ISpeciesDistributionService speciesDistributionService;
        private readonly IMapper mapper;

        public SpeciesDistributionController(ISpeciesDistributionService speciesDistributionService, IMapper mapper)
        {
            this.speciesDistributionService = speciesDistributionService;
            this.mapper = mapper;
        }

        [HttpGet]
        [EnableQuery]
        public IQueryable<SpeciesDistributionViewModel> Get()
        {
            IQueryable<SpeciesDistributionViewModel> speciesDistributions = this.mapper
                .ProjectTo<SpeciesDistributionViewModel>(this.speciesDistributionService.GetSpeciesDistributions());

            return speciesDistributions;
        }

        [HttpPost]
        public IActionResult Post(SpeciesDistributionPostModel speciesDistributionPostModel)
        {
            SpeciesDistribution speciesDistribution = this.mapper.Map<SpeciesDistribution>(speciesDistributionPostModel);
            this.speciesDistributionService.AddSpeciesDistribution(speciesDistribution);
            return this.Ok(speciesDistribution.Id);
        }
    }
}
