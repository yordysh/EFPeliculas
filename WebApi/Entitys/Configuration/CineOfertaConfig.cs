using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entitys.Configuration
{
    public class CineOfertaConfig : IEntityTypeConfiguration<CineOferta>
    {
        public void Configure(EntityTypeBuilder<CineOferta> builder)
        {
            builder.Property(opcion => opcion.PocentajeDescuento)
               .HasPrecision(precision: 5, scale: 2);

        }
    }
}
