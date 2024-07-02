using AutoMapper;
using Microsoft.Extensions.Logging;
using PlateRate.Application.Restaurants.Dtos;
using PlateRate.Domain.Entities;
using PlateRate.Domain.Repositories;

namespace PlateRate.Application.Restaurants;

internal class RestaurantsService(IRestaurantRepository restaurantRepository
    , ILogger<RestaurantsService> logger,IMapper mapper) : IRestaurantsService
{
    public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
    {
        logger.LogInformation("Getting all restaurants");
        var restaurants = await restaurantRepository.GetAllAsync();
        var restaurantsDto = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

        return restaurantsDto;
    }

    public async Task<RestaurantDto?> GetByIdAsync(int id)
    {
        logger.LogInformation($"Getting restaurant with ID: {id}");
        var restaurant = await restaurantRepository.GetByIdAsync(id);
        var restaurantDto = mapper.Map<RestaurantDto>(restaurant);

        return restaurantDto;
    }
}