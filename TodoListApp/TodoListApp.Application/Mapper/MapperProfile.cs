using AutoMapper;
using System;
using TodoListApp.Application.Tasks.DTO;
using TodoListApp.Application.Tasks.ViewModels;
using TodoListApp.Application.Users.ViewModels;
using TodoListApp.Core.Domain;

namespace TodoListApp.Application.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, ProfileViewModel>().ReverseMap();

            CreateMap<SingleTask, TaskDto>()
                .ForMember(dest => dest.PredictedBestBeforeDateExceeded,
                           act => act.MapFrom(src => src.PredictedFinishDate < DateTime.Now))
                .ReverseMap();

            CreateMap<TaskDetails, TaskDetailsDto>().ReverseMap();

            CreateMap<SingleTask, TaskInfoWithDetailsViewModel>();
        }
    }
}
