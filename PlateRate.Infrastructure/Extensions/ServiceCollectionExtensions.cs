using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlateRate.Domain.Entities;
using PlateRate.Domain.Repositories;
using PlateRate.Infrastructure.Authorization;
using PlateRate.Infrastructure.Persistence;
using PlateRate.Infrastructure.Repositories;
using PlateRate.Infrastructure.Seeders;

namespace PlateRate.Infrastructure.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<PlateRateDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("PlateRateDb")).EnableSensitiveDataLogging());
        
        services.AddIdentityApiEndpoints<User>()
            .AddRoles<IdentityRole>()
            .AddClaimsPrincipalFactory<RestaurantUserClaimsPrincipleFactor>()
            .AddEntityFrameworkStores<PlateRateDbContext>();
        services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
        services.AddScoped<IRestaurantRepository, RestaurantsRepository>();
        services.AddScoped<IDishRepository, DishesRepository>();
    }
}
