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
    public DateTime? VerifiedAt { get; set; }
    public Guid? VerifiedBy { get; set; }

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
}