using MediatR;
using PlateRate.Application.Common;
using PlateRate.Application.Restaurants.Dtos;
using PlateRate.Domain.Constants;

namespace PlateRate.Application.Restaurants.Queries.GetAllRestaurants;
public class GetAllRestaurantsQuery : IRequest<PageResult<RestaurantDto>>
{
    public string? SearchPhrase { get; set; }
    public int Page { get; set; } = 1;
    public int Count { get; set; } = 8;
    public string? SortBy  { get; set; }
    public SortDirection SortDirection { get; set; }
}
