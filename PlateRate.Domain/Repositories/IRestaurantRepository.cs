using PlateRate.Domain.Entities;

namespace PlateRate.Domain.Repositories;
public interface IRestaurantRepository
{
    Task<IEnumerable<Restaurant>> GetAllAsync();
    Task<Restaurant?> GetByIdAsync(int id);
    Task<int> CreateAsync(Restaurant entity);
    Task DeleteAsync(Restaurant restaurant);
}
