using HouseBookingApp.Domain.ValueObjects;

namespace HouseBookingApp.Domain.Events;

public record UserPasswordChangedDomainEvent(
    Guid UserId,
    Email Email
) : IDomainEvent;