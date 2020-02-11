using System.Linq;
using AnimalHabitat.Data.Models;
using AnimalHabitat.Data.UnitOfWork;
using AnimalHabitat.ServiceContracts;
using AnimalHabitat.ViewModels.Animals;

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

        public IQueryable<AnimalViewModel> GetAnimals()
        {
            IQueryable<AnimalViewModel> animals = this.unitOfWork.AnimalRepository
                .All()
                .Select(a => new AnimalViewModel()
                {
                    Id = a.Id,
                    Species = a.Species,
                    ContinentalHabitat = a.Continent.Name,
                    Count = a.Count
                });

            return animals;
        }
    }
}
