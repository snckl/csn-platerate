using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PlateRate.Application.Common;
using PlateRate.Application.Restaurants.Dtos;
using PlateRate.Domain.Repositories;

namespace PlateRate.Application.Restaurants.Queries.GetAllRestaurants;
public class GetAllRestaurantsQueryHandler(ILogger<GetAllRestaurantsQueryHandler> logger
    ,IMapper mapper,IRestaurantRepository restaurantRepository) : IRequestHandler<GetAllRestaurantsQuery, PageResult<RestaurantDto>>
{
    public async Task<PageResult<RestaurantDto>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
    {
            request.Page = request.Page == 0 ? 1 : request.Page;
            request.Count = request.Count == 0 ? 8 : request.Count;
            
            logger.LogInformation("Getting all restaurants");
            var (restaurants,totalCount) = await restaurantRepository.GetAllAsync(request.SearchPhrase,request.Page,request.Count);
            var restaurantsDto = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
            var result = new PageResult<RestaurantDto>(restaurantsDto, totalCount,request.Page,request.Count);
            
            return result;     
    }
}
