using HouseBookingApp.Application.DTOs.Payments;
using HouseBookingApp.Domain.Enums;
using MediatR;

namespace HouseBookingApp.Application.Payments.Queries.GetPayments;

public record GetPaymentsQuery(
    int PageNumber = 1,
    int PageSize = 10,
    Guid? ReservationId = null,
    PaymentStatus? Status = null,
    PaymentMethod? Method = null,
    DateTime? FromDate = null,
    DateTime? ToDate = null
) : IRequest<GetPaymentsResponse>;

public class GetPaymentsResponse
{
    public List<PaymentSummaryDto> Payments { get; set; } = new();
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;
}