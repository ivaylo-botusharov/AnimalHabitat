using System.Linq;
using Ecology.Data.Models;
using Ecology.Data.UnitOfWork;
using Ecology.ServiceContracts;

namespace Ecology.Services
{
    public class BiomeService : IBiomeService
    {
        private readonly IUnitOfWork unitOfWork;

        public BiomeService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<Biome> GetBiomes()
        {
            IQueryable<Biome> biomes = this.unitOfWork.BiomeRepository.All();

            return biomes;
        }

        public IQueryable<Biome> GetBiomesByRealmId(int realmId)
        {
            IQueryable<Biome> biomes = this.unitOfWork.BiomeRepository.GetBiomesByRealmId(realmId);

            return biomes;
        }
    }
}
