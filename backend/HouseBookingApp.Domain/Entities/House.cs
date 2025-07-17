using HouseBookingApp.Domain.Common;
using HouseBookingApp.Domain.ValueObjects;

namespace HouseBookingApp.Domain.Entities;

public class House : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Location Location { get; set; } = new();
    public Money PricePerNight { get; set; } = new();
    public int MaxGuests { get; set; }
    public int Bedrooms { get; set; }
    public int Bathrooms { get; set; }
    public bool IsAvailable { get; set; } = true;
    public string ImageUrl { get; set; } = string.Empty;
    public Guid OwnerId { get; set; }

    // For backward compatibility
    public string Address 
    { 
        get => Location.FullAddress;
        set => Location = new Location(Location.City, Location.Country, value, Location.PostalCode, Location.GeoLocation);
    }

    public decimal PricePerNight_Decimal 
    { 
        get => PricePerNight.Amount;
        set => PricePerNight = new Money(value, PricePerNight.Currency);
    }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public House() { }

    public House(string title, string description, Location location, Money pricePerNight, int maxGuests, int bedrooms, int bathrooms, Guid ownerId)
    {
        Title = title;
        Description = description;
        Location = location;
        PricePerNight = pricePerNight;
        MaxGuests = maxGuests;
        Bedrooms = bedrooms;
        Bathrooms = bathrooms;
        OwnerId = ownerId;
        IsAvailable = true;
    }
}