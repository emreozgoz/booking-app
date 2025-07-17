namespace HouseBookingApp.Application.User.Command.Register;

public record RegisterUserResponse(
    Guid UserId,
    string Email,
    string VerificationToken,
    string Message
);