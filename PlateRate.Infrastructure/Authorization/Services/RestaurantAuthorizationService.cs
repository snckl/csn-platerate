using Microsoft.Extensions.Logging;
using PlateRate.Application.User;
using PlateRate.Domain.Constants;
using PlateRate.Domain.Entities;

namespace PlateRate.Infrastructure.Authorization.Services;
public class RestaurantAuthorizationService(ILogger<RestaurantAuthorizationService> logger
    , IUserContext userContext) : IRestaurantAuthorizationService
{
    public bool Authorize(Restaurant restaurant, ResourceOperation resourceOperation)
    {
        var user = userContext.GetCurrentUser()!;

        logger.LogInformation("Authorizing user {UserEmail}, to {Operation} for restaurant {RestaurantName}"
            , user.Email, resourceOperation, restaurant.Name);

        if (resourceOperation == ResourceOperation.Read || resourceOperation == ResourceOperation.Create)
        {
            logger.LogInformation("Create/Read operation - successful authorization");
            return true;
        }

        if ((resourceOperation == ResourceOperation.Delete || resourceOperation == ResourceOperation.Update) && user.IsInRole(UserRoles.Admin))
        {
            logger.LogInformation("Admin user, delete-update operation - successful authorization");
            return true;
        }

        if ((resourceOperation == ResourceOperation.Delete || resourceOperation == ResourceOperation.Update) && user.Id == restaurant.OwnerId)
        {
            logger.LogInformation("Restaurant owner - successful authorization");
            return true;
        }

        return false;
    }
}
