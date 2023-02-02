using Domain;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace WebApi
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Genero>().HasKey(prop => prop.Id);
            modelBuilder.Entity<Genero>().Property(prop => prop.Nombre)
                .HasMaxLength(150).IsRequired();

            modelBuilder.Entity<Actor>().Property(prop => prop.Nombre)
                .HasMaxLength(150).IsRequired();
            modelBuilder.Entity<Actor>().Property(prop => prop.FechaNacimiento)
                .HasColumnType("date");

            modelBuilder.Entity<Cine>().Property(prop => prop.Nombre)
                .HasMaxLength(150).IsRequired();
            modelBuilder.Entity<Cine>().Property(prop => prop.Precio)
                .HasPrecision(precision: 9, scale: 2);
           
        }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Cine> Cines { get; set; }

    }
}
