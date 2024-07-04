
using MediatR;

namespace PlateRate.Application.Dishes.Commands.DeleteDishes;
public class DeleteDishesCommand(int restaurantId) : IRequest
{
    public int RestaurantId { get; set; } = restaurantId;
}
