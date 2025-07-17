using HouseBookingApp.Domain.ValueObjects;

namespace HouseBookingApp.Domain.Events;

public record UserEmailVerifiedDomainEvent(
    UserId UserId,
    Email Email
) : IDomainEvent;