using System.Linq;
using Ecology.Data.Models;

namespace Ecology.ServiceContracts
{
    public interface ISpeciesService
    {
        Species GetSpeciesById(int id);

        IQueryable<Species> GetSpecies();
    }
}
