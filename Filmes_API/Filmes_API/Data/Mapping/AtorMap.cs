using Filmes_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filmes_API.Data.Mapping
{
    public class AtorMap : IEntityTypeConfiguration<Ator>
    {
        public void Configure(EntityTypeBuilder<Ator> builder)
        {
            builder.HasKey(x =>x.Id);

            builder.Property(x => x.PrimeiroNome)
                   .HasMaxLength(15)
                   .IsRequired();

            builder.Property(x => x.UltimoNome)
                  .HasMaxLength(15)
                  .IsRequired();

            builder.Property(x => x.Nacionalidade)
                   .HasMaxLength(25)
                   .IsRequired();

            builder.HasIndex(x => x.Nacionalidade)
                   .IsUnique();

        }
    }
}
