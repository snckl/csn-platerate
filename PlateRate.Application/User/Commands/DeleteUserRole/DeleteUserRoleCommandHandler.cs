using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using PlateRate.Domain.Exceptions;

namespace PlateRate.Application.User.Commands.DeleteUserRole;
public class DeleteUserRoleCommandHandler(ILogger<DeleteUserRoleCommandHandler> logger
    , UserManager<Domain.Entities.User> userManager, RoleManager<IdentityRole> roleManager) : IRequestHandler<DeleteUserRoleCommand>
{
    public async Task Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Unassigning user role: {@Request}",request);
        var user = await userManager.FindByEmailAsync(request.UserEmail) 
            ?? throw new NotFoundException(nameof(User),request.UserEmail);
        var role = await roleManager.FindByNameAsync(request.RoleName)
            ?? throw new NotFoundException(nameof(IdentityRole), request.RoleName);

        await userManager.RemoveFromRoleAsync(user,role.Name!);
    }
}
