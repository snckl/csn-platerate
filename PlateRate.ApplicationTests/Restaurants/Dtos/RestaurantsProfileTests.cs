using AutoMapper;
using FluentAssertions;
using PlateRate.Application.Restaurants.Commands.CreateRestaurant;
using PlateRate.Domain.Entities;
using Xunit;

namespace PlateRate.Application.Restaurants.Dtos.Tests;

public class RestaurantsProfileTests
{

    private readonly IMapper _mapper;

    public RestaurantsProfileTests()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<RestaurantsProfile>(); // will know everything in restaurantsProfile
        });

        _mapper = configuration.CreateMapper();
    }


    [Fact()]
    public void CreateMap_ForRestaurantToRestaurantDto_MapsCorrectly()
    {
        // Arrange

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

        var restaurantDto = _mapper.Map<RestaurantDto>(restaurant);

        // Assert

        restaurantDto.Should().NotBeNull();
        restaurantDto.Id.Should().Be(1);
        restaurantDto.Name.Should().Be("Test");
        restaurantDto.Description.Should().Be("Test");
        restaurantDto.HasDelivery.Should().BeTrue();
        restaurantDto.City.Should().Be("Test city");
        restaurantDto.Street.Should().Be("Test");
        restaurantDto.PostalCode.Should().Be("12345");

    }

    [Fact()]
    public void CreateMap_ForRestaurantCommandToRestaurant_MapsCorrectly()
    {
        // Arrange

        var commdand = new CreateRestaurantCommand()
        {
            Name = "Test",
            Description = "Test",
            Category = "Test",
            HasDelivery = true,
            ContactEmail = "Test@test.com",
            ContactNumber = "1234567890",
            City = "Test city",
            Street = "Test",
            PostalCode = "12345"
        };

        // Act

        var restaurant = _mapper.Map<Restaurant>(commdand);

        // Assert

        restaurant.Should().NotBeNull();
        restaurant.Name.Should().Be(commdand.Name);
        restaurant.Description.Should().Be(commdand.Description);
        restaurant.HasDelivery.Should().BeTrue();
        restaurant.ContactNumber.Should().Be(commdand.ContactNumber);
        restaurant.ContactEmail.Should().Be(commdand.ContactEmail);
        restaurant.Address.City.Should().Be(commdand.City);
        restaurant.Address.Street.Should().Be(commdand.Street);
        restaurant.Address.PostalCode.Should().Be(commdand.PostalCode);

    }
}