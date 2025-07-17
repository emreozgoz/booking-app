using MediatR;

namespace HouseBookingApp.Application.User.Command.DeactivateAccount;

public record DeactivateAccountCommand(
    Guid UserId
) : IRequest<DeactivateAccountResponse>;