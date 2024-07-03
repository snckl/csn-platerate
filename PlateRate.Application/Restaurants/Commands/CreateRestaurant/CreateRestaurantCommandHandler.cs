using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PlateRate.Domain.Entities;
using PlateRate.Domain.Repositories;

namespace PlateRate.Application.Restaurants.Commands.CreateRestaurant;
public class CreateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> logger
    ,IMapper mapper,IRestaurantRepository restaurantRepository) : IRequestHandler<CreateRestaurantCommand, int>
{
    public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating restaurant");
        var restaurant = mapper.Map<Restaurant>(request);

        int id = await restaurantRepository.CreateAsync(restaurant);
        return id;
    }
}
