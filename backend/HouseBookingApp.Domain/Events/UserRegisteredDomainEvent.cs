using HouseBookingApp.Domain.ValueObjects;

namespace HouseBookingApp.Domain.Events;

public record UserRegisteredDomainEvent(
    UserId UserId,
    Email Email,
    string VerificationToken
) : IDomainEvent;