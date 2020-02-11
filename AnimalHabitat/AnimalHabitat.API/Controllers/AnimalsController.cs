using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using AnimalHabitat.ServiceContracts;
using System.Linq;
using AutoMapper.QueryableExtensions;
using AnimalHabitat.API.Models;
using AutoMapper;

namespace AnimalHabitat.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalService animalService;
        private readonly IMapper mapper;

        public AnimalsController(IAnimalService animalService, IMapper mapper)
        {
            this.animalService = animalService;
            this.mapper = mapper;
        }

        [HttpGet]
        [EnableQuery()]
        public IQueryable<AnimalViewModel> Get()
        {
            IQueryable<AnimalViewModel> animals = mapper.ProjectTo<AnimalViewModel>(this.animalService.GetAnimals());
            return animals;
        }
    }
}
