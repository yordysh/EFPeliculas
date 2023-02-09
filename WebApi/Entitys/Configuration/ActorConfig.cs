using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entitys.Configuration
{
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
           builder.Property(opcion => opcion.Nombre)
                .HasMaxLength(150).IsRequired();
        }
    }
}
