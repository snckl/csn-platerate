using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using PlateRate.Domain.Entities;
using System.Security.Claims;

namespace PlateRate.Infrastructure.Authorization;
public class RestaurantUserClaimsPrincipleFactor(UserManager<User> userManager, RoleManager<IdentityRole> roleManager
    ,IOptions<IdentityOptions> options) : UserClaimsPrincipalFactory<User, IdentityRole>(userManager, roleManager, options)
{
    public override async Task<ClaimsPrincipal> CreateAsync(User user)
    {
        var id = await GenerateClaimsAsync(user);

        if (user.Nationality is not null) 
        {
            id.AddClaim(new Claim("Nationality",user.Nationality));
        }

        if(user.DateOfBirth is not null)
        {
            id.AddClaim(new Claim("DateOfBirth", user.DateOfBirth.Value.ToString("yyyy-MM-dd")!));
        }

        return new ClaimsPrincipal(id);
    }
}
