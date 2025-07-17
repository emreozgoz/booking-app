using HouseBookingApp.Domain.Common;

namespace HouseBookingApp.Domain.Entities;

public class PropertyImageV2 : BaseEntity
{
    public Guid PropertyId { get; private set; }
    public Guid ImageId { get; private set; }

    // Navigation properties
    public virtual Property Property { get; set; } = null!;
    public virtual Image Image { get; set; } = null!;

    protected PropertyImageV2() { }

    public PropertyImageV2(Guid propertyId, Guid imageId)
    {
        if (propertyId == Guid.Empty)
            throw new ArgumentException("Property ID cannot be empty");

        if (imageId == Guid.Empty)
            throw new ArgumentException("Image ID cannot be empty");

        PropertyId = propertyId;
        ImageId = imageId;
    }
}