using MediatR;

namespace HouseBookingApp.Application.Rooms.Commands.SetAvailability;

public record SetAvailabilityCommand(
    Guid RoomId,
    DateTime Date,
    bool IsAvailable
) : IRequest<Unit>;