using HouseBookingApp.Domain.ValueObjects;

namespace HouseBookingApp.Application.User.Command.Login;

public record LoginUserResponse(
    UserId Id,
    string Email,
    string FirstName,
    string LastName,
    string Token,
    DateTime ExpiresAt,
    string Message
);