using System.Linq;
using Ecology.Data.Models;
using Ecology.Data.UnitOfWork;
using Ecology.ServiceContracts;

namespace Ecology.Services
{
    public class RealmService : IRealmService
    {
        private readonly IUnitOfWork unitOfWork;

        public RealmService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<Realm> GetRealms()
        {
            IQueryable<Realm> realms = this.unitOfWork.RealmRepository.All();

            return realms;
        }
    }
}
