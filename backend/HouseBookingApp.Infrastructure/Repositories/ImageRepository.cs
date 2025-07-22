using HouseBookingApp.Application.Common.Interfaces;
using HouseBookingApp.Domain.Entities;
using HouseBookingApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HouseBookingApp.Infrastructure.Repositories;

public class ImageRepository : IImageRepository
{
    private readonly ApplicationDbContext _context;

    public ImageRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Image?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Images
            .FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Image>> GetImagesAsync(
        int pageNumber,
        int pageSize,
        bool? isPrimary = null,
        bool? isMarkedForDeletion = null,
        CancellationToken cancellationToken = default)
    {
        var query = _context.Images.AsQueryable();

        if (isPrimary.HasValue)
        {
            query = query.Where(i => i.IsPrimary == isPrimary.Value);
        }

        if (isMarkedForDeletion.HasValue)
        {
            query = query.Where(i => i.IsMarkedForDeletion == isMarkedForDeletion.Value);
        }

        return await query
            .OrderBy(i => i.Order)
            .ThenBy(i => i.CreatedAt)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }

    public async Task<int> GetImagesCountAsync(
        bool? isPrimary = null,
        bool? isMarkedForDeletion = null,
        CancellationToken cancellationToken = default)
    {
        var query = _context.Images.AsQueryable();

        if (isPrimary.HasValue)
        {
            query = query.Where(i => i.IsPrimary == isPrimary.Value);
        }

        if (isMarkedForDeletion.HasValue)
        {
            query = query.Where(i => i.IsMarkedForDeletion == isMarkedForDeletion.Value);
        }

        return await query.CountAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Image>> GetByPropertyAsync(Guid propertyId, CancellationToken cancellationToken = default)
    {
        // Simple implementation - return empty list for now since we removed V2 entities
        return new List<Image>();
    }

    public async Task<IReadOnlyList<Image>> GetByRoomAsync(Guid roomId, CancellationToken cancellationToken = default)
    {
        // Simple implementation - return empty list for now since we removed V2 entities
        return new List<Image>();
    }

    public async Task<IReadOnlyList<Image>> GetMarkedForDeletionAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Images
            .Where(i => i.IsMarkedForDeletion)
            .OrderBy(i => i.MarkedForDeletionAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<Image?> GetPrimaryImageByPropertyAsync(Guid propertyId, CancellationToken cancellationToken = default)
    {
        // Simple implementation - return null for now since we removed V2 entities
        return null;
    }

    public async Task<Image?> GetPrimaryImageByRoomAsync(Guid roomId, CancellationToken cancellationToken = default)
    {
        // Simple implementation - return null for now since we removed V2 entities
        return null;
    }

    public async Task AddAsync(Image image, CancellationToken cancellationToken = default)
    {
        await _context.Images.AddAsync(image, cancellationToken);
    }

    public Task UpdateAsync(Image image, CancellationToken cancellationToken = default)
    {
        _context.Images.Update(image);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Image image, CancellationToken cancellationToken = default)
    {
        _context.Images.Remove(image);
        return Task.CompletedTask;
    }
}