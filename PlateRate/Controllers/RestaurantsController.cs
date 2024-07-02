using Microsoft.AspNetCore.Mvc;
using PlateRate.Application.Restaurants;
using PlateRate.Domain.Repositories;

namespace PlateRate.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantsController(IRestaurantsService restaurantsService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var restaurants = await restaurantsService.GetAllRestaurants();
        return Ok(restaurants);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var restaurant = await restaurantsService.GetByIdAsync(id);
        if(restaurant is null)
        {
            return NotFound();
        }
        return Ok(restaurant);
    }
}
