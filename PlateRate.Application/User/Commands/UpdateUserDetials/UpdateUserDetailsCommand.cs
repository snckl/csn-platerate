using MediatR;

namespace PlateRate.Application.User.Commands.UpdateUserDetials;
public class UpdateUserDetailsCommand : IRequest
{
    public DateOnly? DateOfBirth { get; set; } 
    public string? Nationality { get; set; }
}
