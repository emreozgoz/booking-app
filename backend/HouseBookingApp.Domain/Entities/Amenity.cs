using HouseBookingApp.Domain.Common;

namespace HouseBookingApp.Domain.Entities;

public class Amenity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public AmenityCategory Category { get; set; }
    public bool IsActive { get; set; } = true;

    public Amenity() { }

    public Amenity(string name, string description, string icon, AmenityCategory category)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Amenity name cannot be empty");

        Name = name;
        Description = description;
        Icon = icon;
        Category = category;
    }

    public void Update(string name, string description, string icon, AmenityCategory category)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Amenity name cannot be empty");

        Name = name;
        Description = description;
        Icon = icon;
        Category = category;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Activate()
    {
        IsActive = true;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        IsActive = false;
        UpdatedAt = DateTime.UtcNow;
    }
}

public enum AmenityCategory
{
    Basic = 1,
    Comfort = 2,
    Technology = 3,
    Bathroom = 4,
    Kitchen = 5,
    Entertainment = 6,
    Safety = 7,
    Accessibility = 8
}