using HouseBookingApp.Domain.ValueObjects;

namespace HouseBookingApp.Domain.Events;

public record UserAccountDeactivatedDomainEvent(
    UserId UserId,
    Email Email
) : IDomainEvent;