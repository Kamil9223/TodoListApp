using AutoMapper;
using System;
using TodoListApp.Application.Boards.DTO;
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

            CreateMap<SingleTask, TaskDto>()
                .ForMember(dest => dest.PredictedBestBeforeDateExceeded,
                           act => act.MapFrom(src => src.PredictedFinishDate < DateTime.Now))
                .ReverseMap();

            CreateMap<TaskDetails, TaskDetailsDto>().ReverseMap();

            CreateMap<SingleTask, TaskInfoWithDetailsDto>();
        }
    }
}
