using HouseBookingApp.Domain.Entities;
using HouseBookingApp.Domain.Enums;

namespace HouseBookingApp.Application.Common.Interfaces;

public interface IPaymentRepository
{
    Task<Payment?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Payment?> GetByPaymentNumberAsync(string paymentNumber, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Payment>> GetPaymentsAsync(
        int pageNumber,
        int pageSize,
        Guid? reservationId = null,
        PaymentStatus? status = null,
        PaymentMethod? method = null,
        DateTime? fromDate = null,
        DateTime? toDate = null,
        CancellationToken cancellationToken = default);
    Task<int> GetPaymentsCountAsync(
        Guid? reservationId = null,
        PaymentStatus? status = null,
        PaymentMethod? method = null,
        DateTime? fromDate = null,
        DateTime? toDate = null,
        CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Payment>> GetByReservationAsync(Guid reservationId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Payment>> GetPendingPaymentsAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Payment>> GetFailedPaymentsAsync(CancellationToken cancellationToken = default);
    Task AddAsync(Payment payment, CancellationToken cancellationToken = default);
    Task UpdateAsync(Payment payment, CancellationToken cancellationToken = default);
    Task DeleteAsync(Payment payment, CancellationToken cancellationToken = default);
}