using HouseBookingApp.Domain.Common;
using HouseBookingApp.Domain.ValueObjects;

namespace HouseBookingApp.Domain.Entities;

public class Room : BaseEntity
{
    public string Number { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public RoomType RoomType { get; set; } = new();
    public Money PricePerNight { get; set; } = new();
    public int MaxOccupancy { get; set; }
    public int Size { get; set; } // in square meters
    public bool IsActive { get; set; } = true;
    public bool IsRefundable { get; set; } = true;
    public Guid PropertyId { get; set; }

    // Navigation properties
    public virtual Property Property { get; set; } = null!;
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    public virtual ICollection<RoomAmenity> RoomAmenities { get; set; } = new List<RoomAmenity>();
    public virtual ICollection<RoomImage> Images { get; set; } = new List<RoomImage>();
    public virtual ICollection<RoomAvailability> Availabilities { get; set; } = new List<RoomAvailability>();
    public virtual ICollection<RoomPriceOverride> PriceOverrides { get; set; } = new List<RoomPriceOverride>();

    public Room() { }

    public Room(string number, string name, RoomType roomType, Money pricePerNight, int maxOccupancy, Guid propertyId)
    {
        if (string.IsNullOrWhiteSpace(number))
            throw new ArgumentException("Room number cannot be empty");

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Room name cannot be empty");

        if (maxOccupancy <= 0)
            throw new ArgumentException("Max occupancy must be positive");

        Number = number;
        Name = name;
        RoomType = roomType;
        PricePerNight = pricePerNight;
        MaxOccupancy = maxOccupancy;
        PropertyId = propertyId;
    }

    public bool IsAvailable(Period period)
    {
        if (!IsActive) return false;

        return !Reservations.Any(r => 
            r.IsActive() && 
            r.Period.OverlapsWith(period));
    }

    public Money CalculatePrice(Period period)
    {
        return PricePerNight * period.NumberOfNights;
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

    public void UpdatePrice(Money newPrice)
    {
        PricePerNight = newPrice;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateInfo(RoomType type, int capacity, Money price, bool isRefundable)
    {
        if (capacity <= 0)
            throw new ArgumentException("Capacity must be positive");

        if (price == null)
            throw new ArgumentNullException(nameof(price));

        RoomType = type;
        MaxOccupancy = capacity;
        PricePerNight = price;
        IsRefundable = isRefundable;
        UpdatedAt = DateTime.UtcNow;
    }

    public void AddAmenity(Amenity amenity)
    {
        if (amenity == null)
            throw new ArgumentNullException(nameof(amenity));

        if (RoomAmenities.Any(ra => ra.AmenityId == amenity.Id))
            throw new InvalidOperationException("Amenity already exists in this room");

        var roomAmenity = new RoomAmenity(Id, amenity.Id);
        RoomAmenities.Add(roomAmenity);
        UpdatedAt = DateTime.UtcNow;
    }

    public void RemoveAmenity(Guid amenityId)
    {
        var roomAmenity = RoomAmenities.FirstOrDefault(ra => ra.AmenityId == amenityId);
        if (roomAmenity != null)
        {
            RoomAmenities.Remove(roomAmenity);
            UpdatedAt = DateTime.UtcNow;
        }
    }

    public void AttachImage(RoomImage image)
    {
        if (image == null)
            throw new ArgumentNullException(nameof(image));

        if (Images.Any(i => i.Id == image.Id))
            throw new InvalidOperationException("Image already exists in this room");

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

    public void SetAvailability(DateTime date, bool isAvailable)
    {
        var availability = Availabilities.FirstOrDefault(a => a.Date.Date == date.Date);
        
        if (availability != null)
        {
            availability.SetAvailability(isAvailable);
        }
        else
        {
            var newAvailability = new RoomAvailability(Id, date, isAvailable);
            Availabilities.Add(newAvailability);
        }
        
        UpdatedAt = DateTime.UtcNow;
    }

    public void SetPriceOverride(DateTime date, Money price)
    {
        if (price == null)
            throw new ArgumentNullException(nameof(price));

        var priceOverride = PriceOverrides.FirstOrDefault(po => po.Date.Date == date.Date);
        
        if (priceOverride != null)
        {
            priceOverride.UpdatePrice(price);
        }
        else
        {
            var newPriceOverride = new RoomPriceOverride(Id, date, price);
            PriceOverrides.Add(newPriceOverride);
        }
        
        UpdatedAt = DateTime.UtcNow;
    }

    public Money GetPriceForDate(DateTime date)
    {
        var priceOverride = PriceOverrides.FirstOrDefault(po => po.Date.Date == date.Date);
        return priceOverride?.Price ?? PricePerNight;
    }

    public bool IsAvailableForDate(DateTime date)
    {
        var availability = Availabilities.FirstOrDefault(a => a.Date.Date == date.Date);
        return availability?.IsAvailable ?? true; // Default to available if no specific availability set
    }
}