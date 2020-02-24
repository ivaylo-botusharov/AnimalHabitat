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

        private IEcoregionRepository ecoregionRepository;

        private ICountryRepository countryRepository;

        private ISpeciesRepository speciesRepository;

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

        public IEcoregionRepository EcoregionRepository
        {
            get
            {
                if (this.ecoregionRepository == null)
                {
                    this.ecoregionRepository = new EcoregionRepository(this.Context);
                }

                return this.ecoregionRepository;
            }
        }

        public ICountryRepository CountryRepository
        {
            get
            {
                if (this.countryRepository == null)
                {
                    this.countryRepository = new CountryRepository(this.Context);
                }

                return this.countryRepository;
            }
        }

        public ISpeciesRepository SpeciesRepository
        {
            get
            {
                if (this.speciesRepository == null)
                {
                    this.speciesRepository = new SpeciesRepository(this.Context);
                }

                return this.speciesRepository;
            }
        }

        public void SaveChanges()
        {
            this.Context.SaveChanges();
        }
    }
}
