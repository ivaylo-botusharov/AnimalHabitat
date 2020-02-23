using System.Linq;
using Ecology.Data.Models;

namespace Ecology.Data.Repositories.Contracts
{
    public interface IRealmRepository : IGenericRepository<Realm>
    {
        IQueryable<Realm> GetRealms();
    }
}
