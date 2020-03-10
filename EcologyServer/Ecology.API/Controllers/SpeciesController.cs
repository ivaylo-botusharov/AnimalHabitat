using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecology.API.Models;
using Ecology.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecology.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeciesController : ControllerBase
    {
        private readonly ISpeciesService speciesService;
        private readonly IMapper mapper;

        public SpeciesController(ISpeciesService speciesService, IMapper mapper)
        {
            this.speciesService = speciesService;
            this.mapper = mapper;
        }

        // GET: api/species
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<SpeciesViewModel> speciesList = this.mapper.ProjectTo<SpeciesViewModel>(this.speciesService.GetSpecies());
            return this.Ok(speciesList);
        }

        // GET: api/species/2
        [HttpGet("{speciesId}", Name = "GetById")]
        public IActionResult GetById(int speciesId)
        {
            SpeciesViewModel species = this.mapper.Map<SpeciesViewModel>(this.speciesService.GetSpeciesById(speciesId));

            return this.Ok(species);
        }
    }
}