using HouseBookingApp.Application.DTOs.Users;
using MediatR;

namespace HouseBookingApp.Application.User.Query.GetUserById;

public record GetUserByIdQuery(Guid UserId) : IRequest<UserDto?>;