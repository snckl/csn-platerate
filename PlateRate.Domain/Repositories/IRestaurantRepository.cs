using PlateRate.Domain.Entities;

namespace PlateRate.Domain.Repositories;
public interface IRestaurantRepository
{
    Task<(IEnumerable<Restaurant>, int)> GetAllAsync(string? searchPhrase,int page,int size);
    Task<Restaurant?> GetByIdAsync(int id);
    Task<int> CreateAsync(Restaurant entity);
    Task DeleteAsync(Restaurant restaurant);
    Task SaveAsync();
}
