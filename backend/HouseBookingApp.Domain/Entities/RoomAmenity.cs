using HouseBookingApp.Domain.Common;

namespace HouseBookingApp.Domain.Entities;

public class RoomAmenity : BaseEntity
{
    public Guid RoomId { get; set; }
    public Guid AmenityId { get; set; }

    // Navigation properties
    public virtual Room Room { get; set; } = null!;
    public virtual Amenity Amenity { get; set; } = null!;

    public RoomAmenity() { }

    public RoomAmenity(Guid roomId, Guid amenityId)
    {
        if (roomId == Guid.Empty)
            throw new ArgumentException("Room ID cannot be empty");

        if (amenityId == Guid.Empty)
            throw new ArgumentException("Amenity ID cannot be empty");

        RoomId = roomId;
        AmenityId = amenityId;
    }
}