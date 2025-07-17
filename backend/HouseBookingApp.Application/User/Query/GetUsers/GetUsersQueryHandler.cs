using HouseBookingApp.Application.Common.Interfaces;
using HouseBookingApp.Application.DTOs.Users;
using MediatR;

namespace HouseBookingApp.Application.User.Query.GetUsers;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, GetUsersResponse>
{
    private readonly IUserRepository _userRepository;

    public GetUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetUsersResponse> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetUsersAsync(
            request.PageNumber,
            request.PageSize,
            request.SearchTerm,
            request.IsActive,
            cancellationToken);

        var totalCount = await _userRepository.GetUsersCountAsync(
            request.SearchTerm,
            request.IsActive,
            cancellationToken);

        var userDtos = users.Select(user => new UserDto(
            user.Id,
            user.Email.Value,
            user.FirstName,
            user.LastName,
            user.Role.ToString(),
            user.IsEmailVerified,
            user.IsActive,
            user.CreatedAt,
            user.LastLoginAt)).ToList();

        return new GetUsersResponse(
            userDtos,
            totalCount,
            request.PageNumber,
            request.PageSize);
    }
}