using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
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

            CreateMap<IEnumerable<SingleTask>, TasksCollectionDto>()
                .ForMember(dest => dest.Tasks,
                    act => act.MapFrom(src => src));
        }
    }
}
