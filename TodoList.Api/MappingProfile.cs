using AutoMapper;
using TodoList.Api.Entities;
using TodoList.Models.Dtos;

namespace TodoList.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Entities.Task, TaskDto>()
                .ForMember(dest => dest.AssigneeName, act => act.MapFrom(src => src.Assignee.FirstName + ' ' + src.Assignee.LastName))
                .ReverseMap();
            CreateMap<Entities.Task, TaskDetailsDto>()
                .ForMember(dest => dest.AssigneeName,act => act.MapFrom(src => src.Assignee.FirstName + ' ' + src.Assignee.LastName))
                .ReverseMap();
            CreateMap<TaskUpdateDto, Entities.Task>()
                .ForMember(dest => dest.Id, act => act.Ignore())
                .ForMember(dest => dest.CreatedDate, act => act.Ignore());
            CreateMap<TaskCreateDto, Entities.Task>();

            CreateMap<TaskDetailsDto, TaskUpdateDto>();
                

            CreateMap<User, AssigneeDto>()
                .ForMember(dest => dest.FullName,act => act.MapFrom(src => src.FirstName + ' ' + src.LastName))
                .ReverseMap();
        }
    }
}
