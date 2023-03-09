using Filmes_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filmes_API.Data.Mapping
{
    public class FilmeMap : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titulo)
                .IsRequired();


            builder.Property(x => x.Titulo)
                .HasMaxLength(50);

            builder.Property(x => x.AnoLancamento) 
                .IsRequired();

            builder.Property( x => x.Plot)
                .IsRequired();


            builder.Property(x => x.Plot)
                .HasMaxLength(400);

            builder.Property(x=>x.DuracaoFilme) 
                .IsRequired();
            
            builder.HasOne(x => x.Diretor)
                .WithMany(x => x.Filmes)
                .HasForeignKey(x => x.DiretorId);

            builder.HasMany(x => x.Atores)
                .WithMany(x => x.Filmes)
                .UsingEntity<Dictionary<string, object>>(
                    "FilmeAtor",
                    filme => filme
                        .HasOne<Ator>()
                        .WithMany()
                        .HasForeignKey("FilmeId")
                        .OnDelete(DeleteBehavior.Cascade),
                    ator => ator
                        .HasOne<Filme>()
                        .WithMany()
                        .HasForeignKey("AtorId")
                        .OnDelete(DeleteBehavior.Cascade)


                );

            builder.HasMany(x => x.Generos)
                .WithMany(x => x.Filmes)
                .UsingEntity<Dictionary<string, object>>(
                    "FilmeGenero",
                    filme => filme
                        .HasOne<Genero>()
                        .WithMany()
                        .HasForeignKey("FilmeId")
                        .OnDelete(DeleteBehavior.Cascade),
                    genero => genero
                        .HasOne<Filme>()
                        .WithMany()
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                );
        }
    }
}
