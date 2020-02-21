using AnimalHabitat.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Ecology.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ISpeciesDistributionService speciesDistributionService;

        public HomeController(ISpeciesDistributionService speciesDistributionService)
        {
            this.speciesDistributionService = speciesDistributionService;
        }

        public IActionResult Get()
        {
            var speciesDistributions = this.speciesDistributionService.GetSpeciesDistributions();

            return this.Ok(speciesDistributions);
        }
    }
}