using Microsoft.EntityFrameworkCore;
using RestrauntApp.Models;

namespace RestrauntApp.Data
{
    public class RestContext: DbContext
    {
        public RestContext(DbContextOptions<RestContext> options) : base(options)
        {
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Item> Items { get; set; }
        // DbSet<Menu> Menus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>()
                .HasMany(c => c.Restaurants)
                .WithOne(r => r.City)
                .HasForeignKey(r => r.CityId);

            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.Items)
                .WithOne(i => i.Restaurant)
                .HasForeignKey(i => i.RestaurantId);

            /*
            modelBuilder.Entity<Menu>()
                .HasMany(m => m.Items)
                .WithOne(i => i.Menu)
                .HasForeignKey(i => i.MenuId);
            */
        }
    }
}
