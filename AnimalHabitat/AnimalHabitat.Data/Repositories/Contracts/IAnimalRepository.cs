using AnimalHabitat.Data.Models;
using System.Linq;

namespace AnimalHabitat.Data.Repositories.Contracts
{
    public interface IAnimalRepository : IGenericRepository<Animal>
    {
        Animal GetAnimalById(int id);

        IQueryable<Animal> GetAnimals();
    }
}
