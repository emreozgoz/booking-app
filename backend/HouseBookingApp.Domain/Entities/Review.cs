using HouseBookingApp.Domain.Common;

namespace HouseBookingApp.Domain.Entities;

public class Review : BaseEntity
{
    public Guid PropertyId { get; set; }
    public Guid GuestId { get; set; }
    public Guid? ReservationId { get; set; }
    public int Rating { get; set; } // 1-5 stars
    public string Title { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
    public bool IsVerified { get; set; } = false;
    public bool IsVisible { get; set; } = true;
    public bool IsDeleted { get; set; } = false;
    public bool IsInappropriate { get; set; } = false;
    public DateTime? VerifiedAt { get; set; }
    public Guid? VerifiedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? MarkedInappropriateAt { get; set; }

    // Navigation properties
    public virtual Property Property { get; set; } = null!;
    public virtual User Guest { get; set; } = null!;
    public virtual Reservation? Reservation { get; set; }

    public Review() { }

    public Review(Guid propertyId, Guid guestId, int rating, string title, string comment, Guid? reservationId = null)
    {
        if (rating < 1 || rating > 5)
            throw new ArgumentException("Rating must be between 1 and 5");

        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Review title cannot be empty");

        PropertyId = propertyId;
        GuestId = guestId;
        ReservationId = reservationId;
        Rating = rating;
        Title = title;
        Comment = comment;
        IsVerified = reservationId.HasValue; // Auto-verify if linked to reservation
        IsVisible = true;
    }

    public void Verify(Guid verifierId)
    {
        IsVerified = true;
        VerifiedAt = DateTime.UtcNow;
        VerifiedBy = verifierId;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Hide()
    {
        IsVisible = false;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Show()
    {
        IsVisible = true;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateRating(int newRating)
    {
        if (newRating < 1 || newRating > 5)
            throw new ArgumentException("Rating must be between 1 and 5");

        Rating = newRating;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateContent(string title, string comment)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Review title cannot be empty");

        Title = title;
        Comment = comment;
        UpdatedAt = DateTime.UtcNow;
    }

    public static Review Leave(Guid userId, Guid propertyId, int rating, string comment)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException("User ID cannot be empty");

        if (propertyId == Guid.Empty)
            throw new ArgumentException("Property ID cannot be empty");

        if (rating < 1 || rating > 5)
            throw new ArgumentException("Rating must be between 1 and 5");

        if (string.IsNullOrWhiteSpace(comment))
            throw new ArgumentException("Review comment cannot be empty");

        return new Review(propertyId, userId, rating, "Review", comment);
    }

    public void UpdateComment(string comment)
    {
        if (IsDeleted)
            throw new InvalidOperationException("Cannot update a deleted review");

        if (string.IsNullOrWhiteSpace(comment))
            throw new ArgumentException("Review comment cannot be empty");

        Comment = comment;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Delete()
    {
        if (IsDeleted)
            throw new InvalidOperationException("Review is already deleted");

        IsDeleted = true;
        IsVisible = false;
        DeletedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void MarkAsInappropriate()
    {
        if (IsDeleted)
            throw new InvalidOperationException("Cannot mark a deleted review as inappropriate");

        IsInappropriate = true;
        IsVisible = false;
        MarkedInappropriateAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Restore()
    {
        if (!IsDeleted)
            throw new InvalidOperationException("Review is not deleted");

        IsDeleted = false;
        IsVisible = true;
        DeletedAt = null;
        UpdatedAt = DateTime.UtcNow;
    }

    public void MarkAsAppropriate()
    {
        if (!IsInappropriate)
            throw new InvalidOperationException("Review is not marked as inappropriate");

        IsInappropriate = false;
        IsVisible = true;
        MarkedInappropriateAt = null;
        UpdatedAt = DateTime.UtcNow;
    }
}