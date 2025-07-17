using HouseBookingApp.Application.Common.Interfaces;
using HouseBookingApp.Application.DTOs.Rooms;
using MediatR;

namespace HouseBookingApp.Application.Rooms.Queries.GetRooms;

public class GetRoomsQueryHandler : IRequestHandler<GetRoomsQuery, GetRoomsResponse>
{
    private readonly IRoomRepository _roomRepository;

    public GetRoomsQueryHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<GetRoomsResponse> Handle(GetRoomsQuery request, CancellationToken cancellationToken)
    {
        var rooms = await _roomRepository.GetRoomsAsync(
            request.PageNumber,
            request.PageSize,
            request.SearchTerm,
            request.IsActive,
            request.PropertyId,
            request.RoomType,
            cancellationToken);

        var totalCount = await _roomRepository.GetRoomsCountAsync(
            request.SearchTerm,
            request.IsActive,
            request.PropertyId,
            request.RoomType,
            cancellationToken);

        return new GetRoomsResponse
        {
            Rooms = rooms.Select(r => new RoomSummaryDto
            {
                Id = r.Id,
                Number = r.Number,
                Name = r.Name,
                Description = r.Description,
                RoomType = r.RoomType,
                PricePerNight = r.PricePerNight,
                MaxOccupancy = r.MaxOccupancy,
                Size = r.Size,
                IsActive = r.IsActive,
                IsRefundable = r.IsRefundable,
                PropertyId = r.PropertyId,
                CreatedAt = r.CreatedAt,
                UpdatedAt = r.UpdatedAt
            }).ToList(),
            TotalCount = totalCount,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize
        };
    }
}