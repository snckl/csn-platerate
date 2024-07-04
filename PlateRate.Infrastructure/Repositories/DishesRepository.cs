using PlateRate.Domain.Entities;
using PlateRate.Domain.Repositories;
using PlateRate.Infrastructure.Persistence;

namespace PlateRate.Infrastructure.Repositories;
internal class DishesRepository(PlateRateDbContext dbContext) : IDishRepository
{
    public async Task<int> CreateAsync(Dish entity)
    {
        dbContext.Dishes.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task DeleteAsync(Dish dish)
    {
        throw new NotImplementedException();
    }

}
