using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace PlateRate.Application.User;

public interface IUserContext
{
    public CurrentUser? GetCurrentUser();
}

public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public CurrentUser? GetCurrentUser()
    {
        var user = httpContextAccessor?.HttpContext?.User;

        if(user is null)
        {
            throw new InvalidOperationException("User context is not present");
        }

        if(user.Identity is null || !user.Identity.IsAuthenticated)
        {
            return null;
        }

        var userId = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        var userEmail = user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;
        var userRoles = user.Claims.Where(c => c.Type == ClaimTypes.Role)!.Select(c => c.Value);

        return new CurrentUser(userId, userEmail, userRoles);
    }
}
