using HouseBookingApp.Application.Common.Interfaces;
using HouseBookingApp.Domain.Entities;
using HouseBookingApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HouseBookingApp.Infrastructure.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly ApplicationDbContext _context;

    public ReviewRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Review?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Reviews
            .Include(r => r.Property)
            .Include(r => r.Guest)
            .Include(r => r.Reservation)
            .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Review>> GetReviewsAsync(
        int pageNumber,
        int pageSize,
        Guid? propertyId = null,
        Guid? guestId = null,
        bool? isVerified = null,
        bool? isVisible = null,
        bool? isDeleted = null,
        bool? isInappropriate = null,
        int? minRating = null,
        int? maxRating = null,
        CancellationToken cancellationToken = default)
    {
        var query = _context.Reviews
            .Include(r => r.Property)
            .Include(r => r.Guest)
            .AsQueryable();

        if (propertyId.HasValue)
        {
            query = query.Where(r => r.PropertyId == propertyId.Value);
        }

        if (guestId.HasValue)
        {
            query = query.Where(r => r.GuestId == guestId.Value);
        }

        if (isVerified.HasValue)
        {
            query = query.Where(r => r.IsVerified == isVerified.Value);
        }

        if (isVisible.HasValue)
        {
            query = query.Where(r => r.IsVisible == isVisible.Value);
        }

        if (isDeleted.HasValue)
        {
            query = query.Where(r => r.IsDeleted == isDeleted.Value);
        }

        if (isInappropriate.HasValue)
        {
            query = query.Where(r => r.IsInappropriate == isInappropriate.Value);
        }

        if (minRating.HasValue)
        {
            query = query.Where(r => r.Rating >= minRating.Value);
        }

        if (maxRating.HasValue)
        {
            query = query.Where(r => r.Rating <= maxRating.Value);
        }

        return await query
            .OrderByDescending(r => r.CreatedAt)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }

    public async Task<int> GetReviewsCountAsync(
        Guid? propertyId = null,
        Guid? guestId = null,
        bool? isVerified = null,
        bool? isVisible = null,
        bool? isDeleted = null,
        bool? isInappropriate = null,
        int? minRating = null,
        int? maxRating = null,
        CancellationToken cancellationToken = default)
    {
        var query = _context.Reviews.AsQueryable();

        if (propertyId.HasValue)
        {
            query = query.Where(r => r.PropertyId == propertyId.Value);
        }

        if (guestId.HasValue)
        {
            query = query.Where(r => r.GuestId == guestId.Value);
        }

        if (isVerified.HasValue)
        {
            query = query.Where(r => r.IsVerified == isVerified.Value);
        }

        if (isVisible.HasValue)
        {
            query = query.Where(r => r.IsVisible == isVisible.Value);
        }

        if (isDeleted.HasValue)
        {
            query = query.Where(r => r.IsDeleted == isDeleted.Value);
        }

        if (isInappropriate.HasValue)
        {
            query = query.Where(r => r.IsInappropriate == isInappropriate.Value);
        }

        if (minRating.HasValue)
        {
            query = query.Where(r => r.Rating >= minRating.Value);
        }

        if (maxRating.HasValue)
        {
            query = query.Where(r => r.Rating <= maxRating.Value);
        }

        return await query.CountAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Review>> GetByPropertyAsync(Guid propertyId, CancellationToken cancellationToken = default)
    {
        return await _context.Reviews
            .Include(r => r.Guest)
            .Where(r => r.PropertyId == propertyId && r.IsVisible && !r.IsDeleted)
            .OrderByDescending(r => r.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Review>> GetByUserAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await _context.Reviews
            .Include(r => r.Property)
            .Where(r => r.GuestId == userId && !r.IsDeleted)
            .OrderByDescending(r => r.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Review>> GetPendingReviewsAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Reviews
            .Include(r => r.Property)
            .Include(r => r.Guest)
            .Where(r => !r.IsVerified && !r.IsDeleted)
            .OrderBy(r => r.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Review>> GetInappropriateReviewsAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Reviews
            .Include(r => r.Property)
            .Include(r => r.Guest)
            .Where(r => r.IsInappropriate && !r.IsDeleted)
            .OrderByDescending(r => r.MarkedInappropriateAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<double> GetAverageRatingByPropertyAsync(Guid propertyId, CancellationToken cancellationToken = default)
    {
        var reviews = await _context.Reviews
            .Where(r => r.PropertyId == propertyId && r.IsVisible && !r.IsDeleted)
            .ToListAsync(cancellationToken);

        return reviews.Count > 0 ? reviews.Average(r => r.Rating) : 0.0;
    }

    public async Task<bool> HasUserReviewedPropertyAsync(Guid userId, Guid propertyId, CancellationToken cancellationToken = default)
    {
        return await _context.Reviews
            .AnyAsync(r => r.GuestId == userId && r.PropertyId == propertyId && !r.IsDeleted, cancellationToken);
    }

    public async Task AddAsync(Review review, CancellationToken cancellationToken = default)
    {
        await _context.Reviews.AddAsync(review, cancellationToken);
    }

    public Task UpdateAsync(Review review, CancellationToken cancellationToken = default)
    {
        _context.Reviews.Update(review);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Review review, CancellationToken cancellationToken = default)
    {
        _context.Reviews.Remove(review);
        return Task.CompletedTask;
    }
}