using AutoMapper;
using TechnicalTest.Models;
using TechnicalTest.WebServices.DTO;

namespace TechnicalTest.WebServices.AutoMapper.RaceMapper
{
    public class RaceMapperProfile : Profile
    {
        public RaceMapperProfile()
        {
            CreateMap<RaceDTO, Race>()
                .ForMember(target => target.Description, opt => opt.MapFrom(src => src.Name))
                .ForMember(target => target.State, opt => opt.MapFrom(src => src.State));

            CreateMap<RaceUpdateDTO, Race>()
                .ForMember(target => target.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(target => target.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(target => target.State, opt => opt.MapFrom(src => src.State));
        }
    }
}
