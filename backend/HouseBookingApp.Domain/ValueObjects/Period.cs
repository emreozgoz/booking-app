namespace HouseBookingApp.Domain.ValueObjects;

public record Period
{
    public DateTime CheckInDate { get; init; }
    public DateTime CheckOutDate { get; init; }

    public Period() { }

    public Period(DateTime checkInDate, DateTime checkOutDate)
    {
        if (checkInDate >= checkOutDate)
            throw new ArgumentException("Check-in date must be before check-out date");

        CheckInDate = checkInDate;
        CheckOutDate = checkOutDate;
    }

    public int NumberOfNights => (CheckOutDate - CheckInDate).Days;
    public TimeSpan Duration => CheckOutDate - CheckInDate;
    public bool IsValid => CheckInDate < CheckOutDate && CheckInDate >= DateTime.Today;

    public bool OverlapsWith(Period other)
    {
        return CheckInDate < other.CheckOutDate && CheckOutDate > other.CheckInDate;
    }

    public bool Contains(DateTime date)
    {
        return date >= CheckInDate && date < CheckOutDate;
    }
}