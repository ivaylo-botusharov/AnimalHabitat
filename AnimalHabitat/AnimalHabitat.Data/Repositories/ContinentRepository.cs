using System.Linq;
using AnimalHabitat.Data.Contexts;
using AnimalHabitat.Data.Models;
using AnimalHabitat.Data.Repositories.Contracts;

namespace AnimalHabitat.Data.Repositories
{
    public class ContinentRepository : GenericRepository<Continent>, IContinentRepository
    {
        private readonly AnimalHabitatContext context;

        public ContinentRepository(AnimalHabitatContext context) : base(context)
        {
            this.context = context;
        }

        public Continent GetContinentById(int id)
        {
            Continent continent = this.All().FirstOrDefault(c => c.Id == id);

            return continent;
        }

        public IQueryable<Continent> GetContinents()
        {
            IQueryable<Continent> continents = this.All();

            return continents;
        }
    }
}
