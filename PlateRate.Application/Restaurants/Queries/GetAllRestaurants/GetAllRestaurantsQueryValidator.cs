// Ignore Spelling: Validator

using FluentValidation;

namespace PlateRate.Application.Restaurants.Queries.GetAllRestaurants;
public class GetAllRestaurantsQueryValidator : AbstractValidator<GetAllRestaurantsQuery>
{
    private int[] allowedPageSizes = [8,16,32];

    public GetAllRestaurantsQueryValidator()
    {
        RuleFor(r => r.Page)
            .GreaterThan(0);

        RuleFor(r => r.Count)
            .Must(value => allowedPageSizes.Contains(value))
            .WithMessage($"Page size must be one of [{string.Join(",",allowedPageSizes)}]");
    }
}
