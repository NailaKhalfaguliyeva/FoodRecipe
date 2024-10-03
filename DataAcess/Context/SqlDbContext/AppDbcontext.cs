using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAcess.Context.SqlDbContext
{
    public class AppDbcontext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=Localhost;Initial Catalog=CookingDB; Integrated Security = true;Encrypt=false");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<About> Abouts { get; set; }

        public DbSet<Food> Foods { get; set; }

        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<AboutRightContent> AboutRightContents { get; set; }
        public DbSet<BlogCard> BlogCards { get; set; }
        public DbSet<Main>Mains { get; set; }
        public DbSet<MainCounter> MainCounters { get; set; }
        public DbSet<MainNewsLetter> MainNewsLetters { get; set; }
        public DbSet<Service>Services { get; set; }
        public DbSet<TestmonialSection> TestmonialSections { get; set; }


    }
}
