using HouseBookingApp.Application.DTOs.Reviews;
using MediatR;

namespace HouseBookingApp.Application.Reviews.Commands.LeaveReview;

public record LeaveReviewCommand(
    Guid UserId,
    Guid PropertyId,
    int Rating,
    string Comment
) : IRequest<ReviewDto>;