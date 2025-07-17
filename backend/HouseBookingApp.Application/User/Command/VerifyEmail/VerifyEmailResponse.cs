namespace HouseBookingApp.Application.User.Command.VerifyEmail;

public record VerifyEmailResponse(
    bool IsVerified,
    string Message
);