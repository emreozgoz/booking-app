using HouseBookingApp.Application.Common.Interfaces;
using HouseBookingApp.Domain.Entities;
using HouseBookingApp.Domain.ValueObjects;
using HouseBookingApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HouseBookingApp.Infrastructure.Repositories;

public class RoomRepository : IRoomRepository
{
    private readonly ApplicationDbContext _context;

    public RoomRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Room?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Rooms
            .Include(r => r.Property)
            .Include(r => r.Images)
            .Include(r => r.RoomAmenities)
                .ThenInclude(ra => ra.Amenity)
            .Include(r => r.Availabilities)
            .Include(r => r.PriceOverrides)
            .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Room>> GetRoomsAsync(
        int pageNumber,
        int pageSize,
        string? searchTerm = null,
        bool? isActive = null,
        Guid? propertyId = null,
        RoomType? roomType = null,
        CancellationToken cancellationToken = default)
    {
        var query = _context.Rooms
            .Include(r => r.Property)
            .Include(r => r.Images)
            .AsQueryable();

        if (!string.IsNullOrEmpty(searchTerm))
        {
            query = query.Where(r => 
                r.Name.Contains(searchTerm) || 
                r.Description.Contains(searchTerm) ||
                r.Number.Contains(searchTerm));
        }

        if (isActive.HasValue)
        {
            query = query.Where(r => r.IsActive == isActive.Value);
        }

        if (propertyId.HasValue)
        {
            query = query.Where(r => r.PropertyId == propertyId.Value);
        }

        if (roomType != null)
        {
            query = query.Where(r => r.RoomType.Name == roomType.Name);
        }

        return await query
            .OrderBy(r => r.Number)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }

    public async Task<int> GetRoomsCountAsync(
        string? searchTerm = null,
        bool? isActive = null,
        Guid? propertyId = null,
        RoomType? roomType = null,
        CancellationToken cancellationToken = default)
    {
        var query = _context.Rooms.AsQueryable();

        if (!string.IsNullOrEmpty(searchTerm))
        {
            query = query.Where(r => 
                r.Name.Contains(searchTerm) || 
                r.Description.Contains(searchTerm) ||
                r.Number.Contains(searchTerm));
        }

        if (isActive.HasValue)
        {
            query = query.Where(r => r.IsActive == isActive.Value);
        }

        if (propertyId.HasValue)
        {
            query = query.Where(r => r.PropertyId == propertyId.Value);
        }

        if (roomType != null)
        {
            query = query.Where(r => r.RoomType.Name == roomType.Name);
        }

        return await query.CountAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Room>> GetByPropertyAsync(Guid propertyId, CancellationToken cancellationToken = default)
    {
        return await _context.Rooms
            .Include(r => r.Images)
            .Include(r => r.RoomAmenities)
                .ThenInclude(ra => ra.Amenity)
            .Where(r => r.PropertyId == propertyId)
            .OrderBy(r => r.Number)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Room>> GetAvailableRoomsAsync(
        Period period,
        Guid? propertyId = null,
        RoomType? roomType = null,
        int? maxOccupancy = null,
        CancellationToken cancellationToken = default)
    {
        var query = _context.Rooms
            .Include(r => r.Property)
            .Include(r => r.Images)
            .Where(r => r.IsActive)
            .AsQueryable();

        if (propertyId.HasValue)
        {
            query = query.Where(r => r.PropertyId == propertyId.Value);
        }

        if (roomType != null)
        {
            query = query.Where(r => r.RoomType.Name == roomType.Name);
        }

        if (maxOccupancy.HasValue)
        {
            query = query.Where(r => r.MaxOccupancy >= maxOccupancy.Value);
        }

        return await query
            .Where(r => r.IsAvailable(period))
            .OrderBy(r => r.Number)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Room room, CancellationToken cancellationToken = default)
    {
        await _context.Rooms.AddAsync(room, cancellationToken);
    }

    public Task UpdateAsync(Room room, CancellationToken cancellationToken = default)
    {
        _context.Rooms.Update(room);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Room room, CancellationToken cancellationToken = default)
    {
        _context.Rooms.Remove(room);
        return Task.CompletedTask;
    }
}