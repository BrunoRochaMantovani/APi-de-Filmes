using Filmes_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filmes_API.Data.Mapping
{
    public class PapelMap : IEntityTypeConfiguration<Papel>
    {
        public void Configure(EntityTypeBuilder<Papel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TipoPapel)
                   .HasMaxLength(50);

            builder.Property(x => x.TipoPapel)
                   .IsRequired();

            builder.HasIndex(x => x.TipoPapel)
                   .IsUnique();

        }
    }
}
