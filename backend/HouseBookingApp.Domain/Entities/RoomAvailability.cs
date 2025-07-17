using HouseBookingApp.Domain.Common;

namespace HouseBookingApp.Domain.Entities;

public class RoomAvailability : BaseEntity
{
    public Guid RoomId { get; set; }
    public DateTime Date { get; set; }
    public bool IsAvailable { get; set; } = true;

    // Navigation properties
    public virtual Room Room { get; set; } = null!;

    public RoomAvailability() { }

    public RoomAvailability(Guid roomId, DateTime date, bool isAvailable = true)
    {
        if (roomId == Guid.Empty)
            throw new ArgumentException("Room ID cannot be empty");

        RoomId = roomId;
        Date = date.Date; // Only store date part
        IsAvailable = isAvailable;
    }

    public void SetAvailability(bool isAvailable)
    {
        IsAvailable = isAvailable;
        UpdatedAt = DateTime.UtcNow;
    }
}