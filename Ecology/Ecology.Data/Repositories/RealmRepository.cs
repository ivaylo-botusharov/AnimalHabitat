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
    }
}
