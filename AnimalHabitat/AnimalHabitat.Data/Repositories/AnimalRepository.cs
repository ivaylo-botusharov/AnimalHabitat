using System.Linq;
using AnimalHabitat.Data.Contexts;
using AnimalHabitat.Data.Models;
using AnimalHabitat.Data.Repositories.Contracts;

namespace AnimalHabitat.Data.Repositories
{
    public class AnimalRepository : GenericRepository<Animal>, IAnimalRepository
    {
        private readonly AnimalHabitatContext context;

        public AnimalRepository(AnimalHabitatContext context) : base(context)
        {
            this.context = context;
        }

        public Animal GetAnimalById(int id)
        {
            Animal animal = this.All().FirstOrDefault(a => a.Id == id);

            return animal;
        }

        public IQueryable<Animal> GetAnimals()
        {
            IQueryable<Animal> animals = this.All();

            return animals;
        }
    }
}
