using AutoMapper;
using ProyectoTwin.Entidades;
using ProyectoTwin.DTOs;

namespace ProyectoTwin.Mappings
{
    public class ComponenteTwinProfile : Profile
    {
        public ComponenteTwinProfile()
        {
            CreateMap<ComponenteTwin, ComponenteTwinDto>().ReverseMap();
        }
    }
}
