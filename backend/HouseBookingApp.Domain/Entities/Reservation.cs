using HouseBookingApp.Domain.Common;
using HouseBookingApp.Domain.ValueObjects;
using HouseBookingApp.Domain.Enums;

namespace HouseBookingApp.Domain.Entities;

public class Reservation : BaseEntity
{
    public string ReservationNumber { get; set; } = string.Empty;
    public Guid PropertyId { get; set; }
    public Guid RoomId { get; set; }
    public Guid GuestId { get; set; }
    public Period Period { get; set; } = new();
    public int NumberOfGuests { get; set; }
    public Money TotalAmount { get; set; } = new();
    public ReservationStatus Status { get; set; } = ReservationStatus.Pending;
    public string? SpecialRequests { get; set; }
    public DateTime? CheckInTime { get; set; }
    public DateTime? CheckOutTime { get; set; }
    public string? CancellationReason { get; set; }
    public DateTime? CancellationDate { get; set; }

    // Navigation properties
    public virtual Property Property { get; set; } = null!;
    public virtual Room Room { get; set; } = null!;
    public virtual User Guest { get; set; } = null!;
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public Reservation() { }

    public Reservation(Guid propertyId, Guid roomId, Guid guestId, Period period, int numberOfGuests, Money totalAmount)
    {
        if (numberOfGuests <= 0)
            throw new ArgumentException("Number of guests must be positive");

        if (!period.IsValid)
            throw new ArgumentException("Invalid reservation period");

        ReservationNumber = GenerateReservationNumber();
        PropertyId = propertyId;
        RoomId = roomId;
        GuestId = guestId;
        Period = period;
        NumberOfGuests = numberOfGuests;
        TotalAmount = totalAmount;
        Status = ReservationStatus.Pending;
    }

    public bool IsActive()
    {
        return Status.IsActive();
    }

    public bool CanBeCancelled()
    {
        return Status.CanBeCancelled();
    }

    public void Confirm()
    {
        if (Status != ReservationStatus.Pending)
            throw new InvalidOperationException("Only pending reservations can be confirmed");

        Status = ReservationStatus.Confirmed;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Cancel(string reason)
    {
        if (!CanBeCancelled())
            throw new InvalidOperationException("Reservation cannot be cancelled");

        Status = ReservationStatus.Cancelled;
        CancellationReason = reason;
        CancellationDate = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void CheckIn()
    {
        if (Status != ReservationStatus.Confirmed)
            throw new InvalidOperationException("Only confirmed reservations can be checked in");

        if (DateTime.Now.Date < Period.CheckInDate.Date)
            throw new InvalidOperationException("Cannot check in before check-in date");

        Status = ReservationStatus.CheckedIn;
        CheckInTime = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void CheckOut()
    {
        if (Status != ReservationStatus.CheckedIn)
            throw new InvalidOperationException("Only checked-in reservations can be checked out");

        Status = ReservationStatus.CheckedOut;
        CheckOutTime = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void MarkAsNoShow()
    {
        if (Status != ReservationStatus.Confirmed)
            throw new InvalidOperationException("Only confirmed reservations can be marked as no-show");

        if (DateTime.Now.Date <= Period.CheckInDate.Date)
            throw new InvalidOperationException("Cannot mark as no-show before check-in date");

        Status = ReservationStatus.NoShow;
        UpdatedAt = DateTime.UtcNow;
    }

    public Money GetTotalPaidAmount()
    {
        return Payments
            .Where(p => p.IsSuccessful())
            .Aggregate(Money.Zero(TotalAmount.Currency), (total, payment) => total + payment.Amount);
    }

    public Money GetRemainingAmount()
    {
        return TotalAmount - GetTotalPaidAmount();
    }

    public bool IsFullyPaid()
    {
        return GetRemainingAmount().IsZero;
    }

    private static string GenerateReservationNumber()
    {
        return $"RES{DateTime.UtcNow:yyyyMMdd}{DateTime.UtcNow.Ticks % 10000:D4}";
    }
}