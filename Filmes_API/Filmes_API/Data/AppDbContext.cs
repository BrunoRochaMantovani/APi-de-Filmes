using Filmes_API.Data.Mapping;
using Filmes_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Filmes_API.Data
{

    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {

        }
        public DbSet<Ator> Atores { get; set; }
        public DbSet<Diretor> Diretores { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Genero> Generos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AtorMap());
            modelBuilder.ApplyConfiguration(new DiretorMap());
            modelBuilder.ApplyConfiguration(new FilmeMap());
            modelBuilder.ApplyConfiguration(new GeneroMap());
        }
    }
}
