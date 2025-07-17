namespace HouseBookingApp.Application.User.Command.DeactivateAccount;

public record DeactivateAccountResponse(
    bool IsDeactivated,
    string Message
);