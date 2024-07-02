namespace PlateRate.Application.Restaurants.Dtos;
public class DishDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int? KiloCalories { get; set; }
    public decimal Price { get; set; }
}
