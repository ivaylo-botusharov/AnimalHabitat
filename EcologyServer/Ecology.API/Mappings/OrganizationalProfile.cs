using AutoMapper;
using Ecology.API.Models;
using Ecology.Data.Models;

namespace Ecology.API.Mappings
{
    public class OrganizationalProfile : Profile
    {
        public OrganizationalProfile()
        {
            this.CreateMap<SpeciesDistribution, SpeciesDistributionViewModel>()
                .ForMember(
                    dest =>
                    dest.SpeciesCommonName,
                    opt => opt.MapFrom(src => src.Species.CommonName))
                .ForMember(
                    dest =>
                    dest.SpeciesScientificName,
                    opt => opt.MapFrom(src => src.Species.ScientificName))
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

            this.CreateMap<Realm, RealmViewModel>();

            this.CreateMap<Biome, BiomeViewModel>();

            this.CreateMap<Ecoregion, EcoregionViewModel>();

            this.CreateMap<Country, CountryViewModel>();

            this.CreateMap<Species, SpeciesViewModel>()
                .ForMember(
                    dest =>
                    dest.Name,
                    opt => opt.MapFrom(src => src.CommonName));
        }
    }
}
