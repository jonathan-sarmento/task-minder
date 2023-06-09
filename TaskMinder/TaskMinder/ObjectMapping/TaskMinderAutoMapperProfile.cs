using AutoMapper;
using TaskMinder.Entities;
using TaskMinder.Services.Dtos;

namespace TaskMinder.ObjectMapping;

public class TaskMinderAutoMapperProfile : Profile
{
    public TaskMinderAutoMapperProfile()
    {
        CreateMap<TodoItem, TodoItemDto>()
            .ForMember(dest => dest.CreatedDate,
                opt => opt.MapFrom(entity => TimeZoneInfo.ConvertTimeFromUtc(entity.CreatedDate, TimeZoneInfo.Local)));
    }
}
