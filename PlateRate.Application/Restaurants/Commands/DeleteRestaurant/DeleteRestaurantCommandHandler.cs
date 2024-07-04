using MediatR;
using Microsoft.Extensions.Logging;
using PlateRate.Domain.Entities;
using PlateRate.Domain.Exceptions;
using PlateRate.Domain.Repositories;

namespace PlateRate.Application.Restaurants.Commands.DeleteRestaurant;
public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger
    ,IRestaurantRepository restaurantRepository) : IRequestHandler<DeleteRestaurantCommand>
{
    public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogWarning("Deleting restaurant by ID: {RestaurantId}",request.Id);
        var restaurant = await restaurantRepository.GetByIdAsync( request.Id );
        if (restaurant is null)
        {
            throw new NotFoundException(nameof(Restaurant),request.Id.ToString());
        }
        await restaurantRepository.DeleteAsync(restaurant);
    }
}
