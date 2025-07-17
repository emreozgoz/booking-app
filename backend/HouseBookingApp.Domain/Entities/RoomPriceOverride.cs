using HouseBookingApp.Domain.Common;
using HouseBookingApp.Domain.ValueObjects;

namespace HouseBookingApp.Domain.Entities;

public class RoomPriceOverride : BaseEntity
{
    public Guid RoomId { get; set; }
    public DateTime Date { get; set; }
    public Money Price { get; set; } = new();

    // Navigation properties
    public virtual Room Room { get; set; } = null!;

    public RoomPriceOverride() { }

    public RoomPriceOverride(Guid roomId, DateTime date, Money price)
    {
        if (roomId == Guid.Empty)
            throw new ArgumentException("Room ID cannot be empty");

        if (price == null)
            throw new ArgumentNullException(nameof(price));

        RoomId = roomId;
        Date = date.Date; // Only store date part
        Price = price;
    }

    public void UpdatePrice(Money newPrice)
    {
        if (newPrice == null)
            throw new ArgumentNullException(nameof(newPrice));

        Price = newPrice;
        UpdatedAt = DateTime.UtcNow;
    }
}