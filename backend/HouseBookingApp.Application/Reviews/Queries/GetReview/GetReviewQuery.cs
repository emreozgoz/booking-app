using HouseBookingApp.Application.DTOs.Reviews;
using MediatR;

namespace HouseBookingApp.Application.Reviews.Queries.GetReview;

public record GetReviewQuery(Guid Id) : IRequest<ReviewDto>;