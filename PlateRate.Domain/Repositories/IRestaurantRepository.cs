
using PlateRate.Domain.Constants;
using PlateRate.Domain.Entities;

namespace PlateRate.Domain.Repositories;
public interface IRestaurantRepository
{
    Task<(IEnumerable<Restaurant>, int)> GetAllAsync(string? searchPhrase,int page,int size,string sortBy, SortDirection sortDirection);
    Task<Restaurant?> GetByIdAsync(int id);
    Task<int> CreateAsync(Restaurant entity);
    Task DeleteAsync(Restaurant restaurant);
    Task SaveAsync();
}
