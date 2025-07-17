using HouseBookingApp.Domain.Entities;
using HouseBookingApp.Domain.ValueObjects;

namespace HouseBookingApp.Application.Common.Interfaces;

public interface IRoomRepository
{
    Task<Room?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Room>> GetRoomsAsync(
        int pageNumber,
        int pageSize,
        string? searchTerm = null,
        bool? isActive = null,
        Guid? propertyId = null,
        RoomType? roomType = null,
        CancellationToken cancellationToken = default);
    Task<int> GetRoomsCountAsync(
        string? searchTerm = null,
        bool? isActive = null,
        Guid? propertyId = null,
        RoomType? roomType = null,
        CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Room>> GetByPropertyAsync(Guid propertyId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Room>> GetAvailableRoomsAsync(
        Period period,
        Guid? propertyId = null,
        RoomType? roomType = null,
        int? maxOccupancy = null,
        CancellationToken cancellationToken = default);
    Task AddAsync(Room room, CancellationToken cancellationToken = default);
    Task UpdateAsync(Room room, CancellationToken cancellationToken = default);
    Task DeleteAsync(Room room, CancellationToken cancellationToken = default);
}