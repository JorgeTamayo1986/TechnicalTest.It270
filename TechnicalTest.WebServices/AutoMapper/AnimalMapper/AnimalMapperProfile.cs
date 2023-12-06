using AutoMapper;
using TechnicalTest.Models;
using TechnicalTest.WebServices.DTO;

namespace TechnicalTest.WebServices.AutoMapper.AnimalMapper
{
    public class AnimalMapperProfile : Profile
    {
        public AnimalMapperProfile()
        {
            CreateMap<AnimalDTO, Animal>()
                .ForMember(target => target.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(target => target.BirthDate, opt => opt.MapFrom(src => !string.IsNullOrWhiteSpace(src.BirthDate) ? Convert.ToDateTime(src.BirthDate) : new DateTime?()))
                .ForMember(target => target.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(target => target.Gender, opt => opt.MapFrom(src => src.Gender.Equals("H") ? "Hembra" : src.Gender.Equals("M") ? "Macho" : string.Empty))
                .ForMember(target => target.RaceId, opt => opt.MapFrom(src => src.RaceId))
                .ForMember(target => target.State, opt => opt.MapFrom(src => src.State));

            CreateMap<AnimalUpdateDTO, Animal>()
               .ForMember(target => target.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(target => target.BirthDate, opt => opt.MapFrom(src => !string.IsNullOrWhiteSpace(src.BirthDate) ? Convert.ToDateTime(src.BirthDate) : new DateTime?()))
               .ForMember(target => target.Price, opt => opt.MapFrom(src => src.Price))
               .ForMember(target => target.Gender, opt => opt.MapFrom(src => src.Gender.Equals("H") ? "Hembra" : src.Gender.Equals("M") ? "Macho" : string.Empty))
               .ForMember(target => target.RaceId, opt => opt.MapFrom(src => src.RaceId))
               .ForMember(target => target.State, opt => opt.MapFrom(src => src.State));
        }
    }
}
