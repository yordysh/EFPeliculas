using Domain;
using Microsoft.EntityFrameworkCore;

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

            modelBuilder.Entity<Genero>().HasKey(opcion => opcion.Id);
            modelBuilder.Entity<Genero>().Property(opcion => opcion.Nombre)
                .HasMaxLength(150).IsRequired();

            modelBuilder.Entity<Actor>().Property(opcion => opcion.Nombre)
                .HasMaxLength(150).IsRequired();
            modelBuilder.Entity<Actor>().Property(opcion => opcion.FechaNacimiento)
                .HasColumnType("date");

            modelBuilder.Entity<Cine>().Property(opcion => opcion.Nombre)
                .HasMaxLength(150).IsRequired();
            modelBuilder.Entity<Cine>().Property(opcion => opcion.Precio)
                .HasPrecision(precision:9, scale:2);

            modelBuilder.Entity<Pelicula>().Property(opcion => opcion.Titulo)
                .HasMaxLength(250).IsRequired();
            modelBuilder.Entity<Pelicula>().Property(opcion => opcion.FechaEstreno)
                .HasColumnType("date");
            modelBuilder.Entity<Pelicula>().Property(opcion => opcion.PosterUrl)
                .HasMaxLength(500).IsUnicode(false);

            modelBuilder.Entity<CineOferta>().Property(opcion => opcion.PocentajeDescuento)
                .HasPrecision(precision:5, scale:2);
            modelBuilder.Entity<CineOferta>().Property(opcion => opcion.FechaInicio)
                .HasColumnType("date");
            modelBuilder.Entity<CineOferta>().Property(opcion => opcion.FechaFin)
                .HasColumnType("date");

        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Cine> Cines { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<CineOferta> CineOfertas { get; set; }
    }
}
