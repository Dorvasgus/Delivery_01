using AutoMapper;
using PRJ_Delivery.DTOs;
using PRJ_Delivery.Models;

namespace PRJ_Delivery.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // mapeo general para las personas
            
            CreateMap< Persona, PersonaDTO>();
            // mapeo general para las vehiculo

            CreateMap<Vehiculo, VehiculoDTO>();
        }
    }
}
