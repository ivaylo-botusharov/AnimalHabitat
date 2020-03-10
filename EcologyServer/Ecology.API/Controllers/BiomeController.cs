using System.Linq;
using AutoMapper;
using Ecology.API.Models;
using Ecology.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Ecology.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BiomeController : ControllerBase
    {
        private readonly IBiomeService biomeService;
        private readonly IMapper mapper;

        public BiomeController(IBiomeService biomeService, IMapper mapper)
        {
            this.biomeService = biomeService;
            this.mapper = mapper;
        }

        // GET: api/biome
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<BiomeViewModel> biomes = this.mapper.ProjectTo<BiomeViewModel>(this.biomeService.GetBiomes());
            return this.Ok(biomes);
        }

        // GET: api/biome/realm/5
        [HttpGet("Realm/{realmId}", Name = "GetByRealmId")]
        public IActionResult GetByRealmId(int realmId)
        {
            IQueryable<BiomeViewModel> biomes = this.mapper.ProjectTo<BiomeViewModel>(this.biomeService.GetBiomesByRealmId(realmId));

            return this.Ok(biomes);
        }
    }
}