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
