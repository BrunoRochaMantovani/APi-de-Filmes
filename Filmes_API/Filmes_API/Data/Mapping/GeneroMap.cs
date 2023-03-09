using Filmes_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filmes_API.Data.Mapping
{
    public class GeneroMap : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NomeGenero)
                   .HasMaxLength(50);

            builder.Property(x => x.NomeGenero)
                   .IsRequired();
            
            builder.HasIndex(x => x.NomeGenero)
                   .IsUnique();

        }
    }
}
