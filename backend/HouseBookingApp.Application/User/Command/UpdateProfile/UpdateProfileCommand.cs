using MediatR;

namespace HouseBookingApp.Application.User.Command.UpdateProfile;

public record UpdateProfileCommand(
    Guid UserId,
    string FirstName,
    string LastName
) : IRequest<UpdateProfileResponse>;