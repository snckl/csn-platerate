using MediatR;
using Microsoft.Extensions.Logging;
using PlateRate.Domain.Repositories;

namespace PlateRate.Application.Restaurants.Commands.DeleteRestaurant;
public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger
    ,IRestaurantRepository restaurantRepository) : IRequestHandler<DeleteRestaurantCommand,bool>
{
    public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Deleting restaurant by ID: {request.Id}");
        var restaurant = await restaurantRepository.GetByIdAsync( request.Id );
        if (restaurant is null)
        {
            return false;
        }
        await restaurantRepository.DeleteAsync(restaurant);
        return true;
    }
}
