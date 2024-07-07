using FluentValidation.TestHelper;
using Xunit;

namespace PlateRate.Application.Restaurants.Commands.CreateRestaurant.Tests;

public class CreateRestaurantCommandValidatorTests
{
    [Fact()]
    public void Validator_ForValidCommand_ShouldNotHaveValidationErrors()
    {
        // Arrange

        var command = new CreateRestaurantCommand()
        {
            Name = "test",
            Description = "test",
            Category = "test",
            ContactEmail = "test@test.com",
            PostalCode = "12345",
        };

        var validator = new CreateRestaurantCommandValidator();

        // Act

        var result = validator.TestValidate(command);

        // Assert

        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact()]
    public void Validator_ForInvalidCommand_ShouldHaveValidationErrors()
    {
        // Arrange

        var command = new CreateRestaurantCommand()
        {
            Name = "tt",
            ContactEmail = "@testcom",
            PostalCode = "1234",
        };

        var validator = new CreateRestaurantCommandValidator();

        // Act

        var result = validator.TestValidate(command);

        // Assert

        result.ShouldHaveValidationErrorFor(c => c.Name);
        result.ShouldHaveValidationErrorFor(c => c.Description);
        result.ShouldHaveValidationErrorFor(c => c.Category);
        result.ShouldHaveValidationErrorFor(c => c.ContactEmail);
        result.ShouldHaveValidationErrorFor(c => c.PostalCode);
    }
}