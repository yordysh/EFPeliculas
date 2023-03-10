using AutoMapper;
using Entitys;
using WebApi.Controllers.DTOs;

namespace WebApi.Servicios
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Actor, ActorDTO>();
            CreateMap<Cine, CineDTO>()
                .ForMember(dto => dto.Latitud, ent => ent.MapFrom(prop => prop.Ubicacion.Y))
                .ForMember(dto => dto.Longitud, ent => ent.MapFrom(prop => prop.Ubicacion.X));

            CreateMap<Genero, GeneroDTO>();

            //Sin ProjectTo
            CreateMap<Pelicula, PeliculaDTO>()
                .ForMember(dto => dto.Cines,
                ent => ent.MapFrom(prop => prop.SalaDeCines.Select(c => c.Cine)))
                .ForMember(dto => dto.Actores,
                ent => ent.MapFrom(prop => prop.PeliculaActores.Select(ac => ac.Actor)));

            //Con ProjectTo
            //CreateMap<Pelicula, PeliculaDTO>()
            //    .ForMember(dto => dto.Generos, ent =>
            //    ent.MapFrom(prop => prop.Generos.OrderByDescending(g=>g.Nombre)))
            //    .ForMember(dto => dto.Cines,
            //    ent => ent.MapFrom(prop => prop.SalaDeCines.Select(c => c.Cine)))
            //    .ForMember(dto => dto.Actores,
            //    ent => ent.MapFrom(prop => prop.PeliculaActores.Select(ac => ac.Actor)));
        }
    }
}
