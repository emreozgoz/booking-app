using HouseBookingApp.Application.DTOs.Rooms;
using MediatR;

namespace HouseBookingApp.Application.Rooms.Queries.GetRoom;

public record GetRoomQuery(Guid Id) : IRequest<RoomDto>;