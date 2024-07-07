using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PlateRate.Application.User;
using PlateRate.Domain.Entities;
using PlateRate.Domain.Exceptions;
using PlateRate.Domain.Interfaces;
using PlateRate.Domain.Repositories;
using PlateRate.Infrastructure.Constants;

namespace PlateRate.Application.Restaurants.Commands.CreateRestaurant;
public class CreateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> logger
    ,IMapper mapper,IRestaurantRepository restaurantRepository, IUserContext userContext
    ,IRestaurantAuthorizationService restaurantAuthorization) : IRequestHandler<CreateRestaurantCommand, int>
{
    public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser()!;
        logger.LogInformation("{UserEmail} [{UserId}] Creating restaurant {@Restaurant}", currentUser.Email, currentUser.Id,request);

        var restaurant = mapper.Map<Restaurant>(request);
        restaurant.OwnerId = currentUser.Id;

        if (!restaurantAuthorization.Authorize(restaurant, ResourceOperation.Create))
        {
            throw new ForbidException();
        }

        int id = await restaurantRepository.CreateAsync(restaurant);
        return id;
    }
}
