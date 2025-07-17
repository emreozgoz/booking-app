using MediatR;

namespace HouseBookingApp.Application.User.Command.ChangePassword;

public record ChangePasswordCommand(
    Guid UserId,
    string CurrentPassword,
    string NewPassword
) : IRequest<ChangePasswordResponse>;