using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlateRate.Application.Restaurants;
using PlateRate.Application.Restaurants.Commands.CreateRestaurant;
using PlateRate.Application.Restaurants.Commands.DeleteRestaurant;
using PlateRate.Application.Restaurants.Commands.UpdateRestaurant;
using PlateRate.Application.Restaurants.Dtos;
using PlateRate.Application.Restaurants.Queries.GetAllRestaurants;
using PlateRate.Application.Restaurants.Queries.GetRestaurantById;

namespace PlateRate.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RestaurantDto>>> GetAll()
    {
        var restaurants = await mediator.Send(new GetAllRestaurantsQuery());
        return Ok(restaurants);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<RestaurantDto?>> GetById([FromRoute] int id)
    {
        var restaurant = await mediator.Send(new GetRestaurantByIdQuery(id));
        if(restaurant is null)
        {
            return NotFound();
        }
        return Ok(restaurant);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand command)
    {
        int id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new {id},null);
    }

    [HttpPatch("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateRestaurant([FromRoute] int id,[FromBody] UpdateRestaurantCommand command)
    {
        command.Id = id;
        bool isUpdated = await mediator.Send(command);

        if (isUpdated)
        {
            return NoContent();
        }

        return NotFound();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
    {
        var isDeleted = await mediator.Send(new DeleteRestaurantCommand(id));

        if (isDeleted)
        {
            return NoContent();
        }

        return NotFound();
    }
}
