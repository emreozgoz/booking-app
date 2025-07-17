using HouseBookingApp.Application.DTOs.Users;
using MediatR;

namespace HouseBookingApp.Application.User.Query.GetUsers;

public record GetUsersQuery(
    int PageNumber = 1,
    int PageSize = 10,
    string? SearchTerm = null,
    bool? IsActive = null
) : IRequest<GetUsersResponse>;