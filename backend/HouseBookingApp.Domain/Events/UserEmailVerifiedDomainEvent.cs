using HouseBookingApp.Domain.ValueObjects;

namespace HouseBookingApp.Domain.Events;

public record UserEmailVerifiedDomainEvent(
    Guid UserId,
    Email Email
) : IDomainEvent;