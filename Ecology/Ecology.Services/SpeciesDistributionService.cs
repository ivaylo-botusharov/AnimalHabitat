using System.Linq;
using Ecology.Data.Models;
using Ecology.Data.UnitOfWork;
using Ecology.ServiceContracts;

namespace Ecology.Services
{
    public class SpeciesDistributionService : ISpeciesDistributionService
    {
        private readonly IUnitOfWork unitOfWork;

        public SpeciesDistributionService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<SpeciesDistribution> GetSpeciesDistributions()
        {
            IQueryable<SpeciesDistribution> speciesDistributions = this.unitOfWork.SpeciesDistributionRepository.All();

            return speciesDistributions;
        }

        public SpeciesDistribution GetSpeciesDistributionById(int id)
        {
            SpeciesDistribution speciesDistribution = this.unitOfWork.SpeciesDistributionRepository.GetById(id);

            return speciesDistribution;
        }

        public void AddSpeciesDistribution(SpeciesDistribution speciesDistribution)
        {
            this.unitOfWork.SpeciesDistributionRepository.Add(speciesDistribution);
            this.unitOfWork.SpeciesDistributionRepository.SaveChanges();
        }
    }
}
