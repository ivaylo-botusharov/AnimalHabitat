using Ecology.Data.Contexts;
using Ecology.Data.Repositories.Contracts;

namespace Ecology.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        EcologyContext Context { get; }

        ISpeciesDistributionRepository SpeciesDistributionRepository { get; }

        IRealmRepository RealmRepository { get; }

        IBiomeRepository BiomeRepository { get; }

        IEcoregionRepository EcoregionRepository { get; }

        ICountryRepository CountryRepository { get; }
    }
}

