using HouseBookingApp.Application.Common.Interfaces;
using HouseBookingApp.Domain.Entities;
using HouseBookingApp.Domain.ValueObjects;
using HouseBookingApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HouseBookingApp.Infrastructure.Repositories;

public class PropertyRepository : IPropertyRepository
{
    private readonly ApplicationDbContext _context;

    public PropertyRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Property?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Properties
            .Include(p => p.Rooms)
            .Include(p => p.Reviews)
            .Include(p => p.Images)
            .Include(p => p.Owner)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Property>> GetPropertiesAsync(
        int pageNumber,
        int pageSize,
        string? searchTerm = null,
        bool? isActive = null,
        Guid? ownerId = null,
        Location? location = null,
        PropertyType? propertyType = null,
        CancellationToken cancellationToken = default)
    {
        var query = _context.Properties
            .Include(p => p.Images)
            .Include(p => p.Owner)
            .AsQueryable();

        if (!string.IsNullOrEmpty(searchTerm))
        {
            query = query.Where(p => 
                p.Name.Contains(searchTerm) || 
                p.Description.Contains(searchTerm));
        }

        if (isActive.HasValue)
        {
            query = query.Where(p => p.IsActive == isActive.Value);
        }

        if (ownerId.HasValue)
        {
            query = query.Where(p => p.OwnerId == ownerId.Value);
        }

        if (location != null)
        {
            query = query.Where(p => 
                p.Location.City == location.City &&
                p.Location.Country == location.Country);
        }

        if (propertyType != null)
        {
            query = query.Where(p => p.PropertyType.Name == propertyType.Name);
        }

        return await query
            .OrderBy(p => p.Name)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }

    public async Task<int> GetPropertiesCountAsync(
        string? searchTerm = null,
        bool? isActive = null,
        Guid? ownerId = null,
        Location? location = null,
        PropertyType? propertyType = null,
        CancellationToken cancellationToken = default)
    {
        var query = _context.Properties.AsQueryable();

        if (!string.IsNullOrEmpty(searchTerm))
        {
            query = query.Where(p => 
                p.Name.Contains(searchTerm) || 
                p.Description.Contains(searchTerm));
        }

        if (isActive.HasValue)
        {
            query = query.Where(p => p.IsActive == isActive.Value);
        }

        if (ownerId.HasValue)
        {
            query = query.Where(p => p.OwnerId == ownerId.Value);
        }

        if (location != null)
        {
            query = query.Where(p => 
                p.Location.City == location.City &&
                p.Location.Country == location.Country);
        }

        if (propertyType != null)
        {
            query = query.Where(p => p.PropertyType.Name == propertyType.Name);
        }

        return await query.CountAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Property>> GetByOwnerAsync(Guid ownerId, CancellationToken cancellationToken = default)
    {
        return await _context.Properties
            .Include(p => p.Rooms)
            .Include(p => p.Reviews)
            .Include(p => p.Images)
            .Where(p => p.OwnerId == ownerId)
            .OrderBy(p => p.Name)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Property>> GetAvailablePropertiesAsync(
        Period period,
        Location? location = null,
        PropertyType? propertyType = null,
        CancellationToken cancellationToken = default)
    {
        var query = _context.Properties
            .Include(p => p.Rooms)
            .Include(p => p.Images)
            .Where(p => p.IsActive)
            .AsQueryable();

        if (location != null)
        {
            query = query.Where(p => 
                p.Location.City == location.City &&
                p.Location.Country == location.Country);
        }

        if (propertyType != null)
        {
            query = query.Where(p => p.PropertyType.Name == propertyType.Name);
        }

        return await query
            .Where(p => p.Rooms.Any(r => r.IsActive))
            .OrderBy(p => p.Name)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Property property, CancellationToken cancellationToken = default)
    {
        await _context.Properties.AddAsync(property, cancellationToken);
    }

    public Task UpdateAsync(Property property, CancellationToken cancellationToken = default)
    {
        _context.Properties.Update(property);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Property property, CancellationToken cancellationToken = default)
    {
        _context.Properties.Remove(property);
        return Task.CompletedTask;
    }
}