using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlateRate.Infrastructure.Persistence;
using PlateRate.Infrastructure.Seeders;

namespace PlateRate.Infrastructure.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<PlateRateDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("PlateRateDb")));

        services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
    }
}
