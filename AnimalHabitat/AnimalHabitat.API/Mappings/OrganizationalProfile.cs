using AnimalHabitat.API.Models;
using AnimalHabitat.Data.Models;
using AutoMapper;

namespace AnimalHabitat.API.Mappings
{
    public class OrganizationalProfile : Profile
    {
        public OrganizationalProfile()
        {
            this.CreateMap<SpeciesDistribution, SpeciesDistributionViewModel>()
                .ForMember(
                    dest =>
                    dest.Realm,
                    opt => opt.MapFrom(src => src.EcoregionCountry.Ecoregion.RealmBiome.Realm.Name))
                .ForMember(
                    dest =>
                    dest.Biome,
                    opt => opt.MapFrom(src => src.EcoregionCountry.Ecoregion.RealmBiome.Biome.Name))
                .ForMember(
                    dest =>
                    dest.Ecoregion,
                    opt => opt.MapFrom(src => src.EcoregionCountry.Ecoregion.Name))
                .ForMember(
                    dest =>
                    dest.Country,
                    opt => opt.MapFrom(src => src.EcoregionCountry.Country.Name));

            this.CreateMap<SpeciesDistributionPostModel, SpeciesDistribution>();
        }
    }
}
