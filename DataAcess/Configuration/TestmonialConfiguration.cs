using Core.DefaultValue;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DataAcess.Configuration
{
    public class TestmonialConfiguration : IEntityTypeConfiguration<TestmonialSection>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TestmonialSection> builder)
        {
            builder.ToTable("TestmonialSections");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .IsRequired()
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_KEY_SEED, increment: 1);

            builder.Property(x => x.PhotoUrl)
               .IsRequired();
        }

    }
}
