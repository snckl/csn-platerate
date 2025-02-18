﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PlateRate.Application.Restaurants.Dtos;
using PlateRate.Domain.Entities;
using PlateRate.Domain.Exceptions;
using PlateRate.Domain.Repositories;

namespace PlateRate.Application.Restaurants.Queries.GetRestaurantById;
public class GetRestaurantByIdQueryHandler(ILogger<GetRestaurantByIdQueryHandler> logger
    ,IMapper mapper,IRestaurantRepository restaurantRepository) : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto>
{
    public async Task<RestaurantDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting restaurant with ID: {RestaurantId}",request.Id);
        var restaurant = await restaurantRepository.GetByIdAsync(request.Id) 
            ?? throw new NotFoundException(nameof(Restaurant), request.Id.ToString());

        var restaurantDto = mapper.Map<RestaurantDto>(restaurant);

        return restaurantDto;
    }
}
