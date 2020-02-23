using System.Linq;
using Ecology.Data.Contexts;
using Ecology.Data.Models;
using Ecology.Data.Repositories.Contracts;

namespace Ecology.Data.Repositories
{
    public class RealmRepository : GenericRepository<Realm>, IRealmRepository
    {
        private readonly EcologyContext context;

        public RealmRepository(EcologyContext context) : base(context)
        {
            this.context = context;
        }

        public Realm GetSpeciesDistributionById(int id)
        {
            Realm realm = this.All().FirstOrDefault(r => r.Id == id);

            return realm;
        }

        public IQueryable<Realm> GetRealms()
        {
            IQueryable<Realm> realms = this.All();

            return realms;
        }
    }
}
