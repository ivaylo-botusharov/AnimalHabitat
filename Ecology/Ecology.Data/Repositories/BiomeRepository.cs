using Ecology.Data.Contexts;
using Ecology.Data.Models;
using Ecology.Data.Repositories.Contracts;
using System.Linq;

namespace Ecology.Data.Repositories
{
    public class BiomeRepository : GenericRepository<Biome>, IBiomeRepository
    {
        private readonly EcologyContext context;

        public BiomeRepository(EcologyContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable<Biome> GetBiomesByRealmId(int realmId)
        {
            IQueryable<Biome> biomes = this.All().Where(b => b.RealmBiome.Any(rm => rm.RealmId == realmId));

            return biomes;
        }
    }
}
