using HouseBookingApp.Application.Common.Interfaces;
using HouseBookingApp.Application.DTOs.Reviews;
using MediatR;

namespace HouseBookingApp.Application.Reviews.Queries.GetReviews;

public class GetReviewsQueryHandler : IRequestHandler<GetReviewsQuery, GetReviewsResponse>
{
    private readonly IReviewRepository _reviewRepository;

    public GetReviewsQueryHandler(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<GetReviewsResponse> Handle(GetReviewsQuery request, CancellationToken cancellationToken)
    {
        var reviews = await _reviewRepository.GetReviewsAsync(
            request.PageNumber,
            request.PageSize,
            request.PropertyId,
            request.GuestId,
            request.IsVerified,
            request.IsVisible,
            request.IsDeleted,
            request.IsInappropriate,
            request.MinRating,
            request.MaxRating,
            cancellationToken);

        var totalCount = await _reviewRepository.GetReviewsCountAsync(
            request.PropertyId,
            request.GuestId,
            request.IsVerified,
            request.IsVisible,
            request.IsDeleted,
            request.IsInappropriate,
            request.MinRating,
            request.MaxRating,
            cancellationToken);

        return new GetReviewsResponse
        {
            Reviews = reviews.Select(r => new ReviewSummaryDto
            {
                Id = r.Id,
                PropertyId = r.PropertyId,
                PropertyName = r.Property.Name,
                GuestId = r.GuestId,
                GuestName = $"{r.Guest.FirstName} {r.Guest.LastName}",
                Rating = r.Rating,
                Title = r.Title,
                Comment = r.Comment,
                IsVerified = r.IsVerified,
                IsVisible = r.IsVisible,
                CreatedAt = r.CreatedAt
            }).ToList(),
            TotalCount = totalCount,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize
        };
    }
}