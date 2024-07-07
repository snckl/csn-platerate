using Microsoft.EntityFrameworkCore;
using PlateRate.Domain.Constants;
using PlateRate.Domain.Entities;
using PlateRate.Domain.Repositories;
using PlateRate.Infrastructure.Persistence;
using System.Linq.Expressions;

namespace PlateRate.Infrastructure.Repositories;
internal class RestaurantsRepository(PlateRateDbContext dbContext) : IRestaurantRepository
{
    public async Task<(IEnumerable<Restaurant>,int)> GetAllAsync(string? searchPhrase,int page, int size,string sortBy, SortDirection sortDirection)
    {

        var search = searchPhrase?.ToLower();

        var baseQuery = dbContext.Restaurants
             .Where(r => search == null || (r.Name.ToLower().Contains(search)
             || r.Description.ToLower().Contains(search)));

        var totalCount = await baseQuery.CountAsync();

        if (sortBy is not null)
        {
            var columnSelector = new Dictionary<string, Expression<Func<Restaurant, object>>>()
            {
                {nameof(Restaurant.Name), r=> r.Name},
                {nameof(Restaurant.Description), r=> r.Description},
                {nameof(Restaurant.Category), r=> r.Category}
            };

            var selectedColumn = columnSelector[sortBy];

            baseQuery = sortDirection == SortDirection.Ascending
                ? baseQuery.OrderBy(selectedColumn) : baseQuery.OrderByDescending(selectedColumn);
        }

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
