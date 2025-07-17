using HouseBookingApp.Domain.ValueObjects;

namespace HouseBookingApp.Domain.Events;

public record UserProfileUpdatedDomainEvent(
    Guid UserId,
    string FirstName,
    string LastName
) : IDomainEvent;