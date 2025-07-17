using HouseBookingApp.Application.Common.Interfaces;
using HouseBookingApp.Domain.Entities;
using HouseBookingApp.Domain.Enums;
using HouseBookingApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HouseBookingApp.Infrastructure.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly ApplicationDbContext _context;

    public PaymentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Payment?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Payments
            .Include(p => p.Reservation)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task<Payment?> GetByPaymentNumberAsync(string paymentNumber, CancellationToken cancellationToken = default)
    {
        return await _context.Payments
            .Include(p => p.Reservation)
            .FirstOrDefaultAsync(p => p.PaymentNumber == paymentNumber, cancellationToken);
    }

    public async Task<IReadOnlyList<Payment>> GetPaymentsAsync(
        int pageNumber,
        int pageSize,
        Guid? reservationId = null,
        PaymentStatus? status = null,
        PaymentMethod? method = null,
        DateTime? fromDate = null,
        DateTime? toDate = null,
        CancellationToken cancellationToken = default)
    {
        var query = _context.Payments
            .Include(p => p.Reservation)
            .AsQueryable();

        if (reservationId.HasValue)
        {
            query = query.Where(p => p.ReservationId == reservationId.Value);
        }

        if (status.HasValue)
        {
            query = query.Where(p => p.Status == status.Value);
        }

        if (method.HasValue)
        {
            query = query.Where(p => p.Method == method.Value);
        }

        if (fromDate.HasValue)
        {
            query = query.Where(p => p.CreatedAt >= fromDate.Value);
        }

        if (toDate.HasValue)
        {
            query = query.Where(p => p.CreatedAt <= toDate.Value);
        }

        return await query
            .OrderByDescending(p => p.CreatedAt)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }

    public async Task<int> GetPaymentsCountAsync(
        Guid? reservationId = null,
        PaymentStatus? status = null,
        PaymentMethod? method = null,
        DateTime? fromDate = null,
        DateTime? toDate = null,
        CancellationToken cancellationToken = default)
    {
        var query = _context.Payments.AsQueryable();

        if (reservationId.HasValue)
        {
            query = query.Where(p => p.ReservationId == reservationId.Value);
        }

        if (status.HasValue)
        {
            query = query.Where(p => p.Status == status.Value);
        }

        if (method.HasValue)
        {
            query = query.Where(p => p.Method == method.Value);
        }

        if (fromDate.HasValue)
        {
            query = query.Where(p => p.CreatedAt >= fromDate.Value);
        }

        if (toDate.HasValue)
        {
            query = query.Where(p => p.CreatedAt <= toDate.Value);
        }

        return await query.CountAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Payment>> GetByReservationAsync(Guid reservationId, CancellationToken cancellationToken = default)
    {
        return await _context.Payments
            .Where(p => p.ReservationId == reservationId)
            .OrderBy(p => p.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Payment>> GetPendingPaymentsAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Payments
            .Include(p => p.Reservation)
            .Where(p => p.Status == PaymentStatus.Pending)
            .OrderBy(p => p.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Payment>> GetFailedPaymentsAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Payments
            .Include(p => p.Reservation)
            .Where(p => p.Status == PaymentStatus.Failed)
            .OrderByDescending(p => p.ProcessedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Payment payment, CancellationToken cancellationToken = default)
    {
        await _context.Payments.AddAsync(payment, cancellationToken);
    }

    public Task UpdateAsync(Payment payment, CancellationToken cancellationToken = default)
    {
        _context.Payments.Update(payment);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Payment payment, CancellationToken cancellationToken = default)
    {
        _context.Payments.Remove(payment);
        return Task.CompletedTask;
    }
}