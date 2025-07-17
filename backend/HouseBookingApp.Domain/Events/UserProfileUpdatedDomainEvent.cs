using HouseBookingApp.Domain.ValueObjects;

namespace HouseBookingApp.Domain.Events;

public record UserProfileUpdatedDomainEvent(
    UserId UserId,
    string FirstName,
    string LastName
) : IDomainEvent;