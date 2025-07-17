using HouseBookingApp.Domain.Common;
using HouseBookingApp.Domain.ValueObjects;

namespace HouseBookingApp.Domain.Entities;

public class Property : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public PropertyType PropertyType { get; set; } = new();
    public Location Location { get; set; } = new();
    public Guid OwnerId { get; set; }
    public bool IsActive { get; set; } = true;
    public string ImageUrl { get; set; } = string.Empty;
    public double Rating { get; set; } = 0.0;
    public int ReviewCount { get; set; } = 0;

    // Navigation properties
    public virtual User Owner { get; set; } = null!;
    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    public virtual ICollection<PropertyImage> Images { get; set; } = new List<PropertyImage>();

    public Property() { }

    public Property(string name, string description, PropertyType propertyType, Location location, Guid ownerId)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Property name cannot be empty");

        Name = name;
        Description = description;
        PropertyType = propertyType;
        Location = location;
        OwnerId = ownerId;
    }

    public bool HasAvailableRooms(Period period)
    {
        return Rooms.Any(room => room.IsAvailable(period));
    }

    public IEnumerable<Room> GetAvailableRooms(Period period)
    {
        return Rooms.Where(room => room.IsAvailable(period));
    }

    public void UpdateRating()
    {
        if (Reviews.Count == 0)
        {
            Rating = 0.0;
            ReviewCount = 0;
            return;
        }

        Rating = Reviews.Average(r => r.Rating);
        ReviewCount = Reviews.Count;
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

    public static Property Create(string name, Location location, string description, PropertyType type, Guid ownerId)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Property name cannot be empty");
        
        if (ownerId == Guid.Empty)
            throw new ArgumentException("Owner ID cannot be empty");

        return new Property(name, description, type, location, ownerId);
    }

    public void UpdateDetails(string name, string description, Location location, PropertyType type)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Property name cannot be empty");

        Name = name;
        Description = description;
        Location = location;
        PropertyType = type;
        UpdatedAt = DateTime.UtcNow;
    }

    public void AddRoom(Room room)
    {
        if (room == null)
            throw new ArgumentNullException(nameof(room));

        if (Rooms.Any(r => r.Id == room.Id))
            throw new InvalidOperationException("Room already exists in this property");

        Rooms.Add(room);
        UpdatedAt = DateTime.UtcNow;
    }

    public void RemoveRoom(Guid roomId)
    {
        var room = Rooms.FirstOrDefault(r => r.Id == roomId);
        if (room != null)
        {
            Rooms.Remove(room);
            UpdatedAt = DateTime.UtcNow;
        }
    }

    public void AttachImage(PropertyImage image)
    {
        if (image == null)
            throw new ArgumentNullException(nameof(image));

        if (Images.Any(i => i.Id == image.Id))
            throw new InvalidOperationException("Image already exists in this property");

        Images.Add(image);
        UpdatedAt = DateTime.UtcNow;
    }

    public void RemoveImage(Guid imageId)
    {
        var image = Images.FirstOrDefault(i => i.Id == imageId);
        if (image != null)
        {
            Images.Remove(image);
            UpdatedAt = DateTime.UtcNow;
        }
    }

    public void AddReview(Review review)
    {
        if (review == null)
            throw new ArgumentNullException(nameof(review));

        if (Reviews.Any(r => r.Id == review.Id))
            throw new InvalidOperationException("Review already exists for this property");

        Reviews.Add(review);
        UpdateRating();
        UpdatedAt = DateTime.UtcNow;
    }
}