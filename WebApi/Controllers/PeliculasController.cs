using AutoMapper;
using AutoMapper.QueryableExtensions;
using Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Controllers.DTOs;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/peliculas")]
    public class PeliculasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PeliculasController(ApplicationDbContext context , IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PeliculaDTO>> Get(int id)
        {
            var pelicula = await context.Peliculas.
                Include(p => p.Generos.OrderByDescending(g=>g.Nombre)).
                Include(p => p.SalaDeCines).
                    ThenInclude(p => p.Cine).
                Include(a => a.PeliculaActores.Where(pa => pa.Actor.FechaNacimiento.Value.Year >= 1980)).
                    ThenInclude(pa => pa.Actor).
                FirstOrDefaultAsync(p => p.Id == id);
            if (pelicula is null)
            {
                return NotFound();
            }

            var peliculaDto = mapper.Map<PeliculaDTO>(pelicula);
            peliculaDto.Cines = peliculaDto.Cines.DistinctBy(x => x.Id).ToList();

            return peliculaDto;
        }

        [HttpGet("conprojecto/{id:int}")]
        public async Task<ActionResult<PeliculaDTO>> GetProjectTo(int id)
        {
            var pelicula = await context.Peliculas.
               ProjectTo<PeliculaDTO>(mapper.ConfigurationProvider).
                FirstOrDefaultAsync(p => p.Id == id);
            if (pelicula is null)
            {
                return NotFound();
            }

            pelicula.Cines = pelicula.Cines.DistinctBy(x => x.Id).ToList();

            return pelicula;
        }

        [HttpGet("cargadoselectivo/{id:int}")]
        public async Task<ActionResult> GetSelectivo(int id)
        {
            var pelicula = await context.Peliculas.Select(p => new
            {
                Id = p.Id,
                Titulo = p.Titulo,
                Generos = p.Generos.OrderByDescending(g => g.Nombre).Select(g => g.Nombre).ToList(),
                CantidadActores = p.PeliculaActores.Count(),
                CantidadCines = p.SalaDeCines.Select(c => c.CineId).Distinct().Count()
            }).FirstOrDefaultAsync(p => p.Id == id);
            if (pelicula is null)
            {
                return NotFound();
            }

            return Ok(pelicula);
        }

    }
}
