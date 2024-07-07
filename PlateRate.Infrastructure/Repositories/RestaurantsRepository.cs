﻿using Microsoft.EntityFrameworkCore;
using PlateRate.Domain.Entities;
using PlateRate.Domain.Repositories;
using PlateRate.Infrastructure.Persistence;

namespace PlateRate.Infrastructure.Repositories;
internal class RestaurantsRepository(PlateRateDbContext dbContext) : IRestaurantRepository
{
    public async Task<(IEnumerable<Restaurant>,int)> GetAllAsync(string? searchPhrase,int page, int size)
    {

        var search = searchPhrase?.ToLower();

        var baseQuery = dbContext.Restaurants
             .Where(r => search == null || (r.Name.ToLower().Contains(search)
             || r.Description.ToLower().Contains(search)));

        var totalCount = await baseQuery.CountAsync();

        var restaurants = await baseQuery
             .Skip((page -1)*size)
             .Take(size)
             .Include(r => r.Dishes)
             .ToListAsync();

        return (restaurants,totalCount);
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
