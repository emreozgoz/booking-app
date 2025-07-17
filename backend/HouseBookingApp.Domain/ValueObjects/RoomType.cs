namespace HouseBookingApp.Domain.ValueObjects;

public record RoomType
{
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public int MaxOccupancy { get; init; }

    public RoomType() { }

    public RoomType(string name, string description, int maxOccupancy)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Room type name cannot be empty");
        
        if (maxOccupancy <= 0)
            throw new ArgumentException("Max occupancy must be positive");

        Name = name;
        Description = description;
        MaxOccupancy = maxOccupancy;
    }

    public static RoomType Single => new("Single", "Single bed room", 1);
    public static RoomType Double => new("Double", "Double bed room", 2);
    public static RoomType Twin => new("Twin", "Twin beds room", 2);
    public static RoomType Triple => new("Triple", "Triple bed room", 3);
    public static RoomType Quad => new("Quad", "Quad bed room", 4);
    public static RoomType Suite => new("Suite", "Luxury suite", 4);
    public static RoomType Family => new("Family", "Family room", 6);

    public override string ToString() => Name;
}