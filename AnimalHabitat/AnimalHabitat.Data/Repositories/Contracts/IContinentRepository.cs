using System.Linq;
using AnimalHabitat.Data.Models;

namespace AnimalHabitat.Data.Repositories.Contracts
{
    public interface IContinentRepository : IGenericRepository<Continent>
    {
        Continent GetContinentById(int id);

        IQueryable<Continent> GetContinents();
    }
}
