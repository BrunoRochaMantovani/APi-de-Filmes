using Filmes_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filmes_API.Data.Mapping
{
    public class NacionalidadeMap : IEntityTypeConfiguration<Nacionalidade>
    {
        public void Configure(EntityTypeBuilder<Nacionalidade> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Pais)
                   .HasMaxLength(20);

            builder.Property(x => x.Pais)
                   .IsRequired();

            builder.HasIndex(x => x.Pais)
                   .IsUnique();
        }
    }
}
