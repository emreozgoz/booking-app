namespace HouseBookingApp.Application.DTOs.Auth;

public record AuthResponseDto(
    string Token,
    DateTime ExpiresAt,
    UserDto User
);

public record UserDto(
    Guid Id,
    string Email,
    string FirstName,
    string LastName,
    string Role,
    bool IsEmailVerified
);