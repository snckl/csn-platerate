using PlateRate.API.Middlewares;
using PlateRate.Application.Extensions;
using PlateRate.Infrastructure.Extensions;
using PlateRate.Infrastructure.Seeders;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Host.UseSerilog((context,configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
});
builder.Services.AddScoped<ErrorHandlingMiddleware>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
