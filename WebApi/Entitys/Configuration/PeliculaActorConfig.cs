using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entitys.Configuration
{
    public class PeliculaActorConfig : IEntityTypeConfiguration<PeliculaActor>
    {
        public void Configure(EntityTypeBuilder<PeliculaActor> builder)
        {
            builder.HasKey(opcion =>
            new {
                opcion.PeliculaId,
                opcion.ActorId
            });
            builder.Property(opcion => opcion.Personaje)
                .HasMaxLength(150);
        }
    }
}
