using Ecology.Data.Contexts;
using Ecology.Data.Repositories;
using Ecology.Data.Repositories.Contracts;

namespace Ecology.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ISpeciesDistributionRepository speciesDistributionRepository;

        private IRealmRepository realmRepository;

        private IBiomeRepository biomeRepository;

        public UnitOfWork(EcologyContext context)
        {
            this.Context = context;
        }

        public EcologyContext Context { get; }

        public ISpeciesDistributionRepository SpeciesDistributionRepository
        {
            get
            {
                if (this.speciesDistributionRepository == null)
                {
                    this.speciesDistributionRepository = new SpeciesDistributionRepository(this.Context);
                }

                return this.speciesDistributionRepository;
            }
        }

        public IRealmRepository RealmRepository
        {
            get
            {
                if (this.realmRepository == null)
                {
                    this.realmRepository = new RealmRepository(this.Context);
                }

                return this.realmRepository;
            }
        }

        public IBiomeRepository BiomeRepository
        {
            get
            {
                if (this.biomeRepository == null)
                {
                    this.biomeRepository = new BiomeRepository(this.Context);
                }

                return this.biomeRepository;
            }
        }

        public void SaveChanges()
        {
            this.Context.SaveChanges();
        }
    }
}
