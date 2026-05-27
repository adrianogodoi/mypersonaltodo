using AutoMapper;
using MyPersonalToDo.Domain.Dtos;
using MyPersonalToDo.Domain.Enums;
using MyPersonalToDo.Domain.Models;
using MyPersonalToDo.Domain.ViewModels;
using MyPersonalToDo.Domain.Extensions;

namespace MyPersonalToDo.Api.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {

            CreateMap<ToDoViewModelAdd, ToDo>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => StatusEnum.Pendente))
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<ToDoViewModelUpdate, ToDo>()
                 .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.StatusId))
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<ToDo, ToDoDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.GetDescription()))
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => (int)src.Status));
        }
    }
}

