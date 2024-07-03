// Ignore Spelling: Validator

using FluentValidation;

namespace PlateRate.Application.Restaurants.Commands.UpdateRestaurant;
public class UpdateRestaurantCommandValidator : AbstractValidator<UpdateRestaurantCommand>
{
    public UpdateRestaurantCommandValidator()
    {
        RuleFor(dto => dto.Name)
             .Length(3, 100);

        RuleFor(dto => dto.Description)
            .NotEmpty().WithMessage("Description is required.");
    }
}
