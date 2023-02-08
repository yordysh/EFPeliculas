using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configuration
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
