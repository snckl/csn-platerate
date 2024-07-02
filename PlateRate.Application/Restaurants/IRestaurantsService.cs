using PlateRate.Application.Restaurants.Dtos;
using PlateRate.Domain.Entities;

namespace PlateRate.Application.Restaurants;
public interface IRestaurantsService
{
    Task<IEnumerable<RestaurantDto>> GetAllRestaurants();
    Task<RestaurantDto?> GetByIdAsync(int id);
    Task<int> CreateAsync(CreateRestaurantDto dto);
}