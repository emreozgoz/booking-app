using MediatR;

namespace HouseBookingApp.Application.User.Command.Register;

public record RegisterUserCommand(
    string Email,
    string Password,
    string FirstName,
    string LastName
) : IRequest<RegisterUserResponse>;