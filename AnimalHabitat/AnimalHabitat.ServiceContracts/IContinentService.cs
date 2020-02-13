using System.Linq;
using AnimalHabitat.Data.Models;

namespace AnimalHabitat.ServiceContracts
{
    public interface IContinentService
    {
        Continent GetContinentById(int id);

        IQueryable<Continent> GetContinents();
    }
}
