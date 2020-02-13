using System.Linq;
using AnimalHabitat.API.Models;
using AnimalHabitat.ServiceContracts;
using AutoMapper;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

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
        [EnableQuery]
        public IQueryable<AnimalViewModel> Get()
        {
            IQueryable<AnimalViewModel> animals = this.mapper
                .ProjectTo<AnimalViewModel>(this.animalService.GetAnimals());

            return animals;
        }
    }
}
