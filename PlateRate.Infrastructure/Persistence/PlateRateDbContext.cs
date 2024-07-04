using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlateRate.Domain.Entities;

namespace PlateRate.Infrastructure.Persistence;

internal class PlateRateDbContext(DbContextOptions<PlateRateDbContext> options) : IdentityDbContext<User>(options)
{
    internal DbSet<Restaurant> Restaurants { get; set; }
    internal DbSet<Dish> Dishes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Restaurant>()
            .OwnsOne(e => e.Address);
        modelBuilder.Entity<Restaurant>()
            .HasMany(e => e.Dishes)
            .WithOne()
            .HasForeignKey(d => d.RestaurantId);

    }
}