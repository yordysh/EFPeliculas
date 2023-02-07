using Domain;
using Microsoft.EntityFrameworkCore;

namespace WebApi
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genero>().HasKey(opcion => opcion.Id);
            modelBuilder.Entity<Genero>().Property(opcion => opcion.Nombre)
                .HasMaxLength(150).IsRequired();

            modelBuilder.Entity<Actor>().Property(opcion => opcion.Nombre)
                .HasMaxLength(150).IsRequired();

            modelBuilder.Entity<Cine>().Property(opcion => opcion.Nombre)
                .HasMaxLength(150).IsRequired();

            modelBuilder.Entity<Pelicula>().Property(opcion => opcion.Titulo)
                .HasMaxLength(250).IsRequired();
            modelBuilder.Entity<Pelicula>().Property(opcion => opcion.PosterUrl)
                .HasMaxLength(500).IsUnicode(false);

            modelBuilder.Entity<CineOferta>().Property(opcion => opcion.PocentajeDescuento)
                .HasPrecision(precision: 5, scale: 2);
           

            modelBuilder.Entity<SalaDeCine>().Property(opcion => opcion.Precio)
                .HasPrecision(precision: 5, scale: 2);
            modelBuilder.Entity<SalaDeCine>().Property(opcion => opcion.TipoSalaDeCine)
                .HasDefaultValue(TipoSalaDeCine.DosDimensiones);

            modelBuilder.Entity<PeliculaActor>().HasKey(opcion => new
            {
                opcion.PeliculaId,
                opcion.ActorId
            });
            modelBuilder.Entity<PeliculaActor>().Property(opcion => opcion.Personaje)
                .HasMaxLength(150);

        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Cine> Cines { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<CineOferta> CineOfertas { get; set; }
        public DbSet<SalaDeCine> SalaDeCines { get; set; }
        public DbSet<PeliculaActor> PeliculaActores { get; set; }
    }
}
