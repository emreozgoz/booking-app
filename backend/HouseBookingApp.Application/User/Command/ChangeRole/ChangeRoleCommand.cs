using HouseBookingApp.Domain.Enums;
using MediatR;

namespace HouseBookingApp.Application.User.Command.ChangeRole;

public record ChangeRoleCommand(
    Guid UserId,
    UserRole NewRole
) : IRequest<ChangeRoleResponse>;