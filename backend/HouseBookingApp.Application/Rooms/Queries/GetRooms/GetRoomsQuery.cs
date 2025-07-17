using HouseBookingApp.Application.DTOs.Rooms;
using HouseBookingApp.Domain.ValueObjects;
using MediatR;

namespace HouseBookingApp.Application.Rooms.Queries.GetRooms;

public record GetRoomsQuery(
    int PageNumber = 1,
    int PageSize = 10,
    string? SearchTerm = null,
    bool? IsActive = null,
    Guid? PropertyId = null,
    RoomType? RoomType = null
) : IRequest<GetRoomsResponse>;

public class GetRoomsResponse
{
    public List<RoomSummaryDto> Rooms { get; set; } = new();
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;
}