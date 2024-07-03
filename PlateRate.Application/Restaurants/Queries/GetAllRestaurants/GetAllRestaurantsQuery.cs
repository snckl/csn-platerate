using MediatR;
using PlateRate.Application.Restaurants.Dtos;

namespace PlateRate.Application.Restaurants.Queries.GetAllRestaurants;
public class GetAllRestaurantsQuery : IRequest<IEnumerable<RestaurantDto>>
{
}
