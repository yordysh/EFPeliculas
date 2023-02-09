using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;


namespace Entitys   
{
    public class Cine
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public Point? Ubicacion { get; set; }
        public CineOferta CineOferta { get; set; }
        public HashSet<SalaDeCine> SalaDeCines { get;}
    }
}
