using HouseBookingApp.Application.DTOs.Rooms;
using HouseBookingApp.Domain.ValueObjects;
using MediatR;

namespace HouseBookingApp.Application.Rooms.Commands.UpdateRoomInfo;

public record UpdateRoomInfoCommand(
    Guid Id,
    RoomType Type,
    int Capacity,
    Money Price,
    bool IsRefundable
) : IRequest<RoomDto>;