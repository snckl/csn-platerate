using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PlateRate.Domain.Entities;
using PlateRate.Domain.Exceptions;
using PlateRate.Domain.Repositories;

namespace PlateRate.Application.Dishes.Commands.CreateDish;
public class CreateDishCommandHandler(ILogger<CreateDishCommandHandler> logger
    ,IMapper mapper,IDishRepository dishRepository,IRestaurantRepository restaurantRepository) : IRequestHandler<CreateDishCommand,int>
{
    public async Task<int> Handle(CreateDishCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new dish: {@DishRequest}", request);
        var restaurant = await restaurantRepository.GetByIdAsync(request.RestaurantId);
        if (restaurant is null)
        {
            throw new NotFoundException(nameof(Restaurant),request.RestaurantId.ToString());
        }

        var dish = mapper.Map<Dish>(request);

        var id = await dishRepository.CreateAsync(dish);
        return id;
    }
}
