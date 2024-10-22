﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlateRate.Application.User.Commands.AssignUserRole;
using PlateRate.Application.User.Commands.DeleteUserRole;
using PlateRate.Application.User.Commands.UpdateUserDetials;
using PlateRate.Domain.Constants;

namespace PlateRate.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IdentityController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [Authorize]
    public async  Task<IActionResult> UpdateUserDetails(UpdateUserDetailsCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }

    [HttpPost("assignRole")]
    [Authorize(Roles = UserRoles.Admin)] 
    public async Task<IActionResult> AssignUserRole(AssignUserRoleCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("unassignRole")]
    [Authorize(Roles = UserRoles.Admin)]
    public async Task<IActionResult> UnassignsUserRole(DeleteUserRoleCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }

}
