using System.Linq;
using Ecology.Data.Models;

namespace Ecology.ServiceContracts
{
    public interface IRealmService
    {
        IQueryable<Realm> GetRealms();
    }
}
