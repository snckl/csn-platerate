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
}