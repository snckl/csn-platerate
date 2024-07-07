using PlateRate.Domain.Entities;
using PlateRate.Infrastructure.Constants;

namespace PlateRate.Domain.Interfaces;
public interface IRestaurantAuthorizationService
{
    bool Authorize(Restaurant restaurant, ResourceOperation resourceOperation);
}