using System.Linq;
using AnimalHabitat.Data.Models;
using AnimalHabitat.Data.UnitOfWork;
using AnimalHabitat.ServiceContracts;

namespace AnimalHabitat.Services
{
    public class ContinentService : IContinentService
    {
        private readonly IUnitOfWork unitOfWork;

        public ContinentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Continent GetContinentById(int id)
        {
            Continent continent = this.unitOfWork.ContinentRepository
                .All()
                .FirstOrDefault(c => c.Id == id);

            return continent;
        }

        public IQueryable<Continent> GetContinents()
        {
            IQueryable<Continent> continents = this.unitOfWork.ContinentRepository.All();

            return continents;
        }
    }
}
