using System.Collections.Generic;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using AnimalHabitat.Data.Models;
using AnimalHabitat.ServiceContracts;
using AnimalHabitat.ViewModels.Animals;
using System.Linq;

namespace AnimalHabitat.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalService animalService;

        public AnimalsController(IAnimalService animalService)
        {
            this.animalService = animalService;
        }

        [HttpGet]
        [EnableQuery()]
        public IQueryable<AnimalViewModel> Get()
        {
            IQueryable<AnimalViewModel> animals = this.animalService.GetAnimals();
            return animals;
        }
    }
}
