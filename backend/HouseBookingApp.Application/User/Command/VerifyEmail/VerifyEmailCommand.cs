using MediatR;

namespace HouseBookingApp.Application.User.Command.VerifyEmail;

public record VerifyEmailCommand(
    Guid UserId,
    string VerificationToken
) : IRequest<VerifyEmailResponse>;