using System.Linq;
using AnimalHabitat.Data.Models;
using AnimalHabitat.Data.UnitOfWork;
using AnimalHabitat.ServiceContracts;

namespace AnimalHabitat.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IUnitOfWork unitOfWork;

        public AnimalService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Animal GetAnimalById(int id)
        {
            Animal animal = this.unitOfWork.AnimalRepository
                .All()
                .FirstOrDefault(a => a.Id == id);

            return animal;
        }

        public IQueryable<Animal> GetAnimals()
        {
            IQueryable<Animal> animals = this.unitOfWork.AnimalRepository.All();

            return animals;
        }
    }
}
