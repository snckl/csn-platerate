    using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlateRate.Application.Restaurants.Commands.CreateRestaurant;
using PlateRate.Application.Restaurants.Commands.DeleteRestaurant;
using PlateRate.Application.Restaurants.Commands.UpdateRestaurant;
using PlateRate.Application.Restaurants.Dtos;
using PlateRate.Application.Restaurants.Queries.GetAllRestaurants;
using PlateRate.Application.Restaurants.Queries.GetRestaurantById;
using PlateRate.Domain.Constants;
using PlateRate.Infrastructure.Extensions;

namespace PlateRate.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class RestaurantsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<RestaurantDto>>> GetAll([FromQuery] GetAllRestaurantsQuery query)
    {
        var restaurants = await mediator.Send(query);
        return Ok(restaurants);
    }

    [HttpGet("{id:int}")]
    [AllowAnonymous]
    public async Task<ActionResult<RestaurantDto?>> GetById([FromRoute] int id)
    {
        var restaurant = await mediator.Send(new GetRestaurantByIdQuery(id));
        return Ok(restaurant);
    }

    [HttpPost]
    [Authorize(Roles = UserRoles.Owner,Policy = PolicyNames.HasNationality)]
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
        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
    {
        await mediator.Send(new DeleteRestaurantCommand(id));
        return NoContent();
    }
}
