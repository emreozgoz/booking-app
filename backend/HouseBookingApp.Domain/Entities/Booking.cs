using HouseBookingApp.Domain.Common;
using HouseBookingApp.Domain.Enums;
using HouseBookingApp.Domain.ValueObjects;

namespace HouseBookingApp.Domain.Entities;

public class Booking : BaseEntity
{
    public Guid HouseId { get; set; }
    public Guid UserId { get; set; }
    public Period Period { get; set; } = new();
    public int NumberOfGuests { get; set; }
    public Money TotalAmount { get; set; } = new();
    public BookingStatus Status { get; set; } = BookingStatus.Pending;
    public string? SpecialRequests { get; set; }

    // For backward compatibility
    public DateTime CheckInDate 
    { 
        get => Period.CheckInDate;
        set => Period = new Period(value, Period.CheckOutDate);
    }
    
    public DateTime CheckOutDate 
    { 
        get => Period.CheckOutDate;
        set => Period = new Period(Period.CheckInDate, value);
    }

    public virtual House House { get; set; } = null!;
    public virtual User User { get; set; } = null!;

    public Booking() { }

    public Booking(Guid houseId, Guid userId, Period period, int numberOfGuests, Money totalAmount)
    {
        HouseId = houseId;
        UserId = userId;
        Period = period;
        NumberOfGuests = numberOfGuests;
        TotalAmount = totalAmount;
        Status = BookingStatus.Pending;
    }
}