using System.Linq;
using Ecology.Data.Models;
using Ecology.Data.UnitOfWork;
using Ecology.ServiceContracts;

namespace Ecology.Services
{
    public class SpeciesService : ISpeciesService
    {
        private readonly IUnitOfWork unitOfWork;

        public SpeciesService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<Species> GetSpecies()
        {
            IQueryable<Species> speciesList = this.unitOfWork.SpeciesRepository.All();

            return speciesList;
        }

        public Species GetSpeciesById(int id)
        {
            Species species = this.unitOfWork.SpeciesRepository.GetById(id);

            return species;
        }
    }
}
