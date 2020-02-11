using System.Collections.Generic;
using System.Linq;
using AnimalHabitat.Data.Models;
using AnimalHabitat.ViewModels.Animals;

namespace AnimalHabitat.ServiceContracts
{
    public interface IAnimalService
    {
        Animal GetAnimalById(int id);

        IQueryable<AnimalViewModel> GetAnimals();
    }
}
