using AutoMapper;
using Tour.Heroes.Api.Models.Entities;
using Tour.Heroes.Api.Models.ViewModels;

namespace Tour.Heroes.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<SourceType, DestType>().
            CreateMap<MetaHuman, MetaHumanViewModel>();
            CreateMap<Team, TeamViewModel>();
            CreateMap<Ability, AbilityViewModel>();

        }
    }
}
