using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys   
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool EnCartelera { get; set; }
        public DateTime FechaEstreno { get; set; }
        public string PosterUrl { get; set; }
        public List<Genero> Generos { get; set; }
        public HashSet<SalaDeCine> SalaDeCines { get; set; }
        public HashSet<PeliculaActor> PeliculaActores { get; set; }
    }
}
