using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PlateRate.Application.User;
using PlateRate.Domain.Entities;
using PlateRate.Domain.Repositories;

namespace PlateRate.Application.Restaurants.Commands.CreateRestaurant;
public class CreateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> logger
    ,IMapper mapper,IRestaurantRepository restaurantRepository,, IUserContext userContext) : IRequestHandler<CreateRestaurantCommand, int>
{
    public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser();
        logger.LogInformation("{Username} [{UserId}] Creating restaurant {@Restaurant}", currentUser.Email, currentUser.Id,request);

        var restaurant = mapper.Map<Restaurant>(request);
        restaurant.OwnerId = currentUser.Id;

        int id = await restaurantRepository.CreateAsync(restaurant);
        return id;
    }
}
