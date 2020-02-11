using AnimalHabitat.Data.Contexts;
using AnimalHabitat.Data.Repositories;
using AnimalHabitat.Data.Repositories.Contracts;

namespace AnimalHabitat.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IAnimalRepository animalRepository;

        private IContinentRepository continentRepository;

        public UnitOfWork(AnimalHabitatContext context)
        {
            this.Context = context;
        }

        public AnimalHabitatContext Context { get; }

        public IAnimalRepository AnimalRepository
        {
            get
            {
                if (this.animalRepository == null)
                {
                    this.animalRepository = new AnimalRepository(this.Context);
                }

                return animalRepository;
            }
        }

        public IContinentRepository ContinentRepository
        {
            get
            {
                if (this.continentRepository == null)
                {
                    this.continentRepository = new ContinentRepository(this.Context);
                }

                return continentRepository;
            }
        }

        public void SaveChanges()
        {
            this.Context.SaveChanges();
        }
    }
}
