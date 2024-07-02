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
       var restaurants = await dbContext.Restaurants.ToListAsync();
       return restaurants;
    }

    public async Task<Restaurant?> GetByIdAsync(int id)
    {
        var restaurant = await dbContext.Restaurants.FirstOrDefaultAsync(r => r.Id == id);
        return restaurant;
    }
}
