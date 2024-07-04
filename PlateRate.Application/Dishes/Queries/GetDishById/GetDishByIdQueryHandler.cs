using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PlateRate.Application.Restaurants.Dtos;
using PlateRate.Domain.Entities;
using PlateRate.Domain.Exceptions;
using PlateRate.Domain.Repositories;

namespace PlateRate.Application.Dishes.Queries.GetDishById;
public class GetDishByIdQueryHandler(ILogger<GetDishByIdQuery> logger,IMapper mapper
    ,IRestaurantRepository restaurantRepository) : IRequestHandler<GetDishByIdQuery, DishDto>
{
    public async Task<DishDto> Handle(GetDishByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Retrieving dish: {dishId}, for restaurant with id: {restaurantId}",request.DishId,request.RestaurantId);
        var restaurant = await restaurantRepository.GetByIdAsync(request.RestaurantId);
        if (restaurant is null)
        {
            throw new NotFoundException(nameof(Restaurant),request.RestaurantId.ToString());
        }

        var dish = restaurant.Dishes.FirstOrDefault(d => d.Id == request.DishId);
        if(dish is null)
        {
            throw new NotFoundException(nameof(Dish), request.DishId.ToString());
        }

        var result = mapper.Map<DishDto>(dish);
        return result;
    }
}
