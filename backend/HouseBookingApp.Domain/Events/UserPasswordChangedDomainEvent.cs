using HouseBookingApp.Domain.ValueObjects;

namespace HouseBookingApp.Domain.Events;

public record UserPasswordChangedDomainEvent(
    UserId UserId,
    Email Email
) : IDomainEvent;