using HouseBookingApp.Domain.Entities;
using HouseBookingApp.Domain.ValueObjects;

namespace HouseBookingApp.Application.Common.Interfaces;

public interface IUserRepository
{
    Task<HouseBookingApp.Domain.Entities.User?> GetByIdAsync(UserId id, CancellationToken cancellationToken = default);
    Task<HouseBookingApp.Domain.Entities.User?> GetByEmailAsync(Email email, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<HouseBookingApp.Domain.Entities.User>> GetUsersAsync(
        int pageNumber,
        int pageSize,
        string? searchTerm,
        bool? isActive,
        CancellationToken cancellationToken = default);
    Task<int> GetUsersCountAsync(
        string? searchTerm,
        bool? isActive,
        CancellationToken cancellationToken = default);
    Task AddAsync(HouseBookingApp.Domain.Entities.User user, CancellationToken cancellationToken = default);
    Task UpdateAsync(HouseBookingApp.Domain.Entities.User user, CancellationToken cancellationToken = default);
    Task DeleteAsync(HouseBookingApp.Domain.Entities.User user, CancellationToken cancellationToken = default);
}