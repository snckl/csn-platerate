using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlateRate.Application.User.Commands.UpdateUserDetials;

namespace PlateRate.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class IdentityController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async  Task<IActionResult> UpdateUserDetails(UpdateUserDetailsCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }
}
