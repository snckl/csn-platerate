// Ignore Spelling: Validator

using FluentValidation;
using PlateRate.Application.Common;
using PlateRate.Domain.Entities;

namespace PlateRate.Application.Restaurants.Queries.GetAllRestaurants;
public class GetAllRestaurantsQueryValidator : AbstractValidator<GetAllRestaurantsQuery>
{
    private int[] allowedPageSizes = [8,16,32];
    private string[] allowedSortByColumnNames = [nameof(Restaurant.Name), nameof(Restaurant.Description), nameof(Restaurant.Category)];

    public GetAllRestaurantsQueryValidator()
    {
        RuleFor(r => r.Page)
            .GreaterThan(0);

        RuleFor(r => r.Count)
            .Must(value => allowedPageSizes.Contains(value))
            .WithMessage($"Page size must be one of [{string.Join(",",allowedPageSizes)}]");

        RuleFor(r => r.SortBy)
        .Must(value => allowedSortByColumnNames.Contains(value))
        .When(q => q.SortBy != null)
        .WithMessage($"SortBy is optional, or must be in: [{string.Join(",", allowedSortByColumnNames)}]");
    }
}
