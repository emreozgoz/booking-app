using MediatR;

namespace HouseBookingApp.Application.Reviews.Commands.DeleteReview;

public record DeleteReviewCommand(Guid ReviewId) : IRequest<Unit>;