namespace HouseBookingApp.Domain.ValueObjects;

public record Location
{
    public string City { get; init; } = string.Empty;
    public string Country { get; init; } = string.Empty;
    public string Address { get; init; } = string.Empty;
    public string PostalCode { get; init; } = string.Empty;
    public GeoLocation GeoLocation { get; init; } = new();

    public Location() { }

    public Location(string city, string country, string address, string postalCode, GeoLocation geoLocation)
    {
        City = city;
        Country = country;
        Address = address;
        PostalCode = postalCode;
        GeoLocation = geoLocation;
    }

    public string FullAddress => $"{Address}, {City}, {Country} {PostalCode}";
}

public record GeoLocation
{
    public double Latitude { get; init; }
    public double Longitude { get; init; }

    public GeoLocation() { }

    public GeoLocation(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    public bool IsEmpty => Latitude == 0 && Longitude == 0;
}