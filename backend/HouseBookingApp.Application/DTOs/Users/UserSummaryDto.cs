namespace HouseBookingApp.Application.DTOs.Users;

public record UserSummaryDto(
    Guid Id,
    string Email,
    string FullName,
    string Role,
    bool IsActive
);