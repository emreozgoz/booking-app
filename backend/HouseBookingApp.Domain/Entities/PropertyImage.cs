using HouseBookingApp.Domain.Common;

namespace HouseBookingApp.Domain.Entities;

public class PropertyImage : BaseEntity
{
    public Guid PropertyId { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string Alt { get; set; } = string.Empty;
    public bool IsMain { get; set; } = false;
    public int Order { get; set; } = 0;

    // Navigation properties
    public virtual Property Property { get; set; } = null!;

    public PropertyImage() { }

    public PropertyImage(Guid propertyId, string imageUrl, string alt = "", bool isMain = false, int order = 0)
    {
        if (propertyId == Guid.Empty)
            throw new ArgumentException("Property ID cannot be empty");

        if (string.IsNullOrWhiteSpace(imageUrl))
            throw new ArgumentException("Image URL cannot be empty");

        PropertyId = propertyId;
        ImageUrl = imageUrl;
        Alt = alt;
        IsMain = isMain;
        Order = order;
    }

    public void SetAsMain()
    {
        IsMain = true;
        UpdatedAt = DateTime.UtcNow;
    }

    public void RemoveAsMain()
    {
        IsMain = false;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateOrder(int newOrder)
    {
        Order = newOrder;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateDetails(string imageUrl, string alt)
    {
        if (string.IsNullOrWhiteSpace(imageUrl))
            throw new ArgumentException("Image URL cannot be empty");

        ImageUrl = imageUrl;
        Alt = alt;
        UpdatedAt = DateTime.UtcNow;
    }
}