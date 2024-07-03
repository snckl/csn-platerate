// Ignore Spelling: Validator

using FluentValidation;

namespace PlateRate.Application.Restaurants.Commands.CreateRestaurant;
public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
{
    public CreateRestaurantCommandValidator()
    {
        RuleFor(dto => dto.Name)
            .Length(3, 100);

        RuleFor(dto => dto.Description)
            .NotEmpty().WithMessage("Description is required.");

        RuleFor(dto => dto.Category)
            .NotEmpty().WithMessage("Provide a valid category.");

        RuleFor(dto => dto.ContactEmail)
            .EmailAddress().WithMessage("Please provide a valid email address.");

        RuleFor(dto => dto.ContactNumber)
            .Matches(@"^\{{10\}}$").WithMessage("Please provide a valid phone number.");

        RuleFor(dto => dto.PostalCode)
            .Matches(@"^\{{5\}}$").WithMessage("Please provide a valid postal code.");
    }
}
