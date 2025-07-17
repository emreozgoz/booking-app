using HouseBookingApp.Domain.Common;

namespace HouseBookingApp.Domain.Entities;

public class RoomImageV2 : BaseEntity
{
    public Guid RoomId { get; private set; }
    public Guid ImageId { get; private set; }

    // Navigation properties
    public virtual Room Room { get; set; } = null!;
    public virtual Image Image { get; set; } = null!;

    protected RoomImageV2() { }

    public RoomImageV2(Guid roomId, Guid imageId)
    {
        if (roomId == Guid.Empty)
            throw new ArgumentException("Room ID cannot be empty");

        if (imageId == Guid.Empty)
            throw new ArgumentException("Image ID cannot be empty");

        RoomId = roomId;
        ImageId = imageId;
    }
}