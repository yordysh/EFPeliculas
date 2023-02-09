using Entitys;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApi.Entitys.Seeding;

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

            //modelBuilder.ApplyConfiguration(new GeneroConfig());
            //modelBuilder.ApplyConfiguration(new ActorConfig());
            //modelBuilder.ApplyConfiguration(new CineConfig());
            //modelBuilder.ApplyConfiguration(new PeliculaConfig());
            //modelBuilder.ApplyConfiguration(new CineOfertaConfig());
            //modelBuilder.ApplyConfiguration(new SalaDeCineConfig());
            //modelBuilder.ApplyConfiguration(new PeliculaActorConfig());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            SeedingModuloConsulta.Seed(modelBuilder);


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
