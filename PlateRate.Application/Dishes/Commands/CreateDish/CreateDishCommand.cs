using MediatR;

namespace PlateRate.Application.Dishes.Commands.CreateDish;
public class CreateDishCommand : IRequest<int>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int? KiloCalories { get; set; }
    public decimal Price { get; set; }
    public int RestaurantId { get; set; }
}
