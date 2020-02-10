using System;
using System.Collections.Generic;
using AnimalHabitat.API.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace AnimalHabitat.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalsController : ControllerBase
    {
        [HttpGet]
        [EnableQuery()]
        public IEnumerable<Animal> Get()
        {
            var animals = new List<Animal>()
            {
                CreateNewAnimal("Gabon", "Africa", 900),
                CreateNewAnimal("Deer", "North America", 1200)
            };

            return animals;
        }

        private static Animal CreateNewAnimal(string species, string continentalHabitat, int count)
        {
            return new Animal
            {
                Id = Guid.NewGuid(),
                Species = species,
                ContinentalHabitat = continentalHabitat,
                Count = count
            };
        }
    }
}
