using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlateRate.Application.Dishes.Commands.CreateDish;
using PlateRate.Application.Dishes.Commands.DeleteDishes;
using PlateRate.Application.Dishes.Queries.GetAllDishes;
using PlateRate.Application.Dishes.Queries.GetDishById;
using PlateRate.Application.Restaurants.Dtos;
using PlateRate.Application.Restaurants.Queries.GetAllRestaurants;

namespace PlateRate.API.Controllers;

[ApiController]
[Route("api/restaurants/{restaurantId}/[controller]")]
public class DishesController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateDish([FromRoute]int restaurantId,CreateDishCommand command)
    {
        command.RestaurantId = restaurantId;
        var id = await mediator.Send(command);
        return Created();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<DishDto>>> GetAll([FromRoute] int restaurantId)
    {
        var dishes = await mediator.Send(new GetAllDishesQuery(restaurantId));
        return Ok(dishes);
    }

    [HttpGet("{dishId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DishDto>> GetDishById([FromRoute] int restaurantId, [FromRoute] int dishId)
    {
        var dish = await mediator.Send(new GetDishByIdQuery(restaurantId,dishId));
        return Ok(dish);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteDishes([FromRoute] int restaurantId)
    {
        await mediator.Send(new DeleteDishesCommand(restaurantId));
        return NoContent();
    }
}
