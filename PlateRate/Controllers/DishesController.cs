using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlateRate.Application.Dishes.Commands.CreateDish;
using PlateRate.Application.Dishes.Queries.GetAllDishes;
using PlateRate.Application.Restaurants.Dtos;
using PlateRate.Application.Restaurants.Queries.GetAllRestaurants;

namespace PlateRate.API.Controllers;

[ApiController]
[Route("api/restaurants/{restaurantId}/[controller]")]
public class DishesController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateDish([FromRoute]int restaurantId,CreateDishCommand command)
    {
        command.RestaurantId = restaurantId;
        var id = await mediator.Send(command);
        return Created();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DishDto>>> GetAll([FromRoute] int restaurantId)
    {
        var dishes = await mediator.Send(new GetAllDishesQuery(restaurantId));
        return Ok(dishes);
    }
}
