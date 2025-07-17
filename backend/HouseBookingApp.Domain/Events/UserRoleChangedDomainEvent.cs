using HouseBookingApp.Domain.Enums;
using HouseBookingApp.Domain.ValueObjects;

namespace HouseBookingApp.Domain.Events;

public record UserRoleChangedDomainEvent(
    Guid UserId,
    UserRole OldRole,
    UserRole NewRole
) : IDomainEvent;