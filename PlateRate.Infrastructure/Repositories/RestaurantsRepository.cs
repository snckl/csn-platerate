using Microsoft.EntityFrameworkCore;
using PlateRate.Domain.Entities;
using PlateRate.Domain.Repositories;
using PlateRate.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateRate.Infrastructure.Repositories;
internal class RestaurantsRepository(PlateRateDbContext dbContext) : IRestaurantRepository
{
    public async Task<IEnumerable<Restaurant>> GetAllAsync()
    {
       var restaurants = await dbContext.Restaurants
            .Include(r => r.Dishes)
            .ToListAsync();

       return restaurants;
    }

    public async Task<Restaurant?> GetByIdAsync(int id)
    {
        var restaurant = await dbContext.Restaurants
            .Include(r => r.Dishes)
            .FirstOrDefaultAsync(r => r.Id == id); 

        return restaurant;
    }

    public async Task<int> CreateAsync(Restaurant entity)
    {
        dbContext.Restaurants.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task DeleteAsync(Restaurant restaurant)
    {
       dbContext.Remove(restaurant);
       await dbContext.SaveChangesAsync();
    }

    public async Task SaveAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}
