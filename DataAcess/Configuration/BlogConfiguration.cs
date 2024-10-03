using Core.DefaultValue;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DataAcess.Configuration
{
    public class BlogConfiguration : IEntityTypeConfiguration<BlogCard>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<BlogCard> builder)
        {
            builder.ToTable("BlogCards");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .IsRequired()
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_KEY_SEED, increment: 1);

            builder.Property(x => x.Days)
                .HasMaxLength(50)
               .IsRequired();

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Likes)
                .IsRequired()
                .HasPrecision(7, 2);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(2000);
        }
    }
}
