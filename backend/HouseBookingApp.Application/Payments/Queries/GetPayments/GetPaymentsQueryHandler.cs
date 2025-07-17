using HouseBookingApp.Application.Common.Interfaces;
using HouseBookingApp.Application.DTOs.Payments;
using MediatR;

namespace HouseBookingApp.Application.Payments.Queries.GetPayments;

public class GetPaymentsQueryHandler : IRequestHandler<GetPaymentsQuery, GetPaymentsResponse>
{
    private readonly IPaymentRepository _paymentRepository;

    public GetPaymentsQueryHandler(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<GetPaymentsResponse> Handle(GetPaymentsQuery request, CancellationToken cancellationToken)
    {
        var payments = await _paymentRepository.GetPaymentsAsync(
            request.PageNumber,
            request.PageSize,
            request.ReservationId,
            request.Status,
            request.Method,
            request.FromDate,
            request.ToDate,
            cancellationToken);

        var totalCount = await _paymentRepository.GetPaymentsCountAsync(
            request.ReservationId,
            request.Status,
            request.Method,
            request.FromDate,
            request.ToDate,
            cancellationToken);

        return new GetPaymentsResponse
        {
            Payments = payments.Select(p => new PaymentSummaryDto
            {
                Id = p.Id,
                PaymentNumber = p.PaymentNumber,
                ReservationId = p.ReservationId,
                Amount = p.Amount,
                Status = p.Status,
                Method = p.Method,
                ProcessedAt = p.ProcessedAt,
                CreatedAt = p.CreatedAt
            }).ToList(),
            TotalCount = totalCount,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize
        };
    }
}