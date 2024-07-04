using MediatR;
using PlateRate.Application.Restaurants.Dtos;

namespace PlateRate.Application.Dishes.Queries.GetDishById;
public class GetDishByIdQuery(int restaurantId,int dishId) : IRequest<DishDto>
{
   public int RestaurantId { get; set; } = restaurantId;
   public int DishId { get; set; } = dishId;
}
