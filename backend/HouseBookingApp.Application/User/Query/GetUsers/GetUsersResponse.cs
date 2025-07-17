using HouseBookingApp.Application.DTOs.Users;

namespace HouseBookingApp.Application.User.Query.GetUsers;

public record GetUsersResponse(
    IReadOnlyList<UserDto> Users,
    int TotalCount,
    int PageNumber,
    int PageSize
);