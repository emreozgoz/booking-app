using HouseBookingApp.Application.DTOs.Reviews;
using MediatR;

namespace HouseBookingApp.Application.Reviews.Queries.GetReviews;

public record GetReviewsQuery(
    int PageNumber = 1,
    int PageSize = 10,
    Guid? PropertyId = null,
    Guid? GuestId = null,
    bool? IsVerified = null,
    bool? IsVisible = null,
    bool? IsDeleted = null,
    bool? IsInappropriate = null,
    int? MinRating = null,
    int? MaxRating = null
) : IRequest<GetReviewsResponse>;

public class GetReviewsResponse
{
    public List<ReviewSummaryDto> Reviews { get; set; } = new();
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;
}