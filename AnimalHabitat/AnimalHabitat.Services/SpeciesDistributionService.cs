using System.Linq;
using AnimalHabitat.Data.Models;
using AnimalHabitat.Data.UnitOfWork;
using AnimalHabitat.ServiceContracts;

namespace AnimalHabitat.Services
{
    public class SpeciesDistributionService : ISpeciesDistributionService
    {
        private readonly IUnitOfWork unitOfWork;

        public SpeciesDistributionService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public SpeciesDistribution GetSpeciesDistributionById(int id)
        {
            SpeciesDistribution animal = this.unitOfWork.SpeciesDistributionRepository
                .All()
                .FirstOrDefault(a => a.Id == id);

            return animal;
        }

        public IQueryable<SpeciesDistribution> GetSpeciesDistributions()
        {
            IQueryable<SpeciesDistribution> speciesDistributions = this.unitOfWork.SpeciesDistributionRepository.All();

            return speciesDistributions;
        }

        public void AddSpeciesDistribution(SpeciesDistribution speciesDistribution)
        {
            this.unitOfWork.SpeciesDistributionRepository.Add(speciesDistribution);
            this.unitOfWork.SpeciesDistributionRepository.SaveChanges();
        }
    }
}
