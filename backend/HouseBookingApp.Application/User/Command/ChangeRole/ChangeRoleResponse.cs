namespace HouseBookingApp.Application.User.Command.ChangeRole;

public record ChangeRoleResponse(
    bool IsChanged,
    string Message
);