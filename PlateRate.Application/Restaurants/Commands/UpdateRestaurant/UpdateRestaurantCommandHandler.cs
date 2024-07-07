using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PlateRate.Domain.Entities;
using PlateRate.Domain.Exceptions;
using PlateRate.Domain.Interfaces;
using PlateRate.Domain.Repositories;
using PlateRate.Infrastructure.Constants;

namespace PlateRate.Application.Restaurants.Commands.UpdateRestaurant;
public class UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommandHandler> logger
    ,IMapper mapper,IRestaurantRepository restaurantRepository
    ,IRestaurantAuthorizationService restaurantAuthorization) : IRequestHandler<UpdateRestaurantCommand>
{
    public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating the restaurant with ID: {RestraurantId} with {@UpdatedResturant}",request.Id,request);
        var restaurant = await restaurantRepository.GetByIdAsync(request.Id);
        if (restaurant is null)
        {
            throw new NotFoundException(nameof(Restaurant), request.Id.ToString());
        }
        if (!restaurantAuthorization.Authorize(restaurant, ResourceOperation.Update))
        {
            throw new ForbidException();
        }

        mapper.Map(request,restaurant); // updates restaurant with request data.

        await restaurantRepository.SaveAsync();
    }
}
