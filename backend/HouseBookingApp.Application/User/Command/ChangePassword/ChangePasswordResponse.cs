namespace HouseBookingApp.Application.User.Command.ChangePassword;

public record ChangePasswordResponse(
    bool IsChanged,
    string Message
);