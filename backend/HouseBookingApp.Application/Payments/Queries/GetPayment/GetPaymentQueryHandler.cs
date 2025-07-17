using HouseBookingApp.Application.Common.Interfaces;
using HouseBookingApp.Application.DTOs.Payments;
using MediatR;

namespace HouseBookingApp.Application.Payments.Queries.GetPayment;

public class GetPaymentQueryHandler : IRequestHandler<GetPaymentQuery, PaymentDto>
{
    private readonly IPaymentRepository _paymentRepository;

    public GetPaymentQueryHandler(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<PaymentDto> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
    {
        var payment = await _paymentRepository.GetByIdAsync(request.Id, cancellationToken);
        
        if (payment == null)
            throw new ArgumentException($"Payment with ID {request.Id} not found");

        return new PaymentDto
        {
            Id = payment.Id,
            PaymentNumber = payment.PaymentNumber,
            ReservationId = payment.ReservationId,
            Amount = payment.Amount,
            Status = payment.Status,
            Method = payment.Method,
            TransactionId = payment.TransactionId,
            PaymentGateway = payment.PaymentGateway,
            ProcessedAt = payment.ProcessedAt,
            FailureReason = payment.FailureReason,
            RefundReason = payment.RefundReason,
            RefundedAt = payment.RefundedAt,
            CreatedAt = payment.CreatedAt,
            UpdatedAt = payment.UpdatedAt
        };
    }
}