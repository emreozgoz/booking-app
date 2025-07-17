namespace HouseBookingApp.Domain.ValueObjects;

public record UserId(Guid Value)
{
    public static UserId Create() => new(Guid.NewGuid());
    public static UserId Create(Guid value) => new(value);
    
    public static implicit operator Guid(UserId userId) => userId.Value;
    public static implicit operator UserId(Guid value) => new(value);
}