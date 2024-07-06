using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using PlateRate.Domain.Exceptions;

namespace PlateRate.Application.User.Commands.AssignUserRole;
public class AssignUserRoleCommandHandler(ILogger<AssignUserRoleCommandHandler> logger
    ,UserManager<Domain.Entities.User> userManager,RoleManager<IdentityRole> roleManager) : IRequestHandler<AssignUserRoleCommand>
{
    public async Task Handle(AssignUserRoleCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Assigning user role: {@Request}",request);

        var user = await userManager.FindByEmailAsync(request.UserEmail) 
            ?? throw new NotFoundException(nameof(User), request.UserEmail);

        var role = await roleManager.FindByNameAsync(request.RoleName) 
            ?? throw new NotFoundException(nameof(IdentityRole), request.RoleName);

        await userManager.AddToRoleAsync(user,role.Name!);

    }
}
