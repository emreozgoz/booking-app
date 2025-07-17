using HouseBookingApp.Application.Common.Interfaces;
using HouseBookingApp.Application.DTOs.Reviews;
using MediatR;

namespace HouseBookingApp.Application.Reviews.Commands.UpdateComment;

public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, ReviewDto>
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCommentCommandHandler(
        IReviewRepository reviewRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _reviewRepository = reviewRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ReviewDto> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var review = await _reviewRepository.GetByIdAsync(request.ReviewId, cancellationToken);
        
        if (review == null)
            throw new ArgumentException($"Review with ID {request.ReviewId} not found");

        review.UpdateComment(request.Comment);

        await _reviewRepository.UpdateAsync(review, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        // Get user information for response
        var user = await _userRepository.GetByIdAsync(review.GuestId, cancellationToken);

        return new ReviewDto
        {
            Id = review.Id,
            PropertyId = review.PropertyId,
            GuestId = review.GuestId,
            GuestName = user != null ? $"{user.FirstName} {user.LastName}" : "Unknown",
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