using HouseBookingApp.Application.Common.Interfaces;
using HouseBookingApp.Application.DTOs.Reviews;
using MediatR;

namespace HouseBookingApp.Application.Reviews.Queries.GetReview;

public class GetReviewQueryHandler : IRequestHandler<GetReviewQuery, ReviewDto>
{
    private readonly IReviewRepository _reviewRepository;

    public GetReviewQueryHandler(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<ReviewDto> Handle(GetReviewQuery request, CancellationToken cancellationToken)
    {
        var review = await _reviewRepository.GetByIdAsync(request.Id, cancellationToken);
        
        if (review == null)
            throw new ArgumentException($"Review with ID {request.Id} not found");

        return new ReviewDto
        {
            Id = review.Id,
            PropertyId = review.PropertyId,
            GuestId = review.GuestId,
            GuestName = $"{review.Guest.FirstName} {review.Guest.LastName}",
            ReservationId = review.ReservationId,
            Rating = review.Rating,
            Title = review.Title,
            Comment = review.Comment,
            IsVerified = review.IsVerified,
            IsVisible = review.IsVisible,
            IsDeleted = review.IsDeleted,
            IsInappropriate = review.IsInappropriate,
            VerifiedAt = review.VerifiedAt,
            VerifiedBy = review.VerifiedBy,
            DeletedAt = review.DeletedAt,
            MarkedInappropriateAt = review.MarkedInappropriateAt,
            CreatedAt = review.CreatedAt,
            UpdatedAt = review.UpdatedAt
        };
    }
}