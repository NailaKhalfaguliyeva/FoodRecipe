using Core.DefaultValue;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DataAcess.Configuration
{
    public class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Food> builder)
        {
            builder.ToTable("Foods");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .IsRequired()
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_KEY_SEED, increment: 1);

            builder.Property(x => x.Photo)
                .IsRequired();

            builder.HasOne(x => x.FoodCategory)
                .WithMany(x => x.Foods)
                .HasForeignKey(x => x.FoodCategoryID);


        }
    }
}
