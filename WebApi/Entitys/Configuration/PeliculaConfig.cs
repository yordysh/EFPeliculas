using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entitys.Configuration
{
    public class PeliculaConfig : IEntityTypeConfiguration<Pelicula>
    {
        public void Configure(EntityTypeBuilder<Pelicula> builder)
        {
            builder.Property(opcion => opcion.Titulo)
            .HasMaxLength(250).IsRequired();
            builder.Property(opcion => opcion.PosterUrl)
                .HasMaxLength(500).IsUnicode(false);
        }
    }
}
