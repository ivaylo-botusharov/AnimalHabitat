using System.Linq;
using Ecology.Data.Models;
using Ecology.Data.UnitOfWork;
using Ecology.ServiceContracts;

namespace Ecology.Services
{
    public class EcoregionService : IEcoregionService
    {
        private readonly IUnitOfWork unitOfWork;

        public EcoregionService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<Ecoregion> GetEcoregions()
        {
            IQueryable<Ecoregion> ecoregions = this.unitOfWork.EcoregionRepository.All();

            return ecoregions;
        }

        public IQueryable<Ecoregion> GetEcoregionsByRealmIdBiomeId(int realmId, int biomeId)
        {
            IQueryable<Ecoregion> filteredEcoregions = this.unitOfWork.EcoregionRepository
                .GetEcoregionsByRealmIdBiomeId(realmId, biomeId);

            return filteredEcoregions;
        }
    }
}
