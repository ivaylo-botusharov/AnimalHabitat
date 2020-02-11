using AnimalHabitat.API.Models;
using AnimalHabitat.Data.Models;
using AutoMapper;

namespace AnimalHabitat.API.Mappings
{
    public class OrganizationalProfile : Profile
    {
        public OrganizationalProfile()
        {
            CreateMap<Animal, AnimalViewModel>()
                .ForMember(dest =>
                    dest.ContinentalHabitat,
                    opt => opt.MapFrom(src => src.Continent.Name));
        }
    }
}
