using System.Linq;
using Ecology.Data.Models;

namespace Ecology.ServiceContracts
{
    public interface IBiomeService
    {
        IQueryable<Biome> GetBiomes();

        IQueryable<Biome> GetBiomesByRealmId(int realmId);
    }
}
