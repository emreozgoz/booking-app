using HouseBookingApp.Domain.ValueObjects;

namespace HouseBookingApp.Domain.Events;

public record UserAccountDeactivatedDomainEvent(
    Guid UserId,
    Email Email
) : IDomainEvent;