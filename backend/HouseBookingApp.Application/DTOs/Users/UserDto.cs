namespace HouseBookingApp.Application.DTOs.Users;

public record UserDto(
    Guid Id,
    string Email,
    string FirstName,
    string LastName,
    string Role,
    bool IsEmailVerified,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? LastLoginAt
);