using HouseBookingApp.Application.Common.Interfaces;
using HouseBookingApp.Application.DTOs.Reviews;
using HouseBookingApp.Domain.Entities;
using MediatR;

namespace HouseBookingApp.Application.Reviews.Commands.LeaveReview;

public class LeaveReviewCommandHandler : IRequestHandler<LeaveReviewCommand, ReviewDto>
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public LeaveReviewCommandHandler(
        IReviewRepository reviewRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _reviewRepository = reviewRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ReviewDto> Handle(LeaveReviewCommand request, CancellationToken cancellationToken)
    {
        // Check if user has already reviewed this property
        var hasReviewed = await _reviewRepository.HasUserReviewedPropertyAsync(
            request.UserId, request.PropertyId, cancellationToken);

        if (hasReviewed)
            throw new InvalidOperationException("User has already reviewed this property");

        var review = Review.Leave(
            request.UserId,
            request.PropertyId,
            request.Rating,
            request.Comment);

        await _reviewRepository.AddAsync(review, cancellationToken);
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