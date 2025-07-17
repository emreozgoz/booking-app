using HouseBookingApp.Application.DTOs.Reviews;
using MediatR;

namespace HouseBookingApp.Application.Reviews.Commands.UpdateComment;

public record UpdateCommentCommand(
    Guid ReviewId,
    string Comment
) : IRequest<ReviewDto>;