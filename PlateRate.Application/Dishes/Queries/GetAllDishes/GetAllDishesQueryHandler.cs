using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PlateRate.Application.Restaurants.Dtos;
using PlateRate.Domain.Entities;
using PlateRate.Domain.Exceptions;
using PlateRate.Domain.Repositories;

namespace PlateRate.Application.Dishes.Queries.GetAllDishes;
internal class GetAllDishesQueryHandler(ILogger<GetAllDishesQueryHandler> logger
    ,IMapper mapper,IRestaurantRepository restaurantRepository) : IRequestHandler<GetAllDishesQuery, IEnumerable<DishDto>>
{
    public async Task<IEnumerable<DishDto>> Handle(GetAllDishesQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting dishes for restaurantId: {restaurantId}",request.RestaurantId);
        var restaurant = await restaurantRepository.GetByIdAsync(request.RestaurantId);
        if(restaurant is null)
        {
            throw new NotFoundException(nameof(Restaurant),request.RestaurantId.ToString());
        }
        var results = mapper.Map<IEnumerable<DishDto>>(restaurant.Dishes);

        return results;
    }
}
