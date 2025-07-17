namespace HouseBookingApp.Domain.ValueObjects;

public record PropertyType
{
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public PropertyCategory Category { get; init; }

    public PropertyType() { }

    public PropertyType(string name, string description, PropertyCategory category)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Property type name cannot be empty");

        Name = name;
        Description = description;
        Category = category;
    }

    public static PropertyType Hotel => new("Hotel", "Traditional hotel accommodation", PropertyCategory.Hotel);
    public static PropertyType Apartment => new("Apartment", "Private apartment", PropertyCategory.Apartment);
    public static PropertyType House => new("House", "Entire house", PropertyCategory.House);
    public static PropertyType Villa => new("Villa", "Luxury villa", PropertyCategory.House);
    public static PropertyType Resort => new("Resort", "Resort accommodation", PropertyCategory.Resort);
    public static PropertyType Hostel => new("Hostel", "Budget hostel", PropertyCategory.Hostel);
    public static PropertyType BedAndBreakfast => new("Bed & Breakfast", "Bed and breakfast", PropertyCategory.BedAndBreakfast);
    public static PropertyType Guesthouse => new("Guesthouse", "Guesthouse accommodation", PropertyCategory.Guesthouse);

    public override string ToString() => Name;
}

public enum PropertyCategory
{
    Hotel = 1,
    Apartment = 2,
    House = 3,
    Resort = 4,
    Hostel = 5,
    BedAndBreakfast = 6,
    Guesthouse = 7,
    Villa = 8,
    Cabin = 9
}