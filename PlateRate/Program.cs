using PlateRate.API.Middlewares;
using PlateRate.Application.Extensions;
using PlateRate.Domain.Entities;
using PlateRate.Infrastructure.Extensions;
using PlateRate.Infrastructure.Seeders;
using Microsoft.OpenApi.Models;
using Serilog;
using PlateRate.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
await seeder.Seed();


// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();   
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleWare>();
app.UseMiddleware<RequestTimeLoggingMiddleWare>();

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.MapGroup("api/identity").WithTags("Identity").MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

app.Run();
