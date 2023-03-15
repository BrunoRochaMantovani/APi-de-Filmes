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


            builder.HasOne(x => x.Genero)
                   .WithMany(x => x.Filmes)
                   .HasForeignKey(x => x.GeneroId);
        }
    }
}
