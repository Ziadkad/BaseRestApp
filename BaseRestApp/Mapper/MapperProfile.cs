using AutoMapper;
using BaseRestApp.Dtos;
using BaseRestApp.Entities;

namespace BaseRestApp.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<TaskItem, TaskItemDto>().ReverseMap();
        CreateMap<TaskItem, TaskItemCreateDto>().ReverseMap();
    }
}