using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlateRate.Application.Common;
using PlateRate.Application.Restaurants.Dtos;

namespace PlateRate.Application.Restaurants.Queries.GetAllRestaurants;
public class GetAllRestaurantsQuery : IRequest<PageResult<RestaurantDto>>
{
    public string? SearchPhrase { get; set; }
    public int Page { get; set; }
    public int Count { get; set; }
}
