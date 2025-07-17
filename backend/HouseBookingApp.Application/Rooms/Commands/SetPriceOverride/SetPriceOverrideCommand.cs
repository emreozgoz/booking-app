using HouseBookingApp.Domain.ValueObjects;
using MediatR;

namespace HouseBookingApp.Application.Rooms.Commands.SetPriceOverride;

public record SetPriceOverrideCommand(
    Guid RoomId,
    DateTime Date,
    Money Price
) : IRequest<Unit>;