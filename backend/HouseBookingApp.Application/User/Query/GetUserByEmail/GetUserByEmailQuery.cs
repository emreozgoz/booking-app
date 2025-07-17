using HouseBookingApp.Application.DTOs.Users;
using MediatR;

namespace HouseBookingApp.Application.User.Query.GetUserByEmail;

public record GetUserByEmailQuery(string Email) : IRequest<UserDto?>;