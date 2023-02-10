using AutoMapper;
using AutoMapper.QueryableExtensions;
using Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Controllers.DTOs;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/Actores")]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AutoresController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("SeleccionarCampos")]
        public async Task<IEnumerable<ActorDTO>> Get()
        {
            //return await context.Actores.Select(a => new ActorDTO { Id = a.Id, Nombre = a.Nombre}).ToListAsync();
            return await context.Actores.ProjectTo<ActorDTO>(mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
