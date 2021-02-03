using AutoMapper;
using System;
using TodoListApp.Application.Tasks.DTO;
using TodoListApp.Application.Users.DTO;
using TodoListApp.Core.Domain;

namespace TodoListApp.Application.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, ProfileDto>().ReverseMap();

            CreateMap<SingleTask, MainPanelTasksDto>()
                .ForMember(dest => dest.PredictedBestBeforeDateExceeded,
                           act => act.MapFrom(src => src.PredictedFinishDate < DateTime.Now))
                .ReverseMap();
        }
    }
}
