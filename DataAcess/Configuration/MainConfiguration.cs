using Core.DefaultValue;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DataAcess.Configuration
{
    public class MainConfiguration : IEntityTypeConfiguration<Main>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Main> builder)
        {
            builder.ToTable("Mains");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .IsRequired()
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_KEY_SEED, increment: 1);

            builder.Property(x => x.Photo)
               .IsRequired();

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(2000);
        }
    }
}
