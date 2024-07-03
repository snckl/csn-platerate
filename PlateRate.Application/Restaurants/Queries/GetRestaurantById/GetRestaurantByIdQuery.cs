using MediatR;
using PlateRate.Application.Restaurants.Dtos;

namespace PlateRate.Application.Restaurants.Queries.GetRestaurantById;
public class GetRestaurantByIdQuery(int id) : IRequest<RestaurantDto>
{
    public int Id { get; } = id;
}
