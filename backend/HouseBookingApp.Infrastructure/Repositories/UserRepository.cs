using HouseBookingApp.Application.Common.Interfaces;
using HouseBookingApp.Domain.ValueObjects;
using HouseBookingApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HouseBookingApp.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<HouseBookingApp.Domain.Entities.User?> GetByIdAsync(UserId id, CancellationToken cancellationToken = default)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Id == id.Value, cancellationToken);
    }

    public async Task<HouseBookingApp.Domain.Entities.User?> GetByEmailAsync(Email email, CancellationToken cancellationToken = default)
    {
        // Convert Email to string for EF Core comparison
        string emailString = email;
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Email == Email.Create(emailString), cancellationToken);
    }

    public async Task<IReadOnlyList<HouseBookingApp.Domain.Entities.User>> GetUsersAsync(
        int pageNumber,
        int pageSize,
        string? searchTerm,
        bool? isActive,
        CancellationToken cancellationToken = default)
    {
        var query = _context.Users.AsQueryable();

        if (!string.IsNullOrEmpty(searchTerm))
        {
            query = query.Where(u => 
                u.FirstName.Contains(searchTerm) || 
                u.LastName.Contains(searchTerm) ||
                EF.Functions.Like(u.Email.Value, $"%{searchTerm}%"));
        }

        if (isActive.HasValue)
        {
            query = query.Where(u => u.IsActive == isActive.Value);
        }

        return await query
            .OrderBy(u => u.FirstName)
            .ThenBy(u => u.LastName)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }

    public async Task<int> GetUsersCountAsync(
        string? searchTerm,
        bool? isActive,
        CancellationToken cancellationToken = default)
    {
        var query = _context.Users.AsQueryable();

        if (!string.IsNullOrEmpty(searchTerm))
        {
            query = query.Where(u => 
                u.FirstName.Contains(searchTerm) || 
                u.LastName.Contains(searchTerm) ||
                EF.Functions.Like(u.Email.Value, $"%{searchTerm}%"));
        }

        if (isActive.HasValue)
        {
            query = query.Where(u => u.IsActive == isActive.Value);
        }

        return await query.CountAsync(cancellationToken);
    }

    public async Task AddAsync(HouseBookingApp.Domain.Entities.User user, CancellationToken cancellationToken = default)
    {
        await _context.Users.AddAsync(user, cancellationToken);
    }

    public Task UpdateAsync(HouseBookingApp.Domain.Entities.User user, CancellationToken cancellationToken = default)
    {
        _context.Users.Update(user);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(HouseBookingApp.Domain.Entities.User user, CancellationToken cancellationToken = default)
    {
        _context.Users.Remove(user);
        return Task.CompletedTask;
    }

    public async Task<HouseBookingApp.Domain.Entities.User?> GetByEmailStringAsync(string email, CancellationToken cancellationToken = default)
    {
        var emailObj = Email.Create(email);
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Email == emailObj, cancellationToken);
    }

    public async Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken = default)
    {
        var emailObj = Email.Create(email);
        return await _context.Users
            .AnyAsync(u => u.Email == emailObj, cancellationToken);
    }
}