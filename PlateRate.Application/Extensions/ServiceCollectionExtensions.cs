using Microsoft.Extensions.DependencyInjection;
using PlateRate.Application.Restaurants;

namespace PlateRate.Application.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRestaurantsService,RestaurantsService>();
        services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);
    }
}
