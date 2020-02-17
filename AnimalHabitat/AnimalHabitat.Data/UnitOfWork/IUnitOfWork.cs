using AnimalHabitat.Data.Contexts;
using AnimalHabitat.Data.Repositories.Contracts;

namespace AnimalHabitat.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        EcologyContext Context { get; }

        ISpeciesDistributionRepository SpeciesDistributionRepository { get; }
    }
}

