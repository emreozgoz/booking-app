using MediatR;

namespace HouseBookingApp.Application.User.Command.Login;

public record LoginUserCommand(
    string Email,
    string Password
) : IRequest<LoginUserResponse>;