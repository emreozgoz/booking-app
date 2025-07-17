using HouseBookingApp.Domain.ValueObjects;
using HouseBookingApp.Domain.Entities;

namespace HouseBookingApp.Application.DTOs.Rooms;

public class RoomDto
{
    public Guid Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public RoomType RoomType { get; set; } = new();
    public Money PricePerNight { get; set; } = new();
    public int MaxOccupancy { get; set; }
    public int Size { get; set; }
    public bool IsActive { get; set; }
    public bool IsRefundable { get; set; }
    public Guid PropertyId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<RoomImageDto> Images { get; set; } = new();
    public List<AmenityDto> Amenities { get; set; } = new();
    public List<RoomAvailabilityDto> Availabilities { get; set; } = new();
    public List<RoomPriceOverrideDto> PriceOverrides { get; set; } = new();
}

public class RoomSummaryDto
{
    public Guid Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public RoomType RoomType { get; set; } = new();
    public Money PricePerNight { get; set; } = new();
    public int MaxOccupancy { get; set; }
    public int Size { get; set; }
    public bool IsActive { get; set; }
    public bool IsRefundable { get; set; }
    public Guid PropertyId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public class RoomImageDto
{
    public Guid Id { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string Alt { get; set; } = string.Empty;
    public bool IsMain { get; set; }
    public int Order { get; set; }
}

public class AmenityDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public AmenityCategory Category { get; set; }
    public bool IsActive { get; set; }
}

public class RoomAvailabilityDto
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public bool IsAvailable { get; set; }
}

public class RoomPriceOverrideDto
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public Money Price { get; set; } = new();
}