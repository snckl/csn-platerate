using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PlateRate.Domain.Repositories;

namespace PlateRate.Application.Restaurants.Commands.UpdateRestaurant;
public class UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommandHandler> logger
    ,IMapper mapper,IRestaurantRepository restaurantRepository) : IRequestHandler<UpdateRestaurantCommand, bool>
{
    public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Updating the restaurant with ID: {request.Id}");
        var restaurant = await restaurantRepository.GetByIdAsync(request.Id);
        if (restaurant is null)
        {
            return false;
        }

        mapper.Map(request,restaurant); // updates restaurant with request data.

        await restaurantRepository.SaveAsync();
        
        return true;
    }
}
