namespace HouseBookingApp.Application.User.Command.UpdateProfile;

public record UpdateProfileResponse(
    bool IsUpdated,
    string Message
);