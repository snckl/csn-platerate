using MediatR;

namespace PlateRate.Application.User.Commands.AssignUserRole;
public class AssignUserRoleCommand : IRequest
{
    public string UserEmail { get; set; } = default!;
    public string RoleName { get; set; } = default!;
}
