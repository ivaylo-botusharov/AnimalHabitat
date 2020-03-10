using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Ecology.API.Models;
using Ecology.Data.Models;
using Ecology.ServiceContracts;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IList<SpeciesDistributionViewModel> Get()
        {
            IList<SpeciesDistributionViewModel> speciesDistributions = this.mapper
                .ProjectTo<SpeciesDistributionViewModel>(this.speciesDistributionService.GetSpeciesDistributions()).ToList();

            return speciesDistributions;
        }

        public IActionResult Patch([FromODataUri] int key, Delta<SpeciesDistribution> speciesDistributionDelta)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            SpeciesDistribution speciesDistribution = this.speciesDistributionService.GetSpeciesDistributionById(key);

            if (speciesDistribution == null)
            {
                return this.NotFound();
            }

            if (speciesDistributionDelta == null)
            {
                return this.NotFound();
            }

            speciesDistributionDelta.Patch(speciesDistribution);

            try
            {
                this.speciesDistributionService.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return this.NotFound();
            }

            return this.Ok(speciesDistribution);
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
