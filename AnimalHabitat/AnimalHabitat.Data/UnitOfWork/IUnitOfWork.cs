using AnimalHabitat.Data.Contexts;
using AnimalHabitat.Data.Repositories.Contracts;

namespace AnimalHabitat.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        AnimalHabitatContext Context { get; }

        IAnimalRepository AnimalRepository { get; }

        IContinentRepository ContinentRepository { get; }
    }
}
