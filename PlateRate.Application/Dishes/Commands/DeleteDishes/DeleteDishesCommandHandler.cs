using MediatR;
using Microsoft.Extensions.Logging;
using PlateRate.Domain.Entities;
using PlateRate.Domain.Exceptions;
using PlateRate.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateRate.Application.Dishes.Commands.DeleteDishes;
internal class DeleteDishesCommandHandler(ILogger<DeleteDishesCommandHandler> logger
    ,IRestaurantRepository restaurantRepository,IDishRepository dishRepository) : IRequestHandler<DeleteDishesCommand>
{
    public async Task Handle(DeleteDishesCommand request, CancellationToken cancellationToken)
    {
        logger.LogWarning("Deleting all dishes of restaurant with Id: {restaurantId}",request.RestaurantId);
        var restraurant = await restaurantRepository.GetByIdAsync(request.RestaurantId);
        if (restraurant is null)
        {
            throw new NotFoundException(nameof(Restaurant),request.RestaurantId.ToString());
        }
        await dishRepository.DeleteAsync(restraurant.Dishes);
    }
}
