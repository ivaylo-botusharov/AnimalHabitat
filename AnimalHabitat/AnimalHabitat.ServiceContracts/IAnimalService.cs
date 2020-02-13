using System.Linq;
using AnimalHabitat.Data.Models;

namespace AnimalHabitat.ServiceContracts
{
    public interface IAnimalService
    {
        Animal GetAnimalById(int id);

        IQueryable<Animal> GetAnimals();
    }
}
