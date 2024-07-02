using PlateRate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateRate.Application.Restaurants.Dtos;
public class CreateRestaurantDto
{
    [StringLength(100,MinimumLength = 3)]
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Category { get; set; } = default!;
    public bool HasDelivery { get; set; }
    [EmailAddress(ErrorMessage = "Please provide a valid email address.")]
    public string? ContactEmail { get; set; }
    [Phone(ErrorMessage = "Please provide a valid phone number.")]
    public string? ContactNumber { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    [RegularExpression(@"\d{5}", ErrorMessage = "Please provide a valid postal code (XX-XXX).")]
    public string? PostalCode { get; set; }
}
