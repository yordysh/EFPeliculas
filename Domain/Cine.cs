using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;


namespace Domain
{
    public class Cine
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public decimal Precio { get; set; }
        public Point? Ubicacion { get; set; }
        public CineOferta CineOferta { get; set; }
    }
}
