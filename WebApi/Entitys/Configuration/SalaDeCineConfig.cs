using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entitys.Configuration
{
    public class  SalaDeCineConfig : IEntityTypeConfiguration<SalaDeCine>
    {
        public void Configure(EntityTypeBuilder<SalaDeCine> builder)
        {
        builder.Property(opcion => opcion.Precio)
            .HasPrecision(precision: 5, scale: 2);
        builder.Property(opcion => opcion.TipoSalaDeCine)
            .HasDefaultValue(TipoSalaDeCine.DosDimensiones);
    }
    }
}
