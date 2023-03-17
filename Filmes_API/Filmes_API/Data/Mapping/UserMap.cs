using Filmes_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filmes_API.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(x => x.Username)
                  .HasMaxLength(25)
                  .IsRequired();

            builder.Property(x => x.Email)
                  .HasMaxLength(70)
                  .IsRequired();

            builder.Property(x => x.Password)
                  .HasMaxLength(50)
                  .IsRequired();

            builder.HasOne(x => x.Papel)
                   .WithMany(x => x.Users)
                   .HasForeignKey(x => x.PapelId);
        }
    }
}
