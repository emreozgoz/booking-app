using HouseBookingApp.Domain.Common;

namespace HouseBookingApp.Domain.ValueObjects;

public record Email(string Value)
{
    public static Email Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new DomainException("Email cannot be empty");
        
        if (!IsValidEmail(email))
            throw new DomainException("Invalid email format");
        
        return new Email(email);
    }
    
    private static bool IsValidEmail(string email)
    {
        return System.Text.RegularExpressions.Regex.IsMatch(email, 
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }
    
    public static implicit operator string(Email email) => email.Value;
    public static implicit operator Email(string value) => Create(value);
}