using HouseBookingApp.Domain.Entities;

namespace HouseBookingApp.Application.Common.Interfaces;

public interface IReviewRepository
{
    Task<Review?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Review>> GetReviewsAsync(
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
        CancellationToken cancellationToken = default);
    Task<int> GetReviewsCountAsync(
        Guid? propertyId = null,
        Guid? guestId = null,
        bool? isVerified = null,
        bool? isVisible = null,
        bool? isDeleted = null,
        bool? isInappropriate = null,
        int? minRating = null,
        int? maxRating = null,
        CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Review>> GetByPropertyAsync(Guid propertyId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Review>> GetByUserAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Review>> GetPendingReviewsAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Review>> GetInappropriateReviewsAsync(CancellationToken cancellationToken = default);
    Task<double> GetAverageRatingByPropertyAsync(Guid propertyId, CancellationToken cancellationToken = default);
    Task<bool> HasUserReviewedPropertyAsync(Guid userId, Guid propertyId, CancellationToken cancellationToken = default);
    Task AddAsync(Review review, CancellationToken cancellationToken = default);
    Task UpdateAsync(Review review, CancellationToken cancellationToken = default);
    Task DeleteAsync(Review review, CancellationToken cancellationToken = default);
}