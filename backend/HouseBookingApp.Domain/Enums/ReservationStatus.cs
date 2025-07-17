namespace HouseBookingApp.Domain.Enums;

public enum ReservationStatus
{
    Pending = 1,
    Confirmed = 2,
    CheckedIn = 3,
    CheckedOut = 4,
    Cancelled = 5,
    NoShow = 6,
    Refunded = 7
}

public static class ReservationStatusExtensions
{
    public static string GetDisplayName(this ReservationStatus status)
    {
        return status switch
        {
            ReservationStatus.Pending => "Pending",
            ReservationStatus.Confirmed => "Confirmed",
            ReservationStatus.CheckedIn => "Checked In",
            ReservationStatus.CheckedOut => "Checked Out",
            ReservationStatus.Cancelled => "Cancelled",
            ReservationStatus.NoShow => "No Show",
            ReservationStatus.Refunded => "Refunded",
            _ => status.ToString()
        };
    }

    public static bool CanBeCancelled(this ReservationStatus status)
    {
        return status is ReservationStatus.Pending or ReservationStatus.Confirmed;
    }

    public static bool IsActive(this ReservationStatus status)
    {
        return status is ReservationStatus.Pending or ReservationStatus.Confirmed or ReservationStatus.CheckedIn;
    }

    public static bool IsCompleted(this ReservationStatus status)
    {
        return status is ReservationStatus.CheckedOut or ReservationStatus.Cancelled or ReservationStatus.NoShow or ReservationStatus.Refunded;
    }
}