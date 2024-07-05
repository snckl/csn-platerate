namespace PlateRate.Application.User;
public record CurrentUser(string Id,string Email, IEnumerable<string> Roles)
{
    public bool IsInRole(string RoleName) => Roles.Contains(RoleName);
}
