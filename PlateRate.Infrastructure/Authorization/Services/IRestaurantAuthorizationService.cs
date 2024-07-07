using PlateRate.Domain.Entities;

namespace PlateRate.Infrastructure.Authorization.Services;
public interface IRestaurantAuthorizationService
{
    bool Authorize(Restaurant restaurant, ResourceOperation resourceOperation);
}