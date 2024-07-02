using Microsoft.Extensions.Logging;
using PlateRate.Domain.Entities;
using PlateRate.Domain.Repositories;

namespace PlateRate.Application.Restaurants;

internal class RestaurantsService(IRestaurantRepository restaurantRepository, ILogger<RestaurantsService> logger) : IRestaurantsService
{
    public async Task<IEnumerable<Restaurant>> GetAllRestaurants()
    {
        logger.LogInformation("Getting all restaurants");
        var restaurants = await restaurantRepository.GetAllAsync();
        return restaurants;
    }

    public async Task<Restaurant?> GetByIdAsync(int id)
    {
        logger.LogInformation($"Getting restaurant with ID: {id}");
        var restaurant = await restaurantRepository.GetByIdAsync(id);
        return restaurant;
    }
}