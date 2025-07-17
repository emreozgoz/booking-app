using HouseBookingApp.Domain.ValueObjects;

namespace HouseBookingApp.Domain.Events;

public record UserRegisteredDomainEvent(
    Guid UserId,
    Email Email,
    string VerificationToken
) : IDomainEvent;