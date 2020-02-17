using AnimalHabitat.Data.Contexts;
using AnimalHabitat.Data.Repositories;
using AnimalHabitat.Data.Repositories.Contracts;

namespace AnimalHabitat.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ISpeciesDistributionRepository speciesDistributionRepository;

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

                return speciesDistributionRepository;
            }
        }

        public void SaveChanges()
        {
            this.Context.SaveChanges();
        }
    }
}
