using AutoMapper;
using FluentAssertions;
using PlateRate.Domain.Entities;
using Xunit;

namespace PlateRate.Application.Restaurants.Dtos.Tests;

public class RestaurantsProfileTests
{
    [Fact()]
    public void CreateMap_ForRestaurantToRestaurantDto_MapsCorrectly()
    {
        // Arrange

        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<RestaurantsProfile>(); // will know everything in restaurantsProfile
        });

        var mapper = configuration.CreateMapper();

        var restaurant = new Restaurant()
        {
            Id = 1,
            Name = "Test",
            Description = "Test",
            Category = "Test",
            HasDelivery = true,
            ContactEmail = "Test@test.com",
            ContactNumber = "1234567890",
            Address = new Address()
            {
                City = "Test city",
                Street = "Test",
                PostalCode = "12345",

            }
        };

        // Act

        var restaurantDto = mapper.Map<RestaurantDto>(restaurant);

        // Assert

        restaurantDto.Should().NotBeNull();
        restaurant.Id.Should().Be(1);
        restaurant.Name.Should().Be("Test");
        restaurant.Description.Should().Be("Test");
        restaurant.HasDelivery.Should().BeTrue();
        restaurant.ContactNumber.Should().Be("1234567890");
        restaurant.ContactEmail.Should().Be("Test@test.com");
        restaurant.Address.City.Should().Be("Test city");
        restaurant.Address.Street.Should().Be("Test");
        restaurant.Address.PostalCode.Should().Be("12345");

    }
}